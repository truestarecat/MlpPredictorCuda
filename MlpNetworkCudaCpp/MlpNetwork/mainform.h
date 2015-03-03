#pragma once

#include "mlpnetwork.h"
#include "networkprediction.h"
#include "matrixhelper.h"
#include "networkdataset.h"
#include "cudapropagation.h"

namespace mlp_network
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Collections::Generic;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace ZedGraph;

	/// <summary>
	/// Сводка для MainForm
	/// </summary>
	public ref class MainForm : public System::Windows::Forms::Form
	{
	public:
		MainForm(void)
		{
			InitializeComponent();

			hiddenFunctionComboBox->SelectedIndex = 0; // Логистическая функция (униполярная сигмоида)
			outputFunctionComboBox->SelectedIndex = 0;
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~MainForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::GroupBox^  groupBox1;
	protected:
	private: System::Windows::Forms::GroupBox^  groupBox2;
	private: System::Windows::Forms::GroupBox^  groupBox3;
	private: System::Windows::Forms::GroupBox^  groupBox4;
	private: System::Windows::Forms::Button^  learnButton;
	private: System::Windows::Forms::TabControl^  tabControl1;
	private: System::Windows::Forms::TabPage^  tabPage1;
	private: System::Windows::Forms::TabPage^  tabPage2;
	private: ZedGraph::ZedGraphControl^  resultGraph;
	private: ZedGraph::ZedGraphControl^  errorGraph;

	private: System::Windows::Forms::TableLayoutPanel^  tableLayoutPanel1;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::NumericUpDown^  numInputNumericUpDown;
	private: System::Windows::Forms::NumericUpDown^  numOutputNumericUpDown;

	private: System::Windows::Forms::NumericUpDown^  numHiddenNumericUpDown;

	private: System::Windows::Forms::Label^  label5;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::ComboBox^  hiddenFunctionComboBox;
	private: System::Windows::Forms::ComboBox^  outputFunctionComboBox;

	private: System::Windows::Forms::TableLayoutPanel^  tableLayoutPanel2;
	private: System::Windows::Forms::Label^  label7;
	private: System::Windows::Forms::Label^  label8;
	private: System::Windows::Forms::Label^  label6;
	private: System::Windows::Forms::TableLayoutPanel^  tableLayoutPanel3;
	private: System::Windows::Forms::Label^  numEpochLabel;

	private: System::Windows::Forms::Label^  label9;
	private: System::Windows::Forms::NumericUpDown^  maxNumIterationNumericUpDown;

	private: System::Windows::Forms::TextBox^  divideFactorTextBox;
	private: System::Windows::Forms::TextBox^  maxLearningRmsTextBox;

	private: System::Windows::Forms::Label^  label10;
	private: System::Windows::Forms::Label^  learningRmsLabel;

	private: System::Windows::Forms::Label^  label11;
	private: System::Windows::Forms::Label^  label12;
	private: System::Windows::Forms::TextBox^  learningRateTextBox;
	private: System::Windows::Forms::TextBox^  momentumTextBox;

	private: System::Windows::Forms::Label^  label13;
	private: System::Windows::Forms::Label^  testingRmsLabel;
	private: System::Windows::Forms::RadioButton^  backPropagationRadioButton;
	private: System::Windows::Forms::RadioButton^  resilientPropagationRadioButton;

	private: System::ComponentModel::IContainer^  components;

	private:
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		float divideFactor_;
		float maxLearningRms_;
		int numInput_;
		int numHidden_;
		int numOutput_;
		int maxNumEpoch_;
		float learningRate_;
		float momentum_;
		int hiddenFunctionIndex_;
		int outputsFunctionIndex_;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->tableLayoutPanel1 = (gcnew System::Windows::Forms::TableLayoutPanel());
			this->outputFunctionComboBox = (gcnew System::Windows::Forms::ComboBox());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->numOutputNumericUpDown = (gcnew System::Windows::Forms::NumericUpDown());
			this->numHiddenNumericUpDown = (gcnew System::Windows::Forms::NumericUpDown());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->numInputNumericUpDown = (gcnew System::Windows::Forms::NumericUpDown());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->hiddenFunctionComboBox = (gcnew System::Windows::Forms::ComboBox());
			this->groupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->tableLayoutPanel2 = (gcnew System::Windows::Forms::TableLayoutPanel());
			this->label7 = (gcnew System::Windows::Forms::Label());
			this->label8 = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->maxNumIterationNumericUpDown = (gcnew System::Windows::Forms::NumericUpDown());
			this->divideFactorTextBox = (gcnew System::Windows::Forms::TextBox());
			this->maxLearningRmsTextBox = (gcnew System::Windows::Forms::TextBox());
			this->label11 = (gcnew System::Windows::Forms::Label());
			this->label12 = (gcnew System::Windows::Forms::Label());
			this->learningRateTextBox = (gcnew System::Windows::Forms::TextBox());
			this->momentumTextBox = (gcnew System::Windows::Forms::TextBox());
			this->backPropagationRadioButton = (gcnew System::Windows::Forms::RadioButton());
			this->resilientPropagationRadioButton = (gcnew System::Windows::Forms::RadioButton());
			this->groupBox3 = (gcnew System::Windows::Forms::GroupBox());
			this->tableLayoutPanel3 = (gcnew System::Windows::Forms::TableLayoutPanel());
			this->label9 = (gcnew System::Windows::Forms::Label());
			this->numEpochLabel = (gcnew System::Windows::Forms::Label());
			this->label10 = (gcnew System::Windows::Forms::Label());
			this->learningRmsLabel = (gcnew System::Windows::Forms::Label());
			this->label13 = (gcnew System::Windows::Forms::Label());
			this->testingRmsLabel = (gcnew System::Windows::Forms::Label());
			this->groupBox4 = (gcnew System::Windows::Forms::GroupBox());
			this->tabControl1 = (gcnew System::Windows::Forms::TabControl());
			this->tabPage1 = (gcnew System::Windows::Forms::TabPage());
			this->resultGraph = (gcnew ZedGraph::ZedGraphControl());
			this->tabPage2 = (gcnew System::Windows::Forms::TabPage());
			this->errorGraph = (gcnew ZedGraph::ZedGraphControl());
			this->learnButton = (gcnew System::Windows::Forms::Button());
			this->groupBox1->SuspendLayout();
			this->tableLayoutPanel1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->numOutputNumericUpDown))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->numHiddenNumericUpDown))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->numInputNumericUpDown))->BeginInit();
			this->groupBox2->SuspendLayout();
			this->tableLayoutPanel2->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->maxNumIterationNumericUpDown))->BeginInit();
			this->groupBox3->SuspendLayout();
			this->tableLayoutPanel3->SuspendLayout();
			this->groupBox4->SuspendLayout();
			this->tabControl1->SuspendLayout();
			this->tabPage1->SuspendLayout();
			this->tabPage2->SuspendLayout();
			this->SuspendLayout();
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->tableLayoutPanel1);
			this->groupBox1->Location = System::Drawing::Point(13, 13);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(348, 151);
			this->groupBox1->TabIndex = 0;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Структура сети";
			// 
			// tableLayoutPanel1
			// 
			this->tableLayoutPanel1->ColumnCount = 2;
			this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				60)));
			this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				40)));
			this->tableLayoutPanel1->Controls->Add(this->outputFunctionComboBox, 1, 4);
			this->tableLayoutPanel1->Controls->Add(this->label5, 0, 4);
			this->tableLayoutPanel1->Controls->Add(this->numOutputNumericUpDown, 1, 2);
			this->tableLayoutPanel1->Controls->Add(this->numHiddenNumericUpDown, 1, 1);
			this->tableLayoutPanel1->Controls->Add(this->label1, 0, 0);
			this->tableLayoutPanel1->Controls->Add(this->label2, 0, 1);
			this->tableLayoutPanel1->Controls->Add(this->label3, 0, 2);
			this->tableLayoutPanel1->Controls->Add(this->numInputNumericUpDown, 1, 0);
			this->tableLayoutPanel1->Controls->Add(this->label4, 0, 3);
			this->tableLayoutPanel1->Controls->Add(this->hiddenFunctionComboBox, 1, 3);
			this->tableLayoutPanel1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->tableLayoutPanel1->Location = System::Drawing::Point(3, 16);
			this->tableLayoutPanel1->Name = L"tableLayoutPanel1";
			this->tableLayoutPanel1->RowCount = 5;
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 20.0008F)));
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 20.0008F)));
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 20.0008F)));
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 19.9988F)));
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 19.9988F)));
			this->tableLayoutPanel1->Size = System::Drawing::Size(342, 132);
			this->tableLayoutPanel1->TabIndex = 0;
			// 
			// outputFunctionComboBox
			// 
			this->outputFunctionComboBox->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->outputFunctionComboBox->FormattingEnabled = true;
			this->outputFunctionComboBox->Items->AddRange(gcnew cli::array< System::Object^  >(4) {
				L"Логистическая", L"Гипертангенс",
					L"Синус", L"Линейная"
			});
			this->outputFunctionComboBox->Location = System::Drawing::Point(208, 107);
			this->outputFunctionComboBox->Name = L"outputFunctionComboBox";
			this->outputFunctionComboBox->Size = System::Drawing::Size(120, 21);
			this->outputFunctionComboBox->TabIndex = 9;
			// 
			// label5
			// 
			this->label5->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label5->Location = System::Drawing::Point(3, 104);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(199, 28);
			this->label5->TabIndex = 7;
			this->label5->Text = L"Функция активации выходного слоя:";
			this->label5->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// numOutputNumericUpDown
			// 
			this->numOutputNumericUpDown->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->numOutputNumericUpDown->Location = System::Drawing::Point(208, 55);
			this->numOutputNumericUpDown->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 0 });
			this->numOutputNumericUpDown->Name = L"numOutputNumericUpDown";
			this->numOutputNumericUpDown->Size = System::Drawing::Size(120, 20);
			this->numOutputNumericUpDown->TabIndex = 5;
			this->numOutputNumericUpDown->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 0 });
			// 
			// numHiddenNumericUpDown
			// 
			this->numHiddenNumericUpDown->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->numHiddenNumericUpDown->Location = System::Drawing::Point(208, 29);
			this->numHiddenNumericUpDown->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 0 });
			this->numHiddenNumericUpDown->Name = L"numHiddenNumericUpDown";
			this->numHiddenNumericUpDown->Size = System::Drawing::Size(120, 20);
			this->numHiddenNumericUpDown->TabIndex = 4;
			this->numHiddenNumericUpDown->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) { 15, 0, 0, 0 });
			// 
			// label1
			// 
			this->label1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label1->Location = System::Drawing::Point(3, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(199, 26);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Число входов:";
			this->label1->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// label2
			// 
			this->label2->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label2->Location = System::Drawing::Point(3, 26);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(199, 26);
			this->label2->TabIndex = 1;
			this->label2->Text = L"Число скрытых нейронов:";
			this->label2->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// label3
			// 
			this->label3->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label3->Location = System::Drawing::Point(3, 52);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(199, 26);
			this->label3->TabIndex = 2;
			this->label3->Text = L"Число выходов:";
			this->label3->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// numInputNumericUpDown
			// 
			this->numInputNumericUpDown->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->numInputNumericUpDown->Location = System::Drawing::Point(208, 3);
			this->numInputNumericUpDown->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 0 });
			this->numInputNumericUpDown->Name = L"numInputNumericUpDown";
			this->numInputNumericUpDown->Size = System::Drawing::Size(120, 20);
			this->numInputNumericUpDown->TabIndex = 3;
			this->numInputNumericUpDown->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) { 30, 0, 0, 0 });
			// 
			// label4
			// 
			this->label4->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label4->Location = System::Drawing::Point(3, 78);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(199, 26);
			this->label4->TabIndex = 6;
			this->label4->Text = L"Функция активации скрытого слоя:";
			this->label4->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// hiddenFunctionComboBox
			// 
			this->hiddenFunctionComboBox->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->hiddenFunctionComboBox->FormattingEnabled = true;
			this->hiddenFunctionComboBox->Items->AddRange(gcnew cli::array< System::Object^  >(4) {
				L"Логистическая", L"Гипертангенс",
					L"Синус", L"Линейная"
			});
			this->hiddenFunctionComboBox->Location = System::Drawing::Point(208, 81);
			this->hiddenFunctionComboBox->Name = L"hiddenFunctionComboBox";
			this->hiddenFunctionComboBox->Size = System::Drawing::Size(120, 21);
			this->hiddenFunctionComboBox->TabIndex = 8;
			// 
			// groupBox2
			// 
			this->groupBox2->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left));
			this->groupBox2->Controls->Add(this->tableLayoutPanel2);
			this->groupBox2->Location = System::Drawing::Point(13, 170);
			this->groupBox2->Name = L"groupBox2";
			this->groupBox2->Size = System::Drawing::Size(348, 230);
			this->groupBox2->TabIndex = 1;
			this->groupBox2->TabStop = false;
			this->groupBox2->Text = L"Параметры обучения";
			// 
			// tableLayoutPanel2
			// 
			this->tableLayoutPanel2->ColumnCount = 2;
			this->tableLayoutPanel2->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				60)));
			this->tableLayoutPanel2->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				40)));
			this->tableLayoutPanel2->Controls->Add(this->label7, 0, 0);
			this->tableLayoutPanel2->Controls->Add(this->label8, 0, 1);
			this->tableLayoutPanel2->Controls->Add(this->label6, 0, 2);
			this->tableLayoutPanel2->Controls->Add(this->maxNumIterationNumericUpDown, 1, 2);
			this->tableLayoutPanel2->Controls->Add(this->divideFactorTextBox, 1, 0);
			this->tableLayoutPanel2->Controls->Add(this->maxLearningRmsTextBox, 1, 1);
			this->tableLayoutPanel2->Controls->Add(this->label11, 0, 4);
			this->tableLayoutPanel2->Controls->Add(this->label12, 0, 5);
			this->tableLayoutPanel2->Controls->Add(this->learningRateTextBox, 1, 4);
			this->tableLayoutPanel2->Controls->Add(this->momentumTextBox, 1, 5);
			this->tableLayoutPanel2->Controls->Add(this->backPropagationRadioButton, 0, 3);
			this->tableLayoutPanel2->Controls->Add(this->resilientPropagationRadioButton, 0, 6);
			this->tableLayoutPanel2->Dock = System::Windows::Forms::DockStyle::Fill;
			this->tableLayoutPanel2->Location = System::Drawing::Point(3, 16);
			this->tableLayoutPanel2->Name = L"tableLayoutPanel2";
			this->tableLayoutPanel2->RowCount = 7;
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 14.28588F)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 14.28588F)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 14.28588F)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 14.28445F)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 14.28445F)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 14.28531F)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 14.28816F)));
			this->tableLayoutPanel2->Size = System::Drawing::Size(342, 211);
			this->tableLayoutPanel2->TabIndex = 1;
			// 
			// label7
			// 
			this->label7->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label7->Location = System::Drawing::Point(3, 0);
			this->label7->Name = L"label7";
			this->label7->Size = System::Drawing::Size(199, 30);
			this->label7->TabIndex = 0;
			this->label7->Text = L"Соотношение обучающей и тестирующей выборок:";
			this->label7->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// label8
			// 
			this->label8->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label8->Location = System::Drawing::Point(3, 30);
			this->label8->Name = L"label8";
			this->label8->Size = System::Drawing::Size(199, 30);
			this->label8->TabIndex = 1;
			this->label8->Text = L"Максимальное СКО ошибки обучения:";
			this->label8->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// label6
			// 
			this->label6->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label6->Location = System::Drawing::Point(3, 60);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(199, 30);
			this->label6->TabIndex = 2;
			this->label6->Text = L"Максимальное число эпох обучения:";
			this->label6->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// maxNumIterationNumericUpDown
			// 
			this->maxNumIterationNumericUpDown->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->maxNumIterationNumericUpDown->Increment = System::Decimal(gcnew cli::array< System::Int32 >(4) { 100, 0, 0, 0 });
			this->maxNumIterationNumericUpDown->Location = System::Drawing::Point(208, 65);
			this->maxNumIterationNumericUpDown->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1000000, 0, 0, 0 });
			this->maxNumIterationNumericUpDown->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 100, 0, 0, 0 });
			this->maxNumIterationNumericUpDown->Name = L"maxNumIterationNumericUpDown";
			this->maxNumIterationNumericUpDown->Size = System::Drawing::Size(120, 20);
			this->maxNumIterationNumericUpDown->TabIndex = 4;
			this->maxNumIterationNumericUpDown->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) { 10000, 0, 0, 0 });
			// 
			// divideFactorTextBox
			// 
			this->divideFactorTextBox->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->divideFactorTextBox->Location = System::Drawing::Point(208, 5);
			this->divideFactorTextBox->Name = L"divideFactorTextBox";
			this->divideFactorTextBox->Size = System::Drawing::Size(120, 20);
			this->divideFactorTextBox->TabIndex = 5;
			this->divideFactorTextBox->Text = L"0,7";
			// 
			// maxLearningRmsTextBox
			// 
			this->maxLearningRmsTextBox->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->maxLearningRmsTextBox->Location = System::Drawing::Point(208, 35);
			this->maxLearningRmsTextBox->Name = L"maxLearningRmsTextBox";
			this->maxLearningRmsTextBox->Size = System::Drawing::Size(120, 20);
			this->maxLearningRmsTextBox->TabIndex = 6;
			this->maxLearningRmsTextBox->Text = L"0,01";
			// 
			// label11
			// 
			this->label11->AutoSize = true;
			this->label11->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label11->Location = System::Drawing::Point(3, 120);
			this->label11->Name = L"label11";
			this->label11->Size = System::Drawing::Size(199, 30);
			this->label11->TabIndex = 7;
			this->label11->Text = L"Коэффициент обучения:";
			this->label11->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// label12
			// 
			this->label12->AutoSize = true;
			this->label12->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label12->Location = System::Drawing::Point(3, 150);
			this->label12->Name = L"label12";
			this->label12->Size = System::Drawing::Size(199, 30);
			this->label12->TabIndex = 8;
			this->label12->Text = L"Момент:";
			this->label12->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// learningRateTextBox
			// 
			this->learningRateTextBox->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->learningRateTextBox->Location = System::Drawing::Point(208, 125);
			this->learningRateTextBox->Name = L"learningRateTextBox";
			this->learningRateTextBox->Size = System::Drawing::Size(120, 20);
			this->learningRateTextBox->TabIndex = 9;
			this->learningRateTextBox->Text = L"0,05";
			// 
			// momentumTextBox
			// 
			this->momentumTextBox->Anchor = System::Windows::Forms::AnchorStyles::Left;
			this->momentumTextBox->Location = System::Drawing::Point(208, 155);
			this->momentumTextBox->Name = L"momentumTextBox";
			this->momentumTextBox->Size = System::Drawing::Size(120, 20);
			this->momentumTextBox->TabIndex = 10;
			this->momentumTextBox->Text = L"1,0";
			// 
			// backPropagationRadioButton
			// 
			this->backPropagationRadioButton->AutoSize = true;
			this->backPropagationRadioButton->Checked = true;
			this->backPropagationRadioButton->Location = System::Drawing::Point(3, 93);
			this->backPropagationRadioButton->Name = L"backPropagationRadioButton";
			this->backPropagationRadioButton->Size = System::Drawing::Size(197, 17);
			this->backPropagationRadioButton->TabIndex = 11;
			this->backPropagationRadioButton->TabStop = true;
			this->backPropagationRadioButton->Text = L"Алгоритм наискорейшего спуска:";
			this->backPropagationRadioButton->UseVisualStyleBackColor = true;
			// 
			// resilientPropagationRadioButton
			// 
			this->resilientPropagationRadioButton->AutoSize = true;
			this->resilientPropagationRadioButton->Location = System::Drawing::Point(3, 183);
			this->resilientPropagationRadioButton->Name = L"resilientPropagationRadioButton";
			this->resilientPropagationRadioButton->Size = System::Drawing::Size(115, 17);
			this->resilientPropagationRadioButton->TabIndex = 12;
			this->resilientPropagationRadioButton->TabStop = true;
			this->resilientPropagationRadioButton->Text = L"Алгоритм RPROP";
			this->resilientPropagationRadioButton->UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this->groupBox3->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->groupBox3->Controls->Add(this->tableLayoutPanel3);
			this->groupBox3->Location = System::Drawing::Point(13, 435);
			this->groupBox3->Name = L"groupBox3";
			this->groupBox3->Size = System::Drawing::Size(348, 85);
			this->groupBox3->TabIndex = 2;
			this->groupBox3->TabStop = false;
			this->groupBox3->Text = L"Результаты";
			// 
			// tableLayoutPanel3
			// 
			this->tableLayoutPanel3->ColumnCount = 2;
			this->tableLayoutPanel3->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				60)));
			this->tableLayoutPanel3->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
				40)));
			this->tableLayoutPanel3->Controls->Add(this->label9, 0, 0);
			this->tableLayoutPanel3->Controls->Add(this->numEpochLabel, 1, 0);
			this->tableLayoutPanel3->Controls->Add(this->label10, 0, 1);
			this->tableLayoutPanel3->Controls->Add(this->learningRmsLabel, 1, 1);
			this->tableLayoutPanel3->Controls->Add(this->label13, 0, 2);
			this->tableLayoutPanel3->Controls->Add(this->testingRmsLabel, 1, 2);
			this->tableLayoutPanel3->Dock = System::Windows::Forms::DockStyle::Fill;
			this->tableLayoutPanel3->Location = System::Drawing::Point(3, 16);
			this->tableLayoutPanel3->Name = L"tableLayoutPanel3";
			this->tableLayoutPanel3->RowCount = 3;
			this->tableLayoutPanel3->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 33.33333F)));
			this->tableLayoutPanel3->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 33.33334F)));
			this->tableLayoutPanel3->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 33.33334F)));
			this->tableLayoutPanel3->Size = System::Drawing::Size(342, 66);
			this->tableLayoutPanel3->TabIndex = 1;
			// 
			// label9
			// 
			this->label9->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label9->Location = System::Drawing::Point(3, 0);
			this->label9->Name = L"label9";
			this->label9->Size = System::Drawing::Size(199, 21);
			this->label9->TabIndex = 1;
			this->label9->Text = L"Число эпох обучения:";
			this->label9->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// numEpochLabel
			// 
			this->numEpochLabel->Dock = System::Windows::Forms::DockStyle::Fill;
			this->numEpochLabel->Location = System::Drawing::Point(208, 0);
			this->numEpochLabel->Name = L"numEpochLabel";
			this->numEpochLabel->Size = System::Drawing::Size(131, 21);
			this->numEpochLabel->TabIndex = 0;
			this->numEpochLabel->Text = L"0";
			this->numEpochLabel->TextAlign = System::Drawing::ContentAlignment::MiddleLeft;
			// 
			// label10
			// 
			this->label10->AutoSize = true;
			this->label10->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label10->Location = System::Drawing::Point(3, 21);
			this->label10->Name = L"label10";
			this->label10->Size = System::Drawing::Size(199, 22);
			this->label10->TabIndex = 2;
			this->label10->Text = L"СКО ошибки обучения:";
			this->label10->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// learningRmsLabel
			// 
			this->learningRmsLabel->AutoSize = true;
			this->learningRmsLabel->Dock = System::Windows::Forms::DockStyle::Fill;
			this->learningRmsLabel->Location = System::Drawing::Point(208, 21);
			this->learningRmsLabel->Name = L"learningRmsLabel";
			this->learningRmsLabel->Size = System::Drawing::Size(131, 22);
			this->learningRmsLabel->TabIndex = 3;
			this->learningRmsLabel->Text = L"0";
			this->learningRmsLabel->TextAlign = System::Drawing::ContentAlignment::MiddleLeft;
			// 
			// label13
			// 
			this->label13->AutoSize = true;
			this->label13->Dock = System::Windows::Forms::DockStyle::Fill;
			this->label13->Location = System::Drawing::Point(3, 43);
			this->label13->Name = L"label13";
			this->label13->Size = System::Drawing::Size(199, 23);
			this->label13->TabIndex = 4;
			this->label13->Text = L"СКО ошибки тестирования:";
			this->label13->TextAlign = System::Drawing::ContentAlignment::MiddleRight;
			// 
			// testingRmsLabel
			// 
			this->testingRmsLabel->AutoSize = true;
			this->testingRmsLabel->Dock = System::Windows::Forms::DockStyle::Fill;
			this->testingRmsLabel->Location = System::Drawing::Point(208, 43);
			this->testingRmsLabel->Name = L"testingRmsLabel";
			this->testingRmsLabel->Size = System::Drawing::Size(131, 23);
			this->testingRmsLabel->TabIndex = 5;
			this->testingRmsLabel->Text = L"0";
			this->testingRmsLabel->TextAlign = System::Drawing::ContentAlignment::MiddleLeft;
			// 
			// groupBox4
			// 
			this->groupBox4->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->groupBox4->Controls->Add(this->tabControl1);
			this->groupBox4->Location = System::Drawing::Point(367, 13);
			this->groupBox4->Name = L"groupBox4";
			this->groupBox4->Size = System::Drawing::Size(611, 510);
			this->groupBox4->TabIndex = 3;
			this->groupBox4->TabStop = false;
			this->groupBox4->Text = L"Графики";
			// 
			// tabControl1
			// 
			this->tabControl1->Controls->Add(this->tabPage1);
			this->tabControl1->Controls->Add(this->tabPage2);
			this->tabControl1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->tabControl1->Location = System::Drawing::Point(3, 16);
			this->tabControl1->Name = L"tabControl1";
			this->tabControl1->SelectedIndex = 0;
			this->tabControl1->Size = System::Drawing::Size(605, 491);
			this->tabControl1->TabIndex = 0;
			// 
			// tabPage1
			// 
			this->tabPage1->Controls->Add(this->resultGraph);
			this->tabPage1->Location = System::Drawing::Point(4, 22);
			this->tabPage1->Name = L"tabPage1";
			this->tabPage1->Padding = System::Windows::Forms::Padding(3);
			this->tabPage1->Size = System::Drawing::Size(597, 465);
			this->tabPage1->TabIndex = 0;
			this->tabPage1->Text = L"Результат";
			this->tabPage1->UseVisualStyleBackColor = true;
			// 
			// resultGraph
			// 
			this->resultGraph->Dock = System::Windows::Forms::DockStyle::Fill;
			this->resultGraph->Location = System::Drawing::Point(3, 3);
			this->resultGraph->Name = L"resultGraph";
			this->resultGraph->ScrollGrace = 0;
			this->resultGraph->ScrollMaxX = 0;
			this->resultGraph->ScrollMaxY = 0;
			this->resultGraph->ScrollMaxY2 = 0;
			this->resultGraph->ScrollMinX = 0;
			this->resultGraph->ScrollMinY = 0;
			this->resultGraph->ScrollMinY2 = 0;
			this->resultGraph->Size = System::Drawing::Size(591, 459);
			this->resultGraph->TabIndex = 0;
			// 
			// tabPage2
			// 
			this->tabPage2->Controls->Add(this->errorGraph);
			this->tabPage2->Location = System::Drawing::Point(4, 22);
			this->tabPage2->Name = L"tabPage2";
			this->tabPage2->Padding = System::Windows::Forms::Padding(3);
			this->tabPage2->Size = System::Drawing::Size(597, 465);
			this->tabPage2->TabIndex = 1;
			this->tabPage2->Text = L"Ошибка обучения";
			this->tabPage2->UseVisualStyleBackColor = true;
			// 
			// errorGraph
			// 
			this->errorGraph->Dock = System::Windows::Forms::DockStyle::Fill;
			this->errorGraph->Location = System::Drawing::Point(3, 3);
			this->errorGraph->Name = L"errorGraph";
			this->errorGraph->ScrollGrace = 0;
			this->errorGraph->ScrollMaxX = 0;
			this->errorGraph->ScrollMaxY = 0;
			this->errorGraph->ScrollMaxY2 = 0;
			this->errorGraph->ScrollMinX = 0;
			this->errorGraph->ScrollMinY = 0;
			this->errorGraph->ScrollMinY2 = 0;
			this->errorGraph->Size = System::Drawing::Size(591, 459);
			this->errorGraph->TabIndex = 0;
			// 
			// learnButton
			// 
			this->learnButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->learnButton->Location = System::Drawing::Point(114, 406);
			this->learnButton->Name = L"learnButton";
			this->learnButton->Size = System::Drawing::Size(152, 23);
			this->learnButton->TabIndex = 0;
			this->learnButton->Text = L"Обучить";
			this->learnButton->UseVisualStyleBackColor = true;
			this->learnButton->Click += gcnew System::EventHandler(this, &MainForm::learnButton_Click);
			// 
			// MainForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(990, 535);
			this->Controls->Add(this->learnButton);
			this->Controls->Add(this->groupBox4);
			this->Controls->Add(this->groupBox3);
			this->Controls->Add(this->groupBox2);
			this->Controls->Add(this->groupBox1);
			this->Name = L"MainForm";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Многослойный персептрон";
			this->Load += gcnew System::EventHandler(this, &MainForm::MainForm_Load);
			this->groupBox1->ResumeLayout(false);
			this->tableLayoutPanel1->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->numOutputNumericUpDown))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->numHiddenNumericUpDown))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->numInputNumericUpDown))->EndInit();
			this->groupBox2->ResumeLayout(false);
			this->tableLayoutPanel2->ResumeLayout(false);
			this->tableLayoutPanel2->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->maxNumIterationNumericUpDown))->EndInit();
			this->groupBox3->ResumeLayout(false);
			this->tableLayoutPanel3->ResumeLayout(false);
			this->tableLayoutPanel3->PerformLayout();
			this->groupBox4->ResumeLayout(false);
			this->tabControl1->ResumeLayout(false);
			this->tabPage1->ResumeLayout(false);
			this->tabPage2->ResumeLayout(false);
			this->ResumeLayout(false);

		}
