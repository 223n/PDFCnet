using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfXrefEntryUse
    {

        private PdfXrefEntryUse(bool isFree)
        {
            IsFreeEntry = isFree;
        }

        public bool IsFreeEntry { get; }

        public override string ToString() => (IsFreeEntry ? "f" : "n");

        public static readonly PdfXrefEntryUse FreeEntry = (new PdfXrefEntryUse(true));

        public static readonly PdfXrefEntryUse InUseEntry = (new PdfXrefEntryUse(false));

    }
}
