$(document).ready(function () {

    // get district by province
    $('#province').on('change', function () {
        var provinceid = $(this).val();
        $('#district').html('<option value>Loading...</option>');
        $('#district').attr('disabled', 'true');
        $.ajax({
            url: '/DangTin/GetDistrict/',
            type: 'GET',
            data: { provinceid: provinceid },
            success: function (response) {
                $('#district').removeAttr('disabled');
                $('#district').html('<option value>Chọn</option>');
                $.each(response, function (i, item) {
                    $('#district').append('<option value="' + item.Id + '">' + item.Name + '</option>');
                });
            },
            error: function (x, t, m) {
                $('#province').val('');
                $('#district').html('<option value> Chon Tinh truoc  </option>');
            },
        });
    });

    // get street by district
    $('#district').on('change', function () {
        var districid = $(this).val();
        $('#street_id').html('<option value>Loading...</option>');
        $('#street_id').attr('disabled', 'true');
        $.ajax({
            url: '/DangTin/GetStreet/',
            type: 'GET',
            data: { districtId: districid },
            success: function (response) {
                $('#street_id').removeAttr('disabled');
                $('#street_id').html('<option value>Chọn</option>');
                $.each(response, function (i, item) {
                    $('#street_id').append('<option value="' + item.Id + '">' + item.Name + '</option>');
                });
            },
            error: function (x, t, m) {
                $('#district').val('');
                $('#street_id').html('<option value> Chọn quận/huyện trước  </option>');
            },
        });
    });

    // get street by district
    $('#district').on('change', function () {
        var districtId = $(this).val();
        $('#street').html('<option value>Loading...</option>');
        $('#street').attr('disabled', 'true');
        $.ajax({
            url: '/DangTin/GetStreet/',
            type: 'GET',
            data: { districtId: districtId },
            success: function (response) {
                $('#street').removeAttr('disabled');
                $('#street').html('<option value>Chọn</option>');
                $.each(response, function (i, item) {
                    $('#street').append('<option value="' + item.Id + '">' + item.Name + '</option>');
                });
            },
            error: function (x, t, m) {
                $('#district').val('');
                $('#street').html('<option value> Chọn quận/huyện trước  </option>');
            },
        });
    });

    //Đăng tin
    $('#dangtin').click(function () {
        var type = $("#typeproduct").val();
        var title = $("#title").val();
        var phone = $("#phone").val();
        var price = $("#price").val();
        var acreage = $("#acreage").val();
        var province = $('#province').val();
        var district = $('#district').val();
        var street = $('#street').val();
        var addressDetails = $('#location').val();
        var floor = $('#floor').val();
        var wc = $('#wc').val();
        var numberPeople = $('#peoplenum').val();
        var priceElectric = $('#priceelectric').val();
        var priceWater = $('#pricewater').val();
        var description = $('#description').val();
        var owner = $("#owner").val();
        var islevel = $("#islevel").val();


        if (title.length == 0) {
            alert('Vui long nhập tiêu đề');
        }

        else if (phone.length == 0) {
            alert('Vui long nhập Số điện thoại');
        }

        else if (price.length == 0) {
            alert('Vui long nhập giá');
        }

        else if (addressDetails.length == 0) {
            alert('Vui long nhập Địa chỉ');
        }

        else {
            $.ajax({
                type: 'POST',
                url: "/Admin_addProduct/DangTin/",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({
                    type: type,
                    title: title,
                    phone: phone,
                    price: price,
                    acreage: acreage,
                    province: province,
                    district: district,
                    street: street,
                    addressDetails: addressDetails,
                    floor: floor,
                    wc: wc,
                    numberPeople: numberPeople,
                    priceElectric: priceElectric,
                    priceWater: priceWater,
                    description: description,
                    owner: owner,
                    islevel: islevel,

                })
            }).success(function (response) {
                if (response.result == true) {
                    alert("Thêm Thành Công!")
                    //window.location.href = '/ThanhToan/ThanhToan'
                }

                else {
                    alert("Không thể thêm");
                }
            }).error(function () {
                alert("Lỗi serve!");

            });
        }

    });

    //
    //$("#fileButton").click(function () {
    //    var files = $("#fileInput").get(0).files;
    //    var fileData = new FormData();

    //    for (var i = 0; i < files.length; i++) {
    //        fileData.append("fileInput", files[i]);
    //    }

    //    $.ajax({
    //        type: "POST",
    //        url: "/DangTin/UploadFiles",
    //        dataType: "json",
    //        contentType: false, // Not to set any content header
    //        processData: false, // Not to process data
    //        data: fileData,
    //        success: function (result, status, xhr) {
    //            alert(result);
    //        },
    //        error: function (xhr, status, error) {
    //            alert(status);
    //        }
    //    });
    //});

});
