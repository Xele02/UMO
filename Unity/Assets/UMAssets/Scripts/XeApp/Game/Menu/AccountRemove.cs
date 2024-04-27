using System.Collections;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class AccountRemove
	{
		public enum Result
		{
			None = 0,
			Success = 1,
			Failure = 2,
			Cancel = 3,
		}

		private HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink[] _platforms = new HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink[3]
			{
				HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter,
				HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook,
				HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line
			}; // 0x8

		public Result RemoveAcctounResult { get; private set; } // 0xC

		//[IteratorStateMachineAttribute] // RVA: 0x6C9C34 Offset: 0x6C9C34 VA: 0x6C9C34
		// RVA: 0x1433444 Offset: 0x1433444 VA: 0x1433444
		public IEnumerator Execute()
		{
			int i; // 0x24
			IAEMADDNJPJ_ClearDeviceLoginDataWithLog request; // 0x28

			//0x14336CC
			bool done = false;
			bool cancel = false;
			bool error = false;
			HDEEBKIFLNI.HHCJCDFCLOB.NLCBOJBAJFB_GetLinkageStatuses(() =>
			{
				//0x1433648
				done = true;
			}, () =>
			{
				//0x1433654
				done = true;
				cancel = true;
			}, () =>
			{
				//0x1433660
				error = true;
				done = true;
			});
			while(!done)
				yield return null;
			if(!cancel)
			{
				if(!error)
				{
					AMOCLPHDGBP data = new AMOCLPHDGBP();
					error = false;
					yield return data.HELKENJBJBH_Coroutine_AccountRemoveRecover(() =>
					{
						//0x143363C
						return;
					}, () =>
					{
						//0x1433678
						error = true;
					});
					if(error)
					{
						RemoveAcctounResult = Result.Failure;
					}
					else
					{
						bool isWait = true;
						NMFABEKNBKJ.HHCJCDFCLOB.MDJNLBOLPNJ_BlockFCM(() =>
						{
							//0x143368C
							isWait = false;
						});
						while(isWait)
							yield return null;
						for(i = 0; i < _platforms.Length; i++)
						{
							if(HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(_platforms[i]))
							{
								done = false;
								cancel = false;
								error = false;
								HDEEBKIFLNI.HHCJCDFCLOB.LEDGNMBOGJN(_platforms[i], () =>
								{
									//0x14336A0
									done = true;
								}, () =>
								{
									//0x14336AC
									done = true;
									cancel = true;
								}, () =>
								{
									//0x14336B8
									done = true;
									error = true;
								});
								while(!done)
									yield return null;
								if(cancel)
								{
									RemoveAcctounResult = Result.Cancel;
									yield break;
								}
								else if(error)
								{
									RemoveAcctounResult = Result.Failure;
									yield break;
								}
							}
						}
						if(!Application.isEditor)
						{
							request = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new IAEMADDNJPJ_ClearDeviceLoginDataWithLog());
							yield return request.GDPDELLNOBO_WaitDone(N.a);
							if(request.NPNNPNAIONN_IsError)
							{
								RemoveAcctounResult = Result.Failure;
							}
							else
							{
								request = null;
								EOHDAOAJOHH.HHCJCDFCLOB.KOFIBEMHONI();
								RemoveAcctounResult = Result.Success;
							}
						}
						//LAB_01433f18
					}
				}
				else
				{
					RemoveAcctounResult = Result.Failure;
				}
			}
			else
			{
				RemoveAcctounResult = Result.Cancel;
			}
		}
	}
}
