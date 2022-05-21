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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Genres" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Genres.svc or Genres.svc.cs at the Solution Explorer and start debugging.
    public class Genres : IGenres
    {
        private GenreManagementService genreService = new GenreManagementService();

        // Implementation of Genre Operations.
        public List<GenreDto> GetGenres()
        {
            return genreService.Get();
        }

        public List<GenreDto> GetGenresByName(string name)
        {
            return genreService.GetGenresByName(name);
        }

        public GenreDto GetGenreById(int id)
        {
            return genreService.GetById(id);
        }

        public string PostGenre(GenreDto genreDto)
        {
            if (!genreService.Save(genreDto))
                return "Genre is not inserted.";

            return "Genre is inserted.";
        }

        public string PutGenre(GenreDto genreDto)
        {
            if (!genreService.Update(genreDto))
                return "Genre is not updated.";

            return "Genre is updated.";
        }

        public string DeleteGenre(int id)
        {
            if (!genreService.Delete(id))
                return "Genre is not deleted.";

            return "Genre is deleted.";
        }
    }
}
