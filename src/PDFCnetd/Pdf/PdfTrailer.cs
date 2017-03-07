using System.Text;

namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf Trailer
    /// </summary>
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
        
        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendPdfLine("trailer");
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
