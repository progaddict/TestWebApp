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

        var addImage = function (imageUrl) {
            // main image
            var $image = $('<img />');
            $image.prop('src', imageUrl);
            $currentImage.empty();
            $currentImage.append($image);
            // thumbnail image
            var $thumbnailImage = $('<img />');
            $thumbnailImage.prop('src', imageUrl + '?width=' + IMAGE_WIDTH + '&height=' + IMAGE_HEIGHT + '&mode=' + IMAGE_MODE);
            $thumbnailImage.click(function () {
                $currentImage.empty();
                $currentImage.append($image);
            });
            $allImages.append($thumbnailImage);
        };

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
                // delete the upload handler
                $uploadImageButton.unbind();
                var imageUrl = data.result;
                addImage(imageUrl);
                // show user that the upload has finished
                $uploadImageInfo.text('Upload finished.');
            }
        });
    });
}));