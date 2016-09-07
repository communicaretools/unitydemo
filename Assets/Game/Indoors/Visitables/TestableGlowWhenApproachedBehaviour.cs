using UnityEngine;
using Zenject;

namespace Neighbourhood.Game.Indoors.Visitables
{
	[RequireComponent(typeof(VisitableItemBehaviour))]
	public class TestableGlowWhenApproachedBehaviour : MonoBehaviour, IGlowWhenApproached
	{
		VisitableGlobalSettings settings;
		new Renderer renderer;
		Material originalMaterial;

		public IVisitableItem Item { get; private set; }

		[Inject]
		public void Init(GlowWhenApproachedController controller, VisitableGlobalSettings settings)
		{
			this.settings = settings;
			this.renderer = GetComponent<Renderer>();
			this.originalMaterial = renderer.material;

			Item = GetComponent<VisitableItemBehaviour>();
			controller.InitView(this);
		}

		#region IGlowWhenApproached implementation

		public void Glow()
		{
			renderer.material = settings.GlowMaterial;
		}

		public void StopGlowing()
		{
			renderer.material = originalMaterial;
		}

		#endregion
	}
}

