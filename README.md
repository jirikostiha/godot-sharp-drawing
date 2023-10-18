# Godot Sharp Some

[![NuGet Downloads](https://img.shields.io/nuget/dt/GodotSharpSome.Drawing2D.svg)](https://www.nuget.org/packages/GodotSharpSome.Drawing2D/)
![GitHub repo size](https://img.shields.io/github/repo-size/jirikostiha/godot-sharp-some)  

Is set of extensions for custom drawing API in Godot engine version 3.3 and higher. It simplifies script drawing.

## Features

Includes CanvasItem extensions for drawing various plane shapes and Multiline class extending possibilities of drawing API.  

**Note: Godot currently does not support parameters 'width' and 'antialiased' of 'DrawMultiline' method so they have no effect for now.**  
\
![pic](./doc/images/dots_and_lines_animation.gif)
![pic](./doc/images/connections_animation.gif)
![pic](./doc/images/candlesticks_animation.gif)
![pic](./doc/images/primitives_animation.gif)

Would you like to know [more](./src/GodotSharpSome.Drawing2D/readme.md)
and [more](./src/usage/)?

## Setup

Add [nuget package](https://www.nuget.org/packages/GodotSharpSome.Drawing2D)
to your project.

Godot project's `.csproj` file should look like this:

```xml
<Project Sdk="Godot.NET.Sdk/3.3.0">
  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="GodotSharpSome.Drawing2D" Version="0.19.1" />
  </ItemGroup>
</Project>
```

## Contributing

Any ideas, contributions and bug reports are welcome!

For new idea create an [issue](https://docs.github.com/en/issues/tracking-your-work-with-issues/creating-an-issue).  
For bug report create an [issue](https://docs.github.com/en/issues/tracking-your-work-with-issues/creating-an-issue).  
For contribution create a [pull request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/creating-a-pull-request).  

[Conventions](./doc/conventions.md)  

## License

Project is under [MIT](./LICENSE) license.
