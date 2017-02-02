using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.BLL;
using Chinook.UI;
#endregion

public partial class SamplePages_CRUDReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SelectedTitle.Text = "";
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        //clear out the old album information on the Maintain tab
        Clear_Click(sender, e);

        if(string.IsNullOrEmpty(SearchArg.Text))
        {
            MessageUserControl1.ShowInfo("Enter an Album title or part of the title.");
        }
        else
        {
            //dol a look of the data in the db via the controller
            //all actions that are external to the webpage should be done in a try/catch
            //for friendly error handling
            //we will use message user control to handle the error messages for this semester
            MessageUserControl1.TryRun(() =>
            {
            //coding block I wish message user control to try and run  and checking
            //for any error catching the errors, and displaying said errors fro me 
            //in its error panel
            //what is left for me to do; Simply the logic for the event
            //standard lookup
            AlbumController sysmgr = new AlbumController();
            List<Album> albumlist = sysmgr.Albums_GetbyTitle(SearchArg.Text);
            if (albumlist.Count == 0)
            {
                MessageUserControl1.ShowInfo("Search Result",
                    "No data for album title or partial title " + SearchArg.Text);
                AlbumList.DataSource = null;
                AlbumList.DataBind();
            }
            else
            {
                MessageUserControl1.ShowInfo("Search Result",
                    "Select the desired album for title" + SearchArg.Text);
                        AlbumList.DataSource = null;
                    AlbumList.DataBind();
                }
            });
        }
    }

   

    protected void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
    {
       

    }

    protected void AddAlbum_Click(object sender, EventArgs e)
    {
       
       
    }
    protected void UpdateAlbum_Click(object sender, EventArgs e)
    {
       
    }
    protected void DeleteAlbum_Click(object sender, EventArgs e)
    {
       
    }
    protected void Clear_Click(object sender, EventArgs e)
    {
        AlbumID.Text = "";
        AlbumTitle.Text = "";
        AlbumReleaseYear.Text = "";
        AlbumReleaseLabel.Text = "";
        ArtistList.SelectedIndex = 0;
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }

}