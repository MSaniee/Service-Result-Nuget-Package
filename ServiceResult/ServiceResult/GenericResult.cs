using ServiceResult.Utilities;

namespace ServiceResult
{
    public class Result<TData>
    {
        public bool IsSuccess { get; set; }
        public ResultStatus StatusCode { get; set; }
        public TData Data { get; set; }
        public string Message { get; set; }

        public Result(bool isSuccess, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = isSuccess ? ResultStatus.Success : ResultStatus.BadRequest;
            Message = message ?? StatusCode.ToDisplay();
        }

        public Result(bool isSuccess, ResultStatus statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }

        public Result(bool isSuccess, TData data, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = isSuccess ? ResultStatus.Success : ResultStatus.BadRequest;
            Message = message ?? StatusCode.ToDisplay();
            Data = data;
        }

        public Result(TData data, string message = null)
        {
            IsSuccess = true;
            StatusCode = ResultStatus.Success;
            Message = message ?? StatusCode.ToDisplay();
            Data = data;
        }

        public Result(bool isSuccess, ResultStatus statusCode, TData data, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            Data = data;
        }

        #region Implicit Operators

        public static implicit operator Result<TData>(TData data)
        {
            return new(true, ResultStatus.Success, data);
        }

        public static implicit operator Result<TData>(Result serviceResult)
        {
            return new(serviceResult.IsSuccess, serviceResult.StatusCode, serviceResult.Message);
        }

        #endregion

        #region  Operators

        public static Result<TData> Success(TData data)
        {
            return new(true, ResultStatus.Success, data);
        }

        public static Result<TData> Failure()
        {
            return new(false, ResultStatus.BadRequest);
        }

        public static Result<TData> Failure(ResultStatus resultStatus)            
        {
            if (resultStatus == ResultStatus.Success)
                resultStatus = ResultStatus.BadRequest;

            return new(false, resultStatus);
        }

        public static Result<TData> Failure(ResultStatus resultStatus,string message)
        {
            if (resultStatus == ResultStatus.Success)
                resultStatus = ResultStatus.BadRequest;

            return new(false, resultStatus, message);
        }
        #endregion
    }
}