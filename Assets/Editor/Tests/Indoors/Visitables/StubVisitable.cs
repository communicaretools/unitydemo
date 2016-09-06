using System;
using NUnit.Framework;
using Neighbourhood.Game.Indoors.Visitables;

namespace Neighbourhood.Editor.Tests.Indoors.Visitables
{
	public class StubVisitable : IVisitableItem
	{
		#region IPlayerDestination implementation
		public string Name { get; set; }
		#endregion
	}
}

