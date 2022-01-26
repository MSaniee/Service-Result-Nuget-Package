﻿namespace ServiceResult
{
    #region enum ResultStatus
    public enum ResultStatus
    {
        Success = 0,

        BadRequest = 2,

        NotFound = 3,

        ListEmpty = 4,

        LogicError = 5,
    }

    #endregion

    #region SResult
    public class SResult
    {
        public bool IsSuccess { get; set; }
        public ResultStatus StatusCode { get; set; }
        public string Message { get; set; }

        public SResult()
        {

        }

        public SResult(bool isSuccess, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = isSuccess ? ResultStatus.Success : ResultStatus.BadRequest;
            Message = message ?? StatusCode.ToString();
        }

        public SResult(bool isSuccess, ResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToString();
        }

        public static implicit operator SResult(string message)
        {
            return Success(message);
        }

        public static SResult Success()
        {
            return new(true, ResultStatus.Success);
        }

        public static SResult Success(string message)
        {
            return new(true, ResultStatus.Success, message);
        }

        public static SResult<TData> Success<TData>(TData data)
        {
            return new(true, ResultStatus.Success, data);
        }

        public static SResult<TData> Success<TData>(TData data, string message)
        {
            return new(true, ResultStatus.Success, data, message);
        }

        public static SResult Failure()
        {
            return new(false, ResultStatus.BadRequest);
        }

        public static SResult Failure(string message)
        {
            return new(false, ResultStatus.BadRequest, message);
        }

        public static SResult Failure(ResultStatus resultStatus)
        {
            if (resultStatus == ResultStatus.Success)
                resultStatus = ResultStatus.BadRequest;

            return new(false, resultStatus);
        }

        public static SResult Failure(ResultStatus resultStatus, string message)
        {
            if (resultStatus == ResultStatus.Success)
                resultStatus = ResultStatus.BadRequest;

            return new(false, resultStatus, message);
        }

    }
    #endregion

    #region SResult Generic
    public class SResult<TData>
    {
        public bool IsSuccess { get; set; }
        public ResultStatus StatusCode { get; set; }
        public TData Data { get; set; }
        public string Message { get; set; }

        public SResult()
        {

        }

        public SResult(bool isSuccess, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = isSuccess ? ResultStatus.Success : ResultStatus.BadRequest;
            Message = message ?? StatusCode.ToString();
        }

        public SResult(bool isSuccess, ResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToString();
        }

        public SResult(bool isSuccess, TData data, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = isSuccess ? ResultStatus.Success : ResultStatus.BadRequest;
            Message = message ?? StatusCode.ToString();
            Data = data;
        }

        public SResult(TData data, string message = null)
        {
            IsSuccess = true;
            StatusCode = ResultStatus.Success;
            Message = message ?? StatusCode.ToString();
            Data = data;
        }

        public SResult(bool isSuccess, ResultStatus statusCode, TData data, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToString();
            Data = data;
        }

        #region Implicit Operators

        public static implicit operator SResult<TData>(TData data)
        {
            return new(true, ResultStatus.Success, data);
        }

        public static implicit operator SResult<TData>(SResult serviceResult)
        {
            return new(serviceResult.IsSuccess, serviceResult.StatusCode, serviceResult.Message);
        }

        #endregion

        #region  Operators

        public static SResult<TData> Success(TData data)
        {
            return new(true, ResultStatus.Success, data);
        }

        public static SResult<TData> Failure()
        {
            return new(false, ResultStatus.BadRequest);
        }

        public static SResult<TData> Failure(ResultStatus resultStatus)
        {
            if (resultStatus == ResultStatus.Success)
                resultStatus = ResultStatus.BadRequest;

            return new(false, resultStatus);
        }

        public static SResult<TData> Failure(ResultStatus resultStatus, string message)
        {
            if (resultStatus == ResultStatus.Success)
                resultStatus = ResultStatus.BadRequest;

            return new(false, resultStatus, message);
        }
        #endregion
    }
    #endregion
}
