using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtationLab.Models;
namespace KpopZtationLab.Factory
{
    public class CategoryFactory
    {
        public static Artist Create(string ArtistName, string ArtistImage)
        {
            var createdArtist = new Artist();
            createdArtist.ArtistName = ArtistName;
            createdArtist.ArtistImage = ArtistImage;
            return createdArtist;
        }
    }
}