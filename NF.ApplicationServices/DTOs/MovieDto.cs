using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.ApplicationServices.DTOs
{
    public class MovieDto : BaseDto, IValidate
    {
        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string ReleaseCountry { get; set; }

        public DirectorDto Director { get; set; }

        public ProducerDto Producer { get; set; }

        public GenreDto Genre { get; set; }

        public string MovieInfo { get; set; }

        public RatingDto Rating { get; set; }

        public bool Validate()
        {
            if (!String.IsNullOrEmpty(ReleaseCountry) && !String.IsNullOrEmpty(MovieInfo))
            {
                return !String.IsNullOrEmpty(Title) && Title.Length >= 2 && Title.Length <= 50 &&
                   ReleaseCountry.Length >= 2 && ReleaseCountry.Length <= 50 &&
                   MovieInfo.Length >= 5 && MovieInfo.Length <= 1000;
            }
            if (!String.IsNullOrEmpty(ReleaseCountry) && String.IsNullOrEmpty(MovieInfo))
            {
                return !String.IsNullOrEmpty(Title) && Title.Length >= 2 && Title.Length <= 50 &&
                   ReleaseCountry.Length >= 2 && ReleaseCountry.Length <= 50;
            }
            if (String.IsNullOrEmpty(ReleaseCountry) && !String.IsNullOrEmpty(MovieInfo))
            {
                return !String.IsNullOrEmpty(Title) && Title.Length >= 2 && Title.Length <= 50 &&
                   MovieInfo.Length >= 5 && MovieInfo.Length <= 1000;
            }
            return !String.IsNullOrEmpty(Title) && Title.Length >= 2 && Title.Length <= 50;
        }
    }
}
