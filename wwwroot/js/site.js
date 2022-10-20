// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.





using System.Text.Json


var url = "https://api.themoviedb.org/3/movie/popular?api_key=7e925b5abdc74a44a98a5d9bee65e2ea&language=en-US&page=1"
var api;
    fetch(url)
        .then(response => response.json())
        .then(data => {
            console.log(data)
        })
        .catch(error => console.error('Unable to get items.', error));

for(var obj in api.results){
    console.log(obj.original_title)


}

