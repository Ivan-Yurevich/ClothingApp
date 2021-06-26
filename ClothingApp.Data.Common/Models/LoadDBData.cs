using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ClothingApp.Data.Common.Models
{
	public class LoadDBData
	{
		private static List<string> _context;
		private const byte FIRST_SHEET_ID = 0;
		private const string NULL_VALUE = "NULL";

		private readonly static Dictionary<Type, string> FileNameEntityData = new Dictionary<Type, string>
		{
			[typeof(City)] = "City.xlsx"
		};

		public static async Task Load(List<string> context)
		{
			_context = context;

			await LoadCityData(FileNameEntityData[typeof(Region)]);
		}

		private static ExcelPackage GetFileDb(string fileName)
		{
			fileName = $"TestDbFiles/{fileName}";

			FileInfo file = new FileInfo(fileName);

			if (!file.Exists)
			{
				throw new Exception($"Файл {fileName} не найден");
			}

			return new ExcelPackage(file);
		}

		private static ExcelWorksheet GetWorksheet(string fileName)
		{
			var fileData = GetFileDb(fileName);

			ExcelWorksheet worksheet = fileData.Workbook.Worksheets[FIRST_SHEET_ID];

			if (worksheet == null)
			{
				throw new Exception($"Лист с ID {FIRST_SHEET_ID} в файле {fileName} не найден");
			}

			return worksheet;
		}

		private static async Task LoadCityData(string fileName)
		{
			ExcelWorksheet worksheet = GetWorksheet(fileName);

			List<string> cities = new List<string>();

			int row = 2;

			while (worksheet.Cells[row, 1].Value != null)
			{
				cities.Add(worksheet.Cells[row, 1].Value.ToString());
				row++;
			}

			//await _context.AddRangeAsync(cities);
			//await _context.SaveChangesAsync();
		}
	}
}