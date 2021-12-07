var Comment = function (commentService) {
    var message;
    var name;
    var click = function () {
        $(".js-toggle-comment").click(comment);
    }
    var comment =  function (e) {
        button = $(e.target);
        var audioId = button.attr("data-audio-id");
        name = button.attr("data-user-name");
        message = $(".comment-data").val();

        commentService.Postcomment(audioId, message,done,fail);
    }
    var done = function () {
        $(".comment-data").val('');
        var comment = `<div class="comment"><span id="commented-user">${name}</span><p>${message}</p></div>`
        $(".comments-container").append(comment);
    }
    var fail = function () {
        alert("some thing gone Wrong!");
    }
    return {
    clickComment:click
    }

}(CommentService);