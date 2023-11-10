using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

public class CsvData
{
    public string Grain { get; set; }
    public DateTime Date { get; set; }
    public string FactoryManagerName { get; set; }
    public decimal BeerProduction { get; set; }
}

public class OutputCsvData
{
    public string Grain { get; set; }
    public DateTime Date { get; set; }
    public string Manager { get; set; }
    public decimal BeerProduction { get; set; }
    public decimal YearMean { get; set; }
    public decimal YearMedian { get; set; }
    public string IsBeerProductionGreaterThanYearMean { get; set; }
}

internal class Program
{
    private static void Main()
    {
        string inputFilePath = "Input_v1.0.csv";
        string outputFilePath = "Output.csv";

        List<CsvData> inputData;

        using (var reader = new StreamReader(inputFilePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            inputData = csv.GetRecords<CsvData>().ToList();
        }

        List<OutputCsvData> outputData = ProcessData(inputData);

        using (var writer = new StreamWriter(outputFilePath))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecords(outputData);
        }
    }

    private static List<OutputCsvData> ProcessData(List<CsvData> inputData)
    {
        List<OutputCsvData> outputData = new List<OutputCsvData>();

        // Your logic to process and update the data goes here

        return outputData;
    }
}
