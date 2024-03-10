using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string mess) : base(data, false, mess)
        {
        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string mess) : base(default, false, mess)
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
