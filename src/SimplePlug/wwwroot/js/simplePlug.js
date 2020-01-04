var SimplePlugJs = (function () {
    return {

        init: function (ui) {
            this.ui = ui;
        },

        openFile: function (instance, callbackMethod, requestId) {

            var input = document.createElement('input');
            input.setAttribute('type', 'file');

            mxEvent.addListener(input, 'change', mxUtils.bind(this, function () {
                if (input.files !== null) {

                    var reader = new FileReader();
                    reader.onload = function (evt) {
                        console.log('run here!!!');
                        instance.invokeMethodAsync(callbackMethod, requestId, evt.target.result);
                    };

                    reader.readAsText(input.files[0], "UTF-8");
                }
            }));

            input.click();
        },

        log: function (content) {
            console.log(content);
        }
    };
}());