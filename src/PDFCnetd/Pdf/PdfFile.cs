using System.Collections.Generic;
using System.Text;

namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf File
    /// </summary>
    public class PdfFile
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="header">Header</param>
        /// <param name="rootRef">Root Object Number</param>
        public PdfFile(PdfHeader header, int rootRef)
        {
            Header = header;
            RootRef = rootRef;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="major">Majour Version</param>
        /// <param name="minor">Minor Version</param>
        /// <param name="rootRef">Root Object Number</param>
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

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.Append(Header.ToString());
            var xref = new PdfXref();
            xref.Value.Add(new PdfXrefEntry(0, 65535, PdfXrefEntryUse.FreeEntry));
            int offset = Encoding.GetEncoding("Shift-JIS").GetByteCount(Header.ToString());
            foreach (var obj in PdfObjects)
            {
                xref.Value.Add(new PdfXrefEntry(offset, 0, PdfXrefEntryUse.InUseEntry));
                string str = obj.ToString();
                ret.Append(str);
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
