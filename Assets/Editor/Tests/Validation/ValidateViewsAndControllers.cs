using System;
using NUnit.Framework;
using Neighbourhood.Game;
using System.Linq;
using Neighbourhood.Game.UnityIntegration.Implementation;
using Neighbourhood.Game.UnityIntegration;
using System.Collections.Generic;

namespace Neighbourhood.Editor.Tests.Validation
{
	[TestFixture]
	public class ValidateViewsAndControllers
	{
		[Test]
		public void CheckViews()
		{
			var views = FindAllViews();

			foreach (var view in views)
			{
				var viewArguments = view.Base.GetGenericArguments();
				var controllerType = viewArguments[0];
				var controllerViewType = FindControllerViewType(controllerType);

				Assert.That(controllerViewType == view.View || controllerViewType.IsAssignableFrom(view.View),
					"In order to use {0} as a view for {1}, {0} must implement {2}",
					view.View.Name, controllerType.Name, controllerViewType.Name);
			}
		}

		IEnumerable<ViewAndBase> FindAllViews()
		{
			return typeof(GameInstaller).Assembly
				.GetExportedTypes()
				.Where(t => typeof(BaseBehaviour).IsAssignableFrom(t)
					&& !t.IsAbstract 
					&& t.Namespace.StartsWith(typeof(GameInstaller).Namespace))
				.Select(v => new ViewAndBase(v, FindGenericBaseTypeOf(v)))
				.Where(v => v.Base != null);
		}

		static Type FindControllerViewType(Type controllerType)
		{
			var controllerInterface = controllerType.GetInterface(typeof(IController<>).Name);
			Assert.That(controllerInterface, Is.Not.Null, "If you intend to use the generic BaseBehaviour, {0} has to implement IController<>", controllerType);
			var controllerArguments = controllerInterface.GetGenericArguments();
			var controllerViewType = controllerArguments[0];
			return controllerViewType;
		}

		Type FindGenericBaseTypeOf(Type v)
		{
			if (v.BaseType == null)
			{
				return null;
			}
			if (v.BaseType.GetGenericArguments().Length == 2)
			{
				return v.BaseType;
			}
			return FindGenericBaseTypeOf(v.BaseType);
		}

		class ViewAndBase
		{
			public Type View { get; private set; }
			public Type Base { get; private set; }

			public ViewAndBase(Type item1, Type item2)
			{
				this.View = item1;
				this.Base = item2;
			}
			
		}
	}
}

