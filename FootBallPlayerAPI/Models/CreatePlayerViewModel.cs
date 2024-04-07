using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayerAPI.Models
{
    public class CreatePlayerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of player is required.")]
        public String Name { get; set; }

        public int Age { get; set; }

        [Required(ErrorMessage = "BirthPlace of player is required.")]
        public String BirthPlace { get; set; }
    }
}
