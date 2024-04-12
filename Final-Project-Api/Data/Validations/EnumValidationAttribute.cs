using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Validations
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false
    )]
    internal class EnumValidationAttribute : ValidationAttribute
    {
        private readonly Type enumType;

        public EnumValidationAttribute(Type enumType) => this.enumType = enumType;

        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return false;

            string[] enumNames = Enum.GetNames(this.enumType);

            return enumNames.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
        }
    }
}
