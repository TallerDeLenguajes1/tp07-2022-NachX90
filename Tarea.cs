class Tarea
{
    Random Aleatorio = new();
    public List<string> Descripciones = new()
    {
        "Controlar personal",
        "Reparar maquinaria",
        "Atender cliente",
        "Fabricar producto"
    };

    public int ID;              //Numerado en ciclo iterativo
    public string? Descripcion; //Obtenido de la lista Descripciones
    public int Duracion;        //Entre 10 y 100

    public void MostrarTarea()
    {
        Console.WriteLine($"  ID:\t\t{ID}");
        Console.WriteLine($"  Descripción:\t{Descripcion}");
        Console.WriteLine($"  Duración:\t{Duracion}");
    }

    static public void MostrarTareasDeUnaLista(List<Tarea> Lista)
    {
        if (Lista.Count == 0)
        {
            Console.WriteLine("\nNo hay tareas en esta lista :)");
        }
        else
        {
            foreach (Tarea UnaTarea in Lista)
            {
                Console.WriteLine($"\nTAREA #{Lista.IndexOf(UnaTarea)+1}:");
                UnaTarea.MostrarTarea();
            }
        }
    }
}
