namespace SiteFrotas.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Matricula { get; set; } = "";
        public string Marca { get; set; } = "";
        public string Modelo { get; set; } = "";
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
    }
}