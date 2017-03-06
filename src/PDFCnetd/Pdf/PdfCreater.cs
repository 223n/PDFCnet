using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public static class PdfCreater
    {

        #region Method

        public static PdfFile TextsToPdf(string[] texts)
        {
            var file = new PdfFile(1, 7, 1);

            int n = texts.Length;
            int m = 6;

            var catalog = CreateCatalog();
            var topPage = CreateTopPage(m, n);
            var font = CreateFont();
            var fontCid = CreateCidFont();
            var fontDescriptor = CreateFontDescriptor();
            var pages = CreatePages(m, n);
            var contents = CreateContents(m, n, texts);

            file.PdfObjects.Add(catalog);
            file.PdfObjects.Add(topPage);
            file.PdfObjects.Add(font);
            file.PdfObjects.Add(fontCid);
            file.PdfObjects.Add(fontDescriptor);
            file.PdfObjects.AddRange(pages);
            file.PdfObjects.AddRange(contents);

            return file;
        }

        private static PdfObject CreateCatalog()
        {
            var dic = new PdfDict();
            dic.Add("Type", new PdfName("Catalog"));
            dic.Add("Pages", new PdfRef(2));
            var ret = new PdfObject(1, dic);
            return ret;
        }

        private static PdfObject CreateTopPage(int m, int n)
        {
            var dic = new PdfDict();
            dic.Add("Type", new PdfName("Pages"));
            dic.Add("Kids", new PdfArray(Enumerable.Range(m, n).Select(r => new PdfRef(r)).ToArray()));
            dic.Add("Count", new PdfInt(n));
            var ret = new PdfObject(2, dic);
            return ret;
        }

        private static PdfObject CreateFont()
        {
            var dicDetail = new PdfDict();
            dicDetail.Add("Type", new PdfName("Font"));
            dicDetail.Add("BaseFont", new PdfName("KozMinPr6N-Regular"));
            dicDetail.Add("Subtype", new PdfName("Type0"));
            dicDetail.Add("Encoding", new PdfName("90ms-RKSJ-H"));
            dicDetail.Add("DescendantFonts", new PdfArray(new IPdfElem[] { new PdfRef(4) }));

            var dicF0 = new PdfDict();
            dicF0.Add("F0", dicDetail);

            var dic = new PdfDict();
            dic.Add("Font", dicF0);

            var ret = new PdfObject(3, dic);
            return ret;
        }

        private static PdfObject CreateCidFont()
        {
            var cidDic = new PdfDict();
            cidDic.Add("Registry", new PdfString("Adobe", true));
            cidDic.Add("Ordering", new PdfString("Japan1", true));
            cidDic.Add("Supplement", new PdfInt(6));
            var dic = new PdfDict();
            dic.Add("Type", new PdfName("Font"));
            dic.Add("Subtype", new PdfName("CIDFontType0"));
            dic.Add("BaseFont", new PdfName("KozMinPr6N-Regular"));
            dic.Add("CIDSystemInfo", cidDic);
            dic.Add("FontDescriptor", new PdfRef(5));
            var ret = new PdfObject(4, dic);
            return ret;
        }

        private static PdfObject CreateFontDescriptor()
        {
            var dic = new PdfDict();
            dic.Add("Type", new PdfName("FontDescriptor"));
            dic.Add("FontName", new PdfName("KozMinPr6N-Regular"));
            dic.Add("Flags", new PdfInt(6));
            dic.Add("FontBBox", new PdfArray(new PdfInt[] { new PdfInt(-437), new PdfInt(-340), new PdfInt(1147), new PdfInt(1317) }));
            dic.Add("ItalicAngle", new PdfInt(0));
            dic.Add("Ascent", new PdfInt(1317));
            dic.Add("Descent", new PdfInt(-349));
            dic.Add("CapHeight", new PdfInt(742));
            dic.Add("StemV", new PdfInt(80));
            var ret = new PdfObject(5, dic);
            return ret;
        }

        private static List<PdfObject> CreatePages(int m, int n)
        {
            var ret = new List<PdfObject>();
            for (int i = m; i <= m + n - 1; i++)
            {
                var dic = new PdfDict();
                dic.Add("Type", new PdfName("Page"));
                dic.Add("Parent", new PdfRef(2));
                dic.Add("Resources", new PdfRef(3));
                dic.Add("MediaBox", new PdfArray(new PdfInt[] { new PdfInt(0), new PdfInt(0), new PdfInt(595), new PdfInt(842) }));
                dic.Add("Contents", new PdfRef(i + n));
                var obj = new PdfObject(i, dic);
                ret.Add(obj);
            }
            return ret;
        }

        private static List<PdfObject> CreateContents(int m, int n, string[] texts)
        {
            var ret = new List<PdfObject>();
            int index = 0;
            for (int i = m + n; i <= m + 2 * n - 1; i++)
            {
                var str = new StringBuilder();
                str.AppendPdfLine("1. 0. 0. 1. 50. 770. cm");
                str.AppendPdfLine("BT");
                str.AppendPdfLine("/F0 12 Tf");
                str.AppendPdfLine("16 TL");
                str.AppendPdfLine((new PdfString(texts[index])).ToString(" Tj T*"));
                str.Append("ET");
                var stream = new PdfStream(str.ToString());
                var obj = new PdfObject(i, stream);
                ret.Add(obj);
                index++;
            }
            return ret;
        }

        #endregion

    }
}
