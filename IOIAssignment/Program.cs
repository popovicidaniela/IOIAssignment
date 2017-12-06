using IOIAssignment.Data;
using System;
using System.Collections.Generic;

namespace IOIAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            IData data = new Data.Data();
            List<Record> records = new List<Record>();
            data.ImportData(ref records, "../../../reduced_dataset/block_4.csv");
            data.ImportData(ref records, "../../../reduced_dataset/block_8.csv");
            data.ImportData(ref records, "../../../reduced_dataset/block_15.csv");
            data.ImportData(ref records, "../../../reduced_dataset/block_16.csv");
            data.ImportData(ref records, "../../../reduced_dataset/block_23.csv");
            data.ImportData(ref records, "../../../reduced_dataset/block_42.csv");

            List<OutputRecord> result = data.ProcessData(records);

            data.ExportData(result, "../../../results.csv");

            Console.WriteLine(result.Count + " records have been exported.");
            Console.ReadLine();
        }
    }
}
