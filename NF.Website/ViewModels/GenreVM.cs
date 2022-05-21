using NF.Website.GenresReference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NF.Website.ViewModels
{
    public class GenreVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Genre Name")]
        public string Name { get; set; }

        [StringLength(500, MinimumLength = 5)]
        [Display(Name = "Genre Information")]
        public string GenreInfo { get; set; }

        public GenreVM() { }

        public GenreVM(GenreDto genreDto)
        {
            Id = genreDto.Id;
            Name = genreDto.Name;
            GenreInfo = genreDto.GenreInfo;
        }
    }
}