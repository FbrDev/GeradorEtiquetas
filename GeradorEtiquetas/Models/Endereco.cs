using System.ComponentModel.DataAnnotations;

namespace GeradorEtiquetas.Models
{
    public class Endereco
    {
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O {0} deve ter {1} caracteres.")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Localidade { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public int Numero { get; set; }
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Nome { get; set; }

        public string EndCompleto
        {
            get {
                return $"Endereço: {Logradouro} - N°: {Numero} - Cep: {Cep} - Bairro {Bairro} - Cidade {Localidade} - UF: {Uf} - Complemento: {Complemento}";
            }
        }

    }
}
