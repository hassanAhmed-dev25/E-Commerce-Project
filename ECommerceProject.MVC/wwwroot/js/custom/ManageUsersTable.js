$(document).ready(function () {

    $("#ManageUsersTable").DataTable({

        processing: true,
        serverSide: true,
        searching: true,
        ordering: true,
        paging: true,

        ajax: {
            url: "/Admin/GetAllUsers",
            type: "POST"
        },

        columns: [
            { data: "email", name: "Email" },
            { data: "role", name: "Role" },

            {
                data: "isBlocked",
                name: "IsBlocked",
                render: function (data) {
                    if (data)
                        return `<span class="badge bg-danger">Blocked</span>`;
                    return `<span class="badge bg-success">Active</span>`;
                }
            },

            {
                data: "ordersCount",
                name: "OrdersCount",
                render: data => `<strong>${data}</strong>`
            },

            {
                data: "productsCount",
                name: "ProductsCount",
                render: data => `<strong>${data}</strong>`
            },

            {
                data: "createdAt",
                name: "CreatedAt",
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
                render: function (id, type, row) { // Later i will add this feature to toggle block status
                    return `
                        <button class="btn btn-sm btn-danger ms-1")">
                            ${row.isBlocked ? 'Unblock' : 'Block'}
                        </button>
                    `;
                }
            }
        ],

        order: [[5, "desc"]], // CreatedAt

        columnDefs: [
            {
                defaultContent: "-",
                targets: "_all"
            }
        ]
    });

});
