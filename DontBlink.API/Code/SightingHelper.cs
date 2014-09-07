using DontBlink.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DontBlink.API.Code
{
    public static class SightingHelper
    {
        private static Random rand = new Random();
        public static SightingModel GenerateSightingHelper(Guid id)
        {
            double[] coords = GetRandomGeoCoords();
            string title = Ipsum.GetPhrase(3);
            return new SightingModel
            {
                Id = id,
                UserId = Guid.NewGuid(),
                Title = title,
                Description = Ipsum.GetPhrase(100),
                Latitude = coords[0],
                Longitude = coords[1],
                ImageUrl = GetImageUrl(title)
            };
        }

        public static List<SightingModel> GenerateSightingHelperList()
        {
            if (SessionStateSink.Sightings == null)
            {
                var listing = new List<SightingModel>
                {
                    GenerateSightingHelper(Guid.NewGuid()),
                    GenerateSightingHelper(Guid.NewGuid()),
                    GenerateSightingHelper(Guid.NewGuid()),
                    GenerateSightingHelper(Guid.NewGuid()),
                    GenerateSightingHelper(Guid.NewGuid()),
                    GenerateSightingHelper(Guid.NewGuid()),
                    GenerateSightingHelper(Guid.NewGuid()),
                    GenerateSightingHelper(Guid.NewGuid()),
                    GenerateSightingHelper(Guid.NewGuid()),
                    GenerateSightingHelper(Guid.NewGuid())
                };

                SessionStateSink.Sightings = listing;            
            }

            return SessionStateSink.Sightings;
        }

        private static double[] GetRandomGeoCoords()
        {
            List<double[]> coords = new List<double[]>
            {
                new double[] { -87.04211661, 158.82617792 },
                new double[] { -77.36341956, 65.99830583 },
                new double[] { -80.70552712, 170.61098981 },
                new double[] { -80.79454164, 67.92336686 },
                new double[] { -79.7787381, -102.63497749 },
                new double[] { -81.27512944, 12.45223512 },
                new double[] { -86.71676792, 132.24890074 },
                new double[] { -83.41349091, -123.50539645 },
                new double[] { -82.3634878, 124.79586883 },
                new double[] { -78.33002187, -176.76338047 }
            };


            return coords[rand.Next(coords.Count - 1)];
        }

        private static string GetImageUrl(string text)
        {
            return "http://placehold.it/2048x1536&text=" + text;
        }
    }
}