#pragma endregion

	private: System::Void MainForm_Load(System::Object^  sender, System::EventArgs^  e)
	{
		array<GraphPane ^> ^panes = { resultGraph->GraphPane, errorGraph->GraphPane };

		const size_t GRAPHS_COUNT = 2;
		for (size_t i = 0; i < GRAPHS_COUNT; ++i)
		{
			panes[i]->CurveList->Clear();
			panes[i]->XAxis->Title->Text = L"";
			panes[i]->YAxis->Title->Text = L"";
			panes[i]->Title->Text = L"";
		}
	}

	private: System::Void learnButton_Click(System::Object^ sender, System::EventArgs^ e)
	{
		try
		{
			SetParams();

			learnButton->Enabled = false;

			//LearnNetwork();
			LearnNetworkCuda();

			learnButton->Enabled = true;
		}
		catch (...)
		{
			learnButton->Enabled = true;
			MessageBox::Show(L"Неверный ввод параметров.", L"Ошибка", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
	}

	private: System::Void SetParams()
	{
		divideFactor_ = Convert::ToSingle(divideFactorTextBox->Text);
		maxLearningRms_ = Convert::ToSingle(maxLearningRmsTextBox->Text);
		numInput_ = Convert::ToUInt32(numInputNumericUpDown->Value);
		numHidden_ = Convert::ToUInt32(numHiddenNumericUpDown->Value);
		numOutput_ = Convert::ToUInt32(numOutputNumericUpDown->Value);
		maxNumEpoch_ = Convert::ToUInt32(maxNumIterationNumericUpDown->Value);
		learningRate_ = Convert::ToSingle(learningRateTextBox->Text);
		momentum_ = Convert::ToSingle(momentumTextBox->Text);

		hiddenFunctionIndex_ = hiddenFunctionComboBox->SelectedIndex;
		outputsFunctionIndex_ = outputFunctionComboBox->SelectedIndex;
	}

	//private: System::Void LearnNetwork()
	//{
	//	//auto hiddenFunctionType = (ActivationFunction::Type) hiddenFunctionIndex_;
	//	//auto outputsFunctionType = (ActivationFunction::Type) outputsFunctionIndex_;

	//	MlpNetwork network(numInput_, numHidden_, numOutput_);

	//	vector<float> rawInputData = NetworkPrediction::loadData("InputData.txt");
	//	NetworkPrediction prediction(rawInputData, numInput_, numOutput_, divideFactor_);
	//	const NetworkDataset &fullDataset = prediction.fullDataset();
	//	const NetworkDataset &learningDataset = prediction.learningDataset();
	//	const NetworkDataset &testingDataset = prediction.testingDataset();

	//	std::unique_ptr<INetworkTraining> training = nullptr;
	//	if (backPropagationRadioButton->Checked)
	//	{
	//		float tempLearningRate = learningRate_;
	//		float tempMomentum = momentum_;
	//		training = std::make_unique<BackPropagation>(network, learningDataset, tempLearningRate, tempMomentum);
	//	}
	//	else if (resilientPropagationRadioButton->Checked)
	//	{
	//		//training = std::make_unique<ResilientPropagation>(network, learningDataset);
	//	}

	//	training->train(maxNumEpoch_, maxLearningRms_);

	//	vector<float> learningErrors = training->learningErrors();

	//	numEpochLabel->Text = Convert::ToString(training->numEpoch());
	//	learningRmsLabel->Text = Convert::ToString(learningErrors.back());

	//	float **predictedOutput = training->test(fullDataset);
	//	const vector<float> predictedOutputVector = MatrixHelper::convert2DArrayToVector(predictedOutput,
	//		fullDataset.numSamples(), fullDataset.numOutput());

	//	for (size_t i = 0; i < fullDataset.numSamples(); ++i)
	//	{
	//		delete [] predictedOutput[i];
	//	}
	//	delete [] predictedOutput;

	//	const vector<float> testingOutputVector = MatrixHelper::convert2DArrayToVector(fullDataset.outputData(),
	//		fullDataset.numSamples(), fullDataset.numOutput());

	//	DrawGraph(resultGraph, gcnew array<String ^> { L"Исходный график", L"Нейронная сеть" },
	//		gcnew array<String ^> { L"Red", L"Blue"}, matrix<float> { testingOutputVector, predictedOutputVector });

	//	DrawGraph(errorGraph, gcnew array<String ^> { L"" }, gcnew array<String ^> { L"Red" }, matrix<float> { learningErrors });
	//}

	private: System::Void LearnNetworkCuda()
	{
		//auto hiddenFunctionType = (ActivationFunction::Type) hiddenFunctionIndex_;
		//auto outputsFunctionType = (ActivationFunction::Type) outputsFunctionIndex_;

		MlpNetwork network(numInput_, numHidden_, numOutput_);

		vector<float> rawInputData = NetworkPrediction::loadData("InputData.txt");
		NetworkPrediction prediction(rawInputData, numInput_, numOutput_, divideFactor_);
		const NetworkDataset &fullDataset = prediction.fullDataset();
		const NetworkDataset &learningDataset = prediction.learningDataset();
		const NetworkDataset &testingDataset = prediction.testingDataset();

		CudaPropagation propagation(network, learningDataset);
		propagation.randomizeNetworkWeights();

		int numEpoch = 0;
		float error = FLT_MAX;
		vector<float> learningErrors;
		float tempLearningRate = learningRate_;
		float tempMomentum = momentum_;
		while (numEpoch < maxNumEpoch_ && error > maxLearningRms_)
		{
			error = propagation.performBackPropEpoch(learningRate_, momentum_);

			learningErrors.push_back(error);

			++numEpoch;
		}

		propagation.updateNetworkWeights();

		numEpochLabel->Text = Convert::ToString(numEpoch);
		learningRmsLabel->Text = Convert::ToString(learningErrors.back());

		matrix<float> predictedOutput = network.computeOutput(fullDataset.inputData());

		const vector<float> predictedOutputVector = MatrixHelper::convertMatrixToVector(predictedOutput);
		const vector<float> testingOutputVector = MatrixHelper::convertMatrixToVector(fullDataset.outputData());

		DrawGraph(resultGraph, gcnew array<String ^> { L"Исходный график", L"Нейронная сеть" },
			gcnew array<String ^> { L"Red", L"Blue"}, matrix<float> { testingOutputVector, predictedOutputVector });

		DrawGraph(errorGraph, gcnew array<String ^> { L"" }, gcnew array<String ^> { L"Red" }, matrix<float> { learningErrors });
	}

	private: System::Void DrawGraph(ZedGraphControl ^graph, array<String ^> ^labels, array<String ^> ^colors,
		const matrix<float> &data)
	{
		GraphPane^ pane = graph->GraphPane;

		pane->CurveList->Clear();

		array<PointPairList ^> ^lists = gcnew array<PointPairList ^>(data.size());
		for (size_t i = 0; i < data.size(); ++i)
		{
			lists[i] = gcnew PointPairList();
			for (size_t j = 0; j < data[i].size(); ++j)
			{
				lists[i]->Add(j, data[i][j]);
			}
		}

		array<LineItem ^> ^myCurves = gcnew array<LineItem ^>(data.size());
		for (size_t i = 0; i < data.size(); ++i)
		{
			myCurves[i] = pane->AddCurve(labels[i], lists[i], Color::FromName(colors[i]), SymbolType::None);
		}

		graph->AxisChange();
		graph->Invalidate();
	}

	private: vector<double> ConvertManagedArrayToUnmanaged(array<double>^ managedArray)
	{
		using System::IntPtr;
		using System::Runtime::InteropServices::Marshal;

		vector<double> unmanagedArray(managedArray->Length);
		Marshal::Copy(managedArray, 0, IntPtr(&unmanagedArray[0]), managedArray->Length);

		return unmanagedArray;
	}

	};
}
