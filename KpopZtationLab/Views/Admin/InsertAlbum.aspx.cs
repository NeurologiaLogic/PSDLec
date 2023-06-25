using KpopZtationLab.Controllers;
using KpopZtationLab.Models;
using KpopZtationLab.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationLab.Views.Admin
{
    public partial class InsertAlbum : System.Web.UI.Page
    {
        protected Artist artist = new Artist();
        protected int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            bool success = int.TryParse(Request.QueryString["ID"], out id);
            if (!success)
            {
                Response.Redirect(Routes.Route.Home);
            }   
            artist = CategoryController.Get_Artist_By_ID(id);
            
        }

        protected void createAlbum_Click(object sender, EventArgs e)
        {
            //validate
            //render error if there is
            //use controller
            var AlbumName = AlbumNameTxt.Text;
            var AlbumDescription = AlbumDescriptionTxt.Text;
            int AlbumPrice = int.Parse(AlbumPriceTxt.Text);
            int AlbumStock = int.Parse(AlbumStockTxt.Text);
            string err = ProductController.Validate(AlbumName, AlbumDescription, AlbumPrice, AlbumStock, AlbumImageUpload);
            if (err != "")
            {
                errLbl.Text = err;
                errLbl.Visible = true;
                return;
            }
            var AlbumImage = ProductController.Save_Image(AlbumImageUpload);
            ProductController.Create_Album(id,AlbumName,AlbumImage,AlbumPrice,AlbumStock,AlbumDescription);
        }
    }
}