namespace PDFCnetd.Pdf
{
    /// <summary>
    /// Pdf Bool
    /// </summary>
    public class PdfBool : IPdfElem
    {

        #region Constructor

        public PdfBool(bool value) => Value = value;

        #endregion

        #region Property

        public bool Value { get; set; }

        #endregion

        #region Method

        public override string ToString() => (Value ? "true" : "false");

        #endregion

    }
}
