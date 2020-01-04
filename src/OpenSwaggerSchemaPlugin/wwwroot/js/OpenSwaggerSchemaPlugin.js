Draw.loadPlugin(function (ui) {
    const pluginLocation = 'http://localhost:6930/';
    const pluginDomElement = 'OpenSwaggerSchemaPluginApp';
    let pluginContract;

    document.getElementsByTagName("body")[0].appendChild(document.createElement(pluginDomElement));

    mxscript(pluginLocation + 'js/blazor.webassembly.js');
    mxscript(pluginLocation + 'js/OpenSwaggerSchemaContract.js', function () {
        pluginContract = OpenSwaggerSchemaContract;
        pluginContract.init(ui);
    });

    mxResources.parse('openSwaggerSchema=Swagger Schema');

    ui.actions.addAction('openSwaggerSchema', function () {
        pluginContract.run();
    });

    var theMenu = ui.menus.get('openFrom');
    var oldMenu = theMenu.funct;

    theMenu.funct = function (menu, parent) {
        oldMenu.apply(this, arguments);
        ui.menus.addMenuItems(menu, ['openSwaggerSchema'], parent);
    };
});