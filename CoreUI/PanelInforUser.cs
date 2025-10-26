using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStore.CoreUI
{
    public partial class PanelInforUser : UserControl
    {
        public PanelInforUser()
        {
            InitializeComponent();
            MakePictureBoxCircular(pictureBox1);
            string avatarPath = Path.Combine(
      Application.StartupPath,
      @"..\..\..\Commom\Access\Images\avatar_user.png"
  );
            avatarPath = Path.GetFullPath(avatarPath);

            pictureBox1.Image = Image.FromFile(avatarPath);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void MakePictureBoxCircular(PictureBox pic)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pic.Width, pic.Height);
            pic.Region = new Region(path);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PanelInforUser_Load(object sender, EventArgs e)
        {

        }
    }
}
