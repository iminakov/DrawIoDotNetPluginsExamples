var OpenApiDocumentSchemaPluginLocation = 'file://D:/GIT/DrawIoBlazorMapDiagram/publish_simple/OpenApiDocumentSchemaPlugin/dist/';
OpenApiDocumentSchemaPluginLocation = 'http://localhost:6930/';

Draw.loadPlugin(function (ui) {

    const loadScript = function (path, action) {
        var scriptElement = document.createElement('script');
        scriptElement.setAttribute('src', path);
        document.getElementsByTagName("body")[0].appendChild(scriptElement);

        if (action) {
            var onLoadExecuted = false;

            scriptElement.onload = scriptElement.onreadystatechange = function () {
                if (!onLoadExecuted && (!this.readyState || this.readyState == 'complete')) {
                    onLoadExecuted = true;
                    action();
                }
            };
        }
    };
    
    loadScript(OpenApiDocumentSchemaPluginLocation + 'js/OpenApiDocumentSchemaDotNetContract.js');
    loadScript(OpenApiDocumentSchemaPluginLocation + 'js/OpenApiDocumentSchemaJsContract.js', () => {
        OpenApiDocumentSchemaJsContract.setEditorUi(ui);
    });
    loadScript(OpenApiDocumentSchemaPluginLocation + 'js/blazor.webassembly.js', () => {
        const pluginDomElement = 'OpenApiDocumentSchemaPluginApp';
        document.getElementsByTagName("body")[0].appendChild(document.createElement(pluginDomElement));
    });

    if (mxResources) {
        mxResources.parse('OpenApiDocumentSchema=Open Api Document');
    }

    ui.actions.addAction('OpenApiDocumentSchema', function () {
        OpenApiDocumentSchemaDotNetContract.onMenuClick();
    });

    const openFromMenu = ui.menus.get('openFrom');
    const oldOpenFromMenuFunc = openFromMenu.funct;

    openFromMenu.funct = function (menu, parent) {
        oldOpenFromMenuFunc.apply(this, arguments);
        ui.menus.addMenuItems(menu, ['OpenApiDocumentSchema'], parent);
    };

    const insertMenu = ui.menus.get('insert');
    const oldInsertMenu = insertMenu.funct;

    insertMenu.funct = function (menu, parent) {
        oldInsertMenu.apply(this, arguments);
        ui.menus.addMenuItems(menu, ['OpenApiDocumentSchema'], parent);
    };
});