"use strict";
(function (factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as anonymous module.
        define(['jquery'], factory);
    } else {
        // Browser globals.
        factory(jQuery);
    }
}(function ($) {
    $(function () {
        var $uploadImageInput = $('#upload-image-input');
        var $uploadImageButton = $('#upload-image-button');
        var $uploadImageInfo = $('#upload-image-info');
        $uploadImageInput.fileupload({
            dataType: 'json',
            add: function (e, data) {
                var fileName = data.files[0].name;
                $uploadImageInfo.text(fileName);
                $uploadImageButton.unbind();
                $uploadImageButton.click(function () {
                    $uploadImageInfo.text('Uploading...');
                    data.submit();
                });
            },
            done: function (e, data) {
                $uploadImageButton.unbind();
                $uploadImageInfo.text('Upload finished.');
            }
        });
    });
}));