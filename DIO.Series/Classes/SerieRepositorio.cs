using DIO.Series.Interfaces;
using System.Collections.Generic;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie> // Aqui a classe SerieRepositorio está implementando um IRepositorio de Serie
    {
    private List<Serie> listaSerie = new List<Serie>(); // Váriavel listaSerie recebe lista de série
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir(); // Apenas marce se a id(serie) foi excluido
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count; // Count = contar; ele incrementa sempre que um item é adicionado à lista e decrementada sempre que um item é removido.        
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}