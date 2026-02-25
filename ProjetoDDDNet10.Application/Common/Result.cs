using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; }
        public string? Error { get; }
        public int StatusCode { get; }

        private Result(bool isSuccess, T? value, string? error, int statusCode)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
            StatusCode = statusCode;
        }

        public static Result<T> Success(T value)
            => new(true, value, null, 200);

        public static Result<T> Failure(string error, int statusCode = 400)
            => new(false, default, error, statusCode);
        public static Result<T> Conflict(string message, int statusCode) => new Result<T>(false,default,message, 409);
    }
}
