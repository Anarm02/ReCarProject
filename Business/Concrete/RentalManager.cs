using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
           var rentedCar=_rentalDal.Get(car=>car.RentalId==rental.RentalId);
            if(rentedCar==null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }
            else
            {
                if (rentedCar.CarId == rental.CarId && rentedCar.RentDate == null)
                {
                    return new ErrorResult();
                }
                else
                {
                    _rentalDal.Add(rental);
                    return new SuccessResult();
                }
            }
        }

        public IResult CarDelivery(int id)
        {
            var deliveredCar=_rentalDal.Get(car=> car.RentalId==id);   
            if(deliveredCar!=null)
            {
                _rentalDal.CarDeliver(id);
                return new SuccessResult();
            }
            return new ErrorResult();

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(car=>car.RentalId==id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
