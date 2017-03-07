using System;
using System.Text;

namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf Header
    /// </summary>
    public class PdfHeader
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="major">Major Version</param>
        /// <param name="minor">Minor Version</param>
        public PdfHeader(int major, int minor) { PdfVersion = new Version(major, minor); }

        #endregion

        #region Property

        public Version PdfVersion { get; set; }

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
