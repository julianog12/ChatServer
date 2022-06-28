namespace ClassUsuario
{
     public class NovoUsuario
    {
        private string _NomeUsuario;
        private string _IpUsuario;
        private string _PortaUsuario;

        public string Nome
        {
            get { return _NomeUsuario;}
            set {_NomeUsuario = value;}
        }
        public string IP
        {
            get { return _IpUsuario; }
            set { _IpUsuario = value; }
        } 
        public string Porta
        {
            get { return _PortaUsuario;}
            set {_PortaUsuario = value;}
        }
        public void VerUsuario()
        {
            Console.WriteLine($"Usuário: {Nome} IP: {IP}  Porta: {Porta}"); 
        }
        public void SolicitarUsuario()
        {
            Console.WriteLine("Informe seu Nome:");
            Nome = Console.ReadLine();
            Console.WriteLine("Informe seu IP:");
            IP = Console.ReadLine();
            Console.WriteLine("Informe sua Porta");
            Porta = Console.ReadLine();
        }
    }
    
}