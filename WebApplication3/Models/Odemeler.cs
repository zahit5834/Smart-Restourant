namespace WebApplication3.Models
{
    public class Odemeler
    {
        private int OdemeID  { get; set; }
        private int SiparisID { get; set; } 
        private string? OdemeTipi { get; set; }
        private decimal OdemeMiktari { get; set; }
        private DateTime OdemeTarihi { get; set; }


        public void OdemeEkle(int SiparisID, string? OdemeTipi, decimal OdemeMiktari, DateTime OdemeTarihi)
        {
            Odemeler odemeler = new Odemeler()
            {
                OdemeID = SiparisID,
                SiparisID = SiparisID,
                OdemeTipi = OdemeTipi,
                OdemeMiktari = OdemeMiktari,
                OdemeTarihi = OdemeTarihi
            };
        }

        public void OdemeSil(int OdemeID)
        {
            Odemeler odemeler = new Odemeler()
            {
                OdemeID = OdemeID,
            };
        }

        public List<Odemeler> OdemelerGetir()
        {
            List<Odemeler> odemeler = new List<Odemeler>();

            // vt den çek

            return odemeler;
        }

    }
}
