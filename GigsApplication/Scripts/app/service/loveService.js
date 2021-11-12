var LoveService = function () {
    var love = function (audioId, done, fail) {
        $.post("/api/love", { id: audioId}).done(done).fail(fail);
    };
    var deleteLove = function (audioId, done, fail) {
        $.ajax({
            url: "/api/love/" + audioId,
            method: "DELETE"
        }).done(done).fail(fail);
    };
    return {
        love: love,
        deleteLove: deleteLove
    }
}();