using NF.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NF.WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGenres" in both code and config file together.
    [ServiceContract]
    public interface IGenres
    {
        // Genre Operations.
        [OperationContract]
        List<GenreDto> GetGenres();

        [OperationContract]
        List<GenreDto> GetGenresByName(string name);

        [OperationContract]
        GenreDto GetGenreById(int id);

        [OperationContract]
        string PostGenre(GenreDto genreDto);

        [OperationContract]
        string PutGenre(GenreDto genreDto);

        [OperationContract]
        string DeleteGenre(int id);
    }
}
