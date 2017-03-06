using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfXref : IEnumerable<PdfXrefEntry>
    {

        #region Constructor

        public PdfXref() { }

        public PdfXref(PdfXrefEntry[] entries) => Value.AddRange(entries);

        #endregion

        #region Property

        public List<PdfXrefEntry> Value { get; set; } = new List<PdfXrefEntry>();

        public string ClassName { get; } = nameof(PdfXref);

        #endregion

        #region Method

        public IEnumerator<PdfXrefEntry> GetEnumerator() => Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Value.GetEnumerator();

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendPdfLine("xref");
            ret.AppendPdfFormatLine("0 {0}", Value.Count);
            foreach (var entry in Value) ret.Append(entry.ToString());
            return ret.ToString();
        }

        #endregion

    }
}
