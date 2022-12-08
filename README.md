# ApoteketApi

This is a very rushed attempt at Clean Architecture using a Web Api. There is no validation or error handling whatsoever, so things could go spectacularly wrong, but I did have time to make everything async and I think I got most of the dependencies right. With a bit more time, I would have liked to try to get the dependency injection into the Application layer in order to remove the Api project's dependency on Infrastructure, and I would have liked to use CQRS with the mediator pattern as well. But, some of the pieces are in place, at least - there is a controller, a service, a repository and also an InMemory database that could easily be switched out when continuing the project. 

It's been some time since I've done something like this, and it was a bit of an adventure.
