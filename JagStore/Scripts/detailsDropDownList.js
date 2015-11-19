$(document).ready(function () {
    $('#organizationTypeSelect').change(function () {
        var url = $("#organizationListWrapper").data("get-organization-list-url") + '/' + $("#organizationTypeSelect").val();
        $('#facilityNameSelect').empty();
        $.ajax({
            type: 'GET',
            url: url,
            dataType: 'json',
            success: function (organizations) {
                $.each(organizations, function (i, organization) {
                    $("#facilityNameSelect").append('<option value="' + organization.Value + '">' + organization.Text + '</option>');
                });
            },
            error: function (ex) {
                //console.log('Failed to retrieve organizations.' + ex);
            }
        });
        return false;
    });
});