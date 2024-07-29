using System.IO.Compression;

public class ArbolGeneral<T>
{
  private T dato;
  private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();
  public ArbolGeneral(T dato)
  {
    this.dato = dato;
  }
  public T getDatoRaiz()
  {
    return this.dato;
  }
  public List<ArbolGeneral<T>> getHijos()
  {
    return hijos;
  }
  public int cantHijos()
  {
    return hijos.Count();
  }
  public void agregarHijo(ArbolGeneral<T> hijo)
  {
    this.getHijos().Add(hijo);
  }
  public void eliminarHijo(ArbolGeneral<T> hijo)
  {
    this.getHijos().Remove(hijo);
  }
  public bool esHoja()
  {
    return this.getHijos().Count == 0;
  }
  public void preOrden()
  {
    //proceso primero la raíz
    Console.Write(this.getDatoRaiz() + " ");
    //Luego procesamos los hijos recursivamente
    foreach (var hijo in this.getHijos())
    {
      hijo.preOrden();
    }
  }
  public void postOrden()
  {
    //Procesamos los hijos recursivamente
    foreach (var hijo in this.getHijos())
    {
      hijo.postOrden();
    }
    //proceso después la raíz
    Console.Write(this.getDatoRaiz() + " ");
  }
  public void inOrden()
  {
    if (this.hijos.Count > 0)
    {
      // Procesamos el primer hijo
      this.hijos[0].inOrden();
    }

    // Procesamos la raíz
    Console.Write(this.getDatoRaiz() + " ");

    // Procesamos los hijos restantes
    for (int i = 1; i < this.hijos.Count; i++)
    {
      this.hijos[i].inOrden();
    }
  }
  public void porNiveles()
  {
    Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
    ArbolGeneral<T> arbolAux;

    c.encolar(this);

    while (!c.esVacia())
    {
      arbolAux = c.desencolar();
      Console.Write(arbolAux.getDatoRaiz() + " ");
      foreach (var hijo in arbolAux.getHijos())
      {
        c.encolar(hijo);
      }
    }
  }
  public void porNivelesConSeparador()
  {
    Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
    ArbolGeneral<T> arbolAux;

    c.encolar(this);
    c.encolar(null); // Marcador de fin de nivel

    while (!c.esVacia())
    {
      arbolAux = c.desencolar();

      if (arbolAux == null)
      {
        // Fin de un nivel, inserta un separador
        if (!c.esVacia())
        {
          Console.WriteLine(); // O usar cualquier otro separador, por ejemplo, "-"
          c.encolar(null); // Marcador para el siguiente nivel
        }
      }
      else
      {
        Console.Write(arbolAux.getDatoRaiz() + " ");
        foreach (var hijo in arbolAux.getHijos())
        {
          c.encolar(hijo);
        }
      }
    }
  }

  //Práctica 2 - Ejercicio 4
  public int altura()
  {
    // Caso base: si el árbol es una hoja, su altura es 0
    if (this.esHoja())
    {
      return 0;
    }

    // Variable para mantener la altura máxima entre todos los hijos
    int alturaMaxima = 0;

    // Recorremos todos los hijos y calculamos sus alturas
    foreach (var hijo in this.getHijos())
    {
      // Calculamos la altura del hijo
      int alturaHijo = hijo.altura();

      // Si la altura del hijo es mayor que la altura máxima actual,
      // actualizamos la altura máxima
      if (alturaHijo > alturaMaxima)
      {
        alturaMaxima = alturaHijo;
      }
    }

    // La altura del árbol es la altura máxima de sus hijos más uno (por la raíz)
    return alturaMaxima + 1;
  }

  public int ancho()
  {
    if (this.esHoja())
    {
      return 1;
    }

    // Cola para realizar el recorrido por niveles
    Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
    c.encolar(this);

    int maxAncho = 0;

    while (!c.esVacia())
    {
      int nivelAncho = c.cantidad(); // Número de nodos en el nivel actual
      if (nivelAncho > maxAncho)
      {
        maxAncho = nivelAncho;
      }

      // Procesar todos los nodos en el nivel actual
      for (int i = 0; i < nivelAncho; i++)
      {
        ArbolGeneral<T> arbolAux = c.desencolar();
        foreach (var hijo in arbolAux.getHijos())
        {
          c.encolar(hijo);
        }
      }
    }

    return maxAncho;
  }

  public int nivel(T dato)
  {
    // Cola para realizar el recorrido por niveles
    Cola<(ArbolGeneral<T> arbol, int nivel)> c = new Cola<(ArbolGeneral<T> arbol, int nivel)>();
    c.encolar((this, 0)); // Encolamos la raíz con nivel 0

    while (!c.esVacia())
    {
      var (arbolAux, nivelActual) = c.desencolar();

      // Verificamos si el nodo actual contiene el dato buscado
      if (arbolAux.getDatoRaiz().Equals(dato))
      {
        return nivelActual;
      }

      // Encolamos los hijos con el nivel incrementado en 1
      foreach (var hijo in arbolAux.getHijos())
      {
        c.encolar((hijo, nivelActual + 1));
      }
    }

    // Si no encontramos el dato, devolvemos -1 (indicando que el dato no está en el árbol)
    return -1;
  }
}