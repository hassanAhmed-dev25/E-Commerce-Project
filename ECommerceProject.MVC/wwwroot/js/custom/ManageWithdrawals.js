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
                            <button 
                                class="btn btn-success btn-sm me-1 btn-withdrawal-action"
                                data-id="${id}"
                                data-action="approve">
                                Approve
                            </button>

                            <button 
                                class="btn btn-danger btn-sm btn-withdrawal-action"
                                data-id="${id}"
                                data-action="reject">
                                Reject
                            </button>
                        `;
                    }

                    return `<span class="text-muted">Approved</span>`;
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



$(document).on("click", ".btn-withdrawal-action", function () {

    const id = $(this).data("id");
    const action = $(this).data("action");

    let confirmMsg = action === "approve"
        ? "Are you sure you want to approve this withdrawal?"
        : "Are you sure you want to reject this withdrawal?";

    if (!confirm(confirmMsg))
        return;

    $.ajax({
        url: "/Admin/UpdateWithdrawalStatusAjax",
        type: "POST",
        data: {
            withdrawalRequestId: id,
            action: action
        },
        success: function (res) {

            if (res.success) {
                alert(res.message);

                // Reload DataTable
                $("#ManageWithdrawals").DataTable().ajax.reload(null, false);
            } else {
                alert(res.message);
            }
        },
        error: function () {
            alert("Something went wrong!");
        }
    });
});




