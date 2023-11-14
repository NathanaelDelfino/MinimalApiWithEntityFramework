using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalApiWithEntityFramework.ViewModel
{
    public class ProdutoViewModel
    {    
        public int CodigoDeBarras { get; set; }
        public string Descricao { get; set; } = "";
        public double Preco { get; set; }

    }
}