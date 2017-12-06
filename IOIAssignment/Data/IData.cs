using System.Collections.Generic;
namespace IOIAssignment.Data
{
    interface IData
    {
        void ImportData(ref List<Record> records, string path);
        List<OutputRecord> ProcessData(List<Record> records);
        void ExportData(List<OutputRecord> records, string path);
    }
}
