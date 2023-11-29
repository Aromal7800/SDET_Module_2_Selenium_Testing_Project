using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.Utilities
{
    internal class ExcelUtils
    {
        public static List<GetYourGuide> ReadExcelData(string excelFilePath, string sheetName)
        {
            List<GetYourGuide> excelDataList = new List<GetYourGuide>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            GetYourGuide excelData = new GetYourGuide
                            {
                                FullName = GetValueOrDefault(row, "fullname"),
                                Email = GetValueOrDefault(row, "email"),
                                Password = GetValueOrDefault(row, "password"),
                                LogInEmail = GetValueOrDefault(row, "logInEmail"),
                                LogInPassword = GetValueOrDefault(row, "logInPassword"),
                                Search = GetValueOrDefault(row, "search"),
                                 AdultCount=GetValueOrDefault(row, "adultCount")
                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
