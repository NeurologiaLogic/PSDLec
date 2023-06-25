using KpopZtationLab.Factory;
using KpopZtationLab.Models;
using KpopZtationLab.Pattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KpopZtationLab.Handler
{
    public class ProductHandler
    {
        public static void Add(int ArtistID, string AlbumName, string AlbumImage, int AlbumPrice, int AlbumStock, string AlbumDescription)
        {
            Album album = ProductFactory.Create(ArtistID, AlbumName, AlbumImage, AlbumPrice, AlbumStock, AlbumDescription);
            repo.albums.Add(album);
        }

        public static void Remove(int id)
        {
            var transactionDetail = repo.transactionDetails.Find(x => x.AlbumID == id).ToList();
            Album album = repo.albums.Find(x => x.AlbumID == id).FirstOrDefault();
            var carts = repo.carts.Find(x => x.AlbumID == id).ToList();
            repo.carts.RemoveRange(carts);
            repo.transactionDetails.RemoveRange(transactionDetail);
            repo.albums.Remove(album);
        }

        

        public static List<Album> getAlbum(int artistID)
        {
            return repo.albums.Find(x => x.ArtistID == artistID).ToList();

        }

        public static Album get_album_by_id(int id)
        {
            return repo.albums.Find(x => x.AlbumID == id).FirstOrDefault();

        }

        public static bool Album_Check_Unique(string albumName)
        {
            return repo.albums.Find(x => x.AlbumName == albumName).Count() == 0;
        }

        public static void update(int id, string albumName, string albumImage, string albumDescription, int albumPrice, int albumStock)
        {
            var album = repo.albums.Find(x => x.AlbumID == id).FirstOrDefault();
            if (album != null)
            {
                album.AlbumName = albumName;
                album.AlbumDescription = albumDescription;
                album.AlbumPrice = albumPrice;
                album.AlbumStock = albumStock;
                album.AlbumImage = albumImage;
                repo.albums.Update(album);
            }
        }

        public static string save_Image(FileUpload file)
        {
            string path = "/Assets/Images/Albums/";
            string fileName = Path.GetFileName(file.PostedFile.FileName);
            string fullPath = path + fileName;
            string physicalPath = HttpContext.Current.Server.MapPath(fullPath);
            file.PostedFile.SaveAs(physicalPath);
            return fullPath;
        }
    }
}
