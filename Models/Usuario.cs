namespace TodoApi.Models
{
    public class Usuario
    {
        public int Id {get; set;}
        public string NCliente {get; set;}
        public string DNI {get; set;}
        public int edad {get; set;}
        private int cPuntuacon=0;
        public int CPuntuacon
        {
            get { return cPuntuacon; }   
            
        }
        public string TDescripcion {get; set;}
        
        





    }
}