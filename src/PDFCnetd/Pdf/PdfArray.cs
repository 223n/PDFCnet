using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf Array
    /// </summary>
    public class PdfArray : IPdfElem, IList<IPdfElem>
    {

        #region Constructor

        public PdfArray(IPdfElem[] value) => Value.AddRange(value);

        #endregion

        #region Property

        private List<IPdfElem> Value { get; set; } = new List<IPdfElem>();

        public int Count => Value.Count;

        public bool IsReadOnly => false;

        public IPdfElem this[int index] { get => Value[index]; set => Value[index] = value; }

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder("[");
            foreach (var val in Value) ret.AppendFormat("{0} ", val.ToString());
            return string.Format("{0}]", ret.ToString().Trim());
        }

        public IEnumerator<IPdfElem> GetEnumerator() => Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Value.GetEnumerator();

        public int IndexOf(IPdfElem item) => Value.IndexOf(item);

        public void Insert(int index, IPdfElem item) => Value.Insert(index, item);

        public void RemoveAt(int index) => Value.RemoveAt(index);

        public void Add(IPdfElem item) => Value.Add(item);

        public void Clear() => Value.Clear();

        public bool Contains(IPdfElem item) => Value.Contains(item);

        public void CopyTo(IPdfElem[] array, int arrayIndex) => Value.CopyTo(array, arrayIndex);

        public bool Remove(IPdfElem item) => Value.Remove(item);

        #endregion

    }
}
