using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfStream : IPdfElem
    {

        #region Constructor

        public PdfStream(string value) => Value = value;

        #endregion

        #region Property

        public string Value { get; set; }

        public string ClassName { get; } = nameof(PdfStream);

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendPdfLine("<<");
            ret.AppendPdfFormatLine("/Length {0}", Value.Length);
            ret.AppendPdfLine(">>");
            ret.AppendPdfLine("stream");
            ret.AppendPdfLine(Value);
            ret.Append("endstream");
            return ret.ToString();
        }

        #endregion  

    }
}
