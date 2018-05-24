using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace LSExtendedWarrenty.AppBase.ExcelExport
{
    public class ExcelCSVExport
    {
        public static void ExportTableXLS(DataTable table, String FileName, List<String> Errors)
        {
            if (table != null)
            {
                List<String> Data = new List<String>();

                string x = "";
                foreach (DataColumn col in table.Columns)
                {
                    x += (col.ColumnName + ",");
                }
                Data.Add(x);
                foreach (DataRow row in table.Rows)
                {
                    String temp_1 = "";
                    foreach (var col in row.ItemArray)
                    {
                        temp_1 += (col.ToString() + ",");
                    }
                    temp_1.TrimEnd(new char[] { ',' });
                    Data.Add(temp_1);
                }
                File.WriteAllLines(FileName, Data.ToArray());
            }
            if (Errors != null)
                File.WriteAllLines("Error_" + FileName, Errors.ToArray());
        }
    }
}
