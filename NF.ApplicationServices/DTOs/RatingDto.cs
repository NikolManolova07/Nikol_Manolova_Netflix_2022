using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.ApplicationServices.DTOs
{
    public class RatingDto : BaseDto, IValidate
    {
        public string Name { get; set; }

        public bool Validate()
        {
            return !String.IsNullOrEmpty(Name) && Name.Length >=2 && Name.Length <= 50;
        }
    }
}
