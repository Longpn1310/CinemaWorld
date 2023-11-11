using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Global.Common.Atrributes
{
    //kiem tra file dau vao
    //Chi su dung cho thuoc tinh properties
    [AttributeUsage(AttributeTargets.Property)]
    //Constructor nhan toi da thuoc tinh tep

    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            this.maxFileSize = maxFileSize;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //IFormFile la interface dai dien cho tep tai lien tu client thong qua mot http

            if (value is IFormFile file)
            {
                if (file.Length > maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }
        private string GetErrorMessage()
        {
            return string.Format(GlobalConstants.MaxFileSizeErrorMessage, maxFileSize);
        }
    }
}
