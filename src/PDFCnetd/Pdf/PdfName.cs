using System;
using System.Text;

namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf Name
    /// </summary>
    public class PdfName : IPdfElem
    {

        #region Construcotr

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">Pdf Name</param>
        public PdfName(string text) => Value = text;

        #endregion

        #region Property

        public string Value { get; set; }

        #endregion

        #region Method

        public override string ToString() => string.Format("/{0}", ConvertASCIIString(Value));

        private string ConvertASCIIString(string value)
        {
            var ret = new StringBuilder();
            foreach (char c in value)
            {
                int b = Convert.ToInt32(c);
                if (0x30 <= b && b <= 0x39)
                    ret.Append(c);  // 0 to 9
                else if (0x41 <= b && b <= 0x5a)
                    ret.Append(c);  // A to Z
                else if (0x61 <= b && b <= 0x7a)
                    ret.Append(c);  // a to z
                else if (0x2d == b)
                    ret.Append(c);
                else
                    ret.AppendFormat("#{0}", b);
            }
            return ret.ToString();
        }

        #endregion

    }
}
