Shader "MCRS/PosterShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MaskTex ("Mask (A)", 2D) = "white" {}
		_KiraTex ("Kira (RGB)", 2D) = "white" {}
		_Kira2Tex ("Kira2 (RGB)", 2D) = "white" {}
		_KiraMaskTex ("KiraMask (A)", 2D) = "white" {}
		_EffTex ("EffTex (RGB)", 2D) = "white" {}
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		_ColorMask ("Color Mask", Float) = 15
	}
	SubShader {
		LOD 100
		Tags { "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			LOD 100
			Tags { "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask [_ColorMask]
			ZWrite Off
			Cull Off
			Offset -1, -1
			Stencil {
				Ref [_Stencil]
				ReadMask [_StencilReadMask]
				WriteMask [_StencilWriteMask]
				Comp [_StencilComp]
				Pass [_StencilOp]
				Fail Keep
				ZFail Keep
			}	
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
				float2 texcoord0 : TEXCOORD0;
				float4 color0 : COLOR0;
			};

			struct v2f
			{
				float4 position0 : SV_POSITION;
				float2 texcoord0 : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 color0 : COLOR0;
			};

			sampler2D _MainTex;
			sampler2D _MaskTex;
			sampler2D _EffTex;
			sampler2D _KiraTex;
			sampler2D _Kira2Tex;
			sampler2D _KiraMaskTex;
			float4 _MainTex_ST;
			float4 _MaskTex_ST;

			v2f vert(appdata v)
			{
				v2f o;

				o.texcoord0 = TRANSFORM_TEX(v.texcoord0, _MainTex);
				float2 u_xlat0, u_xlat1;
				bool u_xlatb3;
				float u_xlat16_2, u_xlat16_5, u_xlat3;
				u_xlat0.x = _Time.y * 0.25;
				u_xlat0.x = frac(u_xlat0.x);
				u_xlatb3 = 0.5>=u_xlat0.x;
				u_xlat16_2 = (u_xlatb3) ? -12.0 : -0.0;
				u_xlat16_2 = dot(float2(u_xlat16_2, u_xlat16_2), u_xlat0.xx);
				u_xlat0.xy = v.texcoord0.xy + float2(-0.5, -0.5);
				u_xlat1.x = dot(float2(0.707106769, -0.707106769), u_xlat0.xy);
				u_xlat1.y = dot(float2(0.707106769, 0.707106769), u_xlat0.xy);
				u_xlat0.xy = u_xlat1.xy + float2(0.5, 0.5);
				u_xlat16_5 = u_xlat0.x * 4.0 + 1.20000005;
				o.texcoord1.y = u_xlat0.y;
				o.texcoord1.x = u_xlat16_2 + u_xlat16_5;

				u_xlat0.x = _SinTime.w * _SinTime.w;
				u_xlat0.x = u_xlat0.x * _SinTime.w;
				u_xlat0.x = u_xlat0.x * 4.0;
				u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
				o.texcoord2.x = u_xlat0.x;
				u_xlat0.x = _CosTime.w * _CosTime.w;
				u_xlat0.x = u_xlat0.x * _CosTime.w;
				u_xlat3 = _CosTime.w * 3.0;
				u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
				o.texcoord2.y = u_xlat0.x;
				o.texcoord2.zw = float2(1.0, 1.0);

				o.position0 = UnityObjectToClipPos(v.position0);
				o.color0 = v.color0;

				return o; 
			}
/*
			GpuProgramID 4393
			Program "vp" {
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute mediump vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_5;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb3 = 0.5>=u_xlat0.x;
					    u_xlat16_2 = (u_xlatb3) ? -12.0 : -0.0;
					    u_xlat16_2 = dot(vec2(u_xlat16_2), u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_5 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD1.y = u_xlat0.y;
					    vs_TEXCOORD1.x = u_xlat16_2 + u_xlat16_5;
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD2.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD2.y = u_xlat0.x;
					    vs_TEXCOORD2.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    return;
					}

*/
			fixed4 frag(v2f i) : SV_Target
			{
				float4 SV_Target0, u_xlat16_0, u_xlat16_1, u_xlat10_2, u_xlat16_3, u_xlat10_4, u_xlat16_11, u_xlat16_5, u_xlat16_6;
				float u_xlat10_0, u_xlat16_17, u_xlat16_25, u_xlat10_26;
				float2 u_xlat16_9, u_xlat16_7;
				bool u_xlatb0;
				u_xlat10_0 = tex2D(_MaskTex, i.texcoord0.xy).x;
				u_xlat16_1.x = u_xlat10_0 + -0.00999999978;
				SV_Target0.w = u_xlat10_0;
				u_xlatb0 = u_xlat16_1.x<0.0;
				if(((int(u_xlatb0) * -1))!=0){discard;}
				u_xlat16_1.x = i.texcoord2.w * i.texcoord2.z;
				u_xlat16_0 = u_xlat16_1.xxxx * i.texcoord2.yxyx;
				u_xlat16_1 = u_xlat16_0.wwyw * float4(0.412999988, 0.300000012, 0.588, 0.885999978);
				u_xlat16_9.x = i.texcoord2.z * 0.298999995 + (-u_xlat16_1.y);
				u_xlat16_1.x = i.texcoord2.z * 0.587000012 + u_xlat16_1.x;
				u_xlat16_1.x = u_xlat16_0.z * 0.0350000001 + u_xlat16_1.x;
				u_xlat16_9.x = u_xlat16_0.x * 1.25 + u_xlat16_9.x;
				u_xlat16_17 = i.texcoord2.z * 0.587000012 + (-u_xlat16_1.z);
				u_xlat16_25 = i.texcoord2.z * 0.114 + u_xlat16_1.w;
				u_xlat16_25 = (-u_xlat16_0.z) * 0.202999994 + u_xlat16_25;
				u_xlat16_17 = (-u_xlat16_0.z) * 1.04999995 + u_xlat16_17;
				u_xlat10_2.xyz = tex2D(_Kira2Tex, i.texcoord0.xy).xyz;
				u_xlat16_3.x = u_xlat16_17 * u_xlat10_2.y;
				u_xlat16_3.x = u_xlat16_9.x * u_xlat10_2.x + u_xlat16_3.x;
				u_xlat16_3.x = u_xlat16_25 * u_xlat10_2.z + u_xlat16_3.x;
				u_xlat10_4.xyz = tex2D(_MainTex, i.texcoord0.xy).xyz;
				u_xlat10_26 = tex2D(_KiraMaskTex, i.texcoord0.xy).x;
				u_xlat16_11.x = (-u_xlat10_26) + 1.0;
				u_xlat16_11.xyz = u_xlat16_11.xxx * u_xlat10_4.xyz;
				u_xlat16_5.z = u_xlat16_3.x * u_xlat10_26 + u_xlat16_11.z;
				u_xlat10_4.xyz = tex2D(_KiraTex, i.texcoord0.xy).xyz;
				u_xlat16_17 = u_xlat16_17 * u_xlat10_4.y;
				u_xlat16_9.x = u_xlat16_9.x * u_xlat10_4.x + u_xlat16_17;
				u_xlat16_6.z = u_xlat16_25 * u_xlat10_4.z + u_xlat16_9.x;
				u_xlat16_9.xy = u_xlat16_0.ww * float2(0.700999975, 0.587000012);
				u_xlat16_9.x = i.texcoord2.z * 0.298999995 + u_xlat16_9.x;
				u_xlat16_17 = i.texcoord2.z * 0.587000012 + (-u_xlat16_9.y);
				u_xlat16_17 = u_xlat16_0.z * 0.330000013 + u_xlat16_17;
				u_xlat16_9.x = u_xlat16_0.z * 0.167999998 + u_xlat16_9.x;
				u_xlat16_25 = u_xlat10_2.y * u_xlat16_17;
				u_xlat16_17 = u_xlat10_4.y * u_xlat16_17;
				u_xlat16_17 = u_xlat16_9.x * u_xlat10_4.x + u_xlat16_17;
				u_xlat16_9.x = u_xlat16_9.x * u_xlat10_2.x + u_xlat16_25;
				u_xlat16_3.xw = u_xlat16_0.ww * float2(0.114, 0.298999995);
				u_xlat16_3.xw = i.texcoord2.zz * float2(0.114, 0.298999995) + (-u_xlat16_3.xw);
				u_xlat16_7.xy = (-u_xlat16_0.zz) * float2(0.497000009, 0.328000009) + u_xlat16_3.xw;
				u_xlat16_25 = u_xlat16_0.z * 0.291999996 + u_xlat16_3.x;
				u_xlat16_9.x = u_xlat16_7.x * u_xlat10_2.z + u_xlat16_9.x;
				u_xlat16_5.x = u_xlat16_9.x * u_xlat10_26 + u_xlat16_11.x;
				u_xlat16_9.x = u_xlat10_2.x * u_xlat16_7.y;
				u_xlat16_9.x = u_xlat16_1.x * u_xlat10_2.y + u_xlat16_9.x;
				u_xlat16_9.x = u_xlat16_25 * u_xlat10_2.z + u_xlat16_9.x;
				u_xlat16_5.y = u_xlat16_9.x * u_xlat10_26 + u_xlat16_11.y;
				u_xlat16_6.x = u_xlat16_7.x * u_xlat10_4.z + u_xlat16_17;
				u_xlat16_9.x = u_xlat10_4.x * u_xlat16_7.y;
				u_xlat16_1.x = u_xlat16_1.x * u_xlat10_4.y + u_xlat16_9.x;
				u_xlat16_6.y = u_xlat16_25 * u_xlat10_4.z + u_xlat16_1.x;
				u_xlat16_1.xyz = u_xlat16_5.xyz + u_xlat16_6.xyz;
				u_xlat10_2.xyz = tex2D(_EffTex, i.texcoord1.xy).xyz;
				SV_Target0.xyz = u_xlat16_1.xyz + u_xlat10_2.xyz;
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
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _EffTex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					lowp float u_xlat10_0;
					bool u_xlatb0;
					mediump vec4 u_xlat16_1;
					lowp vec3 u_xlat10_2;
					mediump vec4 u_xlat16_3;
					lowp vec3 u_xlat10_4;
					mediump vec3 u_xlat16_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec2 u_xlat16_9;
					mediump vec3 u_xlat16_11;
					mediump float u_xlat16_17;
					mediump float u_xlat16_25;
					lowp float u_xlat10_26;
					void main()
					{
					    u_xlat10_0 = texture2D(_MaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_1.x = u_xlat10_0 + -0.00999999978;
					    SV_Target0.w = u_xlat10_0;
					    u_xlatb0 = u_xlat16_1.x<0.0;
					    if(((int(u_xlatb0) * -1))!=0){discard;}
					    u_xlat16_1.x = vs_TEXCOORD2.w * vs_TEXCOORD2.z;
					    u_xlat16_0 = u_xlat16_1.xxxx * vs_TEXCOORD2.yxyx;
					    u_xlat16_1 = u_xlat16_0.wwyw * vec4(0.412999988, 0.300000012, 0.588, 0.885999978);
					    u_xlat16_9.x = vs_TEXCOORD2.z * 0.298999995 + (-u_xlat16_1.y);
					    u_xlat16_1.x = vs_TEXCOORD2.z * 0.587000012 + u_xlat16_1.x;
					    u_xlat16_1.x = u_xlat16_0.z * 0.0350000001 + u_xlat16_1.x;
					    u_xlat16_9.x = u_xlat16_0.x * 1.25 + u_xlat16_9.x;
					    u_xlat16_17 = vs_TEXCOORD2.z * 0.587000012 + (-u_xlat16_1.z);
					    u_xlat16_25 = vs_TEXCOORD2.z * 0.114 + u_xlat16_1.w;
					    u_xlat16_25 = (-u_xlat16_0.z) * 0.202999994 + u_xlat16_25;
					    u_xlat16_17 = (-u_xlat16_0.z) * 1.04999995 + u_xlat16_17;
					    u_xlat10_2.xyz = texture2D(_Kira2Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.x = u_xlat16_17 * u_xlat10_2.y;
					    u_xlat16_3.x = u_xlat16_9.x * u_xlat10_2.x + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_25 * u_xlat10_2.z + u_xlat16_3.x;
					    u_xlat10_4.xyz = texture2D(_MainTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat10_26 = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_11.x = (-u_xlat10_26) + 1.0;
					    u_xlat16_11.xyz = u_xlat16_11.xxx * u_xlat10_4.xyz;
					    u_xlat16_5.z = u_xlat16_3.x * u_xlat10_26 + u_xlat16_11.z;
					    u_xlat10_4.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_17 = u_xlat16_17 * u_xlat10_4.y;
					    u_xlat16_9.x = u_xlat16_9.x * u_xlat10_4.x + u_xlat16_17;
					    u_xlat16_6.z = u_xlat16_25 * u_xlat10_4.z + u_xlat16_9.x;
					    u_xlat16_9.xy = u_xlat16_0.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_9.x = vs_TEXCOORD2.z * 0.298999995 + u_xlat16_9.x;
					    u_xlat16_17 = vs_TEXCOORD2.z * 0.587000012 + (-u_xlat16_9.y);
					    u_xlat16_17 = u_xlat16_0.z * 0.330000013 + u_xlat16_17;
					    u_xlat16_9.x = u_xlat16_0.z * 0.167999998 + u_xlat16_9.x;
					    u_xlat16_25 = u_xlat10_2.y * u_xlat16_17;
					    u_xlat16_17 = u_xlat10_4.y * u_xlat16_17;
					    u_xlat16_17 = u_xlat16_9.x * u_xlat10_4.x + u_xlat16_17;
					    u_xlat16_9.x = u_xlat16_9.x * u_xlat10_2.x + u_xlat16_25;
					    u_xlat16_3.xw = u_xlat16_0.ww * vec2(0.114, 0.298999995);
					    u_xlat16_3.xw = vs_TEXCOORD2.zz * vec2(0.114, 0.298999995) + (-u_xlat16_3.xw);
					    u_xlat16_7.xy = (-u_xlat16_0.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_3.xw;
					    u_xlat16_25 = u_xlat16_0.z * 0.291999996 + u_xlat16_3.x;
					    u_xlat16_9.x = u_xlat16_7.x * u_xlat10_2.z + u_xlat16_9.x;
					    u_xlat16_5.x = u_xlat16_9.x * u_xlat10_26 + u_xlat16_11.x;
					    u_xlat16_9.x = u_xlat10_2.x * u_xlat16_7.y;
					    u_xlat16_9.x = u_xlat16_1.x * u_xlat10_2.y + u_xlat16_9.x;
					    u_xlat16_9.x = u_xlat16_25 * u_xlat10_2.z + u_xlat16_9.x;
					    u_xlat16_5.y = u_xlat16_9.x * u_xlat10_26 + u_xlat16_11.y;
					    u_xlat16_6.x = u_xlat16_7.x * u_xlat10_4.z + u_xlat16_17;
					    u_xlat16_9.x = u_xlat10_4.x * u_xlat16_7.y;
					    u_xlat16_1.x = u_xlat16_1.x * u_xlat10_4.y + u_xlat16_9.x;
					    u_xlat16_6.y = u_xlat16_25 * u_xlat10_4.z + u_xlat16_1.x;
					    u_xlat16_1.xyz = u_xlat16_5.xyz + u_xlat16_6.xyz;
					    u_xlat10_2.xyz = texture2D(_EffTex, vs_TEXCOORD1.xy).xyz;
					    SV_Target0.xyz = u_xlat16_1.xyz + u_xlat10_2.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "USE_EFFECT" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute mediump vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_5;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb3 = 0.5>=u_xlat0.x;
					    u_xlat16_2 = (u_xlatb3) ? -12.0 : -0.0;
					    u_xlat16_2 = dot(vec2(u_xlat16_2), u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_5 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD1.y = u_xlat0.y;
					    vs_TEXCOORD1.x = u_xlat16_2 + u_xlat16_5;
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD2.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD2.y = u_xlat0.x;
					    vs_TEXCOORD2.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 100
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					precision highp int;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _EffTex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					lowp float u_xlat10_0;
					bool u_xlatb0;
					mediump vec4 u_xlat16_1;
					lowp vec3 u_xlat10_2;
					mediump vec4 u_xlat16_3;
					lowp vec3 u_xlat10_4;
					mediump vec3 u_xlat16_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec2 u_xlat16_9;
					mediump vec3 u_xlat16_11;
					mediump float u_xlat16_17;
					mediump float u_xlat16_25;
					lowp float u_xlat10_26;
					void main()
					{
					    u_xlat10_0 = texture2D(_MaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_1.x = u_xlat10_0 + -0.00999999978;
					    SV_Target0.w = u_xlat10_0;
					    u_xlatb0 = u_xlat16_1.x<0.0;
					    if(((int(u_xlatb0) * -1))!=0){discard;}
					    u_xlat16_1.x = vs_TEXCOORD2.w * vs_TEXCOORD2.z;
					    u_xlat16_0 = u_xlat16_1.xxxx * vs_TEXCOORD2.yxyx;
					    u_xlat16_1 = u_xlat16_0.wwyw * vec4(0.412999988, 0.300000012, 0.588, 0.885999978);
					    u_xlat16_9.x = vs_TEXCOORD2.z * 0.298999995 + (-u_xlat16_1.y);
					    u_xlat16_1.x = vs_TEXCOORD2.z * 0.587000012 + u_xlat16_1.x;
					    u_xlat16_1.x = u_xlat16_0.z * 0.0350000001 + u_xlat16_1.x;
					    u_xlat16_9.x = u_xlat16_0.x * 1.25 + u_xlat16_9.x;
					    u_xlat16_17 = vs_TEXCOORD2.z * 0.587000012 + (-u_xlat16_1.z);
					    u_xlat16_25 = vs_TEXCOORD2.z * 0.114 + u_xlat16_1.w;
					    u_xlat16_25 = (-u_xlat16_0.z) * 0.202999994 + u_xlat16_25;
					    u_xlat16_17 = (-u_xlat16_0.z) * 1.04999995 + u_xlat16_17;
					    u_xlat10_2.xyz = texture2D(_Kira2Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.x = u_xlat16_17 * u_xlat10_2.y;
					    u_xlat16_3.x = u_xlat16_9.x * u_xlat10_2.x + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_25 * u_xlat10_2.z + u_xlat16_3.x;
					    u_xlat10_4.xyz = texture2D(_MainTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat10_26 = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_11.x = (-u_xlat10_26) + 1.0;
					    u_xlat16_11.xyz = u_xlat16_11.xxx * u_xlat10_4.xyz;
					    u_xlat16_5.z = u_xlat16_3.x * u_xlat10_26 + u_xlat16_11.z;
					    u_xlat10_4.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_17 = u_xlat16_17 * u_xlat10_4.y;
					    u_xlat16_9.x = u_xlat16_9.x * u_xlat10_4.x + u_xlat16_17;
					    u_xlat16_6.z = u_xlat16_25 * u_xlat10_4.z + u_xlat16_9.x;
					    u_xlat16_9.xy = u_xlat16_0.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_9.x = vs_TEXCOORD2.z * 0.298999995 + u_xlat16_9.x;
					    u_xlat16_17 = vs_TEXCOORD2.z * 0.587000012 + (-u_xlat16_9.y);
					    u_xlat16_17 = u_xlat16_0.z * 0.330000013 + u_xlat16_17;
					    u_xlat16_9.x = u_xlat16_0.z * 0.167999998 + u_xlat16_9.x;
					    u_xlat16_25 = u_xlat10_2.y * u_xlat16_17;
					    u_xlat16_17 = u_xlat10_4.y * u_xlat16_17;
					    u_xlat16_17 = u_xlat16_9.x * u_xlat10_4.x + u_xlat16_17;
					    u_xlat16_9.x = u_xlat16_9.x * u_xlat10_2.x + u_xlat16_25;
					    u_xlat16_3.xw = u_xlat16_0.ww * vec2(0.114, 0.298999995);
					    u_xlat16_3.xw = vs_TEXCOORD2.zz * vec2(0.114, 0.298999995) + (-u_xlat16_3.xw);
					    u_xlat16_7.xy = (-u_xlat16_0.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_3.xw;
					    u_xlat16_25 = u_xlat16_0.z * 0.291999996 + u_xlat16_3.x;
					    u_xlat16_9.x = u_xlat16_7.x * u_xlat10_2.z + u_xlat16_9.x;
					    u_xlat16_5.x = u_xlat16_9.x * u_xlat10_26 + u_xlat16_11.x;
					    u_xlat16_9.x = u_xlat10_2.x * u_xlat16_7.y;
					    u_xlat16_9.x = u_xlat16_1.x * u_xlat10_2.y + u_xlat16_9.x;
					    u_xlat16_9.x = u_xlat16_25 * u_xlat10_2.z + u_xlat16_9.x;
					    u_xlat16_5.y = u_xlat16_9.x * u_xlat10_26 + u_xlat16_11.y;
					    u_xlat16_6.x = u_xlat16_7.x * u_xlat10_4.z + u_xlat16_17;
					    u_xlat16_9.x = u_xlat10_4.x * u_xlat16_7.y;
					    u_xlat16_1.x = u_xlat16_1.x * u_xlat10_4.y + u_xlat16_9.x;
					    u_xlat16_6.y = u_xlat16_25 * u_xlat10_4.z + u_xlat16_1.x;
					    u_xlat16_1.xyz = u_xlat16_5.xyz + u_xlat16_6.xyz;
					    u_xlat10_2.xyz = texture2D(_EffTex, vs_TEXCOORD1.xy).xyz;
					    SV_Target0.xyz = u_xlat16_1.xyz + u_xlat10_2.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "UNUSE_EFFECT" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute mediump vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_5;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb3 = 0.5>=u_xlat0.x;
					    u_xlat16_2 = (u_xlatb3) ? -12.0 : -0.0;
					    u_xlat16_2 = dot(vec2(u_xlat16_2), u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_5 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD1.y = u_xlat0.y;
					    vs_TEXCOORD1.x = u_xlat16_2 + u_xlat16_5;
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD2.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD2.y = u_xlat0.x;
					    vs_TEXCOORD2.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    return;
					}
					
					#endif
					#ifdef FRAGMENT
					#version 100
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					precision highp int;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _EffTex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					lowp float u_xlat10_0;
					bool u_xlatb0;
					mediump vec4 u_xlat16_1;
					lowp vec3 u_xlat10_2;
					mediump vec4 u_xlat16_3;
					lowp vec3 u_xlat10_4;
					mediump vec3 u_xlat16_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec2 u_xlat16_9;
					mediump vec3 u_xlat16_11;
					mediump float u_xlat16_17;
					mediump float u_xlat16_25;
					lowp float u_xlat10_26;
					void main()
					{
					    u_xlat10_0 = texture2D(_MaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_1.x = u_xlat10_0 + -0.00999999978;
					    SV_Target0.w = u_xlat10_0;
					    u_xlatb0 = u_xlat16_1.x<0.0;
					    if(((int(u_xlatb0) * -1))!=0){discard;}
					    u_xlat16_1.x = vs_TEXCOORD2.w * vs_TEXCOORD2.z;
					    u_xlat16_0 = u_xlat16_1.xxxx * vs_TEXCOORD2.yxyx;
					    u_xlat16_1 = u_xlat16_0.wwyw * vec4(0.412999988, 0.300000012, 0.588, 0.885999978);
					    u_xlat16_9.x = vs_TEXCOORD2.z * 0.298999995 + (-u_xlat16_1.y);
					    u_xlat16_1.x = vs_TEXCOORD2.z * 0.587000012 + u_xlat16_1.x;
					    u_xlat16_1.x = u_xlat16_0.z * 0.0350000001 + u_xlat16_1.x;
					    u_xlat16_9.x = u_xlat16_0.x * 1.25 + u_xlat16_9.x;
					    u_xlat16_17 = vs_TEXCOORD2.z * 0.587000012 + (-u_xlat16_1.z);
					    u_xlat16_25 = vs_TEXCOORD2.z * 0.114 + u_xlat16_1.w;
					    u_xlat16_25 = (-u_xlat16_0.z) * 0.202999994 + u_xlat16_25;
					    u_xlat16_17 = (-u_xlat16_0.z) * 1.04999995 + u_xlat16_17;
					    u_xlat10_2.xyz = texture2D(_Kira2Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.x = u_xlat16_17 * u_xlat10_2.y;
					    u_xlat16_3.x = u_xlat16_9.x * u_xlat10_2.x + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_25 * u_xlat10_2.z + u_xlat16_3.x;
					    u_xlat10_4.xyz = texture2D(_MainTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat10_26 = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_11.x = (-u_xlat10_26) + 1.0;
					    u_xlat16_11.xyz = u_xlat16_11.xxx * u_xlat10_4.xyz;
					    u_xlat16_5.z = u_xlat16_3.x * u_xlat10_26 + u_xlat16_11.z;
					    u_xlat10_4.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_17 = u_xlat16_17 * u_xlat10_4.y;
					    u_xlat16_9.x = u_xlat16_9.x * u_xlat10_4.x + u_xlat16_17;
					    u_xlat16_6.z = u_xlat16_25 * u_xlat10_4.z + u_xlat16_9.x;
					    u_xlat16_9.xy = u_xlat16_0.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_9.x = vs_TEXCOORD2.z * 0.298999995 + u_xlat16_9.x;
					    u_xlat16_17 = vs_TEXCOORD2.z * 0.587000012 + (-u_xlat16_9.y);
					    u_xlat16_17 = u_xlat16_0.z * 0.330000013 + u_xlat16_17;
					    u_xlat16_9.x = u_xlat16_0.z * 0.167999998 + u_xlat16_9.x;
					    u_xlat16_25 = u_xlat10_2.y * u_xlat16_17;
					    u_xlat16_17 = u_xlat10_4.y * u_xlat16_17;
					    u_xlat16_17 = u_xlat16_9.x * u_xlat10_4.x + u_xlat16_17;
					    u_xlat16_9.x = u_xlat16_9.x * u_xlat10_2.x + u_xlat16_25;
					    u_xlat16_3.xw = u_xlat16_0.ww * vec2(0.114, 0.298999995);
					    u_xlat16_3.xw = vs_TEXCOORD2.zz * vec2(0.114, 0.298999995) + (-u_xlat16_3.xw);
					    u_xlat16_7.xy = (-u_xlat16_0.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_3.xw;
					    u_xlat16_25 = u_xlat16_0.z * 0.291999996 + u_xlat16_3.x;
					    u_xlat16_9.x = u_xlat16_7.x * u_xlat10_2.z + u_xlat16_9.x;
					    u_xlat16_5.x = u_xlat16_9.x * u_xlat10_26 + u_xlat16_11.x;
					    u_xlat16_9.x = u_xlat10_2.x * u_xlat16_7.y;
					    u_xlat16_9.x = u_xlat16_1.x * u_xlat10_2.y + u_xlat16_9.x;
					    u_xlat16_9.x = u_xlat16_25 * u_xlat10_2.z + u_xlat16_9.x;
					    u_xlat16_5.y = u_xlat16_9.x * u_xlat10_26 + u_xlat16_11.y;
					    u_xlat16_6.x = u_xlat16_7.x * u_xlat10_4.z + u_xlat16_17;
					    u_xlat16_9.x = u_xlat10_4.x * u_xlat16_7.y;
					    u_xlat16_1.x = u_xlat16_1.x * u_xlat10_4.y + u_xlat16_9.x;
					    u_xlat16_6.y = u_xlat16_25 * u_xlat10_4.z + u_xlat16_1.x;
					    u_xlat16_1.xyz = u_xlat16_5.xyz + u_xlat16_6.xyz;
					    u_xlat10_2.xyz = texture2D(_EffTex, vs_TEXCOORD1.xy).xyz;
					    SV_Target0.xyz = u_xlat16_1.xyz + u_xlat10_2.xyz;
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
				SubProgram "gles hw_tier00 " {
					Keywords { "USE_EFFECT" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "USE_EFFECT" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "USE_EFFECT" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "UNUSE_EFFECT" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "UNUSE_EFFECT" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "UNUSE_EFFECT" }
					"!!GLES"
				}
			}
*/
			ENDCG
		}
	}
}