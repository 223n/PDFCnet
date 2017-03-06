using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFCnetd.Pdf
{
    public class PdfDict : IPdfElem, IDictionary<string, IPdfElem>
    {

        #region Constructor

        public PdfDict() { }

        #endregion

        #region Field

        private Dictionary<string, IPdfElem> fDic = new Dictionary<string, IPdfElem>();

        private bool fIsReadOnly = false;

        #endregion

        #region Property

        public IPdfElem this[string key] { get => fDic[key]; set => fDic[key] = value; }

        public ICollection<string> Keys => fDic.Keys;

        public ICollection<IPdfElem> Values => fDic.Values;

        public int Count => fDic.Count;

        public bool IsReadOnly => fIsReadOnly;

        public string ClassName { get; } = nameof(PdfDict);

        #endregion

        #region Method

        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendPdfLine("<<");
            foreach (var key in fDic.Keys)
                ret.AppendPdfLine(string.Format("/{0} {1}", key, fDic[key].ToString()));
            ret.Append(">>");
            return ret.ToString();
        }

        public void Add(string key, IPdfElem value) => fDic.Add(key, value);

        public void Add(KeyValuePair<string, IPdfElem> item) => fDic.Add(item.Key, item.Value);

        public void Clear() => fDic.Clear();

        public bool Contains(KeyValuePair<string, IPdfElem> item) => fDic.Contains(item);

        public bool ContainsKey(string key) => fDic.ContainsKey(key);

        public void CopyTo(KeyValuePair<string, IPdfElem>[] array, int arrayIndex)
        {
            int index = arrayIndex - 1;
            foreach (string key in fDic.Keys)
                array[index++] = new KeyValuePair<string, IPdfElem>(key, fDic[key]);
        }

        public IEnumerator<KeyValuePair<string, IPdfElem>> GetEnumerator() => fDic.GetEnumerator();

        public bool Remove(string key) => fDic.Remove(key);

        public bool Remove(KeyValuePair<string, IPdfElem> item)
        {
            if (fDic.Contains(item))
            {
                fDic.Remove(item.Key);
                return true;
            }
            else
                return false;
        }

        public bool TryGetValue(string key, out IPdfElem value) => fDic.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => fDic.GetEnumerator();

        #endregion

    }
}
