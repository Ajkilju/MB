using mB.Loader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Tests.Utils
{
    public class ProductsFileCreator : IDisposable
    {
        private readonly string dirPath;
        private List<string> createdFiles;

        public ProductsFileCreator(string dirPath)
        {
            this.dirPath = dirPath;
            this.createdFiles = new List<string>();
        }

        public void CreateCsv(List<Product> products)
        {
            var csvLines = products
                .Select(p => $"{p.Id};{p.Name};{p.Category};{p.Price}")
                .ToList();

            CreateCsv(csvLines);
        }

        public void CreateCsv(List<string> productCsvFileLine)
        {
            var csv = new StringBuilder();

            csv.AppendLine("Id;Name;Category;Price");

            foreach (var l in productCsvFileLine)
                csv.AppendLine(l);

            var guid = Guid.NewGuid();
            var fileName = $"Products_TST_{guid}.csv";
            var fullFileName = $"{dirPath}\\{fileName}";

            using (var fs = File.Create(fullFileName))
            {
                var content = csv.ToString();
                var bytes = new UTF8Encoding(true).GetBytes(content);
                fs.Write(bytes, 0, bytes.Length);
            }

            createdFiles.Add(fullFileName);
        }

        public void Dispose()
        {
            foreach (var file in createdFiles)
            {
                var fi = new FileInfo(file);
                fi.Delete();
            }
        }

    }
}
