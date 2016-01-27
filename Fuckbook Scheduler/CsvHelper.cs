using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Facebook_Scheduler
{
    public class CsvHelper
    {
        private static CsvHelper _instance;

        public static CsvHelper Instance
        {
            get { return _instance ?? (_instance = new CsvHelper()); }
        }

        public string FilePath { get; set; }

        public DataTable ConvertCsvToDataTable()
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(FilePath);
            }
            catch (Exception)
            {
            }

            if (reader == null) return null;

            var firstLine = reader.ReadLine();
            if (firstLine == null) return null;

            string[] headers = firstLine.Split(',');
            var dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!reader.EndOfStream)
            {
                string[] rows = firstLine.Split(',');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public void WriteDataTable(DataTable sourceTable, bool includeHeaders = true)
        {
            using (TextWriter writer = new StreamWriter(FilePath, false, Encoding.UTF8))
            {
                if (includeHeaders)
                {
                    var headerValues = new List<string>();
                    foreach (DataColumn column in sourceTable.Columns)
                    {
                        headerValues.Add(QuoteValue(column.ColumnName));
                    }

                    writer.WriteLine(String.Join(",", headerValues.ToArray()));
                }

                foreach (DataRow row in sourceTable.Rows)
                {
                    string[] items = row.ItemArray.Select(o => QuoteValue(o.ToString())).ToArray();
                    writer.WriteLine(String.Join(",", items));
                }

                writer.Flush();
                writer.Close();
            }
        }

        private static string QuoteValue(string value)
        {
            return String.Concat("\"", value.Replace("\"", "\"\""), "\"");
        }
    }
}
