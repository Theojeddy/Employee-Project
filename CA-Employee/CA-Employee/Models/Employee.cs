using CA_Employee.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace CA_Employee.Models
{
    public class Employee
    {
        // Create an encapsulated Employee list to hold the employee's.
        private static List<Employee> employeeList = new List<Employee>();

        // Departments
        public const string HR_DEPARTMENT = "HR";
        public const string DEV_DEPARTMENT = "Development";

        // Roles
        public const string JUNIOR_DEVELOPER_ROLE = "Junior Developer";
        public const string SENIOR_DEVELOPER_ROLE = "Senior Developer";

        // Salary bands
        public const string SALARY_BAND_A = "A";
        public const string SALARY_BAND_B = "B";
        public const string SALARY_BAND_C = "C";
        public const string SALARY_BAND_D = "D";


        //Private fields 
        private int _id;
        private string _fullName;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _address;
        private string _department;
        private string _role;
        private List<string> _tasks;
        private DateTime _startDate;
        private DateTime _endDate;
        private List<DateTime> _holidays;
        private bool _isWorking;
        private string _salaryBand;

        /// <summary>
        /// Gets or Sets the Employees Id.
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the employees Full Name.
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        /// <summary>
        /// Gets or sets the employees First Name.
        /// </summary>
        /// <remarks>Set to only allow values of less than 40 charachters</remarks>
        [StringLength(40, ErrorMessage = "First name must be less than 40 characters.")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        /// <summary>
        /// Gets or sets the employees Last Name.
        /// </summary>
        /// <remarks>Set to only allow values of less than 40 charachters</remarks>
        [StringLength(40, ErrorMessage = "Last name must be less than 40 characters.")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Gets or sets the employees Email.
        /// </summary>
        /// <remarks>Regular expression checks that the inputted field has an'@' and contains a domain suffix</remarks>
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Gets or sets the employees Address.
        /// </summary>
        /// <remarks>Set to only allow values of less than 255 charachters</remarks>
        [StringLength(255, ErrorMessage = "Address must be less than 255 characters.")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// Gets or sets the employees Department.
        /// </summary>
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        /// <summary>
        /// Gets or sets the employees Role.
        /// </summary>
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        /// <summary>
        /// Gets or sets the list of the employees Tasks.
        /// </summary>
        [NoDuplicates(ErrorMessage = "The list contains duplicate items.")]
        public List<string> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }

        /// <summary>
        /// Gets or sets the employees start date.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        /// <summary>
        /// Gets or sets the employees end date.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        /// <summary>
        /// Gets or sets the list of the employees holidays.
        /// </summary>
        [NoDuplicates(ErrorMessage = "The list contains duplicate items.")]
        public List<DateTime> Holidays
        {
            get { return _holidays; }
            set { _holidays = value; }
        }

        /// <summary>
        /// Gets or sets the list of the employees holidays.
        /// </summary>
        public bool IsWorking
        {
            get { return _isWorking; }
            set { _isWorking = value; }
        }

        /// <summary>
        /// Gets or sets the employees Salary band.
        /// </summary>
        public string SalaryBand
        {
            get { return _salaryBand; }
            set { _salaryBand = value; }
        }

        /// <summary>
        /// Initializes a new instance of the Employee class with the required default values.
        /// </summary>
        public Employee()
        {
            Tasks = new List<string>();
            Holidays = new List<DateTime>();
        }

        /// <summary>
        /// Constructor to create a new object of employee class.
        /// </summary>
        /// <param name="id">The identifer of the employee.</param>
        /// <param name="firstName">The first name of the employee.</param>
        /// <param name="lastName">The last name of the employee.</param>
        /// <param name="email">The employee's email.</param>
        /// <param name="address">The employee's address</param>
        /// <param name="department">The deparement the employee works in.</param>
        /// <param name="role">The employee's role.</param>
        /// <param name="tasks">The list of tassk the employee has.</param>
        /// <param name="startDate">The start date of the employee.</param>
        /// <param name="endDate">The end date of the employee.</param>
        /// <param name="holidays">The list of holidays the employee has.</param>

        public Employee(int id, string firstName, string lastName, string email, string address, string department, string role, List<string> tasks, DateTime startDate, DateTime endDate, List<DateTime> holidays, bool isWorking, string salaryBand)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            Department = department;
            Role = role;
            Tasks = tasks;
            StartDate = startDate;
            EndDate = endDate;
            Holidays = holidays;
            IsWorking = isWorking;
            SalaryBand = salaryBand;
        }

        /// <summary>
        /// Static constructor to initialize each employee in the employee list.
        /// </summary>
        static Employee()
        {
            employeeList.Add(new Employee(1, "Darren", "Hickman", "Dhickman@Complianceassist.co.uk", "10 Kellogs Lane", HR_DEPARTMENT, "",
                new List<string> { "Make Tea", "Hire", "Solve Disputes", "Hold Review", "Give feedback" },
                new DateTime(2022, 1, 1), new DateTime(2028, 1, 1),
                new List<DateTime>
                {
            new DateTime(2022, 12, 25),
            new DateTime(2022, 11, 24),
            new DateTime(2022, 10, 31),
            new DateTime(2022, 9, 5),
            new DateTime(2022, 7, 4)
                },false, "A"));

            employeeList.Add(new Employee(2, "Theo", "Eddy", "Teddy@Complianceassist.co.uk", "20 Frosties Street", DEV_DEPARTMENT, JUNIOR_DEVELOPER_ROLE,
                new List<string> { "Learn Code", "Test Code", "Read Code", "Understand Code", "Learn Theory" },
                new DateTime(2021, 5, 15), new DateTime(2029, 5, 15),
                new List<DateTime>
                {
            new DateTime(2022, 12, 25),
            new DateTime(2023, 1, 1),
            new DateTime(2023, 7, 4),
            new DateTime(2022, 11, 24),
            new DateTime(2022, 10, 31)
                }, false, "B"));

            employeeList.Add(new Employee(3, "Julian", "Chappel", "Jchappel@Complianceassist.co.uk", "20 Weetabix Road", DEV_DEPARTMENT, SENIOR_DEVELOPER_ROLE,
                new List<string> { "Write Code", "Fix Bugs", "Mentor Junior", "Expand Knowledge", "Test code" },
                new DateTime(2020, 3, 1), new DateTime(2026, 3, 1),
                new List<DateTime>
                {
            new DateTime(2022, 12, 25),
            new DateTime(2023, 1, 1),
            new DateTime(2023, 7, 4),
            new DateTime(2022, 11, 24),
            new DateTime(2022, 10, 31)
                }, false, "D"));
        }

        /// <summary>
        /// Static method that returns an employee dictionary object based on the provided employee ID.
        /// </summary>
        /// <param name="id">The identifer of the employee.</param>
        /// <remarks>If there is no id, this returns null.</remarks>
        public static Employee GetEmployee(int id)
        {
            // If id has no value, return null.
            if (id != null)
            {
                // Returns the first value with a matching id
                return employeeList.FirstOrDefault(e => e.ID == id);
            }
            return null;
        }

        public static void UpdateEmployee(Employee updatedEmployee)
        {
            // id subtracts 1 from id to update the correct employee in the list.
            int id = updatedEmployee.ID - 1;
            if (id != null)
            {
                employeeList[id] = updatedEmployee;
            }
        }

        /// <summary>
        /// An instance method to generate the full name of the employee.
        /// </summary>
        /// <returns>The full name of the employee.</returns>
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        /// <summary>
        /// Static method to get the list of all the employees.
        /// </summary>
        /// <returns>The list of employees.</returns>
        public static List<Employee> GetAllEmployees()
        {
            return employeeList;
        }

        /// <summary>
        /// Checks if the given date is a working day for the employee.
        /// </summary>
        /// <param name="startDate">Employee's start date.</param>
        /// <param name="endDate">Employee's end date.</param>
        /// <param name="holidays">List of employee's holiday dates.</param>
        /// <param name="today">Date to check if it's a working day.</param>
        /// <returns>True if today is a working day, false otherwise.</returns>
        public bool CheckWorkingDay(DateTime startDate, DateTime endDate, List<DateTime> holidays, DateTime today)
        {
            // Check if today is between start date and end date
            if (today >= startDate && today <= endDate)
            {
                // Check if today is not a holiday
                if (!holidays.Contains(today))
                {
                    return true; // It's a working day
                }
            }
            return false; // It's not a working day
        }

        /// <summary>
        /// Static method to set the length of the holidays list depending on the salary band of the employee. 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static List<DateTime> SetHolidaysLength(int employeeId)
        {
            // Get the employee with the mathcing Employee id.
            Employee employee = employeeList.FirstOrDefault(e => e.ID == employeeId);


            if (employee != null)
            {
                int maxHolidayDays;

                // Depending on the Salary band, set the max holiday days. 
                if (employee.SalaryBand == SALARY_BAND_A)
                {
                    maxHolidayDays = 2;
                } else if (employee.SalaryBand == SALARY_BAND_B) 
                {
                    maxHolidayDays = 3; 
                }
                else if (employee.SalaryBand == SALARY_BAND_C) 
                {
                    maxHolidayDays = 4; 
                }
                else 
                {
                    maxHolidayDays = 5; 
                }
                
                // The holiday count it set to 5 days for all employees, and is then reduced depending on holiday bands.
                if (employee.Holidays.Count > maxHolidayDays)
                {
                    employee.Holidays = employee.Holidays.Take(maxHolidayDays).ToList();
                }

                return employee.Holidays;
            }

            // return null if no employee is found with a matching id
            return null; 
        }

    }

}