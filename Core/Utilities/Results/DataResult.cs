using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> :Result, IDataResult<T>
    {
        public DataResult(T data, bool succ,string mess):base(succ,mess)
        {
          Data = data;
        }
        public DataResult(T data, bool succ):base(succ)
        {
            Data=data;
        }
        public T Data { get; }

    }
}
