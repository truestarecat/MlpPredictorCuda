using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MlpNetwork
{
    public partial class LearningProgressForm : Form
    {
        private ErrorPropagationType propagationType;
        private MlpNetwork network;
        private NetworkDataSet learningDataSet;
        private int maxNumEpoch;
        private float maxLearningRms;
        float learningRate;
        float momentum;

        private CancellationTokenSource cancellationTokenSource;

        public int NumEpoch { get; private set; }
        public List<float> LearningRmsList { get; private set; }

        public int ProgressValue { get; private set; }

        public LearningProgressForm(ErrorPropagationType propagationType, MlpNetwork network,
            NetworkDataSet learningDataSet, int maxNumEpoch, float maxLearningRms, float learningRate, float momentum)
        {
            InitializeComponent();

            learningProgressBar.Minimum = 0;
            learningProgressBar.Maximum = maxNumEpoch;
            learningProgressBar.Step = 1;

            this.propagationType = propagationType;
            this.network = network;
            this.learningDataSet = learningDataSet;
            this.maxNumEpoch = maxNumEpoch;
            this.maxLearningRms = maxLearningRms;
            this.learningRate = learningRate;
            this.momentum = momentum;

            cancellationTokenSource = new CancellationTokenSource();

            NumEpoch = 0;
            LearningRmsList = new List<float>();
        }

        private async void LearningProgressForm_Load(object sender, EventArgs e)
        {
            var progress = new Progress<int>(i => learningProgressBar.PerformStep());
            await Task.Factory.StartNew(() => LearnNetwork(progress, cancellationTokenSource.Token),
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

        private void LearnNetwork(IProgress<int> progress, CancellationToken token)
        {
            float error = Single.MaxValue;
            using (CudaErrorPropagation propagation = new CudaErrorPropagation(network, learningDataSet))
            {
                propagation.RandomizeNetworkWeights();

                while (NumEpoch < maxNumEpoch && error > maxLearningRms)
                {
                    if(token.IsCancellationRequested)
                    {
                        propagation.Dispose();
                        return;
                    }

                    switch(propagationType)
                    {
                        case ErrorPropagationType.BackPropagation:
                            error = propagation.PerformBackPropEpoch(learningRate, momentum);
                            break;
                        case ErrorPropagationType.ResilientPropagation:
                            error = propagation.PerformResilientPropEpoch();
                            break;
                        default:
                            throw new ArgumentException("Illegal error propagation type");
                    }

                    LearningRmsList.Add(error);

                    progress.Report(NumEpoch);

                    ++NumEpoch;
                }

                propagation.UpdateNetworkWeights();
            }
        }
    }
}
