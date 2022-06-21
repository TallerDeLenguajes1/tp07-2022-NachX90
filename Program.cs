List<Tarea> TareasPendientes = new();
List<Tarea> TareasRealizadas = new();

Random Aleatorio = new Random();
int CantidadDeTareas = Aleatorio.Next(5,16);

Funcion.GenerarTitulo("BIENVENIDO");
Console.WriteLine($"Generando {CantidadDeTareas} tareas aleatorias...");
for (int i = 0; i < CantidadDeTareas; i++)
{
    Tarea NuevaTarea = new();
    NuevaTarea.ID = i+1;
    NuevaTarea.Descripcion = NuevaTarea.Descripciones.ElementAt(Aleatorio.Next(NuevaTarea.Descripciones.Count));
    NuevaTarea.Duracion = Aleatorio.Next(10, 101);
    TareasPendientes.Add(NuevaTarea);
}
Console.WriteLine("Tareas generadas :D");

int opcion;
do
{
    Console.WriteLine();
    Funcion.GenerarTitulo("MENU");
    Console.WriteLine("  1: Ver todas las tareas");
    Console.WriteLine("  2: Revisar tareas pendientes");
    Console.WriteLine("  3: Buscar tarea pendiente por descripción");
    Console.WriteLine("  4: Mostrar horas trabajadas");
    Console.WriteLine("  5: Salir");
    Console.Write("Ingrese su opción: ");
    opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            VerTodasLastareas();
            break;
        case 2:
            RevisarTareasPendientes();
            break;
        case 3:
            BuscarTareaPendientePorDescripcion();
            break;
        case 4:
            int TotalDeHorasTrabajadas = HorasTrabajadas();
            Console.WriteLine($"\nTotal de horas trabajadas: {TotalDeHorasTrabajadas}");
            break;
        case 5:
            Console.WriteLine("\nGracias por utilizar el programa :)\n");
            break;
        default:
            Console.WriteLine("\nOpción incorrecta. Intente nuevamente");
            break;
    }
} while (opcion != 5);
Funcion.GenerarTitulo("FIN");

void VerTodasLastareas()
{
    Console.WriteLine("\nMostrando las tareas pendientes:");
    Tarea.MostrarTareasDeUnaLista(TareasPendientes);
    Console.WriteLine("\nMostrando las tareas realizadas:");
    Tarea.MostrarTareasDeUnaLista(TareasRealizadas);
}

void RevisarTareasPendientes()
{
    Console.WriteLine("\nRevisando las tareas pendientes:");
    foreach (Tarea UnaTarea in TareasPendientes)
    {
        Console.WriteLine($"\nTAREA #{TareasPendientes.IndexOf(UnaTarea) + 1}:");
        UnaTarea.MostrarTarea();
        string? Respuesta;
        do
        {
            Console.Write("\nLa tarea fue realizada? (Y/N): ");
            Respuesta = Console.ReadLine().ToUpper();
        } while (Respuesta != "Y" && Respuesta != "N");
        if (Respuesta == "Y")
        {
            TareasRealizadas.Add(UnaTarea);
        }
    }
    TareasPendientes = TareasPendientes.Except(TareasRealizadas).ToList();
}

void BuscarTareaPendientePorDescripcion()
{
    Console.WriteLine("\nBuscar tarea pendiente:");
    Console.Write("Ingrese la descripción o parte de ella: ");
    string? Busqueda = Console.ReadLine();
    List<Tarea> TareasEncontradas = new();
    foreach (Tarea UnaTarea in TareasPendientes)
    {
        if (UnaTarea.Descripcion.ToLower().Contains(Busqueda.ToLower()))
        {
            TareasEncontradas.Add(UnaTarea);
        }
    }
    if(TareasEncontradas.Count > 0)
    {
        foreach(Tarea UnaTarea in TareasEncontradas)
        {
            Console.WriteLine($"\nTAREA #{TareasEncontradas.IndexOf(UnaTarea) + 1}:");
            UnaTarea.MostrarTarea();
        }
    }
    else
    {
        Console.WriteLine("\nLa búsqueda no arrojó resultados");
    }
}

int HorasTrabajadas()
{
    int TotalDeHorasTrabajadas = 0;
    foreach (Tarea UnaTarea in TareasRealizadas)
    {
        TotalDeHorasTrabajadas += UnaTarea.Duracion;
    }
    return TotalDeHorasTrabajadas;
}