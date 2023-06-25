using KpopZtationLab.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using KpopZtationLab.DummyClass;
using KpopZtationLab.Controllers;
using KpopZtationLab.Models;

namespace KpopZtationLab.Views.Common
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected List<Artist> artists;
        protected string role = "none";

        protected string getRole()
        {
            var userCookiesAuth = Request.Cookies["userAuth"];
            if (userCookiesAuth!=null)
            {
                return userCookiesAuth["role"].ToString();
            }
            else if(Session["role"]!=null)
            {
                return Session["role"].ToString();
            }
            return "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                role = getRole();
                artists = ArtistController.Get_All_Artist();
                AdminArtistsRepeater.DataSource = artists;
                AdminArtistsRepeater.DataBind();
                CustomerArtistsRepeater.DataSource = artists;
                CustomerArtistsRepeater.DataBind();
            }
        }

        protected void AdminArtistsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Edit")
            {
                Response.Redirect(Routes.Route.UpdateArtist + "?ID=" + ID);
            }
            else if (e.CommandName == "Delete")
            {
                ArtistController.Remove(ID);
                Response.Redirect(Routes.Route.Home);
            }
            else if (e.CommandName == "Select")
            {
                Response.Redirect(Routes.Route.ArtistDetail + "?ID=" + ID);
            }
        }
        protected void Admin2ArtistsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Edit")
            {
                Response.Redirect(Routes.Route.UpdateArtist + "?ID=" + ID);
            }
            else if (e.CommandName == "Delete")
            {
                ArtistController.Remove(ID);
                Response.Redirect(Routes.Route.Home);
            }
            else if (e.CommandName == "Select")
            {
                Response.Redirect(Routes.Route.ArtistDetail + "?ID=" + ID);
            }
        }
        protected void CreateArtist_Click(object sender, EventArgs e)
        {
            Response.Redirect(Routes.Route.InsertArtist);
        }

    }
}