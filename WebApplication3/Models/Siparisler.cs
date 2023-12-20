namespace WebApplication3.Models
{
    public class Siparisler
    {
        public int SiparisID { get; set; }
        private int MasaID { get; set; }
        private decimal ToplamFiyat { get; set; }
        private string? OdemeDurumu { get; set; }


        public void SiparisEkle(int SiparisID, int MasaID, decimal ToplamFiyat, string? OdemeDurumu)
        {
            Siparisler siparisler = new Siparisler()
            {
                SiparisID = SiparisID,
                MasaID = MasaID,
                ToplamFiyat = ToplamFiyat,
                OdemeDurumu = OdemeDurumu,
            };
        }

        public void SiparisSil(int SiparisID)
        {
            Siparisler siparisler = new Siparisler()
            {
                SiparisID = SiparisID,
            };
        }

        public List<Siparisler> SiparisGetir()
        {
            List<Siparisler> siparisler = new List<Siparisler>();

            // vt den çek

            return siparisler;

        }

    }
}
