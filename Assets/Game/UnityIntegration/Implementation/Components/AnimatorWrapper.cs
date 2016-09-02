using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using UnityEngine;

namespace Neighbourhood.Game.UnityIntegration.Implementation.Components
{
	public class AnimatorWrapper : IAnimator
	{
		readonly Animator wrapped;

		public AnimatorWrapper(Animator wrapped)
		{
			this.wrapped = wrapped;
		}

		#region IAnimator implementation

		public void SetBool(string key, bool value)
		{
			wrapped.SetBool(key, value);
		}

		#endregion
	}
}

