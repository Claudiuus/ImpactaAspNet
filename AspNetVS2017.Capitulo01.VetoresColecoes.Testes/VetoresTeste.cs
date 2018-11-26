using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNetVS2017.Capitulo01.VetoresColecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {

            var strings = new string[10];
            strings[0] = "teste";
            strings[1] = "teste2";

            var decimais = new decimal[] { 0.5m, 78, 1.59m };
            Console.WriteLine("primeiro vetor: "+strings[0]+"\n"+
                              "segundo vetor: "+strings[1]);

            //decimal[] novoDecimais = { 2,3,5.9m};

            foreach (var item in decimais)
            {
                Console.WriteLine(""+item);
            }
            Console.WriteLine($"Tamanho do vetor: { decimais.Length}");
        }
        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.5m, 78, 1.59m };
            Array.Resize(ref decimais,5);
            decimais[3] = 20.01m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 35.89m, 0.5m, 78, 1.59m };

            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], 0.5m);
        }

        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new decimal[]{ 35.89m, 0.5m, 78, 1.59m };
            Console.WriteLine(ObterMedia(decimais));
        }

        [TestMethod]
        public void TodaStringEhUmVetor()
        {
            const string nome = "Hejlsberg";

            Assert.AreEqual(nome[0], 'H');

            foreach (var item in nome)
            {
                Console.WriteLine(item); 
            }

        }

        private decimal Media(Decimal Val, Decimal val2)
        {
            return (Val + val2)/2;
        }

        private decimal ObterMedia(decimal[] decimais)
        {
            decimal media = 0;
            //percorre  vetor
            var aux = decimais.Length;
            decimal total = 0;

            foreach (var item in decimais)
            {
                total += item;
            }
            media = total / aux;
            return media;
            //return decimais.Average();
        }
    }
}
