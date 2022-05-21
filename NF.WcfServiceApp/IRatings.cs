using NF.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NF.WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRatings" in both code and config file together.
    [ServiceContract]
    public interface IRatings
    {
        // Rating Operations.
        [OperationContract]
        List<RatingDto> GetRatings();

        [OperationContract]
        List<RatingDto> GetRatingsByName(string name);

        [OperationContract]
        RatingDto GetRatingById(int id);

        [OperationContract]
        string PostRating(RatingDto ratingDto);

        [OperationContract]
        string PutRating(RatingDto ratingDto);

        [OperationContract]
        string DeleteRating(int id);
    }
}
