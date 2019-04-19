var dTable;
var selectedId;

$(document).ready(function () {
    $.fn.dataTable.moment('DD MMM YYYY');    
    //**Result Data Table
    dTable = $('#tableAlbums').dataTable({
        "bPaginate": false,
        "bFilter": false,
        "scrollCollapse": true,
        "paging": true,
        "bLengthChange": false,
        "pagingType": "full",
        "responsive": true,
        "pageLength": 50,
        "language": {
            "infoEmpty": "Total Records: <span class='color-dark-baby-blue'> _TOTAL_ (Page _PAGE_ of _PAGES_) </span>",
            "sEmptyTable": "No record found.",
            "paginate": {
                "first": "First",
                "last": "Last",
                "next": "Next",
                "previous": "Previous"
            }
        }
    });

    LoadData();
    
    $('#btnAdd').on('click', function () {        
        $("#tableAlbums").DataTable().clear().draw(false);

        var urlPath = $('#addArtist').val();

        var txtAlbumName = $('#txtAlbumName').val();
        var txtArtistName = $('#txtArtistName').val();
        var txtImageURL = $('#txtImageURL').val();
        var txtAudioURL = $('#txtAudioURL').val();
        var txtPrice = $('#txtPrice').val();
        var txtReleaseDate = $('#txtReleaseDate').val();

        $.ajax({
            type: "POST",
            url: urlPath,
            data: {
                'ArtistName': txtArtistName,
                'AlbumName': txtAlbumName,
                'ImageURL': txtImageURL,
                'ReleaseDate': txtReleaseDate,
                'Price': txtPrice,
                'SampleURL': txtAudioURL
            },
            success: function (response) {
                if (response.CommandStatus > 0) {
                    alert('Add Success');
                    $('#addAlbumModal').modal('hide');
                    LoadData();
                }
                else {
                    alert(response.ValidationMessages[1]);
                }
            },

            error: function () {
                console.log("error");
                alert('error');
            }
        });
    });

    $('#btnUpdate').on('click', function () {
        $("#btnUpdate").show();
        $("#btnAdd").hide();

        var urlPath = $('#updateArtist').val();

        var txtAlbumName = $('#txtAlbumName').val();
        var txtArtistName = $('#txtArtistName').val();
        var txtImageURL = $('#txtImageURL').val();
        var txtAudioURL = $('#txtAudioURL').val();
        var txtPrice = $('#txtPrice').val();
        var txtReleaseDate = $('#txtReleaseDate').val();

        $.ajax({
            type: "POST",
            url: urlPath,
            data: {
                'ArtistID': selectedId,
                'ArtistName': txtArtistName,
                'AlbumName': txtAlbumName,
                'ImageURL': txtImageURL,
                'ReleaseDate': txtReleaseDate,
                'Price': txtPrice,
                'SampleURL': txtAudioURL
            },
            success: function (response) {
                if (response.ValidationMessages[0] == 'Successful') {
                    alert('Add Success');
                    $('#addAlbumModal').modal('hide');
                    LoadData();
                }
                else {
                    alert(response.ValidationMessages[1]);
                }
            },

            error: function () {
                console.log("error");
                alert('error');
            }
        });
    });

    $('#btnDelete').on('click', function () {
       
        var urlPath = $('#deleteArtist').val();

        $.ajax({
            type: "POST",
            url: urlPath,
            data: {'id': selectedId},
            success: function (response) {
                if (response.ValidationMessages[0] == 'Successful') {
                    alert('Delete Success');
                    $('#deleteAlbumModal').modal('hide');
                    LoadData();
                }
                else {
                    alert(response.ValidationMessages[1]);
                }
            },

            error: function () {
                console.log("error");
                alert('error');
            }
        });
    });

    function ClearField() {
        $('#txtAlbumName').val('');
        $('#txtArtistName').val('');
        $('#txtImageURL').val('');
        $('#txtAudioURL').val('');
        $('#txtPrice').val('');
        $('#txtReleaseDate').val('');
    }    
    
    function LoadData() {
        $("#tableAlbums").DataTable().clear().draw(false);

        var urlPath = $('#albumsList').val();
        $.ajax({
            url: urlPath,
            success: function (response) {
                var rowNum = 1;
                $.each(JSON.parse(response), function (columnKey, columnValue) {
                    var dt = $('#tableAlbums').DataTable().row.add([
                        rowNum,
                        columnValue.AlbumName,
                        columnValue.ArtistName,
                        moment(columnValue.ReleaseDate).format("DD MMM YYYY"),
                        "<a href='#' onclick=\"PlayMusic('" + columnValue.SampleURL + "','" + columnValue.ImageURL + "','" + columnValue.ArtistName + "','" + columnValue.AlbumName + "')\"><td><i class=\'material-icons\' data-toggle=\'tooltip\' title=\'Play\'>play_circle_filled</i></td></a>",
                        columnValue.Price,
                        '<a href=\'#\' class=\'edit\'>' +
                        '<i class= \'material-icons\' data-toggle=\'tooltip\' title = \'Edit\' >&#xE254;</i></a>' +
                        '<a href=\'#\' class=\'delete\'>' +
                        '<i class= \'material-icons\' data-toggle=\'tooltip\' title = \'Delete\' >&#xE872;</i></a>'
                    ]);
                    $(dt.node()).attr("id", columnValue.ArtistID);
                    dt.draw(false);
                    rowNum += 1;
                });
                InitComponent();
            },
            error: function (e) {
                alert("Error: " + e);
            }
        });
    }
    function InitComponent() {
        // Activate tooltip
        $('[data-toggle="tooltip"]').tooltip();       

        $('.edit').click(function () {
            $("#btnUpdate").show();
            $("#btnAdd").hide();
            var id = $(this).closest("tr").attr('id');
            selectedId = id;

            var data;
            var urlPath = $('#getAlbum').val();

            $.ajax({
                method: "POST",
                url: urlPath,
                data: { 'id': selectedId },
                success: function (response) {
                    data = JSON.parse(response);
                    ClearField();
                    $('#txtAlbumName').val(data[0].AlbumName);
                    $('#txtArtistName').val(data[0].ArtistName);
                    $('#txtImageURL').val(data[0].ImageURL);
                    $('#txtAudioURL').val(data[0].SampleURL);
                    $('#txtPrice').val(data[0].Price);
                    setDate(data[0].ReleaseDate, '#txtReleaseDate');
                },
                error: function (e) {
                    alert("Error: " + e);
                }
            });
            $('#addAlbumModal').modal('show');
        });

        $('.delete').click(function () {            
            ClearField();
            var id = $(this).closest("tr").attr('id');
            selectedId = id;
            $('#deleteAlbumModal').modal('show');
        });

        $('#addAlbum').click(function () {
            $("#btnUpdate").hide();
            $("#btnAdd").show();
            ClearField();
            var id = $(this).closest("tr").attr('id');
            selectedId = id;
            $('#addAlbumModal').modal('show');
        });
    }
});

function PlayMusic(urlMusic, imgSrc, artistName, albumName) {
    $("#imgSrc").attr("src", imgSrc);
    $('#showAudio').modal('show');
    $("#artistName").text(artistName);
    $("#albumName").text(albumName);
    changeAudio(urlMusic);
}
function changeAudio(sourceUrl) {
    var audio = $("#audioPlayer");
    $("#audioSrc").attr("src", sourceUrl);

    audio[0].pause();
    audio[0].load();//suspends and restores all audio element

    audio[0].oncanplaythrough = audio[0].play();
}

function setDate(date,id) {
    var z = new Date(date);
    var dd = z.getDate();
    var mm = z.getMonth() + 1; //January is 0!

    var yyyy = z.getFullYear();
    if (dd < 10) { dd = '0' + dd }
    if (mm < 10) { mm = '0' + mm }
    today = yyyy + '-' + mm + '-' + dd;

    $(id).val(today);
}
