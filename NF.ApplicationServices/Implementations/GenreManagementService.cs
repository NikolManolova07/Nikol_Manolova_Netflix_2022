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
    public class GenreManagementService
    {
        public List<GenreDto> Get()
        {
            List<GenreDto> genresDto = new List<GenreDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.GenreRepository.Get())
                {
                    genresDto.Add(new GenreDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        GenreInfo = item.GenreInfo
                    });
                }
            }

            return genresDto;
        }

        public List<GenreDto> GetGenresByName(string name)
        {
            List<GenreDto> genresDto = new List<GenreDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var genres = from g in unitOfWork.GenreRepository.Get()
                             select g;
                if (!String.IsNullOrEmpty(name))
                {
                    genres = genres.Where(g => g.Name.Contains(name));
                }

                foreach (var item in genres)
                {
                    genresDto.Add(new GenreDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        GenreInfo = item.GenreInfo
                    });
                }
            }

            return genresDto;
        }

        public GenreDto GetById(int id)
        {
            GenreDto genreDto = new GenreDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Genre genre = unitOfWork.GenreRepository.GetByID(id);

                genreDto = new GenreDto
                {
                    Id = genre.Id,
                    Name = genre.Name,
                    GenreInfo = genre.GenreInfo
                };
            }

            return genreDto;
        }

        public bool Save(GenreDto genreDto)
        {
            if (genreDto.Validate())
            {
                Genre genre = new Genre
                {
                    Name = genreDto.Name,
                    GenreInfo = genreDto.GenreInfo
                };

                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        unitOfWork.GenreRepository.Insert(genre);
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

        public bool Update(GenreDto genreDto)
        {
            if (genreDto.Validate())
            {
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        Genre genre = unitOfWork.GenreRepository.GetByID(genreDto.Id);
                        if (genre != null)
                        {
                            genre.Name = genreDto.Name;
                            genre.GenreInfo = genreDto.GenreInfo;
                            unitOfWork.GenreRepository.Update(genre);
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
            if (id == 0) return false;

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Genre genre = unitOfWork.GenreRepository.GetByID(id);
                    unitOfWork.GenreRepository.Delete(genre);
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
