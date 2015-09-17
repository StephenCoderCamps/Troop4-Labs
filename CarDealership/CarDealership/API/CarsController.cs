using CarDealership.Models;
using CarDealership.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.API
{
    public class CarsController : ApiController
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        // GET: api/Cars
        public IEnumerable<Car> Get()
        {
            return _carService.ListCars();
        }

        // GET: api/Cars/5
        public Car Get(int id)
        {
            return _carService.FindCar(id);
        }

        // POST: api/Cars
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cars/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cars/5
        public void Delete(int id)
        {
        }

        [Route("api/cars/ByTitle/{search}")]
        public IList<Car> Get(string search)
        {
            return _carService.FindCars(search);
        }
    }
}
