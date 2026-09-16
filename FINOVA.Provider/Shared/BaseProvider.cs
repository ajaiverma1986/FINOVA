

using System.ComponentModel.DataAnnotations;

namespace FINOVA.Provider.Shared
{
    /// <summary>
    /// Base Provider class contains all shared methods and properties
    /// </summary>
    public class BaseProvider
    {
        
        public static bool Validate(out List<ValidationResult> validationResults, object request)
        {
            var context = new ValidationContext(request, serviceProvider: null, items: null);
            validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(request, context, validationResults, true);

            return isValid;
        }


    }
}
