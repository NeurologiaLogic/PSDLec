using KpopZtationLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using KpopZtationLab.Pattern;
using KpopZtationLab.Handler;

namespace KpopZtationLab.Controllers
{
    public class CategoryController
    {
        const int MAX_FILE_SIZE = 2100000;
        public static bool Artist_IsUnique(string artistName)
        {
            if (artistName == "") return false;
            return CategoryHandler.artist_IsUnique(artistName);
        }

        public static bool Image_Less_Than_2mb(FileUpload file)
        {
            if (file == null) return false;
            return file.PostedFile.ContentLength < MAX_FILE_SIZE;
        }
        public static bool file_IsImageExtension(FileUpload file) 
        { 
            return true;
        }

        public static Artist Get_Artist_By_ID(int id)
        {
            return CategoryHandler.get_Artist_By_ID(id);
        }

        public static void Create_Artist(Artist artistToAdd)
        {

            CategoryHandler.create(artistToAdd);
        }

        public static List<Artist> Get_All_Artist()
        {
            return CategoryHandler.get_All_Artist();
        }
        public static string Save_Image(FileUpload file)
        {
            return CategoryHandler.saveImage(file);
        }

        public static void Remove(int id)
        {
            CategoryHandler.remove(id);
        }

        public static void Update(int id,string name,string imageURL)
        {
            CategoryHandler.update(id, name, imageURL);
        }
        private static bool IsImageSelected(FileUpload file)
        {
            return file != null && file.HasFile;
        }
        public static string Validate(string name,FileUpload ArtistImageUpload)
        {
            if (!Artist_IsUnique(name))
            {
                return "artist is not unique";
            };
            if (
                !Image_Less_Than_2mb(ArtistImageUpload)
                && file_IsImageExtension(ArtistImageUpload))
            {
                return "File must be less than 2mb and an image type";
            };

            if (!IsImageSelected(ArtistImageUpload))
            {
                return "An image must be chosen.";
            }

            return "";
        }
    }
}
