using Azure.Core;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file,CarImage img);
        IResult Delete(CarImage img);
        IResult Update(IFormFile file,CarImage img);
        IDataResult<List<CarImage>> GetImages();
        IDataResult<CarImage> GetImage(int id);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
    }
}
