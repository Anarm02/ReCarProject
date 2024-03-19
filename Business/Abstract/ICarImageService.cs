using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage img);
        IResult Delete(CarImage img);
        IResult Update(CarImage img);
        IDataResult<List<CarImage>> GetImages();
        IDataResult<CarImage> GetImage(int id);
    }
}
