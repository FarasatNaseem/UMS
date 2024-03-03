namespace UMS.Api.Helpers
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Linq;

    /// <summary>
    /// Helper class providing methods for working with ModelState in the UMS API.
    /// </summary>
    public static class ModelStateHelper
    {
        /// <summary>
        /// Gets a concatenated string of model state errors.
        /// </summary>
        /// <param name="modelState">The ModelStateDictionary containing validation errors.</param>
        /// <returns>A string representing model state errors with field names and corresponding error messages.</returns>
        public static string GetErrors(ModelStateDictionary modelState)
        {
            // Filter model state errors and create a dictionary of field names and associated error messages
            var errors = modelState
                .Where(e => e.Value.Errors.Any())
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => string.Join(", ", kvp.Value.Errors.Select(error => error.ErrorMessage))
                );

            // Concatenate field names and error messages into a single string
            return string.Join(", ", errors.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        }
    }
}