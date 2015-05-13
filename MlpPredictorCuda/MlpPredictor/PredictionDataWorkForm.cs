using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MlpPredictor
{
    public partial class PredictionDataWorkForm : Form
    {
        private class PredictionDataValue
        {
            public float Value { get; set; }
        }

        private BindingList<PredictionDataValue> predictionDataBindingList;
        private BindingSource predictionDataBindingSource;
        private bool paramsChanged;

        public PredictionDataWorkForm()
        {
            InitializeComponent();
            InitializeGraph();

            создатьToolStripMenuItem_Click(this, null);
        }

        public string PredictionDataFilePath { get; private set; }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PredictionDataFilePath = "";

            predictionDataBindingList = new BindingList<PredictionDataValue>();
            predictionDataBindingSource = new BindingSource(predictionDataBindingList, null);
            predictionDataGridView.DataSource = predictionDataBindingSource;

            ClearGraph();

            paramsChanged = false;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opd = new OpenFileDialog()
                {
                    Filter = "Файл с разделителями|*.csv",
                    InitialDirectory = Application.StartupPath + @"\PredictionData",
                    CheckFileExists = true,
                    CheckPathExists = true
                };

                if (opd.ShowDialog() == DialogResult.OK)
                {
                    predictionDataBindingList = CreateBindingListFromFloatArray(NetworkPredictionData.LoadDataFromCsvFile(opd.FileName));
                    predictionDataBindingSource = new BindingSource(predictionDataBindingList, null);
                    predictionDataGridView.DataSource = predictionDataBindingSource;

                    PredictionDataFilePath = opd.FileName;
                    showButton_Click(this, null);
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
                string filePath = PredictionDataFilePath;

                if (!String.IsNullOrWhiteSpace(filePath))
                {
                    NetworkPredictionData.SaveDataToCsvFile(filePath, ConvertBindingListToFloatArray(predictionDataBindingList));
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
                    Filter = "Файл с разделителями|*.csv",
                    InitialDirectory = Application.StartupPath + @"\PredictionData",
                    CheckPathExists = true
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    NetworkPredictionData.SaveDataToCsvFile(sfd.FileName, ConvertBindingListToFloatArray(predictionDataBindingList));
                    PredictionDataFilePath = sfd.FileName;
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
            Close();
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

        private void showButton_Click(object sender, EventArgs e)
        {
            predictionDataGraphControl.DrawGraph(new string[] { "" }, new string[] { "Red" },
                new float[][] { ConvertBindingListToFloatArray(predictionDataBindingList) });

            paramsChanged = true;
        }

        private void normalizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataNormalizationForm dnf = new DataNormalizationForm(ConvertBindingListToFloatArray(predictionDataBindingList));
                if (dnf.ShowDialog() == DialogResult.OK)
                {
                    predictionDataBindingList = CreateBindingListFromFloatArray(dnf.NormalizedData);
                    predictionDataBindingSource = new BindingSource(predictionDataBindingList, null);
                    predictionDataGridView.DataSource = predictionDataBindingSource;
                    showButton_Click(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeGraph()
        {
            predictionDataGraphControl.SetGraphTitles("Номер значения", "Значение функции", "Вид функции");
        }

        private void ClearGraph()
        {
            predictionDataGraphControl.ClearGraph();
        }

        private static BindingList<PredictionDataValue> CreateBindingListFromFloatArray(float[] array)
        {
            return new BindingList<PredictionDataValue>(array.Select(value => new PredictionDataValue() { Value = value }).ToList());
        }

        private static float[] ConvertBindingListToFloatArray(BindingList<PredictionDataValue> bindingList)
        {
            return bindingList.Select(data => data.Value).ToArray();
        }

        private void predictionDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введите корректное число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
