using CsvHelper;
using Data;
using System.Globalization;
using static System.Formats.Asn1.AsnWriter;

namespace Logik
{
    public class CSVManager
    {
        

        //Gets the path where the exe is and adds the file name to the string
        string filePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\CSVFile.txt";

        /// <summary>
        /// The given parameter score gets added to the CSV File
        /// </summary>
        /// <param name="score"></param>
        public void AddScoreToCSV(Score score)
        {
            List<Score> scores = GetScores();
            scores.Add(score);

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(scores); // Writes all scores in the CSV File
            }
        }

        /// <summary>
        /// Gets all the Scores from the CSV File and returns it
        /// </summary>
        /// <returns></returns>
        public List<Score> GetScores()
        {
            List<Score> scores = new List<Score>(); 

            TextReader textReader = new StreamReader(filePath); 
            using (var csv = new CsvReader(textReader, CultureInfo.InvariantCulture))
            {

                scores.AddRange(csv.GetRecords<Score>());   //Adds all the Scores gotten from the CSV File
            }
            return scores;
        }

       
    }
}