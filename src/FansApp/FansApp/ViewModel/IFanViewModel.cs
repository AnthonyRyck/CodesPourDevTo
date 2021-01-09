using FansApp.Data;

namespace FansApp.ViewModel
{
	public interface IFanViewModel
	{
		/// <summary>
		/// Fan recherché.
		/// </summary>
		Fan FanSelected { get; set; }

		/// <summary>
		/// ID du fan recherché
		/// </summary>
		int IdFan { get; set; }

		/// <summary>
		/// Charge le Fan donné en ID
		/// </summary>
		/// <param name="id"></param>
		void LoadFan(int id);
	}
}