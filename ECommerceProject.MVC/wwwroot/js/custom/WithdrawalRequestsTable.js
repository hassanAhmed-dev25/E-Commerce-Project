$(document).ready(function () {

    $("#WithdrawalRequestTable").DataTable({

        processing: true,
        serverSide: true,
        searching: true,
        ordering: true,
        paging: true,

        ajax: {
            url: "/wallet/GetWithdrawasAjax",
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
                data: "withdrawalStatus",
                name: "WithdrawalStatus",
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
                    return new Date(data).toLocaleDateString('en-GB', {
                        day: '2-digit',
                        month: 'short',
                        year: 'numeric'
                    });
                }

            },

            {
                data: "withdrawalStatus",
                name: "WithdrawalStatus",
                render: function (data, type, row) {

                    switch (data) {
                        case 1:
                            return `<button class="btn btn-danger btn-sm" disabled>
                                        Under Review </button>`;
                        case 2:
                            return `<a href="/Wallet/WithdrawMoney?withdrawalId=${row.id}"
                                            class="btn btn-success btn-sm">Withdraw Now</a>`;
                        case 3:
                            return `<button class="btn btn-danger btn-sm" disabled>
                                        Completed</button>`;
                        case 4:
                            return `<button class="btn btn-danger btn-sm" disabled>
                                        Rejected</button>`;
                        default:
                            return "-";
                    }
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
