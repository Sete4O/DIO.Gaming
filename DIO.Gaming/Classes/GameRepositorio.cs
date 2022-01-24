using DIO.Gaming.Interfaces;
using System.Collections.Generic;

namespace DIO.Gaming.Classes
{
    public class gamesRepositorio : IRepositorio<Games>
    {
        private List<Games> listaGames = new List<Games>();
        public void Atualiza(int ID, Games objeto)
        {
            listaGames[ID] = objeto;
        }

        public void Exclui(int ID)
        {
            listaGames[ID].Excluir();
        }

        public void Insere(Games objeto)
        {
            listaGames.Add(objeto);
        }

        public List<Games> Lista()
        {
            return listaGames;
        }

        public int ProximoID()
        {
            return listaGames.Count;
        }

        public Games RetornaPorID(int ID)
        {
            return listaGames[ID];
        }


    }
}
