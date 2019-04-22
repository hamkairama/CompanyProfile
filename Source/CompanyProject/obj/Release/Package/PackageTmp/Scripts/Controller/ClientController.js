function ClientActionCreate() {
    var txtClientName = $("#txtClientName").val();
    var txtStart = $("#txtStart").val();
    var txtEnd = $("#txtEnd").val();
    var txtAddress = $("#txtAddress").val();
    var txtDesc = $("#txtDesc").val();
    var txtClassProp = $("#txtClassProp").val();
    var txtImage = EraseAttImg($('#txtImage').attr('src'));

    var jsonTeam = {
        client_nm: txtClientName,
        join_start: txtStart,
        join_end: txtEnd,
        client_address: txtAddress,
        client_desc: txtDesc,
        class_prop: txtClassProp,
        img: txtImage,
    };

    rs = $.xResponseJson(fullOrigin + 'Client/ActionCreate/',
          JSON.stringify({ client: jsonTeam }));

    if (IsSuccess()) {
        CleanInputText();
        ModalCreate('Client/Index/', '#modalDialog');
    } else {
        ModalCreate('Client/Create/', '#modalDialog');
    }
}


function ClientActionEdit() {
    var txtId = $("#txtId").val();
    var txtClientName = $("#txtClientName").val();
    var txtStart = $("#txtStart").val();
    var txtEnd = $("#txtEnd").val();
    var txtAddress = $("#txtAddress").val();
    var txtDesc = $("#txtDesc").val();
    var txtClassProp = $("#txtClassProp").val();
    var txtImage = EraseAttImg($('#txtImage').attr('src'));
    var txtCreatedBy = $("#txtCreatedBy").val();
    var txtCreatedDt = $("#txtCreatedDt").val();

    var jsonTeam = {
        id: txtId,
        client_nm: txtClientName,
        join_start: txtStart,
        join_end: txtEnd,
        client_address: txtAddress,
        client_desc: txtDesc,
        class_prop: txtClassProp,
        img: txtImage,
        created_by: txtCreatedBy,
        created_dt: txtCreatedDt
    };

    rs = $.xResponseJson(fullOrigin + 'Client/ActionEdit/',
          JSON.stringify({ about: jsonTeam }));

    if (IsSuccess()) {
        CleanInputText();
        CleanImage();
        ModalCreate('Client/Index/', '#modalDialog');
    } else {
        ModalCreate('Client/Edit/', '#modalDialog');
    }
}

function ClientActionDelete() {
    var txtId = $("#txtId").val();

    rs = $.xResponse(fullOrigin + 'Client/ActionDelete/', { id: txtId });

    if (IsSuccess()) {
        CleanInputText();
        ModalCreate('Client/Index/', '#modalDialog');
    } else {
        ModalCreate('Client/Delete/', '#modalDialog');
    }
}

function CleanImage() {
    document.getElementById("txtImage").src = "";
}