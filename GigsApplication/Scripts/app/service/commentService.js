var CommentService = function () {
    var comment = function (audioId, Message, done, fail) {
        $.post("/api/comment", { AudioId: audioId,comment:Message }).done().fail();
    }
    return {
        Postcomment: comment
    }
}();