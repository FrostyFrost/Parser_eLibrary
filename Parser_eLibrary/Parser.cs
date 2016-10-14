using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Xml;


namespace WindowsFormsApplication1
{


    public partial class Parser : Form
    {
        public int ir = 0;
        public string fulltext = "";
        public Parser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.progressBar1.Value = 10;
            string write = "";
            string abstr = "";
            //ir++;
            string read = null;
            //var s = new StreamReader(@"D:\Учеба\Text categorization\Выборки\GL\Vib58+.txt", Encoding.GetEncoding(1251));
            //int ie = 58;
            //int ir = 8;
            //string sub = "";
            //bool open = false;
            string path = this.textBoxPath.Text ;

            HttpWebRequest req;
            HttpWebResponse resp;
            StreamReader sr;
            string content;

            string url  = this.textBoxURL.Text ; //http://elibrary.ru/item.asp?id=12568047   http://elibrary.ru/item.asp?id=9734106   elibrary.ru/item.asp?id=20992362
            
            this.progressBar1.Value = 30;
           
            req = (HttpWebRequest)WebRequest.Create(url);
            req.AllowAutoRedirect = false;
            resp = (HttpWebResponse)req.GetResponse();

            if (resp.Headers["Location"] != null)
            {
                CookieCollection cookies = resp.Cookies;
                resp.Close();
                req = null;
                req = (HttpWebRequest)WebRequest.Create(url);
                req.CookieContainer = new CookieContainer();
                foreach (Cookie oneCookie in cookies)
                {
                    req.CookieContainer.Add(oneCookie);
                }
                resp = (HttpWebResponse)req.GetResponse();
            }

            sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            content = sr.ReadToEnd();
            sr.Close();
            read = content;

            //у нас точно русские и англ описания, поэтому убираем
          //  if ((content.IndexOf("title_ru") <= 0) | (content.IndexOf("summary_ru") <= 0) | (content.IndexOf("title_en") <= 0) | (content.IndexOf("summary_en") <= 0)) { break; };

            //Заголовок русский
            write = content.Substring(content.IndexOf("<title>"), (content.IndexOf("</title>") - (content.IndexOf("<title>"))));
            write += "\r\n";

            //Ключевые слова русский
            string pattern = @"\S*keywordid\S*[А-я](\s\w+)*";
            foreach (Match match in Regex.Matches(content, pattern, RegexOptions.IgnoreCase))
            {
                write += match.ToString().Substring(match.ToString().IndexOf(">"), (match.ToString().Length) - (match.ToString().IndexOf(">")));
                write += ", ";
            };
            write += "\r\n";

            //аннотация русский
           
                abstr = content.Substring(content.IndexOf("<p align=\"justify\">"), (content.IndexOf("</font></td></tr></table>\r") - (content.IndexOf("<p align=\"justify\">"))));
                write += abstr;

                //delete stop-words
                write = write.Replace("<title>", "");
                write = write.Replace("<p align=\"justify\">", "");
                write = write.Replace("&nbsp;", "");
                write = write.Replace("eLIBRARY.RU - ", "");
                write = write.Replace("</i>", "");
                write = write.Replace("<i>", "");
                write = write.Replace("eLIBRARY.RU", "");
                write = write.Replace(">", "");
                write = write.Replace("</a", "");

            //проверка что документ ранее не встречался
                abstr = abstr.Replace("<title>", "");
                abstr = abstr.Replace("<p align=\"justify\">", "");
                abstr = abstr.Replace("&nbsp;", "");
                abstr = abstr.Replace("eLIBRARY.RU - ", "");
                abstr = abstr.Replace("</i>", "");
                abstr = abstr.Replace("<i>", "");
                abstr = abstr.Replace("eLIBRARY.RU", "");
                abstr = abstr.Replace(">", "");
                abstr = abstr.Replace("</a", "");

