using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespace
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        //Dump all the instances of the entity
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Artist> Artist_ListAll()
        {
            using (var context = new ChinookContext())
            {
                //this is not using Link
                //This is using entity Framework
               return context.Artists.ToList();
            }
        }
        //dump a particular instance of the entity via the primary Key
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Artist Artist_Get(int artistid)
        {
            using (var context = new ChinookContext())
            {
                //this is not using Link
                //This is using entity Framework
                return context.Artists.Find(artistid);
            }
        }
    }
}
