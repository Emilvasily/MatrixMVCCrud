$(function () {
    $('#employeeTable').on("click", "#employeeDelete", function () {
        var btn = $(this);
        bootbox.confirm({
            message: "Do you wanna delete?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                }, cancel: {
                    label: 'Noo',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                var id = btn.data('id');
                if (result) {
                    $.ajax(
                        {
                            type: 'GET',
                            url: '/Home/DeleteEmployee/' + id,
                            success: function () {
                                btn.parent().parent().parent().remove();
                                bootbox.alert('Succesfully delete');
                            }
                        }
                    )
                }
            }
        })
    })
})