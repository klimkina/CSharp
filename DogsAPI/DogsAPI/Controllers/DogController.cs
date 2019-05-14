using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DogsAPI.Models;
using DogsAPI.Services;

namespace DogsAPI.Controllers
{
    public class DogController : ApiController
    {
        
        private DogRepository dogRepository;
        public DogController()
        {
            this.dogRepository = new DogRepository();
        }
        // GET: api/Dog
        public Dog[] Get()
        {
            return dogRepository.GetAllDogs();
        }

        // GET: api/Dog/5
        public Dog Get(int id)
        {
            return dogRepository.Get(id);
        }

        // POST: api/Dog
        public HttpResponseMessage Post(Dog dog)
        {
            this.dogRepository.SaveDog(dog);

            var response = Request.CreateResponse<Dog>(System.Net.HttpStatusCode.Created, dog);

            return response;
        }

        // PUT: api/Dog/5
        public HttpResponseMessage Put(int id, Dog updatedDog)
        {
            HttpResponseMessage response;
            if(this.dogRepository.UpdateDog(id, updatedDog))
                response = Request.CreateResponse<Dog>(System.Net.HttpStatusCode.Accepted, updatedDog);
            else
                response = Request.CreateResponse<Dog>(System.Net.HttpStatusCode.NotModified, updatedDog);
            return response;
        }

        // DELETE: api/Delete/5
        public Dog Delete(int id)
        {
            var dog = this.Get(id);
            this.dogRepository.Remove(dog);
            return dog;
        }
    }
}
