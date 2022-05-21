using NF.Website.DirectorsReference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NF.Website.ViewModels
{
    public class DirectorVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(1000, MinimumLength = 5)]
        [Display(Name = "Director Information")]
        public string DirectorInfo { get; set; }

        public DirectorVM() { }

        public DirectorVM(DirectorDto directorDto)
        {
            Id = directorDto.Id;
            FirstName = directorDto.FirstName;
            LastName = directorDto.LastName;
            DirectorInfo = directorDto.DirectorInfo;
        }
    }
}