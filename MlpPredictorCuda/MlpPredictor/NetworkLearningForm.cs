using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MlpPredictor
{
    public partial class NetworkLearningForm : Form
    {
        private NetworkPredictionManager manager;
        private float learningDataPercentage;
        private LearningAlgorithmType algorithmType;
        private float maxLearningRms;
        private int maxNumEpoch;
        private float learningRate;
        private float momentum;
        private CancellationTokenSource cancellationTokenSource;

        public NetworkLearningForm(NetworkPredictionManager manager, float learningDataPercentage,
            LearningAlgorithmType algorithmType, float maxLearningRms, int maxNumEpoch, float learningRate, float momentum)
        {
            InitializeComponent();

            learningProgressBar.Maximum = maxNumEpoch;
            learningProgressBar.Step = 1;

            this.manager = manager;
            this.learningDataPercentage = learningDataPercentage;
            this.algorithmType = algorithmType;
            this.maxLearningRms = maxLearningRms;
            this.maxNumEpoch = maxNumEpoch;
            this.learningRate = learningRate;
            this.momentum = momentum;
            cancellationTokenSource = new CancellationTokenSource();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        } 

        private async void LearningProgressForm_Load(object sender, EventArgs e)
        {
            var progress = new Progress<float>(value =>
            {
                learningProgressBar.PerformStep();
                numEpochLabel.Text = Convert.ToString(learningProgressBar.Value);
                learningRmsLabel.Text = Convert.ToString(value);
            });

            await Task.Factory.StartNew(() => manager.LearnNetwork(progress, cancellationTokenSource.Token, learningDataPercentage,
                algorithmType, maxLearningRms, maxNumEpoch, learningRate, momentum), TaskCreationOptions.LongRunning);

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
