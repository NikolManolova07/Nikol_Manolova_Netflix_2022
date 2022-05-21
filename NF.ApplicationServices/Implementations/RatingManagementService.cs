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
    public class RatingManagementService
    {
        public List<RatingDto> Get()
        {
            List<RatingDto> ratingsDto = new List<RatingDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.RatingRepository.Get())
                {
                    ratingsDto.Add(new RatingDto
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }

            return ratingsDto;
        }

        public List<RatingDto> GetRatingsByName(string name)
        {
            List<RatingDto> ratingsDto = new List<RatingDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var ratings = from r in unitOfWork.RatingRepository.Get()
                              select r;
                if (!String.IsNullOrEmpty(name))
                {
                    ratings = ratings.Where(r => r.Name.Contains(name));
                }

                foreach (var item in ratings)
                {
                    ratingsDto.Add(new RatingDto
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }

            return ratingsDto;
        }

        public RatingDto GetById(int id)
        {
            RatingDto ratingDto = new RatingDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Rating rating = unitOfWork.RatingRepository.GetByID(id);

                ratingDto = new RatingDto
                {
                    Id = rating.Id,
                    Name = rating.Name
                };
            }

            return ratingDto;
        }

        public bool Save(RatingDto ratingDto)
        {
            if (ratingDto.Validate())
            {
                Rating rating = new Rating
                {
                    Name = ratingDto.Name
                };

                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        unitOfWork.RatingRepository.Insert(rating);
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

        public bool Update(RatingDto ratingDto)
        {
            if (ratingDto.Validate())
            {
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        Rating rating = unitOfWork.RatingRepository.GetByID(ratingDto.Id);
                        if (rating != null)
                        {
                            rating.Name = ratingDto.Name;
                            unitOfWork.RatingRepository.Update(rating);
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
                    Rating rating = unitOfWork.RatingRepository.GetByID(id);
                    unitOfWork.RatingRepository.Delete(rating);
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
