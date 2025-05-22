using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filters
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.png;*.webp;|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Invert();
            backgroundWorker1.RunWorkerAsync(filter);
            /*Bitmap resultImage = filter.processImage(image, backgroundWorker1);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();*/
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Image Files|*.jpg;*.png;*.webp;|All Files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
                MessageBox.Show("Изображение успешно сохранено", "Сообщение", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Blur();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеПоГауссуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianBlur();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чернобелыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScale();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Brightness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поОсиXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilterX();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поОсиYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilterY();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Shift();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Rotate(45.0f, image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеДвиженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlur();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Median();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
