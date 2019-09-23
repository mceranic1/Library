using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Library.Seed
{
    public static class Utility
    {
        public static string readString(this ExcelWorksheet sheet, int row, int col)
        {
            return sheet.Cells[row, col].Value.ToString().Trim();
        }
        public static int readInteger(this ExcelWorksheet sheet, int row, int col)
        {
            return int.Parse(sheet.Cells[row, col].Value.ToString().Trim());
        }
        public static DateTime readDate(this ExcelWorksheet sheet, int row, int col)
        {
            return Convert.ToDateTime(sheet.Cells[row, col].Value.ToString().Trim());
        }
        public static decimal readDecimal(this ExcelWorksheet sheet, int row, int col)
        {
            return decimal.Parse(sheet.Cells[row, col].Value.ToString().Trim());
        }
    }
}
