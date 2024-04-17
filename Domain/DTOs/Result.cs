using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public string Error { get; private set; }

        public string Message { get; private set; }
        public bool IsSuccess => Error == null;

        private Result(T data)
        {
            Data = data;
        }

        private Result(string error)
        {
            Error = error;
        }
        private Result(T data, string message)
        {
            Data = data;
            Message = message;
        }
        public static Result<T> Success(T data) => new Result<T>(data);

         public static Result<T> Success(T data, string message) => new Result<T>(data, message);

        public static Result<T> Success(string data) => new Result<T>(data);

        public static Result<T> Failure(string error) => new Result<T>(error);
    }

}
