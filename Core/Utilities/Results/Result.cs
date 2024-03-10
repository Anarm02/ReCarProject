using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool succ ,string mess):this(succ)
        {
            message=mess;
        }
        public Result(bool succ)
        {
            success = succ;
        }
        public bool success { get; }

        public string message {  get; }
    }
}
