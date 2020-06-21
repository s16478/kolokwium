using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class EventOrganiser
    {
        public int IdEvent { get; set; }
        public int IdOrganiser { get; set; }

        public Event Event { get; set; }
        public Organiser Organiser { get; set;  }



    }
}
