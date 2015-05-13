using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;

namespace MlpPredictor
{
    public partial class MainForm : Form
    {
        private NetworkPredictionManager predictionManager;
        private bool paramsChanged;

        public MainForm()
        {
            InitializeComponent();
            InitializeGraphs();

            создатьToolStripMenuItem_Click(this, null);
        }

        public string PredictionFilePath { get; private set; }

        public int NetworkNumInput
        {
            get
            {
                return (int)numInputNumericUpDown.Value;
            }
            set
            {
                numInputNumericUpDown.Value = value;
            }
        }

        public int NetworkNumHidden
        {
            get
            {
                return (int)numHiddenNumericUpDown.Value;
            }
            set
            {
                numHiddenNumericUpDown.Value = value;
            }
        }

        public int NetworkNumOutput
        {
            get
            {
                return (int)numOutputNumericUpDown.Value;
            }
            set
            {
                numOutputNumericUpDown.Value = value;
            }
        }

        public ActivationFunctionType NetworkHiddenFunctionType
        {
            get
            {
                return GetNetworkActivationFunctionType(hiddenFunctionComboBox);
            }
            set
            {
                SetNetworkActivationFunctionType(hiddenFunctionComboBox, value);
            }
        }

        public ActivationFunctionType NetworkOutputFunctionType
        {
            get
            {
                return GetNetworkActivationFunctionType(outputFunctionComboBox);
            }
            set
            {
                SetNetworkActivationFunctionType(outputFunctionComboBox, value);
            }
        }

        public string PredictionDataFilePath
        {
            get
            {
                return dataFilePathTextBox.Text;
            }
            set
            {
                dataFilePathTextBox.Text = value;
            }
        }

        public float LearningDataPercentage
        {
            get
            {
                return (float)learningDataPercentageNumericUpDown.Value;
            }
            set
            {
                learningDataPercentageNumericUpDown.Value = (decimal)value;
            }
        }

        public float TestingDataPercentage
        {
            get
            {
                return (float)testingDataPercentageNumericUpDown.Value;
            }
            set
            {
                testingDataPercentageNumericUpDown.Value = (decimal)value;
            }
        }

        public float MaxLearningRms
        {
            get
            {
                return (float)maxLearningRmsNumericUpDown.Value;
            }
            set
            {
                maxLearningRmsNumericUpDown.Value = (decimal)value;
            }
        }

        public int MaxNumEpoch
        {
            get
            {
                return (int)maxNumEpochNumericUpDown.Value;
            }
            set
            {
                maxNumEpochNumericUpDown.Value = value;
            }
        }

        public float LearningRate
        {
            get
            {
                return (float)learningRateNumericUpDown.Value;
            }
            set
            {
                learningRateNumericUpDown.Value = (decimal)value;
            }
        }

        public float Momentum
        {
            get
            {
                return (float)momentumNumericUpDown.Value;
            }
            set
            {
                momentumNumericUpDown.Value = (decimal)value;
            }
        }

