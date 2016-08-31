using System;
using System.Reflection;
using Zenject;
using NUnit.Framework;

namespace Neighbourhood.Editor.Tests.TestExtensions
{
	public static class SignalTestingExtensions
	{
		public static void SimulateTrigger<TSignal>(this TSignal signal, params object[] args) where TSignal : ISignal
		{
			// Create a trigger for this signal
			var triggerClass = typeof(TSignal).GetNestedType("Trigger");
			Assert.That(triggerClass, Is.Not.Null, "You cannot simulate triggers on a signal unless its trigger subclass is named Trigger");
			var trigger = Activator.CreateInstance(triggerClass);
			// Wire the given signal to the newly created trigger
			var triggerSignalField = triggerClass.BaseType.GetField("_signal", BindingFlags.NonPublic | BindingFlags.Instance);
			triggerSignalField.SetValue(trigger, signal);
			// Fire trigger
			var method = triggerClass.GetMethod("Fire");
			method.Invoke(trigger, args);
		}
	}
}

