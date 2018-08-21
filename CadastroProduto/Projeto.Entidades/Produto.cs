using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }

        //Construtor default
        public Produto()
        {

        }

        //Sobrecarregando o construtor
        public Produto(int idProduto, string nome, decimal preco, int quantidade, DateTime dataCompra)
        {
            IdProduto = idProduto;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            DataCompra = dataCompra;
        }

        //sobrescrevendo o método ToString da classe object
        public override string ToString()
        {
            //interpolação
            return $"ID:{IdProduto}\n Nome:{Nome} \n Preço: R${Preco}\n Quantidade:{Quantidade}\n DataCompra:{DataCompra} ";
        }
    }
}
