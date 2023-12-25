namespace WebApplication3.Models
{
    public class SiparisDetay
    {
        public int DetayID { get; set; }
        public int SiparisID { get; set; }
        public int UrunId { get; set; }
        public int Adet {  get; set; }
        public string? Durum { get; set; }
        public string? Aciklama { get; set; }


        public void SiparisDetayOlustur(int DetayID,int SiparisID,int UrunId,int Adet,string? Durum,string? Aciklama)
        {
            SiparisDetay siparisDetay = new SiparisDetay()
            {
                DetayID = DetayID,
                SiparisID = SiparisID,
                UrunId = UrunId,
                Adet = Adet,
                Durum = Durum,
                Aciklama = Aciklama,
            };
        }

        public void SiparisDetayGuncelle(int DetayID,int SiparisID,int UrunId,int Adet,string? Durum,string? Aciklama)
        {
            SiparisDetay siparisDetay = new SiparisDetay()
            {
                DetayID = DetayID,
                SiparisID = SiparisID,
                UrunId = UrunId,
                Adet = Adet,
                Durum = Durum,
                Aciklama = Aciklama,
            };
        }

        public void SiparisDetaySil(int DetayID)
        {
            SiparisDetay siparisDetay = new SiparisDetay()
            {
                DetayID = DetayID,
            };
        }

        public List<SiparisDetay> SiparisDetayGetir()
        {
            List<SiparisDetay> siparisDetay = new List<SiparisDetay>();

            // vt den çek

            return siparisDetay;
        }

    } 
}
