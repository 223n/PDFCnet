using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf Xref
    /// </summary>
    public class PdfXref : IList<PdfXrefEntry>
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public PdfXref() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entries">PdfXrefEntry Array</param>
        public PdfXref(PdfXrefEntry[] entries) => Value.AddRange(entries);

        #endregion

        #region Property

        public List<PdfXrefEntry> Value { get; set; } = new List<PdfXrefEntry>();

        public int Count => Value.Count;

        public bool IsReadOnly => false;

        public PdfXrefEntry this[int index] { get => Value[index]; set => Value[index] = value; }

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendPdfLine("xref");
            ret.AppendPdfFormatLine("0 {0}", Value.Count);
            foreach (var entry in Value) ret.Append(entry.ToString());
            return ret.ToString();
        }

        public IEnumerator<PdfXrefEntry> GetEnumerator() => Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Value.GetEnumerator();

        public int IndexOf(PdfXrefEntry item) => Value.IndexOf(item);

        public void Insert(int index, PdfXrefEntry item) => Value.Insert(index, item);

        public void RemoveAt(int index) => Value.RemoveAt(index);

        public void Add(PdfXrefEntry item) => Value.Add(item);

        public void Clear() => Value.Clear();

        public bool Contains(PdfXrefEntry item) => Value.Contains(item);

        public void CopyTo(PdfXrefEntry[] array, int arrayIndex) => Value.CopyTo(array, arrayIndex);

        public bool Remove(PdfXrefEntry item) => Value.Remove(item);

        #endregion

    }
}
