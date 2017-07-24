


//$("#sendEmail").click(function () {
//    swal({
//        title: 'Send',
//        text: "Are you sure to send",
//        type: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Yes, send',
//        cancelButtonText: 'Wait',
//        confirmButtonClass: 'btn btn-success',
//        cancelButtonClass: 'btn btn-danger',
//        buttonsStyling: false
//    }).then(function () {
//        setfeedback();

//        //swal(
//        //    'Deleted!',
//        //    'Your file has been deleted.',
//        //    'success'
//        //)

//    }, function (dismiss) {
//        // dismiss can be 'cancel', 'overlay',
//        // 'close', and 'timer'
//        if (dismiss === 'cancel') {
//            swal(
//                'Cancelled',
//                'Your imaginary file is safe :)',
//                'error'
//            )
//        }
//    })
//});

//function setfeedback() {
//    console.log($('#frmRequest').valid());
//    if ($('#frmRequest').valid()) {
//        $('#sendEmail').button('loading');
//        //var model = $('#frmRequest').serialize();
//        var model = new FormData($('#frmRequest')[0]);
//        //model.append('Test', 'pojfpwoefpowepfohwepofhpowehpfowhepo'); //สามารถส่งข้อมูลเพิ่มได้ Syntax นี้ (กรณีใช้ FormData)
//        $.ajax({
//            type: "POST",
//            url: "@Url.Action("RequestProcess", "Requests")",
//            contentType: false,
//            processData: false,
//            dataType: false,
//            data: model,
//            success: function (response) {
//                if (response != null && response.success) {
//                    var link = '@Html.ActionLink("Click", "Index", "TicketDetail", new {ticket = "ssss"}, null)';
//                    link = link.replace("ssss", response.modelRequest.TicketId);

//                    swal("Ticket ของท่านคือ " + response.modelRequest.TicketId,
//                        //"สามารถตรวจสอบได้ที่ Email " + response.modelRequest.Email + "</br>" + "< a href= 'www.srmforcustomer.com\\search\\" + response.modelRequest.TicketId + "' > test</a > ",
//                        "สามารถตรวจสอบได้ที่ Email " + response.modelRequest.Email + "</br>" + link,
//                        "success");
//                } else {
//                    //console.log(response.errors);
//                    if (response.errors != null) {

//                        var errors = response.errors;
//                        for (var i = 0; i < errors.length; i++) {
//                            var error = errors[i];
//                            $('#' + error.Key).addClass('has-error');
//                        }
//                        swal("ไม่สำเร็จ", response.messageAlert, "error");
//                    } else {
//                        swal("ไม่สำเร็จ", response.messageAlert, "error");
//                    }

//                }
//            },
//            error: function (errMsg) {
//                //console.log(errMsg.responseText);
//                swal("ยกเลิก", "โปรป้อนข้อมูลให้ถูกต้อง", "error");
//            },
//            complete: function () {
//                $('#sendEmail').button('reset');
//                //$('#TelephoneNumber').val('');
//                //$('#CustomerName').val('');
//                //$('#Email').val('');
//                //$('#Remark').val('');
//                //$('#RequestTypeId').val('');
//                //$('#attachment').val('');
//                $('#frmRequest')[0].reset();

//            }
//        });
//    }
//}

//function FileValidate(ctrlFile, MaxSize) {//พารามิเตอร์ที่รับเข้ามาคือตัวคอนโทรลของการอัพโหลดไฟล์ที่ต้องการตรวจสอบ(ctrlFile) 
//    //และขนาดสูงสุดของไฟล์ที่ยอมให้อัพโหลดในแต่ละคอนโทรล(MaxSize)
//    var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png", ".pdf"];

//    ////ดึงค่าชื่อของไฟล์ที่อัพโหลดที่ต้องการตรวจสอบ
//    var sFileName = ctrlFile.value;

//    /////ตรวจสอบเมื่อพบชื่อไฟล์ที่ดึง
//    if (sFileName.length > 0) {
//        var blnValid = false;
//        //////////ตรวจสอบนามสกุลของไฟล์ที่ดึงมาจากชื่อไฟล์กับค่าของนามสกุลไฟล์ที่ยอมให้อัพโหลด
//        //จากตัวแปร _validFileExtensions
//        for (var j = 0; j < _validFileExtensions.length; j++) {
//            var sCurExtension = _validFileExtensions[j];
//            if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
//                blnValid = true;
//                break;
//            }
//        }
//        //////กรณีไฟล์ดังกล่าวมีนามสกุลที่แตกต่างจากที่กำหนดจะแสดงข้อความแจ้งเตือน 
//        และล้างค่าของชื่อไฟล์ในคอนโทรลอัพโหลดไฟล์ตัวดังกล่าว
//        if (!blnValid) {
//            alert("ไม่สามารถอัพโหลดไฟล์ดังกล่าวได้ เนื่องจากรองรับเฉพาะไฟล์ที่มีนามสกุลดังนี้เท่านั้น: " + _validFileExtensions.join(", "));
//            ctrlFile.value = "";
//            return false;
//        }
//        else {
//            /////หากไฟล์ที่อัพโหลดมีนามสกุลไฟล์ตามที่ระบุ จะทำการตรวจสอบขนาดของไฟล์ว่าไม่เกินจากขนาดสูงสุด
//            //ที่กำหนดหรือไม่ โดยมีการคำนวณหน่วยเป็น MB
//            var fileSize = parseFloat(ctrlFile.files[0].size / 1048576).toFixed(2);

//            /////หากขนาดของไฟล์เกินกว่าที่กำหนดจะแสดงข้อความแจ้งเตือน และล้างค่าไฟล์ที่ต้องการอัพโหลด
//            //ในคอนโทรลอัพโหลดไฟล์ดังกล่าว
//            if (fileSize > MaxSize) {
//                alert(" ขออภัย ขนาดของไฟล์ที่ต้องการอัพโหลดมีขนาดใหญ่เกินกว่าทีกำหนด(" + MaxSize + " MB)");
//                ctrlFile.value = "";
//                return false;
//            }
//        }
//    }
//    return true;
//}


