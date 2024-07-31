
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CA_Employee.CustomAttributes
{
    public class NoDuplicatesAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validates that the collection contains no duplicate items.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>Validation result indicating success or failure with error message.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Attempt to cast the value to IEnumerable
            var list = value as IEnumerable;

            // Check if the cast was successful
            if (list != null)
            {
                // Casting the enumerable list to be able to iterate through the list
                var listAsList = list.Cast<object>().ToList();

                // Create a new HashSet to track items and ensure uniqueness
                var hashSet = new HashSet<object>();

                // Iterate through each item in the list
                for (int i = 0; i < listAsList.Count; i++)
                {
                    var item = listAsList[i];

                    // Attempt to add the item to the HashSet
                    // If Add returns false, the item is already in the HashSet, indicating a duplicate
                    if (!hashSet.Add(item))
                    {
                        // Construct the property name for the validation error message
                        var propertyName = $"{validationContext.DisplayName}[{i}]";

                        // Return validation result with error message indicating duplicate item
                        return new ValidationResult($"The task '{item}' is duplicated.", new[] { propertyName });
                    }
                }
            }

            // If no duplicates are found, return ValidationResult.Success indicating the property is valid
            return ValidationResult.Success;
        }
    }
}

