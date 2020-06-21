using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Artist
    {
 
        public int IdArtist { get; set; }

        public string Nickname { get; set; }

        public virtual ICollection<ArtistEvent> ArtistEvent { get; set; }
    }
}
