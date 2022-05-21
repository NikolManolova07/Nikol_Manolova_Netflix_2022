using NF.ApplicationServices.DTOs;
using NF.Data.Entities;
using NF.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.ApplicationServices.Implementations
{
    public class MovieManagementService
    {
        public List<MovieDto> Get()
        {
            List<MovieDto> moviesDto = new List<MovieDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.MovieRepository.Get())
                {
                    moviesDto.Add(new MovieDto
                    {
                        Id = item.Id,
                        Title = item.Title,
                        ReleaseDate = item.ReleaseDate,
                        ReleaseCountry = item.ReleaseCountry,
                        Director = new DirectorDto
                        {
                            Id = item.DirectorId,
                            FirstName = item.Director.FirstName,
                            LastName = item.Director.LastName,
                            DirectorInfo = item.Director.DirectorInfo
                        },
                        Producer = new ProducerDto
                        {
                            Id = item.ProducerId,
                            FirstName = item.Producer.FirstName,
                            LastName = item.Producer.LastName,
                            ProducerInfo = item.Producer.ProducerInfo
                        },
                        Genre = new GenreDto
                        {
                            Id = item.GenreId,
                            Name = item.Genre.Name,
                            GenreInfo = item.Genre.GenreInfo
                        },
                        MovieInfo = item.MovieInfo,
                        Rating = new RatingDto
                        {
                            Id = item.RatingId,
                            Name = item.Rating.Name
                        }
                    });
                }
            }

            return moviesDto;
        }

        public List<MovieDto> GetMoviesByReleaseCountry(string releaseCountry)
        {
            List<MovieDto> moviesDto = new List<MovieDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var movies = from m in unitOfWork.MovieRepository.Get()
                             select m;
                if (!String.IsNullOrEmpty(releaseCountry))
                {
                    movies = movies.Where(m => m.ReleaseCountry.Contains(releaseCountry));
                }

                foreach (var item in movies)
                {
                    moviesDto.Add(new MovieDto
                    {
                        Id = item.Id,
                        Title = item.Title,
                        ReleaseDate = item.ReleaseDate,
                        ReleaseCountry = item.ReleaseCountry,
                        Director = new DirectorDto
                        {
                            Id = item.DirectorId,
                            FirstName = item.Director.FirstName,
                            LastName = item.Director.LastName,
                            DirectorInfo = item.Director.DirectorInfo
                        },
                        Producer = new ProducerDto
                        {
                            Id = item.ProducerId,
                            FirstName = item.Producer.FirstName,
                            LastName = item.Producer.LastName,
                            ProducerInfo = item.Producer.ProducerInfo
                        },
                        Genre = new GenreDto
                        {
                            Id = item.GenreId,
                            Name = item.Genre.Name,
                            GenreInfo = item.Genre.GenreInfo
                        },
                        MovieInfo = item.MovieInfo,
                        Rating = new RatingDto
                        {
                            Id = item.RatingId,
                            Name = item.Rating.Name
                        }
                    });
                }
            }

            return moviesDto;
        }

        public MovieDto GetById(int id)
        {
            MovieDto movieDto = new MovieDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Movie movie = unitOfWork.MovieRepository.GetByID(id);
                movieDto = new MovieDto
                {
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    ReleaseCountry = movie.ReleaseCountry,
                    Director = new DirectorDto
                    {
                        Id = movie.DirectorId,
                        FirstName = movie.Director.FirstName,
                        LastName = movie.Director.LastName,
                        DirectorInfo = movie.Director.DirectorInfo
                    },
                    Producer = new ProducerDto
                    {
                        Id = movie.ProducerId,
                        FirstName = movie.Producer.FirstName,
                        LastName = movie.Producer.LastName,
                        ProducerInfo = movie.Producer.ProducerInfo
                    },
                    Genre = new GenreDto
                    {
                        Id = movie.GenreId,
                        Name = movie.Genre.Name,
                        GenreInfo = movie.Genre.GenreInfo
                    },
                    MovieInfo = movie.MovieInfo,
                    Rating = new RatingDto
                    {
                        Id = movie.RatingId,
                        Name = movie.Rating.Name
                    }
                };
            }

            return movieDto;
        }

        public bool Save(MovieDto movieDto)
        {
            if (movieDto.Validate())
            {
                Movie movie = new Movie
                {
                    Id = movieDto.Id,
                    Title = movieDto.Title,
                    ReleaseDate = movieDto.ReleaseDate,
                    ReleaseCountry = movieDto.ReleaseCountry,
                    DirectorId = movieDto.Director.Id,
                    ProducerId = movieDto.Producer.Id,
                    GenreId = movieDto.Genre.Id,
                    MovieInfo = movieDto.MovieInfo,
                    RatingId = movieDto.Rating.Id
                };

                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        unitOfWork.MovieRepository.Insert(movie);
                        unitOfWork.Save();
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Update(MovieDto movieDto)
        {
            if (movieDto.Validate())
            {
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        Movie movie = unitOfWork.MovieRepository.GetByID(movieDto.Id);
                        if (movie != null)
                        {
                            movie.Title = movieDto.Title;
                            movie.ReleaseDate = movieDto.ReleaseDate;
                            movie.ReleaseCountry = movieDto.ReleaseCountry;
                            movie.DirectorId = movieDto.Director.Id;
                            movie.ProducerId = movieDto.Producer.Id;
                            movie.GenreId = movieDto.Genre.Id;
                            movie.MovieInfo = movieDto.MovieInfo;
                            movie.RatingId = movieDto.Rating.Id;
                            unitOfWork.MovieRepository.Update(movie);
                            unitOfWork.Save();
                        }
                        else
                        {
                            return false;
                        }
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Movie movie = unitOfWork.MovieRepository.GetByID(id);
                    unitOfWork.MovieRepository.Delete(movie);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
