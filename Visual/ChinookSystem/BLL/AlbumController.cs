using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using Chinook.Data.Entities;
using Chinook.Data.DTOs;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumArtist> ListAlbumsbyArtist()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              orderby x.Artist.Name
                              select new AlbumArtist
                              {
                                  Artist = x.Artist.Name,
                                  Title = x.Title,
                                  ReleaseYear = x.ReleaseYear,
                                  ReleaseLabel = x.ReleaseLabel
                              };
                return results.ToList();
            }
        }//eom
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Albums_GetForArtistbyName(string name)
        {
            using (var context = new ChinookContext())
            {
                //this is using linq
                //this is using the method syntax of the query
                var results = context.Albums
                      .Where(x => x.Artist.Name.Contains(name))
                      .OrderByDescending(x => x.ReleaseYear);
                //Remember if u  have used .dUMP() in Linqpad to view
                // your content of the query, .Dump() is a Linqpad method
                //it is NOT C#
                return results.ToList();
            }
        }//eom
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbumReleases> ArtistAlbumReleases_List()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              group x by x.Artist.Name into result
                              select new ArtistAlbumReleases
                              {
                                  Artist = result.Key,
                                  Albums = (from y in result
                                            select new AlbumRelease
                                            {
                                                Title = y.Title,
                                                RYear = y.ReleaseYear,
                                                Label = y.ReleaseLabel
                                            }).ToList()
                              };
                return results.ToList();
                 
            }
        }

    }//eoc
}//eon
