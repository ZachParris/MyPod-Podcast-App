var app = angular.module("MyPod", ['ngRoute']);

app.controller("searchCtrl", function (searchService) {
    var vm = this;
    const parser = new DOMParser();
    vm.searchResults = [];

    vm.search = function () {
        searchService.searchItunes(vm.searchInput).then(function (response) {
            vm.searchResults = response.data.results;
        }, function (error) {
            debugger
        })
    }
    vm.getPodcastFeed = function (url) {
        searchService.searchResult(url).then(function (response) {
            const xml = parser.parseFromString(response.data, "text/xml");
            const enclosures = xml.querySelectorAll("enclosure");
            vm.episodes = [];
            for (let item of enclosures.entries()) {
                debugger
                vm.episodes.push({
                    url: item[1].attributes[0].nodeValue
                })
            }
        }, function (error) {
            debugger
        })
    }
})

app.service("searchService", function ($http) {
    var searchItunes = function (searchTerm) {
        return $http.get("https://podcast-player-mypod.herokuapp.com/api/iTunes/search?entity=podcast&term=" + searchTerm);
    }
    var searchResult = function (url) {
        return $http.get("https://podcast-player-mypod.herokuapp.com/api/feed/?feedUrl=" + url);
    }
    return {
        searchResult: searchResult,
        searchItunes: searchItunes
    }
})



app.config(function($routeProvider) {
    $routeProvider.
    when('/podcasts', {
        templateUrl: 'Partials/podcasts.html',
    }).
    when('/search', {
        templateUrl: 'Partials/Search.html',
    }).
    when('/messages', {
        templateUrl : 'Partials/messages.html',
    }).
    otherwise('/');
});
