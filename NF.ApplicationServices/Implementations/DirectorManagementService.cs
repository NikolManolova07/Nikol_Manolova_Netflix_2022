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
    public class DirectorManagementService
    {
        public List<DirectorDto> Get()
        {
            List<DirectorDto> directorsDto = new List<DirectorDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.DirectorRepository.Get())
                {
                    directorsDto.Add(new DirectorDto
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        DirectorInfo = item.DirectorInfo
                    });
                }
            }

            return directorsDto;
        }

        public List<DirectorDto> GetDirectorsByName(string name)
        {
            List<DirectorDto> directorsDto = new List<DirectorDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var directors = from d in unitOfWork.DirectorRepository.Get()
                                select d;
                if (!String.IsNullOrEmpty(name))
                {
                    directors = directors.Where(d => d.FirstName.Contains(name) || d.LastName.Contains(name));
                }

                foreach (var item in directors)
                {
                    directorsDto.Add(new DirectorDto
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        DirectorInfo = item.DirectorInfo
                    });
                }
            }

            return directorsDto;
        }

        public DirectorDto GetById(int id)
        {
            DirectorDto directorDto = new DirectorDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Director director = unitOfWork.DirectorRepository.GetByID(id);

                directorDto = new DirectorDto
                {
                    Id = director.Id,
                    FirstName = director.FirstName,
                    LastName = director.LastName,
                    DirectorInfo = director.DirectorInfo
                };
            }

            return directorDto;
        }

        public bool Save(DirectorDto directorDto)
        {
            if (directorDto.Validate())
            {
                Director director = new Director
                {
                    FirstName = directorDto.FirstName,
                    LastName = directorDto.LastName,
                    DirectorInfo = directorDto.DirectorInfo
                };

                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        unitOfWork.DirectorRepository.Insert(director);
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

        public bool Update(DirectorDto directorDto)
        {
            if (directorDto.Validate())
            {
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        Director director = unitOfWork.DirectorRepository.GetByID(directorDto.Id);
                        if (director != null)
                        {
                            director.FirstName = directorDto.FirstName;
                            director.LastName = directorDto.LastName;
                            director.DirectorInfo = directorDto.DirectorInfo;
                            unitOfWork.DirectorRepository.Update(director);
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
                    Director director = unitOfWork.DirectorRepository.GetByID(id);
                    unitOfWork.DirectorRepository.Delete(director);
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
