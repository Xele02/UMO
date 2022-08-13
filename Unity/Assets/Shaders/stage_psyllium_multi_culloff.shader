Shader "MCRS/Stage/PsylliumMulti_CullOff" {
	Properties {
		_MainColorTex ("MainColorTex", 2D) = "white" {}
		_MainAlphaTex ("MainAlphaTex", 2D) = "white" {}
		_PsylliumTex ("PsylliumTex", 2D) = "white" {}
		_PsylliumMaskTex ("PsylliumMaskTex", 2D) = "white" {}
		_Color1 ("Main Color1", Vector) = (1,1,1,1)
		_Color2 ("Main Color2", Vector) = (1,1,1,1)
		_Color3 ("Main Color3", Vector) = (1,1,1,1)
		_Power ("Power", Float) = 1
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
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

			sampler2D _MainColorTex;
			float4 _MainColorTex_ST;
			sampler2D _MainAlphaTex;
			float4 _MainAlphaTex_ST;
			sampler2D _PsylliumTex;
			float4 _PsylliumTex_ST;
			sampler2D _PsylliumMaskTex;
			float4 _PsylliumMaskTex_ST;
			float4 _Color1;
			float4 _Color2;
			float4 _Color3;
			float _Power;


			v2f vert(appdata v)
			{
				v2f o;
				o.texcoord0 = TRANSFORM_TEX(v.texcoord0, _MainColorTex);
				o.position0 = UnityObjectToClipPos(v.position0);
				o.color0 = v.color0;
				return o; 
			}
/*			GpuProgramID 23901
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainColorTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec4 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR1;
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainColorTex_ST.xy + _MainColorTex_ST.zw;
					    vs_COLOR1 = in_COLOR0;
					    return;
					}
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 u_xlat10_0, u_xlat1, u_xlat0, SV_Target0, u_xlat10_1, u_xlat10_2;
				u_xlat10_0.xyz = tex2D(_PsylliumMaskTex, i.texcoord0.xy).xyz;
				u_xlat1.xyz = u_xlat10_0.yyy * _Color2.xyz;
				u_xlat0.xyw = _Color1.xyz * u_xlat10_0.xxx + u_xlat1.xyz;
				u_xlat0.xyz = _Color3.xyz * u_xlat10_0.zzz + u_xlat0.xyw;
				u_xlat10_1.xyz = tex2D(_MainColorTex, i.texcoord0.xy).xyz;
				SV_Target0.xyz = u_xlat10_1.xyz * i.color0.xyz + u_xlat0.xyz;
				u_xlat10_0.x = tex2D(_MainAlphaTex, i.texcoord0.xy).x;
				u_xlat10_2 = tex2D(_PsylliumTex, i.texcoord0.xy).x;
				SV_Target0.w = u_xlat10_2 * _Power + u_xlat10_0.x;
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
					uniform 	vec4 _Color1;
					uniform 	vec4 _Color2;
					uniform 	vec4 _Color3;
					uniform 	float _Power;
					uniform lowp sampler2D _MainColorTex;
					uniform lowp sampler2D _MainAlphaTex;
					uniform lowp sampler2D _PsylliumTex;
					uniform lowp sampler2D _PsylliumMaskTex;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR1;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					lowp vec3 u_xlat10_0;
					vec3 u_xlat1;
					lowp vec3 u_xlat10_1;
					lowp float u_xlat10_2;
					void main()
					{
					    u_xlat10_0.xyz = texture2D(_PsylliumMaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat1.xyz = u_xlat10_0.yyy * _Color2.xyz;
					    u_xlat0.xyw = _Color1.xyz * u_xlat10_0.xxx + u_xlat1.xyz;
					    u_xlat0.xyz = _Color3.xyz * u_xlat10_0.zzz + u_xlat0.xyw;
					    u_xlat10_1.xyz = texture2D(_MainColorTex, vs_TEXCOORD0.xy).xyz;
					    SV_Target0.xyz = u_xlat10_1.xyz * vs_COLOR1.xyz + u_xlat0.xyz;
					    u_xlat10_0.x = texture2D(_MainAlphaTex, vs_TEXCOORD0.xy).x;
					    u_xlat10_2 = texture2D(_PsylliumTex, vs_TEXCOORD0.xy).x;
					    SV_Target0.w = u_xlat10_2 * _Power + u_xlat10_0.x;
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