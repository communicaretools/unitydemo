using Neighbourhood.Game.Indoors.Visitables;

namespace Neighbourhood.Editor.Tests.Indoors.Visitables
{
	public class StubGlowingView : IGlowWhenApproached
	{
		public bool DidGlow { get; private set; }
		public bool StoppedToGlow { get; private set; }
		public bool IsGlowing { get; private set; }

		public StubGlowingView(IVisitableItem item)
		{
			this.Item = item;
		}

		#region IGlowWhenApproached implementation
		public void Glow()
		{
			IsGlowing = true;
			DidGlow = true;
		}

		public void StopGlowing()
		{
			IsGlowing = false;
			StoppedToGlow = true;
		}

		public IVisitableItem Item { get; private set; }
		#endregion
	}
}

