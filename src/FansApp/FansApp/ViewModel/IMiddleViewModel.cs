using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.ViewModel
{
	public interface IMiddleViewModel
	{
		int NombreIpUnique { get; }

		IEnumerable<string> LesIps { get; }
	}
}
