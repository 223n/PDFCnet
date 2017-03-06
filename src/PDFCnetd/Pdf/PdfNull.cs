using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfNull : IPdfElem
    {

        public override string ToString() => "null";

        public string ClassName { get; } = nameof(PdfNull);

    }
}
