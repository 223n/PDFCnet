using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfRef : IPdfElem
    {

        #region Constructor

        public PdfRef(int value) => Value = value;

        #endregion

        #region Property

        public int Value { get; set; }

        public string ClassName { get; } = nameof(PdfRef);

        #endregion

        #region Method

        public override string ToString() => string.Format("{0} 0 R", Value);

        #endregion

    }
}
