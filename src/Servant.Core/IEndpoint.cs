
namespace Servant.Core
{
    public interface IEndpoint
    {
        EndpointInfo EndpointInfo { get; }
        object Process(object input);
    }
}