Shader "MCRS/Effect/MultipliedAlphaBlend" {
	Properties {
		_MainTex ("MainTex", 2D) = "white" {}
		_MainMaskTex ("MainMaskTex", 2D) = "white" {}
		_TintColor ("Base Color", Vector) = (1,1,1,1)
		[MaterialToggle] _TexColorOnOff ("TexColor On/Off", Float) = 0
		_GlowColor ("Glow Color", Vector) = (1,1,1,0)
		[MaterialToggle] _GlowColorOnOff ("GlowColor On/Off", Float) = 0
		_Emission ("Emission", Range(0.5, 5)) = 1
		[HideInInspector] _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Name "FORWARD"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" "SHADOWSUPPORT" = "true" }
			Blend One OneMinusSrcAlpha, One OneMinusSrcAlpha
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
			sampler2D _MainMaskTex;
			float4 _MainMaskTex_ST;
			float4 _TintColor;
			float _TexColorOnOff;
			float4 _GlowColor;
			float _GlowColorOnOff;
			float _Emission;
			float _Cutoff;


			v2f vert(appdata v)
			{
				v2f o;
				o.texcoord0 = v.texcoord0;
				o.position0 = UnityObjectToClipPos(v.position0);
				o.color0 = v.color0;
				return o; 
			}
/*			GpuProgramID 5938
			Program "vp" {
				SubProgram "gles hw_tier02 " {
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
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[1].yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[0] * hlslcc_mtx4x4unity_ObjectToWorld[1].xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[2] * hlslcc_mtx4x4unity_ObjectToWorld[1].zzzz + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * hlslcc_mtx4x4unity_ObjectToWorld[1].wwww + u_xlat0;
					    u_xlat0 = u_xlat0 * in_POSITION0.yyyy;
					    u_xlat1 = hlslcc_mtx4x4unity_ObjectToWorld[0].yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * hlslcc_mtx4x4unity_ObjectToWorld[0].xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * hlslcc_mtx4x4unity_ObjectToWorld[0].zzzz + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[3] * hlslcc_mtx4x4unity_ObjectToWorld[0].wwww + u_xlat1;
					    u_xlat0 = u_xlat1 * in_POSITION0.xxxx + u_xlat0;
					    u_xlat1 = hlslcc_mtx4x4unity_ObjectToWorld[2].yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * hlslcc_mtx4x4unity_ObjectToWorld[2].xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * hlslcc_mtx4x4unity_ObjectToWorld[2].zzzz + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[3] * hlslcc_mtx4x4unity_ObjectToWorld[2].wwww + u_xlat1;
					    u_xlat0 = u_xlat1 * in_POSITION0.zzzz + u_xlat0;
					    u_xlat1 = hlslcc_mtx4x4unity_ObjectToWorld[3].yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * hlslcc_mtx4x4unity_ObjectToWorld[3].xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * hlslcc_mtx4x4unity_ObjectToWorld[3].zzzz + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[3] * hlslcc_mtx4x4unity_ObjectToWorld[3].wwww + u_xlat1;
					    gl_Position = u_xlat1 * in_POSITION0.wwww + u_xlat0;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    vs_COLOR0 = in_COLOR0;
					    return;
					}
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 u_xlat10_0, u_xlat0, SV_Target0, u_xlat16_1, u_xlat1, u_xlat10_1;
				u_xlat0.xy = i.texcoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				u_xlat10_0 = tex2D(_MainTex, u_xlat0.xy);
				u_xlat16_1.xyz = u_xlat10_0.xyz + float3(-1.0, -1.0, -1.0);
				u_xlat16_1.xyz = float3(float3(_TexColorOnOff, _TexColorOnOff, _TexColorOnOff)) * u_xlat16_1.xyz + float3(1.0, 1.0, 1.0);
				u_xlat16_1.xyz = u_xlat10_0.www * u_xlat16_1.xyz;
				u_xlat0.xyz = u_xlat10_0.xyz * _GlowColor.xyz;
				u_xlat0.w = u_xlat10_0.w * i.color0.w;
				u_xlat0.xyz = u_xlat0.xyz * float3(_GlowColorOnOff, _GlowColorOnOff, _GlowColorOnOff);
				u_xlat0.xyz = u_xlat16_1.xyz * _TintColor.xyz + u_xlat0.xyz;
				u_xlat0.xyz = u_xlat0.xyz * i.color0.xyz;
				u_xlat0 = u_xlat0 * float4(_Emission, _Emission, _Emission, _Emission);
				u_xlat1.xy = i.texcoord0.xy * _MainMaskTex_ST.xy + _MainMaskTex_ST.zw;
				u_xlat10_1 = tex2D(_MainMaskTex, u_xlat1.xy);
				SV_Target0 = u_xlat0 * u_xlat10_1;
				return SV_Target0;
			}

/*
					#endif
					#ifdef FRAGMENT
					#version 100
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					precision highp int;
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _TintColor;
					uniform 	vec4 _GlowColor;
					uniform 	float _Emission;
					uniform 	mediump float _GlowColorOnOff;
					uniform 	mediump float _TexColorOnOff;
					uniform 	vec4 _MainMaskTex_ST;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _MainMaskTex;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					lowp vec4 u_xlat10_0;
					vec2 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec4 u_xlat10_1;
					void main()
					{
					    u_xlat0.xy = vs_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat10_0 = texture2D(_MainTex, u_xlat0.xy);
					    u_xlat16_1.xyz = u_xlat10_0.xyz + vec3(-1.0, -1.0, -1.0);
					    u_xlat16_1.xyz = vec3(vec3(_TexColorOnOff, _TexColorOnOff, _TexColorOnOff)) * u_xlat16_1.xyz + vec3(1.0, 1.0, 1.0);
					    u_xlat16_1.xyz = u_xlat10_0.www * u_xlat16_1.xyz;
					    u_xlat0.xyz = u_xlat10_0.xyz * _GlowColor.xyz;
					    u_xlat0.w = u_xlat10_0.w * vs_COLOR0.w;
					    u_xlat0.xyz = u_xlat0.xyz * vec3(_GlowColorOnOff);
					    u_xlat0.xyz = u_xlat16_1.xyz * _TintColor.xyz + u_xlat0.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * vs_COLOR0.xyz;
					    u_xlat0 = u_xlat0 * vec4(_Emission);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _MainMaskTex_ST.xy + _MainMaskTex_ST.zw;
					    u_xlat10_1 = texture2D(_MainMaskTex, u_xlat1.xy);
					    SV_Target0 = u_xlat0 * u_xlat10_1;
					    return;
					}
					
					#endif"
				}
			}
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