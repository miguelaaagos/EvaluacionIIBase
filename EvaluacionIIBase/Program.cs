using LibreriaEvaluacion.DTO;
using LibreriaEvaluacion.DAL;

const string nombreAlumno = "Wachimingo";

while (Menu(nombreAlumno))
{
    Console.ReadKey(); // pausa, solicitar la entrada de una tecla
}


static bool Menu(string nombreAlumno)
{ 
    bool continuar = true;

    Console.Clear(); // Limpia la pantalla
    Console.Title = $"Evaluación II: {nombreAlumno}";

    Console.WriteLine("Menú de opciones");
    Console.WriteLine("================");
    Console.WriteLine("1) Listar préstamos");
    Console.WriteLine("2) Agregar préstamo");
    Console.WriteLine("3) Actualizar préstamo");
    Console.WriteLine("4) Eliminar préstamo");
    Console.WriteLine("");
    Console.WriteLine("0) Salir");

    string opcion = Console.ReadLine().Trim(); // " 1 " => "1"

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Listado de préstamos registrados");
            OpcionListar();
            break;
        case "2":
            Console.WriteLine("Insertar un nuevo préstamo");
            OpcionInsertar();
            break;
        case "3":
            Console.WriteLine("Actualizar un préstamo existente");
            OpcionActualizar();
            break;
        case "4":
            Console.WriteLine("Eliminar un préstamo existente");
            OpcionEliminar();
            break;
        case "0":
            Console.WriteLine("Saliendo del programa ...");
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }

    return continuar;
}

// ToDo: lógica de GUI
static void OpcionInsertar()
{
    PrestamoDAL prestamoDal = new PrestamoDAL(); // Se llama a la capa de acceso a datos

    try
    {
        // Solicitar entrada al usuario
        Console.WriteLine("Ingrese ID:");
        int id = int.Parse(Console.ReadLine().Trim());

        Console.WriteLine("Ingrese monto:");
        int monto = int.Parse(Console.ReadLine().Trim());

        // Crear el nuevo objeto a insertar
        PrestamoDTO nuevoPrestamo = new PrestamoDTO()
        {
            Id = id,
            Monto = monto
        };

        bool resultadoInsertar = prestamoDal.Insertar(nuevoPrestamo); // Insertar y obtener resultado

        // Verificamos si el resultado fue correcto o no
        if (resultadoInsertar)
        {
            Console.WriteLine($"Se ha insertado un nuevo prestamo al usuario {nuevoPrestamo.Id} exitosamente");
        }
        else
        {
            Console.WriteLine($"Hubo un error al insertar prestamo al usuario {nuevoPrestamo.Id}");
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Por favor ingrese datos válidos para un nuevo préstamo, recuerde que el monto debe ser sobre los 50.000 pesos");
    }

    Console.ReadKey(); // Pausa para poder observar el resultado de la operación
}

static void OpcionActualizar()
{
    PrestamoDAL prestamoDAL = new PrestamoDAL();

    // Tarea 1: Consultar por el ID a buscar
    Console.WriteLine("Ingrese un ID a buscar");
    string opcion = Console.ReadLine().Trim(); // " A " => "A"

    try
    {
        // Tarea 2: Buscar el ID ingresado
        PrestamoDTO resultado = prestamoDAL.BuscarPorId(int.Parse(opcion));

        if (resultado != null) // si encontró efectivamente
        {
            // Tarea 3: Consultar al usuario qué se desea actualizar
            Console.WriteLine("¿Desea actualizar el Id? (Y/N)");
            string opcionId = Console.ReadLine().Trim();
            if (opcionId.ToUpper() == "Y")
            {
                Console.WriteLine($"Ingrese id nuevo: (actual: {resultado.Id})");
                string nuevoId = Console.ReadLine().Trim();
                resultado.Id = int.Parse(nuevoId);
            }

            Console.WriteLine("¿Desea actualizar el monto? (Y/N)");
            string opcionMonto = Console.ReadLine().Trim();
            bool editarMonto = opcionMonto.ToUpper() == "Y";
            if (opcionMonto.ToUpper() == "Y")
            {
                Console.WriteLine($"Ingrese monto nuevo: (actual: {resultado.Monto})");
                string nuevoMonto = Console.ReadLine().Trim();
                resultado.Monto = int.Parse(nuevoMonto);
            }

            // Tarea 4: Publicar objeto de cambio
        }
        else // si no encontró elementos con ese ID
        {

        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Debe escribir un número válido, recuerde que el monto debe ser sobre los 50.000 pesos");
    }
    finally
    {
        Console.WriteLine("Opción de actualizar terminada");
    }
}

static void OpcionListar()
{
    PrestamoDAL prestamoDAL = new PrestamoDAL();
    List<PrestamoDTO> datosLista = prestamoDAL.Listar();

    foreach (PrestamoDTO dato in datosLista)
    {
        Console.WriteLine(dato.ToString());
        Console.WriteLine($"Id: {dato.Id}, Marca: {dato.Monto}");
    }

    Console.ReadKey();

}

static void OpcionEliminar()
{
    PrestamoDAL prestamoDAL = new PrestamoDAL();

    Console.WriteLine("Ingrese el ID que desea eliminar:");
    int id = int.Parse(Console.ReadLine().Trim());

    bool resultadoEliminacion = prestamoDAL.Eliminar(id); // intento de eliminación, me resulta en fallo debido a que en prestamo DAL, la parte donde pongo el id también me da error y no supe arreglar eso :(

    if (resultadoEliminacion)
    {
        Console.WriteLine("Se ha eliminado el préstamo");
    }
    else
    {
        Console.WriteLine("No se ha podido eliminar el préstamo, revise el ID ingresado");
    }

    Console.ReadKey();
}
