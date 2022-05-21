using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Data.Entities
{
    public class Director : BaseEntity
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        public bool IsFamous { get; set; }

        [StringLength(1000, MinimumLength = 5)]
        public string DirectorInfo { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
