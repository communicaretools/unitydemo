using System;
using Zenject;
using System.Collections.Generic;

namespace Neighbourhood.Game.UnityIntegration
{
	public abstract class Controller : IController
	{
		private IList<Action> unsubscribeHandlers = new List<Action>();

		protected void SubscribeToSignal<TSignal>(TSignal signal, Action handler) where TSignal : Signal
		{
			signal.Event += handler;
			unsubscribeHandlers.Add(() =>
			{
				if (signal != null)
				{
					signal.Event -= handler;
				}
			});
		}

		protected void SubscribeToSignal<TSignal, TParam1>(TSignal signal, Action<TParam1> handler) where TSignal : Signal<TParam1>
		{
			signal.Event += handler;
			unsubscribeHandlers.Add(() =>
			{
				if (signal != null)
				{
					signal.Event -= handler;
				}
			});
		}

		protected void SubscribeToSignal<TSignal, TParam1, TParam2>(TSignal signal, Action<TParam1, TParam2> handler) where TSignal : Signal<TParam1, TParam2>
		{
			signal.Event += handler;
			unsubscribeHandlers.Add(() =>
			{
				if (signal != null)
				{
					signal.Event -= handler;
				}
			});
		}

		protected void SubscribeToSignal<TSignal, TParam1, TParam2, TParam3>(TSignal signal, Action<TParam1, TParam2, TParam3> handler) where TSignal : Signal<TParam1, TParam2, TParam3>
		{
			signal.Event += handler;
			unsubscribeHandlers.Add(() =>
			{
				if (signal != null)
				{
					signal.Event -= handler;
				}
			});
		}

		protected void SubscribeToSignal<TSignal, TParam1, TParam2, TParam3, TParam4>(TSignal signal, Action<TParam1, TParam2, TParam3, TParam4> handler) where TSignal : Signal<TParam1, TParam2, TParam3, TParam4>
		{
			signal.Event += handler;
			unsubscribeHandlers.Add(() =>
			{
				if (signal != null)
				{
					signal.Event -= handler;
				}
			});
		}

		void SubscribeToSignal<TSignal, TParam1, TParam2, TParam3, TParam4, TParam5>(TSignal signal, ModestTree.Util.Action<TParam1, TParam2, TParam3, TParam4, TParam5> handler) where TSignal : Signal<TParam1, TParam2, TParam3, TParam4, TParam5>
		{
			signal.Event += handler;
			unsubscribeHandlers.Add(() =>
			{
				if (signal != null)
				{
					signal.Event -= handler;
				}
			});
		}

		protected void SubscribeToSignal<TSignal, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(TSignal signal, ModestTree.Util.Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> handler) where TSignal : Signal<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>
		{
			signal.Event += handler;
			unsubscribeHandlers.Add(() =>
			{
				if (signal != null)
				{
					signal.Event -= handler;
				}
			});
		}

		#region IDispose implementation
		private bool disposed;
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// See https://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx
		/// for more information on the dispose pattern
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposed) { return; }
			if (disposing)
			{
				if (unsubscribeHandlers != null)
				{
					foreach (var unsubscribe in unsubscribeHandlers)
					{
						unsubscribe();
					}
					unsubscribeHandlers = null;
				}
			}
			disposed = true;
		}
		#endregion
	}

	public abstract class Controller<TView> : Controller, IController<TView>
		where TView : class  // actually, that means "reference type", ie class or interface
	{
		protected TView View { get; private set; }

		#region IController implementation
		public virtual void Init(TView view)
		{
			if (view == null)
			{
				throw new ArgumentNullException("view",
					string.Format("Tried to initialize a Controller, {0}, with a null view - are you sure that the view in question derives from/implements {1}?",
						GetType().Name, typeof(TView).Name));
			}
			View = view;
		}
		#endregion

	}
}
