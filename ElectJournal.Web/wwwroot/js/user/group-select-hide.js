(function () {
    document.addEventListener('DOMContentLoaded', function () {
        var selectgr = document.getElementById("selectgr"),
            student = document.getElementById("flexRadioDefault2"),
            teacher = document.getElementById("flexRadioDefault1");
        
        teacher.addEventListener("click", function () {
            selectgr.style.visibility = "hidden";
        })();
    })();
})();