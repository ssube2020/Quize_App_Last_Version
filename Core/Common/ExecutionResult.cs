using System;
namespace Core.Common
{

    public class ExecutionResult<T>: ExecutionResult
    {

        public T? Data { get; set; }

        public int Count { get; set; }

    }

    public class ExecutionResult
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public string? ErrorMessage { get; set; }

        public int StatusCode { get; set; } = 200;
    }

}

