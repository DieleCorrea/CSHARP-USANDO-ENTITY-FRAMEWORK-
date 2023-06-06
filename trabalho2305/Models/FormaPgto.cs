using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace trabalho2305.Models
{
    public class FormaPgto
    {[Key]
        public int IdFormaPgto { get; set; }
        public string DescricaoFormaPgto { get; set; }
    }
}
