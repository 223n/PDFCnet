using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfString : IPdfElem
    {

        #region Constructor

        public PdfString(string value) => Value = value;

        public PdfString(string value, bool isAscii)
        {
            Value = value;
            IsAscii = isAscii;
        }

        #endregion

        #region Property

        public string Value { get; set; }

        public string ClassName { get; } = nameof(PdfString);

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
                    ret.AppendFormat("({0})", Value.Replace(@"\", @"\\").Replace("(", @"\(").Replace(")", @"\)"));
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
                    ret.AppendFormat("({0})", Value.Replace(@"\", @"\\").Replace("(", @"\(").Replace(")", @"\)"));
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
