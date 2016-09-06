using System;
using Neighbourhood.Game.UnityIntegration.Implementation;
using UnityEngine;

namespace Neighbourhood.Game.Indoors.Visitables
{
	public class VisitableItemBehaviour : BaseBehaviour, IVisitableItem
	{
		[SerializeField]
		VisitableItemSettings settings = new VisitableItemSettings();

		#region IVisitableItem implementation
		public string Name { get { return settings.Name; } }
		#endregion

		[Serializable]
		class VisitableItemSettings
		{
			public string Name;
		}
	}
}

