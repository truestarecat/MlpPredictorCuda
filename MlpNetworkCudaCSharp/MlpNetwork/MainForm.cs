using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MlpNetwork
{
    public partial class MainForm : Form
    {
        private NetworkPredictionManager predictionManager;

        public MainForm()
        {
            InitializeComponent();

            predictionManager = new NetworkPredictionManager();

            this.hiddenFunctionComboBox.DataSource = typeof(ActivationFunctionType).ToList();
            this.outputFunctionComboBox.DataSource = typeof(ActivationFunctionType).ToList();

            this.dataSeparatorComboBox.SelectedIndex = 0;

            this.dataFilePathTextBox.Text = Application.StartupPath + @"\InputData.txt";

            resultGraphControl.ClearGraph();
            learningRmsGraphControl.ClearGraph();
            testingRmsGraphControl.ClearGraph();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(LoadPredictionManager())
            {
                SetParamsToGui();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePredictionManager();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void руководствоПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"Resources\Help.mht");
            }
            catch
            {
                MessageBox.Show("Файл справки не найден. Проверьте наличие файла \"Help.mht\" в папке Resources.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private bool LoadPredictionManager()
        {
            OpenFileDialog opd = new OpenFileDialog()
            {
                Filter = "Файл нейросети|*.network",
                InitialDirectory = Application.StartupPath + @"\Networks"
            };

            if (opd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    predictionManager = NetworkPredictionManager.LoadFromFile(opd.FileName);

                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка при открытии файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        private bool SavePredictionManager()
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Файл нейросети|*.network",
                InitialDirectory = Application.StartupPath + @"\Networks"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    predictionManager.SaveToFile(sfd.FileName);

                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка при сохранении файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
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
            
            GetParamsFromGui();
            
            LearnNetwork();
            
            learnNetworkButton.Enabled = true;
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            TestNetwork();
        } 

        private void GetParamsFromGui()
        {
            predictionManager.NetworkNumInput = (int)numInputNumericUpDown.Value;
            predictionManager.NetworkNumHidden = (int)numHiddenNumericUpDown.Value;
            predictionManager.NetworkNumOutput = (int)numOutputNumericUpDown.Value;
            predictionManager.NetworkHiddenFunctionType = (ActivationFunctionType)hiddenFunctionComboBox.SelectedValue;
            predictionManager.NetworkOutputFunctionType = (ActivationFunctionType)outputFunctionComboBox.SelectedValue;
            predictionManager.LearningDataPercentage = (float)learningDataPercentageNumericUpDown.Value;
            predictionManager.MaxLearningRms = (float)maxLearningRmsNumericUpDown.Value;
            predictionManager.MaxNumEpoch = (int)maxNumEpochNumericUpDown.Value;
            predictionManager.LearningRate = (float)learningRateNumericUpDown.Value;
            predictionManager.Momentum = (float)momentumNumericUpDown.Value;

            if (backPropagationRadioButton.Checked)
            {
                predictionManager.LearningAlgorithmType = LearningAlgorithmType.BackPropagation;
            }
            else if (resilientPropagationRadioButton.Checked)
            {
                predictionManager.LearningAlgorithmType = LearningAlgorithmType.ResilientBackPropagation;
            }
        }

        private void SetParamsToGui()
        {
            numInputNumericUpDown.Value = predictionManager.NetworkNumInput;
            numHiddenNumericUpDown.Value = predictionManager.NetworkNumHidden;
            numOutputNumericUpDown.Value = predictionManager.NetworkNumOutput;
            hiddenFunctionComboBox.SelectedValue = predictionManager.NetworkHiddenFunctionType;
            outputFunctionComboBox.SelectedValue = predictionManager.NetworkOutputFunctionType;
            learningDataPercentageNumericUpDown.Value = (decimal)predictionManager.LearningDataPercentage;
            maxLearningRmsNumericUpDown.Value = (decimal)predictionManager.MaxLearningRms;
            maxNumEpochNumericUpDown.Value = predictionManager.MaxNumEpoch;
            learningRateNumericUpDown.Value = (decimal)predictionManager.LearningRate;
            momentumNumericUpDown.Value = (decimal)predictionManager.Momentum;

            switch(predictionManager.LearningAlgorithmType)
            {
                case LearningAlgorithmType.BackPropagation:
                    backPropagationRadioButton.Checked = true;
                    break;
                case LearningAlgorithmType.ResilientBackPropagation:
                    resilientPropagationRadioButton.Checked = true;
                    break;
            }
        }

        private bool SetPredictionDataParams()
        {
            string filePath = dataFilePathTextBox.Text;

            if(String.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Не задан путь к файлу с данными.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(!File.Exists(filePath))
            {
                MessageBox.Show("Заданного файла не существует. Проверьте путь к файлу с данными.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                predictionManager.PredictionDataFilePath = filePath;
                predictionManager.PredictionDataSeparator = separator;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LearnNetwork()
        {
            if (!SetPredictionDataParams())
                return;

            NetworkLearningForm learningForm = new NetworkLearningForm(predictionManager);

            DialogResult result = DialogResult.Abort;
            try
            {
                result = learningForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if(result == DialogResult.Abort)
            {
                return;
            }

            float[] learningRms = predictionManager.LearningRms;

            learningRmsGraphControl.DrawGraph(new string[] { "" }, new string[] { "Red" }, new float[][] { learningRms });
        }

        private void TestNetwork()
        {
            try
            {
                predictionManager.TestNetwork();
            }
            catch (NetworkNotTrainedException ex)
            {
                MessageBox.Show("Сеть не обучена. Обучите сеть, а затем выполните её тестирование.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            resultGraphControl.DrawGraph(new string[] { "Исходный график", "Нейронная сеть" },
                new string[] { "Red", "Blue" }, new float[][] { predictionManager.TargetOutput, predictionManager.PredictedOutput });

            testingRmsGraphControl.DrawGraph(new string[] { "" }, new string[] { "Red" }, new float[][] { predictionManager.TestingRms });
        }
    }
}
