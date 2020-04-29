function uncheckElements() {
    var uncheck = document.getElementsByTagName('answer');
    for (var i = 0; i < uncheck.length; i++) {
        if (uncheck[i].type == 'checkbox' || uncheck[i].type == 'radio') {
            uncheck[i].checked = false;
        }
    }
}