var vm = new Vue({
    el: '#Vue',
    data: {
        locations: []
    },
    methods: {
        getData: function () {
            var stringToSearchFor = document.getElementById("searchString").value;
            if (stringToSearchFor === "") {
                alert("You have to search for a place first!");
            } else {
                fetch('api/Api/' + stringToSearchFor).then(function (response) {
                        if (response.status !== 200) {
                            vm.Locations = [];
                            return;
                        }
                        response.json().then(function (list) {
                            vm.locations = list;
                        });
                    })
                    .catch(function () {
                        alert('Could not fetch');
                    });
            }
        }
    }
});