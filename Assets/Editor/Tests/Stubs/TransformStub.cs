using Neighbourhood.Game.UnityIntegration.Abstractions.Components;
using UnityEngine;

namespace Neighbourhood.Editor.Tests.Stubs
{
	public class TransformStub : ITransform
	{
		#region ITransform implementation

		public Vector3 Position { get; set; }
		public Vector3 Forward { get; set; }
		public Vector3 Rotation { get; set; }

		#endregion

		public TransformStub()
		{
			Forward = Vector3.forward;
			Rotation = new Vector3();
		}

		public void Rotate(float x, float y, float z)
		{
			// no, it's not necessarily entirely correct
			// or foolproof, but it reflects the intention
			// in a unit test
			Rotation += new Vector3(x, y, z);
		}
	}
	
}
