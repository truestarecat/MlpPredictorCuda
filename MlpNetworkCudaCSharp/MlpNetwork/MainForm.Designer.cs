namespace MlpNetwork
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numInputNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numHiddenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numOutputNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hiddenFunctionComboBox = new System.Windows.Forms.ComboBox();
            this.outputFunctionComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.backPropagationRadioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.resilientPropagationRadioButton = new System.Windows.Forms.RadioButton();
            this.maxNumEpochNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.divideFactorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxLearningRmsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.learningRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.momentumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.learnNetworkButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.predictionResultTabPage = new System.Windows.Forms.TabPage();
            this.resultGraphControl = new ZedGraph.ZedGraphControl();
            this.learningTabPage = new System.Windows.Forms.TabPage();
            this.learningRmsGraphControl = new ZedGraph.ZedGraphControl();
            this.testingTabPage = new System.Windows.Forms.TabPage();
            this.testingRmsGraphControl = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.testNetworkButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.dataFilePathTextBox = new System.Windows.Forms.TextBox();
            this.browseFileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHiddenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumEpochNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.divideFactorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxLearningRmsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.momentumNumericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.predictionResultTabPage.SuspendLayout();
            this.learningTabPage.SuspendLayout();
            this.testingTabPage.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(947, 521);
            this.splitContainer1.SplitterDistance = 359;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.78105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.00901F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.209935F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(359, 521);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Структура сети";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.numInputNumericUpDown, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.numHiddenNumericUpDown, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.numOutputNumericUpDown, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.hiddenFunctionComboBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.outputFunctionComboBox, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(347, 124);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Число входов:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Число скрытых нейронов:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Число выходов:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Функция активации скрытого слоя:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Функция активации выходного слоя:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numInputNumericUpDown
            // 
            this.numInputNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numInputNumericUpDown.Location = new System.Drawing.Point(228, 3);
            this.numInputNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInputNumericUpDown.Name = "numInputNumericUpDown";
            this.numInputNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.numInputNumericUpDown.TabIndex = 5;
            this.numInputNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numHiddenNumericUpDown
            // 
            this.numHiddenNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numHiddenNumericUpDown.Location = new System.Drawing.Point(228, 27);
            this.numHiddenNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHiddenNumericUpDown.Name = "numHiddenNumericUpDown";
            this.numHiddenNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.numHiddenNumericUpDown.TabIndex = 6;
            this.numHiddenNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numOutputNumericUpDown
            // 
            this.numOutputNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numOutputNumericUpDown.Location = new System.Drawing.Point(228, 51);
            this.numOutputNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOutputNumericUpDown.Name = "numOutputNumericUpDown";
            this.numOutputNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.numOutputNumericUpDown.TabIndex = 7;
            this.numOutputNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // hiddenFunctionComboBox
            // 
            this.hiddenFunctionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hiddenFunctionComboBox.DisplayMember = "Value";
            this.hiddenFunctionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hiddenFunctionComboBox.FormattingEnabled = true;
            this.hiddenFunctionComboBox.Location = new System.Drawing.Point(228, 75);
            this.hiddenFunctionComboBox.Name = "hiddenFunctionComboBox";
            this.hiddenFunctionComboBox.Size = new System.Drawing.Size(116, 21);
            this.hiddenFunctionComboBox.TabIndex = 8;
            this.hiddenFunctionComboBox.ValueMember = "Key";
            // 
            // outputFunctionComboBox
            // 
            this.outputFunctionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFunctionComboBox.DisplayMember = "Value";
            this.outputFunctionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputFunctionComboBox.FormattingEnabled = true;
            this.outputFunctionComboBox.Location = new System.Drawing.Point(228, 99);
            this.outputFunctionComboBox.Name = "outputFunctionComboBox";
            this.outputFunctionComboBox.Size = new System.Drawing.Size(116, 21);
            this.outputFunctionComboBox.TabIndex = 9;
            this.outputFunctionComboBox.ValueMember = "Key";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 317);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры обучения";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.Controls.Add(this.resilientPropagationRadioButton, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.momentumNumericUpDown, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.learningRateNumericUpDown, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.backPropagationRadioButton, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.maxNumEpochNumericUpDown, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.maxLearningRmsNumericUpDown, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.divideFactorNumericUpDown, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.browseFileButton, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 9;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.42227F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.69341F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.69341F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.69341F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.69341F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.69341F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.69341F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.68913F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.728157F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(347, 298);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 26);
            this.label6.TabIndex = 0;
            this.label6.Text = "Соотношение обучающей и тестирующей выборок:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Максимальное СКО ошибки обучения:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Максимальное число эпох обучения:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // backPropagationRadioButton
            // 
            this.backPropagationRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.backPropagationRadioButton.AutoSize = true;
            this.backPropagationRadioButton.Checked = true;
            this.backPropagationRadioButton.Location = new System.Drawing.Point(3, 154);
            this.backPropagationRadioButton.Name = "backPropagationRadioButton";
            this.backPropagationRadioButton.Size = new System.Drawing.Size(194, 17);
            this.backPropagationRadioButton.TabIndex = 3;
            this.backPropagationRadioButton.TabStop = true;
            this.backPropagationRadioButton.Text = "Алгоритм наискорейшего спуска";
            this.backPropagationRadioButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(93, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Коэффициент обучения:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(172, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Момент:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // resilientPropagationRadioButton
            // 
            this.resilientPropagationRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.resilientPropagationRadioButton.AutoSize = true;
            this.resilientPropagationRadioButton.Location = new System.Drawing.Point(3, 247);
            this.resilientPropagationRadioButton.Name = "resilientPropagationRadioButton";
            this.resilientPropagationRadioButton.Size = new System.Drawing.Size(115, 17);
            this.resilientPropagationRadioButton.TabIndex = 6;
            this.resilientPropagationRadioButton.Text = "Алгоритм RPROP";
            this.resilientPropagationRadioButton.UseVisualStyleBackColor = true;
            // 
            // maxNumEpochNumericUpDown
            // 
            this.maxNumEpochNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maxNumEpochNumericUpDown.Location = new System.Drawing.Point(228, 121);
            this.maxNumEpochNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.maxNumEpochNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxNumEpochNumericUpDown.Name = "maxNumEpochNumericUpDown";
            this.maxNumEpochNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.maxNumEpochNumericUpDown.TabIndex = 9;
            this.maxNumEpochNumericUpDown.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // divideFactorNumericUpDown
            // 
            this.divideFactorNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.divideFactorNumericUpDown.DecimalPlaces = 2;
            this.divideFactorNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.divideFactorNumericUpDown.Location = new System.Drawing.Point(228, 59);
            this.divideFactorNumericUpDown.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            131072});
            this.divideFactorNumericUpDown.Name = "divideFactorNumericUpDown";
            this.divideFactorNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.divideFactorNumericUpDown.TabIndex = 12;
            this.divideFactorNumericUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // maxLearningRmsNumericUpDown
            // 
            this.maxLearningRmsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maxLearningRmsNumericUpDown.DecimalPlaces = 10;
            this.maxLearningRmsNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.maxLearningRmsNumericUpDown.Location = new System.Drawing.Point(228, 90);
            this.maxLearningRmsNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxLearningRmsNumericUpDown.Name = "maxLearningRmsNumericUpDown";
            this.maxLearningRmsNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.maxLearningRmsNumericUpDown.TabIndex = 13;
            this.maxLearningRmsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // learningRateNumericUpDown
            // 
            this.learningRateNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.learningRateNumericUpDown.DecimalPlaces = 3;
            this.learningRateNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.learningRateNumericUpDown.Location = new System.Drawing.Point(228, 183);
            this.learningRateNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.learningRateNumericUpDown.Name = "learningRateNumericUpDown";
            this.learningRateNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.learningRateNumericUpDown.TabIndex = 14;
            this.learningRateNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // momentumNumericUpDown
            // 
            this.momentumNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.momentumNumericUpDown.DecimalPlaces = 3;
            this.momentumNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.momentumNumericUpDown.Location = new System.Drawing.Point(228, 214);
            this.momentumNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.momentumNumericUpDown.Name = "momentumNumericUpDown";
            this.momentumNumericUpDown.Size = new System.Drawing.Size(116, 20);
            this.momentumNumericUpDown.TabIndex = 15;
            this.momentumNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // learnNetworkButton
            // 
            this.learnNetworkButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.learnNetworkButton.Location = new System.Drawing.Point(14, 10);
            this.learnNetworkButton.Name = "learnNetworkButton";
            this.learnNetworkButton.Size = new System.Drawing.Size(147, 23);
            this.learnNetworkButton.TabIndex = 3;
            this.learnNetworkButton.Text = "Обучить";
            this.learnNetworkButton.UseVisualStyleBackColor = true;
            this.learnNetworkButton.Click += new System.EventHandler(this.learnNetworkButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tabControl1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(584, 521);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Графики";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.learningTabPage);
            this.tabControl1.Controls.Add(this.testingTabPage);
            this.tabControl1.Controls.Add(this.predictionResultTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 502);
            this.tabControl1.TabIndex = 0;
            // 
            // predictionResultTabPage
            // 
            this.predictionResultTabPage.Controls.Add(this.resultGraphControl);
            this.predictionResultTabPage.Location = new System.Drawing.Point(4, 22);
            this.predictionResultTabPage.Name = "predictionResultTabPage";
            this.predictionResultTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.predictionResultTabPage.Size = new System.Drawing.Size(570, 476);
            this.predictionResultTabPage.TabIndex = 0;
            this.predictionResultTabPage.Text = "Результат прогноза";
            this.predictionResultTabPage.UseVisualStyleBackColor = true;
            // 
            // resultGraphControl
            // 
            this.resultGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGraphControl.Location = new System.Drawing.Point(3, 3);
            this.resultGraphControl.Name = "resultGraphControl";
            this.resultGraphControl.ScrollGrace = 0D;
            this.resultGraphControl.ScrollMaxX = 0D;
            this.resultGraphControl.ScrollMaxY = 0D;
            this.resultGraphControl.ScrollMaxY2 = 0D;
            this.resultGraphControl.ScrollMinX = 0D;
            this.resultGraphControl.ScrollMinY = 0D;
            this.resultGraphControl.ScrollMinY2 = 0D;
            this.resultGraphControl.Size = new System.Drawing.Size(564, 470);
            this.resultGraphControl.TabIndex = 0;
            // 
            // learningTabPage
            // 
            this.learningTabPage.Controls.Add(this.learningRmsGraphControl);
            this.learningTabPage.Location = new System.Drawing.Point(4, 22);
            this.learningTabPage.Name = "learningTabPage";
            this.learningTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.learningTabPage.Size = new System.Drawing.Size(570, 476);
            this.learningTabPage.TabIndex = 1;
            this.learningTabPage.Text = "СКО ошибки обучения";
            this.learningTabPage.UseVisualStyleBackColor = true;
            // 
            // learningRmsGraphControl
            // 
            this.learningRmsGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.learningRmsGraphControl.Location = new System.Drawing.Point(3, 3);
            this.learningRmsGraphControl.Name = "learningRmsGraphControl";
            this.learningRmsGraphControl.ScrollGrace = 0D;
            this.learningRmsGraphControl.ScrollMaxX = 0D;
            this.learningRmsGraphControl.ScrollMaxY = 0D;
            this.learningRmsGraphControl.ScrollMaxY2 = 0D;
            this.learningRmsGraphControl.ScrollMinX = 0D;
            this.learningRmsGraphControl.ScrollMinY = 0D;
            this.learningRmsGraphControl.ScrollMinY2 = 0D;
            this.learningRmsGraphControl.Size = new System.Drawing.Size(564, 470);
            this.learningRmsGraphControl.TabIndex = 0;
            // 
            // testingTabPage
            // 
            this.testingTabPage.Controls.Add(this.testingRmsGraphControl);
            this.testingTabPage.Location = new System.Drawing.Point(4, 22);
            this.testingTabPage.Name = "testingTabPage";
            this.testingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.testingTabPage.Size = new System.Drawing.Size(570, 476);
            this.testingTabPage.TabIndex = 2;
            this.testingTabPage.Text = "СКО ошибки тестирования";
            this.testingTabPage.UseVisualStyleBackColor = true;
            // 
            // testingRmsGraphControl
            // 
            this.testingRmsGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testingRmsGraphControl.Location = new System.Drawing.Point(3, 3);
            this.testingRmsGraphControl.Name = "testingRmsGraphControl";
            this.testingRmsGraphControl.ScrollGrace = 0D;
            this.testingRmsGraphControl.ScrollMaxX = 0D;
            this.testingRmsGraphControl.ScrollMaxY = 0D;
            this.testingRmsGraphControl.ScrollMaxY2 = 0D;
            this.testingRmsGraphControl.ScrollMinX = 0D;
            this.testingRmsGraphControl.ScrollMinY = 0D;
            this.testingRmsGraphControl.ScrollMinY2 = 0D;
            this.testingRmsGraphControl.Size = new System.Drawing.Size(564, 470);
            this.testingRmsGraphControl.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.learnNetworkButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.testNetworkButton, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 475);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(353, 43);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // testNetworkButton
            // 
            this.testNetworkButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.testNetworkButton.Location = new System.Drawing.Point(191, 10);
            this.testNetworkButton.Name = "testNetworkButton";
            this.testNetworkButton.Size = new System.Drawing.Size(147, 23);
            this.testNetworkButton.TabIndex = 4;
            this.testNetworkButton.Text = "Тестировать";
            this.testNetworkButton.UseVisualStyleBackColor = true;
            this.testNetworkButton.Click += new System.EventHandler(this.testNetworkButton_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.dataFilePathTextBox, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(219, 48);
            this.tableLayoutPanel5.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Файл с обучающими данными:";
            // 
            // dataFilePathTextBox
            // 
            this.dataFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataFilePathTextBox.Location = new System.Drawing.Point(3, 27);
            this.dataFilePathTextBox.Name = "dataFilePathTextBox";
            this.dataFilePathTextBox.Size = new System.Drawing.Size(213, 20);
            this.dataFilePathTextBox.TabIndex = 1;
            // 
            // browseFileButton
            // 
            this.browseFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.browseFileButton.Location = new System.Drawing.Point(248, 15);
            this.browseFileButton.Name = "browseFileButton";
            this.browseFileButton.Size = new System.Drawing.Size(75, 23);
            this.browseFileButton.TabIndex = 17;
            this.browseFileButton.Text = "Обзор...";
            this.browseFileButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 521);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Многослойный персептрон";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHiddenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumEpochNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.divideFactorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxLearningRmsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.momentumNumericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.predictionResultTabPage.ResumeLayout(false);
            this.learningTabPage.ResumeLayout(false);
            this.testingTabPage.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage predictionResultTabPage;
        private System.Windows.Forms.TabPage learningTabPage;
        private System.Windows.Forms.TabPage testingTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton backPropagationRadioButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton resilientPropagationRadioButton;
        private System.Windows.Forms.Button learnNetworkButton;
        private System.Windows.Forms.NumericUpDown numInputNumericUpDown;
        private System.Windows.Forms.NumericUpDown numHiddenNumericUpDown;
        private System.Windows.Forms.NumericUpDown numOutputNumericUpDown;
        private System.Windows.Forms.ComboBox hiddenFunctionComboBox;
        private System.Windows.Forms.ComboBox outputFunctionComboBox;
        private System.Windows.Forms.NumericUpDown maxNumEpochNumericUpDown;
        private ZedGraph.ZedGraphControl resultGraphControl;
        private ZedGraph.ZedGraphControl learningRmsGraphControl;
        private ZedGraph.ZedGraphControl testingRmsGraphControl;
        private System.Windows.Forms.NumericUpDown divideFactorNumericUpDown;
        private System.Windows.Forms.NumericUpDown maxLearningRmsNumericUpDown;
        private System.Windows.Forms.NumericUpDown learningRateNumericUpDown;
        private System.Windows.Forms.NumericUpDown momentumNumericUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button testNetworkButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox dataFilePathTextBox;
        private System.Windows.Forms.Button browseFileButton;
    }
}

