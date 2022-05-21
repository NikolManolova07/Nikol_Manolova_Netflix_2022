using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.ApplicationServices.DTOs
{
    public class DirectorDto : BaseDto, IValidate
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DirectorInfo { get; set; }

        public bool Validate()
        {
            if (!String.IsNullOrEmpty(DirectorInfo))
            {
                return !String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(LastName) &&
                   FirstName.Length >= 2 && FirstName.Length <= 50 &&
                   LastName.Length >= 2 && LastName.Length <= 50 &&
                   DirectorInfo.Length >= 5 && DirectorInfo.Length <= 1000;
            }
            return !String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(LastName) &&
                   FirstName.Length >= 2 && FirstName.Length <= 50 &&
                   LastName.Length >= 2 && LastName.Length <= 50;
        }
    }
}
