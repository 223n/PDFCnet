using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfObject
    {

        #region Constructor

        public PdfObject(int no, IPdfElem elem)
        {
            ObjNumber = no;
            Element = elem;
        }

        #endregion

        #region Property

        public int ObjNumber { get; set; }

        public IPdfElem Element { get; set; }

        public string ClassName { get; } = nameof(PdfObject);

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendPdfFormatLine("{0} 0 obj", ObjNumber);
            ret.AppendPdfLine(Element.ToString());
            ret.AppendPdfLine("endobj");
            return ret.ToString();
        }

        #endregion

    }
}
