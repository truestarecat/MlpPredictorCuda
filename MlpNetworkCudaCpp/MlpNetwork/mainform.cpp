#include "stdafx.h"
#include "mainform.h"

namespace mlp_network
{
	[STAThread]
	void Main(array<String ^> ^args)
	{
		Application::EnableVisualStyles();
		Application::SetCompatibleTextRenderingDefault(false);
		Application::Run(gcnew MainForm());
	}
}