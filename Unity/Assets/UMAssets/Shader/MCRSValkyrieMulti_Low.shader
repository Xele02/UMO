Shader "MCRS/ValkyrieMulti_Low" {
	Properties {
		_VAL_col ("VAL_col", 2D) = "white" {}
		_Saturationpower ("Saturation (power)", Range(0, 2)) = 1
		_DamageColor ("DamageColor", Vector) = (0,0,0,1)
		_MuzzleColor ("MuzzleColor", Vector) = (0.5,0.5,0.5,1)
		_VAL_col2 ("VAL_col2", 2D) = "white" {}
		_VAL_mask2 ("VAL_mask2", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType" = "Opaque" }
		Pass {
			Name "FORWARD"
			Tags { "LIGHTMODE" = "FORWARDBASE" "RenderType" = "Opaque" "SHADOWSUPPORT" = "true" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 position0 : POSITION;
				float3 normal0 : NORMAL;
				float2 texcoord0 : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
			};

			sampler2D _VAL_col;
			float4 _VAL_col_ST;
			sampler2D _VAL_col2;
			sampler2D _VAL_mask2;
			float4 _VAL_mask2_ST;
			float4 _VAL_col2_ST;
			float4 _DamageColor;
			float4 _MuzzleColor;
			float _Saturationpower;

			v2f vert(appdata v)
			{
				v2f o;

				o.texcoord0 = v.texcoord0;
				o.texcoord1 = v.texcoord1;

				float4 normal;
				normal.xyz = v.normal0;
				normal.w = 0;
				o.texcoord2 = normalize((mul(unity_ObjectToWorld,normal)).xyz);

				o.position0 = UnityObjectToClipPos(v.position0);
				return o; 
			}
/*
			GpuProgramID 53661
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTPROBE_SH" "VERTEXLIGHT_ON" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_WorldToObject[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					attribute highp vec4 in_POSITION0;
					attribute highp vec3 in_NORMAL0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec2 in_TEXCOORD1;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec2 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat6;
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
					    vs_TEXCOORD1.xy = in_TEXCOORD1.xy;
					    u_xlat0.x = dot(in_NORMAL0.xyz, hlslcc_mtx4x4unity_WorldToObject[0].xyz);
					    u_xlat0.y = dot(in_NORMAL0.xyz, hlslcc_mtx4x4unity_WorldToObject[1].xyz);
					    u_xlat0.z = dot(in_NORMAL0.xyz, hlslcc_mtx4x4unity_WorldToObject[2].xyz);
					    u_xlat6 = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat6 = inversesqrt(u_xlat6);
					    vs_TEXCOORD2.xyz = vec3(u_xlat6) * u_xlat0.xyz;
					    return;
					}
					
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 u_xlat0, SV_Target0, u_xlat2, u_xlat10_2, u_xlat1, u_xlat10_1, u_xlat16_2, u_xlat16_0;
				float u_xlat6, u_xlat10_0;
				u_xlat0.xy = i.texcoord1.xy * _VAL_mask2_ST.xy + _VAL_mask2_ST.zw;
				u_xlat10_0 = tex2D(_VAL_mask2, u_xlat0.xy).x;
				u_xlat2.xy = i.texcoord1.xy * _VAL_col2_ST.xy + _VAL_col2_ST.zw;
				u_xlat10_2.xyz = tex2D(_VAL_col2, u_xlat2.xy).xyz;
				u_xlat1.xy = i.texcoord0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
				u_xlat10_1.xyz = tex2D(_VAL_col, u_xlat1.xy).xyz;
				u_xlat16_2.xyz = u_xlat10_2.xyz + (-u_xlat10_1.xyz);
				u_xlat16_0.xyz = float3(u_xlat10_0, u_xlat10_0, u_xlat10_0) * u_xlat16_2.xyz + u_xlat10_1.xyz;
				u_xlat16_0.xyz = log2(u_xlat16_0.xyz);
				u_xlat0.xyz = u_xlat16_0.xyz * float3(_Saturationpower, _Saturationpower, _Saturationpower);
				u_xlat0.xyz = exp2(u_xlat0.xyz);
				u_xlat1.xyz = _DamageColor.www * _DamageColor.xyz;
				u_xlat0.xyz = u_xlat0.xyz * float3(1.29999995, 1.29999995, 1.29999995) + u_xlat1.xyz;
				u_xlat6 = dot(i.texcoord2.xyz, i.texcoord2.xyz);
				u_xlat6 = rsqrt(u_xlat6);
				u_xlat1.xyz = float3(u_xlat6, u_xlat6, u_xlat6) * i.texcoord2.xyz;
				u_xlat6 = dot(float3(0.5, -0.300000012, 1.0), u_xlat1.xyz);
				u_xlat6 = max(u_xlat6, 0.0);
				u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
				SV_Target0.xyz = u_xlat1.xyz * float3(u_xlat6, u_xlat6, u_xlat6) + u_xlat0.xyz;
				SV_Target0.w = 1.0;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Saturationpower;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform 	vec4 _VAL_col2_ST;
					uniform 	vec4 _VAL_mask2_ST;
					uniform lowp sampler2D _VAL_col;
					uniform lowp sampler2D _VAL_col2;
					uniform lowp sampler2D _VAL_mask2;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec2 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_0;
					lowp float u_xlat10_0;
					vec3 u_xlat1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					float u_xlat6;
					void main()
					{
					    u_xlat0.xy = vs_TEXCOORD1.xy * _VAL_mask2_ST.xy + _VAL_mask2_ST.zw;
					    u_xlat10_0 = texture2D(_VAL_mask2, u_xlat0.xy).x;
					    u_xlat2.xy = vs_TEXCOORD1.xy * _VAL_col2_ST.xy + _VAL_col2_ST.zw;
					    u_xlat10_2.xyz = texture2D(_VAL_col2, u_xlat2.xy).xyz;
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz + (-u_xlat10_1.xyz);
					    u_xlat16_0.xyz = vec3(u_xlat10_0) * u_xlat16_2.xyz + u_xlat10_1.xyz;
					    u_xlat16_0.xyz = log2(u_xlat16_0.xyz);
					    u_xlat0.xyz = u_xlat16_0.xyz * vec3(_Saturationpower);
					    u_xlat0.xyz = exp2(u_xlat0.xyz);
					    u_xlat1.xyz = _DamageColor.www * _DamageColor.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * vec3(1.29999995, 1.29999995, 1.29999995) + u_xlat1.xyz;
					    u_xlat6 = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat6 = inversesqrt(u_xlat6);
					    u_xlat1.xyz = vec3(u_xlat6) * vs_TEXCOORD2.xyz;
					    u_xlat6 = dot(vec3(0.5, -0.300000012, 1.0), u_xlat1.xyz);
					    u_xlat6 = max(u_xlat6, 0.0);
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * vec3(u_xlat6) + u_xlat0.xyz;
					    SV_Target0.w = 1.0;
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
	//CustomEditor "ShaderForgeMaterialInspector"
}