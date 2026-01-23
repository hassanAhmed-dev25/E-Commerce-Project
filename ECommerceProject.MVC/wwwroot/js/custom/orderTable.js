
$(document).ready(function () {

    // Initialize DataTable with AJAX (Server-Side)
    $("#OrderTable").DataTable({

        // Show loading indicator
        processing: true,

        // Enable server-side processing
        serverSide: true,

        // Enable searching
        searching: true,

        // Enable sorting
        ordering: true,

        // Enable pagination
        paging: true,

        // AJAX configuration
        ajax: {
            url: "/Order/GetOrders", // Controller Action
            type: "POST",
            datatype: "json"
        },

        // Define table columns and data source
        columns: [
            { data: "id", name: "Id" },
            { data: "totalAmount", name: "TotalAmount" },

            {
                data: "orderStatusName",
                name: "OrderStatus",
                render: function (data) {
                    return `<span class="badge bg-info">${data}</span>`;
                }
            },

            {
                data: "paymentStatusName",
                name: "PaymentStatus",
                render: function (data, type, row) {

                    if (row.paymentStatus === 1)
                        return `<span class="badge bg-warning">Pending</span>`;

                    if (row.paymentStatus === 2)
                        return `<span class="badge bg-success">Paid</span>`;

                    return `<span class="badge bg-danger">Failed</span>`;
                }
            },

            { data: "createdAt", name: "CreatedAt" },

            {
                data: "id",
                render: function (data, type, row) {

                    if (row.paymentStatus === 1) {
                        return `<a href="/Payment/Pay?orderId=${data}"
                                            class="btn btn-success btn-sm">Pay Now</a>`;
                    }

                    if (row.paymentStatus === 2) {
                        return `<button class="btn btn-secondary btn-sm" disabled>
                                            Already Paid</button>`;
                    }

                    return `<button class="btn btn-danger btn-sm" disabled>
                                        Payment Failed</button>`;
                },
                orderable: false,
                searchable: false
            }
        ],

        // Default content for empty cells
        columnDefs: [{
            defaultContent: "-",
            targets: "_all"
        }]
    });

});