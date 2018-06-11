using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTE.Services
{
    class ArquivoServices
    {
        public void Listar(FileInfo[] arquivos)
        {
            if (arquivos == null)
            {
                return;
            }

            for (int i = 0; i < arquivos.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {arquivos[i].Name}");
            }
        }
    }
}
