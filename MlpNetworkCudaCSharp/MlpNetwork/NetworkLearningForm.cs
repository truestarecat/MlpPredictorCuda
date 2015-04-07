using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MlpNetwork
{
    public partial class NetworkLearningForm : Form
    {
        private CancellationTokenSource cancellationTokenSource;

        public NetworkLearningForm(NetworkPredictionManager predictionManager)
        {
            InitializeComponent();
            learningProgressBar.Minimum = 0;
            learningProgressBar.Maximum = predictionManager.MaxNumEpoch;
            learningProgressBar.Step = 1;

            PredictionManager = predictionManager;

            cancellationTokenSource = new CancellationTokenSource();
        }

        public NetworkPredictionManager PredictionManager { get; private set; }

        private async void LearningProgressForm_Load(object sender, EventArgs e)
        {
            var progress = new Progress<float>(value =>
            {
                learningProgressBar.PerformStep();
                numEpochLabel.Text = Convert.ToString(learningProgressBar.Value);
                learningRmsLabel.Text = Convert.ToString(value);
            });

            await Task.Factory.StartNew(() => PredictionManager.LearnNetwork(progress, cancellationTokenSource.Token),
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
