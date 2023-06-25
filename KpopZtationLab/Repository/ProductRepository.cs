using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KpopZtationLab.Interface;
using KpopZtationLab.Models;
using KpopZtationLab.Pattern;

namespace KpopZtationLab.Repository
{
    public class ProductRepository : IRepository<Album>
    {
        KpopZtationDBEntities context = Database.Connection;

        public void Update(Album updatedAlbum)
        {
            var albumToBeUpdated = context.Albums.Find(updatedAlbum.AlbumID);
            if (albumToBeUpdated != null)
            {
                albumToBeUpdated.AlbumDescription = updatedAlbum.AlbumDescription;
                albumToBeUpdated.AlbumName = updatedAlbum.AlbumName;
                albumToBeUpdated.AlbumPrice = updatedAlbum.AlbumPrice;
                albumToBeUpdated.AlbumStock = updatedAlbum.AlbumStock;
                albumToBeUpdated.ArtistID = updatedAlbum.ArtistID;
                albumToBeUpdated.AlbumImage = updatedAlbum.AlbumImage;
                context.SaveChanges();
            }
        }

        public int NextID()
        {
            if (context.Albums.Count() == 0)
                return 0;
            return context.Albums.Max(x => x.AlbumID) + 1;
        }

        public void Add(Album albumToAdd)
        {
            context.Albums.Add(albumToAdd);
            context.SaveChanges();
        }

        public IEnumerable<Album> Find(Expression<Func<Album, bool>> predicate)
        {
            return context.Albums.Where(predicate);
        }

        public void AddRange(List<Album> entities)
        {
            context.Albums.AddRange(entities);
            context.SaveChanges();
        }

        public void Remove(Album entity)
        {
            context.Albums.Remove(entity);
            context.SaveChanges();
        }

        public void RemoveRange(List<Album> entities)
        {
            context.Albums.RemoveRange(entities);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
