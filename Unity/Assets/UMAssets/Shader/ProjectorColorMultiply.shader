Shader "Projector/ColorMultiply" {
	Properties {
		_ShadowTex ("Cookie", 2D) = "gray" {}
		_FalloffTex ("FallOff", 2D) = "white" {}
		_MainColor ("MainColor", Vector) = (0,0,0,1)
	}
	SubShader {
		Tags { "QUEUE" = "Transparent" }
		Pass {
			Tags { "QUEUE" = "Transparent" }
			Blend DstColor Zero, DstColor Zero
			ColorMask RGB -1
			ZWrite Off
			Offset -1, -1
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
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
			};

			sampler2D _ShadowTex;
			sampler2D _FalloffTex;
			float4 _ShadowTex_ST;
			float4 _FalloffTex_ST;
			float4 _MainColor;
			float4x4 unity_Projector;
			float4x4 unity_ProjectorClip;


			v2f vert(appdata v)
			{
				v2f o;

				o.texcoord0 = mul(unity_Projector, v.position0);
				o.texcoord0 = mul(unity_ProjectorClip, v.position0);
				o.position0 = UnityObjectToClipPos(v.position0);
				return o; 
			}
/*			GpuProgramID 27322
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 hlslcc_mtx4x4unity_Projector[4];
					uniform 	vec4 hlslcc_mtx4x4unity_ProjectorClip[4];
					attribute highp vec4 in_POSITION0;
					varying highp vec4 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_Projector[1];
					    u_xlat0 = hlslcc_mtx4x4unity_Projector[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_Projector[2] * in_POSITION0.zzzz + u_xlat0;
					    vs_TEXCOORD0 = hlslcc_mtx4x4unity_Projector[3] * in_POSITION0.wwww + u_xlat0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ProjectorClip[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ProjectorClip[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ProjectorClip[2] * in_POSITION0.zzzz + u_xlat0;
					    vs_TEXCOORD1 = hlslcc_mtx4x4unity_ProjectorClip[3] * in_POSITION0.wwww + u_xlat0;
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
					    return;
					}
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 u_xlat10_0, u_xlat0, SV_Target0, u_xlat3, u_xlat10_1, u_xlat1, u_xlat16_2;
				u_xlat0.xy = i.texcoord1.xy / i.texcoord1.ww;
				u_xlat10_0 = tex2D(_FalloffTex, u_xlat0.xy).w;
				u_xlat3.xy = i.texcoord0.xy / i.texcoord0.ww;
				u_xlat10_1 = tex2D(_ShadowTex, u_xlat3.xy);
				u_xlat1 = _MainColor * u_xlat10_1.wwww + u_xlat10_1;
				u_xlat16_2.xyz = u_xlat1.xyz + float3(-1.0, -1.0, -1.0);
				u_xlat16_2.w = (-u_xlat1.w) + 1.0;
				SV_Target0 = float4(u_xlat10_0) * u_xlat16_2 + float4(1.0, 1.0, 1.0, 0.0);
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
					uniform lowp sampler2D _ShadowTex;
					uniform lowp sampler2D _FalloffTex;
					varying highp vec4 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					#define SV_Target0 gl_FragData[0]
					vec2 u_xlat0;
					lowp float u_xlat10_0;
					vec4 u_xlat1;
					lowp vec4 u_xlat10_1;
					mediump vec4 u_xlat16_2;
					vec2 u_xlat3;
					void main()
					{
					    u_xlat0.xy = vs_TEXCOORD1.xy / vs_TEXCOORD1.ww;
					    u_xlat10_0 = texture2D(_FalloffTex, u_xlat0.xy).w;
					    u_xlat3.xy = vs_TEXCOORD0.xy / vs_TEXCOORD0.ww;
					    u_xlat10_1 = texture2D(_ShadowTex, u_xlat3.xy);
					    u_xlat1 = _MainColor * u_xlat10_1.wwww + u_xlat10_1;
					    u_xlat16_2.xyz = u_xlat1.xyz + vec3(-1.0, -1.0, -1.0);
					    u_xlat16_2.w = (-u_xlat1.w) + 1.0;
					    SV_Target0 = vec4(u_xlat10_0) * u_xlat16_2 + vec4(1.0, 1.0, 1.0, 0.0);
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
}