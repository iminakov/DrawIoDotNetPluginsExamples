# Draw.io DotNet Blazor Plugins Examples

This is source code project for an article: [How to implement plug-in on C# Blazor for native JavaScript application. Open API schema diagram for Draw.io.](https://medium.com/@wertugo.graphics/how-to-implement-plug-in-on-c-blazor-for-native-javascript-application-e462845e1e89)

**Download and start project:**

1. Download project repository and open DrawIoDotNetPlugins.sln in MSVS 2019
2. Run web site on IIS express. It will be loaded at http://localhost:6930/

**Open and configure Draw.io:**

1. Open web site [draw.io](https://draw.io) - online diagram editor
2. Setup plug-in by menu: Extras -> Plugins ...
plug-in url is http://localhost:6930/js/OpenApiDocumentSchemaPlugin.js
3. Reload draw.io web site to initialize plug-in on startup

**Build Open API Swagger Diagram example:**

1. In Draw.io web application open menu item File -> Open from... -> Open API document 
2. Open swagger json document from repository: ..\src\OpenApiDocumentSchemaPlugin\Sample\test-swagger.json
or you can use any other Open API/Swagger schema json file
3. Will be created diagram will all blocks in zero point
4. Make better diagram view by menu item: Arrange -> Layout -> Horizontal Flow

[![123](https://miro.medium.com/max/1114/1*FAqEkAm_AtWv2g7G7BSPug.gif "123")](https://miro.medium.com/max/1114/1*FAqEkAm_AtWv2g7G7BSPug.gif "123")
