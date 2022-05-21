using NF.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NF.WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDirectors" in both code and config file together.
    [ServiceContract]
    public interface IDirectors
    {
        // Director Operations.
        [OperationContract]
        List<DirectorDto> GetDirectors();

        [OperationContract]
        List<DirectorDto> GetDirectorsByName(string name);

        [OperationContract]
        DirectorDto GetDirectorById(int id);

        [OperationContract]
        string PostDirector(DirectorDto directorDto);

        [OperationContract]
        string PutDirector(DirectorDto directorDto);

        [OperationContract]
        string DeleteDirector(int id);
    }
}
