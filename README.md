# yamlconfig


.NET Strongly-typed Application Configuration with YAML


[![Build status](https://ci.appveyor.com/api/projects/status/fkl9q35b11f52es2?svg=true)](https://ci.appveyor.com/project/thebentern/yamlconfig)
[![NuGet](https://img.shields.io/nuget/v/YamlConfig.svg?maxAge=2592000)](https://www.nuget.org/packages/YamlConfig/)
[![Coverage Status](https://coveralls.io/repos/github/thebentern/yamlconfig/badge.svg?branch=master)](https://coveralls.io/github/thebentern/yamlconfig?branch=master)
[![Join the chat at https://gitter.im/thebentern/yamlconfig](https://badges.gitter.im/thebentern/yamlconfig.svg)](https://gitter.im/thebentern/yamlconfig?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

### Why YAML?


[YAML](http://yaml.org/) is an easy to learn human-readable language, used frequently in communities outside of .NET, particularly the Ruby community. To illustrate the difference between traditional XML based config and YAML config, lets take a look at the simple AppSettings example:

```xml
<!-- Traditional .NET app configuration with app settings -->
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <appsettings> 
        <add key="AppName" value="My App Name" />
        <add key="DatabaseInstance" value="locahost" />
    </appsettings>
</configuration>
```

And here is how we could represent it in Yaml.

```yaml
# New hotness Yaml configuration
configuration:
  appSettings:
    AppName: My App Name
    DatabaseInstance: localhost
```

### Aren't you re-inventing the wheel though?

Yes, but this wheel is cooler.


# Contributing

Please see [Contributing](Contributing.md) for information about how you can contribute to the project.


# License

Please see [LICENSE](LICENSE) for license details.
