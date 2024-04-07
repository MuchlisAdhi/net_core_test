using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayerAPI.Entities
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String Name { get; set; }

        public int Age { get; set; }

        [Required]
        [MaxLength(255)]
        public String BirthPlace { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }
    }
}
