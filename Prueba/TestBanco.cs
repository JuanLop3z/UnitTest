using Microsoft.VisualStudio.TestTools.UnitTesting;
using CuentaBancoNS;


namespace Prueba
{
    [TestClass]
    public class TestBanconCuenta
    {
        double balanceComienzo = 11.99;

        [TestMethod]
        public void DebitoValidaciondeMonto()
        {


            double montoDebito = 4.55;
            double esperado = 7.44;
            CuentaBanco cuenta = new CuentaBanco("Señor Juan", balanceComienzo);


            cuenta.Debito(montoDebito);


            double actual = cuenta.Balance;
            Assert.AreEqual(esperado, actual, 0.001, "Cuenta no debita correctamente");
        }

        [TestMethod]
        public void DebitoMenorqueCero()
        {
            double DebitoMonto = -100.00;

            CuentaBanco cuenta = new CuentaBanco("Señor Juan", balanceComienzo);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => cuenta.Debito(DebitoMonto));
        }

        [TestMethod]
        public void DebitoMontoMayoraSaldo()
        {
            double DebitoMonto = 100.00;

            CuentaBanco cuenta = new CuentaBanco("Señor Juan", balanceComienzo);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => cuenta.Debito(DebitoMonto));

        }
    }
}