using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdf1 = PDFCnetd.Pdf.PdfCreator.TextsToPdf(new string[] { "abcde012345" });
            System.IO.File.WriteAllText("text1.pdf", pdf1.ToString());
            var pdf2 = PDFCnetd.Pdf.PdfCreator.TextsToPdf(new string[] { "子丑寅卯辰巳午未申酉戌亥\n甲乙丙丁戊己庚辛壬癸\nあいうえお かきくけこ" });
            System.IO.File.WriteAllText("text2.pdf", pdf2.ToString());
        }
    }
}
