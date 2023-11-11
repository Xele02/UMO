Shader "MCRS/quartz_shader" {
	Properties {
		_Tex_quartz ("Tex_quartz", 2D) = "black" {}
		_Cube_map ("Cube_map", Cube) = "_Skybox" {}
		_speed ("speed", Float) = 15
	}
	SubShader {
		Tags { "RenderType" = "Opaque" }
		Pass {
			Name "FORWARD"
			Tags { "LIGHTMODE" = "FORWARDBASE" "RenderType" = "Opaque" }
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

			sampler2D _Tex_quartz;
			float4 _Tex_quartz_ST;
			samplerCUBE _Cube_map;
			float4 _Cube_map_ST;
			float _speed;
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
			GpuProgramID 58667
			Program "vp" {
				SubProgram "gles hw_tier02 " {
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
				float3 u_xlat0, u_xlat1, u_xlat4;
				float u_xlat15, u_xlat2, u_xlat3, u_xlat5;
				float4 SV_Target0, u_xlat10_0, u_xlat10_1, u_xlat16_0;
				u_xlat0.xyz = (-i.texcoord1.xyz) + _WorldSpaceCameraPos.xyz;
				u_xlat15 = dot(u_xlat0.xyz, u_xlat0.xyz);
				u_xlat15 = rsqrt(u_xlat15);
				u_xlat0.xyz = float3(u_xlat15, u_xlat15, u_xlat15) * u_xlat0.xyz;
				u_xlat15 = dot(i.texcoord2.xyz, i.texcoord2.xyz);
				u_xlat15 = rsqrt(u_xlat15);
				u_xlat1.xyz = float3(u_xlat15, u_xlat15, u_xlat15) * i.texcoord2.xyz;
				u_xlat15 = dot((-u_xlat0.xyz), u_xlat1.xyz);
				u_xlat15 = u_xlat15 + u_xlat15;
				u_xlat0.xyz = u_xlat1.xyz * (-float3(u_xlat15, u_xlat15, u_xlat15)) + (-u_xlat0.xyz);
				u_xlat1.y = u_xlat0.y;
				u_xlat5 = _Time.w + _TimeEditor.w;
				u_xlat5 = u_xlat5 * _speed;
				u_xlat5 = u_xlat5 * 0.0174532942;
				u_xlat2 = sin(u_xlat5);
				u_xlat3 = cos(u_xlat5);
				u_xlat4.x = (-u_xlat2);
				u_xlat4.y = u_xlat3;
				u_xlat4.z = u_xlat2;
				u_xlat1.z = dot(u_xlat4.zy, u_xlat0.xz);
				u_xlat1.x = dot(u_xlat4.yx, u_xlat0.xz);
				u_xlat10_0.xyz = texCUBE(_Cube_map, u_xlat1.xyz).xyz;
				u_xlat1.xy = i.texcoord0.xy * _Tex_quartz_ST.xy + _Tex_quartz_ST.zw;
				u_xlat10_1.xyz = tex2D(_Tex_quartz, u_xlat1.xy).xyz;
				u_xlat16_0.xyz = u_xlat10_0.xyz * u_xlat10_1.xyz;
				SV_Target0.xyz = u_xlat16_0.xyz * float3(3.0, 3.0, 3.0) + u_xlat10_1.xyz;
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
					uniform 	vec4 _Time;
					uniform 	vec3 _WorldSpaceCameraPos;
					uniform 	vec4 _TimeEditor;
					uniform 	vec4 _Tex_quartz_ST;
					uniform 	float _speed;
					uniform lowp sampler2D _Tex_quartz;
					uniform lowp samplerCube _Cube_map;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					vec3 u_xlat1;
					lowp vec3 u_xlat10_1;
					float u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					float u_xlat5;
					float u_xlat15;
					void main()
					{
					    u_xlat0.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat15 = dot(u_xlat0.xyz, u_xlat0.xyz);
					    u_xlat15 = inversesqrt(u_xlat15);
					    u_xlat0.xyz = vec3(u_xlat15) * u_xlat0.xyz;
					    u_xlat15 = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat15 = inversesqrt(u_xlat15);
					    u_xlat1.xyz = vec3(u_xlat15) * vs_TEXCOORD2.xyz;
					    u_xlat15 = dot((-u_xlat0.xyz), u_xlat1.xyz);
					    u_xlat15 = u_xlat15 + u_xlat15;
					    u_xlat0.xyz = u_xlat1.xyz * (-vec3(u_xlat15)) + (-u_xlat0.xyz);
					    u_xlat1.y = u_xlat0.y;
					    u_xlat5 = _Time.w + _TimeEditor.w;
					    u_xlat5 = u_xlat5 * _speed;
					    u_xlat5 = u_xlat5 * 0.0174532942;
					    u_xlat2 = sin(u_xlat5);
					    u_xlat3 = cos(u_xlat5);
					    u_xlat4.x = (-u_xlat2);
					    u_xlat4.y = u_xlat3;
					    u_xlat4.z = u_xlat2;
					    u_xlat1.z = dot(u_xlat4.zy, u_xlat0.xz);
					    u_xlat1.x = dot(u_xlat4.yx, u_xlat0.xz);
					    u_xlat10_0.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xy = vs_TEXCOORD0.xy * _Tex_quartz_ST.xy + _Tex_quartz_ST.zw;
					    u_xlat10_1.xyz = texture2D(_Tex_quartz, u_xlat1.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * u_xlat10_1.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vec3(3.0, 3.0, 3.0) + u_xlat10_1.xyz;
					    SV_Target0.w = 1.0;
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
	CustomEditor "ShaderForgeMaterialInspector"
}