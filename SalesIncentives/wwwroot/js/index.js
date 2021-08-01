
console.log("Entered");
$('input').on('keyup', function() {
    var i = $('input').val();
    console.log(typeof (i));
    $.ajax({
        type: "GET",
        url: "/Home/GetName",
        data: {'str': i },
        dataType: 'json',
        contentType:'application/json',
        success: function (data) {
            $('option').remove();
            console.log(data.s_r.length);
            for (var i = 0; i < data.s_r.length; i++) {
                console.log(data.s_r[i]);
                $('#suggestions').append(new Option(data.s_r[i],data.s_r[i]));
            }
        },
        error: function (data) {
            console.log(data);
        }
    })

})