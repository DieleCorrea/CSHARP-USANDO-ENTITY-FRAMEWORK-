using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace trabalho2305.Models
{
    public class Cliente
    {[Key]
        public int IdCliente { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo deve ter pelo menos 5 caractereres ")]
        public string NomeCliente { get; set; }
    }
}
