using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly
{
    public class Min18YearsValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId== MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Insert a valid birthdate to check");
            }

            var age = (DateTime.Today.Year - customer.BirthDate.Value.Year);
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Must be at least 18");
        }
    }
}