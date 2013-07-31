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
        var IMAGE_WIDTH = 100;
        var IMAGE_HEIGHT = 100;
        var IMAGE_MODE = 'max';

        var $uploadImageInput = $('#upload-image-input');
        var $uploadImageButton = $('#upload-image-button');
        var $uploadImageInfo = $('#upload-image-info');
        var $allImages = $('#all-images');
        var $currentImage = $('#current-image');

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
                var imageUrl = data.result;
                $uploadImageButton.unbind();
                var $image = $('<img />');
                $image.prop('src', imageUrl);
                $currentImage.empty();
                $currentImage.append($image);
                var $thumbnailImage = $('<img />');
                $thumbnailImage.prop('src', imageUrl + '?width=' + IMAGE_WIDTH + '&height=' + IMAGE_HEIGHT + '&mode=' + IMAGE_MODE);
                $allImages.append($thumbnailImage);
                $uploadImageInfo.text('Upload finished.');
            }
        });
    });
}));