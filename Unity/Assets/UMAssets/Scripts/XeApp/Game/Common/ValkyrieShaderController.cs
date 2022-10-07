using System;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieShaderController : MonoBehaviour
	{
		public enum Type
		{
			None = 0,
			Default_Hi = 1,
			Default_Low = 2,
		}

		private class MaterialInfo
		{
			public Material m_awake; // 0x8
			public Material m_default; // 0xC
			public ValkyrieShaderController.ShaderDefaultValue m_default_value;
			public List<ValkyrieShaderController.RendererInfo> m_target_renderer = new List<ValkyrieShaderController.RendererInfo>(); // 0x3C
		}

		private class RendererInfo
		{
			public Renderer m_renderer; // 0x8
			public Material m_material; // 0xC
			public ValkyrieShaderController.Type m_type; // 0x10
			public bool m_is_awake; // 0x14
			public int m_material_index; // 0x18
		}

		private class MaterialData
		{
			public Material m_awake; // 0x8
			public Material m_default; // 0xC
		}

		private struct ShaderDefaultValue
		{
			public int m_base_speed; // 0x0
			public Color m_base_color_IBL; // 0x4
			public int m_awake_speed_noise; // 0x14
			public int m_awake_speed; // 0x18
			public Color m_awake_color_IBL; // 0x1C
		}

		private struct ShaderNameId
		{
			public int m_noise; // 0x0
			public int m_speed; // 0x4
			public int m_color_IBL; // 0x8
		}

		private Dictionary<int, MaterialInfo> m_material_info = new Dictionary<int, MaterialInfo>(); // 0xC
		private ShaderNameId m_shader_nameid; // 0x10

		//// RVA: 0xD2F120 Offset: 0xD2F120 VA: 0xD2F120
		public ValkyrieShaderController.Type GetShaderType(string a_name)
		{
			if (a_name == "MCRS/Valkyrie_High")
				return Type.Default_Hi;
			if (a_name == "MCRS/Valkyrie_Low")
				return Type.Default_Low;
			return Type.None;
		}

		//// RVA: 0xD2F1D8 Offset: 0xD2F1D8 VA: 0xD2F1D8
		public bool IsEnable()
		{
			for(int i = 0; i < m_material_info.Count; i++)
			{
				if (m_material_info[i].m_target_renderer.Count > 0)
					return true;
			}
			return false;
		}

		//// RVA: 0xD2F2E4 Offset: 0xD2F2E4 VA: 0xD2F2E4
		private int GetMaterialIndex(string a_name)
		{
			char[] sep = new char[1];
			sep[0] = '_';
			string[] strs = a_name.Split(sep);
			if(strs.Length > 1 && strs[1].Length > 1)
			{
				int val = 0;
				if(Int32.TryParse(strs[1].Substring(0, 2), out val))
				{
					val = val - 1;
				}
				return val;
			}
			return 0;
		}

		//// RVA: 0xD29174 Offset: 0xD29174 VA: 0xD29174
		public void Initialize(Renderer[] a_renderer, ValkyrieResource a_resource)
		{
			m_material_info = new Dictionary<int, MaterialInfo>();
			for(int i = 0; i < a_renderer.Length; i++)
			{
				for (int j = 0; j < a_renderer[i].sharedMaterials.Length; j++)
				{
					if(a_renderer[i].sharedMaterials[j] != null)
					{
						ValkyrieShaderController.Type shaderType = GetShaderType(a_renderer[i].sharedMaterials[j].shader.name);
						if(shaderType != Type.None)
						{
							RendererInfo info = new RendererInfo();
							info.m_renderer = a_renderer[i];
							info.m_is_awake = false;
							info.m_material = a_renderer[i].sharedMaterials[j];
							info.m_type = shaderType;
							info.m_material_index = GetMaterialIndex(info.m_material.name);
							MaterialInfo matInfo = null;
							if(!m_material_info.TryGetValue(info.m_material_index, out matInfo))
							{
								matInfo = new MaterialInfo();
								m_material_info[info.m_material_index] = matInfo;
							}
							matInfo.m_target_renderer.Add(info);
						}
					}
				}
			}
			if (IsEnable())
			{
				m_shader_nameid.m_speed = Shader.PropertyToID("_speed");
				m_shader_nameid.m_noise = Shader.PropertyToID("_noise_speed");
				m_shader_nameid.m_color_IBL = Shader.PropertyToID("_IBL_color");
				for (int i = 0; i < m_material_info.Count; i++)
				{
					for(int j = 0; j < m_material_info[i].m_target_renderer.Count; j++)
					{
						if(m_material_info[i].m_target_renderer[j] != null)
						{
							if(m_material_info[i].m_target_renderer[j].m_type == Type.Default_Low)
							{
								if(a_resource != null)
								{
									TodoLogger.Log(0, "end valk shader init");
								}
								m_material_info[i].m_default = new Material(m_material_info[i].m_target_renderer[j].m_material);
							}
							else if (m_material_info[i].m_target_renderer[j].m_type == Type.Default_Hi)
							{
								if (a_resource != null)
								{
									TodoLogger.Log(0, "end valk shader init");
								}
								m_material_info[i].m_default = new Material(m_material_info[i].m_target_renderer[j].m_material);
								m_material_info[i].m_default_value.m_base_speed = m_material_info[i].m_default.GetInt(m_shader_nameid.m_speed);
								m_material_info[i].m_default_value.m_base_color_IBL = m_material_info[i].m_default.GetColor(m_shader_nameid.m_color_IBL);
							}
						}
					}
				}
			}
		}

		//// RVA: 0xD2AF2C Offset: 0xD2AF2C VA: 0xD2AF2C
		//public void Pause(bool a_pause) { }

		//// RVA: 0xD2A988 Offset: 0xD2A988 VA: 0xD2A988
		public void SetIBLColor(ValkyrieColorParam a_color_param)
		{
			if(IsEnable())
			{
				for(int i = 0; i < m_material_info.Count; i++)
				{
					if(m_material_info[i].m_target_renderer[0].m_type == Type.Default_Hi)
					{
						if(m_material_info[i].m_awake != null)
						{
							m_material_info[i].m_awake.SetColor(m_shader_nameid.m_color_IBL, a_color_param != null ? a_color_param.colorValkyrie : m_material_info[i].m_default_value.m_awake_color_IBL);
						}
						if (m_material_info[i].m_default != null)
						{
							m_material_info[i].m_default.SetColor(m_shader_nameid.m_color_IBL, a_color_param != null ? a_color_param.colorValkyrie : m_material_info[i].m_default_value.m_base_color_IBL);
						}
						foreach(var s in m_material_info[i].m_target_renderer)
						{
							s.m_renderer.material.SetColor(m_shader_nameid.m_color_IBL, s.m_is_awake ? (a_color_param != null ? a_color_param.colorValkyrie : m_material_info[i].m_default_value.m_awake_color_IBL) : a_color_param != null ? a_color_param.colorValkyrie : m_material_info[i].m_default_value.m_base_color_IBL);
						}
					}
				}
			}
		}

		//// RVA: 0xD2A36C Offset: 0xD2A36C VA: 0xD2A36C
		public void SetAwakeMaterial(bool a_enable)
		{
			if(IsEnable())
			{
				int idx = 0;
				foreach(var s in m_material_info)
				{
					if(s.Value.m_awake != null)
					{
						if(a_enable)
						{
							foreach(var r in s.Value.m_target_renderer)
							{
								if(r.m_material_index == idx)
								{
									r.m_renderer.material = s.Value.m_awake;
									r.m_is_awake = true;
								}
							}
						}
						else
						{
							foreach (var r in s.Value.m_target_renderer)
							{
								if (r.m_material_index == idx)
								{
									r.m_renderer.material = s.Value.m_default;
									r.m_is_awake = false;
								}
							}
						}
					}
					idx++;
				}
			}
		}
	}
}
