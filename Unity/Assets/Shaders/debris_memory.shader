Shader "Shader Forge/testSkyBox" {
	Properties {
		_Tex_A ("Tex_A", 2D) = "white" {}
		_Tex_B ("Tex_B", 2D) = "white" {}
		_Frenel_slider ("Frenel_slider", Range(-0.5, 1)) = 0
		_Cube_map ("Cube_map", Cube) = "_Skybox" {}
		_IBL_color ("IBL_color", Vector) = (0.5,0.5,0.5,1)
		_Lightspeed ("Lightspeed", Float) = 10
		_TexchangeSpeed ("TexchangeSpeed", Float) = 0.1
		_add_color ("add_color", Vector) = (0.5,0.5,0.5,1)
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
				float4 normal0 : NORMAL0;
				float2 texcoord0 : TEXCOORD0;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
			};

			sampler2D _Tex_A;
			sampler2D _Tex_B;
			samplerCUBE _Cube_map;
			float4 _Tex_A_ST;
			float4 _Tex_B_ST;
			float4 _IBL_color;
			float _Frenel_slider;
			float _TexchangeSpeed;
			float _Lightspeed;
			float4 _add_color;
			float4 _TimeEditor;


			v2f vert(appdata v)
			{
				v2f o;
				o.texcoord0 = v.texcoord0;
				o.texcoord1 = mul(unity_ObjectToWorld,v.position0);
				o.position0 = UnityObjectToClipPos(v.position0);
				float4 normal;
				normal.xyz = v.normal0;
				normal.w = 0;
				o.texcoord2 = normalize((mul(unity_ObjectToWorld,normal)).xyz);
				return o; 
			}
/*
			GpuProgramID 29068
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
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat6;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat1 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    vs_TEXCOORD1 = hlslcc_mtx4x4unity_ObjectToWorld[3] * in_POSITION0.wwww + u_xlat0;
					    u_xlat0 = u_xlat1.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat1.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat1.zzzz + u_xlat0;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat1.wwww + u_xlat0;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
				float u_xlat18, u_xlat12, u_xlat3, u_xlat4;
				float3 u_xlat2, u_xlat6, u_xlat5;
				float4 SV_Target0, u_xlat0, u_xlat10_2, u_xlat1, u_xlat10_1;
				u_xlat0.xyz = (-i.texcoord1.xyz) + _WorldSpaceCameraPos.xyz;
				u_xlat18 = dot(u_xlat0.xyz, u_xlat0.xyz);
				u_xlat18 = rsqrt(u_xlat18);
				u_xlat0.xyz = float3(u_xlat18, u_xlat18, u_xlat18) * u_xlat0.xyz;
				u_xlat18 = dot(i.texcoord2.xyz, i.texcoord2.xyz);
				u_xlat18 = rsqrt(u_xlat18);
				u_xlat1.xyz = float3(u_xlat18, u_xlat18, u_xlat18) * i.texcoord2.xyz;
				u_xlat18 = dot((-u_xlat0.xyz), u_xlat1.xyz);
				u_xlat18 = u_xlat18 + u_xlat18;
				u_xlat2.xyz = u_xlat1.xyz * (-float3(u_xlat18, u_xlat18, u_xlat18)) + (-u_xlat0.xyz);
				u_xlat0.x = dot(u_xlat1.xyz, u_xlat0.xyz);
				u_xlat0.x = max(u_xlat0.x, 0.0);
				u_xlat0.x = (-u_xlat0.x) + 1.0;
				u_xlat0.x = log2(u_xlat0.x);
				u_xlat0.x = u_xlat0.x * _Frenel_slider;
				u_xlat0.x = exp2(u_xlat0.x);
				u_xlat1.y = u_xlat2.y;
				u_xlat6.xy = _Time.yw + _TimeEditor.yw;
				u_xlat12 = u_xlat6.y * _Lightspeed;
				u_xlat6.x = u_xlat6.x * _TexchangeSpeed;
				u_xlat6.x = sin(u_xlat6.x);
				u_xlat12 = u_xlat12 * 0.0174532942;
				u_xlat3 = sin(u_xlat12);
				u_xlat4 = cos(u_xlat12);
				u_xlat5.x = (-u_xlat3);
				u_xlat5.y = u_xlat4;
				u_xlat5.z = u_xlat3;
				u_xlat1.z = dot(u_xlat5.zy, u_xlat2.xz);
				u_xlat1.x = dot(u_xlat5.yx, u_xlat2.xz);
				u_xlat10_1.xyz = texCUBE(_Cube_map, u_xlat1.xyz).xyz;
				u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
				u_xlat0.xzw = min(u_xlat0.xxx, u_xlat1.xyz);
				u_xlat1.xy = i.texcoord0.xy * _Tex_B_ST.xy + _Tex_B_ST.zw;
				u_xlat10_1 = tex2D(_Tex_B, u_xlat1.xy);
				u_xlat2.x = (-u_xlat6.x) + 1.0;
				u_xlat1 = u_xlat10_1 * u_xlat2.xxxx;
				u_xlat2.xy = i.texcoord0.xy * _Tex_A_ST.xy + _Tex_A_ST.zw;
				u_xlat10_2 = tex2D(_Tex_A, u_xlat2.xy);
				u_xlat1.xyz = u_xlat10_2.xyz * u_xlat6.xxx + u_xlat1.xyz;
				SV_Target0.w = u_xlat10_2.w * u_xlat6.x + u_xlat1.w;
				u_xlat0.xyz = u_xlat0.xzw + u_xlat1.xyz;
				SV_Target0.xyz = u_xlat0.xyz + _add_color.xyz;
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
					uniform 	vec3 _WorldSpaceCameraPos;
					uniform 	vec4 _TimeEditor;
					uniform 	vec4 _Tex_B_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _IBL_color;
					uniform 	float _Lightspeed;
					uniform 	vec4 _Tex_A_ST;
					uniform 	float _TexchangeSpeed;
					uniform 	vec4 _add_color;
					uniform lowp sampler2D _Tex_A;
					uniform lowp sampler2D _Tex_B;
					uniform lowp samplerCube _Cube_map;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec4 u_xlat1;
					lowp vec4 u_xlat10_1;
					vec3 u_xlat2;
					lowp vec4 u_xlat10_2;
					float u_xlat3;
					float u_xlat4;
					vec3 u_xlat5;
					vec2 u_xlat6;
					float u_xlat12;
					float u_xlat18;
					void main()
					{
					    u_xlat0.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat18 = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat18 = inversesqrt(u_xlat18);
					    u_xlat0.xyz = vec3(u_xlat18) * u_xlat0.xyz;
					    u_xlat18 = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat18 = inversesqrt(u_xlat18);
					    u_xlat1.xyz = vec3(u_xlat18) * vs_TEXCOORD2.xyz;
					    u_xlat18 = dot((-u_xlat0.xyz), u_xlat1.xyz);
					    u_xlat18 = u_xlat18 + u_xlat18;
					    u_xlat2.xyz = u_xlat1.xyz * (-vec3(u_xlat18)) + (-u_xlat0.xyz);
					    u_xlat0.x = dot(u_xlat1.xyz, u_xlat0.xyz);
					    u_xlat0.x = max(u_xlat0.x, 0.0);
					    u_xlat0.x = (-u_xlat0.x) + 1.0;
					    u_xlat0.x = log2(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * _Frenel_slider;
					    u_xlat0.x = exp2(u_xlat0.x);
					    u_xlat1.y = u_xlat2.y;
					    u_xlat6.xy = _Time.yw + _TimeEditor.yw;
					    u_xlat12 = u_xlat6.y * _Lightspeed;
					    u_xlat6.x = u_xlat6.x * _TexchangeSpeed;
					    u_xlat6.x = sin(u_xlat6.x);
					    u_xlat12 = u_xlat12 * 0.0174532942;
					    u_xlat3 = sin(u_xlat12);
					    u_xlat4 = cos(u_xlat12);
					    u_xlat5.x = (-u_xlat3);
					    u_xlat5.y = u_xlat4;
					    u_xlat5.z = u_xlat3;
					    u_xlat1.z = dot(u_xlat5.zy, u_xlat2.xz);
					    u_xlat1.x = dot(u_xlat5.yx, u_xlat2.xz);
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xzw = min(u_xlat0.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _Tex_B_ST.xy + _Tex_B_ST.zw;
					    u_xlat10_1 = texture2D(_Tex_B, u_xlat1.xy);
					    u_xlat2.x = (-u_xlat6.x) + 1.0;
					    u_xlat1 = u_xlat10_1 * u_xlat2.xxxx;
					    u_xlat2.xy = vs_TEXCOORD0.xy * _Tex_A_ST.xy + _Tex_A_ST.zw;
					    u_xlat10_2 = texture2D(_Tex_A, u_xlat2.xy);
					    u_xlat1.xyz = u_xlat10_2.xyz * u_xlat6.xxx + u_xlat1.xyz;
					    SV_Target0.w = u_xlat10_2.w * u_xlat6.x + u_xlat1.w;
					    u_xlat0.xyz = u_xlat0.xzw + u_xlat1.xyz;
					    SV_Target0.xyz = u_xlat0.xyz + _add_color.xyz;
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