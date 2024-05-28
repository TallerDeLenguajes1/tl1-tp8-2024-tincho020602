using System;

public class Tarea
{
    int TareaID; // Numérico autoincremental comenzando en 1000
    string Descripcion; //
    int Duracion; // entre 10 – 100
}

class Nodo
{
    public Tarea Tarea { get; set; }
    public Nodo Siguiente { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Nodo pendientes = CrearListaVacia();
        cargarTarea(ref pendientes);
    }

    static Nodo CrearListaVacia()
    {
        return null;
    }

    static int generarID(Nodo inicio)
    {
        if (inicio == null)
        {
            return 1000;
        }

        Nodo aux = inicio; 
        if (aux.Siguiente == null)
        {
            return 1000;
        }
        else
        {
            while (aux.Siguiente != null)
            {
                aux = aux.Siguiente;
            }

            return aux.Tarea.TareaID + 1;
        }
    }

    static Tarea CrearTarea(Nodo inicio)
    {
        Random random = new Random();
        string descripcion = Console.ReadLine("Agregue una descripcion: ");
        Tarea tarea = new Tarea();
        tarea.TareaID = generarID(inicio);
        tarea.Descripcion = descripcion;
        tarea.Duracion = random.Next(91) + 10;
        return tarea;
    }

    static Nodo CrearNodo(Tarea datos)
    {
        Nodo nuevoNodo = new Nodo();
        nuevoNodo.Tarea = datos;
        nuevoNodo.Siguiente = null;
        return nuevoNodo;
    }

    static void insertarUltimo(ref Nodo inicio, Nodo nuevoNodo)
    {
        nuevoNodo.Siguiente = inicio;
        inicio = nuevoNodo;
    }

    static void cargarTarea(ref Nodo inicio)
    {
        int bandera;
        do
        {
            Tarea nuevaTarea = CrearTarea(inicio);
            Nodo nuevoNodo = CrearNodo(nuevaTarea);
            if (inicio == null)
            {
                inicio = nuevoNodo;
            }
            else
            {
                insertarUltimo(ref inicio, nuevoNodo);
            }

            Console.Write("Desea cargar otra tarea? Ingrese 1:si o 0:no: ");
            bandera = int.Parse(Console.ReadLine());
        } while (bandera != 1);
    }
}
