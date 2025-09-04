$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

$(document).ready(function () {
    console.log("jQuery version:", $.fn.jquery);
    console.log("DataTable function:", $.fn.DataTable);

    try {
        $('#table-products').DataTable();
        console.log("DataTable initialized");
    } catch (e) {
        console.error("Erro ao inicializar DataTable:", e);
    }
});


