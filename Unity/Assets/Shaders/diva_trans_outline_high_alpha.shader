Shader "MCRS/Diva/Trans_Outline_High_Alpha" {
	Properties {
		_MainTex ("DiffuseTex", 2D) = "white" {}
		_Color ("Main Color", Vector) = (1,1,1,1)
		_RimColor ("Rim Color", Vector) = (1,1,1,1)
		_RimLightPower ("RimLight Power", Float) = 1
		_RimLightSampler ("RimLight Control", 2D) = "white" {}
		_EdgeThickness ("Outline Thickness", Float) = 1
		_EdgeBrightness ("Outline Brightness ", Float) = 2
		_Alpha ("Alpha", Range(0, 1)) = 0
	}
	SubShader {
		Tags { "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			ColorMask 0
			Fog {
				Mode Off
			}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 position0 : POSITION;
				float4 color0 : COLOR0;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float4 color0 : COLOR0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.color0 = clamp(v.color0, 0, 1);
				o.position0 = UnityObjectToClipPos(v.position0);
				return o; 
			}
/*			GpuProgramID 142911
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					attribute highp vec3 in_POSITION0;
					attribute mediump vec4 in_COLOR0;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_COLOR0 = in_COLOR0;
					    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}
*/
			fixed4 frag(v2f i) : SV_Target
			{
				return i.color0;
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
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					void main()
					{
					    SV_Target0 = vs_COLOR0;
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
			}*/
			ENDCG
		}
		Pass {
			Tags { "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" "SHADOWSUPPORT" = "true" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			Stencil {
				Ref 128
				WriteMask 128
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 position0 : POSITION;
				float3 normal0 : NORMAL;
				float2 texcoord0 : TEXCOORD0;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float3 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
			};

			sampler2D _MainTex;
			sampler2D _AlphaTex;
			sampler2D _RimLightSampler;
			float4 _MainTex_ST;
			float4 _Color;
			float4 _RimColor;
			float _RimLightPower;
			float _Alpha;


			v2f vert(appdata v)
			{
				v2f o;

				o.texcoord0 = TRANSFORM_TEX(v.texcoord0, _MainTex);

				float4 worldpos = mul(unity_ObjectToWorld,v.position0);
				o.texcoord1 = normalize((_WorldSpaceCameraPos - worldpos.xyz));

				float4 normal;
				normal.xyz = v.normal0;
				normal.w = 0;
				o.texcoord2 = normalize((mul(unity_ObjectToWorld,normal)).xyz);

				o.position0 = UnityObjectToClipPos(v.position0);
				return o; 
			}
/*			GpuProgramID 49483
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec3 _WorldSpaceCameraPos;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec3 in_NORMAL0;
					attribute highp vec4 in_TEXCOORD0;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec3 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec4 u_xlat2;
					float u_xlat9;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat1 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat0.xyz = hlslcc_mtx4x4unity_ObjectToWorld[3].xyz * in_POSITION0.www + u_xlat0.xyz;
					    u_xlat0.xyz = (-u_xlat0.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat2 = u_xlat1.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat1.xxxx + u_xlat2;
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat1.zzzz + u_xlat2;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat1.wwww + u_xlat2;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat9 = inversesqrt(u_xlat9);
					    vs_TEXCOORD1.xyz = vec3(u_xlat9) * u_xlat0.xyz;
					    u_xlat0.xyz = in_NORMAL0.yyy * hlslcc_mtx4x4unity_ObjectToWorld[1].xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_ObjectToWorld[0].xyz * in_NORMAL0.xxx + u_xlat0.xyz;
					    u_xlat0.xyz = hlslcc_mtx4x4unity_ObjectToWorld[2].xyz * in_NORMAL0.zzz + u_xlat0.xyz;
					    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat9 = inversesqrt(u_xlat9);
					    vs_TEXCOORD2.xyz = vec3(u_xlat9) * u_xlat0.xyz;
					    return;
					}
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 u_xlat16_0, u_xlat16_1, u_xlat10_0, SV_Target0, u_xlat10_2, u_xlat0, u_xlat10_3;
				u_xlat16_0 = dot(i.texcoord2.xyz, i.texcoord1.xyz);
				u_xlat16_1.x = -abs(u_xlat16_0) + 1.0;
				u_xlat16_1.x = max(u_xlat16_1.x, 0.0199999996);
				u_xlat16_1.x = min(u_xlat16_1.x, 0.980000019);
				u_xlat16_1.y = 0.5;
				u_xlat10_0 = tex2D(_RimLightSampler, u_xlat16_1.xy).y;
				u_xlat0.x = u_xlat10_0 * _RimLightPower;
				u_xlat10_3 = tex2D(_RimLightSampler, i.texcoord0.xy).x;
				u_xlat16_1.x = u_xlat10_3 * u_xlat0.x;
				u_xlat0.xyz = u_xlat16_1.xxx * _RimColor.xyz;
				u_xlat10_2.xyz = tex2D(_MainTex, i.texcoord0.xy).xyz;
				SV_Target0.xyz = u_xlat10_2.xyz * _Color.xyz + u_xlat0.xyz;
				SV_Target0.xyz = clamp(SV_Target0.xyz, 0.0, 1.0);
				SV_Target0.w = _Alpha;
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
					uniform 	vec4 _Color;
					uniform 	vec4 _RimColor;
					uniform 	float _RimLightPower;
					uniform 	float _Alpha;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _RimLightSampler;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec3 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump float u_xlat16_0;
					lowp float u_xlat10_0;
					mediump vec2 u_xlat16_1;
					lowp vec3 u_xlat10_2;
					lowp float u_xlat10_3;
					void main()
					{
					    u_xlat16_0 = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD1.xyz);
					    u_xlat16_1.x = -abs(u_xlat16_0) + 1.0;
					    u_xlat16_1.x = max(u_xlat16_1.x, 0.0199999996);
					    u_xlat16_1.x = min(u_xlat16_1.x, 0.980000019);
					    u_xlat16_1.y = 0.5;
					    u_xlat10_0 = texture2D(_RimLightSampler, u_xlat16_1.xy).y;
					    u_xlat0.x = u_xlat10_0 * _RimLightPower;
					    u_xlat10_3 = texture2D(_RimLightSampler, vs_TEXCOORD0.xy).x;
					    u_xlat16_1.x = u_xlat10_3 * u_xlat0.x;
					    u_xlat0.xyz = u_xlat16_1.xxx * _RimColor.xyz;
					    u_xlat10_2.xyz = texture2D(_MainTex, vs_TEXCOORD0.xy).xyz;
					    SV_Target0.xyz = u_xlat10_2.xyz * _Color.xyz + u_xlat0.xyz;
					    SV_Target0.xyz = clamp(SV_Target0.xyz, 0.0, 1.0);
					    SV_Target0.w = _Alpha;
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
			}*/
			ENDCG
		}
		Pass {
			Tags { "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			Cull Front
			Stencil {
				Ref 128
				WriteMask 128
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 position0 : POSITION;
				float3 normal0 : NORMAL;
				float2 texcoord0 : TEXCOORD0;
				float4 color0 : COLOR0;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;
			float _EdgeBrightness;
			float _EdgeThickness;
			float _Alpha;


			v2f vert(appdata v)
			{
				v2f o;

				o.texcoord0 = v.texcoord0;
				float4 screenvertex = UnityObjectToClipPos(v.position0);
				float4 projSpacePos;
				projSpacePos.zw = screenvertex.zw;
				float4 normaldir;
				normaldir.w = 0.0;
				normaldir.xyz = v.normal0;
				float zbias = float(clamp ((screenvertex.z * 0.1), 0.5, 1.0));
				float4 scaledNormal = (((
					(v.color0.x * _EdgeThickness)
					* 0.00285) * normalize(
					(UnityObjectToClipPos(float4(normaldir)))
				)) * zbias);
				projSpacePos.xy = (screenvertex.xy + scaledNormal.xy);
				o.position0 = projSpacePos;
				return o; 
			}
/*			GpuProgramID 99687
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	float _EdgeThickness;
					attribute highp vec4 in_POSITION0;
					attribute highp vec3 in_NORMAL0;
					attribute highp vec4 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying highp vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec4 u_xlat2;
					mediump float u_xlat16_3;
					float u_xlat9;
					void main()
					{
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[1].yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[0] * hlslcc_mtx4x4unity_ObjectToWorld[1].xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[2] * hlslcc_mtx4x4unity_ObjectToWorld[1].zzzz + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * hlslcc_mtx4x4unity_ObjectToWorld[1].wwww + u_xlat0;
					    u_xlat1 = u_xlat0 * in_NORMAL0.yyyy;
					    u_xlat0 = u_xlat0 * in_POSITION0.yyyy;
					    u_xlat2 = hlslcc_mtx4x4unity_ObjectToWorld[0].yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[0] * hlslcc_mtx4x4unity_ObjectToWorld[0].xxxx + u_xlat2;
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[2] * hlslcc_mtx4x4unity_ObjectToWorld[0].zzzz + u_xlat2;
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[3] * hlslcc_mtx4x4unity_ObjectToWorld[0].wwww + u_xlat2;
					    u_xlat1 = u_xlat2 * in_NORMAL0.xxxx + u_xlat1;
					    u_xlat0 = u_xlat2 * in_POSITION0.xxxx + u_xlat0;
					    u_xlat2 = hlslcc_mtx4x4unity_ObjectToWorld[2].yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[0] * hlslcc_mtx4x4unity_ObjectToWorld[2].xxxx + u_xlat2;
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[2] * hlslcc_mtx4x4unity_ObjectToWorld[2].zzzz + u_xlat2;
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[3] * hlslcc_mtx4x4unity_ObjectToWorld[2].wwww + u_xlat2;
					    u_xlat1 = u_xlat2 * in_NORMAL0.zzzz + u_xlat1;
					    u_xlat0 = u_xlat2 * in_POSITION0.zzzz + u_xlat0;
					    u_xlat9 = dot(u_xlat1, u_xlat1);
					    u_xlat9 = inversesqrt(u_xlat9);
					    u_xlat1.xy = vec2(u_xlat9) * u_xlat1.xy;
					    u_xlat9 = in_COLOR0.x * _EdgeThickness;
					    u_xlat9 = u_xlat9 * 0.00285000005;
					    u_xlat1.xy = u_xlat1.xy * vec2(u_xlat9);
					    u_xlat2 = hlslcc_mtx4x4unity_ObjectToWorld[3].yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[0] * hlslcc_mtx4x4unity_ObjectToWorld[3].xxxx + u_xlat2;
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[2] * hlslcc_mtx4x4unity_ObjectToWorld[3].zzzz + u_xlat2;
					    u_xlat2 = hlslcc_mtx4x4unity_MatrixVP[3] * hlslcc_mtx4x4unity_ObjectToWorld[3].wwww + u_xlat2;
					    u_xlat0 = u_xlat2 * in_POSITION0.wwww + u_xlat0;
					    u_xlat16_3 = u_xlat0.z * 0.100000001;
					    u_xlat16_3 = max(u_xlat16_3, 0.5);
					    u_xlat16_3 = min(u_xlat16_3, 1.0);
					    gl_Position.xy = u_xlat1.xy * vec2(u_xlat16_3) + u_xlat0.xy;
					    gl_Position.zw = u_xlat0.zw;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}
*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 u_xlat16_0, u_xlat16_1, u_xlat10_0, SV_Target0, u_xlat10_2, u_xlat0, u_xlat10_3;
				u_xlat10_0.xyz = tex2D(_MainTex, i.texcoord0.xy).xyz;
				u_xlat16_1.xyz = u_xlat10_0.xyz * u_xlat10_0.xyz;
				u_xlat0.xyz = u_xlat16_1.xyz * float3(float3(_EdgeBrightness, _EdgeBrightness, _EdgeBrightness));
				SV_Target0.xyz = u_xlat0.xyz * _Color.xyz;
				SV_Target0.w = _Alpha;
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
					uniform 	vec4 _Color;
					uniform 	float _EdgeBrightness;
					uniform 	float _Alpha;
					uniform lowp sampler2D _MainTex;
					varying highp vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp vec3 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0.xyz = texture2D(_MainTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_0.xyz * u_xlat10_0.xyz;
					    u_xlat0.xyz = u_xlat16_1.xyz * vec3(vec3(_EdgeBrightness, _EdgeBrightness, _EdgeBrightness));
					    SV_Target0.xyz = u_xlat0.xyz * _Color.xyz;
					    SV_Target0.w = _Alpha;
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