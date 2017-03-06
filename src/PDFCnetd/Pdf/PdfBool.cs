using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfBool : IPdfElem
    {

        #region Constructor

        public PdfBool(bool value) => Value = value;

        #endregion

        #region Property

        public bool Value { get; set; }

        public string ClassName { get; } = nameof(PdfBool);

        #endregion

        #region Method

        public override string ToString() => (Value ? "true" : "false");

        #endregion

    }
}
