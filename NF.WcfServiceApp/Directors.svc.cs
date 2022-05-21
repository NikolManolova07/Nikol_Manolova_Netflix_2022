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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Directors" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Directors.svc or Directors.svc.cs at the Solution Explorer and start debugging.
    public class Directors : IDirectors
    {
        private DirectorManagementService directorService = new DirectorManagementService();

        // Implementation of Director Operations.
        public List<DirectorDto> GetDirectors()
        {
            return directorService.Get();
        }

        public List<DirectorDto> GetDirectorsByName(string name)
        {
            return directorService.GetDirectorsByName(name);
        }

        public DirectorDto GetDirectorById(int id)
        {
            return directorService.GetById(id);
        }

        public string PostDirector(DirectorDto directorDto)
        {
            if (!directorService.Save(directorDto))
                return "Director is not inserted.";

            return "Director is inserted.";
        }

        public string PutDirector(DirectorDto directorDto)
        {
            if (!directorService.Update(directorDto))
                return "Director is not updated.";

            return "Director is updated.";
        }

        public string DeleteDirector(int id)
        {
            if (!directorService.Delete(id))
                return "Director is not deleted.";

            return "Director is deleted.";
        }
    }
}
