using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearBarClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(fileOpen.FileName);
                string[] strs = new string[] { ".png" };
                if (!((IList)strs).Contains(extension.ToLower()))
                {
                    MessageBox.Show("仅支持png图片！");
                }
                else
                {
                    //FileInfo fileinfo = new FileInfo(fileOpen.FileName);
                    Image img = Image.FromFile(fileOpen.FileName);
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    Bitmap bp = new Bitmap(img);
                    var newbp = GetNewBitmap(bp);
                    //DoImgPixel(bp);

                    pictureBox2.Image = newbp;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
        Bitmap GetNewBitmap(Bitmap img)
        {
            int maxGray = 0;
            int minGray = 0;
            int tempGray = 0;
            int gridIndex = 0;
            int tempi = 0;
            Color curColor;
            var newImg = new Bitmap(@"E:\1.PNG");
            List<IEnumerable<Color>> b = new List<IEnumerable<Color>>();
            var task = Task.Factory.StartNew(() =>
              {
                  for (int i = 0; i < img.Height; i++)
                  {
                      var row = GetRow(i, img);
                      var pi = row.FirstOrDefault();
                      if (row.Any(o => o.Value - pi.Value < 50))
                      {
                          continue;
                      }
                      else
                      {
                          b.Add(row.Select(o => o.Key));
                      }
                  }
                  for (var i = 0; i < b.Count; i++)
                  {
                      var cdcount = b[i].Count();
                      for (var x = 0; x < cdcount; x++)
                      {
                          newImg.SetPixel(x, i, b[i].ElementAt(x));
                      }
                  }
              });
            task.Wait();
            newImg.Save(@"E:\11.PNG");
            return newImg;
            //for (int i = 0; i < img.Height; i++)
            //{
            //    for (int j = 0; j < img.Width; j++)
            //    {
            //        curColor = img.GetPixel(j, i);
            //        tempGray = GetGray(curColor);
            //        if (tempGray > maxGray || maxGray == 0)
            //        {
            //            maxGray = tempGray;
            //        }
            //        if (tempGray < minGray || minGray == 0)
            //        {
            //            minGray = tempGray;
            //        }
            //        gridIndex = this.dataGridView1.Rows.Add();
            //        this.dataGridView1.Rows[gridIndex].Cells[0].Value = tempGray;
            //        this.dataGridView1.Rows[gridIndex].Cells[1].Value = i;
            //        this.dataGridView1.Rows[gridIndex].Cells[2].Value = j;
            //    }
            //    if ((maxGray - minGray) < 30)
            //    {
            //        tempi = i;
            //    Back:
            //        for (int x = i; x < img.Height - i; x++)
            //        {

            //            for (int k = 1; k < img.Width; k++)
            //            {
            //                curColor = img.GetPixel(k, x);
            //                tempGray = GetGray(curColor);
            //                if (tempGray > maxGray || maxGray == 0)
            //                {
            //                    maxGray = tempGray;
            //                }
            //                if (tempGray < minGray || minGray == 0)
            //                {
            //                    minGray = tempGray;
            //                }
            //            }
            //            tempi = x;
            //            if ((maxGray - minGray) > 30)
            //            {
            //                for (int l = 1; l < img.Width; l++)
            //                {
            //                    img.SetPixel(l, i, img.GetPixel(l, tempi));
            //                }
            //                break;
            //            }
            //            else
            //            {
            //                goto Back;
            //            }
            //        }

            //    }
            //    maxGray = 0;
            //    minGray = 0;
            //}

            //return img;
        }
        IEnumerable<KeyValuePair<Color, int>> GetRow(int y, Bitmap bitmap)
        {
            List<KeyValuePair<Color, int>> result = new List<KeyValuePair<Color, int>>();
            for (var i = 0; i < bitmap.Width; i++)
            {
                var color = bitmap.GetPixel(i, y);
                result.Add(new KeyValuePair<Color, int>(color, GetGray(color)));
            }
            return result;
        }
        int GetGray(Color curColor)
        {
            return (int)(curColor.R * 0.299 + curColor.G * 0.587 + curColor.B * 0.114);
        }

        //70 42 54
        //95 58 57
        //68 45 55
        //120 73 75
        //55 44 46
        //106 60 54
        //98 54 49
        //80 40 40
        //79 43 46
        //104 65 66
        //99 71 75
        //61 43 49

    }
}
