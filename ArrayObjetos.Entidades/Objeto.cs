namespace ArrayObjetos.Entidades
{
    public class Objeto
    {
        
        private int _medidaLado;
        private TipoDeBorde tipoDeBorde;

        public TipoDeBorde TipoDeBorde
        {
            get { return tipoDeBorde; }
            set { tipoDeBorde = value; }
        }

        private ColorRelleno colorRelleno;

        public ColorRelleno ColorRelleno 
        {
            get { return colorRelleno; }
            set { colorRelleno = value; }
        }


        public Objeto()
        {

        }

        public Objeto(int MedidaLado, TipoDeBorde borde, ColorRelleno relleno) 
        {
                _medidaLado = MedidaLado;
            TipoDeBorde=borde;
            ColorRelleno = relleno;
           
        }
        public bool Validar()
        {
            return _medidaLado > 0;
        }
        public int GetLado() => _medidaLado;
        public void SetLado(int medida)
        {
            if (medida > 0) 
            {
            _medidaLado = medida;
            }
        }

        public double GetVolumen() => 4/3*Math.PI*Math.Pow(_medidaLado, 3);
        public double GetArea()=> 4*Math.PI*Math.Pow(_medidaLado, 2);
    }
}