using System.Security.Cryptography.X509Certificates;

class Program
{
  public static void Main(string[] args)
  {
    static void pruebaCola()
    {
      //Prueba Cola
      Cola<int> cola = new Cola<int>();

      for (int i = 0; i < 7; i++)
      {
        cola.encolar(i + 7);
        //Console.WriteLine($"El valor agregado fue el: {(i + 7)}");
      }
    }
    static void pruebaArbolGeneral()
    {
      //Prueba Árbol General
      //Raíz
      ArbolGeneral<int> miArbol = new ArbolGeneral<int>(7);
      //Primer nivel
      ArbolGeneral<int> hijo1 = new ArbolGeneral<int>(17);
      ArbolGeneral<int> hijo2 = new ArbolGeneral<int>(27);
      ArbolGeneral<int> hijo3 = new ArbolGeneral<int>(47);
      //Unimos la raíz a los hijos
      miArbol.agregarHijo(hijo1);
      miArbol.agregarHijo(hijo2);
      miArbol.agregarHijo(hijo3);

      //Segundo nivel
      for (int i = 0; i < 3; i++)
      {
        hijo1.agregarHijo(new ArbolGeneral<int>(i + 7));
        hijo2.agregarHijo(new ArbolGeneral<int>(i + 17));
        hijo3.agregarHijo(new ArbolGeneral<int>(i + 27));
      }

      //Test de árbol
      Console.WriteLine("\nRercorrido preOrden: ");
      miArbol.preOrden();
      Console.WriteLine("\nRercorrido postOrden: ");
      miArbol.postOrden();
      Console.WriteLine("\nRercorrido inOrden: ");
      miArbol.inOrden();
      Console.WriteLine("\nRercorrido por Niveles: ");
      miArbol.porNiveles();
      Console.WriteLine("\nRercorrido por Niveles: ");
      miArbol.porNivelesConSeparador();
      Console.WriteLine($"\nLa altura del árbol es {miArbol.altura()}");
      Console.WriteLine($"\nEl ancho del árbol es {miArbol.ancho()}");

      Console.Write("Ingrese el dato que quiere encontrar: ");
      int dato = int.Parse(Console.ReadLine());
      Console.Write($"El dato {dato} se encuentra en el nivel {miArbol.nivel(dato)}");
    }
    static void prubaArbolBinario()
    {
      //Prueba Árbol Binario
      //Raíz
      ArbolBinario<int> miArbol = new ArbolBinario<int>(7);

      ArbolBinario<int> hijo1 = new ArbolBinario<int>(10);
      ArbolBinario<int> hijo2 = new ArbolBinario<int>(17);

      ArbolBinario<int> hijo3 = new ArbolBinario<int>(3);
      ArbolBinario<int> hijo4 = new ArbolBinario<int>(47);
      ArbolBinario<int> hijo5 = new ArbolBinario<int>(5);
      ArbolBinario<int> hijo6 = new ArbolBinario<int>(27);

      //Agregar hijos de la raíz
      miArbol.agregarHijoIzquierdo(hijo1);
      miArbol.agregarHijoDerecho(hijo2);
      //Agregar hijos del H. Izq
      hijo1.agregarHijoIzquierdo(hijo3);
      hijo1.agregarHijoDerecho(hijo4);
      //Agregar hijos del H. Der
      hijo2.agregarHijoIzquierdo(hijo5);
      hijo2.agregarHijoDerecho(hijo6);
      //Agregar hijos de H3
      hijo3.agregarHijoIzquierdo(new ArbolBinario<int>(1));
      hijo3.agregarHijoDerecho(new ArbolBinario<int>(2));
      //Agregar hijos de H4
      hijo4.agregarHijoIzquierdo(new ArbolBinario<int>(0));
      hijo4.agregarHijoDerecho(new ArbolBinario<int>(8));

      //Test de recorridos
      Console.WriteLine("Recorrido preOrden: ");
      miArbol.preorden();
      Console.WriteLine("\nRecorrido inOrden: ");
      miArbol.inorden();
      Console.WriteLine("\nRecorrido postOrden: ");
      miArbol.postorden();
      Console.WriteLine("\nRecorrido Por niveles: ");
      miArbol.recorridoPorNiveles();
      Console.Write("\nCantidad de hojas: ");
      Console.WriteLine(miArbol.contarHojas());
      Console.WriteLine("Recorrido entre niveles: ");
      miArbol.recorridoEntreNiveles(1, 3);
      Console.Write("\n¿Que dato quiere saber si está? ");
      int dato = int.Parse(Console.ReadLine());
      Console.WriteLine($"\nEl árbol contiene el {dato}? {miArbol.incluye(dato)}");
    }
    static void pruebaHeap()
    {
      /*
      //Prueba Heap
      //Raíz
      Heap<int> miHeap = new Heap<int>();
      miHeap.agregar(50);
      //Prueba de recorridos
      System.Console.WriteLine("--------------------------------");
      Console.WriteLine("Recorrido: ");
      miHeap.recorrido();
      miHeap.agregar(52);
      //Prueba de recorridos
      System.Console.WriteLine("--------------------------------");
      Console.WriteLine("Recorrido: ");
      miHeap.recorrido();
      miHeap.agregar(41);
      //Prueba de recorridos
      System.Console.WriteLine("--------------------------------");
      Console.WriteLine("Recorrido: ");
      miHeap.recorrido();
      miHeap.agregar(54);
      //Prueba de recorridos
      System.Console.WriteLine("--------------------------------");
      Console.WriteLine("Recorrido: ");
      miHeap.recorrido();
      miHeap.eliminar();
      //Prueba de recorridos
      System.Console.WriteLine("--------------------------------");
      Console.WriteLine("Recorrido: ");
      miHeap.recorrido();
      System.Console.WriteLine("\n");*/

      int[] arreglo = { 50, 52, 41, 54, 46 };

      Heap<int> maxHeap = new Heap<int>(arreglo, true);
      maxHeap.recorrido();
      System.Console.WriteLine("--------------------------------");
      System.Console.WriteLine("\n");
      Heap<int> minHeap = new Heap<int>(arreglo, false);
      minHeap.recorrido();

    }
    static void pruebaGrafo()
    {
      //Prueba Grafo
    }
    static void PracticaUno()
    {
      //Ejercicio 8
      ArbolBinario<string> menos = new ArbolBinario<string>("-");
      ArbolBinario<string> izMas = new ArbolBinario<string>("+");
      ArbolBinario<string> derMas = new ArbolBinario<string>("+");
      ArbolBinario<string> a = new ArbolBinario<string>("a");
      ArbolBinario<string> b = new ArbolBinario<string>("b");
      ArbolBinario<string> e = new ArbolBinario<string>("e");
      ArbolBinario<string> c = new ArbolBinario<string>("c");
      ArbolBinario<string> d = new ArbolBinario<string>("d");
      ArbolBinario<string> mult = new ArbolBinario<string>("*");

      menos.agregarHijoIzquierdo(izMas);
      menos.agregarHijoDerecho(derMas);

      izMas.agregarHijoDerecho(b);
      izMas.agregarHijoIzquierdo(a);

      derMas.agregarHijoIzquierdo(mult);
      derMas.agregarHijoDerecho(e);

      mult.agregarHijoIzquierdo(c);
      mult.agregarHijoDerecho(d);

      System.Console.Write("Recorrido preOrden: ");
      menos.preorden();
      System.Console.WriteLine("\n");
      System.Console.Write("Recorrido postOrden: ");
      menos.postorden();
      System.Console.WriteLine("\n");
      System.Console.Write("Recorrido inOrden: ");
      menos.inorden();
      System.Console.WriteLine("\n");
    }
    static void PracticaDos()
    {
      Heap<int> miHeap = new Heap<int>([], true);
      System.Console.WriteLine("A");
      miHeap.agregar(50);
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.agregar(52);
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.agregar(41);
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.agregar(54);
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.agregar(46);
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      System.Console.WriteLine("B");
      miHeap.eliminar();
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.eliminar();
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.eliminar();
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      System.Console.WriteLine("C");
      miHeap.agregar(45);
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.agregar(48);
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.agregar(55);
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.agregar(43);
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      System.Console.WriteLine("D");
      miHeap.eliminar();
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.eliminar();
      miHeap.recorrido();
      System.Console.WriteLine("______________");
      miHeap.eliminar();
      miHeap.recorrido();
      System.Console.WriteLine("______________");

    }
    //pruebaArbolGeneral();
    //pruebaCola();
    //pruebaArbolBinario();
    //pruebaHeap();
    //PracticaUno();
    //PracticaDos();

    ArbolGeneral<int> miArbol = new ArbolGeneral<int>(1000);

    //int uno = miArbol.getDatoRaiz() / miArbol.cantHijos();
    
    ArbolGeneral<int> hijo1 = new ArbolGeneral<int>(0);
    ArbolGeneral<int> hijo2 = new ArbolGeneral<int>(0);
    ArbolGeneral<int> hijo3 = new ArbolGeneral<int>(0);
    ArbolGeneral<int> hijo4 = new ArbolGeneral<int>(0);

    miArbol.agregarHijo(hijo1);
    //miArbol.agregarHijo(hijo2);
    //miArbol.agregarHijo(hijo3);
    //miArbol.agregarHijo(hijo4);
    System.Console.WriteLine(miArbol.cantHijos());
    miArbol.agregarHijo(new ArbolGeneral<int>(miArbol.getDatoRaiz() / miArbol.cantHijos()));
    miArbol.agregarHijo(new ArbolGeneral<int>(miArbol.getDatoRaiz() / miArbol.cantHijos()));
    miArbol.agregarHijo(new ArbolGeneral<int>(miArbol.getDatoRaiz() / miArbol.cantHijos()));
    miArbol.agregarHijo(new ArbolGeneral<int>(miArbol.getDatoRaiz() / miArbol.cantHijos()));

    System.Console.WriteLine("--------------------------");
    miArbol.porNivelesConSeparador();

  }

}