using KpopZtationLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using KpopZtationLab.Pattern;
using System.Web;
using KpopZtationLab.Factory;
using System.Web.UI.WebControls;
using System.IO;
using KpopZtationLab.Handler;

namespace KpopZtationLab.Controllers
{

    public class ProductController
    {
        const int MAX_FILE_SIZE = 2100000;
        public static bool Album_IsUnique(string albumName)
        {
            return ProductHandler.Album_Check_Unique(albumName);
        }

        public static bool Image_Less_Than_2mb()
        {
            return false;
        }
        public static List<Album> Get_All_Albums(int artistID)
        {
            return ProductHandler.getAlbum(artistID);
        }

        public static Album Get_album_by_id(int id)
        {
            return ProductHandler.get_album_by_id(id);
        }

        public static string Save_Image(FileUpload file)
        {
            return ProductHandler.save_Image(file);
        }

        public static string Create_Album(int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            
            ProductHandler.Add(ArtistID, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription);
            return "";
        }


        public static void Remove(int id)
        {
            ProductHandler.Remove(id);
        }

        public static void Update(int id, string albumName, string albumImage, string albumDescription, int albumPrice, int albumStock)
        {
            ProductHandler.update(id, albumName, albumImage, albumDescription, albumPrice, albumStock);
        }

        public static bool Name_Length_Between_1_To_50(string name)
        {
            return (name.Length >= 1 && name.Length <= 50);
        }

        public static bool Desc_Length(string desc)
        {
            return (desc.Length <= 50);
        }

        public static bool Price_interval(int price)
        {
            return (price >= 100000 && price <= 1000000);
        }

        public static bool stockCheck(int stock)
        {
            return (stock > 0);
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
        
        private static bool IsImageSelected(FileUpload file)
        {
            return file != null && file.HasFile;
        }

        public static string Validate(string albumName, string albumDescription, int albumPrice, int albumStock,FileUpload image)
        {
            if(!Album_IsUnique(albumName))
            {
                return "album name must be unique";
            }

            if (!IsImageSelected(image))
            {
                return "An image must be chosen.";
            }

            if (
                !Image_Less_Than_2mb(image)
                && file_IsImageExtension(image))
            {
                return "File must be less than 2mb and an image type";
            }

            if (!Name_Length_Between_1_To_50(albumName))
            {
                return "Album Name must be filled and smaller than 50 character";
            }

            if (!Desc_Length(albumDescription))
            {
                return "Album Description must be filled and smaller than 255 characters";
            }

            if (!Price_interval(albumPrice))
            {
                return "Must be filled and between 100000 and 1000000";
            }

            if (!stockCheck(albumStock))
            {
                return "Must be filled and more than 0";
            }

            if (!Image_Less_Than_2mb(image))
            {
                return "Must be chosen, file extension must be .png, .jpg, .jpeg, or .jfif, and file size must be lower than 2MB.";
            }

            if (!Image_Less_Than_2mb(image) && file_IsImageExtension(image))
            {
                return "File must be less than 2mb and an image type.";
            }


            return "";
        }
    }
}