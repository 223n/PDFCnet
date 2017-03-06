using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfHeader
    {

        #region Constructor

        public PdfHeader(int major, int minor) { PdfVersion = new Version(major, minor); }

        #endregion

        #region Property

        public Version PdfVersion { get; set; }

        public string ClassName { get; } = nameof(PdfHeader);

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendPdfFormatLine("%PDF-{0}.{1}", PdfVersion.Major, PdfVersion.Minor);
            ret.Append("%");
            foreach (var c in Encoding.GetEncoding("Shift-JIS").GetChars(new byte[] { 0xe2, 0xe3, 0xcf, 0xd3 }))
                ret.Append(c);
            ret.AppendPdfLine();
            return ret.ToString();
        }

        #endregion

    }
}
