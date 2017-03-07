namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf Ref
    /// </summary>
    public class PdfRef : IPdfElem
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Pdf Ref</param>
        public PdfRef(int value) => Value = value;

        #endregion

        #region Property

        public int Value { get; set; }

        #endregion

        #region Method

        public override string ToString() => string.Format("{0} 0 R", Value);

        #endregion

    }
}
