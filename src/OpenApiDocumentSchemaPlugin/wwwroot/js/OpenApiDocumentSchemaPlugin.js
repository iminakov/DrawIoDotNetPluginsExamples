Draw.loadPlugin(function (ui) {
    const pluginLocation = 'http://localhost:6930/';
    const pluginDomElement = 'OpenApiDocumentSchemaPluginApp';

    document.getElementsByTagName("body")[0].appendChild(document.createElement(pluginDomElement));

    mxscript(pluginLocation + 'js/OpenApiDocumentSchemaDotNetContract.js');
    mxscript(pluginLocation + 'js/OpenApiDocumentSchemaJsContract.js', function () {
        OpenApiDocumentSchemaJsContract.setEditorUi(ui);
    });

    mxscript(pluginLocation + 'js/blazor.webassembly.js');

    mxResources.parse('OpenApiDocumentSchema=Open Api Document');

    ui.actions.addAction('OpenApiDocumentSchema', function () {
        OpenApiDocumentSchemaDotNetContract.onMenuClick();
    });

    var theMenu = ui.menus.get('openFrom');
    var oldMenu = theMenu.funct;

    theMenu.funct = function (menu, parent) {
        oldMenu.apply(this, arguments);
        ui.menus.addMenuItems(menu, ['OpenApiDocumentSchema'], parent);
    };
});