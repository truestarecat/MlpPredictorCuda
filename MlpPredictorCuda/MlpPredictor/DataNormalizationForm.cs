using System;
using System.Windows.Forms;

namespace MlpPredictor
{
    public partial class DataNormalizationForm : Form
    {
        private float[] dataToNormalize;

        public DataNormalizationForm(float[] dataToNormalize)
        {
            if (dataToNormalize == null)
                throw new ArgumentNullException("dataToNormalize");
            if (dataToNormalize.Length == 0)
                throw new ArgumentException("Недостаточно исходных данных.");

            InitializeComponent();

            this.dataToNormalize = dataToNormalize;
        }

        public float[] NormalizedData { get; private set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            float min = (float)minValueNumericUpDown.Value;
            float max = (float)maxValueNumericUpDown.Value;

            try
            {
                NormalizedData = NetworkPredictionData.NormalizeLinearly(dataToNormalize, min, max);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
