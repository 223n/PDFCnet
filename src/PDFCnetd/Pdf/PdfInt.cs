using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfInt : IPdfElem
    {

        #region Constructor

        public PdfInt(int value) => Value = value;

        #endregion

        #region Property

        public int Value { get; set; }

        public string ClassName { get; } = nameof(PdfInt);

        #endregion

        #region Method

        public override string ToString() => Value.ToString();

        #endregion

    }
}
