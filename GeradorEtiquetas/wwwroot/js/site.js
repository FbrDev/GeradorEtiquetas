function buscarCEP(tipo) {
    var cep = $("#" + tipo + "_Cep").val();

    $.ajax({
        url: "/Etiqueta/BuscarCEP",
        type: "GET",
        data: { cep: cep },
        success: function (endereco) {
            if (endereco != null) {
                $("#" + tipo + "_Logradouro").val(endereco.logradouro);
                $("#" + tipo + "_Bairro").val(endereco.bairro);
                $("#" + tipo + "_Localidade").val(endereco.localidade);
                $("#" + tipo + "_Uf").val(endereco.uf);
            } else {
                swal("Alerta!", "CEP não encontrado.", "warning");
            }
        },
        error: function () {
            swal("Erro!", "Ocorreu um erro ao buscar o CEP.", "error");
        }
    });
}

function initializeMap(remetente, destinatario) {
    var map = new Microsoft.Maps.Map(document.getElementById('mapContainer'), {});
    Microsoft.Maps.loadModule('Microsoft.Maps.Directions', function () {
        var directionsManager = new Microsoft.Maps.Directions.DirectionsManager(map);
        directionsManager.setRequestOptions({
            routeMode: Microsoft.Maps.Directions.RouteMode.driving,
            optimizeWaypoints: true,
            avoidTraffic: true
        });
        var waypoint1 = new Microsoft.Maps.Directions.Waypoint({ address: remetente });
        var waypoint2 = new Microsoft.Maps.Directions.Waypoint({ address: destinatario });
        directionsManager.addWaypoint(waypoint1);
        directionsManager.addWaypoint(waypoint2);
        directionsManager.calculateDirections();
    });
}

$(document).ready(function () {

    $("#openMapButton").on('click', () => {
        var remetente = document.getElementById('Remetente_Cep').value;
        var destinatario = document.getElementById('Destinatario_Cep').value;

        if (remetente === "" || destinatario === "") {
            swal("Alerta!", "O preenchimento do CEP é obrigatório.", "warning");
            return;
        } else {
            $('#exampleModal').modal('show');
            $('#exampleModal').on('shown.bs.modal', function () {
                initializeMap(remetente, destinatario);
            });
        }
    });
});