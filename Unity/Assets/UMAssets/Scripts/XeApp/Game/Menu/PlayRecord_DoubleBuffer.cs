
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class PlayRecord_DoubleBuffer<T>
	{
		public List<T> m_obj; // 0x0
		public int m_current; // 0x0

		public T front { get { return m_obj[0]; } } // 0x30A5FB0
		public T back { get { return m_obj[m_current]; } } // 0x30A5FF4 ??

		// RVA: -1 Offset: -1
		public PlayRecord_DoubleBuffer(List<T> a_obj)
		{
			m_obj = a_obj;
			m_current = 0;
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x30A5F74 Offset: 0x30A5F74 VA: 0x30A5F74
		|-PlayRecord_DoubleBuffer<object>..ctor
		|-PlayRecord_DoubleBuffer<UI_PlayRecord_DivaInfo>..ctor
		*/

		//// RVA: -1 Offset: -1
		//public T get_front() { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A5FB0 Offset: 0x30A5FB0 VA: 0x30A5FB0
		//|-PlayRecord_DoubleBuffer<object>.get_front
		//|-PlayRecord_DoubleBuffer<UI_PlayRecord_DivaInfo>.get_front
		//*/

		//// RVA: -1 Offset: -1
		//public T get_back() { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A5FF4 Offset: 0x30A5FF4 VA: 0x30A5FF4
		//|-PlayRecord_DoubleBuffer<object>.get_back
		//|-PlayRecord_DoubleBuffer<UI_PlayRecord_DivaInfo>.get_back
		//*/

		//// RVA: -1 Offset: -1
		//public void Swap() { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x30A6048 Offset: 0x30A6048 VA: 0x30A6048
		//|-PlayRecord_DoubleBuffer<object>.Swap
		//|-PlayRecord_DoubleBuffer<UI_PlayRecord_DivaInfo>.Swap
		//*/
	}
}
