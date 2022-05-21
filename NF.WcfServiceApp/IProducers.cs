using NF.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NF.WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProducers" in both code and config file together.
    [ServiceContract]
    public interface IProducers
    {
        // Producer Operations.
        [OperationContract]
        List<ProducerDto> GetProducers();

        [OperationContract]
        List<ProducerDto> GetProducersByName(string name);

        [OperationContract]
        ProducerDto GetProducerById(int id);

        [OperationContract]
        string PostProducer(ProducerDto producerDto);

        [OperationContract]
        string PutProducer(ProducerDto producerDto);

        [OperationContract]
        string DeleteProducer(int id);
    }
}
