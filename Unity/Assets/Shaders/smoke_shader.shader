Shader "Shader Forge/smoke_Shader" {
	Properties {
		_tex_color ("tex_color", 2D) = "black" {}
		_tex_mask ("tex_mask", 2D) = "black" {}
		_smoke_speed ("smoke_speed", Float) = 1
		_mask_offset ("mask_offset", Range(0, 1)) = 0.3
		[HideInInspector] _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Name "FORWARD"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" "SHADOWSUPPORT" = "true" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 position0 : POSITION;
				float4 color0 : COLOR;
				float2 texcoord0 : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float4 color0 : COLOR0;
			};

			sampler2D _tex_color;
			float4 _tex_color_ST;
			sampler2D _tex_mask;
			float4 _tex_mask_ST;
			float _smoke_speed;
			float _mask_offset;
			float2 _TimeEditor;


			v2f vert(appdata v)
			{
				v2f o;
				o.texcoord0 = v.texcoord0;
				o.texcoord1 = v.texcoord1;
				o.position0 = UnityObjectToClipPos(v.position0);
				o.color0 = v.color0;
				return o; 
			}
/*
			GpuProgramID 3814
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTPROBE_SH" "VERTEXLIGHT_ON" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec2 in_TEXCOORD1;
					attribute highp vec4 in_COLOR0;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec2 vs_TEXCOORD1;
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
					    vs_TEXCOORD1.xy = in_TEXCOORD1.xy;
					    vs_COLOR0 = in_COLOR0;
					    return;
					}
					
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 SV_Target0, u_xlat10_1;
				float2 u_xlat0, u_xlat2;
				float u_xlat10_0;
				u_xlat0.xy = float2(_mask_offset, _mask_offset) * float2(0.0, -1.0) + i.texcoord1.xy;
				u_xlat0.xy = u_xlat0.xy * _tex_mask_ST.xy + _tex_mask_ST.zw;
				u_xlat10_0 = tex2D(_tex_mask, u_xlat0.xy).x;
				u_xlat2.x = _Time.y + _TimeEditor.y;
				u_xlat2.x = u_xlat2.x * _smoke_speed;
				u_xlat2.xy = u_xlat2.xx * float2(0.0, 1.0) + i.texcoord0.xy;
				u_xlat2.xy = u_xlat2.xy * _tex_color_ST.xy + _tex_color_ST.zw;
				u_xlat10_1 = tex2D(_tex_color, u_xlat2.xy);
				SV_Target0.w = u_xlat10_0 * u_xlat10_1.w;
				SV_Target0.xyz = u_xlat10_1.xyz * i.color0.xyz;
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
					uniform 	vec4 _Time;
					uniform 	vec4 _TimeEditor;
					uniform 	vec4 _tex_color_ST;
					uniform 	vec4 _tex_mask_ST;
					uniform 	float _smoke_speed;
					uniform 	float _mask_offset;
					uniform lowp sampler2D _tex_color;
					uniform lowp sampler2D _tex_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec2 vs_TEXCOORD1;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec2 u_xlat0;
					lowp float u_xlat10_0;
					lowp vec4 u_xlat10_1;
					vec2 u_xlat2;
					void main()
					{
					    u_xlat0.xy = vec2(vec2(_mask_offset, _mask_offset)) * vec2(0.0, -1.0) + vs_TEXCOORD1.xy;
					    u_xlat0.xy = u_xlat0.xy * _tex_mask_ST.xy + _tex_mask_ST.zw;
					    u_xlat10_0 = texture2D(_tex_mask, u_xlat0.xy).x;
					    u_xlat2.x = _Time.y + _TimeEditor.y;
					    u_xlat2.x = u_xlat2.x * _smoke_speed;
					    u_xlat2.xy = u_xlat2.xx * vec2(0.0, 1.0) + vs_TEXCOORD0.xy;
					    u_xlat2.xy = u_xlat2.xy * _tex_color_ST.xy + _tex_color_ST.zw;
					    u_xlat10_1 = texture2D(_tex_color, u_xlat2.xy);
					    SV_Target0.w = u_xlat10_0 * u_xlat10_1.w;
					    SV_Target0.xyz = u_xlat10_1.xyz * vs_COLOR0.xyz;
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
	Fallback "Diffuse"
	CustomEditor "ShaderForgeMaterialInspector"
}