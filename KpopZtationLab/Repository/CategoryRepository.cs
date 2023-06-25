using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KpopZtationLab.Interface;
using KpopZtationLab.Models;
using KpopZtationLab.Pattern;

namespace KpopZtationLab.Repository
{
    public class CategoryRepository : IRepository<Artist>
    {
        KpopZtationDBEntities context = Database.Connection;

        public void Add(Artist artistToAdd)
        {
            context.Artists.Add(artistToAdd);
            context.SaveChanges();
        }

        public int NextID()
        {
            if (context.Artists.Count() == 0)
                return 0;
            return context.Artists.Max(x => x.ArtistID) + 1;
        }

        public void Update(Artist updatedArtist)
        {
            var artistToBeUpdated = context.Artists.Find(updatedArtist.ArtistID);
            if (artistToBeUpdated != null)
            {
                artistToBeUpdated.ArtistName = updatedArtist.ArtistName;
                artistToBeUpdated.ArtistImage = updatedArtist.ArtistImage;
                context.SaveChanges();
            }
        }

        public void Remove(Artist entity)
        {
            context.Artists.Remove(entity);
            context.SaveChanges();

        }

        public IEnumerable<Artist> Find(Expression<Func<Artist, bool>> predicate)
        {
            return context.Artists.Where(predicate);
        }

        public void RemoveRange(List<Artist> entities)
        {
            context.Artists.RemoveRange(entities);
            context.SaveChanges();
        }

        public void AddRange(List<Artist> entities)
        {
            context.Artists.AddRange(entities);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
