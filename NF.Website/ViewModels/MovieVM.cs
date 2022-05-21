using NF.Website.MoviesReference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NF.Website.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Release Country")]
        public string ReleaseCountry { get; set; }

        [Display(Name = "Director")]
        public int DirectorId { get; set; }
        public DirectorVM DirectorVM { get; set; }

        [Display(Name = "Producer")]
        public int ProducerId { get; set; }
        public ProducerVM ProducerVM { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public GenreVM GenreVM { get; set; }

        [StringLength(1000, MinimumLength = 5)]

        [Display(Name = "Movie Information")]
        public string MovieInfo { get; set; }

        [Display(Name = "Rating")]
        public int RatingId { get; set; }
        public RatingVM RatingVM { get; set; }

        public MovieVM() { }

        public MovieVM(MovieDto movieDto)
        {
            Id = movieDto.Id;
            Title = movieDto.Title;
            ReleaseDate = movieDto.ReleaseDate;
            ReleaseCountry = movieDto.ReleaseCountry;
            DirectorId = movieDto.Director.Id;
            DirectorVM = new DirectorVM
            {
                Id = movieDto.Director.Id,
                FirstName = movieDto.Director.FirstName,
                LastName = movieDto.Director.LastName,
                DirectorInfo = movieDto.Director.DirectorInfo
            };
            ProducerId = movieDto.Producer.Id;
            ProducerVM = new ProducerVM
            {
                Id = movieDto.Producer.Id,
                FirstName = movieDto.Producer.FirstName,
                LastName = movieDto.Producer.LastName,
                ProducerInfo = movieDto.Producer.ProducerInfo
            };
            GenreId = movieDto.Genre.Id;
            GenreVM = new GenreVM
            {
                Id = movieDto.Genre.Id,
                Name = movieDto.Genre.Name,
                GenreInfo = movieDto.Genre.GenreInfo
            };
            MovieInfo = movieDto.MovieInfo;
            RatingId = movieDto.Rating.Id;
            RatingVM = new RatingVM
            {
                Id = movieDto.Rating.Id,
                Name = movieDto.Rating.Name
            };
        }
    }
}