using System.Collections.Generic;

namespace DIO.Gaming.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorID(int ID);
        void Insere(T entidade);
        void Exclui(int ID);
        void Atualiza(int ID, T entidade);
        int ProximoID();
    }
}
