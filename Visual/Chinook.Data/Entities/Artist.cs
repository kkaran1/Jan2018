﻿using System;
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
    [Table("Artists")]
   public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }

        //navigational properties
        //The virtual property Albums point to all children of the 
        //Parent instant
        public virtual ICollection<Album>Albums { get; set; }

    }
}
