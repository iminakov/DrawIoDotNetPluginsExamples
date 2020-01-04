Draw.loadPlugin(function (ui) {
    const simplePlugLocation = 'http://localhost:6930/';
    const simplePlugDomElement = 'simplePlugApp';
    const simplePlugType = 'SimplePlug';

    document.getElementsByTagName("body")[0].appendChild(document.createElement(simplePlugDomElement));

    mxscript(simplePlugLocation + 'js/blazor.webassembly.js');
    mxscript(simplePlugLocation + 'js/simplePlug.js', function () {
        SimplePlugJs.init(ui);
    });

    mxResources.parse('fromCSharp=From C#');

    ui.actions.addAction('fromCSharp', function () {
        DotNet.invokeMethodAsync(simplePlugType, "HandleMenuActionFromCSharp");
    });

    var theMenu = ui.menus.get('insert');
    var oldMenu = theMenu.funct;

    theMenu.funct = function (menu, parent) {
        oldMenu.apply(this, arguments);
        ui.menus.addMenuItems(menu, ['fromCSharp'], parent);
    };
});	



/*var fileref = document.createElement('script');
fileref.setAttribute("type", "text/javascript");
fileref.setAttribute("src", 'http://localhost:6930/_framework/blazor.webassembly2.js');
document.getElementsByTagName("body")[0].appendChild(appTag);
document.getElementsByTagName("body")[0].appendChild(fileref);*/