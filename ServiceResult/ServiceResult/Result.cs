using ServiceResult.Utilities;

namespace ServiceResult
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public ResultStatus StatusCode { get; set; }
        public string Message { get; set; }

        public Result()
        {

        }

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

        public static Result Success()
        {
            return new(true, ResultStatus.Success);
        }

        public static Result Failure()
        {
            return new(false, ResultStatus.BadRequest);
        }

        public static Result Failure(ResultStatus resultStatus)
        {
            if (resultStatus == ResultStatus.Success)
                resultStatus = ResultStatus.BadRequest;

            return new(false, resultStatus);
        }

        public static Result Failure(ResultStatus resultStatus, string message)
        {
            if (resultStatus == ResultStatus.Success)
                resultStatus = ResultStatus.BadRequest;

            return new(false, resultStatus, message);
        }

    }
}
