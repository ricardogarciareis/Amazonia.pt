﻿using Amazonia.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Repositorios
{
    public class CarrinhoCompras : ICarrinhoCompras
    {
        public Cliente Cliente { get; set; }
        public List<Livro> Livros { get; set; }   //ctrl+F12 em cima da classe Livro

        public decimal AplicarDesconto(decimal valorDesconto)
        {
            var fatorDesconto = (100 - valorDesconto)/100;
            var valorCalculado = Livros.Sum(x => x.ObterPreco());
            var valorComDesconto = valorCalculado * fatorDesconto;
            return valorComDesconto;
        }

        public decimal CalcularPreco()
        {
            var valorCalculado = Livros.Sum(x => x.ObterPreco());

            return valorCalculado;

        }
    }
}
