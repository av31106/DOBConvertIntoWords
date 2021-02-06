using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateToWord
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            rbtnCapitalLetter.Checked = true;
            rbtnNumericWith2Letter.Checked = true;
            cboxDOBFormat.SelectedIndex = 0;
            cboxDateValueSeparatedBy.SelectedIndex = 0;

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void rbtnResultTextFormat_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton thisRadioButton = sender as RadioButton;
            string example = "1st july nineteen hundred ninety";
            if (thisRadioButton.Text == "Capital Letter")
            {
                lblResultTextFormatExample.Text = example.ToUpper();
            }
            else if (thisRadioButton.Text == "Small Letter")
            {
                lblResultTextFormatExample.Text = example.ToLower();
            }
            else if (thisRadioButton.Text == "First Capital Letter Of Every Word")
            {
                lblResultTextFormatExample.Text = GetFirstCapitalLetterOfEveryWord(example);
            }
        }

        private void ResultTextDayFormat_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton thisRadioButton = sender as RadioButton;
            if (thisRadioButton.Text == "Numeric With 2 Letters")
            {
                lblResultTextDayFormatExample.Text = "31st";
            }
            else if (thisRadioButton.Text == "All Letters")
            {
                lblResultTextDayFormatExample.Text = "Thirty First";
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try { 
            string dob = null;
            string firstPart = null;
            string finalResult = null;
            char spliter = ' ';
            StringBuilder res = new StringBuilder();

            dob = txtDOB.Text.Trim();

            if (cboxDateValueSeparatedBy.SelectedItem.ToString() == "Space")
                spliter = ' ';

            string[] dobSplit = dob.Split(spliter);

            if (rbtnNumericWith2Letter.Checked)
                firstPart = GetDateInNumericWith2Characters(Convert.ToInt32(dobSplit[0]));
            else if (rbtnAllLetters.Checked)
                firstPart = GetDateInCompleteWord(Convert.ToInt32(dobSplit[0]));

            string secondPart = GetFullMonthName(dobSplit[1]);
            string thirdPart = getYearInWord(Convert.ToInt32(dobSplit[2]));
            res.Append(firstPart + " " + secondPart + " " + thirdPart);

            if (rbtnCapitalLetter.Checked)
                finalResult = res.ToString().ToUpper();
            else if (rbtnSmallLetter.Checked)
                finalResult = res.ToString().ToLower();
            else if (rbtnFirstCapitalLetterOfEveryWord.Checked)
                finalResult = GetFirstCapitalLetterOfEveryWord(res.ToString());

            txtResult.Text = finalResult;
            }
            catch
            {
                txtResult.Text = "Invalid Date Format.";
            }
        }

        private string GetFirstCapitalLetterOfEveryWord(string str)
        {
            StringBuilder result = new StringBuilder();
            if (string.IsNullOrEmpty(str)) return "";
            string[] strSplite = str.Split(' ');
            foreach (string item in strSplite)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string first = item.Substring(0, 1);
                    string other = item.Substring(1, item.Length - 1);
                    result.Append(first.ToUpper() + other + " ");
                }
            }
            return result.ToString().Trim();

        }

        private string GetDateInCompleteWord(int day)
        {
            string result = null;
            switch (day)
            {
                case 1:
                    result = "First"; break;
                case 2:
                    result = "Second"; break;
                case 3:
                    result = "Third"; break;
                case 4:
                    result = "Fourth"; break;
                case 5:
                    result = "Fifth"; break;
                case 6:
                    result = "Sixth"; break;
                case 7:
                    result = "Seventh"; break;
                case 8:
                    result = "Eighth"; break;
                case 9:
                    result = "Ninth"; break;
                case 10:
                    result = "Tenth"; break;
                case 11:
                    result = "Eleventh"; break;
                case 12:
                    result = "twelfth"; break;
                case 13:
                    result = "thirteenth"; break;
                case 14:
                    result = "Fourteenth"; break;
                case 15:
                    result = "Fifteenth"; break;
                case 16:
                    result = "Sixteenth"; break;
                case 17:
                    result = "Seventeenth"; break;
                case 18:
                    result = "Eighteenth"; break;
                case 19:
                    result = "Nineteenth"; break;
                case 20:
                    result = "Twentieth"; break;
                case 21:
                    result = "Twenty First"; break;
                case 22:
                    result = "Twenty Second"; break;
                case 23:
                    result = "Twenty Third"; break;
                case 24:
                    result = "Twenty Fourth"; break;
                case 25:
                    result = "Twenty Fifth"; break;
                case 26:
                    result = "Twenty Sixth"; break;
                case 27:
                    result = "Twenty Seventh"; break;
                case 28:
                    result = "Twenty Eighth"; break;
                case 29:
                    result = "Twenty Ninth"; break;
                case 30:
                    result = "Thirtieth"; break;
                case 31:
                    result = "Thirty First"; break;
                default:
                    throw new Exception("Day should be from 1 to 31 only");
            }
            return result;
        }
        private string GetDateInNumericWith2Characters(int day)
        {
            string result = null;
            if (day == 1 || day == 21 || day == 31)
                result = day + "st";
            else if (day == 2 || day == 22)
                result = day + "nd";
            else if (day == 3 || day == 23)
                result = day + "rd";
            else if ((day >= 4 && day <= 20) || (day >= 24 && day <= 30))
                result = day + "th";
            else
                throw new Exception("Day should be from 1 to 31 only");
            return result;
        }

        private string GetFullMonthName(string shortMonthWord)
        {
            string result = null;
            if (string.IsNullOrEmpty(shortMonthWord)) throw new Exception("Invalid month name");
            switch (shortMonthWord.ToLower())
            {
                case "jan":
                    result = "January"; break;
                case "feb":
                    result = "February"; break;
                case "mar":
                    result = "March"; break;
                case "apr":
                    result = "April"; break;
                case "may":
                    result = "May"; break;
                case "jun":
                    result = "June"; break;
                case "jul":
                    result = "July"; break;
                case "aug":
                    result = "August"; break;
                case "sep":
                    result = "September"; break;
                case "oct":
                    result = "October"; break;
                case "nov":
                    result = "November"; break;
                case "dec":
                    result = "December"; break;
                default:
                    break;
            }
            return result;
        }
        private string GetFullMonthName(int monthNumber)
        {
            string result = null;
            switch (monthNumber)
            {
                case 1:
                    result = "January"; break;
                case 2:
                    result = "February"; break;
                case 3:
                    result = "March"; break;
                case 4:
                    result = "April"; break;
                case 5:
                    result = "May"; break;
                case 6:
                    result = "June"; break;
                case 7:
                    result = "July"; break;
                case 8:
                    result = "August"; break;
                case 9:
                    result = "September"; break;
                case 10:
                    result = "October"; break;
                case 11:
                    result = "November"; break;
                case 12:
                    result = "December"; break;
                default:
                    throw new Exception("Invalid month number");
            }
            return result;
        }

        private string getYearInWord(int year)
        {
            string result = null;
            int last2DigitNumber = 0;
            if (year >= 1901 && year <= 1999)
            {
                result = "Nineteen Hundred ";
                last2DigitNumber = year - 1900;
            }
            else if (year >= 2000 && year <= 2099)
            {
                result = "Two Thousand ";
                last2DigitNumber = year - 2000;
            }
            else
                throw new Exception("Invalid year number");

            switch (last2DigitNumber.ToString().Length)
            {
                case 1:
                    result += Ones(last2DigitNumber);
                    break;
                case 2:
                    result += Tens(last2DigitNumber);
                    break;
                default:
                    break;
            }
            return result;
        }
        private static String Ones(int number)
        {
            String name = "";
            switch (number)
            {
                case 0:
                    name = "";
                    break;
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
                default:
                    throw new Exception("Not a Single digit number");
            }
            return name;
        }
        private static String Tens(int number)
        {
            String name = null;
            switch (number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (number > 0)
                    {
                        name = Tens(Convert.ToInt32(number.ToString().Substring(0, 1) + "0")) + " " + Ones(Convert.ToInt32(number.ToString().Substring(1)));
                    }
                    break;
            }
            return name;
        }

        private void btnExcelConvert_Click(object sender, EventArgs e)
        {

        }
    }
}
