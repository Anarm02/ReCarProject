using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
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
        IFileHelper _fileHelper;
        public CarImageManager(ICarImagesDal carImagesDal,IFileHelper fileHelper)
        {
            _carImageDal = carImagesDal;
            _fileHelper = fileHelper;   
        }

        public IResult Add(IFormFile file, CarImage img)
        {
            IResult result = BusinessRules.Run(CheckCarImagesCount(img.CarId));
            if (result != null)
            {
                return result;
            }
            img.ImagePath = _fileHelper.Upload(file, PathConstants.imagePath);
            img.ImageDate = DateTime.Now;
            _carImageDal.Add(img);
            return new SuccessResult("Resim başarıyla yüklendi");
        }

        public IResult Delete(CarImage img)
        {
            _fileHelper.Delete(PathConstants.imagePath + img.ImagePath);
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

        public IResult Update(IFormFile file, CarImage img)
        {
         
         img.ImagePath=_fileHelper.Update(PathConstants.imagePath + img.ImagePath, file, PathConstants.imagePath);   
            _carImageDal.Update(img);
            return new SuccessResult();
        }
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId)); 
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();    
            carImages.Add(new CarImage { CarId = carId,ImageDate=DateTime.Now,ImagePath="default_img.png" });   
            return new SuccessDataResult<List<CarImage>>(carImages);   

        }
        private IResult CheckCarImagesCount(int id)
        {
            var result= _carImageDal.GetAll(c=>c.CarId==id);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.CarImagesCount);
            }
            return new SuccessResult();
        }
    }
}
