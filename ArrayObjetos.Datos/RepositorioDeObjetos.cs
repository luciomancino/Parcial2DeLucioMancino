using ArrayObjetos.Entidades;

namespace ArrayObjetos.Datos
{
    public class RepositorioDeObjetos
    {
        private readonly string _archivo = Environment.CurrentDirectory + "\\Objetos.txt";
        private readonly string _archivoCopia = Environment.CurrentDirectory + "\\Objetos.bak";

        private List<Objeto> listaObjetos;

        public RepositorioDeObjetos()
        {
            listaObjetos = new List<Objeto>();
            LeerDatos();
        }

        public List<Objeto> GetLista()
        {
            return listaObjetos;
        }

        private void LeerDatos()
        {
            if (File.Exists(_archivo))
            {
                var lector = new StreamReader(_archivo);
                while (!lector.EndOfStream)
                {
                    string lineaLeida = lector.ReadLine();
                    Objeto objeto = ConstruirObjeto(lineaLeida);
                    listaObjetos.Add(objeto);
                }
                lector.Close();
            }
        }

        public void Editar(int ladoAnterior, Objeto objetoEditar)
        {
            using(var lector=new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        string linealeida=lector.ReadLine();
                        Objeto objeto = ConstruirObjeto(linealeida);
                        if (ladoAnterior != objeto.GetLado())
                        {
                            escritor.WriteLine(linealeida);
                        }
                        else
                        {
                            linealeida = ConstruirLinea(objetoEditar);
                            escritor.WriteLine(linealeida);
                        }
                    }
                }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
        }
        private Objeto ConstruirObjeto(string? lineaLeida)
        {
           var campos= lineaLeida.Split('|');
            int lado = int.Parse(campos[0]);
            TipoDeBorde borde =(TipoDeBorde)int.Parse(campos[1]);
            ColorRelleno color =(ColorRelleno) int.Parse(campos[2]);

            Objeto c = new Objeto(lado, borde, color);
            return c;
           
        }

        public void Agregar(Objeto objeto)
        {
            var escritor = new StreamWriter(_archivo, true);
            
                string lineaEscribir = ConstruirLinea(objeto);
                escritor.WriteLine(lineaEscribir);
                escritor.Close();

            
                listaObjetos.Add(objeto);
            
        }

        private string ConstruirLinea(Objeto objeto)
        {
            return $"{objeto.GetLado()}|{objeto.TipoDeBorde.GetHashCode()}|{objeto.ColorRelleno.GetHashCode()}";
        }

        public int GetCantidad(int valorFiltro=0)
        {
            if(valorFiltro>0)
            {
                return listaObjetos.Count(c => c.GetLado() >= valorFiltro);
            }
            return listaObjetos.Count;
        }
        public void Borrar(Objeto objetoBorrar)
        {
            using(var lector=new StreamReader(_archivo))
            {
                using(var escritor=new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida=lector.ReadLine();
                        Objeto objetoLeido = ConstruirObjeto(lineaLeida);
                        if (objetoBorrar.GetLado() != objetoLeido.GetLado())
                        {
                            escritor.WriteLine(lineaLeida);
                        }
                    }
                }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
            listaObjetos.Remove(objetoBorrar);
        }

        public List<Objeto> Filtrar(int intValor)
        {
            return listaObjetos.Where(c=>c.GetLado()>=intValor).ToList();
        }

        public bool Existe(Objeto objeto)
        {
            bool existe = false;
            foreach(var itemObjeto in listaObjetos)
            {
                if (itemObjeto.GetLado()==objeto.GetLado())
                {
                    return true;
                }
            }
            return false;
        }
    }
}