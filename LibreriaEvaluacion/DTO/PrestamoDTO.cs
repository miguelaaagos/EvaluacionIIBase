using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaEvaluacion.DTO
{
    public class PrestamoDTO
    {
        private int id;
        private int monto;

        public static List<PrestamoDTO> datos = new List<PrestamoDTO>()
        {
            new PrestamoDTO() { id = 1, monto = 150000},
            new PrestamoDTO() { id = 2, monto = 2150000},
            new PrestamoDTO() { id = 3, monto = 13000000}
        };

        public int Id { get => id; set => id = value; }
        public int Monto { get => monto; set => monto = value; }
        //propiedades
        public int MontoMasInteres { get => Monto + Monto * (1 / 10); }
        // Monto + Monto * 0.1 = MontoMasInteres.
        public int MontoAtraso { get => Monto + Monto * (1 / 10) + Monto * (5 / 100); }
        // Monto + Monto * 0.1 + Monto * 0.05 = Monto con interés y multa.
        

        //métodos
        public static bool Add(PrestamoDTO nuevosDatos)
        {
            try
            {
                datos.Add(nuevosDatos); // añadir nuevo objeto a lista estática

                return true; // si añade bien, devuelve true
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static List<PrestamoDTO> List()
        {
            return datos;
        }
        public static int Find(int id)
        {
            for (int i = 0; i < datos.Count; i++) // recorrer lista a través de for y su conteo
            {
                if (datos[i].id == id) // verificar si el atributo id es igual al enviado
                {
                    return i; // en caso de encontrarse, se devuelve la posición
                }
            }

            return -1; // si no se encuentra, pasa del for y devuelve -1
        }

        public static PrestamoDTO Find(PrestamoDTO dato)
        {
            for (int i = 0; i < datos.Count; i++) // recorrer lista a través de for y su conteo
            {
                if (datos[i].id == dato.Id) // verificar si el atributo id es igual al enviado 
                {
                    return datos[i]; // en caso de encontrarse, devuelve el objeto de tipo DatoDTO
                }
            }

            return new PrestamoDTO(); // si no se encuentra, pasa del for y devuelve un objeto vacío
        }

        public static bool Edit(PrestamoDTO dato, int indice)
        {
            try
            {
                // reemplazar elemento en el índice indicado
                datos[indice] = dato;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoveAtIndex(int index)
        {
            if (index >= 0)
            {
                datos.RemoveAt(index);
                // RemoveAt para eliminar en arreglos por su índice
            }

            return false; // temporal para compilar
        }

        public static bool Remove(int id)
        {
            int idEncontrado = Find(id);

            if (idEncontrado >= 0) // si no se encuentra ID, devuelve -1
            {
                datos.RemoveAt(idEncontrado);
                return true;
            }
            else
            {
                return false; // no se encontró el id para eliminar
            }
        }

        public override string ToString()
        {
            // return $"Id: {this.id}, Marca: {this.marca}, Talla: {this.talla}, Precio: {this.precio}";
            return $"Id: {id}, Monto: {monto}, Monto con interés: {MontoMasInteres}, Monto con atraso: {MontoAtraso}";
        }
    }
}
