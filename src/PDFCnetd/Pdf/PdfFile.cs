using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfFile
    {

        #region Constructor

        public PdfFile(PdfHeader header, int rootRef)
        {
            Header = header;
            RootRef = rootRef;
        }

        public PdfFile(int major, int minor, int rootRef)
        {
            Header = new PdfHeader(major, minor);
            RootRef = rootRef;
        }

        #endregion

        #region Property

        public PdfHeader Header { get; set; }

        public int RootRef { get; set; }

        public List<PdfObject> PdfObjects { get; set; } = new List<PdfObject>();

        public string ClassName { get; } = nameof(PdfFile);

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();

            ret.Append(Header.ToString());
            ret.AppendPdfLine();

            var xref = new PdfXref();
            xref.Value.Add(new PdfXrefEntry(0, 65535, PdfXrefEntryUse.FreeEntry));
            int offset = Encoding.GetEncoding("Shift-JIS").GetByteCount(Header.ToString());
            foreach (var obj in PdfObjects)
            {
                xref.Value.Add(new PdfXrefEntry(offset, 0, PdfXrefEntryUse.InUseEntry));
                string str = obj.ToString();
                ret.Append(str);
                ret.AppendPdfLine();
                offset += Encoding.GetEncoding("Shift-JIS").GetByteCount(str);
            }
            ret.Append(xref.ToString());
            var trailer = new PdfTrailer(RootRef, PdfObjects.Count + 1, offset);
            ret.Append(trailer.ToString());
            return ret.ToString();
        }

        #endregion

    }
}
