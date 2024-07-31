using CA_Employee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CA_Employee.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        public const string ROUTE_EMPLOYEEDETAILS = "/EmployeeDetails/EmployeeDetails/{id}";
        public const string ROUTE_SUBMITEMPLOYEE = "/EmployeeDetails/SubmitEmployee";

        [Route(ROUTE_EMPLOYEEDETAILS)]
        public IActionResult EmployeeDetails(int id)
        {
            //Todays date to see if the day is a working day or not
            DateTime today = DateTime.Today;

            // Initialize an instance of the employee class with data from the dictionary.
            Employee employee = Employee.GetEmployee(id);

            if (employee == null)
            {
                // if employee is null, will return a balnk employee triggering an unhandled exeption
                return View(employee);
            }


            // Adds the Full name to the employee object.
            employee.FullName = employee.GetFullName();

            //Checks to see if it is a working day
            employee.IsWorking = employee.CheckWorkingDay(employee.StartDate, employee.EndDate, employee.Holidays, today);

            employee.Holidays = Employee.SetHolidaysLength(id);

            // Pass the employee to the view
            return View(employee);
        }

        /// <summary>
        /// Updates the employee with the new values inputed in the model
        /// </summary>
        /// <param name="model"> The values from the view.</param>
        /// <returns> An updated employee.</returns>
        /// 
        [HttpPost]
        [Route(ROUTE_SUBMITEMPLOYEE)]
        public IActionResult SubmitEmployee(Employee model)
        {
                if (ModelState.IsValid)
                {
                    Employee employee = Employee.GetEmployee(model.ID);
                    // Gets the value of the dictionary employee with the same id.
                    if (employee != null)
                    {
                        //Initialize a new list to store the values of the tasks that have been iterated over.
                        List<string> seenTasks = new List<string>();

                        // Serverside validation for the Tasks
                        // Check for duplicate tasks
                        for (int i = 0; i < model.Tasks.Count; i++)
                        {
                            string currentTask = model.Tasks[i];

                            // Check if this task appears more than once in the list
                            if (seenTasks.Contains(currentTask))
                            {
                                // Add model error for the current task index
                                ModelState.AddModelError($"Tasks[{i}]", $"The task '{currentTask}' is duplicated.");
                            }

                            //Add the current value being used in the comparison to the list.
                            seenTasks.Add(currentTask);
                        }

                    // Checks to see if the value of start date is later than that of end date.
                    if (model.StartDate > model.EndDate)
                    {
                        ModelState.AddModelError($"EndDate", "End date must be after Start date.");
                    }

                    // Checks each value in the list of holidays to ensure they are after the start time and before the end time.
                    for (int i = 0; i < model.Holidays.Count; i++)
                    {
                        if (model.Holidays[i] < model.StartDate || model.Holidays[i] > model.EndDate)
                        {
                            ModelState.AddModelError($"Holidays[{i}]", "Holidays must be during the time of employement.");
                        }
                    }

                    // Checking the model state as if any errors have been added, it will be invalid so the 'db' shouldn't be updated.
                    if (ModelState.IsValid)
                        {
                            // Checks the value of first name and updates if they aren't the same.
                            if (employee.FirstName != model.FirstName)
                            {
                                employee.FirstName = model.FirstName;
                            }

                            // Checks the value of last name and updates if they aren't the same.
                            if (employee.LastName != model.LastName)
                            {
                                employee.LastName = model.LastName;
                            }

                            // Checks the value of email and updates if they aren't the same.
                            if (employee.Email != model.Email)
                            {
                                employee.Email = model.Email;
                            }

                            // Checks the value of address and updates if they aren't the same.
                            if (employee.Address != model.Address)
                            {
                                employee.Address = model.Address;
                            }

                            // Checks the value of department and updates if they aren't the same.
                            if (employee.Department != model.Department)
                            {
                                employee.Department = model.Department;

                                // Checks if the department is Hr as Hr has no roles.
                                if (model.Department == "HR")
                                {
                                    employee.Role = string.Empty;
                                }
                            }

                            // Checks the value of role and updates if they aren't the same.
                            if (employee.Role != model.Role && model.Department != "HR")
                            {
                                employee.Role = model.Role;
                            }

                            // Checks the value of tasks and updates if they aren't the same.
                            if (employee.Tasks != model.Tasks)
                            {
                                employee.Tasks = model.Tasks;
                            }

                            // Checks the value of start date and updates if they aren't the same.
                            if (employee.StartDate != model.StartDate)
                            {
                                employee.StartDate = model.StartDate;
                            }

                            // Checks the value of end date  and updates if they aren't the same.
                            if (employee.EndDate != model.EndDate)
                            {
                                employee.EndDate = model.EndDate;
                            }

                            // Checks the value of holidays and updates if they aren't the same.
                            if (employee.Holidays != model.Holidays)
                            {
                                employee.Holidays = model.Holidays;
                            }

                            // Updates the Value in the list that has a matching id.
                            Employee.UpdateEmployee(employee);

                            return RedirectToAction("EmployeeDetails", new { id = employee.ID });
                        }
                    }
                }
                // If there is an error, this is what is returned
                // Returning the same view with the model to display the error messages. 
                return View("EmployeeDetails", model);
            }
        }
    }

