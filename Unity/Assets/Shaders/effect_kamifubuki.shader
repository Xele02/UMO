Shader "macr\client\trunk\unity\Assets\Bundles\Scriptables\ly\120@bundle\Effect\fx_kuji\Textures" {
	Properties {
		_MainTex ("MainTex", 2D) = "white" {}
		_TintColor ("Base Color", Vector) = (1,1,1,1)
		_GlowColor ("Glow Color", Vector) = (1,1,1,0)
		_Emission ("Emission", Range(0, 2)) = 1
		_hilight_mask ("hilight_mask", 2D) = "white" {}
		_node_3632 ("node_3632", Float) = -0.5
		[HideInInspector] _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Name "FORWARD"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" "SHADOWSUPPORT" = "true" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			Cull Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 position0 : POSITION;
				float4 color0 : COLOR;
				float2 texcoord0 : TEXCOORD0;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float4 color0 : COLOR0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _TintColor;
			float4 _GlowColor;
			float _Emission;
			float _node_3632;
			sampler2D _hilight_mask;
			float4 _hilight_mask_ST;
			float _Cutoff;
			float2 _TimeEditor;

			v2f vert(appdata v)
			{
				v2f o;
				o.position0 = UnityObjectToClipPos(v.position0);
				o.texcoord0 = v.texcoord0;
				o.color0 = v.color0;
				return o; 
			}
/*			GpuProgramID 34358
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    vs_COLOR0 = in_COLOR0;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 100
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					precision highp int;
					uniform 	vec4 _Time;
					uniform 	vec4 _TimeEditor;
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _TintColor;
					uniform 	vec4 _GlowColor;
					uniform 	float _Emission;
					uniform 	vec4 _hilight_mask_ST;
					uniform 	float _node_3632;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _hilight_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					lowp vec4 u_xlat10_1;
					vec3 u_xlat2;
					void main()
					{
					    u_xlat0.x = _Time.y + _TimeEditor.y;
					    u_xlat0.x = u_xlat0.x * _node_3632;
					    u_xlat0.xy = u_xlat0.xx * vec2(0.349999994, -1.0) + vs_TEXCOORD0.xy;
					    u_xlat0.xy = u_xlat0.xy * _hilight_mask_ST.xy + _hilight_mask_ST.zw;
					    u_xlat10_0 = texture2D(_hilight_mask, u_xlat0.xy).x;
					    u_xlat2.xy = vs_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat10_1 = texture2D(_MainTex, u_xlat2.xy);
					    u_xlat2.xyz = u_xlat10_1.xyz * _TintColor.xyz;
					    u_xlat2.xyz = _GlowColor.xyz * u_xlat10_1.xyz + u_xlat2.xyz;
					    SV_Target0.w = u_xlat10_1.w * vs_COLOR0.w;
					    u_xlat0.xyz = vec3(u_xlat10_0) * u_xlat2.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * vec3(_Emission);
					    SV_Target0.xyz = u_xlat0.xyz * vs_COLOR0.xyz;
					    return;
					}
					
					#endif"
				}
			}
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 SV_Target0, u_xlat10_1;
				float3 u_xlat0, u_xlat2;
				float u_xlat10_0;
				u_xlat0.x = _Time.y + _TimeEditor.y;
				u_xlat0.x = u_xlat0.x * _node_3632;
				u_xlat0.xy = u_xlat0.xx * float2(0.349999994, -1.0) + i.texcoord0.xy;
				u_xlat0.xy = u_xlat0.xy * _hilight_mask_ST.xy + _hilight_mask_ST.zw;
				u_xlat10_0 = tex2D(_hilight_mask, u_xlat0.xy).x;
				u_xlat2.xy = i.texcoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				u_xlat10_1 = tex2D(_MainTex, u_xlat2.xy);
				u_xlat2.xyz = u_xlat10_1.xyz * _TintColor.xyz;
				u_xlat2.xyz = _GlowColor.xyz * u_xlat10_1.xyz + u_xlat2.xyz;
				SV_Target0.w = u_xlat10_1.w * i.color0.w;
				u_xlat0.xyz = float3(u_xlat10_0, u_xlat10_0, u_xlat10_0) * u_xlat2.xyz;
				u_xlat0.xyz = u_xlat0.xyz * float3(_Emission, _Emission, _Emission);
				SV_Target0.xyz = u_xlat0.xyz * i.color0.xyz;
				return SV_Target0;
			}

/*
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "DIRECTIONAL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTPROBE_SH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTPROBE_SH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTPROBE_SH" }
					"!!GLES"
				}
			}
*/
			ENDCG
		}
	}
}
//	CustomEditor "ShaderForgeMaterialInspector"
//}