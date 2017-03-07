using System.Text;

namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf Object
    /// </summary>
    public class PdfObject
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="no">Object Number</param>
        /// <param name="elem">Object Value</param>
        public PdfObject(int no, IPdfElem elem)
        {
            ObjNumber = no;
            Element = elem;
        }

        #endregion

        #region Property

        public int ObjNumber { get; set; }

        public int ObjRev { get; set; }

        public IPdfElem Element { get; set; }

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendPdfFormatLine("{0} {1} obj", ObjNumber, ObjRev);
            ret.AppendPdfLine(Element.ToString());
            ret.AppendPdfLine("endobj");
            return ret.ToString();
        }

        #endregion

    }
}
