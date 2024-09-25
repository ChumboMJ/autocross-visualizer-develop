using AutoXDisplay.DAL.Entities;
using CsvHelper;
using System.Globalization;

namespace AutoXDisplay.DAL
{
    public class AutoXWriter : IAutoXWriter
    {
        public Task WriteCsvFileAsyc(IEnumerable<RaceResultEntity> raceResultEntities, string filePath = "_artifacts")
        {
            //TODO: This should not be a hard-coded value
            var filename = "autoXtest3.csv";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            //TODO: Check if the folder exists, create if possible
            using (var writer = new StreamWriter(filePath + "/" + filename))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                return csv.WriteRecordsAsync(raceResultEntities);
            }
        }
    }
}
