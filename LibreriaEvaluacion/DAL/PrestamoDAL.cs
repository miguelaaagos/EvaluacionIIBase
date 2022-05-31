using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaEvaluacion.DTO;

namespace LibreriaEvaluacion.DAL
{
    public class PrestamoDAL
    {
        //métodos
        public bool Insertar(PrestamoDTO datos)
        {
            return PrestamoDTO.Add(datos);
        }

        public bool Actualizar(PrestamoDTO dato)
        {
            // obtener índice de objeto a editar
            int indice = BuscarPorIdSimple(dato.Id);

            // retornar el resultado de la edición del objeto en la lista
            return PrestamoDTO.Edit(dato, indice);
        }

        public bool Eliminar(PrestamoDTO datos)
        {
            int indiceElementoBuscado = BuscarPorId(datos.id); // <---------- este error no supe como arreglarlo :/

            if (indiceElementoBuscado >= 0) // encontró un elemento
            {
                return PrestamoDTO.RemoveAtIndex(indiceElementoBuscado);
            }

            return false; // Si llega a esta línea, significa que algo ocurrió mal (no se encontró el elemento)
        }

        public List<PrestamoDTO> Listar()
        {
            // return null;
            return PrestamoDTO.List();
        }

        public int BuscarPorIdSimple(int id)
        {
            // método 1: tradicional (intro a programación)
            for (int i = 0; i < PrestamoDTO.List().Count; i++)
            {
                // si encuentra elemento
                if (PrestamoDTO.List()[i].Id == id)
                {
                    return i; // retorna índice de elemento
                }
            }
            return -1;
        }

        public bool EliminarPorIndice(int indice)
        {
            return PrestamoDTO.RemoveAtIndex(indice);
        }

        public PrestamoDTO? BuscarPorId(int id)
        {
            foreach (PrestamoDTO dato in PrestamoDTO.List())
            {
                if (dato.Id == id) { return dato; }
            }

            return null;
        }
    }
}
