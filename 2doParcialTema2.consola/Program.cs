using ArrayObjetos.Entidades;

namespace _2doParcialTema2.consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Objeto[] arrayObjetos = new Objeto[5];
            for (int i = 0; i < arrayObjetos.Length; i++)
            {
                do
                {



                    Console.Write("Ingrese la medida del lado:");
                    var lado = int.Parse(Console.ReadLine());
                    Objeto objetocreado = new Objeto(lado);
                    if (objetocreado.Validar())
                    {
                        arrayObjetos[i] = objetocreado;
                        break;
                    }
                    else
                    {
                        Console.Write("cuadrado no valido");
                    }
                } while (true);
            }
            Console.WriteLine("Array Lleno");
            Console.Clear();
            foreach (var item in arrayObjetos)
            {
                Console.WriteLine($"Cuadrado de lado {item.GetLado()} - Sup:{item.GetSuperficie()} - Per:{item.GetPerimetro()}");

            }

            Console.WriteLine("ingrese el nro cuadrado a modificar");
                var index=int.Parse(Console.ReadLine());
                var objetoEditar = arrayObjetos[index];
                Console.Write("ingrese nueva medida:");
                var nuevaMedida = int.Parse(Console.ReadLine());
                objetoEditar.SetLado(nuevaMedida);
        }
    }
}