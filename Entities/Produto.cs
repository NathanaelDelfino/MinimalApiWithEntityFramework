using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApiWithEntityFramework.ViewModel;

namespace MinimalApiWithEntityFramework.Entities
{
    public class Produto
    {
        public static Produto Criar(ProdutoViewModel produto) 
        {
            return new Produto(Guid.NewGuid().ToString(),
                               produto.CodigoDeBarras,
                               produto.Descricao,
                               produto.Preco);
        }

        public void Atualizar(ProdutoViewModel produto) 
        {
            CodigoDeBarras = produto.CodigoDeBarras;
            Descricao = produto.Descricao;
            Preco = produto.Preco;
        }


        public Produto(string id,int codigoDeBarras, string descricao,  double preco) 
        {
            this.Id = id;
            this.CodigoDeBarras = codigoDeBarras;
            this.Descricao = descricao;
            this.Preco = preco;
        }

        public string Id { get; private set; } = "";
        public int CodigoDeBarras { get; private set; } =0;
        public string Descricao { get;private set; } = "";
        public double Preco { get;private set; } = 0;
        
         
    }
}