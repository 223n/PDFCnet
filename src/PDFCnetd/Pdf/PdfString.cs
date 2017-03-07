using System;
using System.Text;

namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf String
    /// </summary>
    public class PdfString : IPdfElem
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">String Value</param>
        public PdfString(string value) => Value = value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">String Value</param>
        /// <param name="isAscii">Is Ascii String</param>
        public PdfString(string value, bool isAscii)
        {
            Value = value;
            IsAscii = isAscii;
        }

        #endregion

        #region Property

        public string Value { get; set; }

        public bool IsAscii { get; set; } = false;

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            bool isRet = false;

            if (IsAscii)
                foreach (string txt in Value.Split('\n'))
                {
                    if (isRet) ret.AppendPdfLine(); else isRet = true;
                    ret.AppendFormat("({0})", Value.ToEscapeString());
                }
            else
            {
                foreach (string txt in Value.Split('\n'))
                {
                    if (isRet) ret.AppendPdfLine(); else isRet = true;
                    ret.Append("<");
                    foreach (var c in Encoding.GetEncoding("Shift-JIS").GetBytes(txt)) ret.Append(Convert.ToString((int)c, 16));
                    ret.Append(">");
                }
            }
            return ret.ToString().Trim();
        }

        public string ToString(string terminatString)
        {
            var ret = new StringBuilder();
            bool isRet = false;

            if (IsAscii)
                foreach (string txt in Value.Split('\n'))
                {
                    if (isRet) ret.AppendPdfLine(); else isRet = true;
                    ret.AppendFormat("({0})", Value.ToEscapeString());
                    ret.Append(terminatString);
                }
            else
            {
                foreach (string txt in Value.Split('\n'))
                {
                    if (isRet) ret.AppendPdfLine(); else isRet = true;
                    ret.Append("<");
                    foreach (var c in Encoding.GetEncoding("Shift-JIS").GetBytes(txt)) ret.Append(Convert.ToString((int)c, 16));
                    ret.Append(">");
                    ret.Append(terminatString);
                }
            }
            return ret.ToString().Trim();
        }

        #endregion

    }
}
