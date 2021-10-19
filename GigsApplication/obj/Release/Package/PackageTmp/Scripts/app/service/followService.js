var FollowService = function () {
    var following = function (followeeId,done,fail) {
        $.post("/api/followings", { followeeId: followeeId }).
            done(done)
            .fail(fail);
    };
    var deleteFollow = function (followeeId, done, fail) {
        $.ajax({
            url: "/api/followings/" + followeeId,
            method: 'DELETE'
        }).done(done)
            .fail(fail);
    };
    return {
        follow: following,
        deleteFollow: deleteFollow 
    }
}();