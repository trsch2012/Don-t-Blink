using System.IO;
using System.Web;
using System.Web.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DontBlink.API.Code;
using DontBlink.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DontBlink.API.Controllers
{
    public class SightingController : ApiController
    {
        // GET: api/Sighting
        public IEnumerable<SightingModel> Get()
        {
            return SightingHelper.GenerateSightingHelperList();
        }

        // GET: api/Sighting/5
        public SightingModel Get(int id)
        {
            try
            {
                return SightingHelper.GenerateSightingHelperList().First(x => x.Id == id);
            }
            catch(Exception){

            }

            return null;
        }

        // POST: api/Sighting
        public SightingModel Post([FromBody]SightingModel value)
        {
            try
            {
                value.Id = SessionStateSink.Sightings.Count;
               // SessionStateSink.Sightings.Add(value);
                if (value.Base64ImageString != null)
                {
                    byte[] data = Convert.FromBase64String(value.Base64ImageString);
                    Cloudinary cloudinary = new Cloudinary("cloudinary://334511462279285:uPmtzU2peDdn0sEXV0Z05C5QiO8@schluect-com");
                    cloudinary.Upload(new ImageUploadParams
                    {
                        File = new FileDescription("Test", new MemoryStream(data))
                    });

                    return new SightingModel();
                }
            }
            catch (Exception)
            {
            }
                return null;
        }

        // PUT: api/Sighting/5
        public void Put(int id, [FromBody]SightingModel value)
        {
            try
            {
                SightingModel oldSighting = SessionStateSink.Sightings.First(x => x.Id == id);
                oldSighting.Title = value.Title;
                oldSighting.Description = value.Description;
                oldSighting.Longitude = value.Longitude;
                oldSighting.Latitude = value.Latitude;
                oldSighting.ImageUrl = value.ImageUrl;
            }
            catch (Exception)
            {

            }

        }

        // DELETE: api/Sighting/5
        public void Delete(int id)
        {
            try
            {
                SessionStateSink.Sightings.Remove(SessionStateSink.Sightings.First(x => x.Id == id));
            }
            catch (Exception)
            {

            }
        }
    }
}
