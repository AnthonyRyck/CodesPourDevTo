using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoRenderFragement.ViewModels
{
	public interface IReceiverViewModel
	{
		int Counter { get; set; }

		void Click();
	}
}
