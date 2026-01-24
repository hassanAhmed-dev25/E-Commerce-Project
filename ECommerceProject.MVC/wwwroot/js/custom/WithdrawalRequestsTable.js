$(document).ready(function () {

    $("#WithdrawalRequestTable").DataTable({

        processing: true,
        serverSide: true,
        searching: true,
        ordering: true,
        paging: true,

        ajax: {
            url: "/wallet/GetWithdrawalsAjax",
            type: "POST",
            datatype: "json"
        },

        columns: [
            { data: "id", name: "Id" },

            {
                data: "amount",
                name: "Amount",
                render: function (data) {
                    return `<strong>${data.toFixed(2)} EGP</strong>`;
                }
            },

            {
                data: "status",
                name: "Status",
                render: function (data) {

                    switch (data) {
                        case 1:
                            return `<span class="badge bg-warning text-dark">Pending</span>`;
                        case 2:
                            return `<span class="badge bg-info">Approved</span>`;
                        case 3:
                            return `<span class="badge bg-success">Completed</span>`;
                        case 4:
                            return `<span class="badge bg-danger">Rejected</span>`;
                        default:
                            return "-";
                    }
                }
            },

            {
                data: "requestedAt",
                name: "RequestedAt",
                render: function (data) {
                    return moment(data).format("DD MMM YYYY");
                }
            }
        ],

        order: [[3, "desc"]],

        columnDefs: [
            {
                defaultContent: "-",
                targets: "_all"
            }
        ]
    });

});
