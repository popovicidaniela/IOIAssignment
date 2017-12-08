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
            List<Record> records = new List<Record>();

            DirectoryInfo d = new DirectoryInfo(datasetPath);
            foreach (var file in d.GetFiles("*.csv"))
            {
                data.ImportData(ref records, file.FullName);
            }

            List<OutputRecord> result = data.ProcessData(records);

            data.ExportData(result, datasetPath + "/results.csv");

            Console.WriteLine(result.Count + " records have been exported.");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs + " ms for executing");
        }
    }
}
