
# Boba.Configurations

Boba.Configurations is a lightweight library designed for .NET projects to simplify the process of retrieving configurations from appsettings.json files.

### Getting Started


Boba.Configurations is conveniently available on NuGet. Simply install the provider package corresponding to your target database.

```c#
dotnet add package Boba.Configurations
```

Utilize the `--version` option to specify a preview version for installation if needed.

### Basic Usage

Harnessing the power of Boba.Configurations is straightforward. Follow these steps to get started:

#### Registration: 

Begin by registering Boba.Configurations in your `program.cs`. Presently, we support SqlServer, necessitating the provision of a connection string. Alternative data store providers are also available.
```c#
builder.Services.AddBobaConfigurations(builder.Configuration);
```

#### Configuration:

Define your settings class, inheriting from `IConfig`. Here, you can optionally assign default values to be retrieved in the absence of stored data.

```c#
public class EmailConfig : IConfig
{
    public string DefaultFromEmail { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public SMTPSetting SMTPSetting { get; set; }
}

public class SMTPSetting
{
    public string Host { get; set; }
}
```
Store your entity mapped as the `EmailConfig` in `appsettings.json`.
```c#
  "EmailConfig": {
    "DefaultFromEmail": "my.email@gmail.com",
    "Port": 587,
    "SMTPSetting": { "Host": "smtp.gmail.com" },
    "UserName": "my.email@gmail.com",
    "Password": "xxxx cccc dddd yyyy"
  }
```

#### Utilization: 
Inject the config service into your application and access the values effortlessly.
```c#
private readonly EmailConfig _emailConfig;

public YourConstructor(EmailConfig emailConfig)
{
    _emailConfig = emailConfig;
}

Console.WriteLine(_emailConfig.DefaultFromEmail);

```

### Upcoming Features
- Intuitive User Interface for simplified management.
- Query caching mechanisms for enhanced performance.
- Flexible injection options, including Windsor, Unity, Autofac, etc.

### Contributing

Contributions are always welcome!

See `contributing.md` for ways to get started.

Please adhere to this project's `code of conduct`.

### Versions
The main branch is now on .NET 8.0. Previous versions are not available at this time.

### License
This project is licensed under the [MIT](https://github.com/MarwanAlmaseid/Boba.Configurations/blob/master/src/Boba.Configurations/LICENSE.txt) license.

### Support
If you encounter any issues or have questions, please feel free to [raise a new issue](https://github.com/MarwanAlmaseid/Boba.Configurations/issues).

### Technologies

 - [ASP.NET Core 8](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0)
