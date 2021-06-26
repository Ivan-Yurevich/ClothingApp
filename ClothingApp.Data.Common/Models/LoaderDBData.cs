/*using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ClothingApp.Data.Common.Models
{
	public class LoaderDBData
	{
		private static FakeContext _context;
		private const byte FIRST_SHEET_ID = 0;
		private const string NULL_VALUE = "NULL";

		private readonly static Dictionary<Type, string> FileNameEntityData = new Dictionary<Type, string>
		{
			[typeof(City)] = "City.xlsx"
		};

		public static async Task Load(FakeСontext context)
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

			List<City> regions = new List<City>();

			int row = 2;

			while (worksheet.Cells[row, 1].Value != null)
			{
				Region region = new Region();

				region.Id = int.Parse(worksheet.Cells[row, 1].Value.ToString());
				region.Updated = DateTime.Now;

				if (worksheet.Cells[row, 6].Value.ToString() != NULL_VALUE)
				{
					region.ParentId = long.Parse(worksheet.Cells[row, 6].Value.ToString());
				}
				city.Name = worksheet.Cells[row, 8].Value.ToString();
				city.Country = (CountryCode?)byte.Parse(worksheet.Cells[row, 10].Value.ToString());

				regions.Add(region);
				row++;
			}

			await _context.Cities.AddRangeAsync(cities);
			await _context.SaveChangesAsync();
		}
	}
}*/