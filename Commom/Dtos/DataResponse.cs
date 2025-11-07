using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Commom.Dtos
{
    public class DataResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
        public bool Success;

        public static DataResponse<T> Ok(T data, string message = "Thành công") => new DataResponse<T> { Data = data, Message = message, Success = true };
        public static DataResponse<T> Failed(string message = "Lỗi") => new DataResponse<T> { Message = message, Success = false };
    }

    public class DataResponse : DataResponse<object>
    {
        public static DataResponse Ok(string message = "Thành công") => new DataResponse { Message = message, Success = true };
          public static DataResponse Failed(string message = "Lỗi") => new DataResponse { Message = message, Success = false };

      
    }
}
