using NF.ApplicationServices.DTOs;
using NF.ApplicationServices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NF.WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producers" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Producers.svc or Producers.svc.cs at the Solution Explorer and start debugging.
    public class Producers : IProducers
    {
        private ProducerManagementService producerService = new ProducerManagementService();

        // Implementation of Producer Operations.
        public List<ProducerDto> GetProducers()
        {
            return producerService.Get();
        }

        public List<ProducerDto> GetProducersByName(string name)
        {
            return producerService.GetProducersByName(name);
        }

        public ProducerDto GetProducerById(int id)
        {
            return producerService.GetById(id);
        }

        public string PostProducer(ProducerDto producerDto)
        {
            if (!producerService.Save(producerDto))
                return "Producer is not inserted.";

            return "Producer is inserted.";
        }

        public string PutProducer(ProducerDto producerDto)
        {
            if (!producerService.Update(producerDto))
                return "Producer is not updated.";

            return "Producer is updated.";
        }

        public string DeleteProducer(int id)
        {
            if (!producerService.Delete(id))
                return "Producer is not deleted.";

            return "Producer is deleted.";
        }
    }
}
