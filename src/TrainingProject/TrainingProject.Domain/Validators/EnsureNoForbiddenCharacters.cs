using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingProject.Domain.Validators
{
    public class EnsureNoForbiddenCharacters : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var list = (IList<string>)value;
                foreach (var element in list)
                {
                    if (element.Contains('|'))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
