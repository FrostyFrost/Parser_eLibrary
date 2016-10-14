using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WindowsFormsApplication1
{
    class YandexTranslate
    {
        public string AccessKey = "trnsl.1.1.20151208T085438Z.7afeb45c88f1a5e5.17bcd8744643ef41372f92702254f30bc5a123da";

        public string Transl(string text, string lang)
        {

            XmlDocument  result = new XmlDocument();
            result.Load(String.Format("https://translate.yandex.net/api/v1.5/tr/translate?key={0}&text={1}&lang={2}", AccessKey, text, lang));
            string str = result.InnerXml.ToString();
            if (str.IndexOf("Translation code=\"200\"") > 0)
            {
                str = str.Substring(str.IndexOf("<text>") + 6, str.IndexOf("</text>") - str.IndexOf("<text>") - 6);
            }
            else 
            {
            }
            return str;
        }   
    }
}
