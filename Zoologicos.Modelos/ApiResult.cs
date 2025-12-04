using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoologicos.Modelos
{
    public class ApiResult<T>
    {
        //errores claros para el usuario y el desarrollador
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ApiResult<T> Ok(T data)//200
        {
            return new ApiResult<T>
            {
                Success = true,
                Data = data
            };
        }

        public static ApiResult<T> Fail(string message)
        {
            return new ApiResult<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}
