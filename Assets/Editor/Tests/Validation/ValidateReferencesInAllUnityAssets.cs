using NUnit.Framework;
using UnityEngine;
using System;

namespace Neighbourhood.Editor.Tests.Validation
{
	[TestFixture, Category("Unity")]
	public class ValidateReferencesInAllUnityAssets
	{
		[Test]
		public void CheckAllAssets()
		{
			// It sucks, but otherwise is hard to disable running this test
			// from MonoDevelop
			try
			{
				var test = Application.isEditor;
				Assert.That(test, Is.True);
			}
			catch (MissingMethodException)
			{
				return;
			}

			MissingReferencesFinder.SearchForMissingReferencesInAllAssets(Assert.Fail);
		}
	}
}
