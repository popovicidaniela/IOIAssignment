using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IOIAssignment.Data
{
    public class Data : IData
    {
        public void ImportData(ref List<Record> records, string path)
        {
            using (var reader = new StreamReader(path))
            {
                var headerLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values.Count() != 3)
                    {
                        continue;
                    }
                    float x = 0;
                    float.TryParse(values[2], out x);
                    var record = new Record { BlockId = values[0], Kwh = x };
                    records.Add(record);
                }
            }
        }
        public List<OutputRecord> ProcessData(List<Record> records)
        {
            return records.GroupBy(record => record.BlockId).Select(group =>
                                        new OutputRecord
                                        {
                                            BlockId = group.Key,
                                            NumberOfBlocks = group.Where(record => record.Kwh >= 1).Count(),
                                            KwhSum = group.Sum(record => record.Kwh)
                                        }).OrderBy(outputRecord => outputRecord.BlockId).ToList();
        }

        public void ExportData(List<OutputRecord> records, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                var headerLine = "block,count,kwh";
                writer.WriteLine(headerLine);
                foreach (var item in records)
                {
                    writer.WriteLine(string.Format("{0},{1},{2}", item.BlockId, item.NumberOfBlocks, item.KwhSum));
                }
            }
        }
    }
}
