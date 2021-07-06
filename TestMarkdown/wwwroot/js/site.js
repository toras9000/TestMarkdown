// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function throttle(time, handler)
{
    debounceTime = 1000;
    debounceId = null

    return function ()
    {
        if (debounceId)
        {
            clearTimeout(debounceId);
        }
        debounceId = setTimeout(function ()
        {
            debounceId = null;
            handler();
        }, debounceTime);
    };
}