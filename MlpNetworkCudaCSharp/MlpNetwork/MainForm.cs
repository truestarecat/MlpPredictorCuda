using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace MlpNetwork
{
    public partial class MainForm : Form
    {
        private	float divideFactor;
		private float maxLearningRms;
		private int numInput;
		private int numHidden;
		private int numOutput;
		private int maxNumEpoch;
		private float learningRate;
		private float momentum;
        private ActivationFunctionType hiddenFunctionType;
        private ActivationFunctionType outputFunctionType;

        public MainForm()
        {
            InitializeComponent();

            this.hiddenFunctionComboBox.DataSource = typeof(ActivationFunctionType).ToList();
            this.outputFunctionComboBox.DataSource = typeof(ActivationFunctionType).ToList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GraphPane[] panes = { resultGraphControl.GraphPane,
                                  learningRmsGraphControl.GraphPane,
                                  testingRmsGraphControl.GraphPane };

            for (int i = 0; i < panes.Length; i++)
            {
                panes[i].CurveList.Clear();
                panes[i].XAxis.Title.Text = "";
                panes[i].YAxis.Title.Text = "";
                panes[i].Title.Text = "";
            }
        }

        private void learnButton_Click(object sender, EventArgs e)
        {
            try
            {
                SetParams();

                learnButton.Enabled = false;

                LearnNetworkCuda();

                learnButton.Enabled = true;
            }
            catch
            {
                learnButton.Enabled = true;
                MessageBox.Show("Неверный ввод параметров.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetParams()
        {
            divideFactor = Convert.ToSingle(divideFactorTextBox.Text);
            maxLearningRms = Convert.ToSingle(maxLearningRmsTextBox.Text);
            numInput = Convert.ToInt32(numInputNumericUpDown.Value);
            numHidden = Convert.ToInt32(numHiddenNumericUpDown.Value);
            numOutput = Convert.ToInt32(numOutputNumericUpDown.Value);
            maxNumEpoch = Convert.ToInt32(maxNumEpochNumericUpDown.Value);
            learningRate = Convert.ToSingle(learningRateTextBox.Text);
            momentum = Convert.ToSingle(momentumTextBox.Text);

            hiddenFunctionType = (ActivationFunctionType)hiddenFunctionComboBox.SelectedValue;
            outputFunctionType = (ActivationFunctionType)outputFunctionComboBox.SelectedValue;
        }

        private void LearnNetworkCuda()
        {
            MlpNetwork network = new MlpNetwork(numInput, numHidden, numOutput, hiddenFunctionType, outputFunctionType);

            float[] rawInputData = NetworkPrediction.LoadData("InputData.txt");
            NetworkPrediction prediction = new NetworkPrediction(rawInputData, numInput, numOutput, divideFactor);
            NetworkDataSet fullDataSet = prediction.FullDataSet;
            NetworkDataSet learningDataSet = prediction.LearningDataSet;
            NetworkDataSet testingDataSet = prediction.TestingDataSet;

            ErrorPropagationType propagationType = ErrorPropagationType.BackPropagation;
            if (backPropagationRadioButton.Checked)
            {
                propagationType = ErrorPropagationType.BackPropagation;
            }
            else if (resilientPropagationRadioButton.Checked)
            {
                propagationType = ErrorPropagationType.ResilientPropagation;
            }

            LearningProgressForm learningForm = new LearningProgressForm(propagationType, network,
                learningDataSet, maxNumEpoch, maxLearningRms, learningRate, momentum);

            DialogResult result = learningForm.ShowDialog();
            if(result == DialogResult.Abort)
            {
                return;
            }

            float[] learningRms = learningForm.LearningRmsList.ToArray();

            float[][] predictedOutput = network.ComputeOutput(fullDataSet.GetInputData());
            float[][] targetOutput = fullDataSet.GetOutputData();

            float[] testingRms = MatrixHelper.Rms(targetOutput, predictedOutput);

            numEpochLabel.Text = learningForm.NumEpoch.ToString();
            learningRmsLabel.Text = learningRms[learningRms.Length - 1].ToString();
            testingRmsLabel.Text = testingRms[testingRms.Length - 1].ToString();

            float[] predictedOutputArray = MatrixHelper.Convert2DArrayTo1D(predictedOutput);
            float[] targetOutputArray = MatrixHelper.Convert2DArrayTo1D(targetOutput);

            DrawGraph(resultGraphControl, new string[] { "Исходный график", "Нейронная сеть" },
                new string[] { "Red", "Blue"}, new float[][] { targetOutputArray, predictedOutputArray });

            DrawGraph(learningRmsGraphControl, new string[] { "" }, new string[] { "Red" }, new float[][] { learningRms });

            DrawGraph(testingRmsGraphControl, new string[] { "" }, new string[] { "Red" }, new float[][] { testingRms });
        }

        private void DrawGraph(ZedGraphControl graph, string[] labels, string[] colors, float[][] data)
        {
            GraphPane pane = graph.GraphPane;

            pane.CurveList.Clear();

            PointPairList[] lists = new PointPairList[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                lists[i] = new PointPairList();
                for (int j = 0; j < data[i].Length; j++)
                {
                    lists[i].Add(j, data[i][j]);
                }
            }

            LineItem[] myCurves = new LineItem[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                myCurves[i] = pane.AddCurve(labels[i], lists[i], Color.FromName(colors[i]), SymbolType.None);
            }

            graph.AxisChange();
            graph.Invalidate();
        }
    }
}
