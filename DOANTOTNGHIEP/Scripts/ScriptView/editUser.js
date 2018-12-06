$(document).ready(function () {
    //Đăng tin
    $('#suauser').click(function () {
        var txtUser = $("#txtUser").val();
        var txtPass = $("#txtPass").val();
        var level = $("input[name='rdoLevel']:checked").val();
        var userid = $("#userid").val();


        $.ajax({
            type: 'POST',
            url: "/Admin_edituser/PostEditUser/",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({
                txtUser: txtUser,
                txtPass: txtPass,
                level: level,
                userid: userid,
            })
        }).success(function (response) {
            if (response.result == true) {
                alert("Sửa Thành Công!");
                window.location.href = '/ListUser/ListUser';
            }

            else {
                alert("Sửa Thất bại");
            }
        }).error(function () {
            alert("Lỗi serve!");

        });


    });

    $('#xoauser').click(function () {
        var userid = $("#userid").val();


        $.ajax({
            type: 'POST',
            url: "/Admin_edituser/Xoa/",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({
                userid: userid,
            })
        }).success(function (response) {
            if (response.result == true) {
                alert("Xóa Thành Công!");
                window.location.href = '/ListUser/ListUser';
            }

            else {
                alert("Xóa Thất bại");
            }
        }).error(function () {
            alert("Lỗi serve!");

        });


    });

});
