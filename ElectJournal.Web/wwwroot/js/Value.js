(function () {
    document.addEventListener('DOMContentLoaded', function () {
        var selectgr = document.getElementById("selectgr"),
            select = document.querySelector(".form-select"),
            teacher = document.getElementById("flexRadioDefault1");

        teacher.addEventListener("click", function () {
            if (teacher.checked) {
                $('#inputGroupSelect01').prop('selectedIndex', 0);
            }
        })();
    })();
})();