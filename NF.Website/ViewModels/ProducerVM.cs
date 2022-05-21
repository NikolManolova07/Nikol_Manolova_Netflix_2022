using NF.Website.ProducersReference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NF.Website.ViewModels
{
    public class ProducerVM
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
        [Display(Name = "Producer Information")]
        public string ProducerInfo { get; set; }

        public ProducerVM() { }

        public ProducerVM(ProducerDto producerDto)
        {
            Id = producerDto.Id;
            FirstName = producerDto.FirstName;
            LastName = producerDto.LastName;
            ProducerInfo = producerDto.ProducerInfo;
        }
    }
}