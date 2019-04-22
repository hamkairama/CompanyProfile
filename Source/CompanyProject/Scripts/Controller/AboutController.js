function AboutActionCreate() {
    var txtProjectName = $("#txtProjectName").val();
    var txtDesc = $("#txtDesc").val();
    var txtStart = $("#txtStart").val();
    var txtEnd = $("#txtEnd").val();
    var txtClassProp = $("#txtClassProp").val();
    var txtImage = EraseAttImg($('#txtImage').attr('src'));

    var jsonTeam = {
        project_nm: txtProjectName,
        project_desc: txtDesc,
        project_start: txtStart,
        project_end: txtEnd,
        class_prop: txtClassProp,
        img: txtImage,
    };

    rs = $.xResponseJson(fullOrigin + 'About/ActionCreate/',
          JSON.stringify({ about: jsonTeam }));

    if (IsSuccess()) {
        CleanInputText();
        ModalCreate('About/Index/', '#modalDialog');
    } else {
        ModalCreate('About/Create/', '#modalDialog');
    }
}


function AboutActionEdit() {
    var txtId = $("#txtId").val();
    var txtProjectName = $("#txtProjectName").val();
    var txtDesc = $("#txtDesc").val();
    var txtStart = $("#txtStart").val();
    var txtEnd = $("#txtEnd").val();
    var txtClassProp = $("#txtClassProp").val();
    var txtImage = EraseAttImg($('#txtImage').attr('src'));
    var txtCreatedBy = $("#txtCreatedBy").val();
    var txtCreatedDt = $("#txtCreatedDt").val();

    var jsonTeam = {
        id: txtId,
        project_nm: txtProjectName,
        project_desc: txtDesc,
        project_start: txtStart,
        project_end: txtEnd,
        class_prop: txtClassProp,
        img: txtImage,
        created_by: txtCreatedBy,
        created_dt: txtCreatedDt
    };

    rs = $.xResponseJson(fullOrigin + 'About/ActionEdit/',
          JSON.stringify({ about: jsonTeam }));

    if (IsSuccess()) {
        CleanInputText();
        CleanImage();
        ModalCreate('About/Index/', '#modalDialog');
    } else {
        ModalCreate('About/Edit/', '#modalDialog');
    }
}

function AboutActionDelete() {
    var txtId = $("#txtId").val();

    rs = $.xResponse(fullOrigin + 'About/ActionDelete/', { id: txtId });

    if (IsSuccess()) {
        CleanInputText();
        ModalCreate('About/Index/', '#modalDialog');
    } else {
        ModalCreate('About/Delete/', '#modalDialog');
    }
}

function CleanImage() {
    document.getElementById("txtImage").src = "";
}