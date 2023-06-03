function deletarContato(idContato) {
    $.ajax({
        url: "contato/delete?idContato=" + idContato,
        success: () => {
            window.location.reload()
        }
    });
}

function editarContato() {
    $("#nomeContato").addClass("d-none");
    $("#inputEditarContato").removeClass("d-none");
    $("#inputEditarContatoConfirmar").removeClass("d-none");
}

function editarContatoConfirmar(idContato) {
    let novoNomeContato = $("#inputEditarContato").val();
    console.log(novoNomeContato);
    $.ajax({
        url: "contato/editar?idContato=" + idContato + "&novoNomeContato=" + novoNomeContato,

        success: () => {
            window.location.reload()
        }
    });
}

function criarContato(idUsuario) {
    let nomeContato = $("#nome-input").val();
    let telefoneContato = $("#telefone-input").val();

    $.ajax({
        url: '/contato/criar',
        method: 'GET',
        data: {
            telefone: telefoneContato,
            nomeContato: nomeContato,
            idUsuario: idUsuario
        },
        success: function () {
            window.location.reload()
        }
    });
}

const modalCriarContato = new bootstrap.Modal('#modal-novo-contato', {
    keyboard: false
})

function openModal() {
    modalCriarContato.show()
}

const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))