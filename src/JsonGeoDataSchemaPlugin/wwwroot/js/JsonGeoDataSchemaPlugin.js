var JsonGeoDataSchemaPluginLocation = 'file://D:/GIT/DrawIoBlazorMapDiagram/publish_simple/JsonGeoDataSchemaPlugin/dist/';
JsonGeoDataSchemaPluginLocation = 'http://localhost:10613/';

Draw.loadPlugin(function (ui) {

    const loadScript = (path, action) => {
        var scriptElement = document.createElement('script');
        scriptElement.setAttribute('src', path);
        document.getElementsByTagName("body")[0].appendChild(scriptElement);

        if (action) {
            var onLoadExecuted = false;

            scriptElement.onload = scriptElement.onreadystatechange = function () {
                if (!onLoadExecuted && (!this.readyState || this.readyState === 'complete')) {
                    onLoadExecuted = true;
                    action();
                }
            };
        }
    };
    
    loadScript(JsonGeoDataSchemaPluginLocation + 'js/JsonGeoDataSchemaDotNetContract.js');
    loadScript(JsonGeoDataSchemaPluginLocation + 'js/JsonGeoDataSchemaJsContract.js', () => {
        JsonGeoDataSchemaJsContract.setEditorUi(ui);
    });
    loadScript(JsonGeoDataSchemaPluginLocation + 'js/blazor.webassembly.js', () => {
        const pluginDomElement = 'JsonGeoDataSchemaPluginApp';
        document.getElementsByTagName("body")[0].appendChild(document.createElement(pluginDomElement));
    });

    const menuActionName = 'JsonGeoDataSchema';

    if (mxResources) {
        mxResources.parse(menuActionName + '=Open Json Geo Data');
    }

    ui.actions.addAction(menuActionName, function () {
        JsonGeoDataSchemaDotNetContract.onMenuClick();
    });

    const openFromMenu = ui.menus.get('openFrom');
    const oldOpenFromMenuFunc = openFromMenu.funct;

    openFromMenu.funct = function (menu, parent) {
        oldOpenFromMenuFunc.apply(this, arguments);
        ui.menus.addMenuItems(menu, [menuActionName], parent);
    };

    const insertMenu = ui.menus.get('insert');
    const oldInsertMenu = insertMenu.funct;

    insertMenu.funct = function (menu, parent) {
        oldInsertMenu.apply(this, arguments);
        ui.menus.addMenuItems(menu, [menuActionName], parent);
    };
});