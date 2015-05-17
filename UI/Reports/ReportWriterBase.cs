using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Willowsoft.Ordering.UI.Reports
{
    public class ReportWriterBase
    {
        protected TextWriter mTextWriter;

        public void Init(TextWriter textWriter)
        {
            mTextWriter = textWriter;
        }

        public virtual void AddToStylesheet()
        {
            WriteLine(".TableBorder { border:1px solid black; border-collapse:collapse; }");
            WriteLine(".Hilite { background-color: #F0F0F0; }");
            WriteLine(".TableCell { font-size: 9pt; border:1px solid black; }");
        }

        public void WriteLine(string text)
        {
            mTextWriter.WriteLine(text);
        }

        public void TableHeader(string text)
        {
            WriteLine("<th class='TableCell'>" + text + "</th>");
        }

        public void TableCellLeft(string text)
        {
            WriteLine("<td class='TableCell'>" + (string.IsNullOrEmpty(text) ? "&nbsp;" : text) + "</td>");
        }

        public void TableCellLeftHilite(string text)
        {
            WriteLine("<td class='TableCell Hilite'>" + (string.IsNullOrEmpty(text) ? "&nbsp;" : text) + "</td>");
        }

        public void TableCellRight(string text)
        {
            WriteLine("<td class='TableCell' align='right'>" + (string.IsNullOrEmpty(text) ? "&nbsp;" : text) + "</td>");
        }

        public void TableCellRightHilite(string text)
        {
            WriteLine("<td class='TableCell Hilite' align='right'>" + (string.IsNullOrEmpty(text) ? "&nbsp;" : text) + "</td>");
        }
    }
}
