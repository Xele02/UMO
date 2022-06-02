
namespace XeApp.Game.Common
{
	public class DivaMenuParam : ScriptableObject
	{
		[SerializeField]
		private List<int> m_reactionWeights; // 0xC
		[SerializeField]
		private List<float> m_cameraPosY; // 0x10
		[SerializeField]
		private List<float> m_battleResultCameraPosY; // 0x14

		public IList<int> ReactionWeights { get { return m_reactionWeights; } } // get_ReactionWeights 0x1BF00FC 

		// // RVA: 0x1BF0104 Offset: 0x1BF0104 VA: 0x1BF0104
		// public IList<float> CameraPosY(DivaMenuParam.CameraPosType type) { }
	}
}