$(document).ready(function(e) {
	
	$('input.money').live('keypress, keyup', function(event) {
		// skip for arrow keys
		if(event.which >= 37 && event.which <= 40){
			event.preventDefault();
		}
		$(this).val( $(this).val().replace(/[^0-9]/g,'') );
		var num = $(this).val().replace(/,/g, '');
		$(this).attr('price', num);
		$(this).val(num.replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
	});
	
	var delay = 300;
	//$('[rel="tooltip"]').tooltip({delay:delay});
	$('[rel="tooltip"][placement="top"]').tooltip({delay:delay, placement:'top'});
	$('[rel="tooltip"][placement="right"]').tooltip({delay:delay, placement:'right'});
	$('[rel="tooltip"][placement="bottom"]').tooltip({delay:delay, placement:'bottom'});
	$('[rel="tooltip"][placement="left"]').tooltip({delay:delay, placement:'left'});
	
	// hide #back-top first
	$("#back-top").hide();
	
	// fade in #back-top
	$(function () {
		$(window).scroll(function () {
			if ($(this).scrollTop() > 100) {
				$('#back-top').fadeIn();
			} else {
				$('#back-top').fadeOut();
			}
		});

		// scroll body to 0px on click
		$('#back-top a').click(function () {
			$('body,html').animate({
				scrollTop: 0
			}, 800);
			return false;
		});
	});
	
	$('#account-box').mouseenter(function(e) {
		$('#account-content-menu').show();
	});
	
	$('#account-box').mouseleave(function(e) {
		$('#account-content-menu').hide();
	});
	
	$('.persian-date').datepicker({ dateFormat: 'yy/mm/dd' });
	
	
	$('#toggle-search').click(function(e) {
		
		$('#advanced-search-section').toggle();
		$('#quick-search-section').toggle();
		
		var icon = $('#toggle-search > i');
		if (icon.hasClass('icon-plus-sign')) {
			icon.removeClass('icon-plus-sign');
			icon.addClass('icon-minus-sign');
			$(this).attr('mode', 'advanced');
		}
		else {
			icon.removeClass('icon-minus-sign');
			icon.addClass('icon-plus-sign');
			$(this).attr('mode', 'quick');
		}
	});
	
});

$(window).resize(function(){
		
	$('.modal').position({my: "center",at: "center",of: window});
});