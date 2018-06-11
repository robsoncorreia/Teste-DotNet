using FileHelpers;
using FileHelpers.ExcelNPOIStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TESTE.Services
{
    class ExcelServices
    {
        private ExcelNPOIStorage CriarExcel(Type tipo, string nomeArquivo)
        {
            
            ExcelNPOIStorage  arquivo = new ExcelNPOIStorage(tipo);

            //O nome do arquivo excel ficará com mesmo nome do arquivo lido no diretório input
            arquivo.FileName = $"{nomeArquivo.Substring(0, nomeArquivo.IndexOf("."))}.xlsx";

            //O nome da tabela tem o mesmo da classe
            arquivo.SheetName = nameof(tipo);

            //Obtem-se os atributos da classe passada como parametro no metódo
            PropertyInfo[] props = tipo.GetProperties();


            foreach (var item in props)
            {
                MemberInfo property = tipo.GetProperty(item.Name);
                var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                                        .Cast<DisplayNameAttribute>().Single();
                string displayName = attribute.DisplayName;
               //O Dispaly dos atributos da classe são usados para criar o nome das colunas do arquivo excel
                arquivo.ColumnsHeaders.Add(displayName);
            }
            return arquivo;
        }

        public void Exportar(Type tipo, string nomeArquivo)
        {

            if (tipo == null || nomeArquivo == null)
            {
                return;
            }

            var engine = new FileHelperEngine<Cotacao>();


            ExcelNPOIStorage arquivo = CriarExcel(tipo, nomeArquivo);

            List<Cotacao> cotacoes = new List<Cotacao>();

            var records = engine.ReadFile(@"Input\" + nomeArquivo);

            foreach (var record in records)
            {
                cotacoes.Add(
                    new Cotacao
                    {
                        NegociacaoID = record.NegociacaoID,
                        DataPregao = record.DataPregao,
                        PrecoAbertura = record.PrecoAbertura,
                        PrecoFechamento = record.PrecoFechamento
                    });
            }
            arquivo.InsertRecords(cotacoes.ToArray());
        }
    }
}

