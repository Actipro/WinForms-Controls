using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Provides textbox extensions.
	/// </summary>
	public static class TextBoxExtension {

		private const int EM_SETTABSTOPS = 0x00CB;

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr h, int msg, int wParam, int[] lParam);
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Sets the tab width.
		/// </summary>
		/// <param name="textbox">The target <see cref="TextBox"/>.</param>
		/// <param name="width">The width.</param>
		public static void SetTabStopWidth(this TextBox textbox, int width) {
			SendMessage(textbox.Handle, EM_SETTABSTOPS, 1, new int[] { width * 4 });
		}

	}

}
