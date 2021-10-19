using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Repositorios
{
    //A interface é um contrato
    //Obriga todas as classes que implementam a usar no mínimo todos os métodos especificados de facto
    interface IRepositorio<T>  //uma interface não pode ser herdada, só pode ser implementada
    {
        void Criar(T obj);

        T ObterPorNome(string Nome);
        List<T> ObterTodos();

        T Atualizar(T obj);

        void Apagar(T obj);
    }
}