namespace GeradorEtiquetas.Models
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            Id = Guid.NewGuid();
            DataEnvio = DateTime.Now.AddDays(1);
        }
        public Guid Id { get; set; }
        public DateTime DataEnvio { get; set; }
        public Endereco Remetente { get; set; }
        public Endereco Destinatario { get; set; }
    }
}
