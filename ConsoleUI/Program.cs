using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService carManager = new CarManager(new EfCarDal()) { };
            
            foreach(var car in carManager.GetCarDetails().Data) {
                Console.WriteLine(car.BrandName+"-------- "+car.CarName+"----- "+car.ColorName);
            }
            

        }

        


        private static void GetByBrandTest(ICarService carManager)
        {
            foreach (Car car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void GetAllTest(ICarService carManager)
        {
            foreach (Car car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
