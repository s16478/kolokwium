using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Event
    {

        public int IdEvent { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



        public virtual ICollection<EventOrganiser> EventOrganisers { get; set; }
        public virtual ICollection<ArtistEvent> ArtistEvents { get; set; }

    }
}
