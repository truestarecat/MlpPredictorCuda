namespace MlpPredictor
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
            this.testNetworkButton = new System.Windows.Forms.Button();
            this.testingDataPercentageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.learnNetworkButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numHiddenCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numInputNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numHiddenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numOutputNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hiddenFunctionComboBox = new System.Windows.Forms.ComboBox();
            this.outputFunctionComboBox = new System.Windows.Forms.ComboBox();
            this.createNetworkButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.resilientPropagationRadioButton = new System.Windows.Forms.RadioButton();
            this.learningDataPercentageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.momentumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.learningRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.backPropagationRadioButton = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.maxNumEpochNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxLearningRmsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.dataFilePathTextBox = new System.Windows.Forms.TextBox();
            this.browseDataFileButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСДаннымиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.learningRmsGraphControl = new ZedGraph.ZedGraphControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.predictionResultTabPage = new System.Windows.Forms.TabPage();
            this.resultGraphControl = new ZedGraph.ZedGraphControl();
            this.learningRmsTabPage = new System.Windows.Forms.TabPage();
            this.testingRmsTabPage = new System.Windows.Forms.TabPage();
            this.testingRmsGraphControl = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.testingDataPercentageNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHiddenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.learningDataPercentageNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.momentumNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumEpochNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxLearningRmsNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.predictionResultTabPage.SuspendLayout();
            this.learningRmsTabPage.SuspendLayout();
            this.testingRmsTabPage.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // testNetworkButton
            // 
            this.testNetworkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.testNetworkButton.Location = new System.Drawing.Point(218, 29);
            this.testNetworkButton.Name = "testNetworkButton";
            this.testNetworkButton.Size = new System.Drawing.Size(111, 22);
            this.testNetworkButton.TabIndex = 1;
            this.testNetworkButton.Text = "Тестировать сеть";
            this.testNetworkButton.UseVisualStyleBackColor = true;
            this.testNetworkButton.Click += new System.EventHandler(this.testNetworkButton_Click);
            // 
            // testingDataPercentageNumericUpDown
            // 
            this.testingDataPercentageNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.testingDataPercentageNumericUpDown.DecimalPlaces = 2;
            this.testingDataPercentageNumericUpDown.Location = new System.Drawing.Point(218, 3);
            this.testingDataPercentageNumericUpDown.Name = "testingDataPercentageNumericUpDown";
            this.testingDataPercentageNumericUpDown.Size = new System.Drawing.Size(111, 20);
            this.testingDataPercentageNumericUpDown.TabIndex = 8;
            this.testingDataPercentageNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.testingDataPercentageNumericUpDown.ValueChanged += new System.EventHandler(this.testingDataPercentageNumericUpDown_ValueChanged);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(196, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Тестирующих данных в исходных (%):";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // learnNetworkButton
            // 
            this.learnNetworkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.learnNetworkButton.Location = new System.Drawing.Point(218, 187);
            this.learnNetworkButton.Name = "learnNetworkButton";
            this.learnNetworkButton.Size = new System.Drawing.Size(111, 23);
            this.learnNetworkButton.TabIndex = 0;
            this.learnNetworkButton.Text = "Обучить сеть";
            this.learnNetworkButton.UseVisualStyleBackColor = true;
            this.learnNetworkButton.Click += new System.EventHandler(this.learnNetworkButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Структура сети";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Controls.Add(this.numHiddenCheckBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.numInputNumericUpDown, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.numHiddenNumericUpDown, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.numOutputNumericUpDown, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.hiddenFunctionComboBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.outputFunctionComboBox, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.createNetworkButton, 1, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66944F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(332, 173);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // numHiddenCheckBox
            // 
            this.numHiddenCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numHiddenCheckBox.AutoSize = true;
            this.numHiddenCheckBox.Checked = true;
            this.numHiddenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.numHiddenCheckBox.Location = new System.Drawing.Point(16, 33);
            this.numHiddenCheckBox.Name = "numHiddenCheckBox";
            this.numHiddenCheckBox.Size = new System.Drawing.Size(196, 17);
            this.numHiddenCheckBox.TabIndex = 1;
            this.numHiddenCheckBox.Text = "Число нейронов в скрытом слое:";
            this.numHiddenCheckBox.UseVisualStyleBackColor = true;
            this.numHiddenCheckBox.CheckedChanged += new System.EventHandler(this.numHiddenCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Число входов:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 63);
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
            this.label4.Location = new System.Drawing.Point(22, 91);
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
            this.label5.Location = new System.Drawing.Point(16, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Функция активации выходного слоя:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numInputNumericUpDown
            // 
            this.numInputNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numInputNumericUpDown.Location = new System.Drawing.Point(218, 4);
            this.numInputNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInputNumericUpDown.Name = "numInputNumericUpDown";
            this.numInputNumericUpDown.Size = new System.Drawing.Size(111, 20);
            this.numInputNumericUpDown.TabIndex = 0;
            this.numInputNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numInputNumericUpDown.ValueChanged += new System.EventHandler(this.numInputNumericUpDown_ValueChanged);
            // 
            // numHiddenNumericUpDown
            // 
            this.numHiddenNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numHiddenNumericUpDown.Location = new System.Drawing.Point(218, 32);
            this.numHiddenNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHiddenNumericUpDown.Name = "numHiddenNumericUpDown";
            this.numHiddenNumericUpDown.Size = new System.Drawing.Size(111, 20);
            this.numHiddenNumericUpDown.TabIndex = 1;
            this.numHiddenNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numHiddenNumericUpDown.ValueChanged += new System.EventHandler(this.numHiddenNumericUpDown_ValueChanged);
            // 
            // numOutputNumericUpDown
            // 
            this.numOutputNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numOutputNumericUpDown.Location = new System.Drawing.Point(218, 60);
            this.numOutputNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOutputNumericUpDown.Name = "numOutputNumericUpDown";
            this.numOutputNumericUpDown.Size = new System.Drawing.Size(111, 20);
            this.numOutputNumericUpDown.TabIndex = 2;
            this.numOutputNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOutputNumericUpDown.ValueChanged += new System.EventHandler(this.numOutputNumericUpDown_ValueChanged);
            // 
            // hiddenFunctionComboBox
            // 
            this.hiddenFunctionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hiddenFunctionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hiddenFunctionComboBox.FormattingEnabled = true;
            this.hiddenFunctionComboBox.Items.AddRange(new object[] {
            "Логистическая",
            "Гипертангенс",
            "Синус",
            "Линейная"});
            this.hiddenFunctionComboBox.Location = new System.Drawing.Point(218, 87);
            this.hiddenFunctionComboBox.Name = "hiddenFunctionComboBox";
            this.hiddenFunctionComboBox.Size = new System.Drawing.Size(111, 21);
            this.hiddenFunctionComboBox.TabIndex = 3;
            this.hiddenFunctionComboBox.SelectedIndexChanged += new System.EventHandler(this.hiddenFunctionComboBox_SelectedIndexChanged);
            // 
            // outputFunctionComboBox
            // 
            this.outputFunctionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFunctionComboBox.DisplayMember = "Value";
            this.outputFunctionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputFunctionComboBox.FormattingEnabled = true;
            this.outputFunctionComboBox.Items.AddRange(new object[] {
            "Логистическая",
            "Гипертангенс",
            "Синус",
            "Линейная"});
            this.outputFunctionComboBox.Location = new System.Drawing.Point(218, 115);
            this.outputFunctionComboBox.Name = "outputFunctionComboBox";
            this.outputFunctionComboBox.Size = new System.Drawing.Size(111, 21);
            this.outputFunctionComboBox.TabIndex = 4;
            this.outputFunctionComboBox.ValueMember = "Key";
            this.outputFunctionComboBox.SelectedIndexChanged += new System.EventHandler(this.outputFunctionComboBox_SelectedIndexChanged);
            // 
            // createNetworkButton
            // 
            this.createNetworkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createNetworkButton.Location = new System.Drawing.Point(218, 145);
            this.createNetworkButton.Name = "createNetworkButton";
            this.createNetworkButton.Size = new System.Drawing.Size(111, 23);
            this.createNetworkButton.TabIndex = 6;
            this.createNetworkButton.Text = "Создать сеть";
            this.createNetworkButton.UseVisualStyleBackColor = true;
            this.createNetworkButton.Click += new System.EventHandler(this.createNetworkButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 279);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 234);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Обучение сети";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel12.Controls.Add(this.learnNetworkButton, 1, 7);
            this.tableLayoutPanel12.Controls.Add(this.resilientPropagationRadioButton, 0, 6);
            this.tableLayoutPanel12.Controls.Add(this.learningDataPercentageNumericUpDown, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.label10, 0, 5);
            this.tableLayoutPanel12.Controls.Add(this.momentumNumericUpDown, 1, 5);
            this.tableLayoutPanel12.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.learningRateNumericUpDown, 1, 4);
            this.tableLayoutPanel12.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel12.Controls.Add(this.backPropagationRadioButton, 0, 3);
            this.tableLayoutPanel12.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.maxNumEpochNumericUpDown, 1, 2);
            this.tableLayoutPanel12.Controls.Add(this.maxLearningRmsNumericUpDown, 1, 1);
            this.tableLayoutPanel12.Controls.Add(this.label18, 0, 1);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 8;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49917F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49917F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49917F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49917F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50167F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50328F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(332, 215);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // resilientPropagationRadioButton
            // 
            this.resilientPropagationRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.resilientPropagationRadioButton.AutoSize = true;
            this.resilientPropagationRadioButton.Location = new System.Drawing.Point(3, 160);
            this.resilientPropagationRadioButton.Name = "resilientPropagationRadioButton";
            this.resilientPropagationRadioButton.Size = new System.Drawing.Size(115, 17);
            this.resilientPropagationRadioButton.TabIndex = 14;
            this.resilientPropagationRadioButton.Text = "Алгоритм RPROP";
            this.resilientPropagationRadioButton.UseVisualStyleBackColor = true;
            // 
            // learningDataPercentageNumericUpDown
            // 
            this.learningDataPercentageNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.learningDataPercentageNumericUpDown.DecimalPlaces = 2;
            this.learningDataPercentageNumericUpDown.Location = new System.Drawing.Point(218, 3);
            this.learningDataPercentageNumericUpDown.Name = "learningDataPercentageNumericUpDown";
            this.learningDataPercentageNumericUpDown.Size = new System.Drawing.Size(111, 20);
            this.learningDataPercentageNumericUpDown.TabIndex = 7;
            this.learningDataPercentageNumericUpDown.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.learningDataPercentageNumericUpDown.ValueChanged += new System.EventHandler(this.learningDataPercentageNumericUpDown_ValueChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(162, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Момент:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.momentumNumericUpDown.Location = new System.Drawing.Point(218, 133);
            this.momentumNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.momentumNumericUpDown.Name = "momentumNumericUpDown";
            this.momentumNumericUpDown.Size = new System.Drawing.Size(111, 20);
            this.momentumNumericUpDown.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(185, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Обучающих данных в исходных (%):";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.learningRateNumericUpDown.Location = new System.Drawing.Point(218, 107);
            this.learningRateNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.learningRateNumericUpDown.Name = "learningRateNumericUpDown";
            this.learningRateNumericUpDown.Size = new System.Drawing.Size(111, 20);
            this.learningRateNumericUpDown.TabIndex = 12;
            this.learningRateNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(83, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Коэффициент обучения:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // backPropagationRadioButton
            // 
            this.backPropagationRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.backPropagationRadioButton.AutoSize = true;
            this.backPropagationRadioButton.Checked = true;
            this.backPropagationRadioButton.Location = new System.Drawing.Point(3, 82);
            this.backPropagationRadioButton.Name = "backPropagationRadioButton";
            this.backPropagationRadioButton.Size = new System.Drawing.Size(194, 17);
            this.backPropagationRadioButton.TabIndex = 11;
            this.backPropagationRadioButton.TabStop = true;
            this.backPropagationRadioButton.Text = "Алгоритм наискорейшего спуска";
            this.backPropagationRadioButton.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(194, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Максимальное число эпох обучения:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maxNumEpochNumericUpDown
            // 
            this.maxNumEpochNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maxNumEpochNumericUpDown.Location = new System.Drawing.Point(218, 55);
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
            this.maxNumEpochNumericUpDown.Size = new System.Drawing.Size(111, 20);
            this.maxNumEpochNumericUpDown.TabIndex = 10;
            this.maxNumEpochNumericUpDown.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
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
            this.maxLearningRmsNumericUpDown.Location = new System.Drawing.Point(218, 29);
            this.maxLearningRmsNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxLearningRmsNumericUpDown.Name = "maxLearningRmsNumericUpDown";
            this.maxLearningRmsNumericUpDown.Size = new System.Drawing.Size(111, 20);
            this.maxLearningRmsNumericUpDown.TabIndex = 9;
            this.maxLearningRmsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(202, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Максимальное СКО ошибки обучения:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 72);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Исходные данные";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.dataFilePathTextBox, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.browseDataFileButton, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(332, 53);
            this.tableLayoutPanel5.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(55, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Файл с исходными данными:";
            // 
            // dataFilePathTextBox
            // 
            this.dataFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.dataFilePathTextBox, 2);
            this.dataFilePathTextBox.Location = new System.Drawing.Point(3, 29);
            this.dataFilePathTextBox.Name = "dataFilePathTextBox";
            this.dataFilePathTextBox.Size = new System.Drawing.Size(326, 20);
            this.dataFilePathTextBox.TabIndex = 6;
            this.dataFilePathTextBox.TextChanged += new System.EventHandler(this.dataFilePathTextBox_TextChanged);
            // 
            // browseDataFileButton
            // 
            this.browseDataFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.browseDataFileButton.Location = new System.Drawing.Point(218, 3);
            this.browseDataFileButton.Name = "browseDataFileButton";
            this.browseDataFileButton.Size = new System.Drawing.Size(111, 20);
            this.browseDataFileButton.TabIndex = 5;
            this.browseDataFileButton.Text = "Обзор...";
            this.browseDataFileButton.UseVisualStyleBackColor = true;
            this.browseDataFileButton.Click += new System.EventHandler(this.browseDataFileButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.работаСДаннымиToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // работаСДаннымиToolStripMenuItem
            // 
            this.работаСДаннымиToolStripMenuItem.Name = "работаСДаннымиToolStripMenuItem";
            this.работаСДаннымиToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.работаСДаннымиToolStripMenuItem.Text = "Работа с данными";
            this.работаСДаннымиToolStripMenuItem.Click += new System.EventHandler(this.работаСДаннымиToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.руководствоПользователяToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // руководствоПользователяToolStripMenuItem
            // 
            this.руководствоПользователяToolStripMenuItem.Name = "руководствоПользователяToolStripMenuItem";
            this.руководствоПользователяToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.руководствоПользователяToolStripMenuItem.Text = "Руководство пользователя";
            this.руководствоПользователяToolStripMenuItem.Click += new System.EventHandler(this.руководствоПользователяToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 631);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1024, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
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
            this.learningRmsGraphControl.Size = new System.Drawing.Size(647, 544);
            this.learningRmsGraphControl.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tabControl1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(353, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(667, 595);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Графики";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.predictionResultTabPage);
            this.tabControl1.Controls.Add(this.learningRmsTabPage);
            this.tabControl1.Controls.Add(this.testingRmsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 576);
            this.tabControl1.TabIndex = 17;
            // 
            // predictionResultTabPage
            // 
            this.predictionResultTabPage.Controls.Add(this.resultGraphControl);
            this.predictionResultTabPage.Location = new System.Drawing.Point(4, 22);
            this.predictionResultTabPage.Name = "predictionResultTabPage";
            this.predictionResultTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.predictionResultTabPage.Size = new System.Drawing.Size(653, 550);
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
            this.resultGraphControl.Size = new System.Drawing.Size(647, 544);
            this.resultGraphControl.TabIndex = 0;
            // 
            // learningRmsTabPage
            // 
            this.learningRmsTabPage.Controls.Add(this.learningRmsGraphControl);
            this.learningRmsTabPage.Location = new System.Drawing.Point(4, 22);
            this.learningRmsTabPage.Name = "learningRmsTabPage";
            this.learningRmsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.learningRmsTabPage.Size = new System.Drawing.Size(653, 550);
            this.learningRmsTabPage.TabIndex = 3;
            this.learningRmsTabPage.Text = "СКО ошибки обучения";
            this.learningRmsTabPage.UseVisualStyleBackColor = true;
            // 
            // testingRmsTabPage
            // 
            this.testingRmsTabPage.Controls.Add(this.testingRmsGraphControl);
            this.testingRmsTabPage.Location = new System.Drawing.Point(4, 22);
            this.testingRmsTabPage.Name = "testingRmsTabPage";
            this.testingRmsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.testingRmsTabPage.Size = new System.Drawing.Size(653, 550);
            this.testingRmsTabPage.TabIndex = 2;
            this.testingRmsTabPage.Text = "СКО ошибки тестирования";
            this.testingRmsTabPage.UseVisualStyleBackColor = true;
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
            this.testingRmsGraphControl.Size = new System.Drawing.Size(647, 544);
            this.testingRmsGraphControl.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1023, 601);
            this.tableLayoutPanel9.TabIndex = 5;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.groupBox5, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 4;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.35248F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.10951F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.42849F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.10951F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(344, 595);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 519);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(338, 73);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Тестирование сети";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.testNetworkButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.testingDataPercentageNumericUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 54);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 653);
            this.Controls.Add(this.tableLayoutPanel9);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автоматизированная система прогнозирования многослойным персептроном";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.testingDataPercentageNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHiddenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.learningDataPercentageNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.momentumNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumEpochNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxLearningRmsNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.predictionResultTabPage.ResumeLayout(false);
            this.learningRmsTabPage.ResumeLayout(false);
            this.testingRmsTabPage.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.NumericUpDown learningDataPercentageNumericUpDown;
        private System.Windows.Forms.NumericUpDown maxLearningRmsNumericUpDown;
        private System.Windows.Forms.NumericUpDown learningRateNumericUpDown;
        private System.Windows.Forms.NumericUpDown momentumNumericUpDown;
        private System.Windows.Forms.Button testNetworkButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox dataFilePathTextBox;
        private System.Windows.Forms.Button browseDataFileButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководствоПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown testingDataPercentageNumericUpDown;
        private ZedGraph.ZedGraphControl learningRmsGraphControl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage testingRmsTabPage;
        private ZedGraph.ZedGraphControl testingRmsGraphControl;
        private System.Windows.Forms.TabPage predictionResultTabPage;
        private ZedGraph.ZedGraphControl resultGraphControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TabPage learningRmsTabPage;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.CheckBox numHiddenCheckBox;
        private System.Windows.Forms.ToolStripMenuItem работаСДаннымиToolStripMenuItem;
        private System.Windows.Forms.Button createNetworkButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

