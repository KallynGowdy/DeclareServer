# Routing

Routing in Servant is built to be quick, easy, and configurable. Instead of a big framework that comes with all of the nuts and bolts though, Servant's goal is to provide the most common use-case,
and allow alternatives to be swapped in with ease.

## Servant.Routing.Default

The default routing library is actually quite simple. Just map a single path to a single service.
Fortunately, because of the power that services provide, this is not a limited approach.

For example, say that we map the path `https://mywebsite.example.com/api/v2/my-service`, to `MyService`.
From here, `MyService` can handle query parameters, extra URL segments, HTTP headers, and more.
And additionally, because services are designed to be composable, you can design an architecture that knows nothing about HTTP, but is still able to handle it like a boss.  
