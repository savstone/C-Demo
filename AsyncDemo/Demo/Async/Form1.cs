using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async
{
    public partial class Form1 : Form
    {

        private readonly BackgroundWorker _worker = new BackgroundWorker();
        private CancellationTokenSource _source;
        private CancellationToken _token;


        public Form1()
        {
            InitializeComponent();
            _worker.DoWork += Worker_DoWork;
            _worker.ProgressChanged += Worker_ProgressChanged;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Cancelled ? $"线程被取消:{progressBar1.Value}%" : $"执行完成:{progressBar1.Value }%");
            progressBar1.Value = 0;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            if (worker == null) return;

            for (int i = 0; i < 10; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                worker.ReportProgress((i + 1) * 10);
                Thread.Sleep(500);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            _source = new CancellationTokenSource();
            _token = _source.Token;

            int percent = 0;
            int times = 10;
            int step = 100 / times;
            for (int i = 0; i < times; i++)
            {
                if (_token.IsCancellationRequested)
                {
                    break;
                }
                try
                {
                    await Task.Delay(500, _token);
                    percent = (i + 1) * step;
                }
                catch (Exception)
                {
                    percent = i * step;
                }
                finally
                {
                    progressBar1.Value = percent;
                }
            }
            string msg = _token.IsCancellationRequested ? $"进度为：{percent}% 已被取消！" : $"已经完成";
            MessageBox.Show(msg, @"信息");
            InitValue();
        }

        private void InitValue()
        {
            progressBar1.Value = 0;
            button2.Enabled = true;
            button1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Enabled)
            {
                return;
            }

            button2.Enabled = false;
            _source.Cancel();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!_worker.IsBusy)
            {
                _worker.RunWorkerAsync();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _worker.CancelAsync();  //请求取消挂起的后台操作
        }
    }
}
