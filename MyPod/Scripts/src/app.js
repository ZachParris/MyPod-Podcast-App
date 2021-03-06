﻿var app = angular.module("MyPod", ['ngRoute']);

app.controller("searchCtrl", function (searchService) {
    var vm = this;
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
            debugger
        }, function (error) {
            debugger
        })
    }
})

app.service("searchService", function ($http) {
    var searchItunes = function (searchTerm) {
        return $http.get("https://itunes.apple.com/search?entity=podcast&term=" + searchTerm);
    }
    var searchResult = function (url) {
        return $http.get(url);
    }
    return {
        searchResult: searchResult,
        searchItunes : searchItunes
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
