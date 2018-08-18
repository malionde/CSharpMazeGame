using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;

namespace WindowsFormsApplication1
{
    public partial class frmMain : Form
    {
        int sutunGen;
        int satirYuk;
        int maxX = 0;
        int maxY = 0;
        int counter = 0;
        private Timer timer;
        private Player playa;
        public int health = 5;
        private Point playerPosition;

        private ucBox[,] boxList;

        //string testFilePath = "C:/Users/Mehmeto/Documents/map2.txt";
        string testFilePath = "C:/Users/Mehmeto/Documents/map.txt";

        List<BoxInfo> infoList = new List<BoxInfo>();

        public frmMain()
        {

            InitializeComponent();
        }

        //private override bool ProcessCmdKey(Keys keyData)

        //{
        //    if (keyData == Keys.Left)
        //        // if ( Gidilmek istenen kutunun rengi kırmızı ise )
        //        // PlayerBox.Location = new point (Gidilmek istenen kutunun Location'ı);
        //        // else if (return null;)

        //    if (keyData == Keys.Right)

        //    if (keyData == Keys.Up)

        //    if (keyData == Keys.Down)

        //    return base.ProcessCmdKey(keyData);

        //}

        #region Button Events
        private void btnReadMap_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
            //infoList = mapCreator.ReadMap(testFilePath);

            if (infoList != null)
                MessageBox.Show("Success");
            else
                MessageBox.Show("Failed");

        }

        private void btnCreateMap_Click(object sender, EventArgs e)
        {
            //mapCreator.CreateMap(gfMain, infoList);
            NewMap();
        }
        #endregion 

        #region Form Evetns

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += MovePlayer;

