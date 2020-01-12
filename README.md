# Draw.io DotNet Blazor Plugins Examples

This is source code for article: [How to implement plug-in on C# Blazor for native JavaScript application.](https://medium.com/@wertugo.graphics/how-to-implement-plug-in-on-c-blazor-for-native-javascript-application-e462845e1e89?source=friends_link&sk=3b2b0ff38a52236eb7f8e667926a40d0)

**How to run project and test plug-in in Draw.io:**

1. Download project repository and open DrawIoDotNetPlugins.sln in MSVS 2019
2. Run web site on IIS express. It will be loaded at http://localhost:6930/
3. Open web site [draw.io](https://draw.io) - online diagram editor
4. Setup plug-in by menu: Extras -> Plugins ...
plug-in url is http://localhost:6930/js/OpenApiDocumentSchemaPlugin.js
5. Reload draw.io web site to initialize plug-in on startup
6. Open menu item File -> Open from... -> Open API document 
7. Open swagger json document from sample in repository: ..\src\OpenApiDocumentSchemaPlugin\Sample\test-swagger.json
or you can use any other Open API schema
8. Make better diagram view by menu: Arrange -> Layout -> Horizontal Flow
9. Find new swagger API diagram

[![123](https://miro.medium.com/max/1114/1*FAqEkAm_AtWv2g7G7BSPug.gif "123")](https://miro.medium.com/max/1114/1*FAqEkAm_AtWv2g7G7BSPug.gif "123")
