using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ZedGraph;

namespace MlpNetwork
{
    public partial class MainForm : Form
    {
		private int numInput;
		private int numHidden;
		private int numOutput;
        private float learningDataPercentage;
        private float maxLearningRms;
		private int maxNumEpoch;
		private float learningRate;
		private float momentum;
        private ActivationFunctionType hiddenFunctionType;
        private ActivationFunctionType outputFunctionType;
        private ErrorPropagationType propagationType;

        private MlpNetwork network;
        private NetworkPrediction prediction;

        private float[] rawInputData;

        public MainForm()
        {
            InitializeComponent();

            this.hiddenFunctionComboBox.DataSource = typeof(ActivationFunctionType).ToList();
            this.outputFunctionComboBox.DataSource = typeof(ActivationFunctionType).ToList();

            this.dataSeparatorComboBox.SelectedIndex = 0;

            this.dataFilePathTextBox.Text = Application.StartupPath + @"\InputData.txt";
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void browseDataFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog()
            {
                Filter = "Текстовый файл|*.txt",
                InitialDirectory = Application.StartupPath
            };

            if (opd.ShowDialog() == DialogResult.OK)
            {
                dataFilePathTextBox.Text = opd.FileName;
            }
        }

        private void learnNetworkButton_Click(object sender, EventArgs e)
        {
            learnNetworkButton.Enabled = false;
            
            SetParams();
            
            LearnNetworkCuda();
            
            learnNetworkButton.Enabled = true;
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            TestNetwork();
        } 

        private void SetParams()
        {
            this.numInput = (int)numInputNumericUpDown.Value;
            this.numHidden = (int)numHiddenNumericUpDown.Value;
            this.numOutput = (int)numOutputNumericUpDown.Value;
            this.hiddenFunctionType = (ActivationFunctionType)hiddenFunctionComboBox.SelectedValue;
            this.outputFunctionType = (ActivationFunctionType)outputFunctionComboBox.SelectedValue;
            this.learningDataPercentage = (float)learningDataPercentageNumericUpDown.Value;
            this.maxLearningRms = (float)maxLearningRmsNumericUpDown.Value;
            this.maxNumEpoch = (int)maxNumEpochNumericUpDown.Value;
            this.learningRate = (float)learningRateNumericUpDown.Value;
            this.momentum = (float)momentumNumericUpDown.Value;

            if (backPropagationRadioButton.Checked)
            {
                propagationType = ErrorPropagationType.BackPropagation;
            }
            else if (resilientPropagationRadioButton.Checked)
            {
                propagationType = ErrorPropagationType.ResilientPropagation;
            }
        }

        private bool LoadData()
        {
            string filePath = dataFilePathTextBox.Text;

            if(String.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Не задан путь к файлу с данными.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(!File.Exists(filePath))
            {
                MessageBox.Show("Заданного файла не существует. Проверьте путь к файлу с данными.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                string separator = null;
                switch(dataSeparatorComboBox.SelectedItem.ToString())
                {
                    case "Новая строка":
                        separator = Environment.NewLine;
                        break;
                    case "Пробел":
                        separator = " ";
                        break;
                }

                rawInputData = NetworkPrediction.LoadData(filePath, separator);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LearnNetworkCuda()
        {
            network = new MlpNetwork(numInput, numHidden, numOutput, hiddenFunctionType, outputFunctionType);

            if (!LoadData())
                return;

            prediction = new NetworkPrediction(rawInputData, numInput, numOutput, learningDataPercentage / 100.0f);

            NetworkLearningForm learningForm = new NetworkLearningForm(propagationType, network,
                prediction.LearningDataSet, maxNumEpoch, maxLearningRms, learningRate, momentum);

            DialogResult result = learningForm.ShowDialog();
            if(result == DialogResult.Abort)
            {
                return;
            }

            float[] learningRms = learningForm.LearningRmsList.ToArray();

            DrawGraph(learningRmsGraphControl, new string[] { "" }, new string[] { "Red" }, new float[][] { learningRms });
        }

        private void TestNetwork()
        {
            NetworkDataSet fullDataSet = prediction.FullDataSet;

            float[][] predictedOutput = network.ComputeOutput(fullDataSet.GetInputData());
            float[][] targetOutput = fullDataSet.GetOutputData();

            float[] testingRms = MatrixHelper.Rms(targetOutput, predictedOutput);

            float[] predictedOutputArray = MatrixHelper.Convert2DArrayTo1D(predictedOutput);
            float[] targetOutputArray = MatrixHelper.Convert2DArrayTo1D(targetOutput);

            DrawGraph(resultGraphControl, new string[] { "Исходный график", "Нейронная сеть" },
                new string[] { "Red", "Blue" }, new float[][] { targetOutputArray, predictedOutputArray });
         
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
