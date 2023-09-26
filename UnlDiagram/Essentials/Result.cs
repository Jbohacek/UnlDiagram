using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlDiagram.Essentials
{
    public class Result<T>
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public T Value { get; set; }
        public bool IsSuccessful { get; set; } = false;

        public Result()
        {

        }

        public Result(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public Result(T value)
        {
            IsSuccessful = true;
            Value = value;
        }
    }
}
