using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic
{
    public class ScoreValidation
    {
        /// <summary>
        /// Calls all Validate functions
        /// </summary>
        /// <param name="score"></param>
        public void Validate(Score score)
        {
            ValidateDate(score.Date);
            ValidateNumber(score.HighScore);
            ValidateString(score.PlayerName);
            ValidateString(score.VideoGameName);
        }

        /// <summary>
        /// ValidateDate checks if the given date is in the present or in in the past.
        /// If the given date is in the future it will throw a exeption.
        /// </summary>
        /// <param name="date"></param>
        /// <exception cref="Exception"></exception>
        private void ValidateDate(DateTime date)
        {
            if (date > DateTime.Today)
            {
                throw new Exception("The selected Date is in the Future");
            }
            
        }

        /// <summary>
        /// ValidateNUmber validates if the given string is a number with a regex.
        /// </summary>
        /// <param name="number"></param>
        /// <exception cref="Exception"></exception>
        private void ValidateNumber(string number)
        {
            Regex rx = new Regex(@"^(?!0\\d)\\d+$"); // Regex Cannot start with 0 but can be 0

            if (!rx.IsMatch(number))
            {
                throw new Exception("The Highscore has to be a Number");
            }
        }

        /// <summary>
        /// ValidateString checks if the given string is nulll or empty.
        /// </summary>
        /// <param name="text"></param>
        /// <exception cref="Exception"></exception>
        private void ValidateString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Please fill in all the Text fields");
            }
        }
    }
}
