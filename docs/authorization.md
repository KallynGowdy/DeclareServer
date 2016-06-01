# Authorization

Authorization in Servant is the process of determining what level of access a client should have based on the evidence 
that the client provided in the [Authentication](./authentication.md) phase.

When we talk about Authorization, we are specifically referring to:

1. Accessing data and information.
2. Performing operations.

Now, these are not the only two categories that need authorization by any stretch of the imagination, but separating authorization into two distinct roles is helpful for recognizing the resources that are worth protecting. In particular,

1. Information that needs to be secured. (For obvious reasons)
2. Things that change the information that needs to be secured. (Again, for obvious reasons)

In a simple world, we could label every operation with a permission, assign permissions to users, and deny anything that a user doesn't have permissions for.

This design, however, isn't satisfactory for a couple of reasons. First, not every operation has a distinct permission that can be assigned to it, and most operations relate to modifing user information or even viewing shared information.

In Servant, authorization rules can be designed to provide access to sets of data in an atomic manner. This way, complex graphs of data can be secured in spite of having many complex relationships. 

For example, take the following Entity Framework models:

```csharp
class User
{
    public string Id { get; set; }
    public IList<Photo> OwnedPhotos { get; set; }
    public IList<Photo> SharedPhotos { get; set; }
}

class Photo
{
    public string Id { get; set; }
    // This HD Url is only available to the owner
    public string UrlHd { get; set; }
    // SD Urls can be seen by the owner and any of the sharers.
    public string UrlSd { get; set; }
    public IList<User> Sharers { get; set; }
    public User Owner { get; set; }
}

modelBuilder.Model<Photo>()
    .HasRequired(p => p.Owner)
    .WithMany(u => u.OwnedPhotos);
    
modelBuilder.Model<Photo>()
    .HasMany(p => p.Sharers)
    .WithMany(u => u.SharedPhotos);
```

In a traditional system, the rules that specify who is able to view the `UrlHd` and the `UrlSd` properties would probably be separated by service, possibly even by operation. It might look something like this:

```csharp
class PhotosService
{
    public PhotoResponse GetPhoto(string photoId, User user)
    {
        var photo = context.Photos.FirstOrDefault(p => p.Id == photoId);
        if(photo.Owner.Id == user.Id)
        {
            // User is owner, we can return both URLs
            return new PhotoResponse(photo.UrlHd, photo.UrlSd);
        } 
        else if(photo.Sharers.Any(u => u.Id == user.Id))
        {
            // User is sharer, we can only return SD URL
            return new PhotoResponse(null, photo.UrlSd);
        }
        else
        {
            // No Access
            return new PhotoResponse(null, null);
        }
    }
}
```

Then, whenever we want to retrieve a photo from the database, we need to use this logic, which can stifle the flexibility of the API because we need to either accommodate this service or create another service that validates whichever photo we give it.

That is only a single example related to authorization. With Servant, we will aim to provide great solutions to all of the potential authorization problems that can arise in an app.

Ideally, we will be able to create a set of rules that are flexible enough to accomidate all of our services needs.

With that in mind, we can decide that rules should be as atomic as possible.
Additionally, we have a choice between putting the authorization rules between the database and services or between the services and the client.
Each choice has advantages and disadvantages.
