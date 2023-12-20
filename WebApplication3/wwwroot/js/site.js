// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function urunEkle() {
    var urunAdi = document.getElementById('UrunAdi').value;
    var urunAciklamasi = document.getElementById('UrunAciklamasi').value;
    var kategoriID = document.getElementById('KategoriId').value;
    var urunFiyati = document.getElementById('UrunFiyati').value;
    var urunFotografi = 'https://i.imgur.com/JIA9UlL_d.webp';

    if (urunAdi.trim() == '' || urunAciklamasi.trim() == '' || KategoriID.trim() == '' || UrunFiyati.trim() == '' || UrunFotografi.trim() == '') {
        alert('Lütfen Tüm Alanları Doldurun.')
        return;
    }

    var xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) // readyStatus 4 ise isteğimiz sunucu tarafında tamamlandığını iletir.
        {
            if (xhr.status = 200) {
                alert('Ürün Başarıyla Eklendi!');
            }
            else {
                alert('Ürün eklenirken hata oluştu!');
            }
        }
    };

    xhr.open('POST', '/Urun/Ekle', true);
    xhr.setRequestHeader('Content-Type', 'application/json;charset=UTF-8');

    var data = JSON.stringify({
        UrunAdi: urunAdi,
        UrunAciklamasi: urunAciklamasi,
        KategoriID: kategoriID,
        UrunFiyati: urunFiyati,
        UrunFotografi: urunFotografi
    });

    xhr.send(data);

    document.getElementById('UrunAdi').value = '';
    document.getElementById('UrunAciklamasi').value = '';
    document.getElementById('KategoriId').value = '';
    document.getElementById('UrunFiyati').value = '';
    document.getElementById('UrunFotografi').value = '';

}