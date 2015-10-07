# Pipeline

Here is the request pipeline:

    +---------------+          +---------------+          +--------------+                     
    |               |          |               |          |              |                     
    |    Request    +---------->   Middleware  +---------->    Router    |                     
    |               |          |               |          |              |                     
    +---------------+          +---------------+          +-------+------+                     
                                                                  |                            
    1. Request comes in from client                               +--------------------+       
    2. Middleware transforms it                                   |                    |       
    3. Router determines content and service to hit       +-------v-------+     +------+------+
    4. A&A validate access to the content                 |               |     |             |
    5. Content is retrieved from database                 |    Content    |     | Auth & Auth |
    6. A&A validate access to service action              |               |     |             |
    7. Service transforms content and creates response    +-------+-------+     +------+------+
    8. Middleware transforms response                             |                    |       
    9. Response is sent to client                                 +--------------------+       
                                                                  |                            
    +---------------+          +---------------+          +-------v-------+                    
    |               |          |               |          |               |                    
    |    Response   <----------+   Middleware  <----------+    Service    |                    
    |               |          |               |          |               |                    
    +---------------+          +---------------+          +---------------+                    


## Overview

Servant is built on top of [OWIN](http://owin.org/). Along with that, Servant is designed to accommodate a pipeline that encourages manipulating data through a simple step-by-step process. As you can see from the diagram above, Servant takes nine major steps to responding to a request.

### Middleware

OWIN/Servant Middleware runs before and after every specified request. How this affects the application is up to you, but middleware allows you to decide whether to handle a request using Servant or something else, or you could use it to manipulate an incoming request. Middleware is usually a good place to put code that affects large parts of the web application that have cross cutting concerns. See [OWIN Middleware in the IIS integrated pipeline](http://www.asp.net/aspnet/overview/owin-and-katana/owin-middleware-in-the-iis-integrated-pipeline) for some more detail on OWIN and OWIN Middleware.

### Router

[Full Article](./routing.md)

The router is used to determine the pathway through the application's code. In Servant, this means determining the content and controller endpoints to hit. Which sections are hit is determined by the configuration, but a rigged install of Serviced will provide most of that for you.

### Content

Content modules control what data is retrieved from the database. They are in charge of defining what data they are able to retrieve and in charge of getting that data in the context of a request. Content modules are also in charge of defining which permissions a user needs to have in order to access the data, if any. Those requirements are then used to determine whether the content should be retrieved or not.

There are several benefits to including content retrieval in the request pipeline:

1. First, it allows you to define strong authorization requirements on specific pieces of data in the application. This is very important when making sure that data is not accidentally exposed or manipulated.
2. Second, it provides a normalized interface to your database. This is important when sharing data across services.
3. Third, it makes resource based routing a cinch. Content modules can filter data based on the request and previous content modules, meaning that getting all of the pets for a user while using the same module for all of the pets in a building is easy to implement in a DRY fashion.
4. Fourth, it just makes sense. Separate the data logic from the business logic.

### Auth & Auth

Simply put, Authorization & Authentication are core concerns for any application. Servant intentionally makes it easy by providing the proper tools to securely manage access to and manipulation of different content. As stated in the routing document, Authentication and Authorization occur after the router has determined the path for the request, and specifically before content and services are hit.

### Services

Services are in charge of defining the interactions that can be made on content and how they are exposed to the outside world. Services determine how content is able to be manipulated and what Auth & Auth rules apply to those manipulations.

Services are designed to be agnostic of requests and responses, allowing a Serviced app to be run on more than just the web, enabling potential reuse of code across platforms.
