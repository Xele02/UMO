
namespace XeApp.Game.Common
{
	public interface IComponentDeepCopy
	{
		// RVA: -1 Offset: -1 Slot: 0
		void PreCopy(ComponentDeepCopy impl);

		// RVA: -1 Offset: -1 Slot: 1
		void PostCopy(ComponentDeepCopy impl);
	}
}
