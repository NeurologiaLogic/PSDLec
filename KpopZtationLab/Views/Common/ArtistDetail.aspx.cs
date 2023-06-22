using KpopZtationLab.Controllers;
using KpopZtationLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationLab.Views.Common
{
    public partial class ArtistDetail : System.Web.UI.Page
    {
        protected List<Album> albums;
        protected Artist artist;
        protected int id;
        protected string role = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bool success = int.TryParse(Request.QueryString["id"], out id);
                if(!success)
                {
                    Response.Redirect(Routes.Route.Home);
                    return;
                }
                role = getRole();
                artist = ArtistController.Get_Artist_By_ID(id);
                albums = AlbumController.Get_All_Albums(id);
                AdminAlbumsRepeater.DataSource = albums;
                AdminAlbumsRepeater.DataBind();
        }

        protected string getRole()
        {
            var userCookiesAuth = Request.Cookies["userAuth"];
            if (userCookiesAuth != null)
            {
                return userCookiesAuth["role"].ToString();
            }
            else if (Session["role"] != null)
            {
                return Session["role"].ToString();
            }
            return "";
        }

        protected void NavigateToInsertAlbum_Click(object sender, EventArgs e)
        {
            int id;
            bool success = int.TryParse(Request.QueryString["id"], out id);
            if (!success)
            {
                Response.Redirect(Routes.Route.Home);
                return;
            }
            Response.Redirect(Routes.Route.InsertAlbum+"?ID=" + id);
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int ID = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect(Routes.Route.UpdateAlbum + "?ID=" + ID);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int ID = Convert.ToInt32(btn.CommandArgument);
            AlbumController.Remove(ID);
            Response.Redirect(Routes.Route.ArtistDetail + "?ID=" + id);
        }

        protected void SelectButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int ID = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect(Routes.Route.AlbumDetail + "?ID=" + ID);
        }
    }
}