        public LearningAlgorithmType LearningAlgorithmType
        {
            get
            {
                if (backPropagationRadioButton.Checked)
                {
                    return LearningAlgorithmType.BackPropagation;
                }
                else
                {
                    return  LearningAlgorithmType.ResilientBackPropagation;
                }
            }
            set
            {
                switch (value)
                {
                    case LearningAlgorithmType.BackPropagation:
                        backPropagationRadioButton.Checked = true;
                        break;
                    case LearningAlgorithmType.ResilientBackPropagation:
                        resilientPropagationRadioButton.Checked = true;
                        break;
                }
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            predictionManager = new NetworkPredictionManager();

            InitializePredictionParams();
            ClearGraphs();

            try
            {
                predictionManager.LoadPredictionData(PredictionDataFilePath);
            }
            catch
            {
                PredictionDataFilePath = "";
            }
            
            toolStripStatusLabel.Text = "Начат новый прогноз.";
            paramsChanged = false;            
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opd = new OpenFileDialog()
                {
                    Filter = "Файл прогноза|*.prediction",
                    InitialDirectory = Application.StartupPath + @"\Predictions",
                    CheckFileExists = true,
                    CheckPathExists = true
                };

                if (opd.ShowDialog() == DialogResult.OK)
                {
                    predictionManager.LoadPredictionFromBinaryFile(opd.FileName);
                    PredictionFilePath = opd.FileName;
                    ClearGraphs();
                    numHiddenCheckBox.Checked = true;
                    SetPredictionParamsToForm();
                    toolStripStatusLabel.Text = "Прогноз успешно загружен.";
                    paramsChanged = false;                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = PredictionFilePath;

                if (!String.IsNullOrWhiteSpace(filePath))
                {
                    predictionManager.SavePredictionToBinaryFile(filePath);
                    toolStripStatusLabel.Text = "Прогноз успешно сохранён.";
                    paramsChanged = false;                    
                } 
                else
                {
                    сохранитьКакToolStripMenuItem_Click(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Файл прогноза|*.prediction",
                    InitialDirectory = Application.StartupPath + @"\Predictions",
                    CheckPathExists = true
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    predictionManager.SavePredictionToBinaryFile(sfd.FileName);
                    PredictionFilePath = sfd.FileName;
                    toolStripStatusLabel.Text = "Прогноз успешно сохранён.";
                    paramsChanged = false;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void работаСДаннымиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PredictionDataWorkForm().ShowDialog();
        }

        private void руководствоПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"Resources\Help.mht");
            }
            catch
            {
                MessageBox.Show("Файл руководства пользователя не найден. Проверьте наличие файла \"Help.mht\" в папке Resources.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void createNetworkButton_Click(object sender, EventArgs e)
        {
            try
            {
                predictionManager.CreateNetwork(NetworkNumInput, NetworkNumHidden, NetworkNumOutput,
                    NetworkHiddenFunctionType, NetworkOutputFunctionType);
                toolStripStatusLabel.Text = "Сеть успешно создана.";
                paramsChanged = true;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void browseDataFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog()
            {
                Filter = "Текстовый файл с разделителями|*.csv",
                InitialDirectory = Application.StartupPath + @"\PredictionData",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (opd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    predictionManager.LoadPredictionData(opd.FileName);
                    PredictionDataFilePath = opd.FileName;
                    toolStripStatusLabel.Text = "Данные для прогноза успешно выбраны.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void learnNetworkButton_Click(object sender, EventArgs e)
        {
            try
            {
                learnNetworkButton.Enabled = false;

                if (LearningDataPercentage == 0.0f)
                    return;

                // Убрать эти строчки, если удастся обработать асинхронное исключение.
                if (predictionManager.Prediction.Network == null)
                    throw new InvalidOperationException("Сеть не создана.");
                if (predictionManager.Prediction.Data == null)
                    throw new InvalidOperationException("Данные для прогноза не загружены.");

                CheckNetworkUpdate();

                NetworkLearningForm learningForm = new NetworkLearningForm(predictionManager, LearningDataPercentage,
                    LearningAlgorithmType, MaxLearningRms, MaxNumEpoch, LearningRate, Momentum);

                if (learningForm.ShowDialog() == DialogResult.Abort)
                    return;

                int numEpoch = predictionManager.Prediction.Learning.NumEpoch;
                float[] learningRms = predictionManager.Prediction.Learning.Rms;
                float lastLearningRms = learningRms.Last();
                toolStripStatusLabel.Text = String.Format("Сеть успешно обучена. Число пройденных эпох обучения: {0}. " +
                    "Последнее СКО ошибки обучения: {1}.", numEpoch, lastLearningRms);                

                learningRmsGraphControl.DrawGraph(new string[] { "" }, new string[] { "Red" }, new float[][] { learningRms });

                paramsChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                learnNetworkButton.Enabled = true;
            }
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (LearningDataPercentage == 100.0f)
                    return;

                CheckNetworkUpdate();

                predictionManager.TestNetwork(TestingDataPercentage);
                toolStripStatusLabel.Text = "Сеть успешно протестирована.";

                NetworkTesting testing = predictionManager.Prediction.Testing;
                resultGraphControl.DrawGraph(new string[] { "Исходный график", "Нейронная сеть" },
                    new string[] { "Red", "Blue" }, new float[][] { testing.TargetOutput, testing.PredictedOutput });

                testingRmsGraphControl.DrawGraph(new string[] { "" }, new string[] { "Red" }, new float[][] { testing.Rms });

                paramsChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ActivationFunctionType GetNetworkActivationFunctionType(ComboBox activationFunctionComboBox)
        {
            switch ((string)activationFunctionComboBox.SelectedItem)
            {
                case "Логистическая":
                    return ActivationFunctionType.UnipolarSigmoid;
                case "Гипертангенс":
                    return ActivationFunctionType.BipolarSigmoid;
                case "Синус":
                    return ActivationFunctionType.Sinusoid;
                case "Линейная":
                    return ActivationFunctionType.Linear;
                default:
                    throw new InvalidOperationException("Неизвестная функция активации.");
            }
        }

        private void SetNetworkActivationFunctionType(ComboBox activationFunctionComboBox, ActivationFunctionType activationFunctionType)
        {
            switch (activationFunctionType)
            {
                case ActivationFunctionType.UnipolarSigmoid:
                    activationFunctionComboBox.SelectedItem = "Логистическая";
                    break;
                case ActivationFunctionType.BipolarSigmoid:
                    activationFunctionComboBox.SelectedItem = "Гипертангенс";
                    break;
                case ActivationFunctionType.Sinusoid:
                    activationFunctionComboBox.SelectedItem = "Синус";
                    break;
                case ActivationFunctionType.Linear:
                    activationFunctionComboBox.SelectedItem = "Линейная";
                    break;
                default:
                    throw new ArgumentException("Неизвестная функция активации.", "activationFunctionType");
            }
        }

        private void InitializeGraphs()
        {
            resultGraphControl.SetGraphTitles("Номер значения", "Значение функции", "Результаты прогноза");
            learningRmsGraphControl.SetGraphTitles("Номер эпохи", "Значение СКО ошибки", "СКО ошибки обучения");
            testingRmsGraphControl.SetGraphTitles("Номер тестирующего примера", "Значение СКО ошибки", "СКО ошибки тестирования");
        }

        private void InitializePredictionParams()
        {
            PredictionFilePath = "";

            InitializeNetworkParams();

            InitializePredictionDataParams();

            InitializeLearningParams();
        }

        private void InitializeNetworkParams()
        {
            NetworkNumInput = 5;
            NetworkNumHidden = 11;
            NetworkNumOutput = 1;
            NetworkHiddenFunctionType = ActivationFunctionType.UnipolarSigmoid;
            NetworkOutputFunctionType = ActivationFunctionType.UnipolarSigmoid;
        }

        private void InitializePredictionDataParams()
        {
            PredictionDataFilePath = Application.StartupPath + @"\PredictionData\micex_stock_index_2014_10-01-2015_05-12_normalized(0.1, 0.9).csv";
            LearningDataPercentage = 70.0f;
        }

        private void InitializeLearningParams()
        {
            MaxLearningRms = 0.01f;
            MaxNumEpoch = 10000;
            LearningRate = 0.05f;
            Momentum = 0.0f;
            LearningAlgorithmType = LearningAlgorithmType.BackPropagation;
        }

        private void ClearGraphs()
        {
            resultGraphControl.ClearGraph();
            learningRmsGraphControl.ClearGraph();
            testingRmsGraphControl.ClearGraph();
        }

        private void SetPredictionParamsToForm()
        {
            if (predictionManager.Prediction.Network != null)
            {
                SetNetworkParamsToForm();
            }
            if (predictionManager.Prediction.Data != null)
            {
                SetPredictionDataParamsToFrom();
            }
            if (predictionManager.Prediction.Learning != null)
            {
                SetLearningParamsToFrom();
            }
            if (predictionManager.Prediction.Testing != null)
            {
                SetTestingParamsToFrom();
            }
        }

        private void SetNetworkParamsToForm()
        {
            MlpNetwork network = predictionManager.Prediction.Network;

            NetworkNumInput = network.NumInput;
            NetworkNumHidden = network.NumHidden;
            NetworkNumOutput = network.NumOutput;
            NetworkHiddenFunctionType = network.HiddenFunction.Type;
            NetworkOutputFunctionType = network.OutputFunction.Type;
        }

        private void SetPredictionDataParamsToFrom()
        {
            NetworkPredictionData predictionData = predictionManager.Prediction.Data;

            PredictionDataFilePath = predictionData.FilePath;
            LearningDataPercentage = predictionData.LearningDataPercentage;
        }

        private void SetLearningParamsToFrom()
        {
            INetworkLearning learning = predictionManager.Prediction.Learning;

            MaxLearningRms = learning.MaxRms;
            MaxNumEpoch = learning.MaxNumEpoch;

            if (learning is CudaBackPropagationLearning)
            {
                LearningAlgorithmType = LearningAlgorithmType.BackPropagation;

                CudaBackPropagationLearning cudaBackPropLearning = (CudaBackPropagationLearning)learning;
                LearningRate = cudaBackPropLearning.LearningRate;
                Momentum = cudaBackPropLearning.Momentum;
            }
            else
            {
                LearningAlgorithmType = LearningAlgorithmType.ResilientBackPropagation;
            }

            learningRmsGraphControl.DrawGraph(new string[] { "" }, new string[] { "Red" }, new float[][] { learning.Rms });
        }

        private void SetTestingParamsToFrom()
        {
            NetworkTesting testing = predictionManager.Prediction.Testing;

            resultGraphControl.DrawGraph(new string[] { "Исходный график", "Нейронная сеть" }, new string[] { "Red", "Blue" },
                new float[][] { testing.TargetOutput, testing.PredictedOutput });

            testingRmsGraphControl.DrawGraph(new string[] { "" }, new string[] { "Red" }, new float[][] { testing.Rms });
        }

        private bool NetworkParamsChanged()
        {
            MlpNetwork network = predictionManager.Prediction.Network;

            if (network.NumInput != NetworkNumInput ||
                network.NumHidden != NetworkNumHidden ||
                network.NumOutput != NetworkNumOutput ||
                network.HiddenFunction.Type != NetworkHiddenFunctionType ||
                network.OutputFunction.Type != NetworkOutputFunctionType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CheckNetworkUpdate()
        {
            if (predictionManager.Prediction.Network != null && NetworkParamsChanged())
            {
                DialogResult result = MessageBox.Show("Параметры сети были изменены. Пересоздать сеть? " +
                    "В противном случае параметры будут установлены в актуальные для сети значения.",
                    "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        predictionManager.CreateNetwork(NetworkNumInput, NetworkNumHidden, NetworkNumOutput,
                            NetworkHiddenFunctionType, NetworkOutputFunctionType);
                        break;
                    case DialogResult.No:
                        numHiddenCheckBox.Checked = true;
                        SetNetworkParamsToForm();
                        break;
                    //default:
                    //    return;
                }
            }
        }

        private void numHiddenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!numHiddenCheckBox.Checked)
            {
                numHiddenNumericUpDown.Enabled = false;
                NetworkNumHidden = NetworkNumInput * 2 + NetworkNumOutput;
            }
            else
            {
                numHiddenNumericUpDown.Enabled = true;
            }
        }

        private void numInputNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            paramsChanged = true;

            if (!numHiddenCheckBox.Checked)
            {
                NetworkNumHidden = NetworkNumInput * 2 + NetworkNumOutput;
            }
        }

        private void numHiddenNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            paramsChanged = true;
        }

        private void numOutputNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            paramsChanged = true;

            if (!numHiddenCheckBox.Checked)
            {
                NetworkNumHidden = NetworkNumInput * 2 + NetworkNumOutput;
            }
        }

        private void learningDataPercentageNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            testingDataPercentageNumericUpDown.Value = 100.0m - learningDataPercentageNumericUpDown.Value;
        }

        private void testingDataPercentageNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            learningDataPercentageNumericUpDown.Value = 100.0m - testingDataPercentageNumericUpDown.Value;
        }

        private void hiddenFunctionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            paramsChanged = true;
        }

        private void outputFunctionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            paramsChanged = true;
        }

        private void dataFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            paramsChanged = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (paramsChanged)
            {
                DialogResult result = MessageBox.Show("Параметры прогноза были изменены. Хотите сохранить изменения?",
                    "Выход", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        сохранитьToolStripMenuItem_Click(this, null);
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
