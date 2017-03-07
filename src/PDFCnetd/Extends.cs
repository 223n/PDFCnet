using System.Text;

namespace PDFCnetd
{
    public static class Extends
    {

        public static string ToEscapeString(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value; else return value.Replace(@"\", @"\").Replace("(", @"\(").Replace(")", @"\)");
        }

        public static void AppendPdfLine(this StringBuilder builder) => builder.Append(Common.PdfLf);

        public static void AppendPdfLine(this StringBuilder builder, string str) => builder.AppendFormat("{0}{1}", str, Common.PdfLf);

        public static void AppendPdfFormatLine(this StringBuilder builder, string format, params object[] args) => builder.AppendPdfLine(string.Format(format, args));

    }
}
