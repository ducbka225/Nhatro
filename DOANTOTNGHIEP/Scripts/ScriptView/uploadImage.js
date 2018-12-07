$("#fileButton").click(function () {
    var files = $("#fileInput").get(0).files;
    var fileData = new FormData();

    for (var i = 0; i < files.length; i++) {
        fileData.append("fileInput", files[i]);
    }

    $.ajax({
        type: "POST",
        url: "/ListImage/UploadFiles",
        dataType: "json",
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: fileData,
        success: function (result, status, xhr) {
            alert(result);
            window.location.reload();
        },
        error: function (xhr, status, error) {
            alert(status);
        }
    });
});

// xóa ảnh
$("#deleteimage").click(function () {
    var Link = $("input[name='linkimage']:checked").val();
    $.ajax({
        type: 'POST',
        url: "/ListImage/Xoa/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            Link: Link,
        })
    }).success(function (response) {
        if (response.result == true) {
            alert("Xóa Thành Công!");
            window.location.reload();
        }

        else {
            alert("Xóa Thất bại");
        }
    }).error(function () {
        alert("Lỗi serve!");

    });
});

// set ảnh đại diện
$("#setimage").click(function () {
    var Link = $("input[name='linkimage']:checked").val();
    $.ajax({
        type: 'POST',
        url: "/ListImage/SetImage/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            Link: Link,
        })
    }).success(function (response) {
        if (response.result == true) {
            alert("Đặt ảnh đại diện Thành Công!");
            window.location.reload();
        }

        else {
            alert("Set Thất bại");
        }
    }).error(function () {
        alert("Lỗi serve!");

    });
});