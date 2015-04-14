using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MlpPredictor
{
    public partial class NetworkLearningForm : Form
    {
        private NetworkPrediction prediction;
        private float maxLearningRms;
        private int maxNumEpoch;
        private float learningRate;
        private float momentum;
        private LearningAlgorithmType learningAlgorithmType;
        private CancellationTokenSource cancellationTokenSource;

        public NetworkLearningForm(NetworkPrediction prediction, float maxLearningRms, int maxNumEpoch,
                                 float learningRate, float momentum, LearningAlgorithmType learningAlgorithmType)
        {
            InitializeComponent();

            learningProgressBar.Minimum = 0;
            learningProgressBar.Maximum = maxNumEpoch;
            learningProgressBar.Step = 1;

            this.prediction = prediction;
            this.maxLearningRms = maxLearningRms;
            this.maxNumEpoch = maxNumEpoch;
            this.learningRate = learningRate;
            this.momentum = momentum;
            this.learningAlgorithmType = learningAlgorithmType;
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

            await Task.Factory.StartNew(() => prediction.LearnNetwork(progress, cancellationTokenSource.Token,
                maxLearningRms, maxNumEpoch, learningRate, momentum, learningAlgorithmType), TaskCreationOptions.LongRunning);

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
