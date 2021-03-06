using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AbayChequeMagic
{
    public class FigursToWords
    {
        public string NumberToText(int number)
        {
            // Converting the number to words
            if (number == 0) return "Zero";
            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };
            num[0] = number % 1000; // units 
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands 
            num[3] = number / 10000000; // crores 
            num[2] = num[2] - 100 * num[3]; // lakhs 
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10; // ones 
                t = num[i] / 10;
                h = num[i] / 100; // hundreds 
                t = t - 10 * h; // tens 
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append(" ");//if (h > 0 || i == 0) sb.Append(" and");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }

        public enum Criteria
        {
            Indian,
            Foreign
        }
         private Hashtable htPunctuation;
        private Dictionary<int, string> DictStaticSuffix;
        private Dictionary<int, string> DictStaticPrefix;
        private Dictionary<int, string> DictHelpNotation;
        private System.Drawing.Color color;
        private Criteria Native;

        public FigursToWords()
        {
        }
        public FigursToWords(Criteria native)
        {
            htPunctuation = new Hashtable();
            DictStaticPrefix = new Dictionary<int, string>();
            DictStaticSuffix = new Dictionary<int, string>();
            DictHelpNotation = new Dictionary<int, string>();
            Native = native;
            LoadStaticPrefix();
            LoadStaticSuffix();
            LoadHelpofNotation();
        }
        public string ConvertToWord(string Value, System.Drawing.Color color)
        {
            this.color = color;
            String ConvertedString = String.Empty;
            if (!(Value.ToString().Length > 40))
            {
                if (IsNumeric(Value.ToString()))
                {
                    try
                    {
                        string strValue = Reverse(Value);
                        switch (strValue.Length)
                        {
                            case 1:
                                if (int.Parse(strValue.ToString()) > 0)
                                    ConvertedString = GetWordConversion(Value);
                                else
                                    ConvertedString = "Zero ";
                                break;
                            case 2:
                                ConvertedString = GetWordConversion(Value);
                                ; break;
                            default:
                                InsertToPunctuationTable(strValue);
                                ReverseHashTable();
                                ConvertedString = ReturnHashtableValue();
                                break;
                        }
                    }
                    catch (Exception Ex)
                    {
                        ConvertedString = "Unexpected Error Occured <br/>";
                        ConvertedString += Ex.Message;
                    }
                }
                else
                {
                    ConvertedString = "Please Enter Numbers Only, Decimal Values Are not supported";
                }
            }
            else
            {
                ConvertedString = "Please Enter Value in Less Then or Equal to 40 Digit";
            }
            return ConvertedString;
        }
        internal bool IsNumeric(string ValueInNumeric)
        {
            bool IsFine = true;
            foreach (char ch in ValueInNumeric)
            {
                if (!(ch >= '0' && ch <= '9'))
                {
                    IsFine = false;
                }
            }
            return IsFine;
        }
        private string ReturnHashtableValue()
        {
            string strFinalString = String.Empty;
            for (int i = (htPunctuation.Count - 1); i >= 0; i--)
            {
                if (GetWordConversion((htPunctuation[i]).ToString()) != "")
                    strFinalString = strFinalString + GetWordConversion((htPunctuation[i]).ToString()) + StaticPrefixFind((i).ToString());
            }
            return strFinalString;
        }
        private void LoadStaticSuffix()
        {
            DictStaticSuffix.Add(1, "One ");
            DictStaticSuffix.Add(2, "Two ");
            DictStaticSuffix.Add(3, "Three ");
            DictStaticSuffix.Add(4, "Four ");
            DictStaticSuffix.Add(5, "Five ");
            DictStaticSuffix.Add(6, "Six ");
            DictStaticSuffix.Add(7, "Seven ");
            DictStaticSuffix.Add(8, "Eight ");
            DictStaticSuffix.Add(9, "Nine ");
            DictStaticSuffix.Add(10, "Ten ");
            DictStaticSuffix.Add(11, "Eleven ");
            DictStaticSuffix.Add(12, "Twelve ");
            DictStaticSuffix.Add(13, "Thirteen ");
            DictStaticSuffix.Add(14, "Fourteen ");
            DictStaticSuffix.Add(15, "Fifteen ");
            DictStaticSuffix.Add(16, "Sixteen ");
            DictStaticSuffix.Add(17, "Seventeen ");
            DictStaticSuffix.Add(18, "Eighteen ");
            DictStaticSuffix.Add(19, "Nineteen ");
            DictStaticSuffix.Add(20, "Twenty ");
            DictStaticSuffix.Add(30, "Thirty ");
            DictStaticSuffix.Add(40, "Fourty ");
            DictStaticSuffix.Add(50, "Fifty ");
            DictStaticSuffix.Add(60, "Sixty ");
            DictStaticSuffix.Add(70, "Seventy ");
            DictStaticSuffix.Add(80, "Eighty ");
            DictStaticSuffix.Add(90, "Ninty ");

        }
        private void LoadStaticPrefix()
        {
            if (Native == Criteria.Indian)
            {
                DictStaticPrefix.Add(2, "Thousand ");
                DictStaticPrefix.Add(3, "Lac ");
                DictStaticPrefix.Add(4, "Crore ");
                DictStaticPrefix.Add(5, "Arab ");
                DictStaticPrefix.Add(6, "Kharab ");
                DictStaticPrefix.Add(7, "Neel ");
                DictStaticPrefix.Add(8, "Padma ");
                DictStaticPrefix.Add(9, "Shankh ");
                DictStaticPrefix.Add(10, "Maha-shankh ");
                DictStaticPrefix.Add(11, "Ank ");
                DictStaticPrefix.Add(12, "Jald ");
                DictStaticPrefix.Add(13, "Madh ");
                DictStaticPrefix.Add(14, "Paraardha ");
                DictStaticPrefix.Add(15, "Ant ");
                DictStaticPrefix.Add(16, "Maha-ant ");
                DictStaticPrefix.Add(17, "Shisht ");
                DictStaticPrefix.Add(18, "Singhar ");
                DictStaticPrefix.Add(19, "Maha-singhar ");
                DictStaticPrefix.Add(20, "Adant-singhar ");
            }
            if (Native == Criteria.Foreign)
            {
                DictStaticPrefix.Add(1, "Thousand ");
                DictStaticPrefix.Add(2, "Million ");
                DictStaticPrefix.Add(3, "Billion ");
                DictStaticPrefix.Add(4, "Trillion ");
                DictStaticPrefix.Add(5, "Quadrillion ");
                DictStaticPrefix.Add(6, "Quintillion ");
                DictStaticPrefix.Add(7, "Sextillion ");
                DictStaticPrefix.Add(8, "Septillion ");
                DictStaticPrefix.Add(9, "Octillion ");
                DictStaticPrefix.Add(10, "Nonillion ");
                DictStaticPrefix.Add(11, "Decillion ");
                DictStaticPrefix.Add(12, "Undecillion ");
                DictStaticPrefix.Add(13, "Duodecillion ");
            }
        }
        private void LoadHelpofNotation()
        {
            if (Native == Criteria.Indian)
            {
                DictHelpNotation.Add(2, "=1,000 (3 Trailing Zeros)");
                DictHelpNotation.Add(3, "=1,00,000 (5 Trailing Zeros)");
                DictHelpNotation.Add(4, "=1,00,00,000 (7 Trailing Zeros)");
                DictHelpNotation.Add(5, "=1,00,00,00,000 (9 Trailing Zeros)");
                DictHelpNotation.Add(6, "=1,00,00,00,00,000 (11 Trailing Zeros)");
                DictHelpNotation.Add(7, "=1,00,00,00,00,00,000 (13 Trailing Zeros)");
                DictHelpNotation.Add(8, "=1,00,00,00,00,00,00,000 (15 Trailing Zeros)");
                DictHelpNotation.Add(9, "=1,00,00,00,00,00,00,00,000 (17 Trailing Zeros)");
                DictHelpNotation.Add(10, "=1,00,00,00,00,00,00,00,00,000 (19 Trailing Zeros)");
                DictHelpNotation.Add(11, "=1,00,00,00,00,00,00,00,00,00,000 (21 Trailing Zeros)");
                DictHelpNotation.Add(12, "=1,00,00,00,00,00,00,00,00,00,00,000 (23 Trailing Zeros)");
                DictHelpNotation.Add(13, "=1,00,00,00,00,00,00,00,00,00,00,00,000 (25 Trailing Zeros)");
                DictHelpNotation.Add(14, "=1,00,00,00,00,00,00,00,00,00,00,00,00,000 (27 Trailing Zeros)");
                DictHelpNotation.Add(15, "=1,00,00,00,00,00,00,00,00,00,00,00,00,00,000 (29 Trailing Zeros)");
                DictHelpNotation.Add(16, "=1,00,00,00,00,00,00,00,00,00,00,00,00,00,00,000 (31 Trailing Zeros)");
                DictHelpNotation.Add(17, "=1,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,000 (33 Trailing Zeros)");
                DictHelpNotation.Add(18, "=1,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,000 (35 Trailing Zeros)");
                DictHelpNotation.Add(19, "=1,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,000 (37 Trailing Zeros)");
                DictHelpNotation.Add(20, "=1,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,000 (39 Trailing Zeros)");
            }
            else
            {
                DictHelpNotation.Add(1, "=1,000 (3 Trailing Zeros)");
                DictHelpNotation.Add(2, "=1,000,000 (6 Trailing Zeros)");
                DictHelpNotation.Add(3, "=1,000,000,000 (9 Trailing Zeros)");
                DictHelpNotation.Add(4, "=1,000,000,000,000 (12 Trailing Zeros)");
                DictHelpNotation.Add(5, "=1,000,000,000,000,000 (15 Trailing Zeros)");
                DictHelpNotation.Add(6, "=1,000,000,000,000,000,000 (18 Trailing Zeros)");
                DictHelpNotation.Add(7, "=1,000,000,000,000,000,000,000 (21 Trailing Zeros)");
                DictHelpNotation.Add(8, "=1,000,000,000,000,000,000,000,000 (24 Trailing Zeros)");
                DictHelpNotation.Add(9, "=1,000,000,000,000,000,000,000,000,000 (27 Trailing Zeros)");
                DictHelpNotation.Add(10, "=1,000,000,000,000,000,000,000,000,000,000 (30 Trailing Zeros)");
                DictHelpNotation.Add(11, "=1,000,000,000,000,000,000,000,000,000,000,000 (33 Trailing Zeros)");
                DictHelpNotation.Add(12, "=1,000,000,000,000,000,000,000,000,000,000,000,000 (36 Trailing Zeros)");
                DictHelpNotation.Add(13, "=1,000,000,000,000,000,000,000,000,000,000,000,000,000 (39 Trailing Zeros)");
                DictHelpNotation.Add(14, "=1,000,000,000,000,000,000,000,000,000,000,000,000,000,000 (42 Trailing Zeros)");
            }
        }
        private void ReverseHashTable()
        {
            Hashtable htTemp = new Hashtable();
            foreach (DictionaryEntry item in htPunctuation)
            {
                htTemp.Add(item.Key, Reverse(item.Value.ToString()));
            }
            htPunctuation.Clear();
            htPunctuation = htTemp;
        }
        private void InsertToPunctuationTable(string strValue)
        {
            int j = 0;
            if (Native == Criteria.Indian)
            {
                htPunctuation.Add(1, strValue.Substring(0, 3).ToString());
                j = 2;
                for (int i = 3; i < strValue.Length; i = i + 2)
                {
                    if (strValue.Substring(i).Length > 0)
                    {
                        if (strValue.Substring(i).Length >= 2)
                            htPunctuation.Add(j, strValue.Substring(i, 2).ToString());
                        else
                            htPunctuation.Add(j, strValue.Substring(i, 1).ToString());
                    }
                    else
                        break;
                    j++;

                }
            }
            if (Native == Criteria.Foreign)
            {
                for (int i = 0; i < strValue.Length; i = i + 3)
                {
                    if (strValue.Substring(i).Length > 0)
                    {
                        if (strValue.Substring(i).Length >= 3)
                            htPunctuation.Add(j, strValue.Substring(i, 3).ToString());
                        else
                            htPunctuation.Add(j, strValue.Substring(i).ToString());
                    }
                    j++;
                }
            }
        }
        private string Reverse(string strValue)
        {
            string Reversed = String.Empty;
            foreach (char Ch in strValue)
            {
                Reversed = Ch + Reversed;
            }
            return Reversed;
        }
        private string GetWordConversion(string inputNumber)
        {
            string ToReturnWord = String.Empty;
            if (inputNumber.Length <= 3 && inputNumber.Length > 0)
            {
                if (inputNumber.Length == 3)
                {
                    if (int.Parse(inputNumber.Substring(0, 1)) > 0)
                        ToReturnWord = ToReturnWord + StaticSuffixFind(inputNumber.Substring(0, 1)) + "Hundread ";

                    string TempString = StaticSuffixFind(inputNumber.Substring(1, 2));

                    if (TempString == "")
                    {
                        ToReturnWord = ToReturnWord + StaticSuffixFind(inputNumber.Substring(1, 1) + "0");
                        ToReturnWord = ToReturnWord + StaticSuffixFind(inputNumber.Substring(2, 1));
                    }
                    ToReturnWord = ToReturnWord + TempString;
                }
                if (inputNumber.Length == 2)
                {
                    string TempString = StaticSuffixFind(inputNumber.Substring(0, 2));
                    if (TempString == "")
                    {
                        ToReturnWord = ToReturnWord + StaticSuffixFind(inputNumber.Substring(0, 1) + "0");
                        ToReturnWord = ToReturnWord + StaticSuffixFind(inputNumber.Substring(1, 1));
                    }
                    ToReturnWord = ToReturnWord + TempString;
                }
                if (inputNumber.Length == 1)
                {
                    ToReturnWord = ToReturnWord + StaticSuffixFind(inputNumber.Substring(0, 1));
                }

            }
            return ToReturnWord;
        }
        internal string StaticSuffixFind(string NumberKey)
        {
            string ValueFromNumber = String.Empty;
            if(DictStaticSuffix.ContainsKey(int.Parse(NumberKey)))
                ValueFromNumber = DictStaticSuffix[int.Parse(NumberKey)];
            return ValueFromNumber;
        }
        private string StaticPrefixFind(string NumberKey)
        {
            string ValueFromNumber = String.Empty;
            if (DictStaticPrefix.ContainsKey(int.Parse(NumberKey)))
                ValueFromNumber = DictStaticPrefix[int.Parse(NumberKey)];
            return ValueFromNumber;
        }
        private string StaticHelpNotationFind(string NumberKey)
        {
            string HelpText = String.Empty;
            if (DictHelpNotation.ContainsKey(int.Parse(NumberKey)))
                HelpText = DictHelpNotation[int.Parse(NumberKey)];
            return HelpText;
        }
    }
}