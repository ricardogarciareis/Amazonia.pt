using System.Collections.Generic;

namespace Amazonia.DAL.Repositorios
{
    //A interface é um contrato
    //Obriga todas as classes que implementam a usar no mínimo todos os métodos especificados de facto
    interface IRepositorio<T>  //uma interface não pode ser herdada, só pode ser implementada
    {
        
        void Criar(T obj);

        T ObterPorNome(string Nome);
        List<T> ObterTodos();

        T Atualizar(string nomeAntigo, string nomeNovo);

        void Apagar(T obj);
    }
}