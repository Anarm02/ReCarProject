using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImagesDal _carImageDal;
        public CarImageManager(ICarImagesDal carImagesDal)
        {
            _carImageDal = carImagesDal;
        }

        public IResult Add(CarImage img)
        {
           _carImageDal.Add(img);
            return new SuccessResult();
        }

        public IResult Delete(CarImage img)
        {
           _carImageDal.Delete(img);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetImage(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=> c.ImageId ==id)) ;
        }

        public IDataResult<List<CarImage>> GetImages()
        {
            return new SuccessDataResult<List< CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(CarImage img)
        {
            _carImageDal.Update(img);
            return new SuccessResult();
        }
        
    }
}
