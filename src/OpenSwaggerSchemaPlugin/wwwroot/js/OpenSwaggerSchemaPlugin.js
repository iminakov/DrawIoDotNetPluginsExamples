Draw.loadPlugin(function (ui) {
    const pluginLocation = 'http://localhost:6930/';
    const pluginDomElement = 'OpenSwaggerSchemaPluginApp';

    document.getElementsByTagName("body")[0].appendChild(document.createElement(pluginDomElement));

    mxscript(pluginLocation + 'js/OpenSwaggerSchemaDotNetContract.js');
    mxscript(pluginLocation + 'js/OpenSwaggerSchemaJsContract.js', function () {
        OpenSwaggerSchemaJsContract.setEditorUi(ui);
    });

    mxscript(pluginLocation + 'js/blazor.webassembly.js');

    mxResources.parse('openSwaggerSchema=Swagger Schema');

    ui.actions.addAction('openSwaggerSchema', function () {
        OpenSwaggerSchemaDotNetContract.onMenuClick();
    });

    var theMenu = ui.menus.get('openFrom');
    var oldMenu = theMenu.funct;

    theMenu.funct = function (menu, parent) {
        oldMenu.apply(this, arguments);
        ui.menus.addMenuItems(menu, ['openSwaggerSchema'], parent);
    };
});