namespace Cyberplay.Modelos
{
    public class EstacionConfiguracion
    {
        public string IdEstacion
        {
            get;
            set;
        }

        public int NumeroEquipo
        {
            get;
            set;
        }

        public string TipoEquipo
        {
            get;
            set;
        }

        public bool Activa
        {
            get;
            set;
        }
            = true;

        public string DireccionIP
        {
            get;
            set;
        }
    }
}
