var OpenApiDocumentSchemaDotNetContract = (function () {
    return {
        setDotNetReference: function (dotnetContractReference) {
            this.dotnetContractReference = dotnetContractReference;
        },

        onMenuClick: function () {
            this.dotnetContractReference.invokeMethodAsync('OnMenuClick');
        },

        onLoadFile: function (content) {
            this.dotnetContractReference.invokeMethodAsync('OnLoadFile', content);
        }
    };
}());