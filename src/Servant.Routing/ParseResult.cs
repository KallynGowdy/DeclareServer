namespace Servant.Routing
{
    public class ParseResult
    {
        protected ParseResult(bool success, object result)
        {
            IsSuccessful = success;
            Result = result;
        }

        public static ParseResult Failed()
        {
            return new ParseResult(false, default(object));
        }

        public static ParseResult Success(object value)
        {
            return new ParseResult(true, value);
        }

        public bool IsSuccessful { get; }
        public object Result { get; }
    }

    public class ParseResult<T> : ParseResult
    {
        private ParseResult(bool success, T result) : base(success, result)
        {
            Result = result;
        }

        public new static ParseResult<T> Failed()
        {
            return new ParseResult<T>(false, default(T));
        }

        public static ParseResult<T> Success(T value)
        {
            return new ParseResult<T>(true, value);
        } 

        public new T Result { get; }
    }
}