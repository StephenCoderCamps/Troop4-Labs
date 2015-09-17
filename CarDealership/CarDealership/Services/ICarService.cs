using System;
namespace CarDealership.Services
{
    public interface ICarService
    {
        CarDealership.Models.Car FindCar(int id);
        System.Collections.Generic.IList<CarDealership.Models.Car> FindCars(string search);
        System.Collections.Generic.IList<CarDealership.Models.Car> ListCars();
    }
}
