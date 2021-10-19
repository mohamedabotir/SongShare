var gig = function (attendanceService) {
    var button;
    var attend = function (gigs) {
        $(gigs).on("click", ".js-toggle-attendance", toggleAttendance);
    };
    var toggleAttendance = function (e) {
        button = $(e.target);
        var gigId = button.attr("data-gig-id");
        if (button.hasClass("btn-default")) {
            attendanceService.attendance(gigId, done, fail);
        } else {
            attendanceService.deleteAttendance(gigId, done, fail);
        }
    };

    var done = function () {
        var text = (button.text() == "Going") ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };
    var fail = function () {
        alert("Something Gone Wrong");
    };
    return {
        attendGig: attend
    }

}(AttendanceService);
