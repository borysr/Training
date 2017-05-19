'use strict';

eventsApp.controller('EventController', 
    function EventController($scope){
        $scope.snippet='<span style="color:red">Hi there</span>';
        $scope.event = {
            name: 'Angular Boot Camp',
            date: '1/1/2017',
            time: '10:30 am',
            location: {
                address: 'Google Headquarters',
                city: 'Mountain View',
                province: 'CA'
            },
            imageUrl: '/img/angularjs-logo.png',
            sessions : [
                {
                    name: 'Directives Mastercalss',
                    creatorName: 'Bob Smith',
                    duration: '1 hr',
                    level: 'Advanced',
                    abstract: 'I this session you will learn the ins and outs of directives',
                    upVoteCount: 0
                },
                {
                    name: 'Scopes for fun and profit',
                    creatorName: 'John Doe',
                    duration: '30 mins',
                    level: 'Intro',
                    abstract: 'This session will take a closer look at scopes. What they do, how they do it, and how to get them do it for you',
                    upVoteCount: 0
                },
                {
                    name: 'Well behaved controllers',
                    creatorName: 'Jane Doe',
                    duration: '2 hrs',
                    level: 'Intermidiate',
                    abstract: 'Controllers at the beginning of everything Angulat does. Learn how to craft controllers that will win respect of your friends and neighbors.',
                    upVoteCount: 0
                }
            ]
        }
        $scope.upVoteSession = function(session) {
            session.upVoteCount++;
        };

        $scope.downVoteSession = function(session) {
            session.upVoteCount--;
        };
    }
);