namespace TodoApi.Models
{
    public class Tecnico
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
        public int AniosExp {get; set;}
        public int CuentaBanco {get; set;}
        public int CEspecialidad {get; set;}
        
        





    }
}