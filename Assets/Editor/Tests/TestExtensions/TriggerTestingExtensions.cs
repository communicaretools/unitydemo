using System;
using Zenject;
using System.Reflection;

namespace Neighbourhood.Editor.Tests.TestExtensions
{
	public static class TriggerTestingExtensions
	{
		public static void SetupSignalListenerForTesting<TSignal>(this Signal.TriggerBase trigger, Action action) where TSignal : new()
		{
			var signal = new TSignal();
			var field = typeof(Signal.TriggerBase).GetField("_signal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
			field.SetValue(trigger, signal);
			trigger.Event += action;
		}

		public static void SetupSignalListenerForTesting<TSignal, TParam1>(this Signal<TParam1>.TriggerBase trigger, Action<TParam1> action) where TSignal : new()
		{
			var signal = new TSignal();
			var field = typeof(Signal<TParam1>.TriggerBase).GetField("_signal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
			field.SetValue(trigger, signal);
			trigger.Event += action;
		}

		public static void SetupSignalListenerForTesting<TSignal, TParam1, TParam2>(this Signal<TParam1, TParam2>.TriggerBase trigger, Action<TParam1, TParam2> action) where TSignal : new()
		{
			var signal = new TSignal();
			var field = typeof(Signal<TParam1, TParam2>.TriggerBase).GetField("_signal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
			field.SetValue(trigger, signal);
			trigger.Event += action;
		}

		public static void SetupSignalListenerForTesting<TSignal, TParam1, TParam2, TParam3>(this Signal<TParam1, TParam2, TParam3>.TriggerBase trigger, Action<TParam1, TParam2, TParam3> action) where TSignal : new()
		{
			var signal = new TSignal();
			var field = typeof(Signal<TParam1, TParam2, TParam3>.TriggerBase).GetField("_signal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
			field.SetValue(trigger, signal);
			trigger.Event += action;
		}

		public static void SetupSignalListenerForTesting<TSignal, TParam1, TParam2, TParam3, TParam4>(this Signal<TParam1, TParam2, TParam3, TParam4>.TriggerBase trigger, Action<TParam1, TParam2, TParam3, TParam4> action) where TSignal : new()
		{
			var signal = new TSignal();
			var field = typeof(Signal<TParam1, TParam2, TParam3, TParam4>.TriggerBase).GetField("_signal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
			field.SetValue(trigger, signal);
			trigger.Event += action;
		}
	}
}

