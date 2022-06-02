Shader "CriMana/SofdecPrimeYuv" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		[HideInInspector] _MovieTexture_ST ("MovieTexture_ST", Vector) = (1,1,0,0)
		[HideInInspector] _MovieChromaTexture_ST ("MovieChromaTexture_ST", Vector) = (1,1,0,0)
		[HideInInspector] _MovieAlphaTexture_ST ("MovieAlphaTexture_ST", Vector) = (1,1,0,0)
		[HideInInspector] _TextureY ("TextureY", 2D) = "white" {}
		[HideInInspector] _TextureU ("TextureU", 2D) = "white" {}
		[HideInInspector] _TextureV ("TextureV", 2D) = "white" {}
		[HideInInspector] _TextureA ("TextureA", 2D) = "white" {}
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
			GpuProgramID 42886
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    SV_Target0.w = (-_Transparency) + 1.0;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    SV_Target0.w = (-_Transparency) + 1.0;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    SV_Target0.w = (-_Transparency) + 1.0;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    SV_Target0.w = (-_Transparency) + 1.0;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    SV_Target0.w = (-_Transparency) + 1.0;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    SV_Target0.w = (-_Transparency) + 1.0;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat16_1.x * vs_COLOR0.w;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat16_1.x * vs_COLOR0.w;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat16_1.x * vs_COLOR0.w;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat16_1.x * vs_COLOR0.w;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat16_1.x * vs_COLOR0.w;
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
					uniform 	vec4 _MovieChromaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat16_1.x * vs_COLOR0.w;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0 * u_xlat16_1.x;
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0 * u_xlat16_1.x;
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0 * u_xlat16_1.x;
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0 * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0 * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat10_0 * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat0.x = u_xlat10_0 * vs_COLOR0.w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0.x * u_xlat16_1.x;
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat0.x = u_xlat10_0 * vs_COLOR0.w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0.x * u_xlat16_1.x;
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					void main()
					{
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat0.x = u_xlat10_0 * vs_COLOR0.w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0.x * u_xlat16_1.x;
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    SV_Target0.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    SV_Target0.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    SV_Target0.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat0.x = u_xlat10_0 * vs_COLOR0.w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0.x * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat0.x = u_xlat10_0 * vs_COLOR0.w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0.x * u_xlat16_1.x;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	vec4 _MovieTexture_ST;
					uniform 	vec4 _MovieChromaTexture_ST;
					uniform 	vec4 _MovieAlphaTexture_ST;
					attribute highp vec4 in_POSITION0;
					attribute mediump vec2 in_TEXCOORD0;
					attribute highp vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					mediump  vec4 phase0_Output0_1;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
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
					    u_xlat1.xy = u_xlat0.xy * _MovieTexture_ST.xy + _MovieTexture_ST.zw;
					    u_xlat1.zw = u_xlat0.xy * _MovieChromaTexture_ST.xy + _MovieChromaTexture_ST.zw;
					    u_xlat0.xy = u_xlat0.xy * _MovieAlphaTexture_ST.xy + _MovieAlphaTexture_ST.zw;
					    vs_TEXCOORD2.xy = u_xlat0.xy;
					    phase0_Output0_1 = u_xlat1;
					    vs_COLOR0 = in_COLOR0;
					vs_TEXCOORD0 = phase0_Output0_1.xy;
					vs_TEXCOORD1 = phase0_Output0_1.zw;
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
					uniform lowp sampler2D _TextureY;
					uniform lowp sampler2D _TextureU;
					uniform lowp sampler2D _TextureV;
					uniform lowp sampler2D _TextureA;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD1;
					varying mediump vec2 vs_TEXCOORD2;
					varying highp vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					lowp float u_xlat10_0;
					mediump vec3 u_xlat16_1;
					mediump vec3 u_xlat16_2;
					void main()
					{
					    u_xlat0.x = texture2D(_TextureY, vs_TEXCOORD0.xy).w;
					    u_xlat0.y = texture2D(_TextureU, vs_TEXCOORD1.xy).w;
					    u_xlat0.z = texture2D(_TextureV, vs_TEXCOORD1.xy).w;
					    u_xlat16_1.xyz = u_xlat0.xyz + vec3(-0.0627499968, -0.50195998, -0.50195998);
					    u_xlat16_2.x = dot(vec2(1.16437995, 1.59603), u_xlat16_1.xz);
					    u_xlat16_2.y = dot(vec3(1.16437995, -0.391759992, -0.812969983), u_xlat16_1.xyz);
					    u_xlat16_2.z = dot(vec2(1.16437995, 2.01723003), u_xlat16_1.xy);
					    u_xlat16_1.xyz = max(u_xlat16_2.xyz, vec3(0.0, 0.0, 0.0));
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(2.20000005, 2.20000005, 2.20000005);
					    SV_Target0.xyz = exp2(u_xlat16_1.xyz);
					    u_xlat10_0 = texture2D(_TextureA, vs_TEXCOORD2.xy).w;
					    u_xlat0.x = u_xlat10_0 * vs_COLOR0.w;
					    u_xlat16_1.x = (-_Transparency) + 1.0;
					    SV_Target0.w = u_xlat0.x * u_xlat16_1.x;
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
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES"
				}
			}
		}
	}
}