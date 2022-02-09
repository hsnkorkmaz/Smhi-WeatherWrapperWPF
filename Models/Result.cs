namespace SMHIAPI.Models
{
    public class Result
    {
        protected Result(bool success, string? message = null)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; }
        public string? Message { get; }

        public static Result Ok() => new Result(true);
        public static Result Ok(string message) => new Result(true, message);
        public static Result Fail() => new Result(false);
        public static Result Fail(string message) => new Result(false, message);
    }

    public class Result<T> : Result
    {
        protected Result(bool success, T data) : this(success, data, null) { }

        protected Result(bool success, T data, string message) : base(success, message)
        {
            Data = data;
        }

        public T Data { get; }

        public static Result<T> Ok(T data)
        {
            return new Result<T>(true, data);
        }

        public static Result<T> Ok(T data, string message)
        {
            return new Result<T>(true, data, message);
        }

        public new static Result<T> Fail()
        {
            return new Result<T>(false, default(T));
        }

        public new static Result<T> Fail(string message)
        {
            return new Result<T>(false, default(T), message);
        }
    }
}
