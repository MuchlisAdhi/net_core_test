using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayerAPI.Models
{
    public class PlayerListViewModel
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public int Age { get; set; }

        public String BirthPlace { get; set; }
    }
}
