using System;
using System.Collections.Generic;

public class Heap<T> where T : IComparable<T>
{
    private List<T> datos;
    private int cantElem;
    private bool esMaxHeap;

    // Constructor base de la clase
    public Heap()
    {
        datos = new List<T> { default(T) }; // El índice 0 no se usa para facilitar los cálculos
        cantElem = 0;
        this.esMaxHeap = true;
    }

    //Constructor del TP
    public Heap(T[] arreglo, bool esMaxHeap)
    {
        datos = new List<T> { default(T) };
        cantElem = arreglo.Length;
        this.esMaxHeap = esMaxHeap;
        this.esMaxHeap = esMaxHeap;

        // Agrega los elementos del arreglo a la lista de datos
        foreach (T elemento in arreglo)
        {
            datos.Add(elemento);
        }
        // Reordena los elementos para formar el tipo de Heap correspondiente
        for (int i = cantElem / 2; i >= 1; i--)
        {
            filtradoHaciaAbajo(i);
        }
    }

    // Getters
    public int GetCantidadElementos()
    {
        return this.cantElem;
    }
    private int GetIndexHijoIzquierdo(int indexElem)
    {
        return 2 * indexElem;
    }
    private int GetIndexHijoDerecho(int indexElem)
    {
        return 2 * indexElem + 1;
    }
    private int GetIndexPadre(int indexElem)
    {
        return indexElem / 2;
    }

    //Métodos públicos
    public bool agregar(T elemento)
    {
        datos.Add(elemento); // Agrega 'elemento' al final de la lista
        cantElem++; // Incrementa la cantidad de elementos
        filtradoHaciaArriba(cantElem); // Realiza el filtrado hacia arriba
        return true;
    }
    public T eliminar()
    {
        if (esVacia()) // Verifica si la lista está vacía
        {
            throw new InvalidOperationException("La Heap está vacía"); // Lanza una excepción si la lista esta vacía
        }
        else
        {
            T elemento = datos[1]; // Guarda el elemento a eliminar
            datos[1] = datos[cantElem]; // Mueve el último elemento a la raíz
            datos.RemoveAt(cantElem); // Elimina el último elemento de la lista
            cantElem--; // Decrementa la cantidad de elementos
            filtradoHaciaAbajo(1); // Realiza el filtrado hacia abajo
            return elemento; // Devuelve el elemento eliminado
        }
    }
    public bool esVacia()
    {
        return cantElem == 0; // Si no hay elementos en la Heap
    }
    public T tope()
    {
        if (esVacia()) // Verifica si la lista está vacía
        {
            throw new InvalidOperationException("La Heap está vacía"); // Lanza una excepción si la lista esta vacía
        }
        return datos[1]; // Devuelve el tope
    }
    public void recorrido()
    {
        for (int i = 1; i <= cantElem; i++)
        {
            T dato = datos[i];
            T hijoIzq = default(T);
            T hijoDer = default(T);
            string hijoIzqStr = "NULL";
            string hijoDerStr = "NULL";

            if (2 * i <= cantElem)
            {
                hijoIzq = datos[2 * i];
                hijoIzqStr = hijoIzq.ToString();
            }

            if (2 * i + 1 <= cantElem)
            {
                hijoDer = datos[2 * i + 1];
                hijoDerStr = hijoDer.ToString();
            }

            Console.WriteLine($"Dato: {dato}, H.I: {hijoIzqStr}, H.D: {hijoDerStr}");
        }
    }
    
    //Métodos privados
    // Método para mantener la propiedad de orden hacia arriba
    private void filtradoHaciaArriba(int index)
    {
        while (index > 1) // Recorrer mientras no se llegue a la raíz
        {
            int indicePadre = GetIndexPadre(index); // Calcula el índice del padre
            int comparacion = datos[indicePadre].CompareTo(datos[index]);
            if ((esMaxHeap && comparacion < 0) || (!esMaxHeap && comparacion > 0))
            {
                // Intercambia el padre y el hijo
                T aux = datos[indicePadre];
                datos[indicePadre] = datos[index];
                datos[index] = aux;
            }
            else // Si no es necesario intercambiar, termina el bucle
            {
                break;
            }
            index = indicePadre; // Actualiza el índice para seguir recorriendo hacia arriba
        }
    }

    // Método para mantener la propiedad de orden hacia abajo
    private void filtradoHaciaAbajo(int index)
{
    while (true)
    {
        int indiceHijoIzq = GetIndexHijoIzquierdo(index);
        int indiceHijoDer = GetIndexHijoDerecho(index);
        int mejorIndice = index;

        if (indiceHijoIzq <= cantElem)
        {
            int comparacionIzq = datos[indiceHijoIzq].CompareTo(datos[mejorIndice]);
            if ((esMaxHeap && comparacionIzq > 0) || (!esMaxHeap && comparacionIzq < 0))
            {
                mejorIndice = indiceHijoIzq;
            }
        }

        if (indiceHijoDer <= cantElem)
        {
            int comparacionDer = datos[indiceHijoDer].CompareTo(datos[mejorIndice]);
            if ((esMaxHeap && comparacionDer > 0) || (!esMaxHeap && comparacionDer < 0))
            {
                mejorIndice = indiceHijoDer;
            }
        }

        if (mejorIndice != index)
        {
            T aux = datos[index];
            datos[index] = datos[mejorIndice];
            datos[mejorIndice] = aux;
            index = mejorIndice;
        }
        else
        {
            break;
        }
    }
}

}
