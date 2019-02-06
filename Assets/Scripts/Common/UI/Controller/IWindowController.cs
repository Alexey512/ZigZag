using Assets.Scripts.Common.UI.Context;
using UnityEngine;

namespace Assets.Scripts.Common.UI.Controller
{
	public interface IWindowController
	{
		Transform Owner { get; }

		void Initialize(IWindowContext context);
	}
}
