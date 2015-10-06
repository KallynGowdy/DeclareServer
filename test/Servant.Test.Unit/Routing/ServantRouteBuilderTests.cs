using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Servant.Core;

namespace Servant.Test.Unit.Routing
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".


    public class ServantRouteBuilderTests
    {
        public class TestGetRequest : ServantRoute<TestGetResponse>
        {
            public RouteParam<string> Id { get; set; }

            public override Task<TestGetResponse> HandleAsync()
            {
                throw new System.NotImplementedException();
            }
        }

        public class TestGetResponse
        {
            public string Email { get; set; }
        }

        public class TestPostRequest : ServantRoute<TestPostResponse>
        {
            public TestPostRequestBody Body { get; set; }

            public override Task<TestPostResponse> HandleAsync()
            {
                throw new System.NotImplementedException();
            }
        }

        public class TestPostRequestBody
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }

            public DateTimeOffset? DateOfBirth { get; set; }
        }

        public class TestPostResponse
        {

        }

        public class TestPutRequest
        {
            public RouteParam<string> Id { get; set; }
            public TestPutRequestBody Body { get; set; }
        }

        public class TestPutRequestBody
        {

        }

        public class TestDeleteRequest : ServantRoute<TestDeleteResponse>
        {
            public RouteParam<string> Id { get; set; }

            public override Task<TestDeleteResponse> HandleAsync()
            {
                throw new NotImplementedException();
            }
        }

        public class TestDeleteResponse
        {
        }

        // POST: /?Action={action}
        //          &VolumeId={volumeId}
        //          &InstanceId={instanceId}
        //          &Device={device}
        // POST: /volumes/{volumeId}/{action}
        public class VolumeActionMessage
        {
            public class RouteDefinition : IRouteDefinition<AttachVolumeMessage>
            {
                public void DefineRoutes(IServantRouteBuilder routeBuilder)
                {
                    // Accept POST Requests
                    routeBuilder.Post();

                    // When binding parameters, the order is defined as follows:
                    // 1. First, bind all parameters that appear in the URL
                    // 2. Then, bind the parameters based on the order defined for their Value() declaration
                    //      a. If the value does not have a Value() declaration or any attributes,
                    //         ignore the parameter
                    // 3. Check for values that were required but not bound.

                    // Bind VolumeId and Action to the Url in the form:
                    // volumes/{volumeId}/{action}
                    routeBuilder.Url(msg => "volumes"/msg.VolumeId/msg.Action);

                    routeBuilder.Value(msg => msg.Action)
                                .Required()
                                .Query(); // Retrive 'Action' param from the query string

                    routeBuilder.Value(msg => msg.VolumeId)
                                .Required()
                        // First look at 'VolumeId' query param
                                .Query()
                        // Then look at the 'VolumeId' Header
                                .Header()
                        // Finally, look at the 'VolumeId' form body param.
                                .Body();

                    // Register multiple bindings at the same time
                    routeBuilder.Value(msg => msg.InstanceId, msg => msg.Device)
                                .Required()
                                .Query()
                                .Body();
                }
            }

            public string Action { get; set; }

            public string VolumeId { get; set; }

            public string InstanceId { get; set; }

            public string Device { get; set; }
        }

        // Defines a message that gets "hit" when the Action is "AttachVolume"
        public class AttachVolumeMessage
        {
            public class RouteDefinition : IRouteDefinition<AttachVolumeMessage>
            {
                public void DefineRoutes(IServantRouteBuilder routeBuilder)
                {
                    // Allow routing to through the "parent message" ActionMessage when the action equals "AttachVolume"
                    routeBuilder.ParentMessage<VolumeActionMessage>()
                        .BindTo(msg => msg.Parent)
                        .AllowSubrouteWhen(msg => msg.Action == "AttachVolume" || msg.Action == "attach");
                }
            }

            public VolumeActionMessage Parent { get; set; }
        }

        public class AttachVolumeHandler : IHandler<AttachVolumeMessage>
        {
            public AttachVolumeHandler()
            {
               // Dependency Injection Support 
            }

            public async Task<object> Handle(AttachVolumeMessage msg)
            {
               
            }
        }

        public class VolumeAttachedMessage
        {
            
        }

        public void Test_Specify_Route_By_Class()
        {
            IServantRouteBuilder routeBuilder = null;

            // Listen to AttachVolumeMessage messages
            routeBinder.Message<AttachVolumeMessage>()
                .To(async msg =>
                {
                    // handler pipeline logic.
                    // this gets hit first
                })
                .To(async msg =>
                {
                    // then this
                })
                // and finally the handler(s)
                .ToHandler<AttachVolumeHandler>();

            routeBinder.Message<VolumeAttachedMessage>()
                .ToClient();
        }

    }
}
