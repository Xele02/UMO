
namespace XeApp.Game.MiniGame
{
	internal interface ShootingPoolMethod<T>
	{
		//// RVA: -1 Offset: -1 Slot: 0
		T Alloc();
		///* GenericInstMethod :
		//|
		//|-RVA: -1 Offset: -1
		//|-ShootingPoolMethod<object>.Alloc
		//*/

		//// RVA: -1 Offset: -1 Slot: 1
		//public abstract void Free();
		///* GenericInstMethod :
		//|
		//|-RVA: -1 Offset: -1
		//|-ShootingPoolMethod<object>.Free
		//*/

		//// RVA: -1 Offset: -1 Slot: 2
		void Create(int createNum);
		///* GenericInstMethod :
		//|
		//|-RVA: -1 Offset: -1
		//|-ShootingPoolMethod<object>.Create
		//*/

		//// RVA: -1 Offset: -1 Slot: 3
		void Create();
		///* GenericInstMethod :
		//|
		//|-RVA: -1 Offset: -1
		//|-ShootingPoolMethod<object>.Create
		//*/

		//// RVA: -1 Offset: -1 Slot: 4
		//public abstract void Dispose();
		///* GenericInstMethod :
		//|
		//|-RVA: -1 Offset: -1
		//|-ShootingPoolMethod<object>.Dispose
		//*/
	}
}
