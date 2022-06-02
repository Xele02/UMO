Shader "MCRS/Transparent_Colored_Blur" {
	Properties {
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
		_Distance ("Distance", Float) = 0.002
		_Sampling ("Sampling", Range(1, 10)) = 2
	}
	SubShader {
		LOD 100
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			LOD 100
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			Cull Off
			Offset -1, -1
			Fog {
				Mode Off
			}
			GpuProgramID 29665
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute mediump vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
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
					uniform 	float _Distance;
					uniform 	float _Sampling;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					vec4 u_xlat3;
					mediump vec4 u_xlat16_4;
					vec2 u_xlat5;
					mediump vec4 u_xlat16_5;
					lowp vec4 u_xlat10_5;
					bool u_xlatb5;
					mediump vec4 u_xlat16_6;
					lowp vec4 u_xlat10_6;
					lowp vec4 u_xlat10_7;
					float u_xlat26;
					void main()
					{
					    u_xlat10_0 = texture2D(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0 * vs_COLOR0;
					    u_xlat1.y = vs_TEXCOORD0.y;
					    u_xlat2.x = vs_TEXCOORD0.x;
					    u_xlat3.xw = vs_TEXCOORD0.xy;
					    u_xlat16_4 = u_xlat16_0;
					    u_xlat26 = 0.0;
					    for(int u_xlati_while_true_0 = 0 ; u_xlati_while_true_0 < 0x7FFF ; u_xlati_while_true_0++){
					        u_xlatb5 = u_xlat26>=_Sampling;
					        if(u_xlatb5){break;}
					        u_xlat26 = u_xlat26 + 1.0;
					        u_xlat5.xy = vec2(_Distance) * vec2(u_xlat26) + vs_TEXCOORD0.xy;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat5.xy);
					        u_xlat16_6 = u_xlat10_6 * vs_COLOR0 + u_xlat16_4;
					        u_xlat1.x = u_xlat5.x;
					        u_xlat10_7 = texture2D(_MainTex, u_xlat1.xy);
					        u_xlat16_6 = u_xlat10_7 * vs_COLOR0 + u_xlat16_6;
					        u_xlat1.zw = (-vec2(_Distance)) * vec2(u_xlat26) + vs_TEXCOORD0.yx;
					        u_xlat10_7 = texture2D(_MainTex, u_xlat1.xz);
					        u_xlat16_6 = u_xlat10_7 * vs_COLOR0 + u_xlat16_6;
					        u_xlat2.y = u_xlat5.y;
					        u_xlat10_5 = texture2D(_MainTex, u_xlat2.xy);
					        u_xlat16_5 = u_xlat10_5 * vs_COLOR0 + u_xlat16_6;
					        u_xlat3.y = u_xlat1.z;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat3.xy);
					        u_xlat16_5 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat2.z = u_xlat1.w;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat2.zy);
					        u_xlat16_5 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat3.z = u_xlat2.z;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat3.zw);
					        u_xlat16_5 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat1.wz);
					        u_xlat16_4 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat16_4 = u_xlat16_4;
					    }
					    u_xlat0.x = u_xlat26 * 8.0 + 1.0;
					    u_xlat0 = u_xlat16_4 / u_xlat0.xxxx;
					    SV_Target0 = u_xlat0;
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
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute mediump vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
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
					uniform 	float _Distance;
					uniform 	float _Sampling;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					vec4 u_xlat3;
					mediump vec4 u_xlat16_4;
					vec2 u_xlat5;
					mediump vec4 u_xlat16_5;
					lowp vec4 u_xlat10_5;
					bool u_xlatb5;
					mediump vec4 u_xlat16_6;
					lowp vec4 u_xlat10_6;
					lowp vec4 u_xlat10_7;
					float u_xlat26;
					void main()
					{
					    u_xlat10_0 = texture2D(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0 * vs_COLOR0;
					    u_xlat1.y = vs_TEXCOORD0.y;
					    u_xlat2.x = vs_TEXCOORD0.x;
					    u_xlat3.xw = vs_TEXCOORD0.xy;
					    u_xlat16_4 = u_xlat16_0;
					    u_xlat26 = 0.0;
					    for(int u_xlati_while_true_0 = 0 ; u_xlati_while_true_0 < 0x7FFF ; u_xlati_while_true_0++){
					        u_xlatb5 = u_xlat26>=_Sampling;
					        if(u_xlatb5){break;}
					        u_xlat26 = u_xlat26 + 1.0;
					        u_xlat5.xy = vec2(_Distance) * vec2(u_xlat26) + vs_TEXCOORD0.xy;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat5.xy);
					        u_xlat16_6 = u_xlat10_6 * vs_COLOR0 + u_xlat16_4;
					        u_xlat1.x = u_xlat5.x;
					        u_xlat10_7 = texture2D(_MainTex, u_xlat1.xy);
					        u_xlat16_6 = u_xlat10_7 * vs_COLOR0 + u_xlat16_6;
					        u_xlat1.zw = (-vec2(_Distance)) * vec2(u_xlat26) + vs_TEXCOORD0.yx;
					        u_xlat10_7 = texture2D(_MainTex, u_xlat1.xz);
					        u_xlat16_6 = u_xlat10_7 * vs_COLOR0 + u_xlat16_6;
					        u_xlat2.y = u_xlat5.y;
					        u_xlat10_5 = texture2D(_MainTex, u_xlat2.xy);
					        u_xlat16_5 = u_xlat10_5 * vs_COLOR0 + u_xlat16_6;
					        u_xlat3.y = u_xlat1.z;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat3.xy);
					        u_xlat16_5 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat2.z = u_xlat1.w;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat2.zy);
					        u_xlat16_5 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat3.z = u_xlat2.z;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat3.zw);
					        u_xlat16_5 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat1.wz);
					        u_xlat16_4 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat16_4 = u_xlat16_4;
					    }
					    u_xlat0.x = u_xlat26 * 8.0 + 1.0;
					    u_xlat0 = u_xlat16_4 / u_xlat0.xxxx;
					    SV_Target0 = u_xlat0;
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
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					attribute mediump vec4 in_COLOR0;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec4 vs_COLOR0;
					vec4 u_xlat0;
					vec4 u_xlat1;
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
					    u_xlat0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
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
					uniform 	float _Distance;
					uniform 	float _Sampling;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					varying mediump vec4 vs_COLOR0;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					mediump vec4 u_xlat16_0;
					lowp vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec3 u_xlat2;
					vec4 u_xlat3;
					mediump vec4 u_xlat16_4;
					vec2 u_xlat5;
					mediump vec4 u_xlat16_5;
					lowp vec4 u_xlat10_5;
					bool u_xlatb5;
					mediump vec4 u_xlat16_6;
					lowp vec4 u_xlat10_6;
					lowp vec4 u_xlat10_7;
					float u_xlat26;
					void main()
					{
					    u_xlat10_0 = texture2D(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat16_0 = u_xlat10_0 * vs_COLOR0;
					    u_xlat1.y = vs_TEXCOORD0.y;
					    u_xlat2.x = vs_TEXCOORD0.x;
					    u_xlat3.xw = vs_TEXCOORD0.xy;
					    u_xlat16_4 = u_xlat16_0;
					    u_xlat26 = 0.0;
					    for(int u_xlati_while_true_0 = 0 ; u_xlati_while_true_0 < 0x7FFF ; u_xlati_while_true_0++){
					        u_xlatb5 = u_xlat26>=_Sampling;
					        if(u_xlatb5){break;}
					        u_xlat26 = u_xlat26 + 1.0;
					        u_xlat5.xy = vec2(_Distance) * vec2(u_xlat26) + vs_TEXCOORD0.xy;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat5.xy);
					        u_xlat16_6 = u_xlat10_6 * vs_COLOR0 + u_xlat16_4;
					        u_xlat1.x = u_xlat5.x;
					        u_xlat10_7 = texture2D(_MainTex, u_xlat1.xy);
					        u_xlat16_6 = u_xlat10_7 * vs_COLOR0 + u_xlat16_6;
					        u_xlat1.zw = (-vec2(_Distance)) * vec2(u_xlat26) + vs_TEXCOORD0.yx;
					        u_xlat10_7 = texture2D(_MainTex, u_xlat1.xz);
					        u_xlat16_6 = u_xlat10_7 * vs_COLOR0 + u_xlat16_6;
					        u_xlat2.y = u_xlat5.y;
					        u_xlat10_5 = texture2D(_MainTex, u_xlat2.xy);
					        u_xlat16_5 = u_xlat10_5 * vs_COLOR0 + u_xlat16_6;
					        u_xlat3.y = u_xlat1.z;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat3.xy);
					        u_xlat16_5 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat2.z = u_xlat1.w;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat2.zy);
					        u_xlat16_5 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat3.z = u_xlat2.z;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat3.zw);
					        u_xlat16_5 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat10_6 = texture2D(_MainTex, u_xlat1.wz);
					        u_xlat16_4 = u_xlat10_6 * vs_COLOR0 + u_xlat16_5;
					        u_xlat16_4 = u_xlat16_4;
					    }
					    u_xlat0.x = u_xlat26 * 8.0 + 1.0;
					    u_xlat0 = u_xlat16_4 / u_xlat0.xxxx;
					    SV_Target0 = u_xlat0;
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
		}
	}
}