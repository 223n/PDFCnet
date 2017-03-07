namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf XrefEntryUser
    /// </summary>
    public class PdfXrefEntryUse
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isFree">is free</param>
        private PdfXrefEntryUse(bool isFree) => IsFreeEntry = isFree;

        public bool IsFreeEntry { get; }

        public override string ToString() => (IsFreeEntry ? "f" : "n");

        public static readonly PdfXrefEntryUse FreeEntry = (new PdfXrefEntryUse(true));

        public static readonly PdfXrefEntryUse InUseEntry = (new PdfXrefEntryUse(false));

    }
}
