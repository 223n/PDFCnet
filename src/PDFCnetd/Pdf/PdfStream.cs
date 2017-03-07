using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf Stream
    /// </summary>
    public class PdfStream : IPdfElem
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Stream Value</param>
        public PdfStream(string value) => Value = value;

        #endregion

        #region Property

        public string Value { get; set; }

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
