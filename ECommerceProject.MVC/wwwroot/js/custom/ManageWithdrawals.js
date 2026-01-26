$(document).ready(function () {

    $("#ManageWithdrawals").DataTable({

        processing: true,
        serverSide: true,
        searching: true,
        ordering: true,
        paging: true,

        ajax: {
            url: "/Admin/GetAllWithdrawalsAjax",
            type: "POST"
        },

        columns: [
            { data: "id", name: "Id" },

            {
                data: "fullName",
                name: "FullName"
            },

            {
                data: "email",
                name: "Email"
            },

            {
                data: "amount",
                name: "Amount",
                className: "text-center",
                render: data => `<strong>${data.toFixed(2)} EGP</strong>`
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
                data: "id",
                orderable: false,
                searchable: false,
                render: function (id, type, row) {

                    if (row.withdrawalStatus === 1) { // Pending
                        return `
                <button class="btn btn-success btn-sm me-1"
                        onclick="approveWithdrawal(${id})">
                    Approve
                </button>

                <button class="btn btn-danger btn-sm"
                        onclick="rejectWithdrawal(${id})">
                    Reject
                </button>
            `;
                    }

                    return `<span class="text-muted">—</span>`;
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
