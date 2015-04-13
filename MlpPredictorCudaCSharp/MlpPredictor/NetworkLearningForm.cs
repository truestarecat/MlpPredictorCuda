using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MlpPredictor
{
    public partial class NetworkLearningForm : Form
    {
        private CancellationTokenSource cancellationTokenSource;

        public NetworkLearningForm(NetworkPrediction prediction)
        {
            InitializeComponent();

            learningProgressBar.Minimum = 0;
            learningProgressBar.Maximum = prediction.MaxNumEpoch;
            learningProgressBar.Step = 1;

            Prediction = prediction;
            cancellationTokenSource = new CancellationTokenSource();
        }

        public NetworkPrediction Prediction { get; private set; }

        private async void LearningProgressForm_Load(object sender, EventArgs e)
        {
            var progress = new Progress<float>(value =>
            {
                learningProgressBar.PerformStep();
                numEpochLabel.Text = Convert.ToString(learningProgressBar.Value);
                learningRmsLabel.Text = Convert.ToString(value);
            });

            await Task.Factory.StartNew(() => Prediction.LearnNetwork(progress, cancellationTokenSource.Token),
                TaskCreationOptions.LongRunning);

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
