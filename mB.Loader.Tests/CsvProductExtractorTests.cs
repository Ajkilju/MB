using mB.Loader.Models;
using mB.Loader.Services.Extractors;
using mB.Loader.Tests.Utils;
using mB.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Tests
{
    public class CsvProductExtractorTests
    {
        private string dirPath;
        private TestLogger logger;
        private CsvProductExtractor sut;

        [SetUp]
        public void Setup()
        {
            logger = new TestLogger();
            sut = new CsvProductExtractor(logger);
            dirPath = "../../../../_SOURCE_TST";
        }

        static CsvFile[] canExtractFromOneFileTestCases = new CsvFile[]
        {
            new CsvFile
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "aa", Category = "bb", Price = 123},
                    new Product { Id = 2, Name = "gfksl", Category = "vvvd", Price = 0},
                    new Product { Id = 3, Name = "dfdsf", Category = "fda", Price = 22.55M},
                }
            },
            new CsvFile
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "aaddd", Category = "bbddd", Price = 123},
                    new Product { Id = 2, Name = "gfkslsda", Category = "vvdsvd", Price = 0},
                    new Product { Id = 12354885, Name = "???....@@@###", Category = "", Price = 22.555555M},
                }
            }
        };

        [TestCaseSource(nameof(canExtractFromOneFileTestCases))]
        public void CanExtractFromOneFile(CsvFile csvFile)
        {
            var extractResult = new List<Product>();

            using(var tstFile = new ProductsFileCreator(dirPath))
            {
                tstFile.CreateCsv(csvFile.Products);

                extractResult = sut.Extract(dirPath);
            }

            ProductsAreEqualAssertion(csvFile.Products, extractResult);
        }

        static List<CsvFile>[] canExtractFromMoteThanOneFileTestCases = new List<CsvFile>[]
        {
            new List<CsvFile>
            {
                new CsvFile
                {
                    Products = new List<Product>
                    {
                        new Product { Id = 5, Name = "aagsfg", Category = "bbfdg", Price = 66},
                        new Product { Id = 6, Name = "fggfksl", Category = "vvgfvd", Price = 0},
                        new Product { Id = 666, Name = "aa666666gsfg", Category = "bbfnnnndg", Price = 66.7767567567M},
                    }
                },
                new CsvFile
                {
                    Products = new List<Product>
                    {
                        new Product { Id = 666, Name = "aagsfg", Category = "bbfdg", Price = 66},
                        new Product { Id = 997, Name = "Bag", Category = "iety", Price = 0},
                    }
                }
            },
            new List<CsvFile>
            {
                new CsvFile
                {
                    Products = new List<Product>
                    {
                        new Product { Id = 55, Name = "hgfh", Category = "hgf", Price = 66},
                        new Product { Id = 88, Name = "rrr", Category = "vvgfvd", Price = 0},
                        new Product { Id = 8666, Name = "aa666666gsfg", Category = "bbfnnnndg", Price = 6},
                    }
                },
                new CsvFile
                {
                    Products = new List<Product>
                    {
                        new Product { Id = 6696, Name = "aagsoooofg", Category = "o", Price = 66},
                    }
                },
                new CsvFile
                {
                    Products = new List<Product>
                    {
                        new Product { Id = 6, Name = "aagsoooofg", Category = "o", Price = 66},
                    }
                }
            }
        };

        [TestCaseSource(nameof(canExtractFromMoteThanOneFileTestCases))]
        public void CanExtractFromMoreThanOneFile(List<CsvFile> fileList)
        {
            var extractResult = new List<Product>();

            using (var tstFile = new ProductsFileCreator(dirPath))
            {
                foreach(var file in fileList)
                    tstFile.CreateCsv(file.Products);

                extractResult = sut.Extract(dirPath);
            }

            var productsInAllFiles = new List<Product>();
            foreach (var file in fileList)
                productsInAllFiles.AddRange(file.Products);

            ProductsAreEqualAssertion(productsInAllFiles, extractResult);
        }

        static CsvFileWithInvalidRecords[] extractLogsErrorWhenFileIsInvalidTestCases = new CsvFileWithInvalidRecords[]
        {
            new CsvFileWithInvalidRecords
            {
                Products = new List<string>
                {
                    "1;Name_1;Category_1;InvalidPrice",
                    "2;Name_2;Category_2;2",
                    "3;Name_2;Category_2;2",
                    "4;Name_4;Category_4;2,555"
                },
                ValidRecords = 3
            },
            new CsvFileWithInvalidRecords
            {
                Products = new List<string>
                {
                    "InvalidId;Name_1;Category_1;1",
                    "2;Name_2;Category_2;2"
                },
                ValidRecords = 1
            }
        };

        [TestCaseSource(nameof(extractLogsErrorWhenFileIsInvalidTestCases))]
        public void CanExtractFileWithInvalidRecords(CsvFileWithInvalidRecords file)
        {
            var extractResult = new List<Product>();

            using (var tstFile = new ProductsFileCreator(dirPath))
            {
                tstFile.CreateCsv(file.Products);

                extractResult = sut.Extract(dirPath);
            }

            Assert.AreEqual(file.ValidRecords, extractResult.Count);
        }

        static CsvFile[] cantExtractProductsWithEmptyNamesTestCases = new CsvFile[]
        {
            new CsvFile
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "", Category = "bb", Price = 123},
                    new Product { Id = 2, Name = "", Category = "vvvd", Price = 0},
                    new Product { Id = 3, Name = "dfdsf", Category = "fda", Price = 22.55M},
                }
            },
            new CsvFile
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "", Category = "bbddd", Price = 123},
                    new Product { Id = 2, Name = "gfkslsda", Category = "vvdsvd", Price = 0},
                    new Product { Id = 12354885, Name = "???....@@@###", Category = "", Price = 22.555555M},
                }
            }
        };

        [TestCaseSource(nameof(cantExtractProductsWithEmptyNamesTestCases))]
        public void CantExtractProductsWithEmptyNames(CsvFile csvFile)
        {
            var extractResult = new List<Product>();

            using (var tstFile = new ProductsFileCreator(dirPath))
            {
                tstFile.CreateCsv(csvFile.Products);

                extractResult = sut.Extract(dirPath);
            }

            var productsWithNames = csvFile.Products
                .Where(x => !string.IsNullOrWhiteSpace(x.Name))
                .ToList();

            ProductsAreEqualAssertion(productsWithNames, extractResult);
        }

        private void ProductsAreEqualAssertion(List<Product> inFiles, List<Product> extracted)
        {
            Assert.AreEqual(inFiles.Count, extracted.Count);

            foreach (var extractedProduct in extracted)
            {
                var equalsProducts = inFiles
                    .Where(x => x.Equals(extractedProduct))
                    .ToList();

                Assert.AreEqual(1, equalsProducts.Count);
            }
        }

        [TestCase("aaaa")]
        [TestCase("aaaa/dddd/dsdad/dase")]
        [TestCase("../../../../_SOURCE_TST_2")]
        public void ExtractThrowsWhenSourceDirNotExists(string notExistingDirPath)
        {
            Assert.Throws(Is.TypeOf<Exception>(), () => sut.Extract(notExistingDirPath)); 
        }

        


    }
}
