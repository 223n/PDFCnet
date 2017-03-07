namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf Int
    /// </summary>
    public class PdfInt : IPdfElem
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Int Value</param>
        public PdfInt(int value) => Value = value;

        #endregion

        #region Property

        public int Value { get; set; }

        #endregion

        #region Method

        public override string ToString() => Value.ToString();

        #endregion

    }
}
