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
            UserManager userManager=new UserManager(new EfUserDal());

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach(var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName);
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
