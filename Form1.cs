using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ペイント
{
    public partial class Form1 : Form
    {
        Point p_point = new Point();
        public Form1()
        {
            InitializeComponent();
            picture.Cursor = new Cursor("aero_pen.cur");
            picture.Image = new Bitmap(picture.Width, picture.Height);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.None)
            {
                p_point = picture.PointToClient(Cursor.Position);
            }
            Point zahyou = picture.PointToClient(Cursor.Position);
            if (zahyou.X >= 0 && zahyou.X <= picture.Width)
            {
                if (zahyou.Y >= 0 && zahyou.Y <= picture.Height)
                {
                    if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
                    {
                        Bitmap bitmap = new Bitmap(picture.Image);
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawLine(Pens.Black, zahyou, p_point);
                        picture.Image = bitmap;
                        p_point = zahyou;
                    }
                }
            }
        }

        private void hozon_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(picture.Image);
                bitmap.Save(saveFileDialog1.FileName, ImageFormat.Png);
                if (File.Exists(saveFileDialog1.FileName))
                {
                    MessageBox.Show("保存しました。", "成功"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存できませんでした。", "失敗"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
