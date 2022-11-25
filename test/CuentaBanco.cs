using System;

namespace CuentaBancoNS
{
    public class CuentaBanco
    {

        //Mensaje de error que sera devuelta en casos especificos
        public const string MontoDebitoExcedeBalanceMensaje = "El monto excede el balance";
        public const string MontoDebitoMenorCeroMensaje = "El monto de debito es menor a cero";

        //readonly se usa para asignar un valor solo atravez de un constructor en este caso es NombreCliente Abajo
        private readonly string m_nombreCliente;
        private double m_balance;

        private CuentaBanco()
        {
        
        }
        //Constructor
        public CuentaBanco(string nombreCliente, double balance)
        {
            m_nombreCliente = nombreCliente;
            m_balance = balance;
        }
        
        public string NombreCliente
        {
            get { return m_nombreCliente; }
        }

        public double Balance
        {
            get { return m_balance; }
        }


        //metodo debito que sera evaluado
        public void Debito(double monto)
        {   //si el monto es mayor al balance
            if (monto > m_balance)
            {   //En caso de una excepcion fuera de rango se le pasa como parametro el nombr, la variable y el mensaje que devolvera
                throw new ArgumentOutOfRangeException("monto",monto,MontoDebitoExcedeBalanceMensaje);
            }
            //si el monto es menor a cero(saldo)
            if (monto < 0)
            {
                throw new ArgumentOutOfRangeException("monto", monto, MontoDebitoMenorCeroMensaje);
            }

            m_balance -= monto;
        }


        public static void Main()
        {
            //Se crea un objeto y se asignan sus atributos s

            CuentaBanco ba = new CuentaBanco("Señor juan", 11.99);

            ba.Debito(11.22);
            Console.WriteLine("Saldo actual es ${0}", ba.Balance);
        }
    }
}

