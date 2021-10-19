var AttendanceService = function () {
    var attendance = function (gigid, done, fail) {
        $.post("/api/attendances", { gigId: gigid })
            .done(done).fail(fail);
    };
    var deleteAttendance = function (gigid, done, fail) {
        $.ajax({
            url: "/api/attendances/" + gigid,
            method: "DELETE"
        }).done(done).
            fail(fail);
    };
    return {
        attendance: attendance,
        deleteAttendance: deleteAttendance
    };

}();