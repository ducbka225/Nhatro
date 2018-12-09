$(document).ready(function () {
    //Đăng tin
    $('#suatin').click(function () {
       
        var title = $("#title").val();
        var price = $("#price").val();
        var acreage = $("#acreage").val();
        var islevel = $("#islevel").val();
        var productid = $("#productid").val();

        $.ajax({
            type: 'POST',
            url: "/Admin_editProduct/PostEditProduct/",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({
                Title: title,
                Price: price,
                Acreage: acreage,             
                Islevel: islevel,
                Id: productid
            })
        }).success(function (response) {
            if (response.result == true) {
                alert("Sửa Thành Công!");
                window.location.href = '/Admin_listProduct/listProduct';
            }

            else {
                alert("Sửa Thất bại");
            }
        }).error(function () {
            alert("Lỗi serve!");

        });


    });

    $('#xoa').click(function () {
        var productid = $("#productid").val();


        $.ajax({
            type: 'POST',
            url: "/Admin_editProduct/Xoa/",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({
                productid: productid,
            })
        }).success(function (response) {
            if (response.result == true) {
                alert("Xóa Thành Công!");
                window.location.href = '/Admin_listProduct/listProduct';
            }

            else {
                alert("Xóa Thất bại");
            }
        }).error(function () {
            alert("Lỗi serve!");

        });
    });

});