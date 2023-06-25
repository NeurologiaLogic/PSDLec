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
    public class ArtistHandler
    {
        public static void remove(int id)
        {
            var transactionDetail = repo.transactionDetails.Find(x => x.Album.ArtistID == id).ToList();
            var albums = repo.albums.Find(x => x.ArtistID == id).ToList();
            var carts = repo.carts.Find(x => x.Album.ArtistID == id).ToList();
            repo.transactionDetails.RemoveRange(transactionDetail);
            repo.carts.RemoveRange(carts);
            repo.albums.RemoveRange(albums);
            var artist = repo.artists.Find(x => x.ArtistID == id).FirstOrDefault();
            repo.artists.Remove(artist);
        }

        public static void update(int id, string name, string imageURL)
        {
            var artist = repo.artists.Find(x => x.ArtistID == id).FirstOrDefault();
            if (artist != null)
            {
                artist.ArtistName = name;
                artist.ArtistImage = imageURL;
                repo.artists.Update(artist);
            }
        }

        public static void create(Artist artistToAdd)
        {
            repo.artists.Add(artistToAdd);
        }

        public static string saveImage(FileUpload file)
        {
            string path = "/Assets/Images/Artists/";
            string fileName = Path.GetFileName(file.PostedFile.FileName);
            string fullPath = path + fileName;
            string physicalPath = HttpContext.Current.Server.MapPath(fullPath);
            file.PostedFile.SaveAs(physicalPath);
            return fullPath;
        }

        public static List<Artist> get_All_Artist()
        {
            return repo.artists.Find(x => true).ToList();
        }

        public static Artist get_Artist_By_ID(int id)
        {
            return repo.artists.Find(x => x.ArtistID == id).FirstOrDefault();
        }

        public static bool artist_IsUnique(string artistName)
        {
            return repo.artists.Find(x => x.ArtistName == artistName).Count() == 0;
        }
    }
}
