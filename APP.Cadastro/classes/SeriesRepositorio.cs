using System;
using System.Collections.Generic;
using APP.Cadastro.interfaces;

namespace APP.Cadastro
{
    public abstract class Series : IRepositorio<Series>
    {
        private List<Series> listaSeries = new List<Series>();

        public Series RetornaPorId(int id)
        {
            return listaSeries[id];
            //throw new NotImplementException();
        }
        
        public List<Series> Lista()
        {
            return listaSeries;
            //throw new NotImplementException();
        }

        public void Insere(Series entidade)
        {
            listaSeries.Add(entidade);
            //throw new NotImplementException();
        }

        public void Atualiza(int id; Series entidade)
        {
            listaSeries[id] = entidade;
            //throw new NotImplementException();
        }

        public int ProximoId()
        {
            return listaSeries.Count;
            //throw new NotImplementException();
        }

        public void Exclui(int id)
        {
            listaSeries[id].Excluir();
            //throw new NotImplementException();
        }
    }
}