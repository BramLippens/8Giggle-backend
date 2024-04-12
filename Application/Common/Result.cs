namespace Application.Common;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public Result(bool success, string message, T data)
    {
        IsSuccess = success;
        Message = message;
        Data = data;
    }

    public static Result<T> Success(T data) => new Result<T>(true, string.Empty, data);
    public static Result<T> Failure(string message) => new Result<T>(false, message, default);
}
