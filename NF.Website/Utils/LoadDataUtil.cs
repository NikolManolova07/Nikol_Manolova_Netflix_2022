using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NF.Website.Utils
{
    public class LoadDataUtil
    {
        public static SelectList LoadDirectorData()
        {
            using (DirectorsReference.DirectorsClient service = new DirectorsReference.DirectorsClient())
            {
                return new SelectList(service.GetDirectors(), "Id", "LastName");
            }
        }

        public static SelectList LoadProducerData()
        {
            using (ProducersReference.ProducersClient service = new ProducersReference.ProducersClient())
            {
                return new SelectList(service.GetProducers(), "Id", "LastName");
            }
        }

        public static SelectList LoadGenreData()
        {
            using (GenresReference.GenresClient service = new GenresReference.GenresClient())
            {
                return new SelectList(service.GetGenres(), "Id", "Name");
            }
        }

        public static SelectList LoadRatingData()
        {
            using (RatingsReference.RatingsClient service = new RatingsReference.RatingsClient())
            {
                return new SelectList(service.GetRatings(), "Id", "Name");
            }
        }
    }
}