Shader "Unlit/RBreakSmallPlateShader" {
	Properties {
		_MainTex ("Base", 2D) = "white" {}
		_MaskTex ("Mask", 2D) = "black" {}
		[Toggle] _MainTexDistotion ("Use Distotion", Float) = 0
		[Toggle] _Use_Front1Tex ("Use Texture", Float) = 1
		_Front1TexColor ("Color", Vector) = (1,1,1,1)
		_Front1Tex ("Texture", 2D) = "black" {}
		_Front1TexAnimeType ("Type", Float) = 1
		_Front1TexAnimeSpeed ("Speed", Float) = 0.5
		_Front1TexAnimeSpeed2 ("Speed2", Float) = 0.5
		[Toggle] _Front1TexDistotion ("Use Distotion", Float) = 0
		_Front1TexBlendMode ("Blend", Float) = 0
		[Toggle] _Use_Front2Tex ("Use Texture", Float) = 1
		_Front2TexColor ("Color", Vector) = (1,1,1,1)
		_Front2Tex ("Texture", 2D) = "black" {}
		_Front2TexAnimeType ("Type", Float) = 1
		_Front2TexAnimeSpeed ("Speed", Float) = 0.5
		_Front2TexAnimeSpeed2 ("Speed", Float) = 0.5
		[Toggle] _Front2TexDistotion ("Use Distotion", Float) = 0
		_Front2TexBlendMode ("Blend", Float) = 0
		[Toggle] _Use_Back1Tex ("Use Texture", Float) = 1
		_Back1TexColor ("Color", Vector) = (1,1,1,1)
		_Back1Tex ("Texture", 2D) = "black" {}
		_Back1TexAnimeType ("Type", Float) = 1
		_Back1TexAnimeSpeed ("Speed", Float) = 0.5
		_Back1TexAnimeSpeed2 ("Speed", Float) = 0.5
		[Toggle] _Back1TexDistotion ("Use Distotion", Float) = 0
		_Back1TexBlendMode ("Blend", Float) = 0
		[Toggle] _Use_Back2Tex ("Use Texture", Float) = 1
		_Back2TexColor ("Color", Vector) = (1,1,1,1)
		_Back2Tex ("Texture", 2D) = "black" {}
		_Back2TexAnimeType ("Type", Float) = 1
		_Back2TexAnimeSpeed ("Speed", Float) = 0.5
		_Back2TexAnimeSpeed2 ("Speed", Float) = 0.5
		[Toggle] _Back2TexDistotion ("Use Distotion", Float) = 0
		_Back2TexBlendMode ("Blend", Float) = 0
		_DistotionTex ("Texture", 2D) = "white" {}
		_DistotionTexPower ("Distotion", Float) = 0
		_DistotionTexAnimeType ("Type", Float) = 1
		_DistotionTexAnimeSpeed ("Speed", Float) = 0
		_DistotionTexAnimeSpeed2 ("Speed", Float) = 0
		[Toggle] _IsKira ("IsKira", Float) = 0
		_KiraTex ("Kira (RGB)", 2D) = "white" {}
		_Kira2Tex ("Kira2 (RGB)", 2D) = "white" {}
		_Kira3Tex ("Kira3 (RGB)", 2D) = "white" {}
		_KiraMaskTex ("KiraMask (A)", 2D) = "white" {}
		_FrameTex ("Frame (RGB)", 2D) = "white" {}
		_FrameMaskTex ("Frame Mask (A)", 2D) = "black" {}
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		_ColorMask ("Color Mask", Float) = 15
		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
	}
	SubShader {
		Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask [_ColorMask]
			ZWrite Off
			Cull Off
			Stencil {
				Ref [_Stencil]
				ReadMask [_StencilReadMask]
				WriteMask [_StencilWriteMask]
				Comp [_StencilComp]
				Pass [_StencilOp]
				Fail Keep
				ZFail Keep
			}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#pragma multi_compile _DISTOTIONTEX_SCROLL _DISTOTIONTEX_POLAR _DISTOTIONTEX_ROTATE
			#pragma multi_compile _BACK1TEX_POLAR _BACK1TEX_ROTATE _BACK1TEX_SCROLL
			#pragma multi_compile _BACK2TEX_POLAR _BACK2TEX_ROTATE _BACK2TEX_SCROLL
			#pragma multi_compile _FRONT1TEX_POLAR _FRONT1TEX_ROTATE _FRONT1TEX_SCROLL
			#pragma multi_compile _FRONT2TEX_POLAR _FRONT2TEX_ROTATE _FRONT2TEX_SCROLL

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
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float2 texcoord3 : TEXCOORD3;
				float2 texcoord4 : TEXCOORD4;
				float4 texcoord5 : TEXCOORD5;
				float4 color0 : COLOR0;
			};

			sampler2D _MainTex;
			sampler2D _MaskTex;
			float4 _MainTex_ST;
			sampler2D _DistotionTex;
			float4 _DistotionTex_ST;
			float _DistotionTexAnimeSpeed;
			float _DistotionTexAnimeSpeed2;
			sampler2D _Back1Tex;
			float4 _Back1Tex_ST;
			float _Back1TexAnimeSpeed;
			float _Back1TexAnimeSpeed2;
			sampler2D _Back2Tex;
			float4 _Back2Tex_ST;
			float _Back2TexAnimeSpeed;
			float _Back2TexAnimeSpeed2;
			sampler2D _Front1Tex;
			float4 _Front1Tex_ST;
			float _Front1TexAnimeSpeed;
			float _Front1TexAnimeSpeed2;
			sampler2D _Front2Tex;
			float4 _Front2Tex_ST;
			float _Front2TexAnimeSpeed;
			float _Front2TexAnimeSpeed2;
			sampler2D _FrameTex;
			sampler2D _FrameMaskTex;
			sampler2D _KiraMaskTex;
			sampler2D _KiraTex;
			sampler2D _Kira2Tex;
			sampler2D _Kira3Tex;

			float _DistotionTexPower;
			float _MainTexDistotion;
			float _Back1TexDistotion;
			float _Back2TexDistotion;
			float _Front1TexDistotion;
			float _Front2TexDistotion;
			float4 _Back1TexColor;
			float4 _Back2TexColor;
			float4 _Front1TexColor;
			float4 _Front2TexColor;
			float _IsKira;

			v2f vert(appdata v)
			{
				v2f o;
				float f, s, c, u_xlat8, u_xlat16_3, u_xlat4;
				float2 texCoord, texOff, b, u_xlat1;
				float3 a;
				float4 u_xlat0, phase0_Output0_0;
				
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
				// Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
				// Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
				u_xlat0.xy = TRANSFORM_TEX(v.texcoord0, _MainTex);
				#if _DISTOTIONTEX_SCROLL
					u_xlat0.xy = TRANSFORM_TEX(v.texcoord0, _DistotionTex);
					u_xlat8.x = frac(_Time.x);
					u_xlat0.zw = float2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
				#elif _DISTOTIONTEX_POLAR
					u_xlat0.zw = TRANSFORM_TEX(v.texcoord0, _DistotionTex);
				#elif _DISTOTIONTEX_ROTATE
					f = _Time.x * _DistotionTexAnimeSpeed;
					f = frac(f) * 6.28318548;
					c = cos(f);
					s = sin(f);
					texCoord = TRANSFORM_TEX(v.texcoord0, _DistotionTex);

					a = float3(-s, c, s);
					texOff = texCoord + float2(-0.5, -0.5);
					b.x = dot(a.yx, texOff.xy);
					b.y = dot(a.zy, texOff.xy);
					u_xlat0.zw = b.xy + float2(0.5, 0.5);
				#endif
				phase0_Output0_0 = u_xlat0;

				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_FRONT2TEX_ROTATE" }
				// Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
				//Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" }
				#if _FRONT1TEX_ROTATE
					f = _Time.x * _Front1TexAnimeSpeed;
					f = frac(f) * 6.28318548;
					c = cos(f);
					s = sin(f);
					texCoord = TRANSFORM_TEX(v.texcoord0, _Front1Tex);

					a = float3(-s, c, s);
					texOff = texCoord + float2(-0.5, -0.5);
					b.x = dot(a.yx, texOff.xy);
					b.y = dot(a.zy, texOff.xy);
					o.texcoord1.xy = b.xy + float2(0.5, 0.5);
				#elif _FRONT1TEX_POLAR
					o.texcoord1.xy = TRANSFORM_TEX(v.texcoord0, _Front1Tex);
				#elif _FRONT1TEX_SCROLL
					texCoord = TRANSFORM_TEX(v.texcoord0, _Front1Tex);
					f = frac(_Time.x);
					o.texcoord1.xy = float2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * float2(f, f) + texCoord;
				#endif

				#if _FRONT2TEX_ROTATE
					f = _Time.x * _Front2TexAnimeSpeed;
					f = frac(f) * 6.28318548;
					c = cos(f);
					s = sin(f);
					texCoord = TRANSFORM_TEX(v.texcoord0, _Front2Tex);

					a = float3(-s, c, s);
					texOff = texCoord + float2(-0.5, -0.5);
					b.x = dot(a.yx, texOff.xy);
					b.y = dot(a.zy, texOff.xy);
					o.texcoord1.zw = b.xy + float2(0.5, 0.5);
				#elif _FRONT2TEX_POLAR
					o.texcoord1.zw = TRANSFORM_TEX(v.texcoord0, _Front2Tex);
				#elif _FRONT2TEX_SCROLL
					texCoord = TRANSFORM_TEX(v.texcoord0, _Front2Tex);
					f = frac(_Time.x);
					o.texcoord1.zw = float2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * float2(f, f) + texCoord;
				#endif


				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
				// Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
				//Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
				//Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" }
				#if _BACK1TEX_ROTATE
					f = _Time.x * _Back1TexAnimeSpeed;
					f = frac(f) * 6.28318548;
					c = cos(f);
					s = sin(f);
					texCoord = TRANSFORM_TEX(v.texcoord0, _Back1Tex);

					a = float3(-s, c, s);
					texOff = texCoord + float2(-0.5, -0.5);
					b.x = dot(a.yx, texOff.xy);
					b.y = dot(a.zy, texOff.xy);
					o.texcoord2.xy = b.xy + float2(0.5, 0.5);
				#elif _BACK1TEX_POLAR
					o.texcoord2.xy = TRANSFORM_TEX(v.texcoord0, _Back1Tex);
				#elif _BACK1TEX_SCROLL
					texCoord = TRANSFORM_TEX(v.texcoord0, _Back1Tex);
					f = frac(_Time.x);
					o.texcoord2.xy = float2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * float2(f, f) + texCoord;
				#endif
				#if _BACK2TEX_ROTATE
					f = _Time.x * _Back2TexAnimeSpeed;
					f = frac(f) * 6.28318548;
					c = cos(f);
					s = sin(f);
					texCoord = TRANSFORM_TEX(v.texcoord0, _Back2Tex);

					a = float3(-s, c, s);
					texOff = texCoord + float2(-0.5, -0.5);
					b.x = dot(a.yx, texOff.xy);
					b.y = dot(a.zy, texOff.xy);
					o.texcoord2.zw = b.xy + float2(0.5, 0.5);
				#elif _BACK2TEX_POLAR
					o.texcoord2.zw = TRANSFORM_TEX(v.texcoord0, _Back2Tex);
				#elif _BACK2TEX_SCROLL
					texCoord = TRANSFORM_TEX(v.texcoord0, _Back2Tex);
					f = frac(_Time.x);
					o.texcoord2.zw = float2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * float2(f, f) + texCoord;
				#endif

				u_xlat0.x = _Time.y * 0.25;
				u_xlat0.x = frac(u_xlat0.x);
				bool u_xlatb4 = 0.5>=u_xlat0.x;
				u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
				u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
				u_xlat0.xy = v.texcoord0.xy + float2(-0.5, -0.5);
				u_xlat1.x = dot(float2(0.707106769, -0.707106769), u_xlat0.xy);
				u_xlat1.y = dot(float2(0.707106769, 0.707106769), u_xlat0.xy);
				u_xlat0.xy = u_xlat1.xy + float2(0.5, 0.5);
				float u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
				o.texcoord4.y = u_xlat0.y;
				o.texcoord4.x = u_xlat16_3.x + u_xlat16_7;
				u_xlat0.x = _SinTime.w * _SinTime.w;
				u_xlat0.x = u_xlat0.x * _SinTime.w;
				u_xlat0.x = u_xlat0.x * 4.0;
				u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
				o.texcoord5.x = u_xlat0.x;
				u_xlat0.x = _CosTime.w * _CosTime.w;
				u_xlat0.x = u_xlat0.x * _CosTime.w;
				u_xlat4.x = _CosTime.w * 3.0;
				u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
				o.texcoord5.y = u_xlat0.x;
				o.texcoord5.zw = float2(1.0, 1.0);

				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
				// Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
				o.color0 = v.color0;

				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
				// Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
				// u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
				// u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
				// u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
				// u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
				// u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
				// u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
				// u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
				// gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
				o.position0 = UnityObjectToClipPos(v.position0);

				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
				// Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
				o.texcoord0 = phase0_Output0_0.xy;

				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
				// Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
				o.texcoord3 = phase0_Output0_0.zw;


				return o; 
			}
/*
			GpuProgramID 43969
			Program "vp" {
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat8.x = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					vec4 u_xlat1;
					mediump vec4 u_xlat16_1;
					vec2 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					bvec2 u_xlatb3;
					mediump vec3 u_xlat16_4;
					vec2 u_xlat5;
					mediump vec3 u_xlat16_5;
					lowp vec3 u_xlat10_5;
					lowp vec3 u_xlat10_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					mediump vec2 u_xlat16_10;
					float u_xlat12;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					mediump vec3 u_xlat16_13;
					lowp vec3 u_xlat10_13;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump float u_xlat16_20;
					mediump vec2 u_xlat16_21;
					vec2 u_xlat22;
					mediump vec2 u_xlat16_22;
					ivec2 u_xlati22;
					bvec2 u_xlatb22;
					mediump vec2 u_xlat16_24;
					mediump float u_xlat16_30;
					bool u_xlatb32;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0 = vs_TEXCOORD2.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = vec2(1.0, 1.0) / u_xlat16_1.xy;
					    u_xlat16_21.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_21.xy;
					    u_xlat16_21.xy = u_xlat16_1.xy * u_xlat16_1.xy;
					    u_xlat16_2.xy = u_xlat16_21.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_22.xy = u_xlat16_1.xy * u_xlat16_2.xy;
					    u_xlat22.xy = u_xlat16_22.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb3.xy = lessThan(abs(u_xlat16_0.ywyy), abs(u_xlat16_0.xzxx)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), u_xlat22.xy, vec2(u_xlatb3.xy));
					    u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat22.xy;
					    u_xlatb22.xy = lessThan(u_xlat16_0.ywyw, (-u_xlat16_0.ywyw)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb22.xy));
					    u_xlat2.xy = u_xlat22.xy + u_xlat2.xy;
					    u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb22.xy = lessThan(u_xlat16_1.xyxy, (-u_xlat16_1.xyxy)).xy;
					    u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb3.xy = greaterThanEqual(u_xlat16_1.xyxx, (-u_xlat16_1.xyxx)).xy;
					    u_xlati22.xy = op_and((ivec2(u_xlatb22.xy) * -1), (ivec2(u_xlatb3.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat2;
					        hlslcc_movcTemp.x = (u_xlati22.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					        hlslcc_movcTemp.y = (u_xlati22.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					        u_xlat2 = hlslcc_movcTemp;
					    }
					    u_xlat16_1.xy = u_xlat2.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat2.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed2, _Back2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
					    u_xlat10_12.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_12.xy = u_xlat10_12.xy + vec2(-0.5, -0.5);
					    u_xlat16_12.xy = u_xlat16_12.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xy = u_xlat16_12.xy * u_xlat10_3.zz;
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
					    u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat1.w = _Back2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					    u_xlat16_10.xy = u_xlat16_4.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat1.yw;
					    u_xlat10_12.xyz = texture2D(_Back2Tex, u_xlat16_10.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Back2TexColor.xyz;
					    u_xlat1.z = _Back1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat1.xz;
					    u_xlat10_5.xyz = texture2D(_Back1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_5.xyz = u_xlat10_5.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_0.xy).xyz;
					    u_xlat16_0.xyz = u_xlat16_5.xyz * u_xlat10_3.yyy + u_xlat10_6.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_3.yyy + u_xlat16_0.xyz;
					    u_xlat16_24.xy = vs_TEXCOORD1.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_30 = max(abs(u_xlat16_24.y), abs(u_xlat16_24.x));
					    u_xlat16_30 = float(1.0) / u_xlat16_30;
					    u_xlat16_7.x = min(abs(u_xlat16_24.y), abs(u_xlat16_24.x));
					    u_xlat16_30 = u_xlat16_30 * u_xlat16_7.x;
					    u_xlat16_7.x = u_xlat16_30 * u_xlat16_30;
					    u_xlat16_12.x = u_xlat16_7.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + 0.180141002;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + -0.330299497;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + 0.999866009;
					    u_xlat16_22.x = u_xlat16_30 * u_xlat16_12.x;
					    u_xlat22.x = u_xlat16_22.x * -2.0 + 1.57079637;
					    u_xlatb32 = abs(u_xlat16_24.y)<abs(u_xlat16_24.x);
					    u_xlat22.x = u_xlatb32 ? u_xlat22.x : float(0.0);
					    u_xlat12 = u_xlat16_30 * u_xlat16_12.x + u_xlat22.x;
					    u_xlatb22.x = u_xlat16_24.y<(-u_xlat16_24.y);
					    u_xlat22.x = u_xlatb22.x ? -3.14159274 : float(0.0);
					    u_xlat12 = u_xlat22.x + u_xlat12;
					    u_xlat16_30 = min(u_xlat16_24.y, u_xlat16_24.x);
					    u_xlatb22.x = u_xlat16_30<(-u_xlat16_30);
					    u_xlat16_30 = max(u_xlat16_24.y, u_xlat16_24.x);
					    u_xlat16_24.x = dot(u_xlat16_24.xy, u_xlat16_24.xy);
					    u_xlat16_24.x = sqrt(u_xlat16_24.x);
					    u_xlat16_24.x = (-u_xlat16_24.x) + 1.0;
					    u_xlat5.y = _Front1TexAnimeSpeed * u_xlat2.x + u_xlat16_24.x;
					    u_xlatb32 = u_xlat16_30>=(-u_xlat16_30);
					    u_xlatb22.x = u_xlatb32 && u_xlatb22.x;
					    u_xlat12 = (u_xlatb22.x) ? (-u_xlat12) : u_xlat12;
					    u_xlat16_30 = u_xlat12 * 0.159154937 + 0.75;
					    u_xlat5.x = _Front1TexAnimeSpeed2 * u_xlat2.x + u_xlat16_30;
					    u_xlat16_24.xy = u_xlat16_4.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat5.xy;
					    u_xlat16_4.xy = u_xlat16_4.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_2.xyz = texture2D(_Front2Tex, u_xlat16_4.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front2TexColor.xyz;
					    u_xlat10_13.xyz = texture2D(_Front1Tex, u_xlat16_24.xy).xyz;
					    u_xlat16_13.xyz = u_xlat10_13.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_13.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_2.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
					    u_xlat10_2.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_2.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_2.x) * _IsKira + 1.0;
					    u_xlat16_2.x = u_xlat10_2.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_1.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24.x = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_24.x;
					    u_xlat16_14.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_12.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_12.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_12.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24.x * u_xlat10_12.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_2.x + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_1.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20 = u_xlat16_1.z * 0.167999998 + u_xlat16_20;
					    u_xlat16_37 = u_xlat10_12.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20 * u_xlat10_12.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_1.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_12.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_2.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_12.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_12.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_8.x * u_xlat10_12.z + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_0.x * u_xlat16_2.x + u_xlat16_0.y;
					    u_xlat10_2.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_2.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat10_2.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_2.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front2TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					vec4 u_xlat1;
					mediump vec4 u_xlat16_1;
					vec2 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					vec2 u_xlat3;
					lowp vec3 u_xlat10_3;
					bvec2 u_xlatb3;
					mediump vec3 u_xlat16_4;
					vec2 u_xlat5;
					mediump vec3 u_xlat16_5;
					lowp vec3 u_xlat10_5;
					lowp vec3 u_xlat10_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					mediump vec2 u_xlat16_10;
					float u_xlat12;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					mediump vec3 u_xlat16_13;
					lowp vec3 u_xlat10_13;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump float u_xlat16_20;
					mediump vec2 u_xlat16_21;
					vec2 u_xlat22;
					mediump vec2 u_xlat16_22;
					ivec2 u_xlati22;
					bvec2 u_xlatb22;
					mediump vec2 u_xlat16_24;
					mediump float u_xlat16_30;
					bool u_xlatb32;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0 = vs_TEXCOORD2.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = vec2(1.0, 1.0) / u_xlat16_1.xy;
					    u_xlat16_21.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_21.xy;
					    u_xlat16_21.xy = u_xlat16_1.xy * u_xlat16_1.xy;
					    u_xlat16_2.xy = u_xlat16_21.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_22.xy = u_xlat16_1.xy * u_xlat16_2.xy;
					    u_xlat22.xy = u_xlat16_22.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb3.xy = lessThan(abs(u_xlat16_0.ywyy), abs(u_xlat16_0.xzxx)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), u_xlat22.xy, vec2(u_xlatb3.xy));
					    u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat22.xy;
					    u_xlatb22.xy = lessThan(u_xlat16_0.ywyw, (-u_xlat16_0.ywyw)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb22.xy));
					    u_xlat2.xy = u_xlat22.xy + u_xlat2.xy;
					    u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb22.xy = lessThan(u_xlat16_1.xyxy, (-u_xlat16_1.xyxy)).xy;
					    u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb3.xy = greaterThanEqual(u_xlat16_1.xyxx, (-u_xlat16_1.xyxx)).xy;
					    u_xlati22.xy = op_and((ivec2(u_xlatb22.xy) * -1), (ivec2(u_xlatb3.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat2;
					        hlslcc_movcTemp.x = (u_xlati22.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					        hlslcc_movcTemp.y = (u_xlati22.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					        u_xlat2 = hlslcc_movcTemp;
					    }
					    u_xlat16_1.xy = u_xlat2.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat2.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed2, _Back2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
					    u_xlat16_4.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_24.x = max(abs(u_xlat16_4.y), abs(u_xlat16_4.x));
					    u_xlat16_24.x = float(1.0) / u_xlat16_24.x;
					    u_xlat16_34 = min(abs(u_xlat16_4.y), abs(u_xlat16_4.x));
					    u_xlat16_24.x = u_xlat16_24.x * u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24.x * u_xlat16_24.x;
					    u_xlat16_12.x = u_xlat16_34 * 0.0208350997 + -0.0851330012;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + 0.180141002;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + -0.330299497;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + 0.999866009;
					    u_xlat16_22.x = u_xlat16_12.x * u_xlat16_24.x;
					    u_xlat22.x = u_xlat16_22.x * -2.0 + 1.57079637;
					    u_xlatb32 = abs(u_xlat16_4.y)<abs(u_xlat16_4.x);
					    u_xlat22.x = u_xlatb32 ? u_xlat22.x : float(0.0);
					    u_xlat12 = u_xlat16_24.x * u_xlat16_12.x + u_xlat22.x;
					    u_xlatb22.x = u_xlat16_4.y<(-u_xlat16_4.y);
					    u_xlat22.x = u_xlatb22.x ? -3.14159274 : float(0.0);
					    u_xlat12 = u_xlat22.x + u_xlat12;
					    u_xlat16_24.x = min(u_xlat16_4.y, u_xlat16_4.x);
					    u_xlatb22.x = u_xlat16_24.x<(-u_xlat16_24.x);
					    u_xlat16_24.x = max(u_xlat16_4.y, u_xlat16_4.x);
					    u_xlat16_4.x = dot(u_xlat16_4.xy, u_xlat16_4.xy);
					    u_xlat16_4.x = sqrt(u_xlat16_4.x);
					    u_xlat16_4.x = (-u_xlat16_4.x) + 1.0;
					    u_xlat3.y = _DistotionTexAnimeSpeed * u_xlat2.x + u_xlat16_4.x;
					    u_xlatb32 = u_xlat16_24.x>=(-u_xlat16_24.x);
					    u_xlatb22.x = u_xlatb32 && u_xlatb22.x;
					    u_xlat12 = (u_xlatb22.x) ? (-u_xlat12) : u_xlat12;
					    u_xlat16_4.x = u_xlat12 * 0.159154937 + 0.75;
					    u_xlat3.x = _DistotionTexAnimeSpeed2 * u_xlat2.x + u_xlat16_4.x;
					    u_xlat10_12.xy = texture2D(_DistotionTex, u_xlat3.xy).xy;
					    u_xlat16_12.xy = u_xlat10_12.xy + vec2(-0.5, -0.5);
					    u_xlat16_12.xy = u_xlat16_12.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xy = u_xlat16_12.xy * u_xlat10_3.zz;
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
					    u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat1.w = _Back2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					    u_xlat16_10.xy = u_xlat16_4.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat1.yw;
					    u_xlat10_12.xyz = texture2D(_Back2Tex, u_xlat16_10.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Back2TexColor.xyz;
					    u_xlat1.z = _Back1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat1.xz;
					    u_xlat10_5.xyz = texture2D(_Back1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_5.xyz = u_xlat10_5.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_0.xy).xyz;
					    u_xlat16_0.xyz = u_xlat16_5.xyz * u_xlat10_3.yyy + u_xlat10_6.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_3.yyy + u_xlat16_0.xyz;
					    u_xlat16_24.xy = vs_TEXCOORD1.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_30 = max(abs(u_xlat16_24.y), abs(u_xlat16_24.x));
					    u_xlat16_30 = float(1.0) / u_xlat16_30;
					    u_xlat16_7.x = min(abs(u_xlat16_24.y), abs(u_xlat16_24.x));
					    u_xlat16_30 = u_xlat16_30 * u_xlat16_7.x;
					    u_xlat16_7.x = u_xlat16_30 * u_xlat16_30;
					    u_xlat16_12.x = u_xlat16_7.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + 0.180141002;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + -0.330299497;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + 0.999866009;
					    u_xlat16_22.x = u_xlat16_30 * u_xlat16_12.x;
					    u_xlat22.x = u_xlat16_22.x * -2.0 + 1.57079637;
					    u_xlatb32 = abs(u_xlat16_24.y)<abs(u_xlat16_24.x);
					    u_xlat22.x = u_xlatb32 ? u_xlat22.x : float(0.0);
					    u_xlat12 = u_xlat16_30 * u_xlat16_12.x + u_xlat22.x;
					    u_xlatb22.x = u_xlat16_24.y<(-u_xlat16_24.y);
					    u_xlat22.x = u_xlatb22.x ? -3.14159274 : float(0.0);
					    u_xlat12 = u_xlat22.x + u_xlat12;
					    u_xlat16_30 = min(u_xlat16_24.y, u_xlat16_24.x);
					    u_xlatb22.x = u_xlat16_30<(-u_xlat16_30);
					    u_xlat16_30 = max(u_xlat16_24.y, u_xlat16_24.x);
					    u_xlat16_24.x = dot(u_xlat16_24.xy, u_xlat16_24.xy);
					    u_xlat16_24.x = sqrt(u_xlat16_24.x);
					    u_xlat16_24.x = (-u_xlat16_24.x) + 1.0;
					    u_xlat5.y = _Front1TexAnimeSpeed * u_xlat2.x + u_xlat16_24.x;
					    u_xlatb32 = u_xlat16_30>=(-u_xlat16_30);
					    u_xlatb22.x = u_xlatb32 && u_xlatb22.x;
					    u_xlat12 = (u_xlatb22.x) ? (-u_xlat12) : u_xlat12;
					    u_xlat16_30 = u_xlat12 * 0.159154937 + 0.75;
					    u_xlat5.x = _Front1TexAnimeSpeed2 * u_xlat2.x + u_xlat16_30;
					    u_xlat16_24.xy = u_xlat16_4.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat5.xy;
					    u_xlat16_4.xy = u_xlat16_4.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_2.xyz = texture2D(_Front2Tex, u_xlat16_4.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front2TexColor.xyz;
					    u_xlat10_13.xyz = texture2D(_Front1Tex, u_xlat16_24.xy).xyz;
					    u_xlat16_13.xyz = u_xlat10_13.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_13.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_2.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
					    u_xlat10_2.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_2.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_2.x) * _IsKira + 1.0;
					    u_xlat16_2.x = u_xlat10_2.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_1.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24.x = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_24.x;
					    u_xlat16_14.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_12.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_12.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_12.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24.x * u_xlat10_12.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_2.x + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_1.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20 = u_xlat16_1.z * 0.167999998 + u_xlat16_20;
					    u_xlat16_37 = u_xlat10_12.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20 * u_xlat10_12.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_1.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_12.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_2.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_12.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_12.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_8.x * u_xlat10_12.z + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_0.x * u_xlat16_2.x + u_xlat16_0.y;
					    u_xlat10_2.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_2.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat10_2.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_2.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					lowp vec3 u_xlat10_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					float u_xlat10;
					mediump vec3 u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_16;
					mediump float u_xlat16_18;
					float u_xlat19;
					mediump float u_xlat16_19;
					bool u_xlatb19;
					mediump float u_xlat16_21;
					mediump float u_xlat16_27;
					bool u_xlatb28;
					mediump float u_xlat16_30;
					mediump float u_xlat16_33;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18 = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = float(1.0) / u_xlat16_18;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = u_xlat16_18 * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18 * u_xlat16_18;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10.x = u_xlat16_18 * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10.x * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18 * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18 = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18<(-u_xlat16_18);
					    u_xlat16_18 = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_18>=(-u_xlat16_18);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat16_9.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_3.x = min(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_10.x = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + 0.180141002;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + -0.330299497;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + 0.999866009;
					    u_xlat16_19 = u_xlat16_27 * u_xlat16_10.x;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_9.y)<abs(u_xlat16_9.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_27 * u_xlat16_10.x + u_xlat19;
					    u_xlatb19 = u_xlat16_9.y<(-u_xlat16_9.y);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_27 = min(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlatb19 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlat16_9.x = dot(u_xlat16_9.xy, u_xlat16_9.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_9.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb28 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_9.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat10_10.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_10.xy = u_xlat10_10.xy + vec2(-0.5, -0.5);
					    u_xlat16_10.xy = u_xlat16_10.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_9.xy = u_xlat16_10.xy * u_xlat10_4.zz;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_10.xyz = texture2D(_Back2Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_10.xyz = u_xlat10_10.xyz * _Back2TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_5.xyz = texture2D(_MainTex, u_xlat16_0.xw).xyz;
					    u_xlat16_3.xyz = u_xlat16_2.xyz * u_xlat10_4.yyy + u_xlat10_5.xyz;
					    u_xlat16_3.xyz = u_xlat16_10.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_0.xw = vs_TEXCOORD1.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_30 = max(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_30 = float(1.0) / u_xlat16_30;
					    u_xlat16_6.x = min(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_30 = u_xlat16_30 * u_xlat16_6.x;
					    u_xlat16_6.x = u_xlat16_30 * u_xlat16_30;
					    u_xlat16_10.x = u_xlat16_6.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + 0.180141002;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + -0.330299497;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + 0.999866009;
					    u_xlat16_19 = u_xlat16_10.x * u_xlat16_30;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_0.w)<abs(u_xlat16_0.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_30 * u_xlat16_10.x + u_xlat19;
					    u_xlatb19 = u_xlat16_0.w<(-u_xlat16_0.w);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_30 = min(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_30<(-u_xlat16_30);
					    u_xlat16_30 = max(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xw, u_xlat16_0.xw);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlat2.y = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlatb28 = u_xlat16_30>=(-u_xlat16_30);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_0.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat2.x = _Front1TexAnimeSpeed2 * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat2.xy;
					    u_xlat16_9.xy = u_xlat16_9.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_9.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_21 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_21 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_21;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_30 = u_xlat10_10.y * u_xlat16_12.x;
					    u_xlat16_30 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_30;
					    u_xlat16_30 = u_xlat16_21 * u_xlat10_10.z + u_xlat16_30;
					    u_xlat16_6.z = u_xlat16_30 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_30 = u_xlat16_2.z * 0.330000013 + u_xlat16_30;
					    u_xlat16_18 = u_xlat16_2.z * 0.167999998 + u_xlat16_18;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_30;
					    u_xlat16_33 = u_xlat16_18 * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_21 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_30;
					    u_xlat16_0.x = u_xlat16_18 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					mediump vec2 u_xlat16_5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_11;
					float u_xlat12;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat12 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat12) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = _Time.xx * vec2(_Front1TexAnimeSpeed, _Front2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2 = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD1.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_5.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_5.x = dot(u_xlat16_5.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_11 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_5.x + u_xlat16_11;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					vec4 u_xlat1;
					mediump vec4 u_xlat16_1;
					vec2 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					bvec2 u_xlatb3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					lowp vec3 u_xlat10_5;
					lowp vec3 u_xlat10_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					lowp vec3 u_xlat10_12;
					mediump vec3 u_xlat16_13;
					lowp vec3 u_xlat10_13;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump vec2 u_xlat16_20;
					mediump vec2 u_xlat16_21;
					vec2 u_xlat22;
					mediump vec2 u_xlat16_22;
					ivec2 u_xlati22;
					bvec2 u_xlatb22;
					mediump float u_xlat16_24;
					mediump float u_xlat16_30;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0 = vs_TEXCOORD2.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = vec2(1.0, 1.0) / u_xlat16_1.xy;
					    u_xlat16_21.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_21.xy;
					    u_xlat16_21.xy = u_xlat16_1.xy * u_xlat16_1.xy;
					    u_xlat16_2.xy = u_xlat16_21.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_22.xy = u_xlat16_1.xy * u_xlat16_2.xy;
					    u_xlat22.xy = u_xlat16_22.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb3.xy = lessThan(abs(u_xlat16_0.ywyy), abs(u_xlat16_0.xzxx)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), u_xlat22.xy, vec2(u_xlatb3.xy));
					    u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat22.xy;
					    u_xlatb22.xy = lessThan(u_xlat16_0.ywyw, (-u_xlat16_0.ywyw)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb22.xy));
					    u_xlat2.xy = u_xlat22.xy + u_xlat2.xy;
					    u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb22.xy = lessThan(u_xlat16_1.xyxy, (-u_xlat16_1.xyxy)).xy;
					    u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb3.xy = greaterThanEqual(u_xlat16_1.xyxx, (-u_xlat16_1.xyxx)).xy;
					    u_xlati22.xy = op_and((ivec2(u_xlatb22.xy) * -1), (ivec2(u_xlatb3.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat2;
					        hlslcc_movcTemp.x = (u_xlati22.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					        hlslcc_movcTemp.y = (u_xlati22.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					        u_xlat2 = hlslcc_movcTemp;
					    }
					    u_xlat16_1.xy = u_xlat2.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat2.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed2, _Back2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
					    u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat1.w = _Back2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					    u_xlat1.z = _Back1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					    u_xlat10_2.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_2.xy = u_xlat10_2.xy + vec2(-0.5, -0.5);
					    u_xlat16_2.xy = u_xlat16_2.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_2.xy * u_xlat10_3.zz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat1.xz;
					    u_xlat16_4.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat1.yw;
					    u_xlat10_2.xyz = texture2D(_Back2Tex, u_xlat16_4.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back2TexColor.xyz;
					    u_xlat10_5.xyz = texture2D(_Back1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_5.xyz = u_xlat10_5.xyz * _Back1TexColor.xyz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_20.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_5.xyz * u_xlat10_3.yyy + u_xlat10_6.xyz;
					    u_xlat16_4.xyz = u_xlat16_2.xyz * u_xlat10_3.yyy + u_xlat16_4.xyz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_2.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front2TexColor.xyz;
					    u_xlat10_13.xyz = texture2D(_Front1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_13.xyz = u_xlat10_13.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_13.xyz * u_xlat10_3.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_2.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
					    u_xlat10_2.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_2.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_2.x) * _IsKira + 1.0;
					    u_xlat16_2.x = u_xlat10_2.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_1.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24 = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_24;
					    u_xlat16_14.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_12.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_12.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_12.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24 * u_xlat10_12.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_2.x + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_1.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20.x = u_xlat16_1.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat16_37 = u_xlat10_12.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20.x * u_xlat10_12.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_1.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_12.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_2.x + u_xlat16_0.x;
					    u_xlat10_3.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_3.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_3.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24 * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_3.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20.x * u_xlat10_3.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat10_5.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.x = u_xlat10_3.x * u_xlat16_18.y;
					    u_xlat16_20.x = u_xlat10_12.x * u_xlat16_18.y;
					    u_xlat16_20.x = u_xlat16_4.x * u_xlat10_12.y + u_xlat16_20.x;
					    u_xlat16_20.x = u_xlat16_8.x * u_xlat10_12.z + u_xlat16_20.x;
					    u_xlat16_7.y = u_xlat16_20.x * u_xlat16_2.x + u_xlat16_0.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_3.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat10_5.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					mediump vec2 u_xlat16_5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_11;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = _Time.xx * vec2(_Front1TexAnimeSpeed, _Front2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2 = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD1.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_5.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_5.x = dot(u_xlat16_5.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_11 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_5.x + u_xlat16_11;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					vec4 u_xlat1;
					mediump vec4 u_xlat16_1;
					vec2 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					vec2 u_xlat3;
					lowp vec3 u_xlat10_3;
					bvec2 u_xlatb3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					lowp vec3 u_xlat10_5;
					lowp vec3 u_xlat10_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					mediump vec2 u_xlat16_10;
					float u_xlat12;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					mediump vec3 u_xlat16_13;
					lowp vec3 u_xlat10_13;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump float u_xlat16_20;
					mediump vec2 u_xlat16_21;
					vec2 u_xlat22;
					mediump vec2 u_xlat16_22;
					ivec2 u_xlati22;
					bvec2 u_xlatb22;
					mediump vec2 u_xlat16_24;
					mediump float u_xlat16_30;
					bool u_xlatb32;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0 = vs_TEXCOORD2.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = vec2(1.0, 1.0) / u_xlat16_1.xy;
					    u_xlat16_21.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_21.xy;
					    u_xlat16_21.xy = u_xlat16_1.xy * u_xlat16_1.xy;
					    u_xlat16_2.xy = u_xlat16_21.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_22.xy = u_xlat16_1.xy * u_xlat16_2.xy;
					    u_xlat22.xy = u_xlat16_22.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb3.xy = lessThan(abs(u_xlat16_0.ywyy), abs(u_xlat16_0.xzxx)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), u_xlat22.xy, vec2(u_xlatb3.xy));
					    u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat22.xy;
					    u_xlatb22.xy = lessThan(u_xlat16_0.ywyw, (-u_xlat16_0.ywyw)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb22.xy));
					    u_xlat2.xy = u_xlat22.xy + u_xlat2.xy;
					    u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb22.xy = lessThan(u_xlat16_1.xyxy, (-u_xlat16_1.xyxy)).xy;
					    u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb3.xy = greaterThanEqual(u_xlat16_1.xyxx, (-u_xlat16_1.xyxx)).xy;
					    u_xlati22.xy = op_and((ivec2(u_xlatb22.xy) * -1), (ivec2(u_xlatb3.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat2;
					        hlslcc_movcTemp.x = (u_xlati22.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					        hlslcc_movcTemp.y = (u_xlati22.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					        u_xlat2 = hlslcc_movcTemp;
					    }
					    u_xlat16_1.xy = u_xlat2.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat2.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed2, _Back2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
					    u_xlat16_4.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_24.x = max(abs(u_xlat16_4.y), abs(u_xlat16_4.x));
					    u_xlat16_24.x = float(1.0) / u_xlat16_24.x;
					    u_xlat16_34 = min(abs(u_xlat16_4.y), abs(u_xlat16_4.x));
					    u_xlat16_24.x = u_xlat16_24.x * u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24.x * u_xlat16_24.x;
					    u_xlat16_12.x = u_xlat16_34 * 0.0208350997 + -0.0851330012;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + 0.180141002;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + -0.330299497;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + 0.999866009;
					    u_xlat16_22.x = u_xlat16_12.x * u_xlat16_24.x;
					    u_xlat22.x = u_xlat16_22.x * -2.0 + 1.57079637;
					    u_xlatb32 = abs(u_xlat16_4.y)<abs(u_xlat16_4.x);
					    u_xlat22.x = u_xlatb32 ? u_xlat22.x : float(0.0);
					    u_xlat12 = u_xlat16_24.x * u_xlat16_12.x + u_xlat22.x;
					    u_xlatb22.x = u_xlat16_4.y<(-u_xlat16_4.y);
					    u_xlat22.x = u_xlatb22.x ? -3.14159274 : float(0.0);
					    u_xlat12 = u_xlat22.x + u_xlat12;
					    u_xlat16_24.x = min(u_xlat16_4.y, u_xlat16_4.x);
					    u_xlatb22.x = u_xlat16_24.x<(-u_xlat16_24.x);
					    u_xlat16_24.x = max(u_xlat16_4.y, u_xlat16_4.x);
					    u_xlat16_4.x = dot(u_xlat16_4.xy, u_xlat16_4.xy);
					    u_xlat16_4.x = sqrt(u_xlat16_4.x);
					    u_xlat16_4.x = (-u_xlat16_4.x) + 1.0;
					    u_xlat3.y = _DistotionTexAnimeSpeed * u_xlat2.x + u_xlat16_4.x;
					    u_xlatb32 = u_xlat16_24.x>=(-u_xlat16_24.x);
					    u_xlatb22.x = u_xlatb32 && u_xlatb22.x;
					    u_xlat12 = (u_xlatb22.x) ? (-u_xlat12) : u_xlat12;
					    u_xlat16_4.x = u_xlat12 * 0.159154937 + 0.75;
					    u_xlat3.x = _DistotionTexAnimeSpeed2 * u_xlat2.x + u_xlat16_4.x;
					    u_xlat10_12.xy = texture2D(_DistotionTex, u_xlat3.xy).xy;
					    u_xlat16_12.xy = u_xlat10_12.xy + vec2(-0.5, -0.5);
					    u_xlat16_12.xy = u_xlat16_12.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xy = u_xlat16_12.xy * u_xlat10_3.zz;
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
					    u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat1.w = _Back2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					    u_xlat16_10.xy = u_xlat16_4.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat1.yw;
					    u_xlat10_12.xyz = texture2D(_Back2Tex, u_xlat16_10.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Back2TexColor.xyz;
					    u_xlat1.z = _Back1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat1.xz;
					    u_xlat10_5.xyz = texture2D(_Back1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_5.xyz = u_xlat10_5.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_0.xy).xyz;
					    u_xlat16_0.xyz = u_xlat16_5.xyz * u_xlat10_3.yyy + u_xlat10_6.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_3.yyy + u_xlat16_0.xyz;
					    u_xlat16_24.xy = u_xlat16_4.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_4.xy = u_xlat16_4.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_2.xyz = texture2D(_Front2Tex, u_xlat16_4.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front2TexColor.xyz;
					    u_xlat10_13.xyz = texture2D(_Front1Tex, u_xlat16_24.xy).xyz;
					    u_xlat16_13.xyz = u_xlat10_13.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_13.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_2.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
					    u_xlat10_2.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_2.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_2.x) * _IsKira + 1.0;
					    u_xlat16_2.x = u_xlat10_2.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_1.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24.x = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_24.x;
					    u_xlat16_14.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_12.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_12.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_12.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24.x * u_xlat10_12.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_2.x + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_1.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20 = u_xlat16_1.z * 0.167999998 + u_xlat16_20;
					    u_xlat16_37 = u_xlat10_12.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20 * u_xlat10_12.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_1.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_12.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_2.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_12.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_12.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_8.x * u_xlat10_12.z + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_0.x * u_xlat16_2.x + u_xlat16_0.y;
					    u_xlat10_2.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_2.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat10_2.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_2.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					mediump vec2 u_xlat16_5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_11;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = _Time.xx * vec2(_Front1TexAnimeSpeed, _Front2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2.x);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2.x;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD1.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.x * _Back1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_5.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_5.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_5.x = dot(u_xlat16_5.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_11 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_5.x + u_xlat16_11;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					lowp vec3 u_xlat10_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_16;
					mediump vec2 u_xlat16_18;
					float u_xlat19;
					mediump float u_xlat16_19;
					bool u_xlatb19;
					mediump float u_xlat16_21;
					mediump float u_xlat16_27;
					bool u_xlatb28;
					mediump float u_xlat16_30;
					mediump float u_xlat16_33;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat16_9.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_3.x = min(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_10 = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + 0.180141002;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + -0.330299497;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + 0.999866009;
					    u_xlat16_19 = u_xlat16_27 * u_xlat16_10;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_9.y)<abs(u_xlat16_9.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_27 * u_xlat16_10 + u_xlat19;
					    u_xlatb19 = u_xlat16_9.y<(-u_xlat16_9.y);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_27 = min(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlatb19 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlat16_9.x = dot(u_xlat16_9.xy, u_xlat16_9.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_9.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb28 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_9.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_4.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_5.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_3.xyz = u_xlat16_2.xyz * u_xlat10_4.yyy + u_xlat10_5.xyz;
					    u_xlat16_3.xyz = u_xlat16_1.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_21 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_21 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_21;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_30 = u_xlat10_10.y * u_xlat16_12.x;
					    u_xlat16_30 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_30;
					    u_xlat16_30 = u_xlat16_21 * u_xlat10_10.z + u_xlat16_30;
					    u_xlat16_6.z = u_xlat16_30 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_30 = u_xlat16_2.z * 0.330000013 + u_xlat16_30;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_30;
					    u_xlat16_33 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_21 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_30;
					    u_xlat16_0.x = u_xlat16_18.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" }
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					float u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat8 = fract(_Time.x);
					    u_xlat0.zw = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * vec2(u_xlat8) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.x = _Time.x * _Back1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					lowp vec3 u_xlat10_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					float u_xlat10;
					mediump vec3 u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_16;
					mediump float u_xlat16_18;
					float u_xlat19;
					mediump float u_xlat16_19;
					bool u_xlatb19;
					mediump float u_xlat16_21;
					mediump float u_xlat16_27;
					bool u_xlatb28;
					mediump float u_xlat16_30;
					mediump float u_xlat16_33;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18 = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = float(1.0) / u_xlat16_18;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = u_xlat16_18 * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18 * u_xlat16_18;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10.x = u_xlat16_18 * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10.x * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18 * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18 = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18<(-u_xlat16_18);
					    u_xlat16_18 = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_18>=(-u_xlat16_18);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat16_9.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_3.x = min(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_10.x = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + 0.180141002;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + -0.330299497;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + 0.999866009;
					    u_xlat16_19 = u_xlat16_27 * u_xlat16_10.x;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_9.y)<abs(u_xlat16_9.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_27 * u_xlat16_10.x + u_xlat19;
					    u_xlatb19 = u_xlat16_9.y<(-u_xlat16_9.y);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_27 = min(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlatb19 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlat16_9.x = dot(u_xlat16_9.xy, u_xlat16_9.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_9.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb28 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_9.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat10_10.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_10.xy = u_xlat10_10.xy + vec2(-0.5, -0.5);
					    u_xlat16_10.xy = u_xlat16_10.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_9.xy = u_xlat16_10.xy * u_xlat10_4.zz;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_10.xyz = texture2D(_Back2Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_10.xyz = u_xlat10_10.xyz * _Back2TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_5.xyz = texture2D(_MainTex, u_xlat16_0.xw).xyz;
					    u_xlat16_3.xyz = u_xlat16_2.xyz * u_xlat10_4.yyy + u_xlat10_5.xyz;
					    u_xlat16_3.xyz = u_xlat16_10.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_0.xw = vs_TEXCOORD1.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_30 = max(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_30 = float(1.0) / u_xlat16_30;
					    u_xlat16_6.x = min(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_30 = u_xlat16_30 * u_xlat16_6.x;
					    u_xlat16_6.x = u_xlat16_30 * u_xlat16_30;
					    u_xlat16_10.x = u_xlat16_6.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + 0.180141002;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + -0.330299497;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + 0.999866009;
					    u_xlat16_19 = u_xlat16_10.x * u_xlat16_30;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_0.w)<abs(u_xlat16_0.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_30 * u_xlat16_10.x + u_xlat19;
					    u_xlatb19 = u_xlat16_0.w<(-u_xlat16_0.w);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_30 = min(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_30<(-u_xlat16_30);
					    u_xlat16_30 = max(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xw, u_xlat16_0.xw);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlat2.y = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlatb28 = u_xlat16_30>=(-u_xlat16_30);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_0.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat2.x = _Front1TexAnimeSpeed2 * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat2.xy;
					    u_xlat16_9.xy = u_xlat16_9.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_9.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_21 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_21 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_21;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_30 = u_xlat10_10.y * u_xlat16_12.x;
					    u_xlat16_30 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_30;
					    u_xlat16_30 = u_xlat16_21 * u_xlat10_10.z + u_xlat16_30;
					    u_xlat16_6.z = u_xlat16_30 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_30 = u_xlat16_2.z * 0.330000013 + u_xlat16_30;
					    u_xlat16_18 = u_xlat16_2.z * 0.167999998 + u_xlat16_18;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_30;
					    u_xlat16_33 = u_xlat16_18 * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_21 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_30;
					    u_xlat16_0.x = u_xlat16_18 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" }
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					float u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat8 = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * vec2(u_xlat8) + u_xlat0.xy;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					lowp vec3 u_xlat10_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_16;
					mediump vec2 u_xlat16_18;
					float u_xlat19;
					mediump float u_xlat16_19;
					bool u_xlatb19;
					mediump float u_xlat16_21;
					mediump float u_xlat16_27;
					bool u_xlatb28;
					mediump float u_xlat16_30;
					mediump float u_xlat16_33;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat16_9.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_3.x = min(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_10 = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + 0.180141002;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + -0.330299497;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + 0.999866009;
					    u_xlat16_19 = u_xlat16_27 * u_xlat16_10;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_9.y)<abs(u_xlat16_9.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_27 * u_xlat16_10 + u_xlat19;
					    u_xlatb19 = u_xlat16_9.y<(-u_xlat16_9.y);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_27 = min(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlatb19 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlat16_9.x = dot(u_xlat16_9.xy, u_xlat16_9.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_9.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb28 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_9.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_4.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_5.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_3.xyz = u_xlat16_2.xyz * u_xlat10_4.yyy + u_xlat10_5.xyz;
					    u_xlat16_3.xyz = u_xlat16_1.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_21 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_21 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_21;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_30 = u_xlat10_10.y * u_xlat16_12.x;
					    u_xlat16_30 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_30;
					    u_xlat16_30 = u_xlat16_21 * u_xlat10_10.z + u_xlat16_30;
					    u_xlat16_6.z = u_xlat16_30 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_30 = u_xlat16_2.z * 0.330000013 + u_xlat16_30;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_30;
					    u_xlat16_33 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_21 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_30;
					    u_xlat16_0.x = u_xlat16_18.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" }
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat8.x = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					lowp vec3 u_xlat10_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_16;
					mediump vec2 u_xlat16_18;
					float u_xlat19;
					mediump float u_xlat16_19;
					bool u_xlatb19;
					mediump float u_xlat16_21;
					mediump float u_xlat16_27;
					bool u_xlatb28;
					mediump float u_xlat16_30;
					mediump float u_xlat16_33;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat16_9.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_3.x = min(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_10 = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + 0.180141002;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + -0.330299497;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + 0.999866009;
					    u_xlat16_19 = u_xlat16_27 * u_xlat16_10;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_9.y)<abs(u_xlat16_9.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_27 * u_xlat16_10 + u_xlat19;
					    u_xlatb19 = u_xlat16_9.y<(-u_xlat16_9.y);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_27 = min(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlatb19 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlat16_9.x = dot(u_xlat16_9.xy, u_xlat16_9.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_9.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb28 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_9.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_4.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_5.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_3.xyz = u_xlat16_2.xyz * u_xlat10_4.yyy + u_xlat10_5.xyz;
					    u_xlat16_3.xyz = u_xlat16_1.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_21 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_21 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_21;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_30 = u_xlat10_10.y * u_xlat16_12.x;
					    u_xlat16_30 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_30;
					    u_xlat16_30 = u_xlat16_21 * u_xlat10_10.z + u_xlat16_30;
					    u_xlat16_6.z = u_xlat16_30 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_30 = u_xlat16_2.z * 0.330000013 + u_xlat16_30;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_30;
					    u_xlat16_33 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_21 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_30;
					    u_xlat16_0.x = u_xlat16_18.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" }
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_5;
					float u_xlat7;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat7 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat7) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat0.xy;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat0.zw = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat1.xy;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
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
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_2 + u_xlat16_5;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					vec4 u_xlat1;
					mediump vec4 u_xlat16_1;
					vec2 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					bvec2 u_xlatb3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					lowp vec3 u_xlat10_5;
					lowp vec3 u_xlat10_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					lowp vec3 u_xlat10_12;
					mediump vec3 u_xlat16_13;
					lowp vec3 u_xlat10_13;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump vec2 u_xlat16_20;
					mediump vec2 u_xlat16_21;
					vec2 u_xlat22;
					mediump vec2 u_xlat16_22;
					ivec2 u_xlati22;
					bvec2 u_xlatb22;
					mediump float u_xlat16_24;
					mediump float u_xlat16_30;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0 = vs_TEXCOORD2.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = vec2(1.0, 1.0) / u_xlat16_1.xy;
					    u_xlat16_21.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_21.xy;
					    u_xlat16_21.xy = u_xlat16_1.xy * u_xlat16_1.xy;
					    u_xlat16_2.xy = u_xlat16_21.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_22.xy = u_xlat16_1.xy * u_xlat16_2.xy;
					    u_xlat22.xy = u_xlat16_22.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb3.xy = lessThan(abs(u_xlat16_0.ywyy), abs(u_xlat16_0.xzxx)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), u_xlat22.xy, vec2(u_xlatb3.xy));
					    u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat22.xy;
					    u_xlatb22.xy = lessThan(u_xlat16_0.ywyw, (-u_xlat16_0.ywyw)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb22.xy));
					    u_xlat2.xy = u_xlat22.xy + u_xlat2.xy;
					    u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb22.xy = lessThan(u_xlat16_1.xyxy, (-u_xlat16_1.xyxy)).xy;
					    u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb3.xy = greaterThanEqual(u_xlat16_1.xyxx, (-u_xlat16_1.xyxx)).xy;
					    u_xlati22.xy = op_and((ivec2(u_xlatb22.xy) * -1), (ivec2(u_xlatb3.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat2;
					        hlslcc_movcTemp.x = (u_xlati22.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					        hlslcc_movcTemp.y = (u_xlati22.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					        u_xlat2 = hlslcc_movcTemp;
					    }
					    u_xlat16_1.xy = u_xlat2.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat2.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed2, _Back2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
					    u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat1.w = _Back2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					    u_xlat1.z = _Back1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					    u_xlat10_2.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_2.xy = u_xlat10_2.xy + vec2(-0.5, -0.5);
					    u_xlat16_2.xy = u_xlat16_2.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_2.xy * u_xlat10_3.zz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat1.xz;
					    u_xlat16_4.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat1.yw;
					    u_xlat10_2.xyz = texture2D(_Back2Tex, u_xlat16_4.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back2TexColor.xyz;
					    u_xlat10_5.xyz = texture2D(_Back1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_5.xyz = u_xlat10_5.xyz * _Back1TexColor.xyz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_20.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_5.xyz * u_xlat10_3.yyy + u_xlat10_6.xyz;
					    u_xlat16_4.xyz = u_xlat16_2.xyz * u_xlat10_3.yyy + u_xlat16_4.xyz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_2.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front2TexColor.xyz;
					    u_xlat10_13.xyz = texture2D(_Front1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_13.xyz = u_xlat10_13.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_13.xyz * u_xlat10_3.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_2.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
					    u_xlat10_2.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_2.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_2.x) * _IsKira + 1.0;
					    u_xlat16_2.x = u_xlat10_2.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_1.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24 = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_24;
					    u_xlat16_14.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_12.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_12.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_12.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24 * u_xlat10_12.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_2.x + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_1.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20.x = u_xlat16_1.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat16_37 = u_xlat10_12.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20.x * u_xlat10_12.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_1.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_12.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_2.x + u_xlat16_0.x;
					    u_xlat10_3.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_3.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_3.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24 * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_3.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20.x * u_xlat10_3.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat10_5.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.x = u_xlat10_3.x * u_xlat16_18.y;
					    u_xlat16_20.x = u_xlat10_12.x * u_xlat16_18.y;
					    u_xlat16_20.x = u_xlat16_4.x * u_xlat10_12.y + u_xlat16_20.x;
					    u_xlat16_20.x = u_xlat16_8.x * u_xlat10_12.z + u_xlat16_20.x;
					    u_xlat16_7.y = u_xlat16_20.x * u_xlat16_2.x + u_xlat16_0.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_3.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat10_5.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" }
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					float u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat8 = fract(_Time.x);
					    u_xlat1.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * vec2(u_xlat8) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat1.zw = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * vec2(u_xlat8) + u_xlat0.xy;
					    vs_TEXCOORD1 = u_xlat1;
					    u_xlat0.x = _Time.x * _Back1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					lowp vec3 u_xlat10_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_16;
					mediump vec2 u_xlat16_18;
					float u_xlat19;
					mediump float u_xlat16_19;
					bool u_xlatb19;
					mediump float u_xlat16_21;
					mediump float u_xlat16_27;
					bool u_xlatb28;
					mediump float u_xlat16_30;
					mediump float u_xlat16_33;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat16_9.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_3.x = min(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_10 = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + 0.180141002;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + -0.330299497;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + 0.999866009;
					    u_xlat16_19 = u_xlat16_27 * u_xlat16_10;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_9.y)<abs(u_xlat16_9.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_27 * u_xlat16_10 + u_xlat19;
					    u_xlatb19 = u_xlat16_9.y<(-u_xlat16_9.y);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_27 = min(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlatb19 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlat16_9.x = dot(u_xlat16_9.xy, u_xlat16_9.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_9.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb28 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_9.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_4.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_5.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_3.xyz = u_xlat16_2.xyz * u_xlat10_4.yyy + u_xlat10_5.xyz;
					    u_xlat16_3.xyz = u_xlat16_1.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_21 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_21 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_21;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_30 = u_xlat10_10.y * u_xlat16_12.x;
					    u_xlat16_30 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_30;
					    u_xlat16_30 = u_xlat16_21 * u_xlat10_10.z + u_xlat16_30;
					    u_xlat16_6.z = u_xlat16_30 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_30 = u_xlat16_2.z * 0.330000013 + u_xlat16_30;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_30;
					    u_xlat16_33 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_21 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_30;
					    u_xlat16_0.x = u_xlat16_18.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" }
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat8.x = fract(_Time.x);
					    u_xlat0.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					lowp vec3 u_xlat10_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					float u_xlat10;
					mediump vec3 u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_16;
					mediump float u_xlat16_18;
					float u_xlat19;
					mediump float u_xlat16_19;
					bool u_xlatb19;
					mediump float u_xlat16_21;
					mediump float u_xlat16_27;
					bool u_xlatb28;
					mediump float u_xlat16_30;
					mediump float u_xlat16_33;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18 = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = float(1.0) / u_xlat16_18;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = u_xlat16_18 * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18 * u_xlat16_18;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10.x = u_xlat16_18 * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10.x * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18 * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18 = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18<(-u_xlat16_18);
					    u_xlat16_18 = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_18>=(-u_xlat16_18);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat16_9.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_3.x = min(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_10.x = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + 0.180141002;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + -0.330299497;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + 0.999866009;
					    u_xlat16_19 = u_xlat16_27 * u_xlat16_10.x;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_9.y)<abs(u_xlat16_9.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_27 * u_xlat16_10.x + u_xlat19;
					    u_xlatb19 = u_xlat16_9.y<(-u_xlat16_9.y);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_27 = min(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlatb19 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlat16_9.x = dot(u_xlat16_9.xy, u_xlat16_9.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_9.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb28 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_9.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat10_10.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_10.xy = u_xlat10_10.xy + vec2(-0.5, -0.5);
					    u_xlat16_10.xy = u_xlat16_10.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_9.xy = u_xlat16_10.xy * u_xlat10_4.zz;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_10.xyz = texture2D(_Back2Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_10.xyz = u_xlat10_10.xyz * _Back2TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_5.xyz = texture2D(_MainTex, u_xlat16_0.xw).xyz;
					    u_xlat16_3.xyz = u_xlat16_2.xyz * u_xlat10_4.yyy + u_xlat10_5.xyz;
					    u_xlat16_3.xyz = u_xlat16_10.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_0.xw = vs_TEXCOORD1.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_30 = max(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_30 = float(1.0) / u_xlat16_30;
					    u_xlat16_6.x = min(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_30 = u_xlat16_30 * u_xlat16_6.x;
					    u_xlat16_6.x = u_xlat16_30 * u_xlat16_30;
					    u_xlat16_10.x = u_xlat16_6.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + 0.180141002;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + -0.330299497;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + 0.999866009;
					    u_xlat16_19 = u_xlat16_10.x * u_xlat16_30;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_0.w)<abs(u_xlat16_0.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_30 * u_xlat16_10.x + u_xlat19;
					    u_xlatb19 = u_xlat16_0.w<(-u_xlat16_0.w);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_30 = min(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_30<(-u_xlat16_30);
					    u_xlat16_30 = max(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xw, u_xlat16_0.xw);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlat2.y = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlatb28 = u_xlat16_30>=(-u_xlat16_30);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_0.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat2.x = _Front1TexAnimeSpeed2 * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat2.xy;
					    u_xlat16_9.xy = u_xlat16_9.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_9.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_21 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_21 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_21;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_30 = u_xlat10_10.y * u_xlat16_12.x;
					    u_xlat16_30 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_30;
					    u_xlat16_30 = u_xlat16_21 * u_xlat10_10.z + u_xlat16_30;
					    u_xlat16_6.z = u_xlat16_30 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_30 = u_xlat16_2.z * 0.330000013 + u_xlat16_30;
					    u_xlat16_18 = u_xlat16_2.z * 0.167999998 + u_xlat16_18;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_30;
					    u_xlat16_33 = u_xlat16_18 * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_21 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_30;
					    u_xlat16_0.x = u_xlat16_18 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" }
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat8.x = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					lowp vec3 u_xlat10_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_16;
					mediump vec2 u_xlat16_18;
					float u_xlat19;
					mediump float u_xlat16_19;
					bool u_xlatb19;
					mediump float u_xlat16_21;
					mediump float u_xlat16_27;
					bool u_xlatb28;
					mediump float u_xlat16_30;
					mediump float u_xlat16_33;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat16_9.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_3.x = min(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_10 = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + 0.180141002;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + -0.330299497;
					    u_xlat16_10 = u_xlat16_3.x * u_xlat16_10 + 0.999866009;
					    u_xlat16_19 = u_xlat16_27 * u_xlat16_10;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_9.y)<abs(u_xlat16_9.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_27 * u_xlat16_10 + u_xlat19;
					    u_xlatb19 = u_xlat16_9.y<(-u_xlat16_9.y);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_27 = min(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlatb19 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlat16_9.x = dot(u_xlat16_9.xy, u_xlat16_9.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_9.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb28 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_9.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_4.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_5.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_3.xyz = u_xlat16_2.xyz * u_xlat10_4.yyy + u_xlat10_5.xyz;
					    u_xlat16_3.xyz = u_xlat16_1.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_21 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_21 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_21;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_30 = u_xlat10_10.y * u_xlat16_12.x;
					    u_xlat16_30 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_30;
					    u_xlat16_30 = u_xlat16_21 * u_xlat10_10.z + u_xlat16_30;
					    u_xlat16_6.z = u_xlat16_30 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_30 = u_xlat16_2.z * 0.330000013 + u_xlat16_30;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_30;
					    u_xlat16_33 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_21 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_30;
					    u_xlat16_0.x = u_xlat16_18.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" }
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					float u_xlat9;
					mediump vec3 u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_11;
					mediump vec2 u_xlat16_14;
					mediump float u_xlat16_16;
					float u_xlat17;
					mediump float u_xlat16_17;
					bool u_xlatb17;
					mediump float u_xlat16_19;
					mediump float u_xlat16_24;
					bool u_xlatb25;
					mediump float u_xlat16_27;
					mediump float u_xlat16_29;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_16 = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16 = float(1.0) / u_xlat16_16;
					    u_xlat16_24 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16 = u_xlat16_16 * u_xlat16_24;
					    u_xlat16_24 = u_xlat16_16 * u_xlat16_16;
					    u_xlat16_1.x = u_xlat16_24 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_9.x = u_xlat16_16 * u_xlat16_1.x;
					    u_xlat9 = u_xlat16_9.x * -2.0 + 1.57079637;
					    u_xlatb17 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat9 = u_xlatb17 ? u_xlat9 : float(0.0);
					    u_xlat1 = u_xlat16_16 * u_xlat16_1.x + u_xlat9;
					    u_xlatb9 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat9 + u_xlat1;
					    u_xlat16_16 = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb9 = u_xlat16_16<(-u_xlat16_16);
					    u_xlat16_16 = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb17 = u_xlat16_16>=(-u_xlat16_16);
					    u_xlatb9 = u_xlatb17 && u_xlatb9;
					    u_xlat1 = (u_xlatb9) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_8.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_8.x;
					    u_xlat16_8.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_24 = max(abs(u_xlat16_8.y), abs(u_xlat16_8.x));
					    u_xlat16_24 = float(1.0) / u_xlat16_24;
					    u_xlat16_3.x = min(abs(u_xlat16_8.y), abs(u_xlat16_8.x));
					    u_xlat16_24 = u_xlat16_24 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_24 * u_xlat16_24;
					    u_xlat16_9.x = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9.x = u_xlat16_3.x * u_xlat16_9.x + 0.180141002;
					    u_xlat16_9.x = u_xlat16_3.x * u_xlat16_9.x + -0.330299497;
					    u_xlat16_9.x = u_xlat16_3.x * u_xlat16_9.x + 0.999866009;
					    u_xlat16_17 = u_xlat16_24 * u_xlat16_9.x;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_8.y)<abs(u_xlat16_8.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_24 * u_xlat16_9.x + u_xlat17;
					    u_xlatb17 = u_xlat16_8.y<(-u_xlat16_8.y);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_24 = min(u_xlat16_8.y, u_xlat16_8.x);
					    u_xlatb17 = u_xlat16_24<(-u_xlat16_24);
					    u_xlat16_24 = max(u_xlat16_8.y, u_xlat16_8.x);
					    u_xlat16_8.x = dot(u_xlat16_8.xy, u_xlat16_8.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_8.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb25 = u_xlat16_24>=(-u_xlat16_24);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_8.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_8.x;
					    u_xlat10_9.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_9.xy = u_xlat10_9.xy + vec2(-0.5, -0.5);
					    u_xlat16_9.xy = u_xlat16_9.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_8.xy = u_xlat16_9.xy * u_xlat10_4.zz;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_9.xyz = texture2D(_Back1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_0.xw).xyz;
					    u_xlat16_3.xyz = u_xlat16_9.xyz * u_xlat10_4.yyy + u_xlat10_2.xyz;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_9.xyz = texture2D(_Back2Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back2TexColor.xyz;
					    u_xlat16_3.xyz = u_xlat16_9.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_0.xw = vs_TEXCOORD1.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_5.x = min(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_9.x = u_xlat16_5.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.180141002;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + -0.330299497;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.999866009;
					    u_xlat16_17 = u_xlat16_9.x * u_xlat16_27;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_0.w)<abs(u_xlat16_0.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_27 * u_xlat16_9.x + u_xlat17;
					    u_xlatb17 = u_xlat16_0.w<(-u_xlat16_0.w);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_27 = min(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlatb17 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xw, u_xlat16_0.xw);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlat2.y = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlatb25 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_0.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat2.x = _Front1TexAnimeSpeed2 * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat2.xy;
					    u_xlat16_8.xy = u_xlat16_8.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_8.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_24 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_24) * u_xlat16_0.xyz;
					    u_xlat16_24 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_24) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_24 = u_xlat16_2.x * 1.25 + u_xlat16_24;
					    u_xlat16_11.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_11.x);
					    u_xlat16_19 = vs_TEXCOORD5.z * 0.114 + u_xlat16_11.y;
					    u_xlat16_19 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_19;
					    u_xlat16_11.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_11.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_27 = u_xlat10_9.y * u_xlat16_11.x;
					    u_xlat16_27 = u_xlat16_24 * u_xlat10_9.x + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_19 * u_xlat10_9.z + u_xlat16_27;
					    u_xlat16_5.z = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_16 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_27 = u_xlat16_2.z * 0.330000013 + u_xlat16_27;
					    u_xlat16_16 = u_xlat16_2.z * 0.167999998 + u_xlat16_16;
					    u_xlat16_29 = u_xlat10_9.y * u_xlat16_27;
					    u_xlat16_29 = u_xlat16_16 * u_xlat10_9.x + u_xlat16_29;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_14.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_6.x = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_29 = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.x = u_xlat16_29 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_9.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_6.x * u_xlat10_9.z + u_xlat16_0.x;
					    u_xlat16_5.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_11.x;
					    u_xlat16_0.x = u_xlat16_24 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.z = u_xlat16_19 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_27;
					    u_xlat16_0.x = u_xlat16_16 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.x = u_xlat16_14.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_6.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_7.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" }
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					mediump vec2 u_xlat16_5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_11;
					vec2 u_xlat12;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat12.x = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * u_xlat12.xx + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = _Time.xx * vec2(_Front1TexAnimeSpeed, _Front2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2.x);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2.x;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD1.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.x * _Back2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat12.y = dot(u_xlat2.zy, u_xlat16_5.xy);
					    u_xlat12.x = dot(u_xlat2.yx, u_xlat16_5.xy);
					    vs_TEXCOORD2.zw = u_xlat12.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_5.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_5.x = dot(u_xlat16_5.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_11 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_5.x + u_xlat16_11;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_3.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_3.yyy + u_xlat10_2.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_3.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" }
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					mediump vec2 u_xlat16_5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_11;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = _Time.xx * vec2(_Front1TexAnimeSpeed, _Front2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2 = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD1.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = _Time.xx * vec2(_Back1TexAnimeSpeed, _Back2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2 = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD2.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_5.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_5.x = dot(u_xlat16_5.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_11 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_5.x + u_xlat16_11;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_11;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_2.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_11.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_2.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_ROTATE" }
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat8.x = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					float u_xlat9;
					mediump float u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_11;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_16;
					float u_xlat17;
					mediump float u_xlat16_17;
					bool u_xlatb17;
					mediump float u_xlat16_19;
					mediump float u_xlat16_24;
					bool u_xlatb25;
					mediump float u_xlat16_27;
					mediump float u_xlat16_29;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_16.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = float(1.0) / u_xlat16_16.x;
					    u_xlat16_24 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = u_xlat16_16.x * u_xlat16_24;
					    u_xlat16_24 = u_xlat16_16.x * u_xlat16_16.x;
					    u_xlat16_1.x = u_xlat16_24 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_9 = u_xlat16_16.x * u_xlat16_1.x;
					    u_xlat9 = u_xlat16_9 * -2.0 + 1.57079637;
					    u_xlatb17 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat9 = u_xlatb17 ? u_xlat9 : float(0.0);
					    u_xlat1 = u_xlat16_16.x * u_xlat16_1.x + u_xlat9;
					    u_xlatb9 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat9 + u_xlat1;
					    u_xlat16_16.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb9 = u_xlat16_16.x<(-u_xlat16_16.x);
					    u_xlat16_16.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb17 = u_xlat16_16.x>=(-u_xlat16_16.x);
					    u_xlatb9 = u_xlatb17 && u_xlatb9;
					    u_xlat1 = (u_xlatb9) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_8.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_8.x;
					    u_xlat16_8.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_24 = max(abs(u_xlat16_8.y), abs(u_xlat16_8.x));
					    u_xlat16_24 = float(1.0) / u_xlat16_24;
					    u_xlat16_3.x = min(abs(u_xlat16_8.y), abs(u_xlat16_8.x));
					    u_xlat16_24 = u_xlat16_24 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_24 * u_xlat16_24;
					    u_xlat16_9 = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9 = u_xlat16_3.x * u_xlat16_9 + 0.180141002;
					    u_xlat16_9 = u_xlat16_3.x * u_xlat16_9 + -0.330299497;
					    u_xlat16_9 = u_xlat16_3.x * u_xlat16_9 + 0.999866009;
					    u_xlat16_17 = u_xlat16_24 * u_xlat16_9;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_8.y)<abs(u_xlat16_8.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_24 * u_xlat16_9 + u_xlat17;
					    u_xlatb17 = u_xlat16_8.y<(-u_xlat16_8.y);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_24 = min(u_xlat16_8.y, u_xlat16_8.x);
					    u_xlatb17 = u_xlat16_24<(-u_xlat16_24);
					    u_xlat16_24 = max(u_xlat16_8.y, u_xlat16_8.x);
					    u_xlat16_8.x = dot(u_xlat16_8.xy, u_xlat16_8.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_8.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb25 = u_xlat16_24>=(-u_xlat16_24);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_8.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_8.x;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_4.zz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_16.xy).xyz;
					    u_xlat16_3.xyz = u_xlat16_1.xyz * u_xlat10_4.yyy + u_xlat10_2.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_3.xyz = u_xlat16_1.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_24 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_24) * u_xlat16_0.xyz;
					    u_xlat16_24 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_24) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_24 = u_xlat16_2.x * 1.25 + u_xlat16_24;
					    u_xlat16_11.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_11.x);
					    u_xlat16_19 = vs_TEXCOORD5.z * 0.114 + u_xlat16_11.y;
					    u_xlat16_19 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_19;
					    u_xlat16_11.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_11.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_27 = u_xlat10_9.y * u_xlat16_11.x;
					    u_xlat16_27 = u_xlat16_24 * u_xlat10_9.x + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_19 * u_xlat10_9.z + u_xlat16_27;
					    u_xlat16_5.z = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_16.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_27 = u_xlat16_2.z * 0.330000013 + u_xlat16_27;
					    u_xlat16_16.x = u_xlat16_2.z * 0.167999998 + u_xlat16_16.x;
					    u_xlat16_29 = u_xlat10_9.y * u_xlat16_27;
					    u_xlat16_29 = u_xlat16_16.x * u_xlat10_9.x + u_xlat16_29;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_14.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_6.x = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_29 = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.x = u_xlat16_29 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_9.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_6.x * u_xlat10_9.z + u_xlat16_0.x;
					    u_xlat16_5.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_11.x;
					    u_xlat16_0.x = u_xlat16_24 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.z = u_xlat16_19 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_27;
					    u_xlat16_0.x = u_xlat16_16.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.x = u_xlat16_14.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_6.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_7.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					float u_xlat9;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat9 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat9) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * vec2(u_xlat9) + u_xlat0.xy;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.x * _Back2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_3.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_3.yyy + u_xlat10_2.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_3.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					float u_xlat4;
					vec3 u_xlat5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_9;
					vec2 u_xlat12;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat12.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat12.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat12.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat12.x = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * u_xlat12.xx + u_xlat0.xy;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = _Time.xx * vec2(_Back1TexAnimeSpeed, _Back2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = sin(u_xlat0.y);
					    u_xlat4 = cos(u_xlat0.y);
					    u_xlat5.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat5.y = u_xlat1.x;
					    u_xlat5.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat5.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat5.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2.x);
					    u_xlat0.y = u_xlat4;
					    u_xlat0.z = u_xlat2.x;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_3.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_9 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_9;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_11;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_2.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_11.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_2.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					mediump vec2 u_xlat16_5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_11;
					vec2 u_xlat12;
					float u_xlat13;
					vec2 u_xlat14;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat13 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat13) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = _Time.xx * vec2(_Front1TexAnimeSpeed, _Front2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2.x);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2.x;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat14.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat14.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD1.zw = u_xlat14.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * vec2(u_xlat13) + u_xlat0.xy;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat12.y = dot(u_xlat2.zy, u_xlat16_5.xy);
					    u_xlat12.x = dot(u_xlat2.yx, u_xlat16_5.xy);
					    vs_TEXCOORD2.zw = u_xlat12.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_5.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_5.x = dot(u_xlat16_5.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_11 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_5.x + u_xlat16_11;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					mediump vec4 u_xlat16_1;
					mediump vec2 u_xlat16_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec4 u_xlat16_5;
					mediump vec3 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					lowp vec3 u_xlat10_9;
					mediump float u_xlat16_10;
					mediump vec2 u_xlat16_11;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					mediump vec2 u_xlat16_14;
					mediump float u_xlat16_19;
					mediump vec2 u_xlat16_20;
					mediump float u_xlat16_28;
					mediump float u_xlat16_29;
					mediump float u_xlat16_31;
					void main()
					{
					    u_xlat10_0.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_1.x = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = u_xlat16_1.xxxx * vs_TEXCOORD5.yxyx;
					    u_xlat16_2.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_2.y);
					    u_xlat16_2.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_2.x;
					    u_xlat16_2.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_2.x;
					    u_xlat16_1.x = u_xlat16_1.x * 1.25 + u_xlat16_11.x;
					    u_xlat16_11.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_10 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_11.x);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.114 + u_xlat16_11.y;
					    u_xlat16_11.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_11.x;
					    u_xlat16_10 = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_10;
					    u_xlat10_3.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_20.x = u_xlat16_10 * u_xlat10_3.y;
					    u_xlat16_20.x = u_xlat16_1.x * u_xlat10_3.x + u_xlat16_20.x;
					    u_xlat16_4.z = u_xlat16_11.x * u_xlat10_3.z + u_xlat16_20.x;
					    u_xlat16_20.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_20.x;
					    u_xlat16_29 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_20.y);
					    u_xlat16_29 = u_xlat16_1.z * 0.330000013 + u_xlat16_29;
					    u_xlat16_20.x = u_xlat16_1.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat16_31 = u_xlat10_3.y * u_xlat16_29;
					    u_xlat16_31 = u_xlat16_20.x * u_xlat10_3.x + u_xlat16_31;
					    u_xlat16_5.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_5.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_5.xy);
					    u_xlat16_14.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_5.xy;
					    u_xlat16_19 = u_xlat16_1.z * 0.291999996 + u_xlat16_5.x;
					    u_xlat16_4.x = u_xlat16_14.x * u_xlat10_3.z + u_xlat16_31;
					    u_xlat16_28 = u_xlat10_3.x * u_xlat16_14.y;
					    u_xlat16_28 = u_xlat16_2.x * u_xlat10_3.y + u_xlat16_28;
					    u_xlat16_4.y = u_xlat16_19 * u_xlat10_3.z + u_xlat16_28;
					    u_xlat16_4.xyz = u_xlat10_0.xyz + u_xlat16_4.xyz;
					    u_xlat10_0.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_0.xy = u_xlat10_0.xy + vec2(-0.5, -0.5);
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_5.xw = u_xlat16_0.xy * u_xlat10_3.zz;
					    u_xlat16_6.xy = u_xlat16_5.xw * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_0.xyz = texture2D(_Back1Tex, u_xlat16_6.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back1TexColor.xyz;
					    u_xlat16_6.xy = u_xlat16_5.xw * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_6.xy).xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.yyy + u_xlat10_7.xyz;
					    u_xlat16_8.xy = u_xlat16_5.xw * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_0.xyz = texture2D(_Back2Tex, u_xlat16_8.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back2TexColor.xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.yyy + u_xlat16_6.xyz;
					    u_xlat16_8.xy = u_xlat16_5.xw * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_5.xw = u_xlat16_5.xw * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_0.xyz = texture2D(_Front2Tex, u_xlat16_5.xw).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Front2TexColor.xyz;
					    u_xlat10_12.xyz = texture2D(_Front1Tex, u_xlat16_8.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Front1TexColor.xyz;
					    u_xlat16_6.xyz = u_xlat16_12.xyz * u_xlat10_3.xxx + u_xlat16_6.xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.xxx + u_xlat16_6.xyz;
					    u_xlat10_0.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_8.xyz = (-u_xlat16_6.xyz) + u_xlat10_0.xyz;
					    u_xlat10_0.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_6.xyz = u_xlat10_0.xxx * u_xlat16_8.xyz + u_xlat16_6.xyz;
					    u_xlat10_0.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_28 = (-u_xlat10_0.x) * _IsKira + 1.0;
					    u_xlat16_0.x = u_xlat10_0.x * _IsKira;
					    u_xlat16_6.xyz = vec3(u_xlat16_28) * u_xlat16_6.xyz;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_10 = u_xlat10_9.y * u_xlat16_10;
					    u_xlat16_1.x = u_xlat16_1.x * u_xlat10_9.x + u_xlat16_10;
					    u_xlat16_1.x = u_xlat16_11.x * u_xlat10_9.z + u_xlat16_1.x;
					    u_xlat16_8.z = u_xlat16_1.x * u_xlat16_0.x + u_xlat16_6.z;
					    u_xlat16_1.x = u_xlat10_9.y * u_xlat16_29;
					    u_xlat16_1.x = u_xlat16_20.x * u_xlat10_9.x + u_xlat16_1.x;
					    u_xlat16_1.x = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_1.x;
					    u_xlat16_10 = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_10 = u_xlat16_2.x * u_xlat10_9.y + u_xlat16_10;
					    u_xlat16_10 = u_xlat16_19 * u_xlat10_9.z + u_xlat16_10;
					    u_xlat16_8.y = u_xlat16_10 * u_xlat16_0.x + u_xlat16_6.y;
					    u_xlat16_8.x = u_xlat16_1.x * u_xlat16_0.x + u_xlat16_6.x;
					    u_xlat16_1.xyz = u_xlat16_4.xyz * vec3(_IsKira) + u_xlat16_8.xyz;
					    SV_Target0.xyz = u_xlat16_1.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat8.x = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_11;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_2.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_11.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_2.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_BACK2TEX_SCROLL" }
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					float u_xlat9;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat9 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat9) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat0.xy = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat9) + u_xlat0.xy;
					    vs_TEXCOORD2.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					lowp vec3 u_xlat10_4;
					mediump vec3 u_xlat16_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_16;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_23;
					mediump float u_xlat16_27;
					mediump float u_xlat16_32;
					mediump float u_xlat16_33;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD1.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Front1TexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_3.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_4.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_5.xyz = u_xlat16_2.xyz * u_xlat10_3.yyy + u_xlat10_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_2.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front2TexColor.xyz;
					    u_xlat10_4.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat10_4.xyz * _Back2TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_4.xyz * u_xlat10_3.yyy + u_xlat16_5.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_5.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_5.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_5.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_5.y);
					    u_xlat16_5.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_5.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_14.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_23 = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_23 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_23;
					    u_xlat16_14.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat10_10.y * u_xlat16_14.x;
					    u_xlat16_32 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_32;
					    u_xlat16_32 = u_xlat16_23 * u_xlat10_10.z + u_xlat16_32;
					    u_xlat16_6.z = u_xlat16_32 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_32 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_32 = u_xlat16_2.z * 0.330000013 + u_xlat16_32;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_4.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_33 = u_xlat10_4.y * u_xlat16_32;
					    u_xlat16_32 = u_xlat10_10.y * u_xlat16_32;
					    u_xlat16_32 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_32;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_4.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_33 = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_4.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_4.y * u_xlat16_14.x;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_4.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_23 * u_xlat10_4.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_4.x * u_xlat16_16.y;
					    u_xlat16_18.x = u_xlat16_5.x * u_xlat10_4.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_33 * u_xlat10_4.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_32;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_27 = u_xlat16_5.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_33 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_6.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_6.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_SCROLL" }
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					mediump vec2 u_xlat16_5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_11;
					float u_xlat13;
					vec2 u_xlat14;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat13 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat13) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = _Time.xx * vec2(_Front1TexAnimeSpeed, _Front2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2 = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat14.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat14.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD1.zw = u_xlat14.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat0.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat13) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_5.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_5.x = dot(u_xlat16_5.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_11 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_5.x + u_xlat16_11;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_3.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_3.yyy + u_xlat10_2.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_3.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_5;
					float u_xlat7;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat7 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat7) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat0.zw = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat0.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
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
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_2 + u_xlat16_5;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					mediump vec3 u_xlat16_7;
					mediump float u_xlat16_8;
					float u_xlat9;
					mediump vec3 u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_16;
					float u_xlat17;
					mediump float u_xlat16_17;
					bool u_xlatb17;
					mediump float u_xlat16_20;
					mediump float u_xlat16_24;
					bool u_xlatb25;
					mediump float u_xlat16_28;
					mediump float u_xlat16_29;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_16.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = float(1.0) / u_xlat16_16.x;
					    u_xlat16_24 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = u_xlat16_16.x * u_xlat16_24;
					    u_xlat16_24 = u_xlat16_16.x * u_xlat16_16.x;
					    u_xlat16_1.x = u_xlat16_24 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_9.x = u_xlat16_16.x * u_xlat16_1.x;
					    u_xlat9 = u_xlat16_9.x * -2.0 + 1.57079637;
					    u_xlatb17 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat9 = u_xlatb17 ? u_xlat9 : float(0.0);
					    u_xlat1 = u_xlat16_16.x * u_xlat16_1.x + u_xlat9;
					    u_xlatb9 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat9 + u_xlat1;
					    u_xlat16_16.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb9 = u_xlat16_16.x<(-u_xlat16_16.x);
					    u_xlat16_16.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb17 = u_xlat16_16.x>=(-u_xlat16_16.x);
					    u_xlatb9 = u_xlatb17 && u_xlatb9;
					    u_xlat1 = (u_xlatb9) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_8 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_8;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_9.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_9.xy = u_xlat10_9.xy + vec2(-0.5, -0.5);
					    u_xlat16_9.xy = u_xlat16_9.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_9.xy * u_xlat10_3.zz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_9.xyz = texture2D(_Back1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back1TexColor.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_16.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_3.yyy + u_xlat10_2.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_9.xyz = texture2D(_Back2Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_3.yyy + u_xlat16_4.xyz;
					    u_xlat16_16.xy = vs_TEXCOORD1.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_28 = max(abs(u_xlat16_16.y), abs(u_xlat16_16.x));
					    u_xlat16_28 = float(1.0) / u_xlat16_28;
					    u_xlat16_5.x = min(abs(u_xlat16_16.y), abs(u_xlat16_16.x));
					    u_xlat16_28 = u_xlat16_28 * u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_28 * u_xlat16_28;
					    u_xlat16_9.x = u_xlat16_5.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.180141002;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + -0.330299497;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.999866009;
					    u_xlat16_17 = u_xlat16_9.x * u_xlat16_28;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_16.y)<abs(u_xlat16_16.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_28 * u_xlat16_9.x + u_xlat17;
					    u_xlatb17 = u_xlat16_16.y<(-u_xlat16_16.y);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_28 = min(u_xlat16_16.y, u_xlat16_16.x);
					    u_xlatb17 = u_xlat16_28<(-u_xlat16_28);
					    u_xlat16_28 = max(u_xlat16_16.y, u_xlat16_16.x);
					    u_xlat16_16.x = dot(u_xlat16_16.xy, u_xlat16_16.xy);
					    u_xlat16_16.x = sqrt(u_xlat16_16.x);
					    u_xlat16_16.x = (-u_xlat16_16.x) + 1.0;
					    u_xlat2.y = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_16.x;
					    u_xlatb25 = u_xlat16_28>=(-u_xlat16_28);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_16.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat2.x = _Front1TexAnimeSpeed2 * u_xlat1 + u_xlat16_16.x;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat2.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_24 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_24) * u_xlat16_0.xyz;
					    u_xlat16_24 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_24) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_24 = u_xlat16_2.x * 1.25 + u_xlat16_24;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_20 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_20;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_28 = u_xlat10_9.y * u_xlat16_12.x;
					    u_xlat16_28 = u_xlat16_24 * u_xlat10_9.x + u_xlat16_28;
					    u_xlat16_28 = u_xlat16_20 * u_xlat10_9.z + u_xlat16_28;
					    u_xlat16_5.z = u_xlat16_28 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_16.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_28 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_28 = u_xlat16_2.z * 0.330000013 + u_xlat16_28;
					    u_xlat16_16.x = u_xlat16_2.z * 0.167999998 + u_xlat16_16.x;
					    u_xlat16_29 = u_xlat10_9.y * u_xlat16_28;
					    u_xlat16_29 = u_xlat16_16.x * u_xlat10_9.x + u_xlat16_29;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_14.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_6.x = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_29 = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.x = u_xlat16_29 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_9.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_6.x * u_xlat10_9.z + u_xlat16_0.x;
					    u_xlat16_5.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_24 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.z = u_xlat16_20 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_28;
					    u_xlat16_0.x = u_xlat16_16.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.x = u_xlat16_14.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_6.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_7.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					float u_xlat9;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat9 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat9) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat0.xy = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * vec2(u_xlat9) + u_xlat0.xy;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat0.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat9) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_3.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_3.yyy + u_xlat10_2.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_3.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					float u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat8 = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * vec2(u_xlat8) + u_xlat0.xy;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat0.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat8) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					float u_xlat9;
					mediump float u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_11;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_16;
					float u_xlat17;
					mediump float u_xlat16_17;
					bool u_xlatb17;
					mediump float u_xlat16_19;
					mediump float u_xlat16_24;
					bool u_xlatb25;
					mediump float u_xlat16_27;
					mediump float u_xlat16_29;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_16.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = float(1.0) / u_xlat16_16.x;
					    u_xlat16_24 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = u_xlat16_16.x * u_xlat16_24;
					    u_xlat16_24 = u_xlat16_16.x * u_xlat16_16.x;
					    u_xlat16_1.x = u_xlat16_24 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_9 = u_xlat16_16.x * u_xlat16_1.x;
					    u_xlat9 = u_xlat16_9 * -2.0 + 1.57079637;
					    u_xlatb17 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat9 = u_xlatb17 ? u_xlat9 : float(0.0);
					    u_xlat1 = u_xlat16_16.x * u_xlat16_1.x + u_xlat9;
					    u_xlatb9 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat9 + u_xlat1;
					    u_xlat16_16.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb9 = u_xlat16_16.x<(-u_xlat16_16.x);
					    u_xlat16_16.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb17 = u_xlat16_16.x>=(-u_xlat16_16.x);
					    u_xlatb9 = u_xlatb17 && u_xlatb9;
					    u_xlat1 = (u_xlatb9) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_8.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_8.x;
					    u_xlat16_8.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_24 = max(abs(u_xlat16_8.y), abs(u_xlat16_8.x));
					    u_xlat16_24 = float(1.0) / u_xlat16_24;
					    u_xlat16_3.x = min(abs(u_xlat16_8.y), abs(u_xlat16_8.x));
					    u_xlat16_24 = u_xlat16_24 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_24 * u_xlat16_24;
					    u_xlat16_9 = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9 = u_xlat16_3.x * u_xlat16_9 + 0.180141002;
					    u_xlat16_9 = u_xlat16_3.x * u_xlat16_9 + -0.330299497;
					    u_xlat16_9 = u_xlat16_3.x * u_xlat16_9 + 0.999866009;
					    u_xlat16_17 = u_xlat16_24 * u_xlat16_9;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_8.y)<abs(u_xlat16_8.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_24 * u_xlat16_9 + u_xlat17;
					    u_xlatb17 = u_xlat16_8.y<(-u_xlat16_8.y);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_24 = min(u_xlat16_8.y, u_xlat16_8.x);
					    u_xlatb17 = u_xlat16_24<(-u_xlat16_24);
					    u_xlat16_24 = max(u_xlat16_8.y, u_xlat16_8.x);
					    u_xlat16_8.x = dot(u_xlat16_8.xy, u_xlat16_8.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_8.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb25 = u_xlat16_24>=(-u_xlat16_24);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_8.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_8.x;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_4.zz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_16.xy).xyz;
					    u_xlat16_3.xyz = u_xlat16_1.xyz * u_xlat10_4.yyy + u_xlat10_2.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_3.xyz = u_xlat16_1.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_2.xyz = texture2D(_Front1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_24 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_24) * u_xlat16_0.xyz;
					    u_xlat16_24 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_24) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_24 = u_xlat16_2.x * 1.25 + u_xlat16_24;
					    u_xlat16_11.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_11.x);
					    u_xlat16_19 = vs_TEXCOORD5.z * 0.114 + u_xlat16_11.y;
					    u_xlat16_19 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_19;
					    u_xlat16_11.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_11.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_27 = u_xlat10_9.y * u_xlat16_11.x;
					    u_xlat16_27 = u_xlat16_24 * u_xlat10_9.x + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_19 * u_xlat10_9.z + u_xlat16_27;
					    u_xlat16_5.z = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_16.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_27 = u_xlat16_2.z * 0.330000013 + u_xlat16_27;
					    u_xlat16_16.x = u_xlat16_2.z * 0.167999998 + u_xlat16_16.x;
					    u_xlat16_29 = u_xlat10_9.y * u_xlat16_27;
					    u_xlat16_29 = u_xlat16_16.x * u_xlat10_9.x + u_xlat16_29;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_14.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_6.x = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_29 = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.x = u_xlat16_29 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_9.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_6.x * u_xlat10_9.z + u_xlat16_0.x;
					    u_xlat16_5.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_11.x;
					    u_xlat16_0.x = u_xlat16_24 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.z = u_xlat16_19 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_27;
					    u_xlat16_0.x = u_xlat16_16.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.x = u_xlat16_14.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_6.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_7.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat8.x = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat0.xy = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    vs_TEXCOORD2.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_11;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_2.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_11.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_2.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					mediump vec2 u_xlat16_5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_11;
					float u_xlat12;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = _Time.xx * vec2(_Front1TexAnimeSpeed, _Front2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2 = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD1.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat12 = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * vec2(u_xlat12) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat1.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat12) + u_xlat0.xy;
					    vs_TEXCOORD2 = u_xlat1;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_5.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_5.x = dot(u_xlat16_5.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_11 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_5.x + u_xlat16_11;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_11;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_2.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_11.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_2.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {			{ "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					float u_xlat9;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat9 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat9) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * vec2(u_xlat9) + u_xlat0.xy;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * vec2(u_xlat9) + u_xlat0.xy;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat0.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat9) + u_xlat1.xy;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					mediump vec4 u_xlat16_1;
					mediump vec2 u_xlat16_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec4 u_xlat16_5;
					mediump vec3 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					lowp vec3 u_xlat10_9;
					mediump float u_xlat16_10;
					mediump vec2 u_xlat16_11;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					mediump vec2 u_xlat16_14;
					mediump float u_xlat16_19;
					mediump vec2 u_xlat16_20;
					mediump float u_xlat16_28;
					mediump float u_xlat16_29;
					mediump float u_xlat16_31;
					void main()
					{
					    u_xlat10_0.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_1.x = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = u_xlat16_1.xxxx * vs_TEXCOORD5.yxyx;
					    u_xlat16_2.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_2.y);
					    u_xlat16_2.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_2.x;
					    u_xlat16_2.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_2.x;
					    u_xlat16_1.x = u_xlat16_1.x * 1.25 + u_xlat16_11.x;
					    u_xlat16_11.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_10 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_11.x);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.114 + u_xlat16_11.y;
					    u_xlat16_11.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_11.x;
					    u_xlat16_10 = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_10;
					    u_xlat10_3.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_20.x = u_xlat16_10 * u_xlat10_3.y;
					    u_xlat16_20.x = u_xlat16_1.x * u_xlat10_3.x + u_xlat16_20.x;
					    u_xlat16_4.z = u_xlat16_11.x * u_xlat10_3.z + u_xlat16_20.x;
					    u_xlat16_20.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_20.x;
					    u_xlat16_29 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_20.y);
					    u_xlat16_29 = u_xlat16_1.z * 0.330000013 + u_xlat16_29;
					    u_xlat16_20.x = u_xlat16_1.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat16_31 = u_xlat10_3.y * u_xlat16_29;
					    u_xlat16_31 = u_xlat16_20.x * u_xlat10_3.x + u_xlat16_31;
					    u_xlat16_5.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_5.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_5.xy);
					    u_xlat16_14.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_5.xy;
					    u_xlat16_19 = u_xlat16_1.z * 0.291999996 + u_xlat16_5.x;
					    u_xlat16_4.x = u_xlat16_14.x * u_xlat10_3.z + u_xlat16_31;
					    u_xlat16_28 = u_xlat10_3.x * u_xlat16_14.y;
					    u_xlat16_28 = u_xlat16_2.x * u_xlat10_3.y + u_xlat16_28;
					    u_xlat16_4.y = u_xlat16_19 * u_xlat10_3.z + u_xlat16_28;
					    u_xlat16_4.xyz = u_xlat10_0.xyz + u_xlat16_4.xyz;
					    u_xlat10_0.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_0.xy = u_xlat10_0.xy + vec2(-0.5, -0.5);
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_5.xw = u_xlat16_0.xy * u_xlat10_3.zz;
					    u_xlat16_6.xy = u_xlat16_5.xw * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_0.xyz = texture2D(_Back1Tex, u_xlat16_6.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back1TexColor.xyz;
					    u_xlat16_6.xy = u_xlat16_5.xw * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_6.xy).xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.yyy + u_xlat10_7.xyz;
					    u_xlat16_8.xy = u_xlat16_5.xw * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_0.xyz = texture2D(_Back2Tex, u_xlat16_8.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back2TexColor.xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.yyy + u_xlat16_6.xyz;
					    u_xlat16_8.xy = u_xlat16_5.xw * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_5.xw = u_xlat16_5.xw * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_0.xyz = texture2D(_Front2Tex, u_xlat16_5.xw).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Front2TexColor.xyz;
					    u_xlat10_12.xyz = texture2D(_Front1Tex, u_xlat16_8.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Front1TexColor.xyz;
					    u_xlat16_6.xyz = u_xlat16_12.xyz * u_xlat10_3.xxx + u_xlat16_6.xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.xxx + u_xlat16_6.xyz;
					    u_xlat10_0.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_8.xyz = (-u_xlat16_6.xyz) + u_xlat10_0.xyz;
					    u_xlat10_0.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_6.xyz = u_xlat10_0.xxx * u_xlat16_8.xyz + u_xlat16_6.xyz;
					    u_xlat10_0.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_28 = (-u_xlat10_0.x) * _IsKira + 1.0;
					    u_xlat16_0.x = u_xlat10_0.x * _IsKira;
					    u_xlat16_6.xyz = vec3(u_xlat16_28) * u_xlat16_6.xyz;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_10 = u_xlat10_9.y * u_xlat16_10;
					    u_xlat16_1.x = u_xlat16_1.x * u_xlat10_9.x + u_xlat16_10;
					    u_xlat16_1.x = u_xlat16_11.x * u_xlat10_9.z + u_xlat16_1.x;
					    u_xlat16_8.z = u_xlat16_1.x * u_xlat16_0.x + u_xlat16_6.z;
					    u_xlat16_1.x = u_xlat10_9.y * u_xlat16_29;
					    u_xlat16_1.x = u_xlat16_20.x * u_xlat10_9.x + u_xlat16_1.x;
					    u_xlat16_1.x = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_1.x;
					    u_xlat16_10 = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_10 = u_xlat16_2.x * u_xlat10_9.y + u_xlat16_10;
					    u_xlat16_10 = u_xlat16_19 * u_xlat10_9.z + u_xlat16_10;
					    u_xlat16_8.y = u_xlat16_10 * u_xlat16_0.x + u_xlat16_6.y;
					    u_xlat16_8.x = u_xlat16_1.x * u_xlat16_0.x + u_xlat16_6.x;
					    u_xlat16_1.xyz = u_xlat16_4.xyz * vec3(_IsKira) + u_xlat16_8.xyz;
					    SV_Target0.xyz = u_xlat16_1.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat8.x = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat1.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    vs_TEXCOORD2 = u_xlat1;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_11;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_2.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_11.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_2.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {			{ "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_5;
					float u_xlat7;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat7 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat7) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat0.xy;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat0.zw = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat1.xy;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat0.xy;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat0.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat1.xy;
					    vs_TEXCOORD2 = u_xlat0;
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
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_2 + u_xlat16_5;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					mediump vec4 u_xlat16_1;
					mediump vec2 u_xlat16_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec4 u_xlat16_5;
					mediump vec3 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					lowp vec3 u_xlat10_9;
					mediump float u_xlat16_10;
					mediump vec2 u_xlat16_11;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					mediump vec2 u_xlat16_14;
					mediump float u_xlat16_19;
					mediump vec2 u_xlat16_20;
					mediump float u_xlat16_28;
					mediump float u_xlat16_29;
					mediump float u_xlat16_31;
					void main()
					{
					    u_xlat10_0.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_1.x = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = u_xlat16_1.xxxx * vs_TEXCOORD5.yxyx;
					    u_xlat16_2.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_2.y);
					    u_xlat16_2.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_2.x;
					    u_xlat16_2.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_2.x;
					    u_xlat16_1.x = u_xlat16_1.x * 1.25 + u_xlat16_11.x;
					    u_xlat16_11.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_10 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_11.x);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.114 + u_xlat16_11.y;
					    u_xlat16_11.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_11.x;
					    u_xlat16_10 = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_10;
					    u_xlat10_3.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_20.x = u_xlat16_10 * u_xlat10_3.y;
					    u_xlat16_20.x = u_xlat16_1.x * u_xlat10_3.x + u_xlat16_20.x;
					    u_xlat16_4.z = u_xlat16_11.x * u_xlat10_3.z + u_xlat16_20.x;
					    u_xlat16_20.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_20.x;
					    u_xlat16_29 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_20.y);
					    u_xlat16_29 = u_xlat16_1.z * 0.330000013 + u_xlat16_29;
					    u_xlat16_20.x = u_xlat16_1.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat16_31 = u_xlat10_3.y * u_xlat16_29;
					    u_xlat16_31 = u_xlat16_20.x * u_xlat10_3.x + u_xlat16_31;
					    u_xlat16_5.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_5.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_5.xy);
					    u_xlat16_14.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_5.xy;
					    u_xlat16_19 = u_xlat16_1.z * 0.291999996 + u_xlat16_5.x;
					    u_xlat16_4.x = u_xlat16_14.x * u_xlat10_3.z + u_xlat16_31;
					    u_xlat16_28 = u_xlat10_3.x * u_xlat16_14.y;
					    u_xlat16_28 = u_xlat16_2.x * u_xlat10_3.y + u_xlat16_28;
					    u_xlat16_4.y = u_xlat16_19 * u_xlat10_3.z + u_xlat16_28;
					    u_xlat16_4.xyz = u_xlat10_0.xyz + u_xlat16_4.xyz;
					    u_xlat10_0.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_0.xy = u_xlat10_0.xy + vec2(-0.5, -0.5);
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_5.xw = u_xlat16_0.xy * u_xlat10_3.zz;
					    u_xlat16_6.xy = u_xlat16_5.xw * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_0.xyz = texture2D(_Back1Tex, u_xlat16_6.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back1TexColor.xyz;
					    u_xlat16_6.xy = u_xlat16_5.xw * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_6.xy).xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.yyy + u_xlat10_7.xyz;
					    u_xlat16_8.xy = u_xlat16_5.xw * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_0.xyz = texture2D(_Back2Tex, u_xlat16_8.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back2TexColor.xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.yyy + u_xlat16_6.xyz;
					    u_xlat16_8.xy = u_xlat16_5.xw * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_5.xw = u_xlat16_5.xw * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_0.xyz = texture2D(_Front2Tex, u_xlat16_5.xw).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Front2TexColor.xyz;
					    u_xlat10_12.xyz = texture2D(_Front1Tex, u_xlat16_8.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Front1TexColor.xyz;
					    u_xlat16_6.xyz = u_xlat16_12.xyz * u_xlat10_3.xxx + u_xlat16_6.xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.xxx + u_xlat16_6.xyz;
					    u_xlat10_0.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_8.xyz = (-u_xlat16_6.xyz) + u_xlat10_0.xyz;
					    u_xlat10_0.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_6.xyz = u_xlat10_0.xxx * u_xlat16_8.xyz + u_xlat16_6.xyz;
					    u_xlat10_0.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_28 = (-u_xlat10_0.x) * _IsKira + 1.0;
					    u_xlat16_0.x = u_xlat10_0.x * _IsKira;
					    u_xlat16_6.xyz = vec3(u_xlat16_28) * u_xlat16_6.xyz;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_10 = u_xlat10_9.y * u_xlat16_10;
					    u_xlat16_1.x = u_xlat16_1.x * u_xlat10_9.x + u_xlat16_10;
					    u_xlat16_1.x = u_xlat16_11.x * u_xlat10_9.z + u_xlat16_1.x;
					    u_xlat16_8.z = u_xlat16_1.x * u_xlat16_0.x + u_xlat16_6.z;
					    u_xlat16_1.x = u_xlat10_9.y * u_xlat16_29;
					    u_xlat16_1.x = u_xlat16_20.x * u_xlat10_9.x + u_xlat16_1.x;
					    u_xlat16_1.x = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_1.x;
					    u_xlat16_10 = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_10 = u_xlat16_2.x * u_xlat10_9.y + u_xlat16_10;
					    u_xlat16_10 = u_xlat16_19 * u_xlat10_9.z + u_xlat16_10;
					    u_xlat16_8.y = u_xlat16_10 * u_xlat16_0.x + u_xlat16_6.y;
					    u_xlat16_8.x = u_xlat16_1.x * u_xlat16_0.x + u_xlat16_6.x;
					    u_xlat16_1.xyz = u_xlat16_4.xyz * vec3(_IsKira) + u_xlat16_8.xyz;
					    SV_Target0.xyz = u_xlat16_1.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {			{ "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					Keywords { "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_5;
					float u_xlat6;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat6 = fract(_Time.x);
					    u_xlat1.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * vec2(u_xlat6) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat1.zw = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * vec2(u_xlat6) + u_xlat0.xy;
					    vs_TEXCOORD1 = u_xlat1;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * vec2(u_xlat6) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat1.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat6) + u_xlat0.xy;
					    vs_TEXCOORD2 = u_xlat1;
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
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_2 + u_xlat16_5;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					mediump float u_xlat16_9;
					float u_xlat10;
					mediump float u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_11;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					mediump vec2 u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_22;
					mediump float u_xlat16_27;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = float(1.0) / u_xlat16_18.x;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18.x * u_xlat16_18.x;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10 = u_xlat16_18.x * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10 * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18.x * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18.x<(-u_xlat16_18.x);
					    u_xlat16_18.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18.x>=(-u_xlat16_18.x);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_1.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_1.xy = u_xlat10_1.xy + vec2(-0.5, -0.5);
					    u_xlat16_1.xy = u_xlat16_1.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_1.xy * u_xlat10_2.zz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_1.xyz = texture2D(_Back1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back1TexColor.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_18.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_1.xyz = texture2D(_Back2Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_1.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_18.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat10_11.xyz = texture2D(_Front1Tex, u_xlat16_18.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_2.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_2.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_2.z * 0.167999998 + u_xlat16_18.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_10.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_18.x * u_xlat10_10.x + u_xlat16_31;
					    u_xlat16_18.x = u_xlat16_18.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_18.x = u_xlat16_27 * u_xlat10_7.x + u_xlat16_18.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_18.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_18.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_18.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_18.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_18.x = u_xlat16_15.x * u_xlat10_10.z + u_xlat16_31;
					    u_xlat16_27 = u_xlat10_10.x * u_xlat16_15.y;
					    u_xlat16_27 = u_xlat16_4.x * u_xlat10_10.y + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_32 * u_xlat10_10.z + u_xlat16_27;
					    u_xlat16_5.y = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat16_5.x = u_xlat16_18.x * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.x = _Time.x * _DistotionTexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD3.xy = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Front2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    vs_TEXCOORD1.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
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
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					vec4 u_xlat1;
					mediump vec4 u_xlat16_1;
					vec2 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					bvec2 u_xlatb3;
					mediump vec3 u_xlat16_4;
					vec2 u_xlat5;
					mediump vec3 u_xlat16_5;
					lowp vec3 u_xlat10_5;
					lowp vec3 u_xlat10_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					mediump vec2 u_xlat16_10;
					float u_xlat12;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					mediump vec3 u_xlat16_13;
					lowp vec3 u_xlat10_13;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump float u_xlat16_20;
					mediump vec2 u_xlat16_21;
					vec2 u_xlat22;
					mediump vec2 u_xlat16_22;
					ivec2 u_xlati22;
					bvec2 u_xlatb22;
					mediump vec2 u_xlat16_24;
					mediump float u_xlat16_30;
					bool u_xlatb32;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0 = vs_TEXCOORD2.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = vec2(1.0, 1.0) / u_xlat16_1.xy;
					    u_xlat16_21.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_21.xy;
					    u_xlat16_21.xy = u_xlat16_1.xy * u_xlat16_1.xy;
					    u_xlat16_2.xy = u_xlat16_21.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_22.xy = u_xlat16_1.xy * u_xlat16_2.xy;
					    u_xlat22.xy = u_xlat16_22.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb3.xy = lessThan(abs(u_xlat16_0.ywyy), abs(u_xlat16_0.xzxx)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), u_xlat22.xy, vec2(u_xlatb3.xy));
					    u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat22.xy;
					    u_xlatb22.xy = lessThan(u_xlat16_0.ywyw, (-u_xlat16_0.ywyw)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb22.xy));
					    u_xlat2.xy = u_xlat22.xy + u_xlat2.xy;
					    u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb22.xy = lessThan(u_xlat16_1.xyxy, (-u_xlat16_1.xyxy)).xy;
					    u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb3.xy = greaterThanEqual(u_xlat16_1.xyxx, (-u_xlat16_1.xyxx)).xy;
					    u_xlati22.xy = op_and((ivec2(u_xlatb22.xy) * -1), (ivec2(u_xlatb3.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat2;
					        hlslcc_movcTemp.x = (u_xlati22.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					        hlslcc_movcTemp.y = (u_xlati22.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					        u_xlat2 = hlslcc_movcTemp;
					    }
					    u_xlat16_1.xy = u_xlat2.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat2.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed2, _Back2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
					    u_xlat10_12.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_12.xy = u_xlat10_12.xy + vec2(-0.5, -0.5);
					    u_xlat16_12.xy = u_xlat16_12.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xy = u_xlat16_12.xy * u_xlat10_3.zz;
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
					    u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat1.w = _Back2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					    u_xlat16_10.xy = u_xlat16_4.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat1.yw;
					    u_xlat10_12.xyz = texture2D(_Back2Tex, u_xlat16_10.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Back2TexColor.xyz;
					    u_xlat1.z = _Back1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat1.xz;
					    u_xlat10_5.xyz = texture2D(_Back1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_5.xyz = u_xlat10_5.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_0.xy).xyz;
					    u_xlat16_0.xyz = u_xlat16_5.xyz * u_xlat10_3.yyy + u_xlat10_6.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_3.yyy + u_xlat16_0.xyz;
					    u_xlat16_24.xy = vs_TEXCOORD1.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_30 = max(abs(u_xlat16_24.y), abs(u_xlat16_24.x));
					    u_xlat16_30 = float(1.0) / u_xlat16_30;
					    u_xlat16_7.x = min(abs(u_xlat16_24.y), abs(u_xlat16_24.x));
					    u_xlat16_30 = u_xlat16_30 * u_xlat16_7.x;
					    u_xlat16_7.x = u_xlat16_30 * u_xlat16_30;
					    u_xlat16_12.x = u_xlat16_7.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + 0.180141002;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + -0.330299497;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + 0.999866009;
					    u_xlat16_22.x = u_xlat16_30 * u_xlat16_12.x;
					    u_xlat22.x = u_xlat16_22.x * -2.0 + 1.57079637;
					    u_xlatb32 = abs(u_xlat16_24.y)<abs(u_xlat16_24.x);
					    u_xlat22.x = u_xlatb32 ? u_xlat22.x : float(0.0);
					    u_xlat12 = u_xlat16_30 * u_xlat16_12.x + u_xlat22.x;
					    u_xlatb22.x = u_xlat16_24.y<(-u_xlat16_24.y);
					    u_xlat22.x = u_xlatb22.x ? -3.14159274 : float(0.0);
					    u_xlat12 = u_xlat22.x + u_xlat12;
					    u_xlat16_30 = min(u_xlat16_24.y, u_xlat16_24.x);
					    u_xlatb22.x = u_xlat16_30<(-u_xlat16_30);
					    u_xlat16_30 = max(u_xlat16_24.y, u_xlat16_24.x);
					    u_xlat16_24.x = dot(u_xlat16_24.xy, u_xlat16_24.xy);
					    u_xlat16_24.x = sqrt(u_xlat16_24.x);
					    u_xlat16_24.x = (-u_xlat16_24.x) + 1.0;
					    u_xlat5.y = _Front1TexAnimeSpeed * u_xlat2.x + u_xlat16_24.x;
					    u_xlatb32 = u_xlat16_30>=(-u_xlat16_30);
					    u_xlatb22.x = u_xlatb32 && u_xlatb22.x;
					    u_xlat12 = (u_xlatb22.x) ? (-u_xlat12) : u_xlat12;
					    u_xlat16_30 = u_xlat12 * 0.159154937 + 0.75;
					    u_xlat5.x = _Front1TexAnimeSpeed2 * u_xlat2.x + u_xlat16_30;
					    u_xlat16_24.xy = u_xlat16_4.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat5.xy;
					    u_xlat16_4.xy = u_xlat16_4.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_2.xyz = texture2D(_Front2Tex, u_xlat16_4.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front2TexColor.xyz;
					    u_xlat10_13.xyz = texture2D(_Front1Tex, u_xlat16_24.xy).xyz;
					    u_xlat16_13.xyz = u_xlat10_13.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_13.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_2.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
					    u_xlat10_2.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_2.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_2.x) * _IsKira + 1.0;
					    u_xlat16_2.x = u_xlat10_2.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_1.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24.x = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_24.x;
					    u_xlat16_14.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_12.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_12.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_12.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24.x * u_xlat10_12.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_2.x + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_1.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20 = u_xlat16_1.z * 0.167999998 + u_xlat16_20;
					    u_xlat16_37 = u_xlat10_12.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20 * u_xlat10_12.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_1.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_12.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_2.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_12.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_12.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_8.x * u_xlat10_12.z + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_0.x * u_xlat16_2.x + u_xlat16_0.y;
					    u_xlat10_2.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_2.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat10_2.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_2.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					float u_xlat4;
					vec3 u_xlat5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_9;
					vec2 u_xlat12;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.x = _Time.x * _DistotionTexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat16_3.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat12.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat12.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD3.xy = u_xlat12.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
					    u_xlat0.xy = _Time.xx * vec2(_Front1TexAnimeSpeed, _Front2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = sin(u_xlat0.y);
					    u_xlat4 = cos(u_xlat0.y);
					    u_xlat5.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat5.y = u_xlat1.x;
					    u_xlat5.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat5.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat5.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2.x);
					    u_xlat0.y = u_xlat4;
					    u_xlat0.z = u_xlat2.x;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_3.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_3.xy);
					    vs_TEXCOORD1.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_9 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_9;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
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
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					vec4 u_xlat1;
					mediump vec4 u_xlat16_1;
					vec2 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					bvec2 u_xlatb3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					lowp vec3 u_xlat10_5;
					lowp vec3 u_xlat10_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					lowp vec3 u_xlat10_12;
					mediump vec3 u_xlat16_13;
					lowp vec3 u_xlat10_13;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump vec2 u_xlat16_20;
					mediump vec2 u_xlat16_21;
					vec2 u_xlat22;
					mediump vec2 u_xlat16_22;
					ivec2 u_xlati22;
					bvec2 u_xlatb22;
					mediump float u_xlat16_24;
					mediump float u_xlat16_30;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0 = vs_TEXCOORD2.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = vec2(1.0, 1.0) / u_xlat16_1.xy;
					    u_xlat16_21.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_21.xy;
					    u_xlat16_21.xy = u_xlat16_1.xy * u_xlat16_1.xy;
					    u_xlat16_2.xy = u_xlat16_21.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_22.xy = u_xlat16_1.xy * u_xlat16_2.xy;
					    u_xlat22.xy = u_xlat16_22.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb3.xy = lessThan(abs(u_xlat16_0.ywyy), abs(u_xlat16_0.xzxx)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), u_xlat22.xy, vec2(u_xlatb3.xy));
					    u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat22.xy;
					    u_xlatb22.xy = lessThan(u_xlat16_0.ywyw, (-u_xlat16_0.ywyw)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb22.xy));
					    u_xlat2.xy = u_xlat22.xy + u_xlat2.xy;
					    u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb22.xy = lessThan(u_xlat16_1.xyxy, (-u_xlat16_1.xyxy)).xy;
					    u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb3.xy = greaterThanEqual(u_xlat16_1.xyxx, (-u_xlat16_1.xyxx)).xy;
					    u_xlati22.xy = op_and((ivec2(u_xlatb22.xy) * -1), (ivec2(u_xlatb3.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat2;
					        hlslcc_movcTemp.x = (u_xlati22.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					        hlslcc_movcTemp.y = (u_xlati22.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					        u_xlat2 = hlslcc_movcTemp;
					    }
					    u_xlat16_1.xy = u_xlat2.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat2.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed2, _Back2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
					    u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat1.w = _Back2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					    u_xlat1.z = _Back1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					    u_xlat10_2.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_2.xy = u_xlat10_2.xy + vec2(-0.5, -0.5);
					    u_xlat16_2.xy = u_xlat16_2.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_2.xy * u_xlat10_3.zz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat1.xz;
					    u_xlat16_4.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat1.yw;
					    u_xlat10_2.xyz = texture2D(_Back2Tex, u_xlat16_4.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back2TexColor.xyz;
					    u_xlat10_5.xyz = texture2D(_Back1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_5.xyz = u_xlat10_5.xyz * _Back1TexColor.xyz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_20.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_5.xyz * u_xlat10_3.yyy + u_xlat10_6.xyz;
					    u_xlat16_4.xyz = u_xlat16_2.xyz * u_xlat10_3.yyy + u_xlat16_4.xyz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_2.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front2TexColor.xyz;
					    u_xlat10_13.xyz = texture2D(_Front1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_13.xyz = u_xlat10_13.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_13.xyz * u_xlat10_3.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_2.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
					    u_xlat10_2.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_2.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_2.x) * _IsKira + 1.0;
					    u_xlat16_2.x = u_xlat10_2.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_1.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24 = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_24;
					    u_xlat16_14.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_12.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_12.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_12.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24 * u_xlat10_12.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_2.x + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_1.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20.x = u_xlat16_1.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat16_37 = u_xlat10_12.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20.x * u_xlat10_12.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_1.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_12.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_2.x + u_xlat16_0.x;
					    u_xlat10_3.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_3.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_3.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24 * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_3.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20.x * u_xlat10_3.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat10_5.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.x = u_xlat10_3.x * u_xlat16_18.y;
					    u_xlat16_20.x = u_xlat10_12.x * u_xlat16_18.y;
					    u_xlat16_20.x = u_xlat16_4.x * u_xlat10_12.y + u_xlat16_20.x;
					    u_xlat16_20.x = u_xlat16_8.x * u_xlat10_12.z + u_xlat16_20.x;
					    u_xlat16_7.y = u_xlat16_20.x * u_xlat16_2.x + u_xlat16_0.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_3.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat10_5.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					Keywords { "_BACK1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					float u_xlat4;
					vec3 u_xlat5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_9;
					vec2 u_xlat12;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.x = _Time.x * _DistotionTexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat16_3.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat12.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat12.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD3.xy = u_xlat12.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat12.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * u_xlat12.xx + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat1.zw = vec2(_Front2TexAnimeSpeed, _Front2TexAnimeSpeed2) * u_xlat12.xx + u_xlat0.xy;
					    vs_TEXCOORD1 = u_xlat1;
					    u_xlat0.xy = _Time.xx * vec2(_Back1TexAnimeSpeed, _Back2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = sin(u_xlat0.y);
					    u_xlat4 = cos(u_xlat0.y);
					    u_xlat5.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat5.y = u_xlat1.x;
					    u_xlat5.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat5.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat5.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2.x);
					    u_xlat0.y = u_xlat4;
					    u_xlat0.z = u_xlat2.x;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_3.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_9 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_9;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
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
					
					#endif
					#ifdef FRAGMENT
					#version 100
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					precision highp int;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					mediump vec4 u_xlat16_1;
					mediump vec2 u_xlat16_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec4 u_xlat16_5;
					mediump vec3 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					lowp vec3 u_xlat10_9;
					mediump float u_xlat16_10;
					mediump vec2 u_xlat16_11;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					mediump vec2 u_xlat16_14;
					mediump float u_xlat16_19;
					mediump vec2 u_xlat16_20;
					mediump float u_xlat16_28;
					mediump float u_xlat16_29;
					mediump float u_xlat16_31;
					void main()
					{
					    u_xlat10_0.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_1.x = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = u_xlat16_1.xxxx * vs_TEXCOORD5.yxyx;
					    u_xlat16_2.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_2.y);
					    u_xlat16_2.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_2.x;
					    u_xlat16_2.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_2.x;
					    u_xlat16_1.x = u_xlat16_1.x * 1.25 + u_xlat16_11.x;
					    u_xlat16_11.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_10 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_11.x);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.114 + u_xlat16_11.y;
					    u_xlat16_11.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_11.x;
					    u_xlat16_10 = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_10;
					    u_xlat10_3.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_20.x = u_xlat16_10 * u_xlat10_3.y;
					    u_xlat16_20.x = u_xlat16_1.x * u_xlat10_3.x + u_xlat16_20.x;
					    u_xlat16_4.z = u_xlat16_11.x * u_xlat10_3.z + u_xlat16_20.x;
					    u_xlat16_20.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_20.x;
					    u_xlat16_29 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_20.y);
					    u_xlat16_29 = u_xlat16_1.z * 0.330000013 + u_xlat16_29;
					    u_xlat16_20.x = u_xlat16_1.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat16_31 = u_xlat10_3.y * u_xlat16_29;
					    u_xlat16_31 = u_xlat16_20.x * u_xlat10_3.x + u_xlat16_31;
					    u_xlat16_5.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_5.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_5.xy);
					    u_xlat16_14.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_5.xy;
					    u_xlat16_19 = u_xlat16_1.z * 0.291999996 + u_xlat16_5.x;
					    u_xlat16_4.x = u_xlat16_14.x * u_xlat10_3.z + u_xlat16_31;
					    u_xlat16_28 = u_xlat10_3.x * u_xlat16_14.y;
					    u_xlat16_28 = u_xlat16_2.x * u_xlat10_3.y + u_xlat16_28;
					    u_xlat16_4.y = u_xlat16_19 * u_xlat10_3.z + u_xlat16_28;
					    u_xlat16_4.xyz = u_xlat10_0.xyz + u_xlat16_4.xyz;
					    u_xlat10_0.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_0.xy = u_xlat10_0.xy + vec2(-0.5, -0.5);
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_5.xw = u_xlat16_0.xy * u_xlat10_3.zz;
					    u_xlat16_6.xy = u_xlat16_5.xw * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_0.xyz = texture2D(_Back1Tex, u_xlat16_6.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back1TexColor.xyz;
					    u_xlat16_6.xy = u_xlat16_5.xw * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_6.xy).xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.yyy + u_xlat10_7.xyz;
					    u_xlat16_8.xy = u_xlat16_5.xw * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_0.xyz = texture2D(_Back2Tex, u_xlat16_8.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back2TexColor.xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.yyy + u_xlat16_6.xyz;
					    u_xlat16_8.xy = u_xlat16_5.xw * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat16_5.xw = u_xlat16_5.xw * vec2(_Front2TexDistotion) + vs_TEXCOORD1.zw;
					    u_xlat10_0.xyz = texture2D(_Front2Tex, u_xlat16_5.xw).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Front2TexColor.xyz;
					    u_xlat10_12.xyz = texture2D(_Front1Tex, u_xlat16_8.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Front1TexColor.xyz;
					    u_xlat16_6.xyz = u_xlat16_12.xyz * u_xlat10_3.xxx + u_xlat16_6.xyz;
					    u_xlat16_6.xyz = u_xlat16_0.xyz * u_xlat10_3.xxx + u_xlat16_6.xyz;
					    u_xlat10_0.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_8.xyz = (-u_xlat16_6.xyz) + u_xlat10_0.xyz;
					    u_xlat10_0.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_6.xyz = u_xlat10_0.xxx * u_xlat16_8.xyz + u_xlat16_6.xyz;
					    u_xlat10_0.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_28 = (-u_xlat10_0.x) * _IsKira + 1.0;
					    u_xlat16_0.x = u_xlat10_0.x * _IsKira;
					    u_xlat16_6.xyz = vec3(u_xlat16_28) * u_xlat16_6.xyz;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_10 = u_xlat10_9.y * u_xlat16_10;
					    u_xlat16_1.x = u_xlat16_1.x * u_xlat10_9.x + u_xlat16_10;
					    u_xlat16_1.x = u_xlat16_11.x * u_xlat10_9.z + u_xlat16_1.x;
					    u_xlat16_8.z = u_xlat16_1.x * u_xlat16_0.x + u_xlat16_6.z;
					    u_xlat16_1.x = u_xlat10_9.y * u_xlat16_29;
					    u_xlat16_1.x = u_xlat16_20.x * u_xlat10_9.x + u_xlat16_1.x;
					    u_xlat16_1.x = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_1.x;
					    u_xlat16_10 = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_10 = u_xlat16_2.x * u_xlat10_9.y + u_xlat16_10;
					    u_xlat16_10 = u_xlat16_19 * u_xlat10_9.z + u_xlat16_10;
					    u_xlat16_8.y = u_xlat16_10 * u_xlat16_0.x + u_xlat16_6.y;
					    u_xlat16_8.x = u_xlat16_1.x * u_xlat16_0.x + u_xlat16_6.x;
					    u_xlat16_1.xyz = u_xlat16_4.xyz * vec3(_IsKira) + u_xlat16_8.xyz;
					    SV_Target0.xyz = u_xlat16_1.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_POLAR" }
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_1;
					vec2 u_xlat2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_4;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb3 = 0.5>=u_xlat0.x;
					    u_xlat16_1 = (u_xlatb3) ? -12.0 : -0.0;
					    u_xlat16_1 = dot(vec2(u_xlat16_1), u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat2.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat2.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat2.xy + vec2(0.5, 0.5);
					    u_xlat16_4 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_1 + u_xlat16_4;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					vec4 u_xlat1;
					mediump vec4 u_xlat16_1;
					vec2 u_xlat2;
					mediump vec2 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					vec2 u_xlat3;
					lowp vec3 u_xlat10_3;
					bvec2 u_xlatb3;
					mediump vec3 u_xlat16_4;
					vec4 u_xlat5;
					mediump vec3 u_xlat16_5;
					lowp vec3 u_xlat10_5;
					bvec2 u_xlatb5;
					lowp vec3 u_xlat10_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					mediump vec2 u_xlat16_10;
					vec2 u_xlat12;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					vec2 u_xlat13;
					mediump vec3 u_xlat16_13;
					lowp vec3 u_xlat10_13;
					ivec2 u_xlati13;
					bvec2 u_xlatb13;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump float u_xlat16_20;
					mediump vec2 u_xlat16_21;
					vec2 u_xlat22;
					mediump vec2 u_xlat16_22;
					ivec2 u_xlati22;
					bvec2 u_xlatb22;
					mediump vec2 u_xlat16_24;
					mediump float u_xlat16_30;
					bool u_xlatb32;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0 = vs_TEXCOORD2.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = vec2(1.0, 1.0) / u_xlat16_1.xy;
					    u_xlat16_21.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_21.xy;
					    u_xlat16_21.xy = u_xlat16_1.xy * u_xlat16_1.xy;
					    u_xlat16_2.xy = u_xlat16_21.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_22.xy = u_xlat16_1.xy * u_xlat16_2.xy;
					    u_xlat22.xy = u_xlat16_22.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb3.xy = lessThan(abs(u_xlat16_0.ywyy), abs(u_xlat16_0.xzxx)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), u_xlat22.xy, vec2(u_xlatb3.xy));
					    u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat22.xy;
					    u_xlatb22.xy = lessThan(u_xlat16_0.ywyw, (-u_xlat16_0.ywyw)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb22.xy));
					    u_xlat2.xy = u_xlat22.xy + u_xlat2.xy;
					    u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb22.xy = lessThan(u_xlat16_1.xyxy, (-u_xlat16_1.xyxy)).xy;
					    u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb3.xy = greaterThanEqual(u_xlat16_1.xyxx, (-u_xlat16_1.xyxx)).xy;
					    u_xlati22.xy = op_and((ivec2(u_xlatb22.xy) * -1), (ivec2(u_xlatb3.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat2;
					        hlslcc_movcTemp.x = (u_xlati22.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					        hlslcc_movcTemp.y = (u_xlati22.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					        u_xlat2 = hlslcc_movcTemp;
					    }
					    u_xlat16_1.xy = u_xlat2.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat2.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed2, _Back2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
					    u_xlat16_4.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_24.x = max(abs(u_xlat16_4.y), abs(u_xlat16_4.x));
					    u_xlat16_24.x = float(1.0) / u_xlat16_24.x;
					    u_xlat16_34 = min(abs(u_xlat16_4.y), abs(u_xlat16_4.x));
					    u_xlat16_24.x = u_xlat16_24.x * u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24.x * u_xlat16_24.x;
					    u_xlat16_12.x = u_xlat16_34 * 0.0208350997 + -0.0851330012;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + 0.180141002;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + -0.330299497;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + 0.999866009;
					    u_xlat16_22.x = u_xlat16_12.x * u_xlat16_24.x;
					    u_xlat22.x = u_xlat16_22.x * -2.0 + 1.57079637;
					    u_xlatb32 = abs(u_xlat16_4.y)<abs(u_xlat16_4.x);
					    u_xlat22.x = u_xlatb32 ? u_xlat22.x : float(0.0);
					    u_xlat12.x = u_xlat16_24.x * u_xlat16_12.x + u_xlat22.x;
					    u_xlatb22.x = u_xlat16_4.y<(-u_xlat16_4.y);
					    u_xlat22.x = u_xlatb22.x ? -3.14159274 : float(0.0);
					    u_xlat12.x = u_xlat22.x + u_xlat12.x;
					    u_xlat16_24.x = min(u_xlat16_4.y, u_xlat16_4.x);
					    u_xlatb22.x = u_xlat16_24.x<(-u_xlat16_24.x);
					    u_xlat16_24.x = max(u_xlat16_4.y, u_xlat16_4.x);
					    u_xlat16_4.x = dot(u_xlat16_4.xy, u_xlat16_4.xy);
					    u_xlat16_4.x = sqrt(u_xlat16_4.x);
					    u_xlat16_4.x = (-u_xlat16_4.x) + 1.0;
					    u_xlat3.y = _DistotionTexAnimeSpeed * u_xlat2.x + u_xlat16_4.x;
					    u_xlatb32 = u_xlat16_24.x>=(-u_xlat16_24.x);
					    u_xlatb22.x = u_xlatb32 && u_xlatb22.x;
					    u_xlat12.x = (u_xlatb22.x) ? (-u_xlat12.x) : u_xlat12.x;
					    u_xlat16_4.x = u_xlat12.x * 0.159154937 + 0.75;
					    u_xlat3.x = _DistotionTexAnimeSpeed2 * u_xlat2.x + u_xlat16_4.x;
					    u_xlat10_12.xy = texture2D(_DistotionTex, u_xlat3.xy).xy;
					    u_xlat16_12.xy = u_xlat10_12.xy + vec2(-0.5, -0.5);
					    u_xlat16_12.xy = u_xlat16_12.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xy = u_xlat16_12.xy * u_xlat10_3.zz;
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
					    u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat1.w = _Back2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					    u_xlat16_10.xy = u_xlat16_4.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat1.yw;
					    u_xlat10_12.xyz = texture2D(_Back2Tex, u_xlat16_10.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Back2TexColor.xyz;
					    u_xlat1.z = _Back1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat1.xz;
					    u_xlat10_5.xyz = texture2D(_Back1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_5.xyz = u_xlat10_5.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_0.xy).xyz;
					    u_xlat16_0.xyz = u_xlat16_5.xyz * u_xlat10_3.yyy + u_xlat10_6.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_3.yyy + u_xlat16_0.xyz;
					    u_xlat16_1 = vs_TEXCOORD1.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_24.xy = max(abs(u_xlat16_1.yw), abs(u_xlat16_1.xz));
					    u_xlat16_24.xy = vec2(1.0, 1.0) / u_xlat16_24.xy;
					    u_xlat16_7.xy = min(abs(u_xlat16_1.yw), abs(u_xlat16_1.xz));
					    u_xlat16_24.xy = u_xlat16_24.xy * u_xlat16_7.xy;
					    u_xlat16_7.xy = u_xlat16_24.xy * u_xlat16_24.xy;
					    u_xlat16_12.xy = u_xlat16_7.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_12.xy = u_xlat16_7.xy * u_xlat16_12.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_12.xy = u_xlat16_7.xy * u_xlat16_12.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_12.xy = u_xlat16_7.xy * u_xlat16_12.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_13.xy = u_xlat16_12.xy * u_xlat16_24.xy;
					    u_xlat13.xy = u_xlat16_13.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb5.xy = lessThan(abs(u_xlat16_1.ywyy), abs(u_xlat16_1.xzxx)).xy;
					    u_xlat13.xy = mix(vec2(0.0, 0.0), u_xlat13.xy, vec2(u_xlatb5.xy));
					    u_xlat12.xy = u_xlat16_24.xy * u_xlat16_12.xy + u_xlat13.xy;
					    u_xlatb13.xy = lessThan(u_xlat16_1.ywyy, (-u_xlat16_1.ywyy)).xy;
					    u_xlat13.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb13.xy));
					    u_xlat12.xy = u_xlat12.xy + u_xlat13.xy;
					    u_xlat16_24.xy = min(u_xlat16_1.yw, u_xlat16_1.xz);
					    u_xlatb13.xy = lessThan(u_xlat16_24.xyxx, (-u_xlat16_24.xyxx)).xy;
					    u_xlat16_24.xy = max(u_xlat16_1.yw, u_xlat16_1.xz);
					    u_xlatb5.xy = greaterThanEqual(u_xlat16_24.xyxx, (-u_xlat16_24.xyxx)).xy;
					    u_xlati13.xy = op_and((ivec2(u_xlatb13.xy) * -1), (ivec2(u_xlatb5.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat12;
					        hlslcc_movcTemp.x = (u_xlati13.x != 0) ? (-u_xlat12.x) : u_xlat12.x;
					        hlslcc_movcTemp.y = (u_xlati13.y != 0) ? (-u_xlat12.y) : u_xlat12.y;
					        u_xlat12 = hlslcc_movcTemp;
					    }
					    u_xlat16_24.xy = u_xlat12.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat5.xy = vec2(_Front1TexAnimeSpeed2, _Front2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_24.xy;
					    u_xlat16_30 = dot(u_xlat16_1.xy, u_xlat16_1.xy);
					    u_xlat16_24.x = dot(u_xlat16_1.zw, u_xlat16_1.zw);
					    u_xlat16_24.x = sqrt(u_xlat16_24.x);
					    u_xlat16_24.x = (-u_xlat16_24.x) + 1.0;
					    u_xlat5.w = _Front2TexAnimeSpeed * u_xlat2.x + u_xlat16_24.x;
					    u_xlat16_24.xy = u_xlat16_4.xy * vec2(_Front2TexDistotion) + u_xlat5.yw;
					    u_xlat10_12.xyz = texture2D(_Front2Tex, u_xlat16_24.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Front2TexColor.xyz;
					    u_xlat16_30 = sqrt(u_xlat16_30);
					    u_xlat16_30 = (-u_xlat16_30) + 1.0;
					    u_xlat5.z = _Front1TexAnimeSpeed * u_xlat2.x + u_xlat16_30;
					    u_xlat16_4.xy = u_xlat16_4.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat5.xz;
					    u_xlat10_13.xyz = texture2D(_Front1Tex, u_xlat16_4.xy).xyz;
					    u_xlat16_13.xyz = u_xlat10_13.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_13.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_2.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
					    u_xlat10_2.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_2.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_2.x) * _IsKira + 1.0;
					    u_xlat16_2.x = u_xlat10_2.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_1.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24.x = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_24.x;
					    u_xlat16_14.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_12.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_12.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_12.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24.x * u_xlat10_12.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_2.x + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_1.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20 = u_xlat16_1.z * 0.167999998 + u_xlat16_20;
					    u_xlat16_37 = u_xlat10_12.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20 * u_xlat10_12.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_1.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_12.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_2.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_12.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_12.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_8.x * u_xlat10_12.z + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_0.x * u_xlat16_2.x + u_xlat16_0.y;
					    u_xlat10_2.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_2.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat10_2.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_2.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_POLAR" }
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					vec4 u_xlat1;
					mediump vec4 u_xlat16_1;
					vec2 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					vec2 u_xlat3;
					lowp vec3 u_xlat10_3;
					bvec2 u_xlatb3;
					mediump vec3 u_xlat16_4;
					vec2 u_xlat5;
					mediump vec3 u_xlat16_5;
					lowp vec3 u_xlat10_5;
					lowp vec3 u_xlat10_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					mediump vec2 u_xlat16_10;
					float u_xlat12;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump float u_xlat16_20;
					mediump vec2 u_xlat16_21;
					vec2 u_xlat22;
					mediump vec2 u_xlat16_22;
					ivec2 u_xlati22;
					bvec2 u_xlatb22;
					mediump vec2 u_xlat16_24;
					mediump float u_xlat16_30;
					bool u_xlatb32;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0 = vs_TEXCOORD2.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = vec2(1.0, 1.0) / u_xlat16_1.xy;
					    u_xlat16_21.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_21.xy;
					    u_xlat16_21.xy = u_xlat16_1.xy * u_xlat16_1.xy;
					    u_xlat16_2.xy = u_xlat16_21.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_2.xy = u_xlat16_21.xy * u_xlat16_2.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_22.xy = u_xlat16_1.xy * u_xlat16_2.xy;
					    u_xlat22.xy = u_xlat16_22.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb3.xy = lessThan(abs(u_xlat16_0.ywyy), abs(u_xlat16_0.xzxx)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), u_xlat22.xy, vec2(u_xlatb3.xy));
					    u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat22.xy;
					    u_xlatb22.xy = lessThan(u_xlat16_0.ywyw, (-u_xlat16_0.ywyw)).xy;
					    u_xlat22.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb22.xy));
					    u_xlat2.xy = u_xlat22.xy + u_xlat2.xy;
					    u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb22.xy = lessThan(u_xlat16_1.xyxy, (-u_xlat16_1.xyxy)).xy;
					    u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb3.xy = greaterThanEqual(u_xlat16_1.xyxx, (-u_xlat16_1.xyxx)).xy;
					    u_xlati22.xy = op_and((ivec2(u_xlatb22.xy) * -1), (ivec2(u_xlatb3.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat2;
					        hlslcc_movcTemp.x = (u_xlati22.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					        hlslcc_movcTemp.y = (u_xlati22.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					        u_xlat2 = hlslcc_movcTemp;
					    }
					    u_xlat16_1.xy = u_xlat2.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat2.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed2, _Back2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
					    u_xlat16_4.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_24.x = max(abs(u_xlat16_4.y), abs(u_xlat16_4.x));
					    u_xlat16_24.x = float(1.0) / u_xlat16_24.x;
					    u_xlat16_34 = min(abs(u_xlat16_4.y), abs(u_xlat16_4.x));
					    u_xlat16_24.x = u_xlat16_24.x * u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24.x * u_xlat16_24.x;
					    u_xlat16_12.x = u_xlat16_34 * 0.0208350997 + -0.0851330012;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + 0.180141002;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + -0.330299497;
					    u_xlat16_12.x = u_xlat16_34 * u_xlat16_12.x + 0.999866009;
					    u_xlat16_22.x = u_xlat16_12.x * u_xlat16_24.x;
					    u_xlat22.x = u_xlat16_22.x * -2.0 + 1.57079637;
					    u_xlatb32 = abs(u_xlat16_4.y)<abs(u_xlat16_4.x);
					    u_xlat22.x = u_xlatb32 ? u_xlat22.x : float(0.0);
					    u_xlat12 = u_xlat16_24.x * u_xlat16_12.x + u_xlat22.x;
					    u_xlatb22.x = u_xlat16_4.y<(-u_xlat16_4.y);
					    u_xlat22.x = u_xlatb22.x ? -3.14159274 : float(0.0);
					    u_xlat12 = u_xlat22.x + u_xlat12;
					    u_xlat16_24.x = min(u_xlat16_4.y, u_xlat16_4.x);
					    u_xlatb22.x = u_xlat16_24.x<(-u_xlat16_24.x);
					    u_xlat16_24.x = max(u_xlat16_4.y, u_xlat16_4.x);
					    u_xlat16_4.x = dot(u_xlat16_4.xy, u_xlat16_4.xy);
					    u_xlat16_4.x = sqrt(u_xlat16_4.x);
					    u_xlat16_4.x = (-u_xlat16_4.x) + 1.0;
					    u_xlat3.y = _DistotionTexAnimeSpeed * u_xlat2.x + u_xlat16_4.x;
					    u_xlatb32 = u_xlat16_24.x>=(-u_xlat16_24.x);
					    u_xlatb22.x = u_xlatb32 && u_xlatb22.x;
					    u_xlat12 = (u_xlatb22.x) ? (-u_xlat12) : u_xlat12;
					    u_xlat16_4.x = u_xlat12 * 0.159154937 + 0.75;
					    u_xlat3.x = _DistotionTexAnimeSpeed2 * u_xlat2.x + u_xlat16_4.x;
					    u_xlat10_12.xy = texture2D(_DistotionTex, u_xlat3.xy).xy;
					    u_xlat16_12.xy = u_xlat10_12.xy + vec2(-0.5, -0.5);
					    u_xlat16_12.xy = u_xlat16_12.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xy = u_xlat16_12.xy * u_xlat10_3.zz;
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
					    u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat1.w = _Back2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					    u_xlat16_10.xy = u_xlat16_4.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat1.yw;
					    u_xlat10_12.xyz = texture2D(_Back2Tex, u_xlat16_10.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Back2TexColor.xyz;
					    u_xlat1.z = _Back1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat1.xz;
					    u_xlat10_5.xyz = texture2D(_Back1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_5.xyz = u_xlat10_5.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xy = u_xlat16_4.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_0.xy).xyz;
					    u_xlat16_0.xyz = u_xlat16_5.xyz * u_xlat10_3.yyy + u_xlat10_6.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_3.yyy + u_xlat16_0.xyz;
					    u_xlat16_24.xy = u_xlat16_4.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat10_12.xyz = texture2D(_Front1Tex, u_xlat16_24.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat16_24.xy = vs_TEXCOORD1.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_30 = max(abs(u_xlat16_24.y), abs(u_xlat16_24.x));
					    u_xlat16_30 = float(1.0) / u_xlat16_30;
					    u_xlat16_7.x = min(abs(u_xlat16_24.y), abs(u_xlat16_24.x));
					    u_xlat16_30 = u_xlat16_30 * u_xlat16_7.x;
					    u_xlat16_7.x = u_xlat16_30 * u_xlat16_30;
					    u_xlat16_12.x = u_xlat16_7.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + 0.180141002;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + -0.330299497;
					    u_xlat16_12.x = u_xlat16_7.x * u_xlat16_12.x + 0.999866009;
					    u_xlat16_22.x = u_xlat16_30 * u_xlat16_12.x;
					    u_xlat22.x = u_xlat16_22.x * -2.0 + 1.57079637;
					    u_xlatb32 = abs(u_xlat16_24.y)<abs(u_xlat16_24.x);
					    u_xlat22.x = u_xlatb32 ? u_xlat22.x : float(0.0);
					    u_xlat12 = u_xlat16_30 * u_xlat16_12.x + u_xlat22.x;
					    u_xlatb22.x = u_xlat16_24.y<(-u_xlat16_24.y);
					    u_xlat22.x = u_xlatb22.x ? -3.14159274 : float(0.0);
					    u_xlat12 = u_xlat22.x + u_xlat12;
					    u_xlat16_30 = min(u_xlat16_24.y, u_xlat16_24.x);
					    u_xlatb22.x = u_xlat16_30<(-u_xlat16_30);
					    u_xlat16_30 = max(u_xlat16_24.y, u_xlat16_24.x);
					    u_xlat16_24.x = dot(u_xlat16_24.xy, u_xlat16_24.xy);
					    u_xlat16_24.x = sqrt(u_xlat16_24.x);
					    u_xlat16_24.x = (-u_xlat16_24.x) + 1.0;
					    u_xlat5.y = _Front2TexAnimeSpeed * u_xlat2.x + u_xlat16_24.x;
					    u_xlatb32 = u_xlat16_30>=(-u_xlat16_30);
					    u_xlatb22.x = u_xlatb32 && u_xlatb22.x;
					    u_xlat12 = (u_xlatb22.x) ? (-u_xlat12) : u_xlat12;
					    u_xlat16_30 = u_xlat12 * 0.159154937 + 0.75;
					    u_xlat5.x = _Front2TexAnimeSpeed2 * u_xlat2.x + u_xlat16_30;
					    u_xlat16_4.xy = u_xlat16_4.xy * vec2(_Front2TexDistotion) + u_xlat5.xy;
					    u_xlat10_2.xyz = texture2D(_Front2Tex, u_xlat16_4.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front2TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_2.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
					    u_xlat10_2.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_2.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_2.x) * _IsKira + 1.0;
					    u_xlat16_2.x = u_xlat10_2.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_1.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24.x = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_24.x;
					    u_xlat16_14.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_12.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_12.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_12.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24.x * u_xlat10_12.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_2.x + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_1.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20 = u_xlat16_1.z * 0.167999998 + u_xlat16_20;
					    u_xlat16_37 = u_xlat10_12.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20 * u_xlat10_12.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_1.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_12.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_2.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_12.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_12.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_8.x * u_xlat10_12.z + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_0.x * u_xlat16_2.x + u_xlat16_0.y;
					    u_xlat10_2.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20 * u_xlat10_2.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_2.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_2.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_2.z + u_xlat16_0.x;
					    u_xlat10_2.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_2.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_POLAR" }
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					lowp vec3 u_xlat10_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					float u_xlat10;
					mediump vec3 u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_16;
					mediump float u_xlat16_18;
					float u_xlat19;
					mediump float u_xlat16_19;
					bool u_xlatb19;
					mediump float u_xlat16_21;
					mediump float u_xlat16_27;
					bool u_xlatb28;
					mediump float u_xlat16_30;
					mediump float u_xlat16_33;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18 = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = float(1.0) / u_xlat16_18;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = u_xlat16_18 * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18 * u_xlat16_18;
					    u_xlat16_1.x = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_27 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_10.x = u_xlat16_18 * u_xlat16_1.x;
					    u_xlat10 = u_xlat16_10.x * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10 = u_xlatb19 ? u_xlat10 : float(0.0);
					    u_xlat1 = u_xlat16_18 * u_xlat16_1.x + u_xlat10;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10 = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10 + u_xlat1;
					    u_xlat16_18 = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18<(-u_xlat16_18);
					    u_xlat16_18 = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_18>=(-u_xlat16_18);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat16_9.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_3.x = min(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_10.x = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + 0.180141002;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + -0.330299497;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + 0.999866009;
					    u_xlat16_19 = u_xlat16_27 * u_xlat16_10.x;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_9.y)<abs(u_xlat16_9.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_27 * u_xlat16_10.x + u_xlat19;
					    u_xlatb19 = u_xlat16_9.y<(-u_xlat16_9.y);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_27 = min(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlatb19 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlat16_9.x = dot(u_xlat16_9.xy, u_xlat16_9.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_9.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb28 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_9.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat10_10.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_10.xy = u_xlat10_10.xy + vec2(-0.5, -0.5);
					    u_xlat16_10.xy = u_xlat16_10.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_9.xy = u_xlat16_10.xy * u_xlat10_4.zz;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_10.xyz = texture2D(_Back2Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_10.xyz = u_xlat10_10.xyz * _Back2TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_5.xyz = texture2D(_MainTex, u_xlat16_0.xw).xyz;
					    u_xlat16_3.xyz = u_xlat16_2.xyz * u_xlat10_4.yyy + u_xlat10_5.xyz;
					    u_xlat16_3.xyz = u_xlat16_10.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat10_10.xyz = texture2D(_Front1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_10.xyz = u_xlat10_10.xyz * _Front1TexColor.xyz;
					    u_xlat16_3.xyz = u_xlat16_10.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xw = vs_TEXCOORD1.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_30 = max(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_30 = float(1.0) / u_xlat16_30;
					    u_xlat16_6.x = min(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_30 = u_xlat16_30 * u_xlat16_6.x;
					    u_xlat16_6.x = u_xlat16_30 * u_xlat16_30;
					    u_xlat16_10.x = u_xlat16_6.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + 0.180141002;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + -0.330299497;
					    u_xlat16_10.x = u_xlat16_6.x * u_xlat16_10.x + 0.999866009;
					    u_xlat16_19 = u_xlat16_10.x * u_xlat16_30;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_0.w)<abs(u_xlat16_0.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10 = u_xlat16_30 * u_xlat16_10.x + u_xlat19;
					    u_xlatb19 = u_xlat16_0.w<(-u_xlat16_0.w);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10 = u_xlat19 + u_xlat10;
					    u_xlat16_30 = min(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_30<(-u_xlat16_30);
					    u_xlat16_30 = max(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xw, u_xlat16_0.xw);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlat2.y = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlatb28 = u_xlat16_30>=(-u_xlat16_30);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10 = (u_xlatb19) ? (-u_xlat10) : u_xlat10;
					    u_xlat16_0.x = u_xlat10 * 0.159154937 + 0.75;
					    u_xlat2.x = _Front2TexAnimeSpeed2 * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_9.xy * vec2(_Front2TexDistotion) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_21 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_21 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_21;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_30 = u_xlat10_10.y * u_xlat16_12.x;
					    u_xlat16_30 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_30;
					    u_xlat16_30 = u_xlat16_21 * u_xlat10_10.z + u_xlat16_30;
					    u_xlat16_6.z = u_xlat16_30 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_30 = u_xlat16_2.z * 0.330000013 + u_xlat16_30;
					    u_xlat16_18 = u_xlat16_2.z * 0.167999998 + u_xlat16_18;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_30;
					    u_xlat16_33 = u_xlat16_18 * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_21 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_30;
					    u_xlat16_0.x = u_xlat16_18 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_BACK1TEX_SCROLL" "_FRONT2TEX_POLAR" }
					Keywords { "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_BACK1TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_5;
					float u_xlat7;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat7 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat7) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat0.xy;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
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
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_2 + u_xlat16_5;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					float u_xlat1;
					mediump float u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					vec4 u_xlat4;
					lowp vec3 u_xlat10_4;
					bvec2 u_xlatb4;
					mediump vec3 u_xlat16_5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					vec2 u_xlat10;
					mediump vec3 u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					vec2 u_xlat12;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					ivec2 u_xlati12;
					bvec2 u_xlatb12;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_16;
					mediump float u_xlat16_18;
					bool u_xlatb19;
					mediump float u_xlat16_23;
					mediump float u_xlat16_27;
					mediump float u_xlat16_32;
					mediump float u_xlat16_33;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18 = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = float(1.0) / u_xlat16_18;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = u_xlat16_18 * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18 * u_xlat16_18;
					    u_xlat16_1 = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1 = u_xlat16_27 * u_xlat16_1 + 0.180141002;
					    u_xlat16_1 = u_xlat16_27 * u_xlat16_1 + -0.330299497;
					    u_xlat16_1 = u_xlat16_27 * u_xlat16_1 + 0.999866009;
					    u_xlat16_10.x = u_xlat16_18 * u_xlat16_1;
					    u_xlat10.x = u_xlat16_10.x * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10.x = u_xlatb19 ? u_xlat10.x : float(0.0);
					    u_xlat1 = u_xlat16_18 * u_xlat16_1 + u_xlat10.x;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10.x = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10.x + u_xlat1;
					    u_xlat16_18 = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18<(-u_xlat16_18);
					    u_xlat16_18 = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb19 = u_xlat16_18>=(-u_xlat16_18);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat10_10.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_10.xy = u_xlat10_10.xy + vec2(-0.5, -0.5);
					    u_xlat16_10.xy = u_xlat16_10.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_9.xy = u_xlat16_10.xy * u_xlat10_3.zz;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_10.xyz = texture2D(_Back2Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_10.xyz = u_xlat10_10.xyz * _Back2TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_4.xyz = texture2D(_MainTex, u_xlat16_0.xw).xyz;
					    u_xlat16_5.xyz = u_xlat16_2.xyz * u_xlat10_3.yyy + u_xlat10_4.xyz;
					    u_xlat16_5.xyz = u_xlat16_10.xyz * u_xlat10_3.yyy + u_xlat16_5.xyz;
					    u_xlat16_2 = vs_TEXCOORD1.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_0.xw = max(abs(u_xlat16_2.yw), abs(u_xlat16_2.xz));
					    u_xlat16_0.xw = vec2(1.0, 1.0) / u_xlat16_0.xw;
					    u_xlat16_6.xy = min(abs(u_xlat16_2.yw), abs(u_xlat16_2.xz));
					    u_xlat16_0.xw = u_xlat16_0.xw * u_xlat16_6.xy;
					    u_xlat16_6.xy = u_xlat16_0.xw * u_xlat16_0.xw;
					    u_xlat16_10.xy = u_xlat16_6.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_10.xy = u_xlat16_6.xy * u_xlat16_10.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_10.xy = u_xlat16_6.xy * u_xlat16_10.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_10.xy = u_xlat16_6.xy * u_xlat16_10.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_12.xy = u_xlat16_0.xw * u_xlat16_10.xy;
					    u_xlat12.xy = u_xlat16_12.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb4.xy = lessThan(abs(u_xlat16_2.ywyy), abs(u_xlat16_2.xzxx)).xy;
					    u_xlat12.xy = mix(vec2(0.0, 0.0), u_xlat12.xy, vec2(u_xlatb4.xy));
					    u_xlat10.xy = u_xlat16_0.xw * u_xlat16_10.xy + u_xlat12.xy;
					    u_xlatb12.xy = lessThan(u_xlat16_2.ywyy, (-u_xlat16_2.ywyy)).xy;
					    u_xlat12.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb12.xy));
					    u_xlat10.xy = u_xlat10.xy + u_xlat12.xy;
					    u_xlat16_0.xw = min(u_xlat16_2.yw, u_xlat16_2.xz);
					    u_xlatb12.xy = lessThan(u_xlat16_0.xwxx, (-u_xlat16_0.xwxx)).xy;
					    u_xlat16_0.xw = max(u_xlat16_2.yw, u_xlat16_2.xz);
					    u_xlatb4.xy = greaterThanEqual(u_xlat16_0.xwxx, (-u_xlat16_0.xwxx)).xy;
					    u_xlati12.xy = op_and((ivec2(u_xlatb12.xy) * -1), (ivec2(u_xlatb4.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat10;
					        hlslcc_movcTemp.x = (u_xlati12.x != 0) ? (-u_xlat10.x) : u_xlat10.x;
					        hlslcc_movcTemp.y = (u_xlati12.y != 0) ? (-u_xlat10.y) : u_xlat10.y;
					        u_xlat10 = hlslcc_movcTemp;
					    }
					    u_xlat16_0.xw = u_xlat10.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat4.xy = vec2(_Front1TexAnimeSpeed2, _Front2TexAnimeSpeed2) * vec2(u_xlat1) + u_xlat16_0.xw;
					    u_xlat16_0.x = dot(u_xlat16_2.xy, u_xlat16_2.xy);
					    u_xlat16_0.w = dot(u_xlat16_2.zw, u_xlat16_2.zw);
					    u_xlat16_0.xw = sqrt(u_xlat16_0.xw);
					    u_xlat16_0.xw = (-u_xlat16_0.xw) + vec2(1.0, 1.0);
					    u_xlat4.w = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_0.w;
					    u_xlat16_6.xy = u_xlat16_9.xy * vec2(_Front2TexDistotion) + u_xlat4.yw;
					    u_xlat10_10.xyz = texture2D(_Front2Tex, u_xlat16_6.xy).xyz;
					    u_xlat16_10.xyz = u_xlat10_10.xyz * _Front2TexColor.xyz;
					    u_xlat4.z = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_9.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat4.xz;
					    u_xlat10_12.xyz = texture2D(_Front1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_3.xxx + u_xlat16_5.xyz;
					    u_xlat16_0.xyz = u_xlat16_10.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_5.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_5.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1 = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_5.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_5.y);
					    u_xlat16_5.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_5.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_14.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_23 = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_23 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_23;
					    u_xlat16_14.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat10_10.y * u_xlat16_14.x;
					    u_xlat16_32 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_32;
					    u_xlat16_32 = u_xlat16_23 * u_xlat10_10.z + u_xlat16_32;
					    u_xlat16_6.z = u_xlat16_32 * u_xlat16_1 + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_32 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_32 = u_xlat16_2.z * 0.330000013 + u_xlat16_32;
					    u_xlat16_18 = u_xlat16_2.z * 0.167999998 + u_xlat16_18;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_32;
					    u_xlat16_33 = u_xlat16_18 * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1 + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_5.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1 + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_23 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_32;
					    u_xlat16_0.x = u_xlat16_18 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_5.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" "_FRONT2TEX_POLAR" }
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_1;
					vec2 u_xlat2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_4;
					float u_xlat6;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat6 = fract(_Time.x);
					    u_xlat0.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * vec2(u_xlat6) + u_xlat0.xy;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb3 = 0.5>=u_xlat0.x;
					    u_xlat16_1 = (u_xlatb3) ? -12.0 : -0.0;
					    u_xlat16_1 = dot(vec2(u_xlat16_1), u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat2.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat2.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat2.xy + vec2(0.5, 0.5);
					    u_xlat16_4 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_1 + u_xlat16_4;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					float u_xlat1;
					mediump float u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					vec4 u_xlat5;
					lowp vec3 u_xlat10_5;
					bvec2 u_xlatb5;
					mediump vec3 u_xlat16_6;
					mediump vec2 u_xlat16_7;
					mediump vec3 u_xlat16_8;
					mediump vec2 u_xlat16_9;
					vec2 u_xlat10;
					mediump vec3 u_xlat16_10;
					lowp vec3 u_xlat10_10;
					bool u_xlatb10;
					mediump vec2 u_xlat16_12;
					vec2 u_xlat13;
					mediump vec3 u_xlat16_13;
					lowp vec3 u_xlat10_13;
					ivec2 u_xlati13;
					bvec2 u_xlatb13;
					mediump vec2 u_xlat16_16;
					mediump float u_xlat16_18;
					float u_xlat19;
					mediump float u_xlat16_19;
					bool u_xlatb19;
					mediump float u_xlat16_21;
					mediump float u_xlat16_27;
					bool u_xlatb28;
					mediump float u_xlat16_30;
					mediump float u_xlat16_33;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_18 = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = float(1.0) / u_xlat16_18;
					    u_xlat16_27 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_18 = u_xlat16_18 * u_xlat16_27;
					    u_xlat16_27 = u_xlat16_18 * u_xlat16_18;
					    u_xlat16_1 = u_xlat16_27 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1 = u_xlat16_27 * u_xlat16_1 + 0.180141002;
					    u_xlat16_1 = u_xlat16_27 * u_xlat16_1 + -0.330299497;
					    u_xlat16_1 = u_xlat16_27 * u_xlat16_1 + 0.999866009;
					    u_xlat16_10.x = u_xlat16_18 * u_xlat16_1;
					    u_xlat10.x = u_xlat16_10.x * -2.0 + 1.57079637;
					    u_xlatb19 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat10.x = u_xlatb19 ? u_xlat10.x : float(0.0);
					    u_xlat1 = u_xlat16_18 * u_xlat16_1 + u_xlat10.x;
					    u_xlatb10 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat10.x = u_xlatb10 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat10.x + u_xlat1;
					    u_xlat16_18 = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb10 = u_xlat16_18<(-u_xlat16_18);
					    u_xlat16_18 = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb19 = u_xlat16_18>=(-u_xlat16_18);
					    u_xlatb10 = u_xlatb19 && u_xlatb10;
					    u_xlat1 = (u_xlatb10) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_9.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back2TexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat16_9.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_3.x = min(abs(u_xlat16_9.y), abs(u_xlat16_9.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_10.x = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + 0.180141002;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + -0.330299497;
					    u_xlat16_10.x = u_xlat16_3.x * u_xlat16_10.x + 0.999866009;
					    u_xlat16_19 = u_xlat16_27 * u_xlat16_10.x;
					    u_xlat19 = u_xlat16_19 * -2.0 + 1.57079637;
					    u_xlatb28 = abs(u_xlat16_9.y)<abs(u_xlat16_9.x);
					    u_xlat19 = u_xlatb28 ? u_xlat19 : float(0.0);
					    u_xlat10.x = u_xlat16_27 * u_xlat16_10.x + u_xlat19;
					    u_xlatb19 = u_xlat16_9.y<(-u_xlat16_9.y);
					    u_xlat19 = u_xlatb19 ? -3.14159274 : float(0.0);
					    u_xlat10.x = u_xlat19 + u_xlat10.x;
					    u_xlat16_27 = min(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlatb19 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_9.y, u_xlat16_9.x);
					    u_xlat16_9.x = dot(u_xlat16_9.xy, u_xlat16_9.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_9.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb28 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb19 = u_xlatb28 && u_xlatb19;
					    u_xlat10.x = (u_xlatb19) ? (-u_xlat10.x) : u_xlat10.x;
					    u_xlat16_9.x = u_xlat10.x * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_9.x;
					    u_xlat10_10.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_10.xy = u_xlat10_10.xy + vec2(-0.5, -0.5);
					    u_xlat16_10.xy = u_xlat16_10.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_9.xy = u_xlat16_10.xy * u_xlat10_4.zz;
					    u_xlat2.y = _Back2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat2.xy;
					    u_xlat10_10.xyz = texture2D(_Back2Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_10.xyz = u_xlat10_10.xyz * _Back2TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_2.xyz = texture2D(_Back1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_9.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_5.xyz = texture2D(_MainTex, u_xlat16_0.xw).xyz;
					    u_xlat16_3.xyz = u_xlat16_2.xyz * u_xlat10_4.yyy + u_xlat10_5.xyz;
					    u_xlat16_3.xyz = u_xlat16_10.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_2 = vs_TEXCOORD1.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_0.xw = max(abs(u_xlat16_2.yw), abs(u_xlat16_2.xz));
					    u_xlat16_0.xw = vec2(1.0, 1.0) / u_xlat16_0.xw;
					    u_xlat16_6.xy = min(abs(u_xlat16_2.yw), abs(u_xlat16_2.xz));
					    u_xlat16_0.xw = u_xlat16_0.xw * u_xlat16_6.xy;
					    u_xlat16_6.xy = u_xlat16_0.xw * u_xlat16_0.xw;
					    u_xlat16_10.xy = u_xlat16_6.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_10.xy = u_xlat16_6.xy * u_xlat16_10.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_10.xy = u_xlat16_6.xy * u_xlat16_10.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_10.xy = u_xlat16_6.xy * u_xlat16_10.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_13.xy = u_xlat16_0.xw * u_xlat16_10.xy;
					    u_xlat13.xy = u_xlat16_13.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb5.xy = lessThan(abs(u_xlat16_2.ywyy), abs(u_xlat16_2.xzxx)).xy;
					    u_xlat13.xy = mix(vec2(0.0, 0.0), u_xlat13.xy, vec2(u_xlatb5.xy));
					    u_xlat10.xy = u_xlat16_0.xw * u_xlat16_10.xy + u_xlat13.xy;
					    u_xlatb13.xy = lessThan(u_xlat16_2.ywyy, (-u_xlat16_2.ywyy)).xy;
					    u_xlat13.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb13.xy));
					    u_xlat10.xy = u_xlat10.xy + u_xlat13.xy;
					    u_xlat16_0.xw = min(u_xlat16_2.yw, u_xlat16_2.xz);
					    u_xlatb13.xy = lessThan(u_xlat16_0.xwxx, (-u_xlat16_0.xwxx)).xy;
					    u_xlat16_0.xw = max(u_xlat16_2.yw, u_xlat16_2.xz);
					    u_xlatb5.xy = greaterThanEqual(u_xlat16_0.xwxx, (-u_xlat16_0.xwxx)).xy;
					    u_xlati13.xy = op_and((ivec2(u_xlatb13.xy) * -1), (ivec2(u_xlatb5.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat10;
					        hlslcc_movcTemp.x = (u_xlati13.x != 0) ? (-u_xlat10.x) : u_xlat10.x;
					        hlslcc_movcTemp.y = (u_xlati13.y != 0) ? (-u_xlat10.y) : u_xlat10.y;
					        u_xlat10 = hlslcc_movcTemp;
					    }
					    u_xlat16_0.xw = u_xlat10.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat5.xy = vec2(_Front1TexAnimeSpeed2, _Front2TexAnimeSpeed2) * vec2(u_xlat1) + u_xlat16_0.xw;
					    u_xlat16_0.x = dot(u_xlat16_2.xy, u_xlat16_2.xy);
					    u_xlat16_0.w = dot(u_xlat16_2.zw, u_xlat16_2.zw);
					    u_xlat16_0.xw = sqrt(u_xlat16_0.xw);
					    u_xlat16_0.xw = (-u_xlat16_0.xw) + vec2(1.0, 1.0);
					    u_xlat5.w = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_0.w;
					    u_xlat16_6.xy = u_xlat16_9.xy * vec2(_Front2TexDistotion) + u_xlat5.yw;
					    u_xlat10_10.xyz = texture2D(_Front2Tex, u_xlat16_6.xy).xyz;
					    u_xlat16_10.xyz = u_xlat10_10.xyz * _Front2TexColor.xyz;
					    u_xlat5.z = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_9.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat5.xz;
					    u_xlat10_13.xyz = texture2D(_Front1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_13.xyz = u_xlat10_13.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_13.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_10.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_27 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1 = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_27) * u_xlat16_0.xyz;
					    u_xlat16_27 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_27) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_27 = u_xlat16_2.x * 1.25 + u_xlat16_27;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_21 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_21 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_21;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_10.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_30 = u_xlat10_10.y * u_xlat16_12.x;
					    u_xlat16_30 = u_xlat16_27 * u_xlat10_10.x + u_xlat16_30;
					    u_xlat16_30 = u_xlat16_21 * u_xlat10_10.z + u_xlat16_30;
					    u_xlat16_6.z = u_xlat16_30 * u_xlat16_1 + u_xlat16_0.z;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_18 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_7.x;
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_7.y);
					    u_xlat16_30 = u_xlat16_2.z * 0.330000013 + u_xlat16_30;
					    u_xlat16_18 = u_xlat16_2.z * 0.167999998 + u_xlat16_18;
					    u_xlat16_33 = u_xlat10_10.y * u_xlat16_30;
					    u_xlat16_33 = u_xlat16_18 * u_xlat10_10.x + u_xlat16_33;
					    u_xlat16_7.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_7.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_7.xy);
					    u_xlat16_16.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_7.xy;
					    u_xlat16_7.x = u_xlat16_2.z * 0.291999996 + u_xlat16_7.x;
					    u_xlat16_33 = u_xlat16_16.x * u_xlat10_10.z + u_xlat16_33;
					    u_xlat16_6.x = u_xlat16_33 * u_xlat16_1 + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_10.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_10.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_7.x * u_xlat10_10.z + u_xlat16_0.x;
					    u_xlat16_6.y = u_xlat16_0.x * u_xlat16_1 + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_27 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.z = u_xlat16_21 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_30;
					    u_xlat16_0.x = u_xlat16_18 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_8.x = u_xlat16_16.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_16.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_8.y = u_xlat16_7.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_6.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					mediump vec2 u_xlat16_5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_11;
					float u_xlat12;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat12 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat12) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = _Time.xx * vec2(_Back1TexAnimeSpeed, _Back2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2 = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD2.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_5.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_5.x = dot(u_xlat16_5.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_11 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_5.x + u_xlat16_11;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					vec4 u_xlat1;
					mediump vec4 u_xlat16_1;
					vec2 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					bvec2 u_xlatb3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					lowp vec3 u_xlat10_5;
					mediump vec3 u_xlat16_6;
					lowp vec3 u_xlat10_6;
					mediump vec3 u_xlat16_7;
					lowp vec3 u_xlat10_7;
					lowp vec3 u_xlat10_8;
					mediump vec3 u_xlat16_9;
					mediump vec2 u_xlat16_10;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_14;
					mediump vec2 u_xlat16_16;
					mediump vec2 u_xlat16_22;
					mediump vec2 u_xlat16_24;
					mediump vec2 u_xlat16_25;
					vec2 u_xlat26;
					mediump vec2 u_xlat16_26;
					ivec2 u_xlati26;
					bvec2 u_xlatb26;
					mediump float u_xlat16_28;
					mediump float u_xlat16_36;
					mediump float u_xlat16_40;
					mediump float u_xlat16_45;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0 = vs_TEXCOORD1.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = vec2(1.0, 1.0) / u_xlat16_1.xy;
					    u_xlat16_25.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
					    u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_25.xy;
					    u_xlat16_25.xy = u_xlat16_1.xy * u_xlat16_1.xy;
					    u_xlat16_2.xy = u_xlat16_25.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_2.xy = u_xlat16_25.xy * u_xlat16_2.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_2.xy = u_xlat16_25.xy * u_xlat16_2.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_2.xy = u_xlat16_25.xy * u_xlat16_2.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_26.xy = u_xlat16_1.xy * u_xlat16_2.xy;
					    u_xlat26.xy = u_xlat16_26.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb3.xy = lessThan(abs(u_xlat16_0.ywyy), abs(u_xlat16_0.xzxx)).xy;
					    u_xlat26.xy = mix(vec2(0.0, 0.0), u_xlat26.xy, vec2(u_xlatb3.xy));
					    u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat26.xy;
					    u_xlatb26.xy = lessThan(u_xlat16_0.ywyw, (-u_xlat16_0.ywyw)).xy;
					    u_xlat26.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb26.xy));
					    u_xlat2.xy = u_xlat26.xy + u_xlat2.xy;
					    u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb26.xy = lessThan(u_xlat16_1.xyxy, (-u_xlat16_1.xyxy)).xy;
					    u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
					    u_xlatb3.xy = greaterThanEqual(u_xlat16_1.xyxx, (-u_xlat16_1.xyxx)).xy;
					    u_xlati26.xy = op_and((ivec2(u_xlatb26.xy) * -1), (ivec2(u_xlatb3.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat2;
					        hlslcc_movcTemp.x = (u_xlati26.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					        hlslcc_movcTemp.y = (u_xlati26.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					        u_xlat2 = hlslcc_movcTemp;
					    }
					    u_xlat16_1.xy = u_xlat2.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat2.x = fract(_Time.x);
					    u_xlat1.xy = vec2(_Front1TexAnimeSpeed2, _Front2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
					    u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat1.w = _Front2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					    u_xlat1.z = _Front1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					    u_xlat10_2.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_2.xy = u_xlat10_2.xy + vec2(-0.5, -0.5);
					    u_xlat16_2.xy = u_xlat16_2.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_2.xy * u_xlat10_3.zz;
					    u_xlat16_24.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat1.xz;
					    u_xlat16_4.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + u_xlat1.yw;
					    u_xlat10_2.xyz = texture2D(_Front2Tex, u_xlat16_4.xy).xyz;
					    u_xlat16_2.xyz = u_xlat10_2.xyz * _Front2TexColor.xyz;
					    u_xlat10_5.xyz = texture2D(_Front1Tex, u_xlat16_24.xy).xyz;
					    u_xlat16_5.xyz = u_xlat10_5.xyz * _Front1TexColor.xyz;
					    u_xlat16_24.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_6.xyz = texture2D(_Back1Tex, u_xlat16_24.xy).xyz;
					    u_xlat16_6.xyz = u_xlat10_6.xyz * _Back1TexColor.xyz;
					    u_xlat16_24.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_7.xyz = texture2D(_Back2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_7.xyz = u_xlat10_7.xyz * _Back2TexColor.xyz;
					    u_xlat10_8.xyz = texture2D(_MainTex, u_xlat16_24.xy).xyz;
					    u_xlat16_0.xyz = u_xlat16_6.xyz * u_xlat10_3.yyy + u_xlat10_8.xyz;
					    u_xlat16_0.xyz = u_xlat16_7.xyz * u_xlat10_3.yyy + u_xlat16_0.xyz;
					    u_xlat16_0.xyz = u_xlat16_5.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat16_0.xyz = u_xlat16_2.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
					    u_xlat10_2.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
					    u_xlat10_2.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_2.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_36 = (-u_xlat10_2.x) * _IsKira + 1.0;
					    u_xlat16_2.x = u_xlat10_2.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_36) * u_xlat16_0.xyz;
					    u_xlat16_36 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_36) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_36 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_36 = u_xlat16_1.x * 1.25 + u_xlat16_36;
					    u_xlat16_16.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_16.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_16.x);
					    u_xlat16_28 = vs_TEXCOORD5.z * 0.114 + u_xlat16_16.y;
					    u_xlat16_28 = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_28;
					    u_xlat16_16.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_16.x;
					    u_xlat10_14.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_40 = u_xlat10_14.y * u_xlat16_16.x;
					    u_xlat16_40 = u_xlat16_36 * u_xlat10_14.x + u_xlat16_40;
					    u_xlat16_40 = u_xlat16_28 * u_xlat10_14.z + u_xlat16_40;
					    u_xlat16_9.z = u_xlat16_40 * u_xlat16_2.x + u_xlat16_0.z;
					    u_xlat16_10.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_24.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_10.x;
					    u_xlat16_40 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_10.y);
					    u_xlat16_40 = u_xlat16_1.z * 0.330000013 + u_xlat16_40;
					    u_xlat16_24.x = u_xlat16_1.z * 0.167999998 + u_xlat16_24.x;
					    u_xlat16_45 = u_xlat10_14.y * u_xlat16_40;
					    u_xlat16_45 = u_xlat16_24.x * u_xlat10_14.x + u_xlat16_45;
					    u_xlat16_10.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_10.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_10.xy);
					    u_xlat16_22.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_10.xy;
					    u_xlat16_10.x = u_xlat16_1.z * 0.291999996 + u_xlat16_10.x;
					    u_xlat16_45 = u_xlat16_22.x * u_xlat10_14.z + u_xlat16_45;
					    u_xlat16_9.x = u_xlat16_45 * u_xlat16_2.x + u_xlat16_0.x;
					    u_xlat10_3.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_3.y * u_xlat16_16.x;
					    u_xlat16_0.x = u_xlat16_36 * u_xlat10_3.x + u_xlat16_0.x;
					    u_xlat16_11.z = u_xlat16_28 * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_3.y * u_xlat16_40;
					    u_xlat16_0.x = u_xlat16_24.x * u_xlat10_3.x + u_xlat16_0.x;
					    u_xlat16_11.x = u_xlat16_22.x * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat10_5.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.x = u_xlat10_3.x * u_xlat16_22.y;
					    u_xlat16_24.x = u_xlat10_14.x * u_xlat16_22.y;
					    u_xlat16_24.x = u_xlat16_4.x * u_xlat10_14.y + u_xlat16_24.x;
					    u_xlat16_24.x = u_xlat16_10.x * u_xlat10_14.z + u_xlat16_24.x;
					    u_xlat16_9.y = u_xlat16_24.x * u_xlat16_2.x + u_xlat16_0.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_3.y + u_xlat16_0.x;
					    u_xlat16_11.y = u_xlat16_10.x * u_xlat10_3.z + u_xlat16_0.x;
					    u_xlat16_0.xyz = u_xlat10_5.xyz + u_xlat16_11.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_9.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Back2TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.x = _Time.x * _Back2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					float u_xlat1;
					mediump float u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					vec4 u_xlat5;
					mediump vec2 u_xlat16_5;
					bvec2 u_xlatb6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					mediump vec2 u_xlat16_10;
					vec2 u_xlat11;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_11;
					bool u_xlatb11;
					mediump vec2 u_xlat16_13;
					vec2 u_xlat14;
					mediump vec3 u_xlat16_14;
					lowp vec3 u_xlat10_14;
					ivec2 u_xlati14;
					bvec2 u_xlatb14;
					mediump vec2 u_xlat16_18;
					mediump float u_xlat16_20;
					float u_xlat21;
					mediump float u_xlat16_21;
					bool u_xlatb21;
					mediump float u_xlat16_23;
					mediump float u_xlat16_30;
					bool u_xlatb31;
					mediump float u_xlat16_33;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_20 = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_20 = float(1.0) / u_xlat16_20;
					    u_xlat16_30 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_20 = u_xlat16_20 * u_xlat16_30;
					    u_xlat16_30 = u_xlat16_20 * u_xlat16_20;
					    u_xlat16_1 = u_xlat16_30 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1 = u_xlat16_30 * u_xlat16_1 + 0.180141002;
					    u_xlat16_1 = u_xlat16_30 * u_xlat16_1 + -0.330299497;
					    u_xlat16_1 = u_xlat16_30 * u_xlat16_1 + 0.999866009;
					    u_xlat16_11.x = u_xlat16_20 * u_xlat16_1;
					    u_xlat11.x = u_xlat16_11.x * -2.0 + 1.57079637;
					    u_xlatb21 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat11.x = u_xlatb21 ? u_xlat11.x : float(0.0);
					    u_xlat1 = u_xlat16_20 * u_xlat16_1 + u_xlat11.x;
					    u_xlatb11 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat11.x = u_xlatb11 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat11.x + u_xlat1;
					    u_xlat16_20 = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb11 = u_xlat16_20<(-u_xlat16_20);
					    u_xlat16_20 = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb21 = u_xlat16_20>=(-u_xlat16_20);
					    u_xlatb11 = u_xlatb21 && u_xlatb11;
					    u_xlat1 = (u_xlatb11) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_10.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_10.x;
					    u_xlat16_10.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_30 = max(abs(u_xlat16_10.y), abs(u_xlat16_10.x));
					    u_xlat16_30 = float(1.0) / u_xlat16_30;
					    u_xlat16_3.x = min(abs(u_xlat16_10.y), abs(u_xlat16_10.x));
					    u_xlat16_30 = u_xlat16_30 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_30 * u_xlat16_30;
					    u_xlat16_11.x = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_11.x = u_xlat16_3.x * u_xlat16_11.x + 0.180141002;
					    u_xlat16_11.x = u_xlat16_3.x * u_xlat16_11.x + -0.330299497;
					    u_xlat16_11.x = u_xlat16_3.x * u_xlat16_11.x + 0.999866009;
					    u_xlat16_21 = u_xlat16_30 * u_xlat16_11.x;
					    u_xlat21 = u_xlat16_21 * -2.0 + 1.57079637;
					    u_xlatb31 = abs(u_xlat16_10.y)<abs(u_xlat16_10.x);
					    u_xlat21 = u_xlatb31 ? u_xlat21 : float(0.0);
					    u_xlat11.x = u_xlat16_30 * u_xlat16_11.x + u_xlat21;
					    u_xlatb21 = u_xlat16_10.y<(-u_xlat16_10.y);
					    u_xlat21 = u_xlatb21 ? -3.14159274 : float(0.0);
					    u_xlat11.x = u_xlat21 + u_xlat11.x;
					    u_xlat16_30 = min(u_xlat16_10.y, u_xlat16_10.x);
					    u_xlatb21 = u_xlat16_30<(-u_xlat16_30);
					    u_xlat16_30 = max(u_xlat16_10.y, u_xlat16_10.x);
					    u_xlat16_10.x = dot(u_xlat16_10.xy, u_xlat16_10.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_10.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb31 = u_xlat16_30>=(-u_xlat16_30);
					    u_xlatb21 = u_xlatb31 && u_xlatb21;
					    u_xlat11.x = (u_xlatb21) ? (-u_xlat11.x) : u_xlat11.x;
					    u_xlat16_10.x = u_xlat11.x * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_10.x;
					    u_xlat10_11.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_11.xy = u_xlat10_11.xy + vec2(-0.5, -0.5);
					    u_xlat16_11.xy = u_xlat16_11.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_10.xy = u_xlat16_11.xy * u_xlat10_4.zz;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_10.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_11.xyz = texture2D(_Back1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_10.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_0.xw).xyz;
					    u_xlat16_3.xyz = u_xlat16_11.xyz * u_xlat10_4.yyy + u_xlat10_2.xyz;
					    u_xlat16_0.xw = u_xlat16_10.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_11.xyz = texture2D(_Back2Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Back2TexColor.xyz;
					    u_xlat16_3.xyz = u_xlat16_11.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_2 = vs_TEXCOORD1.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_0.xw = max(abs(u_xlat16_2.yw), abs(u_xlat16_2.xz));
					    u_xlat16_0.xw = vec2(1.0, 1.0) / u_xlat16_0.xw;
					    u_xlat16_5.xy = min(abs(u_xlat16_2.yw), abs(u_xlat16_2.xz));
					    u_xlat16_0.xw = u_xlat16_0.xw * u_xlat16_5.xy;
					    u_xlat16_5.xy = u_xlat16_0.xw * u_xlat16_0.xw;
					    u_xlat16_11.xy = u_xlat16_5.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_11.xy = u_xlat16_5.xy * u_xlat16_11.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_11.xy = u_xlat16_5.xy * u_xlat16_11.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_11.xy = u_xlat16_5.xy * u_xlat16_11.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_14.xy = u_xlat16_0.xw * u_xlat16_11.xy;
					    u_xlat14.xy = u_xlat16_14.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb6.xy = lessThan(abs(u_xlat16_2.ywyy), abs(u_xlat16_2.xzxx)).xy;
					    u_xlat14.xy = mix(vec2(0.0, 0.0), u_xlat14.xy, vec2(u_xlatb6.xy));
					    u_xlat11.xy = u_xlat16_0.xw * u_xlat16_11.xy + u_xlat14.xy;
					    u_xlatb14.xy = lessThan(u_xlat16_2.ywyy, (-u_xlat16_2.ywyy)).xy;
					    u_xlat14.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb14.xy));
					    u_xlat11.xy = u_xlat11.xy + u_xlat14.xy;
					    u_xlat16_0.xw = min(u_xlat16_2.yw, u_xlat16_2.xz);
					    u_xlatb14.xy = lessThan(u_xlat16_0.xwxx, (-u_xlat16_0.xwxx)).xy;
					    u_xlat16_0.xw = max(u_xlat16_2.yw, u_xlat16_2.xz);
					    u_xlatb6.xy = greaterThanEqual(u_xlat16_0.xwxx, (-u_xlat16_0.xwxx)).xy;
					    u_xlati14.xy = op_and((ivec2(u_xlatb14.xy) * -1), (ivec2(u_xlatb6.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat11;
					        hlslcc_movcTemp.x = (u_xlati14.x != 0) ? (-u_xlat11.x) : u_xlat11.x;
					        hlslcc_movcTemp.y = (u_xlati14.y != 0) ? (-u_xlat11.y) : u_xlat11.y;
					        u_xlat11 = hlslcc_movcTemp;
					    }
					    u_xlat16_0.xw = u_xlat11.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat5.xy = vec2(_Front1TexAnimeSpeed2, _Front2TexAnimeSpeed2) * vec2(u_xlat1) + u_xlat16_0.xw;
					    u_xlat16_0.x = dot(u_xlat16_2.xy, u_xlat16_2.xy);
					    u_xlat16_0.w = dot(u_xlat16_2.zw, u_xlat16_2.zw);
					    u_xlat16_0.xw = sqrt(u_xlat16_0.xw);
					    u_xlat16_0.xw = (-u_xlat16_0.xw) + vec2(1.0, 1.0);
					    u_xlat5.w = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_0.w;
					    u_xlat16_7.xy = u_xlat16_10.xy * vec2(_Front2TexDistotion) + u_xlat5.yw;
					    u_xlat10_11.xyz = texture2D(_Front2Tex, u_xlat16_7.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Front2TexColor.xyz;
					    u_xlat5.z = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_10.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat5.xz;
					    u_xlat10_14.xyz = texture2D(_Front1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_14.xyz = u_xlat10_14.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_14.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_4.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1 = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_30 = u_xlat16_2.x * 1.25 + u_xlat16_30;
					    u_xlat16_13.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_23 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_23 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_23;
					    u_xlat16_13.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_11.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_33 = u_xlat10_11.y * u_xlat16_13.x;
					    u_xlat16_33 = u_xlat16_30 * u_xlat10_11.x + u_xlat16_33;
					    u_xlat16_33 = u_xlat16_23 * u_xlat10_11.z + u_xlat16_33;
					    u_xlat16_7.z = u_xlat16_33 * u_xlat16_1 + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_33 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_33 = u_xlat16_2.z * 0.330000013 + u_xlat16_33;
					    u_xlat16_20 = u_xlat16_2.z * 0.167999998 + u_xlat16_20;
					    u_xlat16_37 = u_xlat10_11.y * u_xlat16_33;
					    u_xlat16_37 = u_xlat16_20 * u_xlat10_11.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_2.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_11.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_1 + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_11.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_11.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_8.x * u_xlat10_11.z + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_0.x * u_xlat16_1 + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_13.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_23 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_33;
					    u_xlat16_0.x = u_xlat16_20 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					Keywords { "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					float u_xlat2;
					float u_xlat3;
					vec3 u_xlat4;
					mediump vec2 u_xlat16_5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_11;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = _Time.xx * vec2(_Back1TexAnimeSpeed, _Back2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2 = sin(u_xlat0.y);
					    u_xlat3 = cos(u_xlat0.y);
					    u_xlat4.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat4.y = u_xlat1.x;
					    u_xlat4.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat4.zy, u_xlat16_5.xy);
					    u_xlat0.x = dot(u_xlat4.yx, u_xlat16_5.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2);
					    u_xlat0.y = u_xlat3;
					    u_xlat0.z = u_xlat2;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_5.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_5.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_5.xy);
					    vs_TEXCOORD2.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_5.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_5.x = dot(u_xlat16_5.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_11 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_5.x + u_xlat16_11;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump float u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec4 u_xlat16_3;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					vec4 u_xlat5;
					mediump vec2 u_xlat16_5;
					bvec2 u_xlatb6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					mediump float u_xlat16_10;
					vec2 u_xlat11;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_11;
					bool u_xlatb11;
					vec2 u_xlat12;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					ivec2 u_xlati12;
					bvec2 u_xlatb12;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump vec2 u_xlat16_20;
					bool u_xlatb21;
					mediump float u_xlat16_24;
					mediump float u_xlat16_30;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_20.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_20.x = float(1.0) / u_xlat16_20.x;
					    u_xlat16_30 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_20.x = u_xlat16_20.x * u_xlat16_30;
					    u_xlat16_30 = u_xlat16_20.x * u_xlat16_20.x;
					    u_xlat16_1 = u_xlat16_30 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1 = u_xlat16_30 * u_xlat16_1 + 0.180141002;
					    u_xlat16_1 = u_xlat16_30 * u_xlat16_1 + -0.330299497;
					    u_xlat16_1 = u_xlat16_30 * u_xlat16_1 + 0.999866009;
					    u_xlat16_11.x = u_xlat16_20.x * u_xlat16_1;
					    u_xlat11.x = u_xlat16_11.x * -2.0 + 1.57079637;
					    u_xlatb21 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat11.x = u_xlatb21 ? u_xlat11.x : float(0.0);
					    u_xlat1 = u_xlat16_20.x * u_xlat16_1 + u_xlat11.x;
					    u_xlatb11 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat11.x = u_xlatb11 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat11.x + u_xlat1;
					    u_xlat16_20.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb11 = u_xlat16_20.x<(-u_xlat16_20.x);
					    u_xlat16_20.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb21 = u_xlat16_20.x>=(-u_xlat16_20.x);
					    u_xlatb11 = u_xlatb21 && u_xlatb11;
					    u_xlat1 = (u_xlatb11) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_10 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_10;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_11.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_11.xy = u_xlat10_11.xy + vec2(-0.5, -0.5);
					    u_xlat16_11.xy = u_xlat16_11.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_11.xy * u_xlat10_2.zz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_11.xyz = texture2D(_Back1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Back1TexColor.xyz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_20.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_11.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_11.xyz = texture2D(_Back2Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_11.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_3 = vs_TEXCOORD1.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_20.xy = max(abs(u_xlat16_3.yw), abs(u_xlat16_3.xz));
					    u_xlat16_20.xy = vec2(1.0, 1.0) / u_xlat16_20.xy;
					    u_xlat16_5.xy = min(abs(u_xlat16_3.yw), abs(u_xlat16_3.xz));
					    u_xlat16_20.xy = u_xlat16_20.xy * u_xlat16_5.xy;
					    u_xlat16_5.xy = u_xlat16_20.xy * u_xlat16_20.xy;
					    u_xlat16_11.xy = u_xlat16_5.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_11.xy = u_xlat16_5.xy * u_xlat16_11.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_11.xy = u_xlat16_5.xy * u_xlat16_11.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_11.xy = u_xlat16_5.xy * u_xlat16_11.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_12.xy = u_xlat16_20.xy * u_xlat16_11.xy;
					    u_xlat12.xy = u_xlat16_12.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb6.xy = lessThan(abs(u_xlat16_3.ywyy), abs(u_xlat16_3.xzxx)).xy;
					    u_xlat12.xy = mix(vec2(0.0, 0.0), u_xlat12.xy, vec2(u_xlatb6.xy));
					    u_xlat11.xy = u_xlat16_20.xy * u_xlat16_11.xy + u_xlat12.xy;
					    u_xlatb12.xy = lessThan(u_xlat16_3.ywyy, (-u_xlat16_3.ywyy)).xy;
					    u_xlat12.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb12.xy));
					    u_xlat11.xy = u_xlat11.xy + u_xlat12.xy;
					    u_xlat16_20.xy = min(u_xlat16_3.yw, u_xlat16_3.xz);
					    u_xlatb12.xy = lessThan(u_xlat16_20.xyxx, (-u_xlat16_20.xyxx)).xy;
					    u_xlat16_20.xy = max(u_xlat16_3.yw, u_xlat16_3.xz);
					    u_xlatb6.xy = greaterThanEqual(u_xlat16_20.xyxx, (-u_xlat16_20.xyxx)).xy;
					    u_xlati12.xy = op_and((ivec2(u_xlatb12.xy) * -1), (ivec2(u_xlatb6.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat11;
					        hlslcc_movcTemp.x = (u_xlati12.x != 0) ? (-u_xlat11.x) : u_xlat11.x;
					        hlslcc_movcTemp.y = (u_xlati12.y != 0) ? (-u_xlat11.y) : u_xlat11.y;
					        u_xlat11 = hlslcc_movcTemp;
					    }
					    u_xlat16_20.xy = u_xlat11.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat5.xy = vec2(_Front1TexAnimeSpeed2, _Front2TexAnimeSpeed2) * vec2(u_xlat1) + u_xlat16_20.xy;
					    u_xlat16_20.x = dot(u_xlat16_3.xy, u_xlat16_3.xy);
					    u_xlat16_20.y = dot(u_xlat16_3.zw, u_xlat16_3.zw);
					    u_xlat16_20.xy = sqrt(u_xlat16_20.xy);
					    u_xlat16_20.xy = (-u_xlat16_20.xy) + vec2(1.0, 1.0);
					    u_xlat5.w = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_20.y;
					    u_xlat16_7.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + u_xlat5.yw;
					    u_xlat10_11.xyz = texture2D(_Front2Tex, u_xlat16_7.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Front2TexColor.xyz;
					    u_xlat5.z = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_20.x;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat5.xz;
					    u_xlat10_12.xyz = texture2D(_Front1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_2.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1 = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_2.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_24;
					    u_xlat16_14.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_11.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_11.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_11.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24 * u_xlat10_11.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_1 + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_2.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20.x = u_xlat16_2.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat16_37 = u_xlat10_11.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20.x * u_xlat10_11.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_2.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_11.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_1 + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_11.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_11.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_8.x * u_xlat10_11.z + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_0.x * u_xlat16_1 + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_DISTOTIONTEX_SCROLL" "_BACK1TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					Keywords { "_DISTOTIONTEX_SCROLL" "_BACK1TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					float u_xlat4;
					vec3 u_xlat5;
					vec2 u_xlat6;
					bool u_xlatb6;
					mediump float u_xlat16_9;
					float u_xlat12;
					vec2 u_xlat13;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat12 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat12) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.xy = _Time.xx * vec2(_Back1TexAnimeSpeed, _Back2TexAnimeSpeed);
					    u_xlat0.xy = fract(u_xlat0.xy);
					    u_xlat0.xy = u_xlat0.xy * vec2(6.28318548, 6.28318548);
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = sin(u_xlat0.y);
					    u_xlat4 = cos(u_xlat0.y);
					    u_xlat5.x = (-u_xlat0.x);
					    u_xlat6.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat6.xy + vec2(-0.5, -0.5);
					    u_xlat5.y = u_xlat1.x;
					    u_xlat5.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat5.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat5.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = (-u_xlat2.x);
					    u_xlat0.y = u_xlat4;
					    u_xlat0.z = u_xlat2.x;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat1.xy + vec2(-0.5, -0.5);
					    u_xlat13.x = dot(u_xlat0.yx, u_xlat16_3.xy);
					    u_xlat13.y = dot(u_xlat0.zy, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat13.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb6 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb6) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_9 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_9;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat6.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat6.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					float u_xlat0;
					mediump vec3 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					mediump vec4 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					mediump vec3 u_xlat16_2;
					vec2 u_xlat3;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					float u_xlat9;
					mediump float u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					bool u_xlatb18;
					mediump vec2 u_xlat16_20;
					mediump float u_xlat16_22;
					mediump float u_xlat16_29;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat10_0.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_0.xy = u_xlat10_0.xy + vec2(-0.5, -0.5);
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_1.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_2.xy = u_xlat16_0.xy * u_xlat10_1.zz;
					    u_xlat16_20.xy = u_xlat16_2.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_0.xyz = texture2D(_Back1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back1TexColor.xyz;
					    u_xlat16_20.xy = u_xlat16_2.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_20.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_0.xyz * u_xlat10_1.yyy + u_xlat10_3.xyz;
					    u_xlat16_20.xy = u_xlat16_2.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_0.xyz = texture2D(_Back2Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_0.xyz * u_xlat10_1.yyy + u_xlat16_4.xyz;
					    u_xlat16_20.xy = u_xlat16_2.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat10_0.xyz = texture2D(_Front1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Front1TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_0.xyz * u_xlat10_1.xxx + u_xlat16_4.xyz;
					    u_xlat16_20.xy = vs_TEXCOORD1.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_31 = max(abs(u_xlat16_20.y), abs(u_xlat16_20.x));
					    u_xlat16_31 = float(1.0) / u_xlat16_31;
					    u_xlat16_5.x = min(abs(u_xlat16_20.y), abs(u_xlat16_20.x));
					    u_xlat16_31 = u_xlat16_31 * u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_31 * u_xlat16_31;
					    u_xlat16_0.x = u_xlat16_5.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_0.x = u_xlat16_5.x * u_xlat16_0.x + 0.180141002;
					    u_xlat16_0.x = u_xlat16_5.x * u_xlat16_0.x + -0.330299497;
					    u_xlat16_0.x = u_xlat16_5.x * u_xlat16_0.x + 0.999866009;
					    u_xlat16_9 = u_xlat16_0.x * u_xlat16_31;
					    u_xlat9 = u_xlat16_9 * -2.0 + 1.57079637;
					    u_xlatb18 = abs(u_xlat16_20.y)<abs(u_xlat16_20.x);
					    u_xlat9 = u_xlatb18 ? u_xlat9 : float(0.0);
					    u_xlat0 = u_xlat16_31 * u_xlat16_0.x + u_xlat9;
					    u_xlatb9 = u_xlat16_20.y<(-u_xlat16_20.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat0 = u_xlat9 + u_xlat0;
					    u_xlat16_31 = min(u_xlat16_20.y, u_xlat16_20.x);
					    u_xlatb9 = u_xlat16_31<(-u_xlat16_31);
					    u_xlat16_31 = max(u_xlat16_20.y, u_xlat16_20.x);
					    u_xlat16_20.x = dot(u_xlat16_20.xy, u_xlat16_20.xy);
					    u_xlat16_20.x = sqrt(u_xlat16_20.x);
					    u_xlat16_20.x = (-u_xlat16_20.x) + 1.0;
					    u_xlatb18 = u_xlat16_31>=(-u_xlat16_31);
					    u_xlatb9 = u_xlatb18 && u_xlatb9;
					    u_xlat0 = (u_xlatb9) ? (-u_xlat0) : u_xlat0;
					    u_xlat16_29 = u_xlat0 * 0.159154937 + 0.75;
					    u_xlat0 = fract(_Time.x);
					    u_xlat3.x = _Front2TexAnimeSpeed2 * u_xlat0 + u_xlat16_29;
					    u_xlat3.y = _Front2TexAnimeSpeed * u_xlat0 + u_xlat16_20.x;
					    u_xlat16_2.xy = u_xlat16_2.xy * vec2(_Front2TexDistotion) + u_xlat3.xy;
					    u_xlat10_0.xyz = texture2D(_Front2Tex, u_xlat16_2.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Front2TexColor.xyz;
					    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat10_1.xxx + u_xlat16_4.xyz;
					    u_xlat10_0.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_2.xyz) + u_xlat10_0.xyz;
					    u_xlat10_0.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_2.xyz = u_xlat10_0.xxx * u_xlat16_4.xyz + u_xlat16_2.xyz;
					    u_xlat10_0.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_29 = (-u_xlat10_0.x) * _IsKira + 1.0;
					    u_xlat16_0.x = u_xlat10_0.x * _IsKira;
					    u_xlat16_2.xyz = vec3(u_xlat16_29) * u_xlat16_2.xyz;
					    u_xlat16_29 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_29) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_29 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_29 = u_xlat16_1.x * 1.25 + u_xlat16_29;
					    u_xlat16_13.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_9.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_29 * u_xlat10_9.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_9.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_0.x + u_xlat16_2.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_1.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_20.x = u_xlat16_1.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_9.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_20.x * u_xlat10_9.x + u_xlat16_31;
					    u_xlat16_20.x = u_xlat16_20.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_1.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_20.x;
					    u_xlat16_20.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_20.x = u_xlat16_29 * u_xlat10_7.x + u_xlat16_20.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_20.x;
					    u_xlat16_20.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_20.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_20.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_20.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_20.x = u_xlat16_15.x * u_xlat10_9.z + u_xlat16_31;
					    u_xlat16_29 = u_xlat10_9.x * u_xlat16_15.y;
					    u_xlat16_29 = u_xlat16_4.x * u_xlat10_9.y + u_xlat16_29;
					    u_xlat16_29 = u_xlat16_32 * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.y = u_xlat16_29 * u_xlat16_0.x + u_xlat16_2.y;
					    u_xlat16_5.x = u_xlat16_20.x * u_xlat16_0.x + u_xlat16_2.x;
					    u_xlat16_2.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_2.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					float u_xlat9;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat9 = fract(_Time.x);
					    u_xlat0.zw = vec2(_DistotionTexAnimeSpeed, _DistotionTexAnimeSpeed2) * vec2(u_xlat9) + u_xlat1.xy;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat0.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * vec2(u_xlat9) + u_xlat0.xy;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					float u_xlat0;
					mediump vec3 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					mediump vec4 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					mediump vec3 u_xlat16_2;
					vec2 u_xlat3;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					lowp vec3 u_xlat10_7;
					mediump vec3 u_xlat16_8;
					float u_xlat9;
					mediump float u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_13;
					mediump vec2 u_xlat16_15;
					bool u_xlatb18;
					mediump vec2 u_xlat16_20;
					mediump float u_xlat16_22;
					mediump float u_xlat16_29;
					mediump float u_xlat16_31;
					mediump float u_xlat16_32;
					void main()
					{
					    u_xlat10_0.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_0.xy = u_xlat10_0.xy + vec2(-0.5, -0.5);
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_1.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_2.xy = u_xlat16_0.xy * u_xlat10_1.zz;
					    u_xlat16_20.xy = u_xlat16_2.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_0.xyz = texture2D(_Back1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back1TexColor.xyz;
					    u_xlat16_20.xy = u_xlat16_2.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_20.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_0.xyz * u_xlat10_1.yyy + u_xlat10_3.xyz;
					    u_xlat16_20.xy = u_xlat16_2.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_0.xyz = texture2D(_Back2Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_0.xyz * u_xlat10_1.yyy + u_xlat16_4.xyz;
					    u_xlat16_20.xy = u_xlat16_2.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat10_0.xyz = texture2D(_Front1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Front1TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_0.xyz * u_xlat10_1.xxx + u_xlat16_4.xyz;
					    u_xlat16_20.xy = vs_TEXCOORD1.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_31 = max(abs(u_xlat16_20.y), abs(u_xlat16_20.x));
					    u_xlat16_31 = float(1.0) / u_xlat16_31;
					    u_xlat16_5.x = min(abs(u_xlat16_20.y), abs(u_xlat16_20.x));
					    u_xlat16_31 = u_xlat16_31 * u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_31 * u_xlat16_31;
					    u_xlat16_0.x = u_xlat16_5.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_0.x = u_xlat16_5.x * u_xlat16_0.x + 0.180141002;
					    u_xlat16_0.x = u_xlat16_5.x * u_xlat16_0.x + -0.330299497;
					    u_xlat16_0.x = u_xlat16_5.x * u_xlat16_0.x + 0.999866009;
					    u_xlat16_9 = u_xlat16_0.x * u_xlat16_31;
					    u_xlat9 = u_xlat16_9 * -2.0 + 1.57079637;
					    u_xlatb18 = abs(u_xlat16_20.y)<abs(u_xlat16_20.x);
					    u_xlat9 = u_xlatb18 ? u_xlat9 : float(0.0);
					    u_xlat0 = u_xlat16_31 * u_xlat16_0.x + u_xlat9;
					    u_xlatb9 = u_xlat16_20.y<(-u_xlat16_20.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat0 = u_xlat9 + u_xlat0;
					    u_xlat16_31 = min(u_xlat16_20.y, u_xlat16_20.x);
					    u_xlatb9 = u_xlat16_31<(-u_xlat16_31);
					    u_xlat16_31 = max(u_xlat16_20.y, u_xlat16_20.x);
					    u_xlat16_20.x = dot(u_xlat16_20.xy, u_xlat16_20.xy);
					    u_xlat16_20.x = sqrt(u_xlat16_20.x);
					    u_xlat16_20.x = (-u_xlat16_20.x) + 1.0;
					    u_xlatb18 = u_xlat16_31>=(-u_xlat16_31);
					    u_xlatb9 = u_xlatb18 && u_xlatb9;
					    u_xlat0 = (u_xlatb9) ? (-u_xlat0) : u_xlat0;
					    u_xlat16_29 = u_xlat0 * 0.159154937 + 0.75;
					    u_xlat0 = fract(_Time.x);
					    u_xlat3.x = _Front2TexAnimeSpeed2 * u_xlat0 + u_xlat16_29;
					    u_xlat3.y = _Front2TexAnimeSpeed * u_xlat0 + u_xlat16_20.x;
					    u_xlat16_2.xy = u_xlat16_2.xy * vec2(_Front2TexDistotion) + u_xlat3.xy;
					    u_xlat10_0.xyz = texture2D(_Front2Tex, u_xlat16_2.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_0.xyz * _Front2TexColor.xyz;
					    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat10_1.xxx + u_xlat16_4.xyz;
					    u_xlat10_0.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_2.xyz) + u_xlat10_0.xyz;
					    u_xlat10_0.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_2.xyz = u_xlat10_0.xxx * u_xlat16_4.xyz + u_xlat16_2.xyz;
					    u_xlat10_0.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_29 = (-u_xlat10_0.x) * _IsKira + 1.0;
					    u_xlat16_0.x = u_xlat10_0.x * _IsKira;
					    u_xlat16_2.xyz = vec3(u_xlat16_29) * u_xlat16_2.xyz;
					    u_xlat16_29 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_1 = vec4(u_xlat16_29) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_1.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_29 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_29 = u_xlat16_1.x * 1.25 + u_xlat16_29;
					    u_xlat16_13.xy = u_xlat16_1.yw * vec2(0.588, 0.885999978);
					    u_xlat16_13.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_13.x);
					    u_xlat16_22 = vs_TEXCOORD5.z * 0.114 + u_xlat16_13.y;
					    u_xlat16_22 = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_22;
					    u_xlat16_13.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_13.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_31 = u_xlat10_9.y * u_xlat16_13.x;
					    u_xlat16_31 = u_xlat16_29 * u_xlat10_9.x + u_xlat16_31;
					    u_xlat16_31 = u_xlat16_22 * u_xlat10_9.z + u_xlat16_31;
					    u_xlat16_5.z = u_xlat16_31 * u_xlat16_0.x + u_xlat16_2.z;
					    u_xlat10_3.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_6.xy = u_xlat16_1.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_31 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_31 = u_xlat16_1.z * 0.330000013 + u_xlat16_31;
					    u_xlat16_20.x = u_xlat16_1.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat10_7.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_32 = u_xlat16_31 * u_xlat10_7.y;
					    u_xlat16_31 = u_xlat10_9.y * u_xlat16_31;
					    u_xlat16_31 = u_xlat16_20.x * u_xlat10_9.x + u_xlat16_31;
					    u_xlat16_20.x = u_xlat16_20.x * u_xlat10_7.x + u_xlat16_32;
					    u_xlat16_6.xy = u_xlat16_1.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_15.xy = (-u_xlat16_1.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_32 = u_xlat16_1.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_8.x = u_xlat16_15.x * u_xlat10_7.z + u_xlat16_20.x;
					    u_xlat16_20.x = u_xlat16_13.x * u_xlat10_7.y;
					    u_xlat16_20.x = u_xlat16_29 * u_xlat10_7.x + u_xlat16_20.x;
					    u_xlat16_8.z = u_xlat16_22 * u_xlat10_7.z + u_xlat16_20.x;
					    u_xlat16_20.x = u_xlat10_7.x * u_xlat16_15.y;
					    u_xlat16_20.x = u_xlat16_4.x * u_xlat10_7.y + u_xlat16_20.x;
					    u_xlat16_8.y = u_xlat16_32 * u_xlat10_7.z + u_xlat16_20.x;
					    u_xlat16_8.xyz = u_xlat10_3.xyz + u_xlat16_8.xyz;
					    u_xlat16_20.x = u_xlat16_15.x * u_xlat10_9.z + u_xlat16_31;
					    u_xlat16_29 = u_xlat10_9.x * u_xlat16_15.y;
					    u_xlat16_29 = u_xlat16_4.x * u_xlat10_9.y + u_xlat16_29;
					    u_xlat16_29 = u_xlat16_32 * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.y = u_xlat16_29 * u_xlat16_0.x + u_xlat16_2.y;
					    u_xlat16_5.x = u_xlat16_20.x * u_xlat16_0.x + u_xlat16_2.x;
					    u_xlat16_2.xyz = u_xlat16_8.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_2.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					Keywords { "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat8.x = fract(_Time.x);
					    u_xlat0.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * u_xlat8.xx + u_xlat0.xy;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					vec2 u_xlat3;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					mediump vec3 u_xlat16_7;
					mediump float u_xlat16_8;
					float u_xlat9;
					mediump vec3 u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_16;
					float u_xlat17;
					mediump float u_xlat16_17;
					bool u_xlatb17;
					mediump float u_xlat16_20;
					mediump float u_xlat16_24;
					bool u_xlatb25;
					mediump float u_xlat16_28;
					mediump float u_xlat16_29;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_16.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = float(1.0) / u_xlat16_16.x;
					    u_xlat16_24 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = u_xlat16_16.x * u_xlat16_24;
					    u_xlat16_24 = u_xlat16_16.x * u_xlat16_16.x;
					    u_xlat16_1.x = u_xlat16_24 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_9.x = u_xlat16_16.x * u_xlat16_1.x;
					    u_xlat9 = u_xlat16_9.x * -2.0 + 1.57079637;
					    u_xlatb17 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat9 = u_xlatb17 ? u_xlat9 : float(0.0);
					    u_xlat1 = u_xlat16_16.x * u_xlat16_1.x + u_xlat9;
					    u_xlatb9 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat9 + u_xlat1;
					    u_xlat16_16.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb9 = u_xlat16_16.x<(-u_xlat16_16.x);
					    u_xlat16_16.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb17 = u_xlat16_16.x>=(-u_xlat16_16.x);
					    u_xlatb9 = u_xlatb17 && u_xlatb9;
					    u_xlat1 = (u_xlatb9) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_8 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_8;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_9.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_9.xy = u_xlat10_9.xy + vec2(-0.5, -0.5);
					    u_xlat16_9.xy = u_xlat16_9.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_9.xy * u_xlat10_2.zz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_9.xyz = texture2D(_Back1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back1TexColor.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_16.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_9.xyz = texture2D(_Back2Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat10_9.xyz = texture2D(_Front1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Front1TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_16.xy = vs_TEXCOORD1.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_28 = max(abs(u_xlat16_16.y), abs(u_xlat16_16.x));
					    u_xlat16_28 = float(1.0) / u_xlat16_28;
					    u_xlat16_5.x = min(abs(u_xlat16_16.y), abs(u_xlat16_16.x));
					    u_xlat16_28 = u_xlat16_28 * u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_28 * u_xlat16_28;
					    u_xlat16_9.x = u_xlat16_5.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.180141002;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + -0.330299497;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.999866009;
					    u_xlat16_17 = u_xlat16_9.x * u_xlat16_28;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_16.y)<abs(u_xlat16_16.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_28 * u_xlat16_9.x + u_xlat17;
					    u_xlatb17 = u_xlat16_16.y<(-u_xlat16_16.y);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_28 = min(u_xlat16_16.y, u_xlat16_16.x);
					    u_xlatb17 = u_xlat16_28<(-u_xlat16_28);
					    u_xlat16_28 = max(u_xlat16_16.y, u_xlat16_16.x);
					    u_xlat16_16.x = dot(u_xlat16_16.xy, u_xlat16_16.xy);
					    u_xlat16_16.x = sqrt(u_xlat16_16.x);
					    u_xlat16_16.x = (-u_xlat16_16.x) + 1.0;
					    u_xlat3.y = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_16.x;
					    u_xlatb25 = u_xlat16_28>=(-u_xlat16_28);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_16.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat3.x = _Front2TexAnimeSpeed2 * u_xlat1 + u_xlat16_16.x;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + u_xlat3.xy;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_24 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_24) * u_xlat16_0.xyz;
					    u_xlat16_24 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_24) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_24 = u_xlat16_2.x * 1.25 + u_xlat16_24;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_20 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_20;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_28 = u_xlat10_9.y * u_xlat16_12.x;
					    u_xlat16_28 = u_xlat16_24 * u_xlat10_9.x + u_xlat16_28;
					    u_xlat16_28 = u_xlat16_20 * u_xlat10_9.z + u_xlat16_28;
					    u_xlat16_5.z = u_xlat16_28 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_16.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_28 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_28 = u_xlat16_2.z * 0.330000013 + u_xlat16_28;
					    u_xlat16_16.x = u_xlat16_2.z * 0.167999998 + u_xlat16_16.x;
					    u_xlat16_29 = u_xlat10_9.y * u_xlat16_28;
					    u_xlat16_29 = u_xlat16_16.x * u_xlat10_9.x + u_xlat16_29;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_14.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_6.x = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_29 = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.x = u_xlat16_29 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_9.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_6.x * u_xlat10_9.z + u_xlat16_0.x;
					    u_xlat16_5.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_24 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.z = u_xlat16_20 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_28;
					    u_xlat16_0.x = u_xlat16_16.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.x = u_xlat16_14.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_6.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_7.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					float u_xlat8;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat8 = fract(_Time.x);
					    u_xlat0.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat8) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					float u_xlat9;
					mediump vec3 u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_11;
					mediump vec2 u_xlat16_14;
					mediump float u_xlat16_16;
					float u_xlat17;
					mediump float u_xlat16_17;
					bool u_xlatb17;
					mediump float u_xlat16_19;
					mediump float u_xlat16_24;
					bool u_xlatb25;
					mediump float u_xlat16_27;
					mediump float u_xlat16_29;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_16 = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16 = float(1.0) / u_xlat16_16;
					    u_xlat16_24 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16 = u_xlat16_16 * u_xlat16_24;
					    u_xlat16_24 = u_xlat16_16 * u_xlat16_16;
					    u_xlat16_1.x = u_xlat16_24 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_9.x = u_xlat16_16 * u_xlat16_1.x;
					    u_xlat9 = u_xlat16_9.x * -2.0 + 1.57079637;
					    u_xlatb17 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat9 = u_xlatb17 ? u_xlat9 : float(0.0);
					    u_xlat1 = u_xlat16_16 * u_xlat16_1.x + u_xlat9;
					    u_xlatb9 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat9 + u_xlat1;
					    u_xlat16_16 = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb9 = u_xlat16_16<(-u_xlat16_16);
					    u_xlat16_16 = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb17 = u_xlat16_16>=(-u_xlat16_16);
					    u_xlatb9 = u_xlatb17 && u_xlatb9;
					    u_xlat1 = (u_xlatb9) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_8.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_8.x;
					    u_xlat16_8.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_24 = max(abs(u_xlat16_8.y), abs(u_xlat16_8.x));
					    u_xlat16_24 = float(1.0) / u_xlat16_24;
					    u_xlat16_3.x = min(abs(u_xlat16_8.y), abs(u_xlat16_8.x));
					    u_xlat16_24 = u_xlat16_24 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_24 * u_xlat16_24;
					    u_xlat16_9.x = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9.x = u_xlat16_3.x * u_xlat16_9.x + 0.180141002;
					    u_xlat16_9.x = u_xlat16_3.x * u_xlat16_9.x + -0.330299497;
					    u_xlat16_9.x = u_xlat16_3.x * u_xlat16_9.x + 0.999866009;
					    u_xlat16_17 = u_xlat16_24 * u_xlat16_9.x;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_8.y)<abs(u_xlat16_8.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_24 * u_xlat16_9.x + u_xlat17;
					    u_xlatb17 = u_xlat16_8.y<(-u_xlat16_8.y);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_24 = min(u_xlat16_8.y, u_xlat16_8.x);
					    u_xlatb17 = u_xlat16_24<(-u_xlat16_24);
					    u_xlat16_24 = max(u_xlat16_8.y, u_xlat16_8.x);
					    u_xlat16_8.x = dot(u_xlat16_8.xy, u_xlat16_8.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_8.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb25 = u_xlat16_24>=(-u_xlat16_24);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_8.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_8.x;
					    u_xlat10_9.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_9.xy = u_xlat10_9.xy + vec2(-0.5, -0.5);
					    u_xlat16_9.xy = u_xlat16_9.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_8.xy = u_xlat16_9.xy * u_xlat10_4.zz;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_9.xyz = texture2D(_Back1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_0.xw).xyz;
					    u_xlat16_3.xyz = u_xlat16_9.xyz * u_xlat10_4.yyy + u_xlat10_2.xyz;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_9.xyz = texture2D(_Back2Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back2TexColor.xyz;
					    u_xlat16_3.xyz = u_xlat16_9.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat10_9.xyz = texture2D(_Front1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Front1TexColor.xyz;
					    u_xlat16_3.xyz = u_xlat16_9.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xw = vs_TEXCOORD1.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_5.x = min(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_9.x = u_xlat16_5.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.180141002;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + -0.330299497;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.999866009;
					    u_xlat16_17 = u_xlat16_9.x * u_xlat16_27;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_0.w)<abs(u_xlat16_0.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_27 * u_xlat16_9.x + u_xlat17;
					    u_xlatb17 = u_xlat16_0.w<(-u_xlat16_0.w);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_27 = min(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlatb17 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xw, u_xlat16_0.xw);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlat2.y = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlatb25 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_0.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat2.x = _Front2TexAnimeSpeed2 * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_8.xy * vec2(_Front2TexDistotion) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_24 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_24) * u_xlat16_0.xyz;
					    u_xlat16_24 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_24) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_24 = u_xlat16_2.x * 1.25 + u_xlat16_24;
					    u_xlat16_11.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_11.x);
					    u_xlat16_19 = vs_TEXCOORD5.z * 0.114 + u_xlat16_11.y;
					    u_xlat16_19 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_19;
					    u_xlat16_11.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_11.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_27 = u_xlat10_9.y * u_xlat16_11.x;
					    u_xlat16_27 = u_xlat16_24 * u_xlat10_9.x + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_19 * u_xlat10_9.z + u_xlat16_27;
					    u_xlat16_5.z = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_16 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_27 = u_xlat16_2.z * 0.330000013 + u_xlat16_27;
					    u_xlat16_16 = u_xlat16_2.z * 0.167999998 + u_xlat16_16;
					    u_xlat16_29 = u_xlat10_9.y * u_xlat16_27;
					    u_xlat16_29 = u_xlat16_16 * u_xlat10_9.x + u_xlat16_29;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_14.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_6.x = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_29 = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.x = u_xlat16_29 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_9.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_6.x * u_xlat10_9.z + u_xlat16_0.x;
					    u_xlat16_5.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_11.x;
					    u_xlat16_0.x = u_xlat16_24 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.z = u_xlat16_19 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_27;
					    u_xlat16_0.x = u_xlat16_16 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.x = u_xlat16_14.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_6.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_7.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_5;
					float u_xlat7;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat7 = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat1.xy;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat0.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat7) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2 = u_xlat0;
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
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_2 + u_xlat16_5;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec4 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					vec2 u_xlat4;
					lowp vec3 u_xlat10_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					float u_xlat9;
					mediump vec3 u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_11;
					mediump vec2 u_xlat16_14;
					mediump float u_xlat16_16;
					float u_xlat17;
					mediump float u_xlat16_17;
					bool u_xlatb17;
					mediump float u_xlat16_19;
					mediump float u_xlat16_24;
					bool u_xlatb25;
					mediump float u_xlat16_27;
					mediump float u_xlat16_29;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_16 = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16 = float(1.0) / u_xlat16_16;
					    u_xlat16_24 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16 = u_xlat16_16 * u_xlat16_24;
					    u_xlat16_24 = u_xlat16_16 * u_xlat16_16;
					    u_xlat16_1.x = u_xlat16_24 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_9.x = u_xlat16_16 * u_xlat16_1.x;
					    u_xlat9 = u_xlat16_9.x * -2.0 + 1.57079637;
					    u_xlatb17 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat9 = u_xlatb17 ? u_xlat9 : float(0.0);
					    u_xlat1 = u_xlat16_16 * u_xlat16_1.x + u_xlat9;
					    u_xlatb9 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat9 + u_xlat1;
					    u_xlat16_16 = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb9 = u_xlat16_16<(-u_xlat16_16);
					    u_xlat16_16 = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlatb17 = u_xlat16_16>=(-u_xlat16_16);
					    u_xlatb9 = u_xlatb17 && u_xlatb9;
					    u_xlat1 = (u_xlatb9) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_8.x = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_8.x;
					    u_xlat16_8.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_24 = max(abs(u_xlat16_8.y), abs(u_xlat16_8.x));
					    u_xlat16_24 = float(1.0) / u_xlat16_24;
					    u_xlat16_3.x = min(abs(u_xlat16_8.y), abs(u_xlat16_8.x));
					    u_xlat16_24 = u_xlat16_24 * u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_24 * u_xlat16_24;
					    u_xlat16_9.x = u_xlat16_3.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9.x = u_xlat16_3.x * u_xlat16_9.x + 0.180141002;
					    u_xlat16_9.x = u_xlat16_3.x * u_xlat16_9.x + -0.330299497;
					    u_xlat16_9.x = u_xlat16_3.x * u_xlat16_9.x + 0.999866009;
					    u_xlat16_17 = u_xlat16_24 * u_xlat16_9.x;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_8.y)<abs(u_xlat16_8.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_24 * u_xlat16_9.x + u_xlat17;
					    u_xlatb17 = u_xlat16_8.y<(-u_xlat16_8.y);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_24 = min(u_xlat16_8.y, u_xlat16_8.x);
					    u_xlatb17 = u_xlat16_24<(-u_xlat16_24);
					    u_xlat16_24 = max(u_xlat16_8.y, u_xlat16_8.x);
					    u_xlat16_8.x = dot(u_xlat16_8.xy, u_xlat16_8.xy);
					    u_xlat16_0.y = sqrt(u_xlat16_8.x);
					    u_xlat16_0.xy = (-u_xlat16_0.xy) + vec2(1.0, 1.0);
					    u_xlat4.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.y;
					    u_xlatb25 = u_xlat16_24>=(-u_xlat16_24);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_8.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat4.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_8.x;
					    u_xlat10_9.xy = texture2D(_DistotionTex, u_xlat4.xy).xy;
					    u_xlat16_9.xy = u_xlat10_9.xy + vec2(-0.5, -0.5);
					    u_xlat16_9.xy = u_xlat16_9.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_4.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_8.xy = u_xlat16_9.xy * u_xlat10_4.zz;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_9.xyz = texture2D(_Back1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back1TexColor.xyz;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_0.xw).xyz;
					    u_xlat16_3.xyz = u_xlat16_9.xyz * u_xlat10_4.yyy + u_xlat10_2.xyz;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_9.xyz = texture2D(_Back2Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back2TexColor.xyz;
					    u_xlat16_3.xyz = u_xlat16_9.xyz * u_xlat10_4.yyy + u_xlat16_3.xyz;
					    u_xlat16_0.xw = u_xlat16_8.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat10_9.xyz = texture2D(_Front1Tex, u_xlat16_0.xw).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Front1TexColor.xyz;
					    u_xlat16_3.xyz = u_xlat16_9.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat16_0.xw = vs_TEXCOORD1.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_27 = max(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_27 = float(1.0) / u_xlat16_27;
					    u_xlat16_5.x = min(abs(u_xlat16_0.w), abs(u_xlat16_0.x));
					    u_xlat16_27 = u_xlat16_27 * u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_27 * u_xlat16_27;
					    u_xlat16_9.x = u_xlat16_5.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.180141002;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + -0.330299497;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.999866009;
					    u_xlat16_17 = u_xlat16_9.x * u_xlat16_27;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_0.w)<abs(u_xlat16_0.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_27 * u_xlat16_9.x + u_xlat17;
					    u_xlatb17 = u_xlat16_0.w<(-u_xlat16_0.w);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_27 = min(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlatb17 = u_xlat16_27<(-u_xlat16_27);
					    u_xlat16_27 = max(u_xlat16_0.w, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xw, u_xlat16_0.xw);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlat2.y = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlatb25 = u_xlat16_27>=(-u_xlat16_27);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_0.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat2.x = _Front2TexAnimeSpeed2 * u_xlat1 + u_xlat16_0.x;
					    u_xlat16_0.xy = u_xlat16_8.xy * vec2(_Front2TexDistotion) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_4.xxx + u_xlat16_3.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_3.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_3.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_24 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_24) * u_xlat16_0.xyz;
					    u_xlat16_24 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_24) * vs_TEXCOORD5.yxyx;
					    u_xlat16_3.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_3.y);
					    u_xlat16_3.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_3.x;
					    u_xlat16_3.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_3.x;
					    u_xlat16_24 = u_xlat16_2.x * 1.25 + u_xlat16_24;
					    u_xlat16_11.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_11.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_11.x);
					    u_xlat16_19 = vs_TEXCOORD5.z * 0.114 + u_xlat16_11.y;
					    u_xlat16_19 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_19;
					    u_xlat16_11.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_11.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_27 = u_xlat10_9.y * u_xlat16_11.x;
					    u_xlat16_27 = u_xlat16_24 * u_xlat10_9.x + u_xlat16_27;
					    u_xlat16_27 = u_xlat16_19 * u_xlat10_9.z + u_xlat16_27;
					    u_xlat16_5.z = u_xlat16_27 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_16 = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_27 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_27 = u_xlat16_2.z * 0.330000013 + u_xlat16_27;
					    u_xlat16_16 = u_xlat16_2.z * 0.167999998 + u_xlat16_16;
					    u_xlat16_29 = u_xlat10_9.y * u_xlat16_27;
					    u_xlat16_29 = u_xlat16_16 * u_xlat10_9.x + u_xlat16_29;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_14.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_6.x = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_29 = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.x = u_xlat16_29 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_9.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_6.x * u_xlat10_9.z + u_xlat16_0.x;
					    u_xlat16_5.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_11.x;
					    u_xlat16_0.x = u_xlat16_24 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.z = u_xlat16_19 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_27;
					    u_xlat16_0.x = u_xlat16_16 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.x = u_xlat16_14.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_3.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_6.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_7.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					Keywords { "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					float u_xlat9;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    u_xlat1.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat9 = fract(_Time.x);
					    u_xlat0.xy = vec2(_Front1TexAnimeSpeed, _Front1TexAnimeSpeed2) * vec2(u_xlat9) + u_xlat1.xy;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat0.xy = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat9) + u_xlat0.xy;
					    vs_TEXCOORD2.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					vec2 u_xlat3;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					mediump vec3 u_xlat16_7;
					mediump float u_xlat16_8;
					float u_xlat9;
					mediump vec3 u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_16;
					float u_xlat17;
					mediump float u_xlat16_17;
					bool u_xlatb17;
					mediump float u_xlat16_20;
					mediump float u_xlat16_24;
					bool u_xlatb25;
					mediump float u_xlat16_28;
					mediump float u_xlat16_29;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_16.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = float(1.0) / u_xlat16_16.x;
					    u_xlat16_24 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = u_xlat16_16.x * u_xlat16_24;
					    u_xlat16_24 = u_xlat16_16.x * u_xlat16_16.x;
					    u_xlat16_1.x = u_xlat16_24 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_9.x = u_xlat16_16.x * u_xlat16_1.x;
					    u_xlat9 = u_xlat16_9.x * -2.0 + 1.57079637;
					    u_xlatb17 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat9 = u_xlatb17 ? u_xlat9 : float(0.0);
					    u_xlat1 = u_xlat16_16.x * u_xlat16_1.x + u_xlat9;
					    u_xlatb9 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat9 + u_xlat1;
					    u_xlat16_16.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb9 = u_xlat16_16.x<(-u_xlat16_16.x);
					    u_xlat16_16.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb17 = u_xlat16_16.x>=(-u_xlat16_16.x);
					    u_xlatb9 = u_xlatb17 && u_xlatb9;
					    u_xlat1 = (u_xlatb9) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_8 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_8;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_9.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_9.xy = u_xlat10_9.xy + vec2(-0.5, -0.5);
					    u_xlat16_9.xy = u_xlat16_9.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_9.xy * u_xlat10_2.zz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_9.xyz = texture2D(_Back1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back1TexColor.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_16.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_9.xyz = texture2D(_Back2Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat10_9.xyz = texture2D(_Front1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Front1TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_16.xy = vs_TEXCOORD1.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_28 = max(abs(u_xlat16_16.y), abs(u_xlat16_16.x));
					    u_xlat16_28 = float(1.0) / u_xlat16_28;
					    u_xlat16_5.x = min(abs(u_xlat16_16.y), abs(u_xlat16_16.x));
					    u_xlat16_28 = u_xlat16_28 * u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_28 * u_xlat16_28;
					    u_xlat16_9.x = u_xlat16_5.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.180141002;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + -0.330299497;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.999866009;
					    u_xlat16_17 = u_xlat16_9.x * u_xlat16_28;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_16.y)<abs(u_xlat16_16.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_28 * u_xlat16_9.x + u_xlat17;
					    u_xlatb17 = u_xlat16_16.y<(-u_xlat16_16.y);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_28 = min(u_xlat16_16.y, u_xlat16_16.x);
					    u_xlatb17 = u_xlat16_28<(-u_xlat16_28);
					    u_xlat16_28 = max(u_xlat16_16.y, u_xlat16_16.x);
					    u_xlat16_16.x = dot(u_xlat16_16.xy, u_xlat16_16.xy);
					    u_xlat16_16.x = sqrt(u_xlat16_16.x);
					    u_xlat16_16.x = (-u_xlat16_16.x) + 1.0;
					    u_xlat3.y = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_16.x;
					    u_xlatb25 = u_xlat16_28>=(-u_xlat16_28);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_16.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat3.x = _Front2TexAnimeSpeed2 * u_xlat1 + u_xlat16_16.x;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + u_xlat3.xy;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_24 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_24) * u_xlat16_0.xyz;
					    u_xlat16_24 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_24) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_24 = u_xlat16_2.x * 1.25 + u_xlat16_24;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_20 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_20;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_28 = u_xlat10_9.y * u_xlat16_12.x;
					    u_xlat16_28 = u_xlat16_24 * u_xlat10_9.x + u_xlat16_28;
					    u_xlat16_28 = u_xlat16_20 * u_xlat10_9.z + u_xlat16_28;
					    u_xlat16_5.z = u_xlat16_28 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_16.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_28 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_28 = u_xlat16_2.z * 0.330000013 + u_xlat16_28;
					    u_xlat16_16.x = u_xlat16_2.z * 0.167999998 + u_xlat16_16.x;
					    u_xlat16_29 = u_xlat10_9.y * u_xlat16_28;
					    u_xlat16_29 = u_xlat16_16.x * u_xlat10_9.x + u_xlat16_29;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_14.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_6.x = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_29 = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.x = u_xlat16_29 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_9.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_6.x * u_xlat10_9.z + u_xlat16_0.x;
					    u_xlat16_5.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_24 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.z = u_xlat16_20 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_28;
					    u_xlat16_0.x = u_xlat16_16.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.x = u_xlat16_14.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_6.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_7.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					Keywords { "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed2;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					mediump float u_xlat16_2;
					float u_xlat3;
					bool u_xlatb3;
					mediump float u_xlat16_5;
					float u_xlat6;
					void main()
					{
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    phase0_Output0_0 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat0.zw = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1 = u_xlat0;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    u_xlat6 = fract(_Time.x);
					    u_xlat1.xy = vec2(_Back1TexAnimeSpeed, _Back1TexAnimeSpeed2) * vec2(u_xlat6) + u_xlat0.xy;
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat1.zw = vec2(_Back2TexAnimeSpeed, _Back2TexAnimeSpeed2) * vec2(u_xlat6) + u_xlat0.xy;
					    vs_TEXCOORD2 = u_xlat1;
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
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_2 + u_xlat16_5;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat3 = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat3);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
					    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_0.xy;
					vs_TEXCOORD3 = phase0_Output0_0.zw;
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
					uniform 	vec4 _Time;
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Front1TexAnimeSpeed2;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump float u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					mediump vec4 u_xlat16_3;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					vec4 u_xlat5;
					mediump vec2 u_xlat16_5;
					bvec2 u_xlatb6;
					mediump vec3 u_xlat16_7;
					mediump vec2 u_xlat16_8;
					mediump vec3 u_xlat16_9;
					mediump float u_xlat16_10;
					vec2 u_xlat11;
					mediump vec3 u_xlat16_11;
					lowp vec3 u_xlat10_11;
					bool u_xlatb11;
					vec2 u_xlat12;
					mediump vec3 u_xlat16_12;
					lowp vec3 u_xlat10_12;
					ivec2 u_xlati12;
					bvec2 u_xlatb12;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_18;
					mediump vec2 u_xlat16_20;
					bool u_xlatb21;
					mediump float u_xlat16_24;
					mediump float u_xlat16_30;
					mediump float u_xlat16_34;
					mediump float u_xlat16_37;
					const int BITWISE_BIT_COUNT = 32;
					int op_modi(int x, int y) { return x - y * (x / y); }
					ivec2 op_modi(ivec2 a, ivec2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
					ivec3 op_modi(ivec3 a, ivec3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
					ivec4 op_modi(ivec4 a, ivec4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
					
					int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
					ivec2 op_and(ivec2 a, ivec2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
					ivec3 op_and(ivec3 a, ivec3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
					ivec4 op_and(ivec4 a, ivec4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }
					
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD3.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_20.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_20.x = float(1.0) / u_xlat16_20.x;
					    u_xlat16_30 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_20.x = u_xlat16_20.x * u_xlat16_30;
					    u_xlat16_30 = u_xlat16_20.x * u_xlat16_20.x;
					    u_xlat16_1 = u_xlat16_30 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1 = u_xlat16_30 * u_xlat16_1 + 0.180141002;
					    u_xlat16_1 = u_xlat16_30 * u_xlat16_1 + -0.330299497;
					    u_xlat16_1 = u_xlat16_30 * u_xlat16_1 + 0.999866009;
					    u_xlat16_11.x = u_xlat16_20.x * u_xlat16_1;
					    u_xlat11.x = u_xlat16_11.x * -2.0 + 1.57079637;
					    u_xlatb21 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat11.x = u_xlatb21 ? u_xlat11.x : float(0.0);
					    u_xlat1 = u_xlat16_20.x * u_xlat16_1 + u_xlat11.x;
					    u_xlatb11 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat11.x = u_xlatb11 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat11.x + u_xlat1;
					    u_xlat16_20.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb11 = u_xlat16_20.x<(-u_xlat16_20.x);
					    u_xlat16_20.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb21 = u_xlat16_20.x>=(-u_xlat16_20.x);
					    u_xlatb11 = u_xlatb21 && u_xlatb11;
					    u_xlat1 = (u_xlatb11) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_10 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _DistotionTexAnimeSpeed2 * u_xlat1 + u_xlat16_10;
					    u_xlat2.y = _DistotionTexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_11.xy = texture2D(_DistotionTex, u_xlat2.xy).xy;
					    u_xlat16_11.xy = u_xlat10_11.xy + vec2(-0.5, -0.5);
					    u_xlat16_11.xy = u_xlat16_11.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_2.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_11.xy * u_xlat10_2.zz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + vs_TEXCOORD2.xy;
					    u_xlat10_11.xyz = texture2D(_Back1Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Back1TexColor.xyz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_20.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_11.xyz * u_xlat10_2.yyy + u_xlat10_3.xyz;
					    u_xlat16_20.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_11.xyz = texture2D(_Back2Tex, u_xlat16_20.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_11.xyz * u_xlat10_2.yyy + u_xlat16_4.xyz;
					    u_xlat16_3 = vs_TEXCOORD1.yxwz * vec4(2.0, 2.0, 2.0, 2.0) + vec4(-1.0, -1.0, -1.0, -1.0);
					    u_xlat16_20.xy = max(abs(u_xlat16_3.yw), abs(u_xlat16_3.xz));
					    u_xlat16_20.xy = vec2(1.0, 1.0) / u_xlat16_20.xy;
					    u_xlat16_5.xy = min(abs(u_xlat16_3.yw), abs(u_xlat16_3.xz));
					    u_xlat16_20.xy = u_xlat16_20.xy * u_xlat16_5.xy;
					    u_xlat16_5.xy = u_xlat16_20.xy * u_xlat16_20.xy;
					    u_xlat16_11.xy = u_xlat16_5.xy * vec2(0.0208350997, 0.0208350997) + vec2(-0.0851330012, -0.0851330012);
					    u_xlat16_11.xy = u_xlat16_5.xy * u_xlat16_11.xy + vec2(0.180141002, 0.180141002);
					    u_xlat16_11.xy = u_xlat16_5.xy * u_xlat16_11.xy + vec2(-0.330299497, -0.330299497);
					    u_xlat16_11.xy = u_xlat16_5.xy * u_xlat16_11.xy + vec2(0.999866009, 0.999866009);
					    u_xlat16_12.xy = u_xlat16_20.xy * u_xlat16_11.xy;
					    u_xlat12.xy = u_xlat16_12.xy * vec2(-2.0, -2.0) + vec2(1.57079637, 1.57079637);
					    u_xlatb6.xy = lessThan(abs(u_xlat16_3.ywyy), abs(u_xlat16_3.xzxx)).xy;
					    u_xlat12.xy = mix(vec2(0.0, 0.0), u_xlat12.xy, vec2(u_xlatb6.xy));
					    u_xlat11.xy = u_xlat16_20.xy * u_xlat16_11.xy + u_xlat12.xy;
					    u_xlatb12.xy = lessThan(u_xlat16_3.ywyy, (-u_xlat16_3.ywyy)).xy;
					    u_xlat12.xy = mix(vec2(0.0, 0.0), vec2(-3.14159274, -3.14159274), vec2(u_xlatb12.xy));
					    u_xlat11.xy = u_xlat11.xy + u_xlat12.xy;
					    u_xlat16_20.xy = min(u_xlat16_3.yw, u_xlat16_3.xz);
					    u_xlatb12.xy = lessThan(u_xlat16_20.xyxx, (-u_xlat16_20.xyxx)).xy;
					    u_xlat16_20.xy = max(u_xlat16_3.yw, u_xlat16_3.xz);
					    u_xlatb6.xy = greaterThanEqual(u_xlat16_20.xyxx, (-u_xlat16_20.xyxx)).xy;
					    u_xlati12.xy = op_and((ivec2(u_xlatb12.xy) * -1), (ivec2(u_xlatb6.xy) * -1));
					    {
					        vec2 hlslcc_movcTemp = u_xlat11;
					        hlslcc_movcTemp.x = (u_xlati12.x != 0) ? (-u_xlat11.x) : u_xlat11.x;
					        hlslcc_movcTemp.y = (u_xlati12.y != 0) ? (-u_xlat11.y) : u_xlat11.y;
					        u_xlat11 = hlslcc_movcTemp;
					    }
					    u_xlat16_20.xy = u_xlat11.xy * vec2(0.159154937, 0.159154937) + vec2(0.75, 0.75);
					    u_xlat5.xy = vec2(_Front1TexAnimeSpeed2, _Front2TexAnimeSpeed2) * vec2(u_xlat1) + u_xlat16_20.xy;
					    u_xlat16_20.x = dot(u_xlat16_3.xy, u_xlat16_3.xy);
					    u_xlat16_20.y = dot(u_xlat16_3.zw, u_xlat16_3.zw);
					    u_xlat16_20.xy = sqrt(u_xlat16_20.xy);
					    u_xlat16_20.xy = (-u_xlat16_20.xy) + vec2(1.0, 1.0);
					    u_xlat5.w = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_20.y;
					    u_xlat16_7.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + u_xlat5.yw;
					    u_xlat10_11.xyz = texture2D(_Front2Tex, u_xlat16_7.xy).xyz;
					    u_xlat16_11.xyz = u_xlat10_11.xyz * _Front2TexColor.xyz;
					    u_xlat5.z = _Front1TexAnimeSpeed * u_xlat1 + u_xlat16_20.x;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat5.xz;
					    u_xlat10_12.xyz = texture2D(_Front1Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_12.xyz = u_xlat10_12.xyz * _Front1TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_12.xyz * u_xlat10_2.xxx + u_xlat16_4.xyz;
					    u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_2.xxx + u_xlat16_0.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_30 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1 = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_30) * u_xlat16_0.xyz;
					    u_xlat16_30 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_30) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_30 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_30 = u_xlat16_2.x * 1.25 + u_xlat16_30;
					    u_xlat16_14.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_14.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_14.x);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.114 + u_xlat16_14.y;
					    u_xlat16_24 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_24;
					    u_xlat16_14.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_14.x;
					    u_xlat10_11.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_34 = u_xlat10_11.y * u_xlat16_14.x;
					    u_xlat16_34 = u_xlat16_30 * u_xlat10_11.x + u_xlat16_34;
					    u_xlat16_34 = u_xlat16_24 * u_xlat10_11.z + u_xlat16_34;
					    u_xlat16_7.z = u_xlat16_34 * u_xlat16_1 + u_xlat16_0.z;
					    u_xlat16_8.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_20.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_8.x;
					    u_xlat16_34 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_8.y);
					    u_xlat16_34 = u_xlat16_2.z * 0.330000013 + u_xlat16_34;
					    u_xlat16_20.x = u_xlat16_2.z * 0.167999998 + u_xlat16_20.x;
					    u_xlat16_37 = u_xlat10_11.y * u_xlat16_34;
					    u_xlat16_37 = u_xlat16_20.x * u_xlat10_11.x + u_xlat16_37;
					    u_xlat16_8.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_8.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_8.xy);
					    u_xlat16_18.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_8.xy;
					    u_xlat16_8.x = u_xlat16_2.z * 0.291999996 + u_xlat16_8.x;
					    u_xlat16_37 = u_xlat16_18.x * u_xlat10_11.z + u_xlat16_37;
					    u_xlat16_7.x = u_xlat16_37 * u_xlat16_1 + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_11.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_11.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_8.x * u_xlat10_11.z + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_0.x * u_xlat16_1 + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_14.x;
					    u_xlat16_0.x = u_xlat16_30 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_9.z = u_xlat16_24 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_34;
					    u_xlat16_0.x = u_xlat16_20.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_9.x = u_xlat16_18.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_18.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_9.y = u_xlat16_8.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_9.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_7.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {	{ "_BACK1TEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" "_FRONT2TEX_POLAR" }
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 _Time;
					uniform 	vec4 _SinTime;
					uniform 	vec4 _CosTime;
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _Front1Tex_ST;
					uniform 	vec4 _Front2Tex_ST;
					uniform 	vec4 _Back1Tex_ST;
					uniform 	vec4 _Back2Tex_ST;
					uniform 	vec4 _DistotionTex_ST;
					uniform 	mediump float _Front1TexAnimeSpeed;
					uniform 	mediump float _Back2TexAnimeSpeed;
					uniform 	mediump float _DistotionTexAnimeSpeed;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					mediump vec2 u_xlat16_3;
					vec2 u_xlat4;
					bool u_xlatb4;
					mediump float u_xlat16_7;
					vec2 u_xlat8;
					void main()
					{
					    u_xlat0.x = _Time.x * _DistotionTexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _DistotionTex_ST.xy + _DistotionTex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD3.xy = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Front1TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Front1Tex_ST.xy + _Front1Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat0.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat0.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD1.xy = u_xlat0.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Front2Tex_ST.xy + _Front2Tex_ST.zw;
					    vs_TEXCOORD1.zw = u_xlat0.xy;
					    u_xlat0.x = _Time.x * _Back2TexAnimeSpeed;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlat0.x = u_xlat0.x * 6.28318548;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xy = in_TEXCOORD0.xy * _Back2Tex_ST.xy + _Back2Tex_ST.zw;
					    u_xlat16_3.xy = u_xlat4.xy + vec2(-0.5, -0.5);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat8.y = dot(u_xlat2.zy, u_xlat16_3.xy);
					    u_xlat8.x = dot(u_xlat2.yx, u_xlat16_3.xy);
					    vs_TEXCOORD2.zw = u_xlat8.xy + vec2(0.5, 0.5);
					    u_xlat0.xy = in_TEXCOORD0.xy * _Back1Tex_ST.xy + _Back1Tex_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    u_xlat0.x = _Time.y * 0.25;
					    u_xlat0.x = fract(u_xlat0.x);
					    u_xlatb4 = 0.5>=u_xlat0.x;
					    u_xlat16_3.x = (u_xlatb4) ? -12.0 : -0.0;
					    u_xlat16_3.x = dot(u_xlat16_3.xx, u_xlat0.xx);
					    u_xlat0.xy = in_TEXCOORD0.xy + vec2(-0.5, -0.5);
					    u_xlat1.x = dot(vec2(0.707106769, -0.707106769), u_xlat0.xy);
					    u_xlat1.y = dot(vec2(0.707106769, 0.707106769), u_xlat0.xy);
					    u_xlat0.xy = u_xlat1.xy + vec2(0.5, 0.5);
					    u_xlat16_7 = u_xlat0.x * 4.0 + 1.20000005;
					    vs_TEXCOORD4.y = u_xlat0.y;
					    vs_TEXCOORD4.x = u_xlat16_3.x + u_xlat16_7;
					    u_xlat0.x = _SinTime.w * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * _SinTime.w;
					    u_xlat0.x = u_xlat0.x * 4.0;
					    u_xlat0.x = _SinTime.w * 3.0 + (-u_xlat0.x);
					    vs_TEXCOORD5.x = u_xlat0.x;
					    u_xlat0.x = _CosTime.w * _CosTime.w;
					    u_xlat0.x = u_xlat0.x * _CosTime.w;
					    u_xlat4.x = _CosTime.w * 3.0;
					    u_xlat0.x = u_xlat0.x * 4.0 + (-u_xlat4.x);
					    vs_TEXCOORD5.y = u_xlat0.x;
					    vs_TEXCOORD5.zw = vec2(1.0, 1.0);
					    vs_COLOR0 = in_COLOR0;
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
					uniform 	mediump vec4 _Front1TexColor;
					uniform 	mediump vec4 _Front2TexColor;
					uniform 	mediump vec4 _Back1TexColor;
					uniform 	mediump vec4 _Back2TexColor;
					uniform 	mediump float _Front2TexAnimeSpeed;
					uniform 	mediump float _Front2TexAnimeSpeed2;
					uniform 	mediump float _Back1TexAnimeSpeed;
					uniform 	mediump float _Back1TexAnimeSpeed2;
					uniform 	mediump float _MainTexDistotion;
					uniform 	mediump float _Front1TexDistotion;
					uniform 	mediump float _Front2TexDistotion;
					uniform 	mediump float _Back1TexDistotion;
					uniform 	mediump float _Back2TexDistotion;
					uniform 	mediump float _DistotionTexPower;
					uniform 	mediump float _IsKira;
					uniform lowp sampler2D _DistotionTex;
					uniform lowp sampler2D _MaskTex;
					uniform lowp sampler2D _MainTex;
					uniform lowp sampler2D _Front1Tex;
					uniform lowp sampler2D _Front2Tex;
					uniform lowp sampler2D _Back1Tex;
					uniform lowp sampler2D _Back2Tex;
					uniform lowp sampler2D _FrameTex;
					uniform lowp sampler2D _FrameMaskTex;
					uniform lowp sampler2D _KiraTex;
					uniform lowp sampler2D _Kira2Tex;
					uniform lowp sampler2D _Kira3Tex;
					uniform lowp sampler2D _KiraMaskTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD3;
					varying mediump vec4 vs_TEXCOORD1;
					varying mediump vec4 vs_TEXCOORD2;
					varying mediump vec2 vs_TEXCOORD4;
					varying mediump vec4 vs_TEXCOORD5;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump vec3 u_xlat16_0;
					float u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec2 u_xlat2;
					mediump vec4 u_xlat16_2;
					lowp vec3 u_xlat10_2;
					lowp vec3 u_xlat10_3;
					mediump vec3 u_xlat16_4;
					mediump vec3 u_xlat16_5;
					mediump vec2 u_xlat16_6;
					mediump vec3 u_xlat16_7;
					mediump float u_xlat16_8;
					float u_xlat9;
					mediump vec3 u_xlat16_9;
					lowp vec3 u_xlat10_9;
					bool u_xlatb9;
					mediump vec2 u_xlat16_12;
					mediump vec2 u_xlat16_14;
					mediump vec2 u_xlat16_16;
					float u_xlat17;
					mediump float u_xlat16_17;
					bool u_xlatb17;
					mediump float u_xlat16_20;
					mediump float u_xlat16_24;
					bool u_xlatb25;
					mediump float u_xlat16_28;
					mediump float u_xlat16_29;
					void main()
					{
					    u_xlat16_0.xy = vs_TEXCOORD2.yx * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_16.x = max(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = float(1.0) / u_xlat16_16.x;
					    u_xlat16_24 = min(abs(u_xlat16_0.y), abs(u_xlat16_0.x));
					    u_xlat16_16.x = u_xlat16_16.x * u_xlat16_24;
					    u_xlat16_24 = u_xlat16_16.x * u_xlat16_16.x;
					    u_xlat16_1.x = u_xlat16_24 * 0.0208350997 + -0.0851330012;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.180141002;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + -0.330299497;
					    u_xlat16_1.x = u_xlat16_24 * u_xlat16_1.x + 0.999866009;
					    u_xlat16_9.x = u_xlat16_16.x * u_xlat16_1.x;
					    u_xlat9 = u_xlat16_9.x * -2.0 + 1.57079637;
					    u_xlatb17 = abs(u_xlat16_0.y)<abs(u_xlat16_0.x);
					    u_xlat9 = u_xlatb17 ? u_xlat9 : float(0.0);
					    u_xlat1 = u_xlat16_16.x * u_xlat16_1.x + u_xlat9;
					    u_xlatb9 = u_xlat16_0.y<(-u_xlat16_0.y);
					    u_xlat9 = u_xlatb9 ? -3.14159274 : float(0.0);
					    u_xlat1 = u_xlat9 + u_xlat1;
					    u_xlat16_16.x = min(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlatb9 = u_xlat16_16.x<(-u_xlat16_16.x);
					    u_xlat16_16.x = max(u_xlat16_0.y, u_xlat16_0.x);
					    u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
					    u_xlat16_0.x = sqrt(u_xlat16_0.x);
					    u_xlat16_0.x = (-u_xlat16_0.x) + 1.0;
					    u_xlatb17 = u_xlat16_16.x>=(-u_xlat16_16.x);
					    u_xlatb9 = u_xlatb17 && u_xlatb9;
					    u_xlat1 = (u_xlatb9) ? (-u_xlat1) : u_xlat1;
					    u_xlat16_8 = u_xlat1 * 0.159154937 + 0.75;
					    u_xlat1 = fract(_Time.x);
					    u_xlat2.x = _Back1TexAnimeSpeed2 * u_xlat1 + u_xlat16_8;
					    u_xlat2.y = _Back1TexAnimeSpeed * u_xlat1 + u_xlat16_0.x;
					    u_xlat10_9.xy = texture2D(_DistotionTex, vs_TEXCOORD3.xy).xy;
					    u_xlat16_9.xy = u_xlat10_9.xy + vec2(-0.5, -0.5);
					    u_xlat16_9.xy = u_xlat16_9.xy * vec2(vec2(_DistotionTexPower, _DistotionTexPower));
					    u_xlat10_3.xyz = texture2D(_MaskTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.xy = u_xlat16_9.xy * u_xlat10_3.zz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat2.xy;
					    u_xlat10_9.xyz = texture2D(_Back1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back1TexColor.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_MainTexDistotion, _MainTexDistotion)) + vs_TEXCOORD0.xy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat16_16.xy).xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_3.yyy + u_xlat10_2.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Back2TexDistotion, _Back2TexDistotion)) + vs_TEXCOORD2.zw;
					    u_xlat10_9.xyz = texture2D(_Back2Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Back2TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_3.yyy + u_xlat16_4.xyz;
					    u_xlat16_16.xy = u_xlat16_0.xy * vec2(vec2(_Front1TexDistotion, _Front1TexDistotion)) + vs_TEXCOORD1.xy;
					    u_xlat10_9.xyz = texture2D(_Front1Tex, u_xlat16_16.xy).xyz;
					    u_xlat16_9.xyz = u_xlat10_9.xyz * _Front1TexColor.xyz;
					    u_xlat16_4.xyz = u_xlat16_9.xyz * u_xlat10_3.xxx + u_xlat16_4.xyz;
					    u_xlat16_16.xy = vs_TEXCOORD1.wz * vec2(2.0, 2.0) + vec2(-1.0, -1.0);
					    u_xlat16_28 = max(abs(u_xlat16_16.y), abs(u_xlat16_16.x));
					    u_xlat16_28 = float(1.0) / u_xlat16_28;
					    u_xlat16_5.x = min(abs(u_xlat16_16.y), abs(u_xlat16_16.x));
					    u_xlat16_28 = u_xlat16_28 * u_xlat16_5.x;
					    u_xlat16_5.x = u_xlat16_28 * u_xlat16_28;
					    u_xlat16_9.x = u_xlat16_5.x * 0.0208350997 + -0.0851330012;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.180141002;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + -0.330299497;
					    u_xlat16_9.x = u_xlat16_5.x * u_xlat16_9.x + 0.999866009;
					    u_xlat16_17 = u_xlat16_9.x * u_xlat16_28;
					    u_xlat17 = u_xlat16_17 * -2.0 + 1.57079637;
					    u_xlatb25 = abs(u_xlat16_16.y)<abs(u_xlat16_16.x);
					    u_xlat17 = u_xlatb25 ? u_xlat17 : float(0.0);
					    u_xlat9 = u_xlat16_28 * u_xlat16_9.x + u_xlat17;
					    u_xlatb17 = u_xlat16_16.y<(-u_xlat16_16.y);
					    u_xlat17 = u_xlatb17 ? -3.14159274 : float(0.0);
					    u_xlat9 = u_xlat17 + u_xlat9;
					    u_xlat16_28 = min(u_xlat16_16.y, u_xlat16_16.x);
					    u_xlatb17 = u_xlat16_28<(-u_xlat16_28);
					    u_xlat16_28 = max(u_xlat16_16.y, u_xlat16_16.x);
					    u_xlat16_16.x = dot(u_xlat16_16.xy, u_xlat16_16.xy);
					    u_xlat16_16.x = sqrt(u_xlat16_16.x);
					    u_xlat16_16.x = (-u_xlat16_16.x) + 1.0;
					    u_xlat2.y = _Front2TexAnimeSpeed * u_xlat1 + u_xlat16_16.x;
					    u_xlatb25 = u_xlat16_28>=(-u_xlat16_28);
					    u_xlatb17 = u_xlatb25 && u_xlatb17;
					    u_xlat9 = (u_xlatb17) ? (-u_xlat9) : u_xlat9;
					    u_xlat16_16.x = u_xlat9 * 0.159154937 + 0.75;
					    u_xlat2.x = _Front2TexAnimeSpeed2 * u_xlat1 + u_xlat16_16.x;
					    u_xlat16_0.xy = u_xlat16_0.xy * vec2(_Front2TexDistotion) + u_xlat2.xy;
					    u_xlat10_1.xyz = texture2D(_Front2Tex, u_xlat16_0.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * _Front2TexColor.xyz;
					    u_xlat16_0.xyz = u_xlat16_1.xyz * u_xlat10_3.xxx + u_xlat16_4.xyz;
					    u_xlat10_1.xyz = texture2D(_FrameTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_1.xyz;
					    u_xlat10_1.x = texture2D(_FrameMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_0.xyz = u_xlat10_1.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
					    u_xlat10_1.x = texture2D(_KiraMaskTex, vs_TEXCOORD0.xy).x;
					    u_xlat16_24 = (-u_xlat10_1.x) * _IsKira + 1.0;
					    u_xlat16_1.x = u_xlat10_1.x * _IsKira;
					    u_xlat16_0.xyz = vec3(u_xlat16_24) * u_xlat16_0.xyz;
					    u_xlat16_24 = vs_TEXCOORD5.w * vs_TEXCOORD5.z;
					    u_xlat16_2 = vec4(u_xlat16_24) * vs_TEXCOORD5.yxyx;
					    u_xlat16_4.xy = u_xlat16_2.ww * vec2(0.412999988, 0.300000012);
					    u_xlat16_24 = vs_TEXCOORD5.z * 0.298999995 + (-u_xlat16_4.y);
					    u_xlat16_4.x = vs_TEXCOORD5.z * 0.587000012 + u_xlat16_4.x;
					    u_xlat16_4.x = u_xlat16_2.z * 0.0350000001 + u_xlat16_4.x;
					    u_xlat16_24 = u_xlat16_2.x * 1.25 + u_xlat16_24;
					    u_xlat16_12.xy = u_xlat16_2.yw * vec2(0.588, 0.885999978);
					    u_xlat16_12.x = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_12.x);
					    u_xlat16_20 = vs_TEXCOORD5.z * 0.114 + u_xlat16_12.y;
					    u_xlat16_20 = (-u_xlat16_2.z) * 0.202999994 + u_xlat16_20;
					    u_xlat16_12.x = (-u_xlat16_2.z) * 1.04999995 + u_xlat16_12.x;
					    u_xlat10_9.xyz = texture2D(_Kira3Tex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_28 = u_xlat10_9.y * u_xlat16_12.x;
					    u_xlat16_28 = u_xlat16_24 * u_xlat10_9.x + u_xlat16_28;
					    u_xlat16_28 = u_xlat16_20 * u_xlat10_9.z + u_xlat16_28;
					    u_xlat16_5.z = u_xlat16_28 * u_xlat16_1.x + u_xlat16_0.z;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.700999975, 0.587000012);
					    u_xlat16_16.x = vs_TEXCOORD5.z * 0.298999995 + u_xlat16_6.x;
					    u_xlat16_28 = vs_TEXCOORD5.z * 0.587000012 + (-u_xlat16_6.y);
					    u_xlat16_28 = u_xlat16_2.z * 0.330000013 + u_xlat16_28;
					    u_xlat16_16.x = u_xlat16_2.z * 0.167999998 + u_xlat16_16.x;
					    u_xlat16_29 = u_xlat10_9.y * u_xlat16_28;
					    u_xlat16_29 = u_xlat16_16.x * u_xlat10_9.x + u_xlat16_29;
					    u_xlat16_6.xy = u_xlat16_2.ww * vec2(0.114, 0.298999995);
					    u_xlat16_6.xy = vs_TEXCOORD5.zz * vec2(0.114, 0.298999995) + (-u_xlat16_6.xy);
					    u_xlat16_14.xy = (-u_xlat16_2.zz) * vec2(0.497000009, 0.328000009) + u_xlat16_6.xy;
					    u_xlat16_6.x = u_xlat16_2.z * 0.291999996 + u_xlat16_6.x;
					    u_xlat16_29 = u_xlat16_14.x * u_xlat10_9.z + u_xlat16_29;
					    u_xlat16_5.x = u_xlat16_29 * u_xlat16_1.x + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_9.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_9.y + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat16_6.x * u_xlat10_9.z + u_xlat16_0.x;
					    u_xlat16_5.y = u_xlat16_0.x * u_xlat16_1.x + u_xlat16_0.y;
					    u_xlat10_1.xyz = texture2D(_KiraTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_12.x;
					    u_xlat16_0.x = u_xlat16_24 * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.z = u_xlat16_20 * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.y * u_xlat16_28;
					    u_xlat16_0.x = u_xlat16_16.x * u_xlat10_1.x + u_xlat16_0.x;
					    u_xlat16_7.x = u_xlat16_14.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat16_0.x = u_xlat10_1.x * u_xlat16_14.y;
					    u_xlat16_0.x = u_xlat16_4.x * u_xlat10_1.y + u_xlat16_0.x;
					    u_xlat16_7.y = u_xlat16_6.x * u_xlat10_1.z + u_xlat16_0.x;
					    u_xlat10_1.xyz = texture2D(_Kira2Tex, vs_TEXCOORD4.xy).xyz;
					    u_xlat16_0.xyz = u_xlat10_1.xyz + u_xlat16_7.xyz;
					    u_xlat16_0.xyz = u_xlat16_0.xyz * vec3(_IsKira) + u_xlat16_5.xyz;
					    SV_Target0.xyz = u_xlat16_0.xyz * vs_COLOR0.xyz;
					    SV_Target0.w = vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
			}
*/

			const int BITWISE_BIT_COUNT = 32;
			int op_modi(int x, int y) { return x - y * (x / y); }
			int2 op_modi(int2 a, int2 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); return a; }
			int3 op_modi(int3 a, int3 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); return a; }
			int4 op_modi(int4 a, int4 b) { a.x = op_modi(a.x, b.x); a.y = op_modi(a.y, b.y); a.z = op_modi(a.z, b.z); a.w = op_modi(a.w, b.w); return a; }
			
			int op_and(int a, int b) { int result = 0; int n = 1; for (int i = 0; i < BITWISE_BIT_COUNT; i++) { if ((op_modi(a, 2) != 0) && (op_modi(b, 2) != 0)) { result += n; } a = a / 2; b = b / 2; n = n * 2; if (!(a > 0 && b > 0)) { break; } } return result; }
			int2 op_and(int2 a, int2 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); return a; }
			int3 op_and(int3 a, int3 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); return a; }
			int4 op_and(int4 a, int4 b) { a.x = op_and(a.x, b.x); a.y = op_and(a.y, b.y); a.z = op_and(a.z, b.z); a.w = op_and(a.w, b.w); return a; }

			fixed4 frag(v2f i) : SV_Target
			{
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }

				//Keywords { "_BACK1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
				//Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_POLAR" }
				float4 u_xlat16_0;
				float4 u_xlat1;
				float4 u_xlat16_1;
				float2 u_xlat2;
				float2 u_xlat16_2;
				float2 u_xlat3;
				float3 u_xlat10_3;
				bool2 u_xlatb3;
				float3 u_xlat16_4;
				float4 u_xlat5;
				float3 u_xlat16_5;
				float3 u_xlat10_5;
				bool2 u_xlatb5;
				float3 u_xlat10_6;
				float3 u_xlat16_7;
				float2 u_xlat16_8;
				float2 u_xlat10;
				float3 u_xlat16_10;
				float3 u_xlat10_10;
				float2 u_xlat11;
				float3 u_xlat16_11;
				float3 u_xlat10_11;
				int2 u_xlati11;
				bool2 u_xlatb11;
				float2 u_xlat16_17;
				float2 u_xlat18;
				float2 u_xlat16_18;
				int2 u_xlati18;
				bool2 u_xlatb18;
				float2 u_xlat16_20;
				float u_xlat16_24;
				bool u_xlatb26;
				float u_xlat16_28;
				u_xlat16_0 = i.texcoord2.yxwz * float4(2.0, 2.0, 2.0, 2.0) + float4(-1.0, -1.0, -1.0, -1.0);
				u_xlat16_1.xy = max(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
				u_xlat16_1.xy = float2(1.0, 1.0) / u_xlat16_1.xy;
				u_xlat16_17.xy = min(abs(u_xlat16_0.yw), abs(u_xlat16_0.xz));
				u_xlat16_1.xy = u_xlat16_1.xy * u_xlat16_17.xy;
				u_xlat16_17.xy = u_xlat16_1.xy * u_xlat16_1.xy;
				u_xlat16_2.xy = u_xlat16_17.xy * float2(0.0208350997, 0.0208350997) + float2(-0.0851330012, -0.0851330012);
				u_xlat16_2.xy = u_xlat16_17.xy * u_xlat16_2.xy + float2(0.180141002, 0.180141002);
				u_xlat16_2.xy = u_xlat16_17.xy * u_xlat16_2.xy + float2(-0.330299497, -0.330299497);
				u_xlat16_2.xy = u_xlat16_17.xy * u_xlat16_2.xy + float2(0.999866009, 0.999866009);
				u_xlat16_18.xy = u_xlat16_1.xy * u_xlat16_2.xy;
				u_xlat18.xy = u_xlat16_18.xy * float2(-2.0, -2.0) + float2(1.57079637, 1.57079637);
				u_xlatb3.xy = (abs(u_xlat16_0.ywyy) < abs(u_xlat16_0.xzxx)).xy;
				u_xlat18.xy = lerp(float2(0.0, 0.0), u_xlat18.xy, float2(u_xlatb3.xy));
				u_xlat2.xy = u_xlat16_1.xy * u_xlat16_2.xy + u_xlat18.xy;
				u_xlatb18.xy = (u_xlat16_0.ywyw < (-u_xlat16_0.ywyw)).xy;
				u_xlat18.xy = lerp(float2(0.0, 0.0), float2(-3.14159274, -3.14159274), float2(u_xlatb18.xy));
				u_xlat2.xy = u_xlat18.xy + u_xlat2.xy;
				u_xlat16_1.xy = min(u_xlat16_0.yw, u_xlat16_0.xz);
				u_xlatb18.xy = (u_xlat16_1.xyxy < (-u_xlat16_1.xyxy)).xy;
				u_xlat16_1.xy = max(u_xlat16_0.yw, u_xlat16_0.xz);
				u_xlatb3.xy = (u_xlat16_1.xyxx >= (-u_xlat16_1.xyxx)).xy;
				u_xlati18.xy = op_and((int2(u_xlatb18.xy) * -1), (int2(u_xlatb3.xy) * -1));
				{
					float2 hlslcc_movcTemp = u_xlat2;
					hlslcc_movcTemp.x = (u_xlati18.x != 0) ? (-u_xlat2.x) : u_xlat2.x;
					hlslcc_movcTemp.y = (u_xlati18.y != 0) ? (-u_xlat2.y) : u_xlat2.y;
					u_xlat2 = hlslcc_movcTemp;
				}
				u_xlat16_1.xy = u_xlat2.xy * float2(0.159154937, 0.159154937) + float2(0.75, 0.75);
				u_xlat2.x = frac(_Time.x);
				u_xlat1.xy = float2(_Back1TexAnimeSpeed2, _Back2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_1.xy;
				u_xlat16_4.xy = i.texcoord3.yx * float2(2.0, 2.0) + float2(-1.0, -1.0);
				u_xlat16_20.x = max(abs(u_xlat16_4.y), abs(u_xlat16_4.x));
				u_xlat16_20.x = float(1.0) / u_xlat16_20.x;
				u_xlat16_28 = min(abs(u_xlat16_4.y), abs(u_xlat16_4.x));
				u_xlat16_20.x = u_xlat16_20.x * u_xlat16_28;
				u_xlat16_28 = u_xlat16_20.x * u_xlat16_20.x;
				u_xlat16_10.x = u_xlat16_28 * 0.0208350997 + -0.0851330012;
				u_xlat16_10.x = u_xlat16_28 * u_xlat16_10.x + 0.180141002;
				u_xlat16_10.x = u_xlat16_28 * u_xlat16_10.x + -0.330299497;
				u_xlat16_10.x = u_xlat16_28 * u_xlat16_10.x + 0.999866009;
				u_xlat16_18.x = u_xlat16_10.x * u_xlat16_20.x;
				u_xlat18.x = u_xlat16_18.x * -2.0 + 1.57079637;
				u_xlatb26 = abs(u_xlat16_4.y)<abs(u_xlat16_4.x);
				u_xlat18.x = u_xlatb26 ? u_xlat18.x : float(0.0);
				u_xlat10.x = u_xlat16_20.x * u_xlat16_10.x + u_xlat18.x;
				u_xlatb18.x = u_xlat16_4.y<(-u_xlat16_4.y);
				u_xlat18.x = u_xlatb18.x ? -3.14159274 : float(0.0);
				u_xlat10.x = u_xlat18.x + u_xlat10.x;
				u_xlat16_20.x = min(u_xlat16_4.y, u_xlat16_4.x);
				u_xlatb18.x = u_xlat16_20.x<(-u_xlat16_20.x);
				u_xlat16_20.x = max(u_xlat16_4.y, u_xlat16_4.x);
				u_xlat16_4.x = dot(u_xlat16_4.xy, u_xlat16_4.xy);
				u_xlat16_4.x = sqrt(u_xlat16_4.x);
				u_xlat16_4.x = (-u_xlat16_4.x) + 1.0;
				u_xlat3.y = _DistotionTexAnimeSpeed * u_xlat2.x + u_xlat16_4.x;
				u_xlatb26 = u_xlat16_20.x>=(-u_xlat16_20.x);
				u_xlatb18.x = u_xlatb26 && u_xlatb18.x;
				u_xlat10.x = (u_xlatb18.x) ? (-u_xlat10.x) : u_xlat10.x;
				u_xlat16_4.x = u_xlat10.x * 0.159154937 + 0.75;
				u_xlat3.x = _DistotionTexAnimeSpeed2 * u_xlat2.x + u_xlat16_4.x;
				#if _DISTOTIONTEX_POLAR
					u_xlat10_10.xy = tex2D(_DistotionTex, u_xlat3.xy).xy;
				#elif _DISTOTIONTEX_ROTATE || _DISTOTIONTEX_SCROLL
					u_xlat10_10.xy = tex2D(_DistotionTex, i.texcoord3.xy).xy;
				#endif

				u_xlat16_10.xy = u_xlat10_10.xy + float2(-0.5, -0.5);
				u_xlat16_10.xy = u_xlat16_10.xy * float2(float2(_DistotionTexPower, _DistotionTexPower));

				u_xlat10_3.xyz = tex2D(_MaskTex, i.texcoord0.xy).xyz;
				u_xlat16_4.xy = u_xlat16_10.xy * u_xlat10_3.zz;

				u_xlat16_0.x = dot(u_xlat16_0.xy, u_xlat16_0.xy);
				u_xlat16_0.y = dot(u_xlat16_0.zw, u_xlat16_0.zw);
				u_xlat16_0.xy = sqrt(u_xlat16_0.xy);
				u_xlat16_0.xy = (-u_xlat16_0.xy) + float2(1.0, 1.0);

				#if _BACK2TEX_POLAR
					u_xlat1.w = _Back2TexAnimeSpeed * u_xlat2.x + u_xlat16_0.y;
					u_xlat16_8.xy = u_xlat16_4.xy * float2(float2(_Back2TexDistotion, _Back2TexDistotion)) + u_xlat1.yw;
				#elif _BACK2TEX_ROTATE || _BACK2TEX_SCROLL
					u_xlat16_8.xy = u_xlat16_4.xy * float2(float2(_Back2TexDistotion, _Back2TexDistotion)) + i.texcoord2.zw;
				#endif
				u_xlat10_10.xyz = tex2D(_Back2Tex, u_xlat16_8.xy).xyz;
				u_xlat16_10.xyz = u_xlat10_10.xyz * _Back2TexColor.xyz;

				#if	_BACK1TEX_POLAR
					u_xlat1.z = _Back1TexAnimeSpeed * u_xlat2.x + u_xlat16_0.x;
					u_xlat16_0.xy = u_xlat16_4.xy * float2(float2(_Back1TexDistotion, _Back1TexDistotion)) + u_xlat1.xz;
				#elif _BACK1TEX_ROTATE || _BACK1TEX_SCROLL
					u_xlat16_0.xy = u_xlat16_4.xy * float2(float2(_Back1TexDistotion, _Back1TexDistotion)) + i.texcoord2.xy;
				#endif
				u_xlat10_5.xyz = tex2D(_Back1Tex, u_xlat16_0.xy).xyz;
				u_xlat16_5.xyz = u_xlat10_5.xyz * _Back1TexColor.xyz;

				u_xlat16_0.xy = u_xlat16_4.xy * float2(float2(_MainTexDistotion, _MainTexDistotion)) + i.texcoord0.xy;
				u_xlat10_6.xyz = tex2D(_MainTex, u_xlat16_0.xy).xyz;
				u_xlat16_0.xyz = u_xlat16_5.xyz * u_xlat10_3.yyy + u_xlat10_6.xyz;
				u_xlat16_0.xyz = u_xlat16_10.xyz * u_xlat10_3.yyy + u_xlat16_0.xyz;

				u_xlat16_1 = i.texcoord1.yxwz * float4(2.0, 2.0, 2.0, 2.0) + float4(-1.0, -1.0, -1.0, -1.0);
				u_xlat16_20.xy = max(abs(u_xlat16_1.yw), abs(u_xlat16_1.xz));
				u_xlat16_20.xy = float2(1.0, 1.0) / u_xlat16_20.xy;
				u_xlat16_7.xy = min(abs(u_xlat16_1.yw), abs(u_xlat16_1.xz));
				u_xlat16_20.xy = u_xlat16_20.xy * u_xlat16_7.xy;
				u_xlat16_7.xy = u_xlat16_20.xy * u_xlat16_20.xy;
				u_xlat16_10.xy = u_xlat16_7.xy * float2(0.0208350997, 0.0208350997) + float2(-0.0851330012, -0.0851330012);
				u_xlat16_10.xy = u_xlat16_7.xy * u_xlat16_10.xy + float2(0.180141002, 0.180141002);
				u_xlat16_10.xy = u_xlat16_7.xy * u_xlat16_10.xy + float2(-0.330299497, -0.330299497);
				u_xlat16_10.xy = u_xlat16_7.xy * u_xlat16_10.xy + float2(0.999866009, 0.999866009);
				u_xlat16_11.xy = u_xlat16_10.xy * u_xlat16_20.xy;
				u_xlat11.xy = u_xlat16_11.xy * float2(-2.0, -2.0) + float2(1.57079637, 1.57079637);
				u_xlatb5.xy = (abs(u_xlat16_1.ywyy) < abs(u_xlat16_1.xzxx)).xy;
				u_xlat11.xy = lerp(float2(0.0, 0.0), u_xlat11.xy, float2(u_xlatb5.xy));
				u_xlat10.xy = u_xlat16_20.xy * u_xlat16_10.xy + u_xlat11.xy;
				u_xlatb11.xy = (u_xlat16_1.ywyy < (-u_xlat16_1.ywyy)).xy;
				u_xlat11.xy = lerp(float2(0.0, 0.0), float2(-3.14159274, -3.14159274), float2(u_xlatb11.xy));
				u_xlat10.xy = u_xlat10.xy + u_xlat11.xy;
				u_xlat16_20.xy = min(u_xlat16_1.yw, u_xlat16_1.xz);
				u_xlatb11.xy = (u_xlat16_20.xyxx < (-u_xlat16_20.xyxx)).xy;
				u_xlat16_20.xy = max(u_xlat16_1.yw, u_xlat16_1.xz);
				u_xlatb5.xy = (u_xlat16_20.xyxx >= (-u_xlat16_20.xyxx)).xy;
				u_xlati11.xy = op_and((int2(u_xlatb11.xy) * -1), (int2(u_xlatb5.xy) * -1));
				{
					float2 hlslcc_movcTemp = u_xlat10;
					hlslcc_movcTemp.x = (u_xlati11.x != 0) ? (-u_xlat10.x) : u_xlat10.x;
					hlslcc_movcTemp.y = (u_xlati11.y != 0) ? (-u_xlat10.y) : u_xlat10.y;
					u_xlat10 = hlslcc_movcTemp;
				}
				u_xlat16_20.xy = u_xlat10.xy * float2(0.159154937, 0.159154937) + float2(0.75, 0.75);
				u_xlat5.xy = float2(_Front1TexAnimeSpeed2, _Front2TexAnimeSpeed2) * u_xlat2.xx + u_xlat16_20.xy;
				u_xlat16_24 = dot(u_xlat16_1.xy, u_xlat16_1.xy);
				u_xlat16_20.x = dot(u_xlat16_1.zw, u_xlat16_1.zw);
				u_xlat16_20.x = sqrt(u_xlat16_20.x);
				u_xlat16_20.x = (-u_xlat16_20.x) + 1.0;
				u_xlat5.w = _Front2TexAnimeSpeed * u_xlat2.x + u_xlat16_20.x;
				#if _FRONT2TEX_POLAR
					u_xlat16_20.xy = u_xlat16_4.xy * float2(_Front2TexDistotion, _Front2TexDistotion) + u_xlat5.yw;
					u_xlat10_10.xyz = tex2D(_Front2Tex, u_xlat16_20.xy).xyz;
				#elif _FRONT2TEX_SCROLL || _FRONT2TEX_ROTATE
					u_xlat16_20.xy = u_xlat16_4.xy * float2(_Front2TexDistotion, _Front2TexDistotion) + i.texcoord1.zw;
					u_xlat10_10.xyz = tex2D(_Front2Tex, u_xlat16_20.xy).xyz;
				#endif
				u_xlat16_10.xyz = u_xlat10_10.xyz * _Front2TexColor.xyz;
				u_xlat16_24 = sqrt(u_xlat16_24);
				u_xlat16_24 = (-u_xlat16_24) + 1.0;
				u_xlat5.z = _Front1TexAnimeSpeed * u_xlat2.x + u_xlat16_24;
				#if _FRONT1TEX_POLAR
					u_xlat16_4.xy = u_xlat16_4.xy * float2(float2(_Front1TexDistotion, _Front1TexDistotion)) + u_xlat5.xz;
					u_xlat10_11.xyz = tex2D(_Front1Tex, u_xlat16_4.xy).xyz;
				#elif _FRONT1TEX_SCROLL || _FRONT1TEX_ROTATE
					u_xlat16_4.xy = u_xlat16_4.xy * float2(float2(_Front1TexDistotion, _Front1TexDistotion)) + i.texcoord1.xy;
					u_xlat10_11.xyz = tex2D(_Front1Tex, u_xlat16_4.xy).xyz;
				#endif
				u_xlat16_11.xyz = u_xlat10_11.xyz * _Front1TexColor.xyz;
				
				u_xlat16_0.xyz = u_xlat16_11.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;
				u_xlat16_0.xyz = u_xlat16_10.xyz * u_xlat10_3.xxx + u_xlat16_0.xyz;

				float3 u_xlat10_2, u_xlat10_12, u_xlat16_9;
				float2 u_xlat16_14;
				u_xlat10_2.xyz = tex2D(_FrameTex, i.texcoord0.xy).xyz;
				u_xlat16_4.xyz = (-u_xlat16_0.xyz) + u_xlat10_2.xyz;
				u_xlat10_2.x = tex2D(_FrameMaskTex, i.texcoord0.xy).x;
				u_xlat16_0.xyz = u_xlat10_2.xxx * u_xlat16_4.xyz + u_xlat16_0.xyz;
				u_xlat10_2.x = tex2D(_KiraMaskTex, i.texcoord0.xy).x;
				float u_xlat16_30 = (-u_xlat10_2.x) * _IsKira + 1.0;
				u_xlat16_2.x = u_xlat10_2.x * _IsKira;
				u_xlat16_0.xyz = float3(u_xlat16_30, u_xlat16_30, u_xlat16_30) * u_xlat16_0.xyz;
				u_xlat16_30 = i.texcoord5.w * i.texcoord5.z;
				u_xlat16_1 = float4(u_xlat16_30, u_xlat16_30, u_xlat16_30, u_xlat16_30) * i.texcoord5.yxyx;
				u_xlat16_4.xy = u_xlat16_1.ww * float2(0.412999988, 0.300000012);
				u_xlat16_30 = i.texcoord5.z * 0.298999995 + (-u_xlat16_4.y);
				u_xlat16_4.x = i.texcoord5.z * 0.587000012 + u_xlat16_4.x;
				u_xlat16_4.x = u_xlat16_1.z * 0.0350000001 + u_xlat16_4.x;
				u_xlat16_30 = u_xlat16_1.x * 1.25 + u_xlat16_30;
				u_xlat16_14.xy = u_xlat16_1.yw * float2(0.588, 0.885999978);
				u_xlat16_14.x = i.texcoord5.z * 0.587000012 + (-u_xlat16_14.x);
				u_xlat16_24.x = i.texcoord5.z * 0.114 + u_xlat16_14.y;
				u_xlat16_24.x = (-u_xlat16_1.z) * 0.202999994 + u_xlat16_24.x;
				u_xlat16_14.x = (-u_xlat16_1.z) * 1.04999995 + u_xlat16_14.x;
				u_xlat10_12.xyz = tex2D(_Kira3Tex, i.texcoord0.xy).xyz;
				float u_xlat16_34 = u_xlat10_12.y * u_xlat16_14.x;
				u_xlat16_34 = u_xlat16_30 * u_xlat10_12.x + u_xlat16_34;
				u_xlat16_34 = u_xlat16_24.x * u_xlat10_12.z + u_xlat16_34;
				u_xlat16_7.z = u_xlat16_34 * u_xlat16_2.x + u_xlat16_0.z;
				u_xlat16_8.xy = u_xlat16_1.ww * float2(0.700999975, 0.587000012);
				u_xlat16_20 = i.texcoord5.z * 0.298999995 + u_xlat16_8.x;
				u_xlat16_34 = i.texcoord5.z * 0.587000012 + (-u_xlat16_8.y);
				u_xlat16_34 = u_xlat16_1.z * 0.330000013 + u_xlat16_34;
				u_xlat16_20 = u_xlat16_1.z * 0.167999998 + u_xlat16_20;
				float u_xlat16_37 = u_xlat10_12.y * u_xlat16_34;
				u_xlat16_37 = u_xlat16_20 * u_xlat10_12.x + u_xlat16_37;
				u_xlat16_8.xy = u_xlat16_1.ww * float2(0.114, 0.298999995);
				u_xlat16_8.xy = i.texcoord5.zz * float2(0.114, 0.298999995) + (-u_xlat16_8.xy);
				u_xlat16_18.xy = (-u_xlat16_1.zz) * float2(0.497000009, 0.328000009) + u_xlat16_8.xy;
				u_xlat16_8.x = u_xlat16_1.z * 0.291999996 + u_xlat16_8.x;
				u_xlat16_37 = u_xlat16_18.x * u_xlat10_12.z + u_xlat16_37;
				u_xlat16_7.x = u_xlat16_37 * u_xlat16_2.x + u_xlat16_0.x;
				u_xlat16_0.x = u_xlat10_12.x * u_xlat16_18.y;
				u_xlat16_0.x = u_xlat16_4.x * u_xlat10_12.y + u_xlat16_0.x;
				u_xlat16_0.x = u_xlat16_8.x * u_xlat10_12.z + u_xlat16_0.x;
				u_xlat16_7.y = u_xlat16_0.x * u_xlat16_2.x + u_xlat16_0.y;
				u_xlat10_2.xyz = tex2D(_KiraTex, i.texcoord0.xy).xyz;
				u_xlat16_0.x = u_xlat10_2.y * u_xlat16_14.x;
				u_xlat16_0.x = u_xlat16_30 * u_xlat10_2.x + u_xlat16_0.x;
				u_xlat16_9.z = u_xlat16_24.x * u_xlat10_2.z + u_xlat16_0.x;
				u_xlat16_0.x = u_xlat10_2.y * u_xlat16_34;
				u_xlat16_0.x = u_xlat16_20 * u_xlat10_2.x + u_xlat16_0.x;
				u_xlat16_9.x = u_xlat16_18.x * u_xlat10_2.z + u_xlat16_0.x;
				u_xlat16_0.x = u_xlat10_2.x * u_xlat16_18.y;
				u_xlat16_0.x = u_xlat16_4.x * u_xlat10_2.y + u_xlat16_0.x;
				u_xlat16_9.y = u_xlat16_8.x * u_xlat10_2.z + u_xlat16_0.x;
				u_xlat10_2.xyz = tex2D(_Kira2Tex, i.texcoord4.xy).xyz;
				u_xlat16_0.xyz = u_xlat10_2.xyz + u_xlat16_9.xyz;
				u_xlat16_0.xyz = u_xlat16_0.xyz * float3(_IsKira, _IsKira, _IsKira) + u_xlat16_7.xyz;

				float4 SV_Target0;
				SV_Target0.xyz = u_xlat16_0.xyz * i.color0.xyz;
				SV_Target0.w = i.color0.w;
				return SV_Target0;
			}

/*
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_FRONT2TEX_ROTATE" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_ROTATE" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_DISTOTIONTEX_POLAR" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_FRONT2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT2TEX_ROTATE" "_FRONT1TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_ROTATE" "_FRONT2TEX_SCROLL" "_FRONT1TEX_SCROLL" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_BACK2TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_BACK1TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_BACK1TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_BACK1TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK2TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_FRONT1TEX_POLAR" "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_BACK1TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_BACK1TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_BACK1TEX_ROTATE" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_DISTOTIONTEX_SCROLL" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK1TEX_SCROLL" "_BACK2TEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_ROTATE" "_DISTOTIONTEX_POLAR" "_FRONT1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_FRONT1TEX_POLAR" "_DISTOTIONTEX_POLAR" "_BACK1TEX_SCROLL" "_BACK2TEX_SCROLL" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "_BACK1TEX_POLAR" "_FRONT1TEX_ROTATE" "_BACK2TEX_ROTATE" "_DISTOTIONTEX_ROTATE" "_FRONT2TEX_POLAR" }
					"!!GLES"
				}
			}
		}
	}
}
*/
			ENDCG
		}
	}
}