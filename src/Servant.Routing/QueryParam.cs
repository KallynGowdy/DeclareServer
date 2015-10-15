namespace Servant.Routing
{
    public class QueryParam
    {
        public static string operator +(string left, QueryParam right)
        {
            return null;
        }

        public static string operator +(QueryParam left, QueryParam right)
        {
            return null;
        }
    }

    public class QueryParam<T> : QueryParam
    {
    }
}