using KpopZtationLab.Controllers;
using KpopZtationLab.Models;
using System;
using System.Collections.Generic;
using KpopZtationLab.Pattern;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtationLab.Factory;
using System.IO;

namespace KpopZtationLab.Views.Admin
{
    public partial class InsertArtists : System.Web.UI.Page
    {
        protected List<Artist> artists = new List<Artist>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                artists = CategoryController.Get_All_Artist();
            }
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            var name = ArtistTxt.Text;
            errLbl.Visible = false;
            string err = CategoryController.Validate(name, ArtistImageUpload);
            if(err!="")
            {
                errLbl.Text = err;
                errLbl.Visible = true;
                return;
            }
            var image = CategoryController.Save_Image(ArtistImageUpload);
            var artist = CategoryFactory.Create(name, image);

            CategoryController.Create_Artist(artist);

            Response.Redirect(Routes.Route.Home);
        }
    }
}