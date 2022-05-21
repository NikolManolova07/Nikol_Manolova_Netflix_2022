using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Data.Entities
{
    public class Genre : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(500, MinimumLength = 5)]
        public string GenreInfo { get; set; }

        public bool IsPopular { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
