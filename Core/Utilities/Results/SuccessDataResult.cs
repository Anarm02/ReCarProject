using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data,  string mess) : base(data, true, mess)
        {
        }
        public SuccessDataResult(T data):base(data, true) 
        {
            
        }
        public SuccessDataResult(string mess):base(default,true,mess)
        {
            
        }
        public SuccessDataResult():base(default,true) 
        {
            
        }
    }
}
