using System.ComponentModel.DataAnnotations;

namespace AppAssigments.Constants
{
    public class CustomAgeAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            if((int)value < 18)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
