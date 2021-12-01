namespace TutoDynamicComponent.ViewModels
{
	public class ReceiverViewModel : IReceiverViewModel
	{
		public int Counter { get; set; }

		public void Click()
		{
			Counter++;
		}
	}
}
