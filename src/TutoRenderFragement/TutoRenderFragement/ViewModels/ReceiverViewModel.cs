﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoRenderFragement.ViewModels
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
