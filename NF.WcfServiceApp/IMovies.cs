using NF.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NF.WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMovies" in both code and config file together.
    [ServiceContract]
    public interface IMovies
    {
        // Movie Operations.
        [OperationContract]
        List<MovieDto> GetMovies();

        [OperationContract]
        List<MovieDto> GetMoviesByReleaseCountry(string releaseCountry);

        [OperationContract]
        MovieDto GetMovieById(int id);

        [OperationContract]
        string PostMovie(MovieDto movieDto);

        [OperationContract]
        string PutMovie(MovieDto movieDto);

        [OperationContract]
        string DeleteMovie(int id);
    }
}
