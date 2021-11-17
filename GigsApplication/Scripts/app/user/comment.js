var Comment = function (commentService) {
    var click = function () {
        $(".js-toggle-comment").click(comment);
    }
    var comment = function (e) {
        button = $(e.target);
        var audioId = button.attr("data-audio-id");
        var message = $(".comment-data").val();
        commentService.Postcomment(audioId, message,done,fail);
    }
    var done = function () {

    }
    var fail = function () {

    }
    return {
    clickComment:click
    }

}(CommentService);