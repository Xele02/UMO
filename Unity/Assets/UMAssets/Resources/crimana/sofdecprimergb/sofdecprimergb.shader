Shader "CriMana/SofdecPrimeRgb" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		[HideInInspector] _MovieTexture_ST ("MovieTexture_ST", Vector) = (1,1,0,0)
		[HideInInspector] _TextureRGBA ("TextureRGBA", 2D) = "white" {}
		[HideInInspector] _SrcBlendMode ("SrcBlendMode", Float) = 0
		[HideInInspector] _DstBlendMode ("DstBlendMode", Float) = 0
		[HideInInspector] _CullMode ("CullMode", Float) = 2
		[HideInInspector] _ZWriteMode ("ZWriteMode", Float) = 1
	}
	SubShader {
		Tags { "PreviewType" = "Plane" "QUEUE" = "Transparent" }
		Pass {
			Tags { "PreviewType" = "Plane" "QUEUE" = "Transparent" }
			Blend Zero Zero, Zero Zero
			ZWrite Off
			Cull Off
			GpuProgramID 27042
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    SV_Target0.w = u_xlat16_0 * u_xlat10_1.w;
					    SV_Target0.xyz = u_xlat10_1.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    SV_Target0.w = u_xlat16_0 * u_xlat10_1.w;
					    SV_Target0.xyz = u_xlat10_1.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    SV_Target0.w = u_xlat16_0 * u_xlat10_1.w;
					    SV_Target0.xyz = u_xlat10_1.xyz;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    SV_Target0.w = u_xlat16_0 * u_xlat10_1.w;
					    SV_Target0.xyz = u_xlat10_1.zyx;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    SV_Target0.w = u_xlat16_0 * u_xlat10_1.w;
					    SV_Target0.xyz = u_xlat10_1.zyx;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    SV_Target0.w = u_xlat16_0 * u_xlat10_1.w;
					    SV_Target0.xyz = u_xlat10_1.zyx;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					float u_xlat7;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat7 = u_xlat10_1.w * vs_COLOR0.w;
					    SV_Target0.xyz = u_xlat10_1.xyz;
					    SV_Target0.w = u_xlat16_0 * u_xlat7;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					float u_xlat7;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat7 = u_xlat10_1.w * vs_COLOR0.w;
					    SV_Target0.xyz = u_xlat10_1.xyz;
					    SV_Target0.w = u_xlat16_0 * u_xlat7;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					float u_xlat7;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat7 = u_xlat10_1.w * vs_COLOR0.w;
					    SV_Target0.xyz = u_xlat10_1.xyz;
					    SV_Target0.w = u_xlat16_0 * u_xlat7;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					float u_xlat7;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat7 = u_xlat10_1.w * vs_COLOR0.w;
					    SV_Target0.xyz = u_xlat10_1.zyx;
					    SV_Target0.w = u_xlat16_0 * u_xlat7;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					float u_xlat7;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat7 = u_xlat10_1.w * vs_COLOR0.w;
					    SV_Target0.xyz = u_xlat10_1.zyx;
					    SV_Target0.w = u_xlat16_0 * u_xlat7;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					mediump float u_xlat16_0;
					lowp vec4 u_xlat10_1;
					float u_xlat7;
					void main()
					{
					    u_xlat16_0 = (-_Transparency) + 1.0;
					    u_xlat10_1 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat7 = u_xlat10_1.w * vs_COLOR0.w;
					    SV_Target0.xyz = u_xlat10_1.zyx;
					    SV_Target0.w = u_xlat16_0 * u_xlat7;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0.w * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0.w * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0.w * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.zyx, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0.w * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.zyx, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0.w * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.zyx, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0.w * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					float u_xlat0;
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat0 = u_xlat10_0.w * vs_COLOR0.w;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0 * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					float u_xlat0;
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat0 = u_xlat10_0.w * vs_COLOR0.w;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0 * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					float u_xlat0;
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat0 = u_xlat10_0.w * vs_COLOR0.w;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0 * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					float u_xlat0;
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.zyx, vec3(0.0, 0.0, 0.0));
					    u_xlat0 = u_xlat10_0.w * vs_COLOR0.w;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0 * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					float u_xlat0;
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.zyx, vec3(0.0, 0.0, 0.0));
					    u_xlat0 = u_xlat10_0.w * vs_COLOR0.w;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0 * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy;
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
					uniform 	mediump float _Transparency;
					uniform lowp sampler2D _TextureRGBA;
					varying mediump vec2 vs_TEXCOORD0;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					float u_xlat0;
					lowp vec4 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureRGBA, vs_TEXCOORD0.xy);
					    u_xlat16_1.xyz = max(u_xlat10_0.zyx, vec3(0.0, 0.0, 0.0));
					    u_xlat0 = u_xlat10_0.w * vs_COLOR0.w;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0 * u_xlat16_1.x;
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
					Keywords { "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" "CRI_SWITCH" }
					"!!GLES"
				}
			}
		}
	}
}