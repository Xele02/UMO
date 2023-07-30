Shader "Adv/Effect/AdditiveTransparent" {
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
				float2 texcoord0 : TEXCOORD0;
				float4 color0 : COLOR0;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float4 color0 : COLOR0;
			};

			sampler2D _MainTex;
			sampler2D _PatternTex;
			float4 _MainTex_ST;
			float _Power;
			float4 _MainColor;

			v2f vert(appdata v)
			{
				v2f o;
				o.texcoord0 = TRANSFORM_TEX(v.texcoord0, _MainTex);
				o.position0 = UnityObjectToClipPos(v.position0);
				o.color0 = v.color0;
				return o; 
			}

/*
			GpuProgramID 64253
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute mediump vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
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
					    vs_TEXCOORD0.xy = u_xlat0.xy;
					    vs_COLOR0 = in_COLOR0;
					    return;
					}
					
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 u_xlat10_0, u_xlat16_2, u_xlat1, u_xlat0;
				u_xlat10_0.xyz = tex2D(_PatternTex, i.texcoord0.xy).xyz;
				u_xlat1 = tex2D(_MainTex, i.texcoord0.xy);
				u_xlat16_2.xyz = u_xlat10_0.xyz * u_xlat1.xyz;
				u_xlat0.xyz = u_xlat16_2.xyz * _MainColor.xyz;
				u_xlat0.xyz = u_xlat0.xyz * float3(_Power, _Power, _Power);
				u_xlat1.xyz = u_xlat0.xyz * i.color0.www;
				u_xlat1.xyz = clamp(u_xlat1.xyz, 0.0, 1.0);
				float4 SV_Target0 = u_xlat1;
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
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp vec3 u_xlat10_0;
					vec4 u_xlat1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat10_0.xyz = texture2D(_PatternTex, vs_TEXCOORD0.xy).xyz;
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