var OpenSwaggerSchemaJsContract = (function () {
    return {

        setEditorUi: function (ui) {
            this.ui = ui;
        },

        openFile: function () {

            var input = document.createElement('input');
            input.setAttribute('type', 'file');

            mxEvent.addListener(input, 'change', mxUtils.bind(this, function () {
                if (input.files !== null) {

                    var reader = new FileReader();
                    reader.onload = function (evt) {
                        OpenSwaggerSchemaDotNetContract.onLoadFile(evt.target.result);
                    };

                    reader.readAsText(input.files[0], "UTF-8");
                }
            }));

            input.click();
        },

        log: function (content) {
            console.log(content);
        }

        loadXml: function (xmlContent) {
            let error = null;
            this.ui.editor.graph.model.beginUpdate();
            try {
                this.ui.editor.setGraphXml(mxUtils.parseXml(xmlContent).documentElement);
                this.ui.hideDialog();
            }
            catch (e) {
                error = e;
            }
            finally {
                this.ui.editor.graph.model.endUpdate();
            }

            if (error != null) {
                mxUtils.alert(error.message);
            }
        }
    };
}());