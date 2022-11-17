Shader "Adv/Effect/AdditiveOverlay" {
	Properties {
		_MainTex ("MainTex (RGB)", 2D) = "white" {}
		_PatternTex ("PatternTex (RGB)", 2D) = "white" {}
		_MainColor ("MainColor", Vector) = (1,1,1,1)
		_Power ("Power", Float) = 1
	}
	SubShader {
		Tags { "QUEUE" = "Transparent" }
		Pass {
			Tags { "QUEUE" = "Transparent" }
			Blend One One, One One
			ZWrite Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 position0 : POSITION;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
			};

			v2f vert(appdata v)
			{
				v2f o;

				o.position0 = UnityObjectToClipPos(v.position0);

				return o;
			}
			/*
			GpuProgramID 10318
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _PatternTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute mediump vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCORRD1;
					varying mediump vec4 vs_COLOR0;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _PatternTex_ST.xy + _PatternTex_ST.zw;
					    phase0_Output0_1 = u_xlat0;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCORRD1 = phase0_Output0_1.zw;
					    return;
					}
						
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 SV_Target0;
				SV_Target0 = float4(1, 0, 1, 1);
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
					uniform 	vec4 _MainColor;
					uniform 	float _Power;
					uniform lowp sampler2D _PatternTex;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCORRD1;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp vec3 u_xlat10_0;
					vec4 u_xlat1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat10_0.xyz = texture2D(_PatternTex, vs_TEXCORRD1.xy).xyz;
					    u_xlat1 = texture2D(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_2.xyz = u_xlat10_0.xyz * u_xlat1.xyz;
					    u_xlat0.xyz = u_xlat16_2.xyz * _MainColor.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * vec3(_Power);
					    u_xlat1.xyz = u_xlat0.xyz * vs_COLOR0.www;
					    u_xlat1.xyz = clamp(u_xlat1.xyz, 0.0, 1.0);
					    SV_Target0 = u_xlat1;
					    return;
					}
					
					#endif"
				}
			}
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES"
				}
			}
*/
			ENDCG
		}
	}
	Fallback "Diffuse"
}