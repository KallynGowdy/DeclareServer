using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servant.Routing;
using Xunit;

namespace Servant.Test.Routing.Unit
{
    /// <summary>
    /// Test writing routes using the core routing library.
    /// </summary>
    public class TestConfigureCoreRoutes
    {
        public class TestService
        {
            public object HandleMessage(dynamic message)
            {
                return new object();
            }

            public object HandleMessage(Message message)
            {
                return null;
            }
        }

        public class Message
        {
            public int Id { get; set; }

            public string Action { get; set; }

            public string Header { get; set; }
        }

        public class MessageParams : Message
        {
            public new Param<int> Id { get; set; }
            public new QueryParam<string> Action { get; set; }
        }

        public TestConfigureCoreRoutes()
        {
            //RouteCollection = routeBuilder;
        }

        IServantRouteCollection RouteCollection { get; }

        [Fact]
        public void Test_Simple_Static_Get_Route_Can_Be_Handled_By_Anonymous_Method()
        {
            RouteCollection.Get("static-page").To(m => "handled!");
        }

        [Fact]
        public void Test_Simple_Static_Get_Route_Can_Be_Made()
        {
            RouteCollection.Get("static-page").To<TestService>().Handler((s, m) => s.HandleMessage(m));
        }

        [Fact]
        public void Test_Simple_Static_Get_Route_Can_Be_Made_With_Explicit_Message()
        {
            RouteCollection.Get<Message>("static-page").To<TestService>().Handler((s, m) => s.HandleMessage(m));
        }

        [Fact]
        public void Test_Get_Route_Can_Be_Made_With_Parameter()
        {
            // GET: static-page/{id:int}
            RouteCollection.Get<MessageParams>(m => "static-page" / m.Id).To<TestService>().Handler((s, m) => s.HandleMessage(m));
        }

        [Fact]
        public void Test_Get_Route_Can_Be_Made_With_Query_Parameter()
        {
            // GET: static-page?action={action:string}
            RouteCollection.Get<MessageParams>(m => "static-page" + m.Action).To<TestService>().Handler((s, m) => s.HandleMessage(m));
        }

        [Fact]
        public void Test_Get_Route_Can_Be_Made_With_Values_From_Headers()
        {
            RouteCollection.GetBinder<MessageParams>(binder =>
            {
                return binder.Url("static-page")
                    .Param(m => m.Id)
                    .Query("action", m => m.Action)
                    .Header("X-Header", m => m.Header);
            }).To<TestService>().Handler((s, m) => s.HandleMessage(m));
        }

        [Fact]
        public void Test_Content_Routing()
        {
            // static-page/users/{userId}/posts/{postId}/comments/{commentId}
            // static-page/users/named/{userName}/posts
            // static-page/users/{userId}
            // static-page/users

            // static-page/posts?page={pageId}&count={count}
            // static-page/posts/{postId}/comments
            // static-page/posts/by/user/{userId}
            // static-page/posts/search/{q}
            // static-page/posts/tagged/with/{tag1}/and/{tag2}/and/{tag3}
            // static-page/posts/tagged/with/user/{user1}/and/{tag1}/and/with/user/{user2}

            // static-page/comments/{commentId}


            // {static-url}/{root-route}/{sub-route1}/{sub-route2}/{sub-route3}...

            // Route: Users
            // Url: users
            // SubRoutes: [UserId]

            // Route: UserId
            // Url: {userId}
            // SubRoutes: [Posts, NamedUsers]

            // Route: NamedUsers
            // Url: named/{userName}
            // SubRoutes: [Posts]

            // Route: Posts
            // Url: posts
            // SubRoutes: [PostId, TaggedPosts]

            // Route: PostId
            // Url: {postId}
            // SubRoutes: [Comments]

            // Route: Comments
            // Url: comments
            // SubRoutes: [CommentId]

            // Route: CommentId
            // Url: {commentId}
            // SubRoutes: []

        }
    }
}
