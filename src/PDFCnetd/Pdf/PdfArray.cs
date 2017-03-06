using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfArray : IPdfElem, IEnumerable<IPdfElem>
    {

        #region Constructor

        public PdfArray(IPdfElem[] value) => Value.AddRange(value);

        #endregion

        #region Property

        public List<IPdfElem> Value { get; set; } = new List<IPdfElem>();

        public string ClassName { get; } = nameof(PdfArray);

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

        #endregion

    }
}
