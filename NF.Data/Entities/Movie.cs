using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Data.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string ReleaseCountry { get; set; }

        public int DirectorId { get; set; }

        public int ProducerId { get; set; }

        public int GenreId { get; set; }

        [StringLength(1000, MinimumLength = 5)]
        public string MovieInfo { get; set; }

        public int RatingId { get; set; }

        public bool IsOscarWinner { get; set; }

        public virtual Director Director { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