                if (!(fulltext.Contains(abstr)))
                {

                    StreamWriter w = new StreamWriter(path + "\\rus\\r" + path.Substring(path.Length - 2) + (ir +1) + ".txt", true);
                    w.WriteLine(write);
                    w.Close();


                    this.progressBar1.Value = 50;

                    //Английская часть
                    write = "";

                    try
                    {
                        //Заголовок англ
                        write = content.Substring(content.IndexOf("<font color=#000000>", content.IndexOf("ОПИСАНИЕ НА АНГЛИЙСКОМ ЯЗЫКЕ")), (content.IndexOf("</font>\r", content.IndexOf("ОПИСАНИЕ НА АНГЛИЙСКОМ ЯЗЫКЕ")) - content.IndexOf("<font color=#000000>", content.IndexOf("ОПИСАНИЕ НА АНГЛИЙСКОМ ЯЗЫКЕ"))));
                        write += "\r\n";

                        //Ключевые слова англ


                        pattern = @"\S*keywordid\S*[A-Z](\s\w+)*./";
                        foreach (Match match in Regex.Matches(content, pattern, RegexOptions.IgnoreCase))
                        {
                            write += match.ToString().Substring(match.ToString().IndexOf(">"), (match.ToString().Length) - (match.ToString().IndexOf(">")));
                            write += ", ";
                        };
                        write += "\r\n";

                        //аннотация англ
                        write += content.Substring(content.IndexOf("<p align=\"justify\">", content.IndexOf("ОПИСАНИЕ НА АНГЛИЙСКОМ ЯЗЫКЕ")), (content.IndexOf("</td></tr>\r", content.IndexOf("<p align=\"justify\">", content.IndexOf("ОПИСАНИЕ НА АНГЛИЙСКОМ ЯЗЫКЕ"))) - content.IndexOf("<p align=\"justify\">", content.IndexOf("ОПИСАНИЕ НА АНГЛИЙСКОМ ЯЗЫКЕ"))));

                        //delete stop-words
                        write = write.Replace("<title>", "");
                        write = write.Replace("<p align=\"justify\">", "");
                        write = write.Replace("&nbsp;", "");
                        write = write.Replace("eLIBRARY.RU - ", "");
                        write = write.Replace("</i>", "");
                        write = write.Replace("<i>", "");
                        write = write.Replace("eLIBRARY.RU", "");
                        write = write.Replace(">", "");
                        write = write.Replace("<font color=#000000", "");
                        write = write.Replace("</a", "");
                        write = write.Replace("</", "");

                        w = new StreamWriter(path + "\\eng\\e" + path.Substring(path.Length - 2) + (ir+1) + ".txt", true);
                        w.WriteLine(write);
                        w.Close();

                        ir++;
                        this.textBoxIR.Text = ir.ToString();
                        this.progressBar1.Value = 0;
                    }
                    catch
                    {
                        System.IO.File.Delete(path + "\\rus\\r" + path.Substring(path.Length - 2) + (ir+1) + ".txt"); // Delete russian part if there's no english
                        this.progressBar1.Value = 0;
                        
                    }
                }
                else
                {
                    this.progressBar1.Value = 0;
                    MessageBox.Show("Такой документ уже есть");
                    
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ir = int.Parse(this.textBoxIR.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string path = this.textBoxPath.Text;
            string write = "";
            //StreamReader w;

            for (int i = 1; i <= Convert.ToInt16(this.textBoxIR.Text); i++)
            { 
                //w = new StreamReader (path + "\\rus\\r"+path.Substring(path.Length - 2) + i+".txt");
                //слить все в документы в один файл

                write += System.IO.File.ReadAllText(path + "\\rus\\r" + path.Substring(path.Length - 2) + i + ".txt", Encoding.GetEncoding(1251)); 


            }
            File.WriteAllText(path + "\\vib\\all.txt",write);

        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string path = this.textBoxPath.Text ;
            for (int i = 0; i < 80; i++)
            {
                int a = rnd.Next(1, 150);
                int b = rnd.Next(1, 150);
                if (a != b)
                {
                    File.Move(path + "\\rus\\r" + path.Substring(path.Length - 2) + a + ".txt", path + "\\rus\\r" + path.Substring(path.Length - 2) + a + "_.txt");
                    File.Move(path + "\\rus\\r" + path.Substring(path.Length - 2) + b + ".txt", path + "\\rus\\r" + path.Substring(path.Length - 2) + a + ".txt");
                    File.Move(path + "\\rus\\r" + path.Substring(path.Length - 2) + a + "_.txt", path + "\\rus\\r" + path.Substring(path.Length - 2) + b + ".txt");

                    //File.Move(path + "\\eng\\e" + path.Substring(path.Length - 2) + a + ".txt", path + "\\eng\\e" + path.Substring(path.Length - 2) + a + "_.txt");
                    //File.Move(path + "\\eng\\e" + path.Substring(path.Length - 2) + b + ".txt", path + "\\eng\\e" + path.Substring(path.Length - 2) + a + ".txt");
                    //File.Move(path + "\\eng\\e" + path.Substring(path.Length - 2) + a + "_.txt", path + "\\eng\\e" + path.Substring(path.Length - 2) + b + ".txt");
                };

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // string input;
           // Encoding enc1251 = Encoding.GetEncoding(1251);
           // Encoding encUTF = Encoding.GetEncoding("UTF-8");
           // string outputString;
           //// using (var sr = new StreamReader(@"D:\Учеба\Text categorization\Выборки\TM\rus\rTM11.txt"))

           // string data = null;
            //using (var sr = new StreamReader(@"D:\Учеба\Text categorization\Выборки\TM\rus\rTM99.txt"))
            //{
            //    MessageBox.Show(sr.CurrentEncoding.ToString());
            //    input = sr.ReadToEnd();
            //    byte[] sourceBytes = encUTF.GetBytes(input);
            //    outputString = enc1251.GetString(sourceBytes);
               
            //}

            //using (var sw = new StreamWriter(@"D:\Учеба\Text categorization\Выборки\TM\rus\rTM999.txt", false, Encoding.ASCII ))
            //{
            //    sw.Write(outputString);
            //}
            //File.WriteAllText(@"D:\Учеба\Text categorization\Выборки\TM\rus\rTM5.txt", File.ReadAllText(@"D:\Учеба\Text categorization\Выборки\TM\rus\rTM5.txt", Encoding.UTF8  ), Encoding.GetEncoding("windows-1251"));





            for (int i = 1; i <= Convert.ToInt16(this.textBoxIR.Text); i++)
            {
                string path = this.textBoxPath.Text ;
                string path2 = path + "\\rus\\r" + path.Substring(path.Length - 2) + i + ".txt";
               
                Utf8Checker checker = new Utf8Checker ();
                if ( checker.Check(path2) )
                {
                    string text = File.ReadAllText(path2);
                    File.WriteAllText(path2, text, Encoding.GetEncoding(1251)); 
                };
                
               
            }
            MessageBox.Show("READY");




            //string path = this.textBoxPath.Text ;
            //for (int i = 1; i <= 80; i++)
            //{
            //    string data = null;
            //    using (var sr = new StreamReader(path + "\\rus\\r" + path.Substring(path.Length - 2) + i + ".txt"))
            //    {
            //        data = sr.ReadToEnd();
            //        sr.Close();
            //    }
            //    using (var sw = new StreamWriter(path + "\\rus\\r" + path.Substring(path.Length - 2) + i + ".txt", false, Encoding.GetEncoding("windows-1251")))
            //    {
            //        sw.Write(data);
            //        sw.Close();
            //    }
                
            //}
        }

        private void button3_Click(object sender, EventArgs e) //Переименовать файлы в папке

        {
            string path = this.textBoxPath.Text;
            DirectoryInfo  FileDir = new DirectoryInfo (path+ "\\rus-\\");
            int i = 1;
            foreach (FileInfo filename in FileDir.GetFiles())
            {
                string name = filename.Name;
                File.Move(path + "\\rus-\\" + name, path + "\\rus\\rAL" + i.ToString()+ ".txt");
                i++;
            }
            MessageBox.Show("READY");
            //string path2 = path + "\\rSMTH_IPIRAN" + i + ".txt"; 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = 1;
            string writeE = "";
            string writeR = "";
            string path = this.textBoxPath.Text;
            for (i = 1; i <= Convert.ToInt32(this.textBoxIR.Text ); i++)
            {
                string pathR = path + "\\rus\\r" + path.Substring(path.Length - 2) + i + ".txt";
                string pathE = path + "\\eng\\e" + path.Substring(path.Length - 2) + i + ".txt";
                //открываем англ файл, считываем его первую строчку, если она 0, то 
                StreamReader srE = new StreamReader(pathE, Encoding.GetEncoding(1251));
                string contentE = srE.ReadLine().Trim();
                StreamReader srR = new StreamReader(pathR, Encoding.GetEncoding(1251));
                string contentR = srR.ReadLine().Trim();
                if (LanguageText(contentR) == "rus")
                {
                    if (contentE.Length == 0 & contentR.Length != 0) //нет англ
                    {
                        YandexTranslate YT = new YandexTranslate();
                        contentR = contentR.Replace("#", " ");
                        string translated = YT.Transl(contentR, "ru-en");
                        if (translated.IndexOf("Translation code=") == -1)
                        {
                            writeE = translated + Environment.NewLine + Environment.NewLine; ;
                            writeR = contentR + Environment.NewLine + Environment.NewLine; ;
                        }
                        else
                        {
                            MessageBox.Show(translated);
                        }

                    }
                    if (contentE.Length == 0 & contentR.Length == 0)//нет англ, нет рус
                    {
                        writeE = Environment.NewLine;
                        writeR = Environment.NewLine;
                    }
                    if ((contentE.Length != 0) & (contentR.Length == 0)) // нет рус
                    {
                        YandexTranslate YT = new YandexTranslate();
                        string translated = YT.Transl(contentE, "en-ru");
                        if (translated.IndexOf("Translation code=") == -1)
                        {
                            writeR = translated + Environment.NewLine + Environment.NewLine;
                            writeE = contentE + Environment.NewLine + Environment.NewLine;
                        }
                        else
                        {
                            MessageBox.Show(translated);
                        }
                    }
                    if (contentE.Length != 0 & contentR.Length != 0)//Все есть
                    {
                        writeE = contentE + Environment.NewLine + ',' + Environment.NewLine + ',' ;
                        writeR = contentR + Environment.NewLine + ',' + Environment.NewLine +',' ;
                    }

                }
                else if (LanguageText(contentR ) == "eng") //переводим с англ на русский
                {
                    if (contentE.Length == 0 & contentR.Length != 0) //нет англ
                    {
                        YandexTranslate YT = new YandexTranslate();
                        contentR = contentR.Replace("#", " ");
                        string translated = YT.Transl(contentR, "en-ru");
                        if (translated.IndexOf("Translation code=") == -1)
                        {
                            writeE = translated + Environment.NewLine + Environment.NewLine;
                            writeR = contentR + Environment.NewLine + Environment.NewLine;

                        }
                        else
                        {
                            MessageBox.Show(translated);
                        }

                    }
                    if (contentE.Length != 0 & contentR.Length != 0)//Все есть
                    {
                        writeE = contentE + Environment.NewLine + ',' + Environment.NewLine + ',';
                        writeR = contentR + Environment.NewLine + ',' + Environment.NewLine + ',';
                    }

                }
                // вторая строчка - keywords
                //contentE = srE.ReadLine().Trim();
                //contentR = srR.ReadLine().Trim();


                //if (contentE.Length == 0 & contentR.Length != 0)
                //{
                //    YandexTranslate YT = new YandexTranslate();
                //    string translated = YT.Transl(contentR, "ru-en");
                //    if (translated.IndexOf("Translation code=") == -1)
                //    {
                //        writeE += Environment.NewLine + translated;
                //        writeR += Environment.NewLine + contentR;
                //    }
                //    else
                //    {
                //        MessageBox.Show(translated);
                //    }

                //}
                //if ((contentE.Length != 0) & (contentR.Length == 0))
                //{
                //    YandexTranslate YT = new YandexTranslate();
                //    string translated = YT.Transl(contentE, "en-ru");
                //    if (translated.IndexOf("Translation code=") == -1)
                //    {
                //        writeR += Environment.NewLine + translated;
                //        writeE += Environment.NewLine + contentE;

                //    }
                //    else
                //    {
                //        MessageBox.Show(translated);
                //    }
                //}
                //if (contentE.Length == 0 & contentR.Length == 0)//нет англ, нет рус
                //{
                //    writeE += Environment.NewLine;
                //    writeR += Environment.NewLine;
                //}
                //if (contentE.Length != 0 & contentR.Length != 0)//Все есть
                //{
                //    writeE += Environment.NewLine + contentE;
                //    writeR += Environment.NewLine + contentR;
                //}
                //writeE += Environment.NewLine + srE.ReadLine().Trim();
                //writeR += Environment.NewLine + srR.ReadLine().Trim();

                // Записываем перевод в файлы
                srE.Close();
                srR.Close();
                
                File.WriteAllText(pathE, writeE, Encoding.GetEncoding(1251));
                File.WriteAllText(pathR, writeR, Encoding.GetEncoding(1251));

                //StreamWriter w = new StreamWriter(path + "\\vib\\r" + path.Substring(path.Length - 2) + ir + ".txt", true);

            }
            MessageBox.Show("OK");
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = 1;
            fulltext = "";
            string path0 = this.textBoxPath.Text;
            string path = "";
            for (i = 1; i <= Convert.ToInt16(this.textBoxIR.Text); i++)
            {
                path = path0 + "\\rus\\r" + path0.Substring(path0.Length - 2) + i + ".txt";
                StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251));
                string content = sr.ReadToEnd();
                fulltext = fulltext + " " + content;
            }
           
        }


        static public string LanguageText(string text)
        {
            int rus = 0, eng = 0;

            text = text.ToLower();

            byte[] Ch = System.Text.Encoding.Default.GetBytes(text);
            foreach (byte ch in Ch)
            {
                if ((ch >= 97) && (ch <= 122)) eng += 1;
                if ((ch >= 224) && (ch <= 255)) rus += 1;
            }

            if (eng > rus) return "eng";
            if (rus >= eng) return "rus";
            return "mix";
            
        }
        


        
    

    }
}
