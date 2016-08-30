using Neighbourhood.Game.Abstractions.Components;
using UnityEngine;

namespace Neighbourhood.Editor.Tests.Stubs
{
	public class TransformStub : ITransform
	{
		#region ITransform implementation

		public Vector3 Position { get; set; }
		public Vector3 Forward { get; set; }
		public Quaternion Rotation { get; set; }

		#endregion

		public TransformStub()
		{
			Forward = Vector3.forward;
			Rotation = Quaternion.identity;
		}
	}
	
}
