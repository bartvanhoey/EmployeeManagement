using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Utilities
{
    public class ValidEmailDomainAttribute: ValidationAttribute {
        private string _allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain) => _allowedDomain = allowedDomain;
        public override bool IsValid(object value) {
            var strings = value.ToString().Split('@');
            var domain = strings[strings.Length -1];
            return (domain.ToUpperInvariant() == _allowedDomain.ToUpperInvariant());
        }

    }
}