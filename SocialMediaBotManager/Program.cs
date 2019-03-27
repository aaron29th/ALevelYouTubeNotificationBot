using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialMediaBotManager.Forms;
using SocialMediaBotManager.Models;

namespace SocialMediaBotManager
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Network.Init();
			Application.Run(new LoginWindow());
		}
	}
}
