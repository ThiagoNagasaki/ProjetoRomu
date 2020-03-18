using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoRumo.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        [Column(TypeName = "varchar(4)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Mesa Solicitante")]
        public int MesaSolicitante { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cliente { get; set; }
        public ICollection<PedidoCozinha> PedidoCozinha { get; set; }
    }
}
