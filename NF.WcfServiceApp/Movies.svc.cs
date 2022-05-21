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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Movies" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Movies.svc or Movies.svc.cs at the Solution Explorer and start debugging.
    public class Movies : IMovies
    {
        private MovieManagementService movieService = new MovieManagementService();

        // Implementation of Movie Operations.
        public List<MovieDto> GetMovies()
        {
            return movieService.Get();
        }

        public List<MovieDto> GetMoviesByReleaseCountry(string releaseCountry)
        {
            return movieService.GetMoviesByReleaseCountry(releaseCountry);
        }

        public MovieDto GetMovieById(int id)
        {
            return movieService.GetById(id);
        }

        public string PostMovie(MovieDto movieDto)
        {
            if (!movieService.Save(movieDto))
                return "Movie is not inserted.";

            return "Movie is inserted.";
        }

        public string PutMovie(MovieDto movieDto)
        {
            if (!movieService.Update(movieDto))
                return "Movie is not updated.";

            return "Movie is updated.";
        }

        public string DeleteMovie(int id)
        {
            if (!movieService.Delete(id))
                return "Movie is not deleted.";

            return "Movie is deleted.";
        }
    }
}
