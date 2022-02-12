(function () {
    document.addEventListener('DOMContentLoaded', function () {
        var selectgr = document.getElementById("selectgr"),
            student = document.getElementById("flexRadioDefault2"),
            teacher = document.getElementById("flexRadioDefault1");
        //admin = document.getElementById("flexRadioDefault3");

       
            student.addEventListener("click", function () {
            if (student.checked) {
                selectgr.style.visibility = "visible";
            } else if (student.checked == false) {
                selectgr.style.visibility = "hidden";
            }
        })();
        teacher.addEventListener("click", function () {
            //if (teacher.checked) {
                selectgr.style.visibility = "hidden";
            //} else {
            //    selectgr.style.visibility = "visible";
            //}
        })();
        //admin.addEventListener("click", function () {
        //    if (admin.checked) {
        //        selectgr.style.visibility = "hidden";
        //        selectgr.style.opacity = 0;
        //    }
        //})();
    })();
})();
