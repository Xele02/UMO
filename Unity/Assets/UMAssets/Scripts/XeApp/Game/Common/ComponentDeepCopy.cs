using System;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ComponentDeepCopy
	{
		public class ObjectData
		{
			public GameObject gameObject { get; private set; } // 0x8
			public int level { get; private set; } // 0xC
			public bool isSelected { get; internal set; } // 0x10
			public bool foldout { get; set; } // 0x11
			private List<Component> components { get; set; } // 0x14

			// RVA: 0xE670F8 Offset: 0xE670F8 VA: 0xE670F8
			//public bool HasComponent(Type componentType) { }

			// RVA: 0xE68710 Offset: 0xE68710 VA: 0xE68710
			public ObjectData(GameObject go, int lv)
			{
				gameObject = go;
				level = lv;
				isSelected = true;
				foldout = true;
				components = new List<Component>(go.GetComponents<Component>());
			}
		}
	
		public class ComponentData
		{
			public Type type { get; private set; } // 0x8
			public IComponentDeepCopy copyInterface { get; private set; } // 0xC
			public bool hasInterface { get; private set; } // 0x10
			public bool isProjectInternal { get; private set; } // 0x11
			public bool isShow { get; internal set; } // 0x12
			public bool isSelected { get; set; } // 0x13

			// RVA: 0xE684EC Offset: 0xE684EC VA: 0xE684EC
			public ComponentData(Component component)
			{
				type = component.GetType();
				hasInterface = type.GetInterface(nameof(IComponentDeepCopy)) != null;
				isProjectInternal = false;
				copyInterface = component as IComponentDeepCopy;
				isSelected = false;
			}
		}

		private class RelativeData
		{
			public string path = string.Empty; // 0x8
			public Type type = null; // 0xC
			public int index = 0; // 0x10
		}

		private class SerializedRelative : RelativeData
		{
			public string propPath = string.Empty; // 0x14
			public string dispPath; // 0x18
		}

		public enum LogGroup
		{
			Debug = 0,
			Info = 1,
			Warning = 2,
			Error = 3,
			_Num = 4
		}

		public const int LogGroupNum = 4;
		private GameObject m_copyFrom; // 0x8
		private GameObject m_copyTo; // 0xC
		private GameObject m_copyFromRoot; // 0x10
		private GameObject m_copyToRoot; // 0x14
		private List<ObjectData> m_objectDatas; // 0x18
		private List<ComponentData> m_componentDatas; // 0x1C
		private List<RelativeData> m_relativeDatas; // 0x20
		private List<SerializedRelative> m_serializedRelativeDatas; // 0x24
		private List<Component> m_pastedComponents; // 0x28
		private List<string> m_logs = new List<string>(); // 0x2C
		private List<LogGroup> m_logGroups = new List<LogGroup>(); // 0x30
		private readonly Color s_logDefaultColor; // 0x34
		private readonly Color s_logDebugColor; // 0x44
		private readonly Color s_logInfoColor; // 0x54
		private readonly Color s_logWarnColor; // 0x64
		private readonly Color s_logErrColor; // 0x74

		//public GameObject copyFromRoot { get; } 0xE66C28
		//public GameObject copyToRoot { get; } 0xE66C30
		public bool allRelativeCheck { get; set; } // 0x84
		public bool allRelativeReconnect { get; set; } // 0x85
		public int logWarningCount { get; private set; } // 0x88
		public int logErrorCount { get; private set; } // 0x8C
		//public bool hasWarning { get; } 0xE68050
		//public bool hasError { get; } 0xE68064

		// RVA: 0xE66C58 Offset: 0xE66C58 VA: 0xE66C58
		public ComponentDeepCopy()
		{
			m_objectDatas = new List<ObjectData>();
			m_componentDatas = new List<ComponentData>();
			m_relativeDatas = new List<RelativeData>();
			m_serializedRelativeDatas = new List<SerializedRelative>();
			m_pastedComponents = new List<Component>();
			s_logDefaultColor = Color.white;
			s_logInfoColor = s_logDefaultColor;
			s_logDebugColor = Color.gray;
			s_logWarnColor = new Color(0.8f, 0.8f, 0);
			s_logErrColor = new Color(0.8f, 0, 0);
		}

		//// RVA: 0xE66EE0 Offset: 0xE66EE0 VA: 0xE66EE0
		private static bool IsEqualsOrSubclassOf(Type self, Type target)
		{
			return self == target || self.IsSubclassOf(target);
		}

		//// RVA: 0xE66F40 Offset: 0xE66F40 VA: 0xE66F40
		//private static bool ContainComponents(ComponentDeepCopy.ObjectData obj, List<ComponentDeepCopy.ComponentData> components) { }

		//// RVA: 0xE671F0 Offset: 0xE671F0 VA: 0xE671F0
		//private void SearchTargetObject(ComponentDeepCopy.ObjectData obj, ref string fromPath, ref string toPath) { }

		//// RVA: -1 Offset: -1
		public void RegisterRelative<T>(Transform from, T to)
		{
			RegisterRelative(from, to as UnityEngine.Object, to.GetType());
		}
		///* GenericInstMethod :
		//|
		//|-RVA: 0x1AB46E0 Offset: 0x1AB46E0 VA: 0x1AB46E0
		//|-ComponentDeepCopy.RegisterRelative<object>
		//|-ComponentDeepCopy.RegisterRelative<Transform>
		//*/

		//// RVA: 0xE676D4 Offset: 0xE676D4 VA: 0xE676D4
		//public void RegisterRelative(Transform from, GameObject to) { }

		//// RVA: 0xE6778C Offset: 0xE6778C VA: 0xE6778C
		private void RegisterRelative(Transform from, UnityEngine.Object to, Type type)
		{
			RelativeData data = new RelativeData();
			if(to != null)
			{
				if(IsEqualsOrSubclassOf(type, typeof(GameObject)))
				{
					data.path = MakeRelativePath((to as GameObject).transform, from);
					LogDebug(string.Format(" - {0}", data.path));
				}
				else if (IsEqualsOrSubclassOf(type, typeof(Component)))
				{
					data.path = MakeRelativePath((to as Component).transform, from);
					data.index = System.Array.IndexOf((to as Component).GetComponents(type), to);
					LogDebug(string.Format(" - {0} ({1})", data.path, data.index));
				}
				else
				{
					LogError(string.Format(JpStringLiterals.StringLiteral_13620, type));
				}
			}
			else
			{
				LogDebug(string.Format(" - None ({0})", type.Name));
			}
			data.type = type;
			m_relativeDatas.Add(data);
		}

		//// RVA: -1 Offset: -1
		public bool FindRelative<T>(int i, Transform from, ref T result)
		{
			return FindRelative(i, from, ref result, null, null);
		}
		///* GenericInstMethod :
		//|
		//|-RVA: 0x1A0D9A0 Offset: 0x1A0D9A0 VA: 0x1A0D9A0
		//|-ComponentDeepCopy.FindRelative<object>
		//|-ComponentDeepCopy.FindRelative<Transform>
		//*/

		//// RVA: -1 Offset: -1
		public bool FindRelative<T>(int i, Transform from, ref T result, Action<T> onFound, Action onNotFound)
		{
			if(string.IsNullOrEmpty(m_relativeDatas[i].path))
			{
				LogDebug(string.Format(" - None ({0}) ... StringLiteral_13622", typeof(T).Name));
			}
			else
			{
				Transform t = FindRelativeByPath(m_copyTo.transform, m_relativeDatas[i].path);
				if(t != null)
				{
					T[] cp = t.GetComponents<T>();
					if(m_relativeDatas[i].index < cp.Length)
					{
						LogDebug(string.Format(" - StringLiteral_21823\n   {0} ({1})", m_relativeDatas[i].path, m_relativeDatas[i].index));
						result = cp[m_relativeDatas[i].index];
						if (onFound != null)
							onFound(result);
						return true;
					}
					LogError(string.Format(" - StringLiteral_21824\n   {0} ({2})\n   {1}", m_relativeDatas[i].path, typeof(T).FullName, m_relativeDatas[i].index));
				}
				else
				{
					LogError(string.Format(" - StringLiteral_13625\n   {0}", m_relativeDatas[i].path));
				}
				if (onNotFound != null)
					onNotFound();
			}
			return false;
		}
		///* GenericInstMethod :
		//|
		//|-RVA: 0x1A0DA08 Offset: 0x1A0DA08 VA: 0x1A0DA08
		//|-ComponentDeepCopy.FindRelative<object>
		//*/

		//// RVA: 0xE67DEC Offset: 0xE67DEC VA: 0xE67DEC
		//public bool FindRelative(int i, Transform from, ref GameObject result) { }

		//// RVA: 0xE67E10 Offset: 0xE67E10 VA: 0xE67E10
		//public bool FindRelative(int i, Transform from, ref GameObject result, Action<GameObject> onFound, Action onNotFound) { }

		//// RVA: 0xE6748C Offset: 0xE6748C VA: 0xE6748C
		public string MakeRelativePath(Transform from, Transform to)
		{
			string res = "";
			while(true)
			{
				if (to == null)
					return "";
				res = to.name + "/" + res;
				if (to == from)
					break;
				to = to.parent;
			}
			res = res.Remove(res.Length - 1);
			return res;
		}

		//// RVA: 0xE67644 Offset: 0xE67644 VA: 0xE67644
		public Transform FindRelativeByPath(Transform root, string path)
		{
			int pos = path.IndexOf('/');
			if (pos < 0)
			{
				return root;
			}
			return root.Find(path.Remove(0, pos));
		}

		//// RVA: 0xE68078 Offset: 0xE68078 VA: 0xE68078
		//public void LogInfo(string log) { }

		//// RVA: 0xE67C90 Offset: 0xE67C90 VA: 0xE67C90
		public void LogDebug(string log)
		{
			Log(log, s_logDebugColor);
			m_logGroups.Add(LogGroup.Debug);
		}

		//// RVA: 0xE681F8 Offset: 0xE681F8 VA: 0xE681F8
		//public void LogWarning(string log) { }

		//// RVA: 0xE67D38 Offset: 0xE67D38 VA: 0xE67D38
		public void LogError(string log)
		{
			Log(log, s_logErrColor);
			m_logGroups.Add(LogGroup.Error);
		}

		//// RVA: 0xE68120 Offset: 0xE68120 VA: 0xE68120
		private void Log(string log, Color color)
		{
			m_logs.Add(string.Format("<color=#{1}>{0}</color>", log, ColorUtility.ToHtmlStringRGB(color)));
		}

		//// RVA: 0xE682AC Offset: 0xE682AC VA: 0xE682AC
		//public IEnumerable<string> IterationLog() { }

		//// RVA: 0xE682B4 Offset: 0xE682B4 VA: 0xE682B4
		//public void IterationLog(Action<string, ComponentDeepCopy.LogGroup> iterate) { }

		//// RVA: 0xE683F4 Offset: 0xE683F4 VA: 0xE683F4
		//public void ClearLog() { }
	}
}
