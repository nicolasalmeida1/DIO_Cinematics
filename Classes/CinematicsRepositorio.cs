using System.Collections.Generic;
using Dio_Cinematics.Interfaces;

namespace Dio_Cinematics
{
    public class CinematicsRepositorio : IRepositorio<Cinematic>
    {
        private List<Cinematic> listaCinematic = new List<Cinematic>();
        public void Atualiza(int id, Cinematic objeto)
        {
            listaCinematic[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaCinematic[id].Excluir();
        }

        public void Insere(Cinematic objeto)
        {
            listaCinematic.Add(objeto);
        }

        public List<Cinematic> Lista()
        {
            return listaCinematic;
        }

        public int ProximoId()
        {
            return listaCinematic.Count;
        }

        public Cinematic RetornaPorId(int id)
        {
            return listaCinematic[id];
        }
    }
}