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
    public class ProducerManagementService
    {
        public List<ProducerDto> Get()
        {
            List<ProducerDto> producersDto = new List<ProducerDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.ProducerRepository.Get())
                {
                    producersDto.Add(new ProducerDto
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        ProducerInfo = item.ProducerInfo
                    });
                }
            }

            return producersDto;
        }

        public List<ProducerDto> GetProducersByName(string name)
        {
            List<ProducerDto> producersDto = new List<ProducerDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var producers = from p in unitOfWork.ProducerRepository.Get()
                                select p;
                if (!String.IsNullOrEmpty(name))
                {
                    producers = producers.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name));
                }

                foreach (var item in producers)
                {
                    producersDto.Add(new ProducerDto
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        ProducerInfo = item.ProducerInfo
                    });
                }
            }

            return producersDto;
        }

        public ProducerDto GetById(int id)
        {
            ProducerDto producerDto = new ProducerDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Producer producer = unitOfWork.ProducerRepository.GetByID(id);

                producerDto = new ProducerDto
                {
                    Id = producer.Id,
                    FirstName = producer.FirstName,
                    LastName = producer.LastName,
                    ProducerInfo = producer.ProducerInfo
                };
            }

            return producerDto;
        }

        public bool Save(ProducerDto producerDto)
        {
            if (producerDto.Validate())
            {
                Producer producer = new Producer
                {
                    FirstName = producerDto.FirstName,
                    LastName = producerDto.LastName,
                    ProducerInfo = producerDto.ProducerInfo
                };

                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        unitOfWork.ProducerRepository.Insert(producer);
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

        public bool Update(ProducerDto producerDto)
        {
            if (producerDto.Validate())
            {
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork())
                    {
                        Producer producer = unitOfWork.ProducerRepository.GetByID(producerDto.Id);
                        if (producer != null)
                        {
                            producer.FirstName = producerDto.FirstName;
                            producer.LastName = producerDto.LastName;
                            producer.ProducerInfo = producerDto.ProducerInfo;
                            unitOfWork.ProducerRepository.Update(producer);
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
                    Producer producer = unitOfWork.ProducerRepository.GetByID(id);
                    unitOfWork.ProducerRepository.Delete(producer);
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
