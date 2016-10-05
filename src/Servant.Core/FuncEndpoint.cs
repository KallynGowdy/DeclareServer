
using System;
using Servant.Core;

public class FuncEndpoint : IEndpoint
{
    public EndpointInfo EndpointInfo => new EndpointInfo("Func", "1.0.0", null, null);

    public object Process(object input)
    {
        throw new NotImplementedException();
    }
}