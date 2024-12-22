Shader "MCRS/Costume/ChangeBlend" {
	Properties {
		_BeforeTex ("BeforeTex", 2D) = "white" {}
		_AfterTex ("AfterTex", 2D) = "white" {}
		_PrizumTex ("PrizumTex", 2D) = "white" {}
		_Threthold ("Threthold", Float) = 1
		_BlendFadeWidth ("_BlendFadeWidth", Float) = 1
		_EffectBeforeWidth ("_EffectBeforeWidth", Float) = 1
		_EffectAfterWidth ("_EffectAfterWidth", Float) = 1
		_EffectPower ("EffectPower", Float) = 2
		_EffectOrigin ("EffectOrigin", Float) = 1
		_MainTex ("DiffuseTex", 2D) = "white" {}
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" "SHADOWSUPPORT" = "true" }
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
				float2 texcoord0 : TEXCOORD0;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
			};

			sampler2D _BeforeTex;
			float4 _BeforeTex_ST;
			sampler2D _PrizumTex;
			float4 _PrizumTex_ST;
			sampler2D _AfterTex;
			float _EffectBeforeWidth;
			float _EffectAfterWidth;
			float _Threthold;
			float _BlendFadeWidth;
			float _EffectPower;
			float _EffectOrigin;
			sampler2D _MainTex;
			
			v2f vert(appdata v)
			{
				v2f o;
				o.position0 = UnityObjectToClipPos(v.position0);
				o.texcoord0 = TRANSFORM_TEX(v.texcoord0, _BeforeTex);
				o.texcoord1 = TRANSFORM_TEX(v.texcoord0, _PrizumTex);
				return o; 
			}
/*
			GpuProgramID 7701
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTPROBE_SH" "VERTEXLIGHT_ON" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _BeforeTex_ST;
					uniform 	vec4 _PrizumTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec4 in_TEXCOORD0;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec2 vs_TEXCOORD1;
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _BeforeTex_ST.xy + _BeforeTex_ST.zw;
					    vs_TEXCOORD1.xy = in_TEXCOORD0.xy * _PrizumTex_ST.xy + _PrizumTex_ST.zw;
					    return;
					}
					
					
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 u_xlat0;
				bool u_xlatb15;
				float u_xlat16_1;
				float2 u_xlat16_6;
				bool u_xlatb5;
				float u_xlat16_11;
				float u_xlat4;
				float4 u_xlat10_0, u_xlat2, u_xlat3, u_xlat16_3, u_xlat16_2, u_xlat16_0;
				u_xlat0.x = i.texcoord0.y + (-_Threthold);
				u_xlat0.x = -abs(u_xlat0.x) + 1.0;
				u_xlat0.x = log2(u_xlat0.x);
				u_xlat0.xyz = u_xlat0.xxx * float3(_EffectBeforeWidth, _EffectAfterWidth, _BlendFadeWidth);
				u_xlat0.xyz = exp2(u_xlat0.xyz);
				u_xlatb15 = i.texcoord0.y<_Threthold;
				u_xlat16_1 = (u_xlatb15) ? 1.0 : 0.0;
				u_xlat16_6.x = u_xlat0.z + u_xlat16_1;
				u_xlat16_1 = u_xlat0.y * u_xlat16_1;
				u_xlatb5 = _Threthold<i.texcoord0.y;
				u_xlat16_11 = (u_xlatb5) ? 1.0 : 0.0;
				u_xlat16_1 = u_xlat16_11 * u_xlat0.x + u_xlat16_1;
				u_xlat16_6.y = u_xlat0.z + u_xlat16_11;
				u_xlat16_6.xy = min(u_xlat16_6.xy, float2(1.0, 1.0));
				u_xlat10_0 = tex2D(_PrizumTex, i.texcoord1.xy);
				u_xlat16_0 = u_xlat10_0 * float4(u_xlat16_1, u_xlat16_1, u_xlat16_1, u_xlat16_1);
				u_xlat0 = u_xlat16_0 * float4(_EffectPower, _EffectPower, _EffectPower, _EffectPower);
				u_xlat2 = tex2D(_BeforeTex, i.texcoord0.xy);
				u_xlat3 = tex2D(_AfterTex, i.texcoord0.xy);
				u_xlat16_1 = u_xlat2.w + u_xlat3.w;
				u_xlat4 = u_xlat0.w * u_xlat16_1;
				u_xlat3.xyz = (-float3(u_xlat4, u_xlat4, u_xlat4)) * float3(float3(_EffectOrigin, _EffectOrigin, _EffectOrigin)) + u_xlat3.xyz;
				u_xlat2.xyz = (-float3(u_xlat4, u_xlat4, u_xlat4)) * float3(float3(_EffectOrigin, _EffectOrigin, _EffectOrigin)) + u_xlat2.xyz;
				u_xlat16_3 = u_xlat16_6.xxxx * u_xlat3;
				u_xlat16_2 = u_xlat2 * u_xlat16_6.yyyy + u_xlat16_3;
				u_xlat16_0 = u_xlat0 * float4(u_xlat16_1, u_xlat16_1, u_xlat16_1, u_xlat16_1) + u_xlat16_2;
				float4 SV_Target0 = u_xlat16_0;
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
					uniform 	float _Threthold;
					uniform 	float _BlendFadeWidth;
					uniform 	float _EffectBeforeWidth;
					uniform 	float _EffectAfterWidth;
					uniform 	float _EffectPower;
					uniform 	float _EffectOrigin;
					uniform lowp sampler2D _BeforeTex;
					uniform lowp sampler2D _AfterTex;
					uniform lowp sampler2D _PrizumTex;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec2 vs_TEXCOORD1;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					mediump float u_xlat16_1;
					vec4 u_xlat2;
					mediump vec4 u_xlat16_2;
					vec4 u_xlat3;
					mediump vec4 u_xlat16_3;
					float u_xlat4;
					bool u_xlatb5;
					mediump vec2 u_xlat16_6;
					mediump float u_xlat16_11;
					bool u_xlatb15;
					void main()
					{
					    u_xlat0.x = vs_TEXCOORD0.y + (-_Threthold);
					    u_xlat0.x = -abs(u_xlat0.x) + 1.0;
					    u_xlat0.x = log2(u_xlat0.x);
					    u_xlat0.xyz = u_xlat0.xxx * vec3(_EffectBeforeWidth, _EffectAfterWidth, _BlendFadeWidth);
					    u_xlat0.xyz = exp2(u_xlat0.xyz);
					    u_xlatb15 = vs_TEXCOORD0.y<_Threthold;
					    u_xlat16_1 = (u_xlatb15) ? 1.0 : 0.0;
					    u_xlat16_6.x = u_xlat0.z + u_xlat16_1;
					    u_xlat16_1 = u_xlat0.y * u_xlat16_1;
					    u_xlatb5 = _Threthold<vs_TEXCOORD0.y;
					    u_xlat16_11 = (u_xlatb5) ? 1.0 : 0.0;
					    u_xlat16_1 = u_xlat16_11 * u_xlat0.x + u_xlat16_1;
					    u_xlat16_6.y = u_xlat0.z + u_xlat16_11;
					    u_xlat16_6.xy = min(u_xlat16_6.xy, vec2(1.0, 1.0));
					    u_xlat10_0 = texture2D(_PrizumTex, vs_TEXCOORD1.xy);
					    u_xlat16_0 = u_xlat10_0 * vec4(u_xlat16_1);
					    u_xlat0 = u_xlat16_0 * vec4(_EffectPower);
					    u_xlat2 = texture2D(_BeforeTex, vs_TEXCOORD0.xy);
					    u_xlat3 = texture2D(_AfterTex, vs_TEXCOORD0.xy);
					    u_xlat16_1 = u_xlat2.w + u_xlat3.w;
					    u_xlat4 = u_xlat0.w * u_xlat16_1;
					    u_xlat3.xyz = (-vec3(u_xlat4)) * vec3(vec3(_EffectOrigin, _EffectOrigin, _EffectOrigin)) + u_xlat3.xyz;
					    u_xlat2.xyz = (-vec3(u_xlat4)) * vec3(vec3(_EffectOrigin, _EffectOrigin, _EffectOrigin)) + u_xlat2.xyz;
					    u_xlat16_3 = u_xlat16_6.xxxx * u_xlat3;
					    u_xlat16_2 = u_xlat2 * u_xlat16_6.yyyy + u_xlat16_3;
					    u_xlat16_0 = u_xlat0 * vec4(u_xlat16_1) + u_xlat16_2;
					    SV_Target0 = u_xlat16_0;
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