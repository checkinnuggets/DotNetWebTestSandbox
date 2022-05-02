# .NET Web Test Sandbox

This solution contains some examples of basic browser-based test automation for .NET web applications.

There are examples of both .NET Framework and .NET Core web sites which use Selenium WebDriver.  

All examples use `Selenium.WebDriver.GeckoDriver` which will execute the tests using Mozilla Firefox, but the NuGet references could just as easily be replaced with the corresponding packages for other browsers - `Selenium.WebDriver.ChromeDriver` could be used to execute the tests with Google Chrome for example.

# Scenario
The examples are based around the scenario of a basic Address Book, which operates on a collection of objects that look like this:

```
    public class AddressBookEntry
    {
        [ExplicitKey]
        public string Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("E-Mail Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("Telephone Number")]
        public string TelephoneNumber { get; set; }
    }
```

# Examples


## FrameworkWebApplication (and FrameworkWebApplication.Tests)

The first example shows a .NET Framework version of the Address Book application which runs on IIS Express.  It uses an in-memory data store.

The tests require that the web server/web site is running and accessible.  The tests then instantiate a web browser and interact with the site in the same way a user would.


### Running the tests

Right-click the project `FrameworkWebApplication` and select 'Set as Startup Project' then from the top menu bar select 'Debug' and then 'Start Without Debugging'.  This should launch the web server (IIS Express - which you will find in the system tray).  

You should be able to access the site from a web browser at `http://localhost:49387/` (port number may vary).

If you don't have the 'Test Explorer' window visible in Visual Studio, from the top menu select 'Test' then 'Text Exporer' and from there you will be able to select and run `FrameworkWebApplication.Tests`.



## CoreWebApplication (and CoreWebApplication.Tests)

This example shows a .NET Core implementation of the Address Book application.  The .NET Core version can run on IIS Express and the tests work in the same way - by creating and driving the operation of a web browser.

The .NET Core example is slightly more complex in that it uses a real database.  (A script to set this up can be found at the root of the solution).

### Shared Test State

Testing against a real database can be problematic.  Each time a test excutes it performs the same operation, but if you can't guarantee the starting state then you can't be sure that your results are meaningful.  Did that test fail because something is broken, or because a particular record has that it was looking for was changed or removed?


### Microsoft.AspNetCore.Mvc.Testing

The tests in `CoreWebApplication.Tests` make use of the `Microsoft.AspNetCore.Mvc.Testing` package.  We create a simple Test Harness class which is responsible for setting up the WebHost.  The `CoreWebApplication` itself uses standard .NET Core ServiceCollection /  Dependency Injection.  As part of creating the WebHost, the Test Harness can provide alternate implementations of particular interfaces.  In this case, we replace `SqlServerDataStore` with `InMemoryDataStore`. This allows us each test run to start from a clean slate.

Note that because the Test Harness creates and instantiates the WebHost, you don't need to have the web server/site running.  You will get an error `Failed to bind to address` if the test run tries to instantiate a WebHost while IIS Express is also running a site on the same port.

I hope to write a more detailed post on `Microsoft.AspNetCore.Mvc.Testing` this in future.

## CoreWebApi (and CoreWebApi.Tests)

This example demonstrates testing a .NET Core Web API.  As we are testing an API, no web browser is required.  Instead, we make HTTP requests directly using `HttpClient`, deserialize with `Newtonsoft.Json` and validate the responses using `FluentAssertions`.

Similar to the `CoreWebApplication`, this one also uses a Test Harness class to instantiate the WebHost which makes it quite easy to write fully-container API Integration tests.

This example uses NUnit - just to demonstrate that different test frameworks and assertion libraries can be used without making too much difference to the overall picture.