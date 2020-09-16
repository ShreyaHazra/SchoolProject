
$('#submit_button').click(function(evt) {
      var begD = $.datepicker.parseDate('mm/dd/yy', $('#BeginDate').val());
      var endD = $.datepicker.parseDate('mm/dd'yy', $('#EndDate').val());
      if (begD > endD) {
            alert('Begin date must be before End date');
            $('#BeginDate').focus();
            return false;
      }
      ...
});
