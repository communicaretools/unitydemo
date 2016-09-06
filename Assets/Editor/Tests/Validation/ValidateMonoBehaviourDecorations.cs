using System;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using Neighbourhood.Game;
using Neighbourhood.Game.UnityIntegration.Abstractions;
using Neighbourhood.Game.UnityIntegration.Abstractions.Components;

namespace Neighbourhood.Editor.Tests.Validation
{
	[TestFixture]
	public class ValidateMonoBehaviourDecorations
	{
		// Relationships between our abstraction interfaces and Unity Components:
		// Require that the given behaviour has the corresponding RequireComponent(type)
		// annotation
		IDictionary<Type, Type> ifaceToComponent = new Dictionary<Type, Type>
		{
			{typeof(IHasRigidbody), typeof(Rigidbody)},
			{typeof(IHasAnimator), typeof(Animator)},
			{typeof(IHasNavMeshAgent), typeof(UnityEngine.AI.NavMeshAgent)}
		};
		/// <summary>
		/// Relationships between certain message handlers and Unity Components:
		/// Require that the given behaviour has the corresponding RequireComponent(type)
		/// annotation
		/// </summary>
		IDictionary<string, Type> handlerMethodPrefixToComponent = new Dictionary<string, Type>
		{
			{"OnAnimator", typeof(Animator)},
			{"OnCollision", typeof(Collider)},
			{"OnTrigger", typeof(Collider)},
			{"OnMouse", typeof(Collider)},
		};

		[Test]
		public void CheckThatDecorationsMatchInterfaces()
		{
			var behaviours = GetMonoBehaviours();
			foreach (var behaviour in behaviours)
			{
				var abstractions = GetAbstractionInterfaces(behaviour);
				var requires = GetComponentRequired(behaviour);
				foreach (var iface in abstractions)
				{
					if (!ifaceToComponent.ContainsKey(iface)) { continue; }

					Assert.That(requires, Contains.Item(ifaceToComponent[iface]),
						"The MonoBehaviour {0} declares the interface {1}, but is missing the corresponding [RequireComponent({2})] annotation",
						behaviour.FullName, iface.Name, ifaceToComponent[iface].Name);
				}
			}
		}

		[Test]
		public void CheckThatDecorationsMatchHandlerMethods()
		{
			var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

			var behaviours = GetMonoBehaviours();
			foreach (var behaviour in behaviours)
			{
				var handlerMethods = GetHandlerMethodNames(bindingFlags, behaviour);
				var requires = GetComponentRequired(behaviour);
				foreach (var method in handlerMethods)
				{
					var key = handlerMethodPrefixToComponent.Keys.FirstOrDefault(method.StartsWith);
					if (key == null) { continue; }
					var requiredComponent = handlerMethodPrefixToComponent[key];
					Assert.That(requires, Contains.Item(requiredComponent),
						"The MonoBehaviour {0} declares the handler method {1}, but is missing the corresponding [RequireComponent({2})] annotation",
						behaviour.FullName, method, requiredComponent.Name);
				}
			}
		}

		static IEnumerable<Type> GetMonoBehaviours()
		{
			return typeof(GameInstaller).Assembly
				.GetExportedTypes()
				.Where(t => typeof(MonoBehaviour).IsAssignableFrom(t)
					&& !t.IsAbstract
					&& t.Namespace.StartsWith(typeof(GameInstaller).Namespace));
		}

		static Type[] GetAbstractionInterfaces(Type behaviour)
		{
			return behaviour.GetInterfaces()
				.Where(iface => iface.Namespace != null && iface.Namespace.StartsWith(typeof(IInput).Namespace))
				.ToArray();
		}

		static IEnumerable<string> GetHandlerMethodNames(BindingFlags bindingFlags, Type behaviour)
		{
			return behaviour.GetMethods(bindingFlags).Where(method => method.Name.StartsWith("On")).Select(method => method.Name);
		}

		Type[] GetComponentRequired(Type behaviourType)
		{
			return behaviourType
				.GetCustomAttributes(true)
				.OfType<RequireComponent>()
				.SelectMany(cr => new[] {cr.m_Type0, cr.m_Type1, cr.m_Type2})
				.Where(c => c != null)
				.ToArray();
		}
	}
}

