
using System;

namespace Servant.Core
{
    public abstract class EndpointWrapper : IEndpoint
    {
        private readonly IEndpoint wrapped;

        public EndpointWrapper(IEndpoint wrapped) 
        {
            this.wrapped = wrapped;
        }

        public EndpointInfo EndpointInfo => MapEndpointInfo(wrapped.EndpointInfo);

        public object Process(object input)
        {
            throw new NotImplementedException();
        }

        protected abstract EndpointInfo MapEndpointInfo(EndpointInfo info);
        protected abstract object MapInput(object input);
        protected abstract object MapOutput(object output);
    }

}