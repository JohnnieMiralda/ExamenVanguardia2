using Hotel.Rates.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Services
{
    public class ServiceResult<T>
    {
        public ServiceResult(ResponseCode responseCode, string error, T result)
        {
            ResponseCode = responseCode;
            Error = error;
            Result = result;
        }
        public ResponseCode ResponseCode { get; set; }

        public string Error { get; set; }

        public T Result { get; set; }

        public static ServiceResult<T> ErrorResult(string error)
        {
            return new ServiceResult<T>(ResponseCode.Error, error, default(T));
        }

        public static ServiceResult<T> BadRequestResult(string error)
        {
            return new ServiceResult<T>(ResponseCode.BadRequest, error, default(T));
        }

        public static ServiceResult<T> SuccessResult(T entity)
        {
            return new ServiceResult<T>(ResponseCode.Success, string.Empty, entity);
        }

        public static ServiceResult<T> OkResult(T entity)
        {
            return new ServiceResult<T>(ResponseCode.Ok, string.Empty, entity);
        }

        public static ServiceResult<T> NotFoundResult(string error)
        {
            return new ServiceResult<T>(ResponseCode.NotFound, error, default(T));
        }
    }
}
