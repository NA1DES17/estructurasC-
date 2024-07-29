using System;

public class Impresora
{
    private Heap<string> colaDocumentos;

    public Impresora()
    {
        colaDocumentos = new Heap<string>(new string[] { }, false);
    }

    public void nuevoDocumento(string documento)
    {
        colaDocumentos.agregar(documento);
    }

    public void imprime()
    {
        if (!colaDocumentos.esVacia())
        {
            string documentoMasCorto = colaDocumentos.eliminar();
            Console.WriteLine(documentoMasCorto);
        }
    }
}
