using System.Collections.Generic;
namespace IOIAssignment.Data
{
    interface IData
    {
        List<Record> ImportData(List<Record> records, string path);
        List<OutputRecord> ProcessData(List<Record> records);
        List<OutputRecord> AggregateResults(List<OutputRecord> records);
        void ExportData(List<OutputRecord> records, string path);
    }
}
