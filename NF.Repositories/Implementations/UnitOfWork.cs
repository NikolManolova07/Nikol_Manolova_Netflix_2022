using NF.Data.Context;
using NF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private NetflixDbContext context = new NetflixDbContext();
        private GenericRepository<Movie> movieRepository;
        private GenericRepository<Genre> genreRepository;
        private GenericRepository<Director> directorRepository;
        private GenericRepository<Producer> producerRepository;
        private GenericRepository<Rating> ratingRepository;

        public GenericRepository<Movie> MovieRepository
        {
            get
            {
                if (this.movieRepository == null)
                {
                    this.movieRepository = new GenericRepository<Movie>(context);
                }
                return movieRepository;
            }
        }

        public GenericRepository<Genre> GenreRepository
        {
            get
            {
                if (this.genreRepository == null)
                {
                    this.genreRepository = new GenericRepository<Genre>(context);
                }
                return genreRepository;
            }
        }

        public GenericRepository<Director> DirectorRepository
        {
            get
            {
                if (this.directorRepository == null)
                {
                    this.directorRepository = new GenericRepository<Director>(context);
                }
                return directorRepository;
            }
        }

        public GenericRepository<Producer> ProducerRepository
        {
            get
            {
                if (this.producerRepository == null)
                {
                    this.producerRepository = new GenericRepository<Producer>(context);
                }
                return producerRepository;
            }
        }

        public GenericRepository<Rating> RatingRepository
        {
            get
            {
                if (this.ratingRepository == null)
                {
                    this.ratingRepository = new GenericRepository<Rating>(context);
                }
                return ratingRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
