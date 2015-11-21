$(document).ready(function () {
    $('#colorSelect').change(function () {
        var url = $("#fill").data("get-size-list-url") + '/' + $("#colorSelect").val();
        $('#sizeSelect').empty();
        $.ajax({
            type: 'GET',
            url: url,
            dataType: 'json',
            success: function (sizes) {
                $.each(sizes, function (i, size) {
                    $("#sizeSelect").append('<option value="' + size.Value + '">' + size.Text + '</option>');
                });
            },
            error: function (ex) {
                //console.log('Failed to retrieve organizations.' + ex);
            }
        });
        return false;
    });
});