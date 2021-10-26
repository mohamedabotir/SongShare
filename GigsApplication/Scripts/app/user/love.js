var loveAudio = function (loveService) {
    var button;
    var click = function () {
        $(".js-toggle-love").click(Love);
    }
    var Love = function (e) {
        button = $(e.target);
        var audioId = button.attr("data-audio-id");
        console.log(audioId + "id")
        if (button.hasClass("heart"))
            loveService.love(audioId, done, fail)
        else
            loveService.deleteLove(audioId, done, fail)
    }
    var done = function () {
        if (button.hasClass("single-heart-active"))
            button.toggleClass("single-heart-active").toggleClass("heart");
        else
        button.toggleClass("heart-blast");
        console.log("success love")
    }
    var fail = function () {
        alert('Something gone wrong')
    }
    return {
        loveClick: click
    }

}(LoveService);