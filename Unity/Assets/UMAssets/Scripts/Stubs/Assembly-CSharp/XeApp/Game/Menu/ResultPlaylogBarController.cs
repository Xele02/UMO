using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class ResultPlaylogBarController : MonoBehaviour
	{
		[Serializable]
		private class GraphColorData
		{
			public Color left;
			public Color right;
		}

		[Serializable]
		private class GraphColorDataTable
		{
			public ResultPlaylogBarController.GraphColorData[] table;
		}

		[SerializeField]
		private GraphColorDataTable[] GraphColorTable;
	}
}
