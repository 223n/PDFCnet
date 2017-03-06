using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfXrefEntry
    {

        #region constructor

        public PdfXrefEntry(int generation, int offset, PdfXrefEntryUse use)
        {
            Generation = generation;
            Offset = offset;
            Use = use;
        }

        #endregion

        #region Property

        public int Generation { get; set; }

        public int Offset { get; set; }

        public PdfXrefEntryUse Use { get; set; }

        public string ClassName { get; } = nameof(PdfXref);

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendFormat("{0:D10} ", Generation);
            ret.AppendFormat("{0:D5} ", Offset);
            ret.AppendPdfFormatLine("{0} ", Use.ToString());
            return ret.ToString();
        }

        #endregion

    }
}
