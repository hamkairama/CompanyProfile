function ContactActionSentEmail() {
    var fullPath = $("#fileUpload").val();
    var jsonMail = GetMailMessage();

    rs = $.xResponseJson(fullOrigin + 'Contact/SendEmail/', JSON.stringify({ customMail: jsonMail, attachment: fullPath }));
    alert(MessageText());
}

function GetMailMessage() {
    var txtName =  $("#txtEmailName").val();
    var txtFrom = "admin@professionalis.me";
    var txtTo = "admin@professionalis.me";
    var txtCC = $("#txtEmailUser").val();
    var txtSubject = "[professionalis.me] Customer Service - " + txtName;
    var txtBody = $("#txtMessage").val();

    var jsonMail = {
        From: [txtFrom],
        To: [txtTo],
        CC: [txtCC],
        Subject: txtSubject,
        IsBodyHtml: true,
        Body: txtBody,
    };

    return jsonMail;
}