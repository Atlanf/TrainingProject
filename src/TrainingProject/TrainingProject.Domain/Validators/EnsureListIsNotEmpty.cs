using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace TrainingProject.Domain.Validators
{
    public class EnsureListIsNotEmpty : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var list = (IList<string>)value;
                foreach (var element in list)
                {
                    if (element == "" || element == null)
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
