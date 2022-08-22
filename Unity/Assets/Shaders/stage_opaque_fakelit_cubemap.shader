Shader "MCRS/Stage/Opaque_FakeLit_Cubemap" {
	Properties {
		_MainTex ("DiffuseTex", 2D) = "white" {}
		_CubemapTex ("CubemapTex", Cube) = "_Skybox" {}
		_CubemapMaskTex ("CubemapMaskTex", 2D) = "white" {}
		_Color ("Main Color", Vector) = (1,1,1,1)
		_CubemapPower ("_CubemapPower (power)", Range(0, 1)) = 1
		_Frenel_slider ("Frenel_slider", Range(-0.5, 1)) = 0
		_Brightnessmulti ("Brightness(multi)", Range(0, 2)) = 1
		_Saturationpower ("Saturation (power)", Range(0, 2)) = 1
	}
	SubShader {
		Tags { "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Geometry" "RenderType" = "Opaque" }
		Pass {
			Tags { "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Geometry" "RenderType" = "Opaque" "SHADOWSUPPORT" = "true" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 position0 : POSITION;
				float4 color0 : COLOR;
				float3 normal0 : NORMAL0;
				float2 texcoord0 : TEXCOORD0;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
				float4 color0 : COLOR0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;
			samplerCUBE _CubemapTex;
			float4 _CubemapTex_ST;
			sampler2D _CubemapMaskTex;
			float4 _CubemapMaskTex_ST;
			float _CubemapPower;
			float _Frenel_slider;
			float _Brightnessmulti;
			float _Saturationpower;

			v2f vert(appdata v)
			{
				v2f o;

				o.position0 = UnityObjectToClipPos(v.position0);
				o.color0 = v.color0;
				o.texcoord0 = /*TRANSFORM_TEX(*/v.texcoord0/*, _MainTex)*/;
				o.texcoord1 = mul(unity_ObjectToWorld,v.position0);
				float4 normal;
				normal.xyz = v.normal0;
				normal.w = 0;
				o.texcoord2 = normalize((mul(unity_ObjectToWorld,normal)).xyz);
				return o; 
			}
/*			GpuProgramID 41664
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_WorldToObject[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec3 in_NORMAL0;
					attribute highp vec4 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR1;
					varying highp vec4 vs_TEXCOORD1;
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_COLOR1 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    vs_TEXCOORD1 = hlslcc_mtx4x4unity_ObjectToWorld[3] * in_POSITION0.wwww + u_xlat0;
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
				float4 u_xlat10_0, u_xlat0, SV_Target0, u_xlat1, u_xlat2, u_xlat10_3, u_xlat10_1, u_xlat16_1;
				float u_xlat9;
				u_xlat0.xyz = (-i.texcoord1.xyz) + _WorldSpaceCameraPos.xyz;
				u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
				u_xlat9 = rsqrt(u_xlat9);
				u_xlat0.xyz = float3(u_xlat9, u_xlat9, u_xlat9) * u_xlat0.xyz;
				u_xlat9 = dot(i.texcoord2.xyz, i.texcoord2.xyz);
				u_xlat9 = rsqrt(u_xlat9);
				u_xlat1.xyz = float3(u_xlat9, u_xlat9, u_xlat9) * i.texcoord2.xyz;
				u_xlat9 = dot((-u_xlat0.xyz), u_xlat1.xyz);
				u_xlat9 = u_xlat9 + u_xlat9;
				u_xlat2.xyz = u_xlat1.xyz * (-float3(u_xlat9, u_xlat9, u_xlat9)) + (-u_xlat0.xyz);
				u_xlat0.x = dot(u_xlat1.xyz, u_xlat0.xyz);
				u_xlat0.x = max(u_xlat0.x, 0.0);
				u_xlat0.x = (-u_xlat0.x) + 1.0;
				u_xlat0.x = log2(u_xlat0.x);
				u_xlat0.x = u_xlat0.x * _Frenel_slider;
				u_xlat0.x = exp2(u_xlat0.x);
				u_xlat10_3.xyz = texCUBE(_CubemapTex, u_xlat2.xyz).xyz;
				u_xlat0.xyz = min(u_xlat0.xxx, u_xlat10_3.xyz);
				u_xlat1.xy = i.texcoord0.xy * _CubemapMaskTex_ST.xy + _CubemapMaskTex_ST.zw;
				u_xlat10_1.xyz = tex2D(_CubemapMaskTex, u_xlat1.xy).xyz;
				u_xlat0.xyz = min(u_xlat0.xyz, u_xlat10_1.xyz);
				u_xlat0.xyz = u_xlat0.xyz * float3(_CubemapPower, _CubemapPower, _CubemapPower);
				u_xlat1.xy = i.texcoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				u_xlat10_1.xyz = tex2D(_MainTex, u_xlat1.xy).xyz;
				u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
				u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
				u_xlat1.xyz = u_xlat16_1.xyz * float3(float3(_Saturationpower, _Saturationpower, _Saturationpower));
				u_xlat1.xyz = exp2(u_xlat1.xyz);
				u_xlat0.xyz = u_xlat1.xyz * float3(float3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyz;
				u_xlat0.xyz = u_xlat0.xyz * _Color.xyz;
				SV_Target0.xyz = u_xlat0.xyz * i.color0.xyz;
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
					uniform 	vec3 _WorldSpaceCameraPos;
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _CubemapMaskTex_ST;
					uniform 	vec4 _Color;
					uniform 	float _CubemapPower;
					uniform 	float _Frenel_slider;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform lowp sampler2D _MainTex;
					uniform lowp samplerCube _CubemapTex;
					uniform lowp sampler2D _CubemapMaskTex;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR1;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					lowp vec3 u_xlat10_3;
					float u_xlat9;
					void main()
					{
					    u_xlat0.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat9 = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat9 = inversesqrt(u_xlat9);
					    u_xlat0.xyz = vec3(u_xlat9) * u_xlat0.xyz;
					    u_xlat9 = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat9 = inversesqrt(u_xlat9);
					    u_xlat1.xyz = vec3(u_xlat9) * vs_TEXCOORD2.xyz;
					    u_xlat9 = dot((-u_xlat0.xyz), u_xlat1.xyz);
					    u_xlat9 = u_xlat9 + u_xlat9;
					    u_xlat2.xyz = u_xlat1.xyz * (-vec3(u_xlat9)) + (-u_xlat0.xyz);
					    u_xlat0.x = dot(u_xlat1.xyz, u_xlat0.xyz);
					    u_xlat0.x = max(u_xlat0.x, 0.0);
					    u_xlat0.x = (-u_xlat0.x) + 1.0;
					    u_xlat0.x = log2(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * _Frenel_slider;
					    u_xlat0.x = exp2(u_xlat0.x);
					    u_xlat10_3.xyz = textureCube(_CubemapTex, u_xlat2.xyz).xyz;
					    u_xlat0.xyz = min(u_xlat0.xxx, u_xlat10_3.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _CubemapMaskTex_ST.xy + _CubemapMaskTex_ST.zw;
					    u_xlat10_1.xyz = texture2D(_CubemapMaskTex, u_xlat1.xy).xyz;
					    u_xlat0.xyz = min(u_xlat0.xyz, u_xlat10_1.xyz);
					    u_xlat0.xyz = u_xlat0.xyz * vec3(_CubemapPower);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat10_1.xyz = texture2D(_MainTex, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(vec3(_Saturationpower, _Saturationpower, _Saturationpower));
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyz = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyz;
					    u_xlat0.xyz = u_xlat0.xyz * _Color.xyz;
					    SV_Target0.xyz = u_xlat0.xyz * vs_COLOR1.xyz;
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
}