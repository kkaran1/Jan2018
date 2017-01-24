using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespace
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace Chinook.Data.Entities
{
    [Table("Tracks")]
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        public string Name { get; set; }
        public int? albumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? genreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }


        //navigation Properties
        public virtual Album Album { get; set; }
        public virtual MediaType Mediatype { get; set; }

        //public virtual Genre Genre{get;set;}
        //public virtual ICollection<PlaylistTrack> PlaylistTracks {get; set;}
        //public virtual ICollection<InvoiceLine> InvoiceLines{get;set;}

    }
}
