using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Infraestrutura
{
    public class AmazoniaException : Exception
    {
        public AmazoniaException(string tipoErro) // base("Exceção Customizada do Amazonia.PT")
        {
            var path = @"c:\temp\";
            var log = $"{DateTime.Now} :: {tipoErro}";
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllText($@"{path}log.txt", log);
        }
    }
}
