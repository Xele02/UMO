using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class BgScroll : SwapScrollList
	{
		// RVA: 0x1444C18 Offset: 0x1444C18 VA: 0x1444C18
		private void Start()
		{
			InitializeList();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CA01C Offset: 0x6CA01C VA: 0x6CA01C
		//// RVA: 0x143C83C Offset: 0x143C83C VA: 0x143C83C
		public IEnumerator SetupList(int scrollCount)
		{
			int i;

			//0x1444E38
			Vector2 p = ScrollContent.anchoredPosition;
			Apply();
			SetContentEscapeMode(true);
			SetItemCount(scrollCount);
			OnUpdateItem.RemoveAllListeners();
			OnUpdateItem.AddListener(OnUpdateListItem);
			ResetScrollVelocity();
			SetPosition(0, p.x, p.y, true);
			VisibleRegionUpdate();
			yield return null;
			for(i = 0; i < ScrollObjects.Count; i++)
			{
				BgItem obj = (ScrollObjects[i] as BgItem);
				yield return new WaitWhile(() =>
				{
					//0x1444DF4
					return !obj.isLoaded;
				});
			}
			yield return null;
		}

		// RVA: 0x1444C1C Offset: 0x1444C1C VA: 0x1444C1C
		private void InitializeList()
		{
			for (int i = 0; i < ScrollObjects.Count; i++)
			{
				SetItemCount(0);
				VisibleRegionUpdate();
			}
		}

		// RVA: 0x1444CF0 Offset: 0x1444CF0 VA: 0x1444CF0
		protected void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			(content as BgItem).UpdateItem(index);
		}
	}
}
