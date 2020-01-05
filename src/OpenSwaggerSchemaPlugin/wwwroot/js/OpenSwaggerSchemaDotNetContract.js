var OpenSwaggerSchemaDotNetContract = (function () {
    return {
        setDotNetReference: function (dotnetContractReference) {
            this.dotnetContractReference = dotnetContractReference;
        },

        onMenuClick: function () {
            this.dotnetContractReference.invokeMethodAsync('HandleMenuActionOpenSwaggerSchema');
        }
    };
}());