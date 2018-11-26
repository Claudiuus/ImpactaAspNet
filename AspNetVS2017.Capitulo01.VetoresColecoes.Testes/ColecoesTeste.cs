using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AspNetVS2017.Capitulo01.VetoresColecoes.Testes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTest()
        {
            var inteiros = new List<int>(50) { 2,1,2,6,125};
            inteiros.Add(22);

            var maisInteiros = new List<int> { 21, 72, 14,6 };

            inteiros.AddRange(maisInteiros);
            inteiros.Insert(0, 29);
            inteiros.Remove(2);
            inteiros.RemoveAt(5);
            inteiros.Sort();

            var primeiro = inteiros.FirstOrDefault();
            var ultimo = inteiros.LastOrDefault();
            var estahVazia = inteiros.Count == 0;



            foreach (var item in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(item)}:{item}");
            }

            for (int i = 0; i < inteiros.Count; i++)
            {
                Console.WriteLine($"para cada ={i}:{inteiros[i]}");
            }
        }
        [TestMethod]
        public void DictionaryTeste()
        {
            var feriado = new Dictionary<DateTime,string>();

            feriado.Add(new DateTime(2018, 12, 25), "NATAL");
            feriado.Add(new DateTime(2019, 01, 01), "Ano novo");
            feriado.Add(new DateTime(2019, 1, 27), "Niver de sp");


            var natal = feriado[new DateTime(2018,12,25)];

            foreach (var item in feriado)
            {
               // Console.WriteLine(string.Format("{0}: {1}", item.Key, item.Value));
                Console.WriteLine(string.Format("{0}: {1}", item.Key.ToString("dd/MM"), item.Value));
            }

            Console.WriteLine(feriado.ContainsKey(Convert.ToDateTime("25/12/2018")));
            Console.WriteLine(feriado.ContainsValue("Ano Novo"));
        }
    }
}
