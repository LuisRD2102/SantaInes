namespace SantaInesAPI.BussinessLogic.DTO
{
    public class DireccionDTO
    {
        public Guid Id { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Calle { get; set; }
        public string EdifCasa { get; set; }
        public string NumCasaApto { get; set; }
        public int CodPostal { get; set; }
    }
}
