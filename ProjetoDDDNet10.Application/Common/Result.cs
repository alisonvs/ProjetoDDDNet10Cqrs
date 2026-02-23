using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Application.Common
{
    public class Result<T>
    {
        public bool Success { get; }
        public T? Data { get; }
        public string? Error { get; }

        protected Result(bool success, T? data, string? error)
        {
            Success = success;
            Data = data;
            Error = error;
        }

        public static Result<T> Ok(T data) => new(true, data, null);
        public static Result<T> Fail(string error) => new(false, default, error);
    }
}
