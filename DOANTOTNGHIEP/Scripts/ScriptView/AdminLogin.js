$(document).ready(function () {
    $('#login').click(function () {
        var email = $('#email').val();
        var password = $('#password').val();

        if (email.length == 0) {
            alert("Vui lòng nhập Email!");

        }

        if (password.length == 0) {
            alert("Vui lòng nhập PassWord!");
        }
        if (email.length != 0 && password.length != 0) {
            $.ajax({
                type: 'POST',
                url: "/LoginAdmin/PostLoginAdmin/",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({
                    email: $('#email').val(),
                    password: $('#password').val()
                })
            }).success(function (response) {
                if (response == true) {
                    window.location.href = '/Admin_DashBoard/DashBoard';
                }
                else {
                    alert("Email Hoặc PassWord Không Chính xác!");
                }
            }).error(function () {
                alert("Lỗi serve!");
                window.location.reload();
            });
        }
    });


});