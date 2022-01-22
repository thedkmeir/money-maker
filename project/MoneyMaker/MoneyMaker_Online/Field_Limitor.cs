using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MoneyMaker_Online
{
    public class Field_Limitor
    {

        //password:
        //length 8-20:
        //has at least one letter
        //has at least one upercut letter
        //has at least one number
        //no signs

        //fname / lname
        //length 2-15
        //no signs 
        //no numbers

        //money
        //only numbers
        //every length

        //rest (comments, description....)
        //no signs

        static public string length(int max, int min, string str)
        {
            if (str.Length > max)
            {
                return "is too long";
            }

            if (str.Length < min)
            {
                return "is too short";
            }

            return "";
        }

        static public bool length_check(int max, int min, string str)
        {
            if (str.Length > max)
            {
                return false;
            }
            else if (str.Length < min)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static public string letters(string str)
        {
            foreach (char character in str)
            {
                if (Char.IsLetter(character))
                {
                    return "has letters";
                }
            }
            return "";
        }

        //if only letters return true
        static public bool letter_check(string str)
        {
            foreach (char character in str)
            {
                if (!Char.IsLetter(character))
                {
                    return false;
                }
            }
            return true;
        }

        static public bool has_letter(string str)
        {
            foreach (char character in str)
            {
                if (Char.IsLetter(character))
                {
                    return true;
                }
            }
            return false;
        }

        static public string numbers(string str)
        {
            foreach (char character in str)
            {
                if (Char.IsNumber(character))
                {
                    return "has number";
                }
            }
            return "";
        }

        static public bool number_check(string str)
        {
            foreach (char character in str)
            {
                if (!Char.IsNumber(character))
                {
                    if (character == '-')
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static public bool has_number(string str)
        {
            foreach (char character in str)
            {
                if (Char.IsNumber(character))
                {
                    return true;
                }
            }
            return false;
        }

        static public string signs(string str)
        {
            foreach (char character in str)
            {
                if (!Char.IsLetterOrDigit(character))
                {
                    return "has illegal characters!!!";
                }
            }
            return "";
        }

        //if ther is any sign exept the stuff in the if return false
        static public bool signs_check_alltext(string str)
        {
            foreach (char character in str)
            {
                if (character.ToString() == "@" || character.ToString() == "." || character.ToString() == " " || character.ToString() == "_" || character.ToString() == "-" || character.ToString() == ",")
                {

                }
                else
                {
                    if (!Char.IsLetterOrDigit(character))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //if there any sign besides "-" then return true
        static public bool signs_check_numbers(string str)
        {
            foreach (char character in str)
            {
                if (!Char.IsLetterOrDigit(character))
                {
                    if (character != '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //only numbers at all cost if only number return true
        static public bool only_numbers(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        static public string uppercut(string str)
        {
            foreach (char character in str)
            {
                if (!Char.IsLower(character))
                {
                    return "has uppercut letter";
                }
            }
            return "";
        }

        static public bool uppercut_check(string str)
        {
            foreach (char character in str)
            {
                if (!Char.IsLower(character))
                {
                    return true;
                }
            }
            return false;
        }

        static public bool has_uppercut(string str)
        {
            foreach (char character in str)
            {
                if (Char.IsUpper(character))
                {
                    return true;
                }
            }
            return false;
        }

        static public bool has_lowercut(string str)
        {
            foreach (char character in str)
            {
                if (Char.IsLower(character))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
