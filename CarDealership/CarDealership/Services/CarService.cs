using CarDealership.Models;
using CoderCamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Services
{

    public class CarService : CarDealership.Services.ICarService
    {
        private IGenericRepository _repo;
        public CarService(IGenericRepository repo)        {
            _repo = repo;

	    }


        public IList<Car> ListCars()
        {
            return _repo.Query<Car>().ToList();
        }

        public Car FindCar(int id)
        {
            return _repo.Find<Car>(id);
        }

        public IList<Car> FindCars(string search)
        {
            return _repo.Query<Car>().Where((c) => c.Title.Contains(search)).ToList();
        }
    }
    
}