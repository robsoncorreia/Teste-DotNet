using FileHelpers;
using FileHelpers.ExcelNPOIStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTE.Services;

namespace TESTE
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo diretorio = new DirectoryInfo(@"Input");

            FileInfo[] arquivos = diretorio.GetFiles("*", SearchOption.AllDirectories);

            ArquivoServices arquivoServices = new ArquivoServices();

            arquivoServices.Listar(arquivos);

            Console.ReadKey();

            Task[] tasks = new Task[arquivos.Length];

            for (int i = 0; i < arquivos.Length; i++)
            {
                ExcelServices excel = new ExcelServices();
                tasks[i] = new Task(() => excel.Exportar(typeof(Cotacao), arquivos[i].Name));
                tasks[i].Start();
                tasks[i].Wait();
            }           
        }
    }
}
