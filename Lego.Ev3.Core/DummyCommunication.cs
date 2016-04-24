using System;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
#if WINRT
using Windows.Foundation;
#endif

namespace Lego.Ev3.Core
{
	/// <summary>
	/// Dummy object for testing.  Does not actually connect or communicate with EV3 brick.
	/// </summary>
	public sealed class DummyCommunication : ICommunication
	{
		/// <summary>
		/// Event fired when a complete report is received from the EV3 brick.  In this dummy implementation, the event is never fired.
		/// </summary>
		public event EventHandler<ReportReceivedEventArgs> ReportReceived
#if WINRT
		;
#else
		{ add {} remove {} }
#endif

	/// <summary>
	/// Test Connect method.
	/// </summary>
	/// <returns></returns>
	public
#if WINRT
	IAsyncAction
#else
	Task
#endif
		ConnectAsync()
		{
			return Task.Run(() => Debug.WriteLine("connected"))
#if WINRT
			.AsAsyncAction()
#endif
			;
		}

		/// <summary>
		/// Test Disconnect method.
		/// </summary>
		public void Disconnect()
		{
		}

		/// <summary>
		/// Test WriteAsync method.  (Writes formatted data to Debug stream).
		/// </summary>
		/// <param name="data">Byte array to be written.</param>
		/// <returns></returns>
		public
#if WINRT
		IAsyncAction
#else
		Task
#endif
		WriteAsync([ReadOnlyArray]byte[] data)
		{
			return Task.Run(() => 
			{
				string s = string.Empty;
				for(int i = 3; i < data.Length; i++)
					s += data[i].ToString("X2") + " ";
                bool contains = s.Contains("00 00 5E 00 99 05 81 00 81 00 E1 00 E1 01 99 1D 81 00 81 00 81 00 81 00 81 01 E1 02 99 1C 81 00 81 00 81 00 81 00 81 01 E1 06 99 1B 81 00 81 00 81 00 81 00 81 01 E1 0A 99 05 81 00 81 01 E1 0B E1 0C 99 1D 81 00 81 01 81 00 81 00 81 01 E1 0D 99 1C 81 00 81 01 81 00 81 00 81 01 E1 11 99 1B 81 00 81 01 81 00 81 00 81 01 E1 15 99 05 81 00 81 02 E1 16 E1 17 99 1D 81 00 81 02 81 00 81 00 81 01 E1 18 99 1C 81 00 81 02 81 00 81 00 81 01 E1 1C 99 1B 81 00 81 02 81 00 81 00 81 01 E1 20 99 05 81 00 81 03 E1 21 E1 22 99 1D 81 00 81 03 81 00 81 00 81 01 E1 23 99 1C 81 00 81 03 81 00 81 00 81 01 E1 27 99 1B 81 00 81 03 81 00 81 00 81 01 E1 2B 99 05 81 00 81 10 E1 2C E1 2D 99 1D 81 00 81 10 81 00 81 00 81 01 E1 2E 99 1C 81 00 81 10 81 00 81 00 81 01 E1 32 99 1B 81 00 81 10 81 00 81 00 81 01 E1 36 99 05 81 00 81 11 E1 37 E1 38 99 1D 81 00 81 11 81 00 81 00 81 01 E1 39 99 1C 81 00 81 11 81 00 81 00 81 01 E1 3D 99 1B 81 00 81 11 81 00 81 00 81 01 E1 41 99 05 81 00 81 12 E1 42 E1 43 99 1D 81 00 81 12 81 00 81 00 81 01 E1");
                if (!contains)
				    Debug.WriteLine("Write: " + s);
			})
#if WINRT
			.AsAsyncAction()
#endif
			;
		}
	}
}
