Shader "Shader Forge/NewShader" {
	Properties {
		_VAL_col ("VAL_col", 2D) = "white" {}
		_Frenel_slider ("Frenel_slider", Range(-0.5, 1)) = 0
		_Cube_map ("Cube_map", Cube) = "_Skybox" {}
		_VAL_mask ("VAL_mask", 2D) = "white" {}
		_Brightnessmulti ("Brightness(multi)", Range(0, 2)) = 1
		_Saturationpower ("Saturation (power)", Range(0, 2)) = 1
		_IBL_color ("IBL_color", Vector) = (0.5,0.5,0.5,1)
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
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float3 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
			};

			float4 _TimeEditor;
			sampler2D _VAL_col;
			float4 _VAL_col_ST;
			float _Frenel_slider;
			samplerCUBE _Cube_map;
			sampler2D _VAL_mask;
			float4 _VAL_mask_ST;
			float _Brightnessmulti;
			float _Saturationpower;
			float4 _IBL_color;

			v2f vert(appdata v)
			{
				v2f o;

				o.texcoord0 = v.texcoord0;
				o.texcoord1 = mul(unity_ObjectToWorld,v.position0);

				float4 normal;
				normal.xyz = v.normal0;
				normal.w = 0;
				o.texcoord2 = normalize((mul(unity_ObjectToWorld,normal)).xyz);

				o.position0 = UnityObjectToClipPos(v.position0);
				return o; 
			}
/*			GpuProgramID 45248
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" }
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
				float4 u_xlat0, u_xlat1, u_xlat2, u_xlat4, u_xlat5, u_xlat3, u_xlat10_1, u_xlat16_1, u_xlat10_3, SV_Target0;
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
				u_xlat10_3.xyz = texCUBE(_Cube_map, u_xlat2.xyz).xyz;
				u_xlat3.xyz = u_xlat10_3.xyz * _IBL_color.xyz;
				u_xlat0.xyz = min(u_xlat0.xxx, u_xlat3.xyz);
				u_xlat1.xy = i.texcoord0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
				u_xlat10_1.xyz = tex2D(_VAL_mask, u_xlat1.xy).xyz;
				u_xlat0.xyz = min(u_xlat0.xyz, u_xlat10_1.xyz);
				u_xlat1.xy = i.texcoord0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
				u_xlat10_1.xyz = tex2D(_VAL_col, u_xlat1.xy).xyz;
				u_xlat16_1.xyz = log2(u_xlat10_1.xyz);
				u_xlat1.xyz = u_xlat16_1.xyz * float3(_Saturationpower, _Saturationpower, _Saturationpower);
				u_xlat1.xyz = exp2(u_xlat1.xyz);
				SV_Target0.xyz = u_xlat1.xyz * float3(float3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyz;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
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
					    u_xlat10_3.xyz = textureCube(_Cube_map, u_xlat2.xyz).xyz;
					    u_xlat3.xyz = u_xlat10_3.xyz * _IBL_color.xyz;
					    u_xlat0.xyz = min(u_xlat0.xxx, u_xlat3.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyz = min(u_xlat0.xyz, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = log2(u_xlat10_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    SV_Target0.xyz = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyz;
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
	CustomEditor "ShaderForgeMaterialInspector"
}