using IOIAssignment.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace IOIAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var reducedDatasetPath = "../../../reduced_dataset";
            var wholeDatasetPath = "../../../dataset_kaggle";
            
            ProcessDataset(reducedDatasetPath);
            ProcessDataset(wholeDatasetPath);
            Console.ReadLine();
        }

        private static void ProcessDataset(string datasetPath)
        {
            IData data = new Data.Data();
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var result = new List<OutputRecord>();
            DirectoryInfo d = new DirectoryInfo(datasetPath);
            foreach (var file in d.GetFiles("*.csv"))
            {
                var records = new List<Record>();
                var importedData = data.ImportData(records, file.FullName);
                var processedRecords = data.ProcessData(records);
                result.AddRange(processedRecords);                    
            }
            var aggregatedResults = data.AggregateResults(result);
            data.ExportData(aggregatedResults, datasetPath + "/Results.csv");
            Console.WriteLine(aggregatedResults.Count + " records have been exported.");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs + " ms for executing");
        }
    }
}
