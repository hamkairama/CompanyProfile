function TeamActionCreate() {
    var txtName = $("#txtName").val();
    var txtBorn = $("#txtBorn").val();
    var txtAddress = $("#txtAddress").val();
    var txtPosition = $("#txtPosition").val();
    var txtDescription = $("#txtDescription").val();
    var txtImage = EraseAttImg($('#txtImage').attr('src'));

    var jsonTeam = {
        person_nm: txtName,
        person_born: txtBorn,
        person_address: txtAddress,
        person_position: txtPosition,
        person_desc: txtDescription,
        img: txtImage,
    };

    rs = $.xResponseJson(fullOrigin + 'Team/ActionCreate/',
          JSON.stringify({ team: jsonTeam }));

    if (IsSuccess()) {
        CleanInputText();
        ModalCreate('Team/Index/', '#modalDialog');
    } else {
        ModalCreate('Team/Create/', '#modalDialog');
    }
}


function TeamActionEdit() {
    var txtId = $("#txtId").val();
    var txtName = $("#txtName").val();
    var txtBorn = $("#txtBorn").val();
    var txtAddress = $("#txtAddress").val();
    var txtPosition = $("#txtPosition").val();
    var txtDescription = $("#txtDescription").val();
    var txtImage = EraseAttImg($('#txtImage').attr('src'));
    var txtCreatedBy = $("#txtCreatedBy").val();
    var txtCreatedDt = $("#txtCreatedDt").val();

    var jsonTeam = {
        id: txtId,
        person_nm: txtName,
        person_born: txtBorn,
        person_address: txtAddress,
        person_position: txtPosition,
        person_desc: txtDescription,
        img: txtImage,
        created_by: txtCreatedBy,
        created_dt: txtCreatedDt
    };

    rs = $.xResponseJson(fullOrigin + 'Team/ActionEdit/',
          JSON.stringify({ team: jsonTeam }));

    if (IsSuccess()) {
        CleanInputText();
        CleanImage();
        ModalCreate('Team/Index/', '#modalDialog');
    } else {
        ModalCreate('Team/Edit/', '#modalDialog');
    }
}

function TeamActionDelete() {
    var txtId = $("#txtId").val();

    rs = $.xResponse(fullOrigin + 'Team/ActionDelete/', { id: txtId });

    if (IsSuccess()) {
        CleanInputText();
        ModalCreate('Team/Index/', '#modalDialog');
    } else {
        ModalCreate('Team/Delete/', '#modalDialog');
    }
}

function CleanImage() {
    document.getElementById("txtImage").src = "";
}