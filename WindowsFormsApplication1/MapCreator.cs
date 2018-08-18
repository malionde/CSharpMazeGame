using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class MapCreator
    {
        int sutunGen;
        int satirYuk;

        public List<BoxInfo> ReadMap(string mapPath)
        {
            Random rnd = new Random();

            List<BoxInfo> result = null;

            try
            {
                if (!File.Exists(mapPath))
                    return null;

                // dosyayı oku
                string content = System.IO.File.ReadAllText(mapPath);

                // dosytanın ici bosmu
                if (string.IsNullOrEmpty(content))
                    return null;

                // her satırı al
                string[] lines = content.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                result = new List<BoxInfo>();

                // her karakter için
                for (int y = 0; y < lines.Length; y++)
                {
                    string line = lines[y];

                    // check line

                    for (int x = 0; x < line.Length; x++)
                    {
                        char c = line[x];


                        // yeni boxinfo (x,y)
                        BoxInfo b = new BoxInfo(c);
                        b.C = c;
                        b.X = x;
                        b.Y = y;

                        // add to result
                        result.Add(b);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            return result;

        }


        public void CreateMap(ucGameField field, List<BoxInfo> infoList)
        {
            int w = field.Size.Width;
            int h = field.Size.Height;

            int maxX = 0;
            int maxY = 0;

            StringBuilder builder = new StringBuilder();

            // Maksimum satır ve sütün sayısı bul
            for (int i = 0; i < infoList.Count; i++)
            {
                var b = infoList[i];
                if (b.X > maxX)
                    maxX = b.X;
                if (b.Y > maxY)
                    maxY = b.Y;

                //builder.AppendLine(b.ToString());
            }

            //Satır Yüksekliği Yükseklik / Maks satır sayısı 
            //Sütün yüksekliği Genişlik / Maks Sütun sayısı 
            satirYuk = h / (maxY + 1);
            sutunGen = w / (maxX + 1);

            // MaxY boyunca Döngü çalıştır
            for (int i = 0; i <= maxY; i++)
            {

                //maxX boyunca döngü çalıştır
                //Döngü boyunca ucBox ları yaz 
                for (int j = 0; j <= maxX; j++)
                {

                    var info = infoList.Where(z => z.X == j && z.Y == i).FirstOrDefault();

                    if (info == null)
                        throw new Exception("WTF!");

                    // ucBox oluştur, boyut ver, konum belirle
                    // Getcolor func ile renk ver 
                    ucBox b = new ucBox();
                    b.Size = new Size(sutunGen, satirYuk);
                    b.Location = new Point(sutunGen * j, satirYuk * i);
                    b.BackColor = GetColor(info.C);

                    field.Controls.Add(b);                    
                    //Button btnAdd = new Button();
                    // btnAdd.Location = new System.Drawing.Point(25, 25);

                    // if (!=0) 
                    // this.btnAdd.BackColor = Color.Red;

                }
            }


            //File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"test.txt"), builder.ToString());

            // box yap 
            // ekle
        }

        //Text dökümanındaki değerlere göre renkleri belirle, 
        //Eğer harici bir karakter olursa default renk ver. 
        private Color GetColor(char c)
        {


            switch (c)
            {
                case '0': return Color.GhostWhite;
                case '1': return Color.IndianRed;
                case 'S': return Color.LightGreen;
                case 'F': return Color.LightGreen;

                    //Timer ekle 
                   
                /*  private void timer1_Tick(object sender, EventArgs e)
                    {
                        Random rnd = new Random();
                        label1.ForeColor = Color.FromArgb((rnd.Next(0, 255)), (rnd.Next(0, 255)),
                  (rnd.Next(0, 255)));
                    }
                    */


                case 'P': return Color.LightBlue;
                default:
                    return Color.Black;
            }
        }



        //Programda karmaşayı engellemek için dışarıdan çağırabilirsin. 
        // Tek satırlık bir işlem olduğu için gerek kalmadı. 
        private Point GetCoordinates(int x, int y)
        {

            return new Point(sutunGen * x, satirYuk * y);
        }
    }
}
