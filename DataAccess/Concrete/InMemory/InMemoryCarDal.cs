using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {  
        List<Car> cars;
        public InMemoryCarDal()
        {
            cars = new List<Car> {
            new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=100,Description="Audi a4",ModelYear=2012},
            new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=124,Description="Audi a8",ModelYear=2009},
            new Car{CarId=3,BrandId=2,ColorId=2,DailyPrice=150,Description="Mercedes c180",ModelYear=2008},
            new Car{CarId=4,BrandId=2,ColorId=4,DailyPrice=200,Description="Mercedes cla220",ModelYear=2011},
            new Car{CarId=5,BrandId=3,ColorId=3,DailyPrice=180,Description="BMW 525",ModelYear=2012},
            };
        }
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = cars.SingleOrDefault(car=>car.CarId==car.CarId);
            cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            List<Car> sortedCars= cars.Where(car=>car.BrandId==id).ToList();  
            return sortedCars;
        }

        public List<CarDetailsDto> GetDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = cars.SingleOrDefault(car=>car.CarId==car.CarId);
            carToUpdate.DailyPrice=car.DailyPrice;
            carToUpdate.Description=car.Description;
            carToUpdate.BrandId=car.BrandId;
            carToUpdate.ColorId=car.ColorId;
            carToUpdate.ModelYear=car.ModelYear;
        }

        public void Update(int id,Car car)
        {
            throw new NotImplementedException();
        }
    }
}
