using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Data.Entities
{
    public class Rating : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Range(0.0, 6.1)]
        public double Status { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
