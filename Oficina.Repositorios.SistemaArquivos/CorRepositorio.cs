using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos
{
    
    public class CorRepositorio
    {
        const string caminhoArquivo = "Dados\\Cor.txt";

        public List<Cor>Selecionar()
        {
            var cores = new List<Cor>();

            foreach (var item in File.ReadAllLines(caminhoArquivo))
            {
                var cor = new Cor();
                cor.Id = Convert.ToInt32(item.Substring(0,5));//Onde Finaliza
                cor.Nome = item.Substring(5);//Onde inicia

                cores.Add(cor);
            }
            return cores;
        }



        public Cor Selecionar(int id)
        {
            Cor cor = null;

            foreach (var item in File.ReadAllLines(caminhoArquivo))
            {
                var linhaId = item.Substring(0, 5);
                if (Convert.ToUInt32(linhaId) == id)
                {
                    cor = new Cor();

                    cor.Id = Convert.ToInt32(item.Substring(0, 5));//Onde Finaliza
                    cor.Nome = item.Substring(5);//Onde inicia
                    break;
                }
            }

            return cor;
        }

    }
}