            StartGame();
        }


        private void gfMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    playa.Yon = Direction.Left;
                    return true;
                case Keys.Right:
                    playa.Yon = Direction.Right;
                    return true;
                case Keys.Up:
                    playa.Yon = Direction.Top;
                    return true;
                case Keys.Down:
                    playa.Yon = Direction.Down;
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);

            }

        }
       
        #endregion

        #region Game Functions
        public void StartGame()
        {

            // Haritayı oku 
            infoList = ReadMap(testFilePath);

            if (infoList != null)
                MessageBox.Show("Success");
            else
                MessageBox.Show("Failed");

            // Haritayı çiz 
            CreateMap(gfMain, infoList);

            playerPosition = new Point(0, 0);

            // Player'ı start'a yerleştir. 
            playa = new Player();
            playa.X = 0; // Y==0 && X==First_Red || X==0 && Y==First_Red
            playa.Y = 0; // 
            playa.Yon = Direction.Down;


            // Hareketi başlat. 
            timer.Start();



        }
        public void MovePlayer(object sender, EventArgs e)
        {
            counter++;
            lbl_Counter.Text = counter.ToString();

            // Yönü bul 
            // Gidilecek yönü kontrol et 

            // eski
            //var box = infoList.Where(i => i.X == playerPosition.X && i.Y == playerPosition.Y).FirstOrDefault();
            //if (box == null) throw new Exception("WTF");

            ucBox old = boxList[playerPosition.Y, playerPosition.X];

            // bunu eskiline getir

            //Hızı eski haline çevir
            timer.Interval = 300;

            int x = playerPosition.X;
            int y = playerPosition.Y;
            int old_x = playerPosition.X;
            int old_y = playerPosition.Y;
            switch (playa.Yon)
            {
                case Direction.Top:
                    x = x - 1;
                    break;
                case Direction.Right:
                    y = y + 1;
                    break;
                case Direction.Down:
                    x = x + 1;
                    break;
                case Direction.Left:
                    y = y - 1;
                    break;
                case Direction.Stop:
                    playerPosition.X = 0;
                    playerPosition.Y = 0;
                    //Duvara çarptığında bir tepki ver
                    break;
                default:
                    break;
            }


            // yeni
            try
            {


                ucBox yeni = boxList[y, x];

                if (yeni.MapChar == 'F' || playerPosition.X == maxY)

                {
                    timer.Interval = 100000;
                    
                    DialogResult result = MessageBox.Show("You Won!!" + "\n" +"Your Soccer is :"+(health*100 - (counter*5) )+"\n" + "Do you wanna next game? ", "You Won!", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        NewMap();
                    }
                    else if (result == DialogResult.No)

                    {
                        Environment.Exit(0);

                    }
                    else if (result ==DialogResult.Cancel)
                    {
                        //code for Cancel
                    }
                }
                else if (yeni.MapChar == '0' || playerPosition.X >= maxY || playerPosition.Y >= maxX)
                {

                    health--;
                    //Eğer can düştüyse Mesajı göster ve diğer hamle yapılana kadar oyunu yavaşlat. 
                    //Tekrar tekrar duvara çar
                    timer.Interval = 1400;
                    AutoClosingMessageBox.Show("You hit the wall!" + "\n" + "Your health is :" + health, "Warning!", 1300);

                    #region Duvara carptıktan sonrası
                    // Duvara sürekli çarpmasını engelle 
                    if (playa.Yon == Direction.Down)
                        playa.Yon = Direction.Top;
                    else if (playa.Yon == Direction.Left)
                        playa.Yon = Direction.Right;
                    else if (playa.Yon == Direction.Right)
                        playa.Yon = Direction.Left;
                    else
                        playa.Yon = Direction.Down;

                    timer.Interval = 500;
                    #endregion

                    if (health == 0)
                    {
                        timer.Interval = 1000000;

                        DialogResult result = MessageBox.Show("You lost the game!" + "\n" + "Do you wanna new game? ", "Game is over!", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            EndGame();
                        }
                        else if (result == DialogResult.No)

                        {
                            Environment.Exit(0);

                        }
                        else if (result == DialogResult.Cancel)
                        {

                        }
                        
                    }


                }



                //else if ( playerPosition.X < 0 || playerPosition.Y < 0 || playerPosition.X >= maxY-2 || playerPosition.Y >= maxX-1 )
                //    EndGame();
                else
                {
                    playerPosition.X = x;
                    playerPosition.Y = y;

                    var temp = yeni.BackColor;
                    yeni.BackColor = Color.IndianRed;
                    old.BackColor = temp;
                    old.SetPicture(null);

                    yeni.SetPicture(GetPlayerImage());
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
         
            }
        }
          
        public void NewMap()
        {
            Random random = new Random();

           
            string fileName = "C:/Users/Mehmeto/Documents/"+"map" + ".txt";
            //creating the lotto file
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            Console.WriteLine("File created");
            fs.Close();

            StreamWriter sw = new StreamWriter(fileName);

            for (int i = 0; i < 14; i++)
            {
                
                for (int j = 0; j < 14; j++)
                {
                    sw.Write("1");
                    sw.Write(random.Next(0, 2));
                }
                Console.WriteLine();
                sw.Write("1");
                sw.Write("F");
                sw.Write("1");
                sw.Write(Environment.NewLine);
               

            }

            sw.Close();
            Application.Restart();
            Environment.Exit(0);
            EndGame();
        }

        public void EndGame()
        {
            timer.Interval = 500;

                // Kazanmak kaybetmek 


            // Haritayı sıfırla 

            
            playerPosition = new Point(0, 0);

            // Sonucu göster. 

            //AutoClosingMessageBox.Show("Your Soccer is" + "\n" + "Your health is :" + health, "Soccer!", 1500);


            // Hareketi sonlandır. 

            playerPosition = new Point(0, 0);
            playerPosition = new Point(0, 0);
            playa.Yon = Direction.Down;
            health = 5;
        }

        public Image GetPlayerImage()
        {
            switch (playa.Yon)
            {
                case Direction.Top:
                    return WindowsFormsApplication1.Properties.Resources.arr_up;
                case Direction.Right:
                    return WindowsFormsApplication1.Properties.Resources.arr_right;
                case Direction.Down:
                    return WindowsFormsApplication1.Properties.Resources.arr_down;
                case Direction.Left:
                    return WindowsFormsApplication1.Properties.Resources.arr_left;
                case Direction.Stop:
                    break;
                default:
                    break;
            }
            return null;
        }
        #endregion

        #region Map
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

            boxList = new ucBox[maxX,maxY];

            //Satır Yüksekliği Yükseklik / Maks satır sayısı 
            //Sütün yüksekliği Genişlik / Maks Sütun sayısı 
            satirYuk = h / (maxY );
            sutunGen = w / (maxX );

            // MaxY boyunca Döngü çalıştır
            for (int i = 0; i < maxY; i++)
            {

                //maxX boyunca döngü çalıştır
                //Döngü boyunca ucBox ları yaz 
                for (int j = 0; j < maxX; j++)
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
                    b.MapChar = info.C;

                    field.Controls.Add(b);

                    boxList[j,i] = b;
                                

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
        #endregion
    }
}
