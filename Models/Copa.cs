using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoRumo.Models
{
    public class Copa
    {
        [Key]
       public int CopaId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName ("Bebida Escolhida")]
        public string BebidaEscolhida { get; set; }
        [Column(TypeName = "varchar(3)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Quantidade { get; set; }
       
    }
}
