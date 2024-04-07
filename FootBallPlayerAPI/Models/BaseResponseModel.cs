using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayerAPI.Models
{
    public class BaseResponseModel
    {
        public bool Status { get; set; }

        public String Message { get; set; }

        public object Data { get; set; }
    }
}
