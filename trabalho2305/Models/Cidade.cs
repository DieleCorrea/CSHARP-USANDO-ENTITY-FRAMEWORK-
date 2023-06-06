using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace trabalho2305.Models
{
    public class Cidade
    {   [Key]
        public int IdCidade { get; set; }

        [StringLength(50, MinimumLength =5, ErrorMessage ="Campo deve ter pelo menos 5 caractereres ")]
        public string NomeCidade { get; set; }


        public string uf { get; set; }
        public string Pais { get; set; }

    }
}
