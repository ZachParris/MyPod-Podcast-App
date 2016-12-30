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
                var siblings = item[1].parentElement.childNodes;
                for (let key in siblings){
                    if (siblings[key].nodeName === "title") {
                        vm.episodes.push({
                            url: item[1].attributes.url.nodeValue,
                            title: siblings[key].textContent
                        })
                    }
                    }
            }
        }, function (error) {
            debugger
        })
    }

    vm.followPodcastChannel = function (url) {
        searchService.subscription = function (userChoice) {
            vm.subscriptions = [];

        }
    }

})

app.service("searchService", function ($http) {
    var searchItunes = function (searchTerm) {
        return $http.get("https://podcast-player-mypod.herokuapp.com/api/iTunes/search?entity=podcast&term=" + searchTerm);
    }
    var searchResult = function (url) {
        return $http.get("https://podcast-player-mypod.herokuapp.com/api/feed/?feedUrl=" + url);
    }
    var subscription = function (channel) {
        return $http.get("https://podcast-player-mypod.herokuapp.com/api/iTunes/search?entity=podcast&term=" + channel)
    }
    return {
        subscription: subscription,
        searchResult: searchResult,
        searchItunes: searchItunes
    }
})

app.controller("blogCtrl", function (blogService) {
    var vm = this;
    vm.blogPosts = [];

    vm.addNewPost = function () {
        blogService.addPost(vm.blogInput).then(function (post) {
           vm.getAllBlogPosts();
        })
    }
    vm.getAllBlogPosts = function () {
        blogService.getAllPosts().then(function (response) {
            vm.blogPosts = response.data
        })
    }
    vm.removePost = function () {
        blogService.removeBlogPost().then(function (post) {
            vm.blogPosts.remove(post)
        })
    }
})

app.service("blogService", function ($http) {
    var addPost = function (blogText) {
        return $http.post("api/blog", blogText);
    }
    var getAllPosts = function () {
        return $http.get("api/Blog");
    }
    var removeBlogPost = function () {
        return $http.get("api/Blog");
    }
    return {
        addPost: addPost,
        getAllPosts: getAllPosts,
        removeBlogPost: removeBlogPost
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
     when('/blog', {
        templateUrl: 'Partials/blog.html',
     }).
     when('/', {
         templateUrl: 'Partials/home.html',
     }).
    otherwise('/');
});
