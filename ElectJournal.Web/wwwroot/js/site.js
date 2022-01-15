// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function () {
	document.addEventListener('DOMContentLoaded', function () {
		$('#header').prepend('<div id="menu-icon"><span class="first"></span><span class="second"></span><span class="third"></span></div>');

		$("#menu-icon").on("click", function () {
			$("nav").slideToggle();
			$(this).toggleClass("active");
		});
	})();
})();

