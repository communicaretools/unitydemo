using System;
using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace Neighbourhood.Editor.Tests.Stubs
{
	public class AnimatorStub : IAnimator
	{
		readonly IDictionary<Type, IDictionary<string, object>> items;

		public AnimatorStub()
		{
			items = new Dictionary<Type, IDictionary<string, object>>();
			items[typeof(bool)] = new Dictionary<string, object>();
			items[typeof(float)] = new Dictionary<string, object>();
		}

		public T GetSetting<T>(string key)
		{
			Assert.That(items.ContainsKey(typeof(T)),
				"You cannot ask the AnimatorStub to return a(n) {0}, only [{1}] supported",
				typeof(T).Name, string.Join(", ", items.Keys.Select(k => k.Name).ToArray()));
			Assert.That(items[typeof(T)].ContainsKey(key),
				"Expected the animation property `{0}' ({1}) to have been set; these {1} keys were set: [{2}]",
				key,
				typeof(T).Name,
				string.Join(", ", items[typeof(T)].Select(kvp => string.Format("{0}: {1}", kvp.Key, kvp.Value)).ToArray()));

			return (T)items[typeof(T)][key];
		}

		#region IAnimator implementation

		public void SetBool(string key, bool value)
		{
			items[typeof(bool)][key] = value;
		}

		#endregion
	}
}

