using NF.Website.RatingsReference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NF.Website.ViewModels
{
    public class RatingVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Rating Name")]
        public string Name { get; set; }

        public RatingVM() { }

        public RatingVM(RatingDto ratingDto)
        {
            Id = ratingDto.Id;
            Name = ratingDto.Name;
        }
    }
}