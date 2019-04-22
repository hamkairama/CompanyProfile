function LoginActionLogin() {
    if (!IsValidForm()) {
        return false;
    }

    var txtUserId = $("#txtUserId").val();
    var txtPassword = $("#txtPassword").val();

    rs = $.xResponse(fullOrigin + 'Login/ActionLogin/', {
        userId: txtUserId,
        password: txtPassword,
    });

    if (IsSuccess()) {
        CleanInputText();
        Refresh();
    } else {
        var valid = document.getElementById("required_txtLoginValidation");
        valid.style.display = "";
        valid.style.color = "red";
        valid.textContent = "User id and password incorrect";
    }
}

function OnKeyPress(event) {
    if (event.which == 13 || event.keyCode == 13) {
        LoginActionLogin();
    }
}
