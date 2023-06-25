using KpopZtationLab.Factory;
using KpopZtationLab.Models;
using KpopZtationLab.Pattern;
using KpopZtationLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtationLab.Controllers;
namespace KpopZtationLab.Views.Common
{
    public partial class AlbumDetail : System.Web.UI.Page
    {
        public Album album = new Album();
        public string role = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //dapetin data user
            int albumID = int.Parse(Request.QueryString["ID"]);
            album = ProductController.Get_album_by_id(albumID);
            role = getRole();

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
            return "None";
        }
        protected int getCurrentUserID()
        {
            var userCookies = Request.Cookies["userAuth"];
            if (userCookies != null)
            {
                return int.Parse(userCookies["id"]);
            }
            else if (Session["userAuth"] != null)
            {
                var userID = Session["userAuth"].ToString();    
                return int.Parse(userID);
            }

            Response.Redirect(Routes.Route.Home);
            return 0; // Return a default value or choose an appropriate alternative.
        }
        protected void addToCartBtn_Click(object sender, EventArgs e)
        {
            int userID = getCurrentUserID();
            int selectedQuantity = int.Parse(QuantityTxt.Text);
            ErrorLbl.Visible = false;
            string err = CartController.ValidateQuantity(selectedQuantity, album.AlbumStock);
            if(err!="")
            {
                ErrorLbl.Text = err;
                ErrorLbl.Visible = true;
                return;
            }
            CartController.Add(userID, album.AlbumID, selectedQuantity);
            Response.Redirect(Routes.Route.Cart);
        }
    }
}