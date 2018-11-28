using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Oficina.Repositorios.SistemaArquivos
{
  public  class MarcaRepositorio
    {
        private string caminhoArquivo = ConfigurationManager.AppSettings["caminhoArquivoMarca"];

        public List<Marca> Selecionar()
        {
            var marcas = new List<Marca>();

            foreach (var item in File.ReadAllLines(caminhoArquivo))
            {
                var propriedades = item.Split('|');
                var marca = new Marca();

                marca.Id = Convert.ToInt32(propriedades[0]);//Onde Finaliza
                marca.Nome = propriedades[1];//Onde inicia

                marcas.Add(marca);
            }
            return marcas;
        }

        public Marca Selecionar(int id)
        {
            Marca marca = null;

            foreach (var item in File.ReadAllLines(caminhoArquivo))
            {
                var propriedades = item.Split('|');
                if (Convert.ToUInt32(propriedades[0]) == id)
                {
                    
                    marca = new Marca();

                    marca.Id = Convert.ToInt32(propriedades[0]);//Onde Finaliza
                    marca.Nome = propriedades[1];//Onde inicia
                    break;
                }
            }

            return marca;
        }
    }
}
