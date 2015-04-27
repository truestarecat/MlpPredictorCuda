using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MlpPredictor
{
    public partial class NetworkLearningForm : Form
    {
        private INetworkLearning learning;
        private CancellationTokenSource cancellationTokenSource;

        public NetworkLearningForm(INetworkLearning learning)
        {
            InitializeComponent();

            learningProgressBar.Minimum = 0;
            learningProgressBar.Maximum = learning.MaxNumEpoch;
            learningProgressBar.Step = 1;

            this.learning = learning;
            cancellationTokenSource = new CancellationTokenSource();
        }

        private async void LearningProgressForm_Load(object sender, EventArgs e)
        {
            var progress = new Progress<float>(value =>
            {
                learningProgressBar.PerformStep();
                numEpochLabel.Text = Convert.ToString(learningProgressBar.Value);
                learningRmsLabel.Text = Convert.ToString(value);
            });

            await Task.Factory.StartNew(() => learning.Start(progress, cancellationTokenSource.Token), TaskCreationOptions.LongRunning);

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if(cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }
    }
}
