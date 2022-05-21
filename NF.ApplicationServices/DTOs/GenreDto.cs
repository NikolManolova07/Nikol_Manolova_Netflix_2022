using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.ApplicationServices.DTOs
{
    public class GenreDto : BaseDto, IValidate
    {
        public string Name { get; set; }

        public string GenreInfo { get; set; }

        public bool Validate()
        {
            if (!String.IsNullOrEmpty(GenreInfo))
            {
                return !String.IsNullOrEmpty(Name) && Name.Length >= 2 && Name.Length <= 50 &&
                  GenreInfo.Length >= 5 && GenreInfo.Length <= 500;
            }
            return !String.IsNullOrEmpty(Name) && Name.Length >= 2 && Name.Length <= 50;
        }
    }
}
