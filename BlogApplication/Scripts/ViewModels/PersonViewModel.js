PersonViewModel = function (self) {
    
}

createPersonViewModel = function (data) {
    var options = {
        extend: {
            "{root}": PersonViewModel
        }
    };
    return ko.viewmodel.fromModel(data, options);
};