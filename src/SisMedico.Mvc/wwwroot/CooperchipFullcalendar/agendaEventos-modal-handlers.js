
// Quando o documento estiver pronto
$(document).ready(function () {
    // Evento de submissão do formulário
    $(document).on('submit', '#eventForm', function (e) {
        e.preventDefault(); // Impede o envio padrão do formulário

        // var startDateTime = moment($('#Start').val()).format('YYYY-MM-DDTHH:mm:ss');
        // $('#Start').val(startDateTime);


        // Serializa os dados do formulário para envio
        var formData = $(this).serialize();

        // Faz a requisição AJAX para a action Create
        $.ajax({
            url: '/AgendaEventos/Save',
            type: 'POST',
            data: formData,
            headers: { 'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val() },

            success: function (response) {

                Swal.fire({
                    title: 'SUCESSO!',
                    text: 'Seu Agendamento foi gravado com sucesso!',
                    icon: 'success', // 'success', 'error', 'warning', 'info', 'question'
                    confirmButtonText: 'Ok'
                });

                // Fecha o modal
                $('#envetModalLg').modal('hide');

                // Recarrega a página ou o calendário para mostrar o novo evento
                location.reload(); // ou calendar.refetchEvents();
            },
            error: function (xhr, status, error) {
                // Tratamento de erro
                Swal.fire({
                    title: 'ATENÇÃO!',
                    text: 'Erro ao salvar o evento: ' + error,
                    icon: 'error', // 'success', 'error', 'warning', 'info', 'question'
                    confirmButtonText: 'Entendi'
                });

            }
        })

    });

});


