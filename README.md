# CoreApp

If your project has too many dependencies and you don't understand how to make easier, coreApp for you. 
You should split your configs on dependencies and initializations. These services should register in Application class;

Application
-----------

Application is main class in project

```c#

var application = new Application<Container>(new AppOptions<Container>
{
	DependencyContainer = container;
	GetServiceFunc = container.GetInstance;
	GetAllServicesFunc = container.GetAllInstances;
	VerifyAction = c => c.Verify();
	Logger = logger;
});

```

When you create application, you should set Container for registration dependencies, delegates for getting services, action for verifying correct dependencies and Logger.

Dependencies
------------

Dependency Module contains code for registration services of one module. For example:

```c#

public class FacebookDependency: IIDependency<Container>
{
	public void Register(Container container)
    {
        container.Register(() => new FbClient("authKey", "secretKey");
    }
}

application.SetDependency(new FacebookDependency());

```

Init
----

Init Services will called after registration dependencies and you can use Dependency Resolver for additional settings.For Example

```c#

public class AspNetMvcInit: IInit
{
	public void Init(IDependencyResolver resolver)
	{
		System.Web.Mvc.DependencyResolver.SetResolver(resolver.GetService, resolver.GetServices);
	}
}

application.SetInit(new AspNetMvcInit());

```

Build
-----

When you have added all settings, you should call Build method for registration all things. After this you can use dependencyResolver and Logger for starting your project.

```c#

var appConfig = application.SetDependency(new FacebookDependency())
						   .SetInit(new AspNetMvcInit())
						   .Build();

appConfig.DependencyResolver.GetService<MainService>().Start();

```
