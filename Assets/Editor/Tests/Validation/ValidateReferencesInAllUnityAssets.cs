using NUnit.Framework;
using UnityEngine;
using System;
using System.Text;

namespace Neighbourhood.Editor.Tests.Validation
{
	[TestFixture, Category("Unity")]
	public class ValidateReferencesInAllUnityAssets
	{
		[Test]
		public void CheckAllScenes()
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

			var errors = new StringBuilder();
			MissingReferencesFinder.SearchForMissingSpritesInAllScenes(msg => errors.AppendLine(msg));
			if (errors.Length > 0)
			{
				Assert.Fail(errors.ToString());
			}
		}
	}
}
