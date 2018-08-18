using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ucBox : UserControl
    {
        public ucBox()
        {
          
            InitializeComponent();

            picBg.BringToFront();
        }

        public char MapChar;

        public void SetPicture(Image pic)
        {
            this.picBg.Image = pic;
        }
    }
}
