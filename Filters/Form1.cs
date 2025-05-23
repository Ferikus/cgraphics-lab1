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

        private Stack<Bitmap> returnBack = new Stack<Bitmap>();
        private Stack<Bitmap> returnForward = new Stack<Bitmap>();

        bool filtersFlag = false;
        bool dilFlag = false;
        bool erFlag = false;
        bool opFlag = false;
        bool clFlag = false;
        bool gradFlag = false;
        bool wrdFlag = false;
        bool perfmirFlag = false;

        public Form1()
        {
            InitializeComponent();
        }

        int[,] structuralElement = new int[,]
        {
            { 0, 1, 0 },
            { 1, 1, 1 },
            { 0, 1, 0 }
        };

        private void HandleWithFilter(Filters filter)
        {
            filtersFlag = true;
            dilFlag = false;
            erFlag = false;
            opFlag = false;
            clFlag = false;
            gradFlag = false;
            wrdFlag = false;
            perfmirFlag = false;

            if (image == null)
            {
                MessageBox.Show("Изображение не загружено.");
                return;
            }

            if (!backgroundWorker1.IsBusy)
            {
                SaveCondition();
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                MessageBox.Show("Обработка уже выполняется.");
            }
        }

        private void HandleWithDilation(Dilation filter)
        {
            filtersFlag = false;
            dilFlag = true;
            erFlag = false;
            opFlag = false;
            clFlag = false;
            gradFlag = false;
            wrdFlag = false;
            perfmirFlag = false;

            if (image == null)
            {
                MessageBox.Show("Изображение не загружено.");
                return;
            }

            if (!backgroundWorker1.IsBusy)
            {
                SaveCondition();
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                MessageBox.Show("Обработка уже выполняется.");
            }
        }

        private void HandleWithErosion(Erosion filter)
        {
            filtersFlag = false;
            dilFlag = false;
            erFlag = true;
            opFlag = false;
            clFlag = false;
            gradFlag = false;
            wrdFlag = false;
            perfmirFlag = false;

            if (image == null)
            {
                MessageBox.Show("Изображение не загружено.");
                return;
            }

            if (!backgroundWorker1.IsBusy)
            {
                SaveCondition();
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                MessageBox.Show("Обработка уже выполняется.");
            }
        }

        private void HandleWithOpening(Opening filter)
        {
            filtersFlag = false;
            dilFlag = false;
            erFlag = false;
            opFlag = true;
            clFlag = false;
            gradFlag = false;
            wrdFlag = false;
            perfmirFlag = false;

            if (image == null)
            {
                MessageBox.Show("Изображение не загружено.");
                return;
            }

            if (!backgroundWorker1.IsBusy)
            {
                SaveCondition();
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                MessageBox.Show("Обработка уже выполняется.");
            }
        }

        private void HandleWithClosing(Closing filter)
        {
            filtersFlag = false;
            dilFlag = false;
            erFlag = false;
            opFlag = false;
            clFlag = true;
            gradFlag = false;
            wrdFlag = false;
            perfmirFlag = false;

            if (image == null)
            {
                MessageBox.Show("Изображение не загружено.");
                return;
            }

            if (!backgroundWorker1.IsBusy)
            {
                SaveCondition();
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                MessageBox.Show("Обработка уже выполняется.");
            }
        }
        private void HandleWithGradient(Gradient filter)
        {
            filtersFlag = false;
            dilFlag = false;
            erFlag = false;
            opFlag = false;
            clFlag = false;
            gradFlag = true;
            wrdFlag = false;
            perfmirFlag = false;

            if (image == null)
            {
                MessageBox.Show("Изображение не загружено.");
                return;
            }

            if (!backgroundWorker1.IsBusy)
            {
                SaveCondition();
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                MessageBox.Show("Обработка уже выполняется.");
            }
        }

        private void HandleWithGrayWorld(GrayWorld filter)
        {
            filtersFlag = false;
            dilFlag = false;
            erFlag = false;
            opFlag = false;
            clFlag = false;
            gradFlag = false;
            wrdFlag = true;
            perfmirFlag = false;

            if (image == null)
            {
                MessageBox.Show("Изображение не загружено.");
                return;
            }

            if (!backgroundWorker1.IsBusy)
            {
                SaveCondition();
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                MessageBox.Show("Обработка уже выполняется.");
            }
        }

        private void HandleWithPerfectMirror(PerfectMirror filter)
        {
            filtersFlag = false;
            dilFlag = false;
            erFlag = false;
            opFlag = false;
            clFlag = false;
            gradFlag = false;
            wrdFlag = false;
            perfmirFlag = true;

            if (image == null)
            {
                MessageBox.Show("Изображение не загружено.");
                return;
            }

            if (!backgroundWorker1.IsBusy)
            {
                SaveCondition();
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                MessageBox.Show("Обработка уже выполняется.");
            }
        }

        private void SaveCondition()
        {
            if (image != null)
            {
                returnBack.Push(new Bitmap(image));
                if (returnForward.Count != 0)
                {
                    returnForward.Clear();
                }

            }
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

        // BACKGROUND WORKER

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (filtersFlag)
                {
                    Filters filter = (Filters)e.Argument;
                    Bitmap newImage = filter.processImage(image, backgroundWorker1);
                    e.Result = newImage;
                }
                else if (dilFlag)
                {
                    Dilation filter = (Dilation)e.Argument;
                    Bitmap newImage = filter.DilationProcessImage(image, backgroundWorker1);
                    e.Result = newImage;
                }
                else if (erFlag)
                {
                    Erosion filter = (Erosion)e.Argument;
                    Bitmap newImage = filter.ErosionProcessImage(image, backgroundWorker1);
                    e.Result = newImage;
                }
                else if (opFlag)
                {
                    Opening filter = (Opening)e.Argument;
                    Bitmap newImage = filter.OpeningProcessImage(image, backgroundWorker1);
                    e.Result = newImage;
                }
                else if (clFlag)
                {
                    Closing filter = (Closing)e.Argument;
                    Bitmap newImage = filter.ClosingProcessImage(image, backgroundWorker1);
                    e.Result = newImage;
                }
                else if (wrdFlag)
                {
                    GrayWorld filter = (GrayWorld)e.Argument;
                    Bitmap newImage = filter.GrayWorldProcessImage(image, backgroundWorker1);
                    e.Result = newImage;
                }
                else if (perfmirFlag)
                {
                    PerfectMirror filter = (PerfectMirror)e.Argument;
                    Bitmap newImage = filter.IdealReflectorProcessImage(image, backgroundWorker1);
                    e.Result = newImage;
                }

            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                progressBar1.Value = e.ProgressPercentage;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Ошибка в BackgroundWorker: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Обработка отменена.");
            }
            else if (e.Result is Exception ex)
            {
                MessageBox.Show("Ошибка при обработке изображения: " + ex.Message);
            }
            else if (e.Result is Bitmap resultImage)
            {
                pictureBox1.Image = resultImage;
                image = resultImage;
                pictureBox1.Refresh();

            }
            progressBar1.Value = 0;
        }

        // UNDO AND REDO
        private void buttonUndo_Click(object sender, EventArgs e)
        {
            if (returnBack.Count > 0)
            {
                returnForward.Push(new Bitmap(pictureBox1.Image));
                image = returnBack.Pop();
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            if (returnForward.Count > 0)
            {
                returnBack.Push(new Bitmap(pictureBox1.Image));
                image = returnForward.Pop();
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        // SPOT AND MATRIX FILTERS
        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new Invert());
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new Blur());
        }

        private void размытиеПоГауссуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new GaussianBlur());
        }

        private void чернобелыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new GrayScale());
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new Sepia());
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new Brightness());
        }

        private void поОсиXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new SobelFilterX());
        }

        private void поОсиYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new SobelFilterY());
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new Sharpness());
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new Shift());
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new Rotate(45.0f, image));
        }

        private void размытиеДвиженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new MotionBlur());
        }

        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new Median());
        }

        private void поОсиXToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new ScharrX());
        }

        private void поОсиYToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new ScharrY());
        }

        // MATH MORPHOLOGY

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithDilation(new Dilation(structuralElement));
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithErosion(new Erosion(structuralElement));
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithOpening(new Opening(structuralElement));
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithClosing(new Closing(structuralElement));
        }

        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithGradient(new Gradient(structuralElement));
        }

        // FILTERS FROM THE LIST

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new Glass());
        }

        private void горизонтальныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new WavesX());
        }

        private void вертикальныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithFilter(new WavesY());
        }

        // LINEAR STRETCH

        private void линРастяжениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Ymax_ = 0;
            int Ymin_ = 255;

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixelColor = image.GetPixel(i, j);

                    int intensity = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                    Ymax_ = Math.Max(Ymax_, intensity);
                    Ymin_ = Math.Min(Ymin_, intensity);
                }
            }

            HandleWithFilter(new LinearStretch(Ymax_, Ymin_));
        }

        // ADDITIONAL FILTERS

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithGrayWorld(new GrayWorld());
        }

        private void идеальныйОтражательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleWithPerfectMirror(new PerfectMirror());
        }
    }
}
