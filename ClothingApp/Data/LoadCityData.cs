using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ClothingApp.Data.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingApp.Data
{
	public class LoaderDBData
	{
		private static ApplicationDbContext _context { get; set; }

		private readonly static Dictionary<Type, string> FileNameEntityData = new Dictionary<Type, string>
		{
			[typeof(City)] = "cities.xlsx"
		};

		public static async Task Load(ApplicationDbContext context)
		{
			_context = context;
			bool isAny = await context.Cities.AnyAsync();
			if (!isAny) await LoadCityData(FileNameEntityData[typeof(City)]);
		}

		private static ExcelPackage GetFileDb(string fileName)
		{
			string curDir = Directory.GetCurrentDirectory();
			//fileName = $"DbFiles\\{fileName}";
			fileName = curDir + "\\Data\\DbFiles\\" + fileName;

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

			if (fileData.Workbook.Worksheets.Count == 0) throw new Exception("No Worksheets found");

			ExcelWorksheet worksheet = fileData.Workbook.Worksheets[1];

			if (worksheet == null)
			{
				throw new Exception($"Лист с ID {0} в файле {fileName} не найден");
			}

			return worksheet;
		}

		private static async Task LoadCityData(string fileName)
		{
			ExcelWorksheet worksheet = GetWorksheet(fileName);

			List<City> cities = new List<City>();

			int row = 2;

			while (worksheet.Cells[row, 1].Value != null)
			{
				City newCity = new City();
				//newCity.Id = row;
				newCity.Name = worksheet.Cells[row, 1].Value.ToString();

				cities.Add(newCity);
				row++;
			}


			await _context.Cities.AddRangeAsync(cities);
			await _context.SaveChangesAsync();
		}
	}
}
