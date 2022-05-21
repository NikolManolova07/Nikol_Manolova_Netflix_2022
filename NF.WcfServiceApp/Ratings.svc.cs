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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Ratings" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Ratings.svc or Ratings.svc.cs at the Solution Explorer and start debugging.
    public class Ratings : IRatings
    {
        private RatingManagementService ratingService = new RatingManagementService();

        // Implementation of Rating Operations.
        public List<RatingDto> GetRatings()
        {
            return ratingService.Get();
        }

        public List<RatingDto> GetRatingsByName(string name)
        {
            return ratingService.GetRatingsByName(name);
        }

        public RatingDto GetRatingById(int id)
        {
            return ratingService.GetById(id);
        }

        public string PostRating(RatingDto ratingDto)
        {
            if (!ratingService.Save(ratingDto))
                return "Rating is not inserted.";

            return "Rating is inserted.";
        }

        public string PutRating(RatingDto ratingDto)
        {
            if (!ratingService.Update(ratingDto))
                return "Rating is not updated.";

            return "Rating is updated.";
        }

        public string DeleteRating(int id)
        {
            if (!ratingService.Delete(id))
                return "Rating is not deleted.";

            return "Rating is deleted.";
        }
    }
}
