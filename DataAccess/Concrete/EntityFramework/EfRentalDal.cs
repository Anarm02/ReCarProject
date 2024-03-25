using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RcdbContext>, IRentalDal
    {
        public void CarDeliver(int id)
        {
            using (RcdbContext context = new RcdbContext())
            {
                var deliveredcar = context.Rentals.FirstOrDefault(car => car.RentalId == id);
                deliveredcar.RentDate = DateTime.Now;
                context.SaveChanges();

            }
        }
    }
}
