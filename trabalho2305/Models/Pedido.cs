using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace trabalho2305.Models
{
    public class Pedido
    {[Key]
        
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "IdCliente é obrigatório")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "IdCidade é obrigatório")]
        public int IdCidade { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Venda precisa ser maior ou igual a 0")]
        public float Valor { get; set; }
        public string Observacao { get; set; }
        public int IdFormaPgto { get; set; }
    }
}
