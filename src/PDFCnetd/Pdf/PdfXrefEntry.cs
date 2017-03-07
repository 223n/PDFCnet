using System.Text;

namespace PDFCnetd.Pdf
{
    public class PdfXrefEntry
    {

        #region constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="generation">Generation</param>
        /// <param name="offset">Offset</param>
        /// <param name="use">free entry / use entry</param>
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
