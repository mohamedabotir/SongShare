var followArtist = function (followService) {
    var button;
    var f = function () {
        $(".js-toggle-follow").click(followToggle);
    };
    var followToggle = function (e) {
        button = $(e.target);
        var userId = button.attr("data-user-id");
        if (button.hasClass("btn-default"))
            followService.follow(userId, done, fail);
        else
            followService.deleteFollow(userId, done, fail);
    };
    var done = function () {
        var text = (button.text() == "follow") ? "Following" : "follow";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };
    var fail = function () {
        alert("Something Gone Wrong");
    };
    return {
        follow: f
    };
}(FollowService);