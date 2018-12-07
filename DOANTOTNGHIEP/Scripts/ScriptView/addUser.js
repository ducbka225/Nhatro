$(document).ready(function () {
    //Đăng tin
    $('#themuser').click(function () {
        var txtUser = $("#txtUser").val();
        var txtEmail = $("#txtEmail").val();
        var txtPass = $("#txtPass").val();
        var level = $("input[name='rdoLevel']:checked").val();


        if (txtUser.length == 0) {
            alert('Vui long nhập Tên');
        }

        else if (txtEmail.length == 0) {
            alert('Vui long nhập Email');
        }

        else if (txtPass.length == 0) {
            alert('Vui long nhập mật khẩu');
        }
        else {
            $.ajax({
                type: 'POST',
                url: "/Admin_addUser/ThemUser/",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({
                    txtUser: txtUser,
                    txtEmail: txtEmail,
                    txtPass: txtPass,
                    level: level,
                })
            }).success(function (response) {
                if (response.result == true) {
                    alert("Thêm Thành Công!");
                    window.location.href = '/ListUser/ListUser';
                }

                else {
                    alert("Email Đã tồn tại!");
                }
            }).error(function () {
                alert("Lỗi serve!");

            });
        }

    });
});
