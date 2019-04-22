function ServiceActionCreate() {
    var txtServiceName = $("#txtServiceName").val();
    var txtDescription = $("#txtDescription").val();
    var txtClassProp = $("#txtClassProp").val();
    var txtImage = EraseAttImg($('#txtImage').attr('src'));

    var jsonService = {
        service_nm: txtServiceName,
        service_desc: txtDescription,
        class_prop: txtClassProp,
        img: txtImage,
    };

    rs = $.xResponseJson(fullOrigin + 'Service/ActionCreate/',
          JSON.stringify({ service: jsonService }));

    if (IsSuccess()) {
        CleanInputText();
        ModalCreate('Service/Index/', '#modalDialog');
    } else {
        ModalCreate('Service/Create/', '#modalDialog');
    }
}


function ServiceActionEdit() {
    var txtId = $("#txtId").val();
    var txtServiceName = $("#txtServiceName").val();
    var txtDescription = $("#txtDescription").val();
    var txtClassProp = $("#txtClassProp").val();
    var txtImage = EraseAttImg($('#txtImage').attr('src'));
    var txtCreatedBy = $("#txtCreatedBy").val();
    var txtCreatedDt = $("#txtCreatedDt").val();

    var jsonService = {
        id: txtId,
        service_nm: txtServiceName,
        service_desc: txtDescription,
        class_prop: txtClassProp,
        img: txtImage,
        created_by: txtCreatedBy,
        created_dt: txtCreatedDt
    };

    rs = $.xResponseJson(fullOrigin + 'Service/ActionEdit/',
          JSON.stringify({ service: jsonService }));

    if (IsSuccess()) {
        CleanInputText();
        CleanImage();
        ModalCreate('Service/Index/', '#modalDialog');
    } else {
        ModalCreate('Service/Edit/', '#modalDialog');
    }
}

function ServiceActionDelete() {
    var txtId = $("#txtId").val();

    rs = $.xResponse(fullOrigin + 'Service/ActionDelete/', { id: txtId });

    if (IsSuccess()) {
        CleanInputText();
        ModalCreate('Service/Index/', '#modalDialog');
    } else {
        ModalCreate('Service/Delete/', '#modalDialog');
    }
}

function CleanImage() {
    document.getElementById("txtImage").src = "";
}