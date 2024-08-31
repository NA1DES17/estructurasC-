using System.ComponentModel;

public class ArbolBinario<T>
{
  private T dato;
  private ArbolBinario<T> hijoIzquierdo;
  private ArbolBinario<T> hijoDerecho;

  public ArbolBinario(T dato)
  {
    this.dato = dato;
  }
  public T getDatoRaiz()
  {
    return this.dato;
  }
  public ArbolBinario<T> getHijoIzquierdo()
  {
    return this.hijoIzquierdo;
  }
  public void setHijoIzquierdo(ArbolBinario<T> hijoIzquierdo)
  {
    this.hijoIzquierdo = hijoIzquierdo;
  }
  public ArbolBinario<T> getHijoDerecho()
  {
    return this.hijoDerecho;
  }
  public void setHijoDerecho(ArbolBinario<T> hijoDerecho)
  {
    this.hijoDerecho = hijoDerecho;
  }
  public void agregarHijoIzquierdo(ArbolBinario<T> hijo)
  {
    this.hijoIzquierdo = hijo;
  }
  public void agregarHijoDerecho(ArbolBinario<T> hijo)
  {
    this.hijoDerecho = hijo;
  }
  public void eliminarHijoIzquierdo()
  {
    this.hijoIzquierdo = null;
  }
  public void eliminarHijoDerecho()
  {
    this.hijoDerecho = null;
  }
  public bool esHoja()
  {
    return this.hijoIzquierdo == null && this.hijoDerecho == null;
  }

  //-------------------
  public void preorden()
  {
    //Raíz
    Console.Write(this.getDatoRaiz() + " ");
    //Hijo Izquierdo
    if (this.getHijoIzquierdo() != null)
    {
      this.getHijoIzquierdo().preorden();
    }
    //Hijo Derecho
    if (this.getHijoDerecho() != null)
    {
      this.getHijoDerecho().preorden();
    }
  }
  public void inorden()
  {
    //Hijo Izquierdo
    if (this.getHijoIzquierdo() != null)
    {
      this.getHijoIzquierdo().inorden();
    }
    //Raíz
    Console.Write(this.getDatoRaiz() + " ");
    //Hijo Derecho
    if (this.getHijoDerecho() != null)
    {
      this.getHijoDerecho().inorden();
    }
  }
  public void postorden()
  {
    //Hijo Izquierdo
    if (this.getHijoIzquierdo() != null)
    {
      this.getHijoIzquierdo().postorden();
    }
    //Hijo Derecho
    if (this.getHijoDerecho() != null)
    {
      this.getHijoDerecho().postorden();
    }
    //Raíz
    Console.Write(this.getDatoRaiz() + " ");
  }
  public void recorridoPorNiveles()
  {
    Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
    ArbolBinario<T> arbolAux;

    c.encolar(this);

    while (!c.esVacia())
    {
      arbolAux = c.desencolar();
      Console.Write(arbolAux.getDatoRaiz() + " ");
      if (arbolAux.getHijoIzquierdo() != null)
      {
        c.encolar(arbolAux.getHijoIzquierdo());
      }
      if (arbolAux.getHijoDerecho() != null)
      {
        c.encolar(arbolAux.getHijoDerecho());
      }
    }
  }
  //--- Práctica 1 - Ejercicio 5
  public int contarHojas()
  {
    return contarHojas(this);
  }
  private int contarHojas(ArbolBinario<T> nodo)
  {
    if (nodo == null)
      return 0;

    if (nodo.hijoIzquierdo == null && nodo.hijoDerecho == null)
      return 1; // nodo hoja

    return contarHojas(nodo.hijoIzquierdo) + contarHojas(nodo.hijoDerecho);
  }
  //---
  public void recorridoEntreNiveles(int n, int m)
  {
    if (n > m)
    {
      throw new ArgumentException("El nivel n debe ser menor o igual al nivel m.");
    }

    Cola<ArbolBinario<T>> cola = new Cola<ArbolBinario<T>>();
    Cola<int> niveles = new Cola<int>();  // Para llevar el seguimiento de los niveles de cada nodo

    cola.encolar(this);
    niveles.encolar(0);

    while (!cola.esVacia())
    {
      ArbolBinario<T> nodoActual = cola.desencolar();
      int nivelActual = niveles.desencolar();

      if (nivelActual >= n && nivelActual <= m)
      {
        Console.Write(nodoActual.getDatoRaiz() + " ");
      }

      if (nivelActual < m)
      {
        if (nodoActual.getHijoIzquierdo() != null)
        {
          cola.encolar(nodoActual.getHijoIzquierdo());
          niveles.encolar(nivelActual + 1);
        }
        if (nodoActual.getHijoDerecho() != null)
        {
          cola.encolar(nodoActual.getHijoDerecho());
          niveles.encolar(nivelActual + 1);
        }
      }
    }
  }

  //---- Práctica 1 - Ejercicio 4
  public bool incluye(T elemento)
  {
    return incluye(this, elemento);
  }
  private bool incluye(ArbolBinario<T> nodo, T elemento)
  {
    if (nodo == null)
    {
      return false;
    }

    if (nodo.getDatoRaiz().Equals(elemento))
    {
      return true;
    }
    return incluye(nodo.getHijoIzquierdo(), elemento) || incluye(nodo.getHijoDerecho(), elemento);
  }
  //----

/*public ArbolBinario<int> nuevo(ArbolBinario<int> arbol){
    //Creamos el nuevo árbol con el mismo valor de la raíz del árbol original
    ArbolBinario<int> nuevoArbol = new ArbolBinario<int>(arbol.getDatoRaiz());

    //Si el árbol original tiene un HI, crear un nuevo HI
    if (arbol.getHijoIzquierdo() != null) {

      ArbolBinario<int> nuevoHI = new ArbolBinario<int>(arbol.getDatoRaiz() + arbol.getHijoIzquierdo().getDatoRaiz());
      nuevoArbol.agregarHijoIzquierdo(nuevoHI);
    }
    // El hijo derecho del nuevo árbol es una copia directa del hijo derecho del árbol original
    if (arbol.getHijoDerecho() != null)
    {
      ArbolBinario<int> nuevoHD = nuevo(arbol.getHijoDerecho()); // Llamada recursiva
      nuevoArbol.agregarHijoDerecho(nuevoHD);
    }
    return nuevoArbol;
  }*/
  public void nuevo(ArbolBinario<int> arbol)
{
    // Si el árbol está vacío, no hacemos nada
    if (arbol == null)
        return;

    // Primero, procesamos el subárbol izquierdo
    if (arbol.getHijoIzquierdo() != null)
    {
        // Llamada recursiva para el subárbol izquierdo para asegurar que sus nodos se actualicen primero
        nuevo(arbol.getHijoIzquierdo());
        
        // Actualizamos el valor del nodo actual basado en el valor de su hijo izquierdo
        arbol.getHijoIzquierdo().dato = arbol.getDatoRaiz() + arbol.getHijoIzquierdo().getDatoRaiz();
    }

    // Procesamos el hijo derecho
    if (arbol.getHijoDerecho() != null)
    {
        // Llamada recursiva para el subárbol derecho
        nuevo(arbol.getHijoDerecho());
    }
}




}