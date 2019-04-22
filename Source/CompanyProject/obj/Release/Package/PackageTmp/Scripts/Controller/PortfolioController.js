function PortfolioActionCreate() {
    var txtPortfolioName = $("#txtPortfolioName").val();
    var txtDesc = $("#txtDesc").val();
    var txtStart = $("#txtStart").val();
    var txtEnd = $("#txtEnd").val();
    var txtClient = $("#txtClient").val();
    var txtCategory = $("#txtCategory").val();
    var txtClassProp = $("#txtClassProp").val();
    var txtImage = EraseAttImg($('#txtImage').attr('src'));

    var jsonTeam = {
        portfolio_nm: txtPortfolioName,
        portfolio_desc: txtDesc,
        portfolio_start: txtStart,
        portfolio_end: txtEnd,
        portfolio_client: txtClient,
        portfolio_category: txtCategory,
        class_prop: txtClassProp,
        img: txtImage,
    };

    rs = $.xResponseJson(fullOrigin + 'Portfolio/ActionCreate/',
          JSON.stringify({ portfolio: jsonTeam }));

    if (IsSuccess()) {
        CleanInputText();
        ModalCreate('Portfolio/Index/', '#modalDialog');
    } else {
        ModalCreate('Portfolio/Create/', '#modalDialog');
    }
}


function PortfolioActionEdit() {
    var txtId = $("#txtId").val();
    var txtPortfolioName = $("#txtPortfolioName").val();
    var txtDesc = $("#txtDesc").val();
    var txtStart = $("#txtStart").val();
    var txtEnd = $("#txtEnd").val();
    var txtClient = $("#txtClient").val();
    var txtCategory = $("#txtCategory").val();
    var txtClassProp = $("#txtClassProp").val();
    var txtImage = EraseAttImg($('#txtImage').attr('src'));
    var txtCreatedBy = $("#txtCreatedBy").val();
    var txtCreatedDt = $("#txtCreatedDt").val();

    var jsonTeam = {
        id: txtId,
        portfolio_nm: txtPortfolioName,
        portfolio_desc: txtDesc,
        portfolio_start: txtStart,
        portfolio_end: txtEnd,
        portfolio_client: txtClient,
        portfolio_category: txtCategory,
        class_prop: txtClassProp,
        img: txtImage,
        created_by: txtCreatedBy,
        created_dt: txtCreatedDt
    };

    rs = $.xResponseJson(fullOrigin + 'Portfolio/ActionEdit/',
          JSON.stringify({ portfolio: jsonTeam }));

    if (IsSuccess()) {
        CleanInputText();
        CleanImage();
        ModalCreate('Portfolio/Index/', '#modalDialog');
    } else {
        ModalCreate('Portfolio/Edit/', '#modalDialog');
    }
}

function PortfolioActionDelete() {
    var txtId = $("#txtId").val();

    rs = $.xResponse(fullOrigin + 'Portfolio/ActionDelete/', { id: txtId });

    if (IsSuccess()) {
        CleanInputText();
        ModalCreate('Portfolio/Index/', '#modalDialog');
    } else {
        ModalCreate('Portfolio/Delete/', '#modalDialog');
    }
}

function CleanImage() {
    document.getElementById("txtImage").src = "";
}