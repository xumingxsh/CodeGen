using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CodeGen.Tool
{
    class ControlUtils
    {
        public static void SetSQLColor(RichTextBox ctrl)
        {
            int pos = ctrl.SelectionStart;
            ctrl.SelectAll();
            ctrl.SelectionColor = Color.Black;
            string[] keywords = { "select", "distinct", "from", "where", 
                                    "order", "by", "group", "null","desc","asc",
                                    "update","delete","insert", "into", "set" };
            SetColor(ctrl, keywords);
            ctrl.SelectionStart = pos;
            ctrl.Select(pos, 0);
        }


        public  static void SetHTMLColor(RichTextBox ctrl)
        {

            ctrl.SelectAll();
            ctrl.SelectionColor = Color.Black;
            int pos = ctrl.SelectionStart;
            /*
            string[] keywords = { "<html", "</html", "<head", "</head", "<title","</title", "<body", "</body", 
                                    "<input", "<select", "</select","<option","<div","</div", "<label","<form", "</form",
                                    "<script", "</script","<style","</style", "<table", "</table", 
                                    "<tr","</tr","<td","</td","<font"};
            SetColor(ctrl, keywords, Color.Blue);*/
            SetHTMLTagColor(ctrl);
            string[] keywords2 = { " action"," class", "class "," rowspan", " colspan", 
                                " align","function ", "return ", "return;", "break;", "continue;"
                                 ,"if\\(", "if ", "else", "try", "catch", "finaly", "switch", "case ",
                                 "for ","for\\(", "foreach", "int ", "string ", "float ",
                                 "decimal ", "DateTime ","long ", "double ", "void ", "while ", "while\\(", " in ",
                                 "private ", "protected ", "public ", "inneral",
                                 "abstract ", "override ", "static ", "const ",
                                 "partial ", "using ", "this.", "base\\.", "namespace ", "where ",
                                 "throw ", " type", " id", " as ", " is ", "typeof", "value",
                                 "package ", "import ", "final ", "\\#include "};
            SetColor(ctrl, keywords2, Color.Red);
            ctrl.SelectionStart = pos;
            ctrl.Select(pos, 0);
        }

        private static void SetHTMLTagColor(RichTextBox ctrl)
        {
            int start = 0;
            int end = 0;

            while (true)
            {
                start = ctrl.Text.IndexOf("<", end);
                if (start < 0)
                {
                    break;
                }

                int end1 = ctrl.Text.IndexOf(">", start);
                int end2 = ctrl.Text.IndexOf(" ", start);
                end = end1 > end2 ? end2 : end1;
                if (end < 0)
                {
                    break;
                }
                ctrl.Select(start, end - start);
                ctrl.SelectionColor = Color.Blue;
            }
        }

        private static void SetColor(RichTextBox ctrl, string[] keywords)
        {
            SetColor(ctrl, keywords, Color.Blue);
        }
        private static void SetColor(RichTextBox ctrl, string[] keywords, Color color)
        {

            foreach (string word in keywords)
            {
                Regex r = new Regex(word, RegexOptions.IgnoreCase);

                foreach (Match m in r.Matches(ctrl.Text))
                {
                    ctrl.Select(m.Index, m.Length);
                    ctrl.SelectionColor = color;
                }
            }
        }
    }
}
