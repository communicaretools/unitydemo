using System;
using Neighbourhood.Game.UnityIntegration.Abstractions;
using UnityEngine;
using NUnit.Framework;

namespace Neighbourhood.Editor.Tests.Stubs
{
	public class CoordinateUtilityStub : ICoordinateUtility
	{
		public Func<Vector2, Vector3> ScreenToWorldTransform { get; set; }

		#region ICoordinateUtility implementation
		public Vector3 ScreenPointToWorldPoint(Vector2 screenCoordinate)
		{
			Assert.That(ScreenToWorldTransform, Is.Not.Null,
				"In order to use the CoordinateUtilityStub, you need to set the ScreenToWorldTransform property to return your expected value");
			return ScreenToWorldTransform(screenCoordinate);
		}
		#endregion
	}
}

