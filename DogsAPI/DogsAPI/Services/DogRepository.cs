using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DogsAPI.Models;
using System.IO;
using Newtonsoft.Json;

namespace DogsAPI.Services
{
    public class DogRepository
    {
        private const string CacheKey = "DogStore";
        private int nextDogID = 8;
        private string GetJsonFileName()
        {
            return Path.Combine(HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data"), "dogs.json");
        }
        public DogRepository()
        {
            var ctx = HttpContext.Current;

                if (ctx != null)
                {
                    if (ctx.Cache[CacheKey] == null)
                    {
                        Dog[] dogs;
                        var fileName = GetJsonFileName();
                    
                        using (StreamReader r = new StreamReader(fileName))
                        {
                            string json = r.ReadToEnd();
                            dogs = JsonConvert.DeserializeObject<List<Dog>>(json).ToArray();
                        }

                    nextDogID = dogs.Length + 1;
                    ctx.Cache[CacheKey] = dogs;
                    }
                }
        }
        public Dog[] GetAllDogs()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Dog[])ctx.Cache[CacheKey];
            }
            return new Dog[]
            {
                    new Dog
                    {
                        Id = 1,
                        Name = "Peanut",
                        Owner = "Mila",
                        Notes = "Very Friendly"
                    },
                new Dog
                {
                    Id = 7,
                    Name = "Julbars",
                    Owner = "Mazover",
                    Notes = "WWII hero"
                }
            };
        }
        private void SaveFile()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                string output = JsonConvert.SerializeObject(ctx.Cache[CacheKey], Formatting.Indented);
                File.WriteAllText(GetJsonFileName(), output);
            }
        }
        public bool SaveDog(Dog dog)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Dog[])ctx.Cache[CacheKey]).ToList();
                    dog.Id = nextDogID++;
                    currentData.Add(dog);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    SaveFile();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
        public bool UpdateDog(int id, Dog updatedDog)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Dog[])ctx.Cache[CacheKey]).ToList();
                    var dog = ((Dog[])ctx.Cache[CacheKey]).SingleOrDefault(c => c.Id == id);
                    if (dog == null || updatedDog == null)
                        return false;
                    dog.Id = updatedDog.Id;
                    dog.Name = updatedDog.Name;
                    dog.Owner = updatedDog.Owner;
                    dog.Notes = updatedDog.Notes;
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    SaveFile();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
        public bool Remove(Dog dog)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Dog[])ctx.Cache[CacheKey]).ToList();
                    currentData.Remove(dog);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    SaveFile();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
        public Dog Get(int id)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return ((Dog[])ctx.Cache[CacheKey]).SingleOrDefault(c => c.Id == id); ;
            }
            return null;
        }
    }
}