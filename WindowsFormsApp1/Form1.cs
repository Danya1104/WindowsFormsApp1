using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void иверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            //Bitmap resultImage = filter.processImage(image);
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp;.jpeg|All files(*.*.)|*.*";
            if (dialog.ShowDialog()== DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage=((Filters)e.Argument).processImage(image,backgroundWorker1);
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

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеПоГауссуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void полутоновоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
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

        private void собеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sobol();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Embossing();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Filters filter = new Transfer();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Filters filter = new Tern();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void вертикальныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Filters filter = new Wave1();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void горизонтальныеИВертикальныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Filters filter = new Wave2();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void эффектстеклаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Glass();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlur();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкость1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sharpness1();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторЩарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new OperatorSharr();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторПрюитаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new OperatorPrewitt();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void светящиесяКраяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GlowingEdges();
            backgroundWorker1.RunWorkerAsync(filter); 
        }

        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveDialog.FileName);
            }
        }
        private Stack<Action> actionStack = new Stack<Action>(); // Стек для хранения действий

        
        // Метод для выполнения действия и сохранения его в стеке
        private void DoAction(Action action)
        {
            action(); // Выполняем действие
            actionStack.Push(action); // Добавляем действие в стек
        }

        // Метод для отмены последнего действия
        private void UndoLastAction()
        {
            if (actionStack.Count > 0)
            {
                Action lastAction = actionStack.Pop(); // Получаем последнее действие из стека
                lastAction(); // Отменяем последнее действие
            }
        }

        // Пример метода, который выполняет действие (например, изменение текста на кнопке)
        
        private void button2_Click(object sender, EventArgs e)
        {
            UndoLastAction();
        }
    }
}