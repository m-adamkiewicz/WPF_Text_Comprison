using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Comparer
{
    static class StringComparision
    {
        public static int a = 1;
        public static string Compare(string[] str1, string[] str2, int line)
        {
            //StringBuilder initializated to modify returned string
            StringBuilder str_comparision_result = new StringBuilder();
            //additional bool variables for equality and empty line detection
            bool equal, empty = false;
            // First line of result 
            str_comparision_result.Append("Comparision result:\n");
            //Check if "line" do not exceed number of rows in both string, if so then write messsage and skip comparision
            if (line > str1.Length && line > str2.Length)
                str_comparision_result.Append("Selected line do not exist in both files!");
            else if (line > str1.Length)
                str_comparision_result.Append("Selected Line do not exists in File 1");
            else if (line > str2.Length)
                str_comparision_result.Append("Selected Line do not exists in File 2");
           
            //Additional comparision only if selected line exists in both files
            else
            {
                //End of line, tabulator and signs are ignored
                string str1_dup = str1[line - 1].Trim('\r', '\t');
                string str2_dup = str2[line - 1].Trim('\r', '\t');
                str_comparision_result.Append(Text_Equal(str1_dup, str2_dup, out equal));
                if (!equal)
                {
                    str_comparision_result.Append(Empty_Line(str1_dup, str2_dup, out empty));
                    if (!empty)
                        str_comparision_result.Append(Text_Letter_Size_Mismatch(str1_dup, str2_dup));
                }
            }

            return str_comparision_result.ToString();
        }
       
        //Compare if text in both files is equal - with additional info about two empty lines
        private static string Text_Equal(string str1, string str2, out bool equal)
        {
            if (str1 != "" || str2 != "")
            {
                if (str1.Equals(str2))
                {
                    equal = true;
                    return "Lines are equal";
                }
                else
                {
                    equal = false;
                    return "Lines are not equal. \nDifferences: \n";
                }
            }
            else
            {
                equal = true;
                return "Lines are equal, but both are empty";
            }
        }

        //Return info if there is an empty line in one of files
        private static string Empty_Line(string str1, string str2, out bool empty)
        {
            if (str1 == "")
            {
                empty = true;
                return "Line in File 1 is empty";                
            }
            else if (str2 == "")
            {
                empty = true;
                return "Line in File 2 is empty";             
            }
            else
            {
                empty = false;
                return "";
            }
        }

        //Check if the only difference between lines is letter size
        private static string Text_Letter_Size_Mismatch(string str1, string str2)
        {
            if ((str1.ToLower()).Equals(str2.ToLower()))
                return "Mismatch between letters size";
            else
                return "Lines have different chars";
        }

    }
}
