using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtationLab.Models;
namespace KpopZtationLab.Factory
{
    public class ProductFactory
    {
        public static Album Create(int ArtistID, string AlbumName,string AlbumImage,int AlbumPrice,int AlbumStock,string AlbumDescription)
        {
            var createdAlbum = new Album();
            createdAlbum.ArtistID = ArtistID;
            createdAlbum.AlbumName = AlbumName;
            createdAlbum.AlbumImage = AlbumImage;
            createdAlbum.AlbumPrice = AlbumPrice;
            createdAlbum.AlbumStock = AlbumStock;
            createdAlbum.AlbumDescription = AlbumDescription;
            return createdAlbum;
        }
    }
}