using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRumo.Models
{
    public class Cozinha
    {
        [Key]
        public int CozinhaId { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName ("Prato escolhido")]
        public string PratoEscolho { get; set; }
        [Column(TypeName = "varchar(10")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Quantidade { get; set; }
        public ICollection<PedidoCozinha> PedidosCozinha { get; set; }
    }
}
