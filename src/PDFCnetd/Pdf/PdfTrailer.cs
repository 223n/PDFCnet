using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfTrailer
    {

        #region Constructor

        public PdfTrailer(int root, int size, int startXref)
        {
            Root = new PdfRef(root);
            Size = new PdfInt(size);
            StartXref = new PdfInt(startXref);
        }

        #endregion

        #region Property

        public PdfRef Root { get; set; }

        public PdfInt Size { get; set; }

        public PdfInt StartXref { get; set; }

        public string ClassName { get; } = nameof(PdfTrailer);

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendPdfLine("trailer");
            ret.AppendPdfLine();
            ret.AppendPdfLine(CreatePdfDic().ToString());
            ret.AppendPdfLine("startxref");
            ret.AppendPdfLine(StartXref.ToString());
            ret.AppendPdfLine("%%EOF");
            return ret.ToString();
        }

        private PdfDict CreatePdfDic()
        {
            var ret = new PdfDict();
            ret.Add("Root", Root);
            ret.Add("Size", Size);
            return ret;
        }

        #endregion

    }
}
