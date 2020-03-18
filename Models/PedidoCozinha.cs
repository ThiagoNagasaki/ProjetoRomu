using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRumo.Models
{
    public class PedidoCozinha
    {
        [Key]
        public int PedidoCozinhaId { get; set; }
        public int PedidoId { get; set; }
        [ForeignKey("PedidoFK")]
        public Pedido Pedido { get; set; }
        public int CozinhaId { get; set; }
        [ForeignKey("CozninhaFK")]
        public Cozinha Cozinha { get; set; }
    }

}   

