Shader "Adv/Effect/GaussianBlur" {
	Properties {
		_MainTex ("MainTex (RGB)", 2D) = "white" {}
		_GaussParam0 ("GaussParam0", Vector) = (1,0,0,0)
		_GaussParam1 ("GaussParam1", Vector) = (0,0,0,0)
		_GaussParam2 ("GaussParam2", Vector) = (0,0,0,0)
		_GaussParam3 ("GaussParam3", Vector) = (0,0,0,0)
		_TexelParam ("TexelParam", Vector) = (1,1,0,0)
		_SamplingLevel ("SamplingLevel", Float) = 8
		_UvOffset ("UvOffset", Vector) = (0,0,0,0)
	}
	SubShader {
		Tags { "QUEUE" = "Overlay" }
		Pass {
			Tags { "QUEUE" = "Overlay" }
			ZWrite Off
			GpuProgramID 43388
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
					varying mediump vec2 vs_TEXCOORD0;
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
					vec4 ImmCB_0_0_0[4];
					uniform 	vec4 _GaussParam0;
					uniform 	vec4 _GaussParam1;
					uniform 	vec4 _GaussParam2;
					uniform 	vec4 _GaussParam3;
					uniform 	int _SamplingLevel;
					uniform 	vec4 _MainTex_TexelSize;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec2 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					vec3 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_3;
					bool u_xlatb3;
					mediump float u_xlat16_4;
					float u_xlat5;
					ivec2 u_xlati5;
					lowp vec3 u_xlat10_6;
					vec3 u_xlat7;
					mediump vec3 u_xlat16_7;
					vec3 u_xlat8;
					lowp vec3 u_xlat10_8;
					ivec2 u_xlati8;
					bool u_xlatb8;
					vec3 u_xlat9;
					mediump vec3 u_xlat16_9;
					vec3 u_xlat10;
					lowp vec3 u_xlat10_10;
					mediump vec2 u_xlat16_11;
					lowp vec3 u_xlat10_12;
					bool u_xlatb16;
					mediump vec2 u_xlat16_17;
					vec3 u_xlat18;
					float u_xlat21;
					bool u_xlatb21;
					mediump vec2 u_xlat16_26;
					mediump vec2 u_xlat16_27;
					bool u_xlatb34;
					int u_xlati39;
					mediump float u_xlat16_46;
					float u_xlat47;
					bool u_xlatb47;
					#define UNITY_DYNAMIC_INDEX_ES2 0
					
					
					
					vec4 ImmCB_0_0_0DynamicIndex(int i){
					#if UNITY_DYNAMIC_INDEX_ES2
					    return ImmCB_0_0_0[i];
					#else
					#define d_ar ImmCB_0_0_0
					    if (i <= 0) return d_ar[0]; else if (i == 1) return d_ar[1]; else if (i == 2) return d_ar[2]; else if (i == 3) return d_ar[3];
					    return d_ar[0];
					#undef d_ar
					#endif
					}
					
					void main()
					{
						ImmCB_0_0_0[0] = vec4(1.0, 0.0, 0.0, 0.0);
						ImmCB_0_0_0[1] = vec4(0.0, 1.0, 0.0, 0.0);
						ImmCB_0_0_0[2] = vec4(0.0, 0.0, 1.0, 0.0);
						ImmCB_0_0_0[3] = vec4(0.0, 0.0, 0.0, 1.0);
					    u_xlat10_0.xyz = texture2D(_MainTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat0.xyz = u_xlat10_0.xyz * _GaussParam0.xxx;
					    u_xlat16_1.y = float(0.0);
					    u_xlat16_27.y = float(0.0);
					    u_xlat16_2.xyz = u_xlat0.xyz;
					    u_xlati39 = 1;
					    for(int u_xlati_while_true_0 = 0 ; u_xlati_while_true_0 < 0x7FFF ; u_xlati_while_true_0++){
					        u_xlatb3 = u_xlati39<4;
					        u_xlatb16 = u_xlati39<_SamplingLevel;
					        u_xlatb3 = u_xlatb16 && u_xlatb3;
					        if(!u_xlatb3){break;}
					        u_xlat16_4 = float(u_xlati39);
					        u_xlat16_1.x = u_xlat16_4 * _MainTex_TexelSize.x;
					        u_xlat16_17.xy = u_xlat16_1.xy + vs_TEXCOORD0.xy;
					        u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat5 = dot(_GaussParam0, ImmCB_0_0_0DynamicIndex(u_xlati39));
					        u_xlat18.xyz = u_xlat10_3.xyz * vec3(u_xlat5) + u_xlat16_2.xyz;
					        u_xlat16_27.x = u_xlat16_4 * (-_MainTex_TexelSize.x);
					        u_xlat16_1.xz = u_xlat16_27.xy + vs_TEXCOORD0.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_1.xz).xyz;
					        u_xlat2.xyz = u_xlat10_6.xyz * vec3(u_xlat5) + u_xlat18.xyz;
					        u_xlati39 = u_xlati39 + 1;
					        u_xlat16_2.xyz = u_xlat2.xyz;
					    }
					    u_xlat16_0.y = float(0.0);
					    u_xlat16_26.y = float(0.0);
					    u_xlat16_7.xyz = u_xlat16_2.xyz;
					    u_xlati5.x = 4;
					    for(int u_xlati_while_true_1 = 0 ; u_xlati_while_true_1 < 0x7FFF ; u_xlati_while_true_1++){
					        u_xlatb8 = u_xlati5.x<8;
					        u_xlatb21 = u_xlati5.x<_SamplingLevel;
					        u_xlatb8 = u_xlatb21 && u_xlatb8;
					        if(!u_xlatb8){break;}
					        u_xlat16_46 = float(u_xlati5.x);
					        u_xlat16_0.x = u_xlat16_46 * _MainTex_TexelSize.x;
					        u_xlat16_9.xy = u_xlat16_0.xy + vs_TEXCOORD0.xy;
					        u_xlat10_8.xyz = texture2D(_MainTex, u_xlat16_9.xy).xyz;
					        u_xlati5.xy = u_xlati5.xx + ivec2(1, -4);
					        u_xlat47 = dot(_GaussParam1, ImmCB_0_0_0DynamicIndex(u_xlati5.y));
					        u_xlat8.xyz = u_xlat10_8.xyz * vec3(u_xlat47) + u_xlat16_7.xyz;
					        u_xlat16_26.x = u_xlat16_46 * (-_MainTex_TexelSize.x);
					        u_xlat16_9.xy = u_xlat16_26.xy + vs_TEXCOORD0.xy;
					        u_xlat10_10.xyz = texture2D(_MainTex, u_xlat16_9.xy).xyz;
					        u_xlat7.xyz = u_xlat10_10.xyz * vec3(u_xlat47) + u_xlat8.xyz;
					        u_xlat16_7.xyz = u_xlat7.xyz;
					    }
					    u_xlat16_0.y = float(0.0);
					    u_xlat16_26.y = float(0.0);
					    u_xlat16_9.xyz = u_xlat16_7.xyz;
					    u_xlati8.x = 8;
					    for(int u_xlati_while_true_2 = 0 ; u_xlati_while_true_2 < 0x7FFF ; u_xlati_while_true_2++){
					        u_xlatb34 = u_xlati8.x<12;
					        u_xlatb47 = u_xlati8.x<_SamplingLevel;
					        u_xlatb34 = u_xlatb47 && u_xlatb34;
					        if(!u_xlatb34){break;}
					        u_xlat16_46 = float(u_xlati8.x);
					        u_xlat16_0.x = u_xlat16_46 * _MainTex_TexelSize.x;
					        u_xlat16_11.xy = u_xlat16_0.xy + vs_TEXCOORD0.xy;
					        u_xlat10_10.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlati8.xy = u_xlati8.xx + ivec2(1, -8);
					        u_xlat21 = dot(_GaussParam2, ImmCB_0_0_0DynamicIndex(u_xlati8.y));
					        u_xlat10.xyz = u_xlat10_10.xyz * vec3(u_xlat21) + u_xlat16_9.xyz;
					        u_xlat16_26.x = u_xlat16_46 * (-_MainTex_TexelSize.x);
					        u_xlat16_11.xy = u_xlat16_26.xy + vs_TEXCOORD0.xy;
					        u_xlat10_12.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlat9.xyz = u_xlat10_12.xyz * vec3(u_xlat21) + u_xlat10.xyz;
					        u_xlat16_9.xyz = u_xlat9.xyz;
					    }
					    u_xlat16_0.y = float(0.0);
					    u_xlat16_26.y = float(0.0);
					    u_xlat16_7.xyz = u_xlat16_9.xyz;
					    u_xlati8.x = 12;
					    for(int u_xlati_while_true_3 = 0 ; u_xlati_while_true_3 < 0x7FFF ; u_xlati_while_true_3++){
					        u_xlatb34 = u_xlati8.x<16;
					        u_xlatb47 = u_xlati8.x<_SamplingLevel;
					        u_xlatb34 = u_xlatb47 && u_xlatb34;
					        if(!u_xlatb34){break;}
					        u_xlat16_46 = float(u_xlati8.x);
					        u_xlat16_0.x = u_xlat16_46 * _MainTex_TexelSize.x;
					        u_xlat16_11.xy = u_xlat16_0.xy + vs_TEXCOORD0.xy;
					        u_xlat10_10.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlati8.xy = u_xlati8.xx + ivec2(1, -12);
					        u_xlat21 = dot(_GaussParam3, ImmCB_0_0_0DynamicIndex(u_xlati8.y));
					        u_xlat10.xyz = u_xlat10_10.xyz * vec3(u_xlat21) + u_xlat16_7.xyz;
					        u_xlat16_26.x = u_xlat16_46 * (-_MainTex_TexelSize.x);
					        u_xlat16_11.xy = u_xlat16_26.xy + vs_TEXCOORD0.xy;
					        u_xlat10_12.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlat7.xyz = u_xlat10_12.xyz * vec3(u_xlat21) + u_xlat10.xyz;
					        u_xlat16_7.xyz = u_xlat7.xyz;
					    }
					    SV_Target0.xyz = u_xlat16_7.xyz;
					    SV_Target0.w = 1.0;
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
					varying mediump vec2 vs_TEXCOORD0;
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
					vec4 ImmCB_0_0_0[4];
					uniform 	vec4 _GaussParam0;
					uniform 	vec4 _GaussParam1;
					uniform 	vec4 _GaussParam2;
					uniform 	vec4 _GaussParam3;
					uniform 	int _SamplingLevel;
					uniform 	vec4 _MainTex_TexelSize;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec2 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					vec3 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_3;
					bool u_xlatb3;
					mediump float u_xlat16_4;
					float u_xlat5;
					ivec2 u_xlati5;
					lowp vec3 u_xlat10_6;
					vec3 u_xlat7;
					mediump vec3 u_xlat16_7;
					vec3 u_xlat8;
					lowp vec3 u_xlat10_8;
					ivec2 u_xlati8;
					bool u_xlatb8;
					vec3 u_xlat9;
					mediump vec3 u_xlat16_9;
					vec3 u_xlat10;
					lowp vec3 u_xlat10_10;
					mediump vec2 u_xlat16_11;
					lowp vec3 u_xlat10_12;
					bool u_xlatb16;
					mediump vec2 u_xlat16_17;
					vec3 u_xlat18;
					float u_xlat21;
					bool u_xlatb21;
					mediump vec2 u_xlat16_26;
					mediump vec2 u_xlat16_27;
					bool u_xlatb34;
					int u_xlati39;
					mediump float u_xlat16_46;
					float u_xlat47;
					bool u_xlatb47;
					#define UNITY_DYNAMIC_INDEX_ES2 0
					
					
					
					vec4 ImmCB_0_0_0DynamicIndex(int i){
					#if UNITY_DYNAMIC_INDEX_ES2
					    return ImmCB_0_0_0[i];
					#else
					#define d_ar ImmCB_0_0_0
					    if (i <= 0) return d_ar[0]; else if (i == 1) return d_ar[1]; else if (i == 2) return d_ar[2]; else if (i == 3) return d_ar[3];
					    return d_ar[0];
					#undef d_ar
					#endif
					}
					
					void main()
					{
						ImmCB_0_0_0[0] = vec4(1.0, 0.0, 0.0, 0.0);
						ImmCB_0_0_0[1] = vec4(0.0, 1.0, 0.0, 0.0);
						ImmCB_0_0_0[2] = vec4(0.0, 0.0, 1.0, 0.0);
						ImmCB_0_0_0[3] = vec4(0.0, 0.0, 0.0, 1.0);
					    u_xlat10_0.xyz = texture2D(_MainTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat0.xyz = u_xlat10_0.xyz * _GaussParam0.xxx;
					    u_xlat16_1.y = float(0.0);
					    u_xlat16_27.y = float(0.0);
					    u_xlat16_2.xyz = u_xlat0.xyz;
					    u_xlati39 = 1;
					    for(int u_xlati_while_true_0 = 0 ; u_xlati_while_true_0 < 0x7FFF ; u_xlati_while_true_0++){
					        u_xlatb3 = u_xlati39<4;
					        u_xlatb16 = u_xlati39<_SamplingLevel;
					        u_xlatb3 = u_xlatb16 && u_xlatb3;
					        if(!u_xlatb3){break;}
					        u_xlat16_4 = float(u_xlati39);
					        u_xlat16_1.x = u_xlat16_4 * _MainTex_TexelSize.x;
					        u_xlat16_17.xy = u_xlat16_1.xy + vs_TEXCOORD0.xy;
					        u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat5 = dot(_GaussParam0, ImmCB_0_0_0DynamicIndex(u_xlati39));
					        u_xlat18.xyz = u_xlat10_3.xyz * vec3(u_xlat5) + u_xlat16_2.xyz;
					        u_xlat16_27.x = u_xlat16_4 * (-_MainTex_TexelSize.x);
					        u_xlat16_1.xz = u_xlat16_27.xy + vs_TEXCOORD0.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_1.xz).xyz;
					        u_xlat2.xyz = u_xlat10_6.xyz * vec3(u_xlat5) + u_xlat18.xyz;
					        u_xlati39 = u_xlati39 + 1;
					        u_xlat16_2.xyz = u_xlat2.xyz;
					    }
					    u_xlat16_0.y = float(0.0);
					    u_xlat16_26.y = float(0.0);
					    u_xlat16_7.xyz = u_xlat16_2.xyz;
					    u_xlati5.x = 4;
					    for(int u_xlati_while_true_1 = 0 ; u_xlati_while_true_1 < 0x7FFF ; u_xlati_while_true_1++){
					        u_xlatb8 = u_xlati5.x<8;
					        u_xlatb21 = u_xlati5.x<_SamplingLevel;
					        u_xlatb8 = u_xlatb21 && u_xlatb8;
					        if(!u_xlatb8){break;}
					        u_xlat16_46 = float(u_xlati5.x);
					        u_xlat16_0.x = u_xlat16_46 * _MainTex_TexelSize.x;
					        u_xlat16_9.xy = u_xlat16_0.xy + vs_TEXCOORD0.xy;
					        u_xlat10_8.xyz = texture2D(_MainTex, u_xlat16_9.xy).xyz;
					        u_xlati5.xy = u_xlati5.xx + ivec2(1, -4);
					        u_xlat47 = dot(_GaussParam1, ImmCB_0_0_0DynamicIndex(u_xlati5.y));
					        u_xlat8.xyz = u_xlat10_8.xyz * vec3(u_xlat47) + u_xlat16_7.xyz;
					        u_xlat16_26.x = u_xlat16_46 * (-_MainTex_TexelSize.x);
					        u_xlat16_9.xy = u_xlat16_26.xy + vs_TEXCOORD0.xy;
					        u_xlat10_10.xyz = texture2D(_MainTex, u_xlat16_9.xy).xyz;
					        u_xlat7.xyz = u_xlat10_10.xyz * vec3(u_xlat47) + u_xlat8.xyz;
					        u_xlat16_7.xyz = u_xlat7.xyz;
					    }
					    u_xlat16_0.y = float(0.0);
					    u_xlat16_26.y = float(0.0);
					    u_xlat16_9.xyz = u_xlat16_7.xyz;
					    u_xlati8.x = 8;
					    for(int u_xlati_while_true_2 = 0 ; u_xlati_while_true_2 < 0x7FFF ; u_xlati_while_true_2++){
					        u_xlatb34 = u_xlati8.x<12;
					        u_xlatb47 = u_xlati8.x<_SamplingLevel;
					        u_xlatb34 = u_xlatb47 && u_xlatb34;
					        if(!u_xlatb34){break;}
					        u_xlat16_46 = float(u_xlati8.x);
					        u_xlat16_0.x = u_xlat16_46 * _MainTex_TexelSize.x;
					        u_xlat16_11.xy = u_xlat16_0.xy + vs_TEXCOORD0.xy;
					        u_xlat10_10.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlati8.xy = u_xlati8.xx + ivec2(1, -8);
					        u_xlat21 = dot(_GaussParam2, ImmCB_0_0_0DynamicIndex(u_xlati8.y));
					        u_xlat10.xyz = u_xlat10_10.xyz * vec3(u_xlat21) + u_xlat16_9.xyz;
					        u_xlat16_26.x = u_xlat16_46 * (-_MainTex_TexelSize.x);
					        u_xlat16_11.xy = u_xlat16_26.xy + vs_TEXCOORD0.xy;
					        u_xlat10_12.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlat9.xyz = u_xlat10_12.xyz * vec3(u_xlat21) + u_xlat10.xyz;
					        u_xlat16_9.xyz = u_xlat9.xyz;
					    }
					    u_xlat16_0.y = float(0.0);
					    u_xlat16_26.y = float(0.0);
					    u_xlat16_7.xyz = u_xlat16_9.xyz;
					    u_xlati8.x = 12;
					    for(int u_xlati_while_true_3 = 0 ; u_xlati_while_true_3 < 0x7FFF ; u_xlati_while_true_3++){
					        u_xlatb34 = u_xlati8.x<16;
					        u_xlatb47 = u_xlati8.x<_SamplingLevel;
					        u_xlatb34 = u_xlatb47 && u_xlatb34;
					        if(!u_xlatb34){break;}
					        u_xlat16_46 = float(u_xlati8.x);
					        u_xlat16_0.x = u_xlat16_46 * _MainTex_TexelSize.x;
					        u_xlat16_11.xy = u_xlat16_0.xy + vs_TEXCOORD0.xy;
					        u_xlat10_10.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlati8.xy = u_xlati8.xx + ivec2(1, -12);
					        u_xlat21 = dot(_GaussParam3, ImmCB_0_0_0DynamicIndex(u_xlati8.y));
					        u_xlat10.xyz = u_xlat10_10.xyz * vec3(u_xlat21) + u_xlat16_7.xyz;
					        u_xlat16_26.x = u_xlat16_46 * (-_MainTex_TexelSize.x);
					        u_xlat16_11.xy = u_xlat16_26.xy + vs_TEXCOORD0.xy;
					        u_xlat10_12.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlat7.xyz = u_xlat10_12.xyz * vec3(u_xlat21) + u_xlat10.xyz;
					        u_xlat16_7.xyz = u_xlat7.xyz;
					    }
					    SV_Target0.xyz = u_xlat16_7.xyz;
					    SV_Target0.w = 1.0;
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
					varying mediump vec2 vs_TEXCOORD0;
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
					vec4 ImmCB_0_0_0[4];
					uniform 	vec4 _GaussParam0;
					uniform 	vec4 _GaussParam1;
					uniform 	vec4 _GaussParam2;
					uniform 	vec4 _GaussParam3;
					uniform 	int _SamplingLevel;
					uniform 	vec4 _MainTex_TexelSize;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec2 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					mediump vec3 u_xlat16_1;
					vec3 u_xlat2;
					mediump vec3 u_xlat16_2;
					lowp vec3 u_xlat10_3;
					bool u_xlatb3;
					mediump float u_xlat16_4;
					float u_xlat5;
					ivec2 u_xlati5;
					lowp vec3 u_xlat10_6;
					vec3 u_xlat7;
					mediump vec3 u_xlat16_7;
					vec3 u_xlat8;
					lowp vec3 u_xlat10_8;
					ivec2 u_xlati8;
					bool u_xlatb8;
					vec3 u_xlat9;
					mediump vec3 u_xlat16_9;
					vec3 u_xlat10;
					lowp vec3 u_xlat10_10;
					mediump vec2 u_xlat16_11;
					lowp vec3 u_xlat10_12;
					bool u_xlatb16;
					mediump vec2 u_xlat16_17;
					vec3 u_xlat18;
					float u_xlat21;
					bool u_xlatb21;
					mediump vec2 u_xlat16_26;
					mediump vec2 u_xlat16_27;
					bool u_xlatb34;
					int u_xlati39;
					mediump float u_xlat16_46;
					float u_xlat47;
					bool u_xlatb47;
					#define UNITY_DYNAMIC_INDEX_ES2 0
					
					
					
					vec4 ImmCB_0_0_0DynamicIndex(int i){
					#if UNITY_DYNAMIC_INDEX_ES2
					    return ImmCB_0_0_0[i];
					#else
					#define d_ar ImmCB_0_0_0
					    if (i <= 0) return d_ar[0]; else if (i == 1) return d_ar[1]; else if (i == 2) return d_ar[2]; else if (i == 3) return d_ar[3];
					    return d_ar[0];
					#undef d_ar
					#endif
					}
					
					void main()
					{
						ImmCB_0_0_0[0] = vec4(1.0, 0.0, 0.0, 0.0);
						ImmCB_0_0_0[1] = vec4(0.0, 1.0, 0.0, 0.0);
						ImmCB_0_0_0[2] = vec4(0.0, 0.0, 1.0, 0.0);
						ImmCB_0_0_0[3] = vec4(0.0, 0.0, 0.0, 1.0);
					    u_xlat10_0.xyz = texture2D(_MainTex, vs_TEXCOORD0.xy).xyz;
					    u_xlat0.xyz = u_xlat10_0.xyz * _GaussParam0.xxx;
					    u_xlat16_1.y = float(0.0);
					    u_xlat16_27.y = float(0.0);
					    u_xlat16_2.xyz = u_xlat0.xyz;
					    u_xlati39 = 1;
					    for(int u_xlati_while_true_0 = 0 ; u_xlati_while_true_0 < 0x7FFF ; u_xlati_while_true_0++){
					        u_xlatb3 = u_xlati39<4;
					        u_xlatb16 = u_xlati39<_SamplingLevel;
					        u_xlatb3 = u_xlatb16 && u_xlatb3;
					        if(!u_xlatb3){break;}
					        u_xlat16_4 = float(u_xlati39);
					        u_xlat16_1.x = u_xlat16_4 * _MainTex_TexelSize.x;
					        u_xlat16_17.xy = u_xlat16_1.xy + vs_TEXCOORD0.xy;
					        u_xlat10_3.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat5 = dot(_GaussParam0, ImmCB_0_0_0DynamicIndex(u_xlati39));
					        u_xlat18.xyz = u_xlat10_3.xyz * vec3(u_xlat5) + u_xlat16_2.xyz;
					        u_xlat16_27.x = u_xlat16_4 * (-_MainTex_TexelSize.x);
					        u_xlat16_1.xz = u_xlat16_27.xy + vs_TEXCOORD0.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_1.xz).xyz;
					        u_xlat2.xyz = u_xlat10_6.xyz * vec3(u_xlat5) + u_xlat18.xyz;
					        u_xlati39 = u_xlati39 + 1;
					        u_xlat16_2.xyz = u_xlat2.xyz;
					    }
					    u_xlat16_0.y = float(0.0);
					    u_xlat16_26.y = float(0.0);
					    u_xlat16_7.xyz = u_xlat16_2.xyz;
					    u_xlati5.x = 4;
					    for(int u_xlati_while_true_1 = 0 ; u_xlati_while_true_1 < 0x7FFF ; u_xlati_while_true_1++){
					        u_xlatb8 = u_xlati5.x<8;
					        u_xlatb21 = u_xlati5.x<_SamplingLevel;
					        u_xlatb8 = u_xlatb21 && u_xlatb8;
					        if(!u_xlatb8){break;}
					        u_xlat16_46 = float(u_xlati5.x);
					        u_xlat16_0.x = u_xlat16_46 * _MainTex_TexelSize.x;
					        u_xlat16_9.xy = u_xlat16_0.xy + vs_TEXCOORD0.xy;
					        u_xlat10_8.xyz = texture2D(_MainTex, u_xlat16_9.xy).xyz;
					        u_xlati5.xy = u_xlati5.xx + ivec2(1, -4);
					        u_xlat47 = dot(_GaussParam1, ImmCB_0_0_0DynamicIndex(u_xlati5.y));
					        u_xlat8.xyz = u_xlat10_8.xyz * vec3(u_xlat47) + u_xlat16_7.xyz;
					        u_xlat16_26.x = u_xlat16_46 * (-_MainTex_TexelSize.x);
					        u_xlat16_9.xy = u_xlat16_26.xy + vs_TEXCOORD0.xy;
					        u_xlat10_10.xyz = texture2D(_MainTex, u_xlat16_9.xy).xyz;
					        u_xlat7.xyz = u_xlat10_10.xyz * vec3(u_xlat47) + u_xlat8.xyz;
					        u_xlat16_7.xyz = u_xlat7.xyz;
					    }
					    u_xlat16_0.y = float(0.0);
					    u_xlat16_26.y = float(0.0);
					    u_xlat16_9.xyz = u_xlat16_7.xyz;
					    u_xlati8.x = 8;
					    for(int u_xlati_while_true_2 = 0 ; u_xlati_while_true_2 < 0x7FFF ; u_xlati_while_true_2++){
					        u_xlatb34 = u_xlati8.x<12;
					        u_xlatb47 = u_xlati8.x<_SamplingLevel;
					        u_xlatb34 = u_xlatb47 && u_xlatb34;
					        if(!u_xlatb34){break;}
					        u_xlat16_46 = float(u_xlati8.x);
					        u_xlat16_0.x = u_xlat16_46 * _MainTex_TexelSize.x;
					        u_xlat16_11.xy = u_xlat16_0.xy + vs_TEXCOORD0.xy;
					        u_xlat10_10.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlati8.xy = u_xlati8.xx + ivec2(1, -8);
					        u_xlat21 = dot(_GaussParam2, ImmCB_0_0_0DynamicIndex(u_xlati8.y));
					        u_xlat10.xyz = u_xlat10_10.xyz * vec3(u_xlat21) + u_xlat16_9.xyz;
					        u_xlat16_26.x = u_xlat16_46 * (-_MainTex_TexelSize.x);
					        u_xlat16_11.xy = u_xlat16_26.xy + vs_TEXCOORD0.xy;
					        u_xlat10_12.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlat9.xyz = u_xlat10_12.xyz * vec3(u_xlat21) + u_xlat10.xyz;
					        u_xlat16_9.xyz = u_xlat9.xyz;
					    }
					    u_xlat16_0.y = float(0.0);
					    u_xlat16_26.y = float(0.0);
					    u_xlat16_7.xyz = u_xlat16_9.xyz;
					    u_xlati8.x = 12;
					    for(int u_xlati_while_true_3 = 0 ; u_xlati_while_true_3 < 0x7FFF ; u_xlati_while_true_3++){
					        u_xlatb34 = u_xlati8.x<16;
					        u_xlatb47 = u_xlati8.x<_SamplingLevel;
					        u_xlatb34 = u_xlatb47 && u_xlatb34;
					        if(!u_xlatb34){break;}
					        u_xlat16_46 = float(u_xlati8.x);
					        u_xlat16_0.x = u_xlat16_46 * _MainTex_TexelSize.x;
					        u_xlat16_11.xy = u_xlat16_0.xy + vs_TEXCOORD0.xy;
					        u_xlat10_10.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlati8.xy = u_xlati8.xx + ivec2(1, -12);
					        u_xlat21 = dot(_GaussParam3, ImmCB_0_0_0DynamicIndex(u_xlati8.y));
					        u_xlat10.xyz = u_xlat10_10.xyz * vec3(u_xlat21) + u_xlat16_7.xyz;
					        u_xlat16_26.x = u_xlat16_46 * (-_MainTex_TexelSize.x);
					        u_xlat16_11.xy = u_xlat16_26.xy + vs_TEXCOORD0.xy;
					        u_xlat10_12.xyz = texture2D(_MainTex, u_xlat16_11.xy).xyz;
					        u_xlat7.xyz = u_xlat10_12.xyz * vec3(u_xlat21) + u_xlat10.xyz;
					        u_xlat16_7.xyz = u_xlat7.xyz;
					    }
					    SV_Target0.xyz = u_xlat16_7.xyz;
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
		}
		Pass {
			Tags { "QUEUE" = "Overlay" }
			ZWrite Off
			GpuProgramID 98998
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
					varying mediump vec2 vs_TEXCOORD0;
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
					vec4 ImmCB_0_0_0[4];
					uniform 	vec4 _GaussParam0;
					uniform 	vec4 _GaussParam1;
					uniform 	vec4 _GaussParam2;
					uniform 	vec4 _GaussParam3;
					uniform 	int _SamplingLevel;
					uniform 	vec4 _MainTex_TexelSize;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec2 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					bool u_xlatb0;
					mediump vec2 u_xlat16_1;
					vec3 u_xlat2;
					mediump vec3 u_xlat16_2;
					vec3 u_xlat3;
					mediump vec3 u_xlat16_3;
					vec3 u_xlat4;
					lowp vec3 u_xlat10_4;
					ivec2 u_xlati4;
					bool u_xlatb4;
					mediump vec2 u_xlat16_5;
					vec3 u_xlat6;
					lowp vec3 u_xlat10_6;
					lowp vec3 u_xlat10_7;
					float u_xlat12;
					bool u_xlatb12;
					mediump vec2 u_xlat16_16;
					mediump vec2 u_xlat16_17;
					mediump vec2 u_xlat16_18;
					bool u_xlatb20;
					int u_xlati24;
					float u_xlat28;
					bool u_xlatb28;
					#define UNITY_DYNAMIC_INDEX_ES2 0
					
					
					
					vec4 ImmCB_0_0_0DynamicIndex(int i){
					#if UNITY_DYNAMIC_INDEX_ES2
					    return ImmCB_0_0_0[i];
					#else
					#define d_ar ImmCB_0_0_0
					    if (i <= 0) return d_ar[0]; else if (i == 1) return d_ar[1]; else if (i == 2) return d_ar[2]; else if (i == 3) return d_ar[3];
					    return d_ar[0];
					#undef d_ar
					#endif
					}
					
					void main()
					{
						ImmCB_0_0_0[0] = vec4(1.0, 0.0, 0.0, 0.0);
						ImmCB_0_0_0[1] = vec4(0.0, 1.0, 0.0, 0.0);
						ImmCB_0_0_0[2] = vec4(0.0, 0.0, 1.0, 0.0);
						ImmCB_0_0_0[3] = vec4(0.0, 0.0, 0.0, 1.0);
					    u_xlatb0 = _MainTex_TexelSize.y<0.0;
					    u_xlat16_1.x = (-vs_TEXCOORD0.y) + 1.0;
					    u_xlat16_1.y = (u_xlatb0) ? u_xlat16_1.x : vs_TEXCOORD0.y;
					    u_xlat16_1.x = vs_TEXCOORD0.x;
					    u_xlat10_0.xyz = texture2D(_MainTex, u_xlat16_1.xy).xyz;
					    u_xlat0.xyz = u_xlat10_0.xyz * _GaussParam0.xxx;
					    u_xlat16_2.x = float(0.0);
					    u_xlat16_18.x = float(0.0);
					    u_xlat16_3.xyz = u_xlat0.xyz;
					    u_xlati24 = 1;
					    for(int u_xlati_while_true_0 = 0 ; u_xlati_while_true_0 < 0x7FFF ; u_xlati_while_true_0++){
					        u_xlatb4 = u_xlati24<4;
					        u_xlatb12 = u_xlati24<_SamplingLevel;
					        u_xlatb4 = u_xlatb12 && u_xlatb4;
					        if(!u_xlatb4){break;}
					        u_xlat16_17.x = float(u_xlati24);
					        u_xlat16_2.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_1.xy + u_xlat16_2.xy;
					        u_xlat10_4.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlat28 = dot(_GaussParam0, ImmCB_0_0_0DynamicIndex(u_xlati24));
					        u_xlat4.xyz = u_xlat10_4.xyz * vec3(u_xlat28) + u_xlat16_3.xyz;
					        u_xlat16_18.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_1.xy + u_xlat16_18.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat3.xyz = u_xlat10_6.xyz * vec3(u_xlat28) + u_xlat4.xyz;
					        u_xlati24 = u_xlati24 + 1;
					        u_xlat16_3.xyz = u_xlat3.xyz;
					    }
					    u_xlat16_0.x = float(0.0);
					    u_xlat16_16.x = float(0.0);
					    u_xlat16_2.xyz = u_xlat16_3.xyz;
					    u_xlati4.x = 4;
					    for(int u_xlati_while_true_1 = 0 ; u_xlati_while_true_1 < 0x7FFF ; u_xlati_while_true_1++){
					        u_xlatb20 = u_xlati4.x<8;
					        u_xlatb28 = u_xlati4.x<_SamplingLevel;
					        u_xlatb20 = u_xlatb28 && u_xlatb20;
					        if(!u_xlatb20){break;}
					        u_xlat16_17.x = float(u_xlati4.x);
					        u_xlat16_0.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_0.xy + u_xlat16_1.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlati4.xy = u_xlati4.xx + ivec2(1, -4);
					        u_xlat12 = dot(_GaussParam1, ImmCB_0_0_0DynamicIndex(u_xlati4.y));
					        u_xlat6.xyz = u_xlat10_6.xyz * vec3(u_xlat12) + u_xlat16_2.xyz;
					        u_xlat16_16.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_16.xy + u_xlat16_1.xy;
					        u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat2.xyz = u_xlat10_7.xyz * vec3(u_xlat12) + u_xlat6.xyz;
					        u_xlat16_2.xyz = u_xlat2.xyz;
					    }
					    u_xlat16_0.x = float(0.0);
					    u_xlat16_16.x = float(0.0);
					    u_xlat16_3.xyz = u_xlat16_2.xyz;
					    u_xlati4.x = 8;
					    for(int u_xlati_while_true_2 = 0 ; u_xlati_while_true_2 < 0x7FFF ; u_xlati_while_true_2++){
					        u_xlatb20 = u_xlati4.x<12;
					        u_xlatb28 = u_xlati4.x<_SamplingLevel;
					        u_xlatb20 = u_xlatb28 && u_xlatb20;
					        if(!u_xlatb20){break;}
					        u_xlat16_17.x = float(u_xlati4.x);
					        u_xlat16_0.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_0.xy + u_xlat16_1.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlati4.xy = u_xlati4.xx + ivec2(1, -8);
					        u_xlat12 = dot(_GaussParam2, ImmCB_0_0_0DynamicIndex(u_xlati4.y));
					        u_xlat6.xyz = u_xlat10_6.xyz * vec3(u_xlat12) + u_xlat16_3.xyz;
					        u_xlat16_16.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_16.xy + u_xlat16_1.xy;
					        u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat3.xyz = u_xlat10_7.xyz * vec3(u_xlat12) + u_xlat6.xyz;
					        u_xlat16_3.xyz = u_xlat3.xyz;
					    }
					    u_xlat16_0.x = float(0.0);
					    u_xlat16_16.x = float(0.0);
					    u_xlat16_2.xyz = u_xlat16_3.xyz;
					    u_xlati4.x = 12;
					    for(int u_xlati_while_true_3 = 0 ; u_xlati_while_true_3 < 0x7FFF ; u_xlati_while_true_3++){
					        u_xlatb20 = u_xlati4.x<16;
					        u_xlatb28 = u_xlati4.x<_SamplingLevel;
					        u_xlatb20 = u_xlatb28 && u_xlatb20;
					        if(!u_xlatb20){break;}
					        u_xlat16_17.x = float(u_xlati4.x);
					        u_xlat16_0.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_0.xy + u_xlat16_1.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlati4.xy = u_xlati4.xx + ivec2(1, -12);
					        u_xlat12 = dot(_GaussParam3, ImmCB_0_0_0DynamicIndex(u_xlati4.y));
					        u_xlat6.xyz = u_xlat10_6.xyz * vec3(u_xlat12) + u_xlat16_2.xyz;
					        u_xlat16_16.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_16.xy + u_xlat16_1.xy;
					        u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat2.xyz = u_xlat10_7.xyz * vec3(u_xlat12) + u_xlat6.xyz;
					        u_xlat16_2.xyz = u_xlat2.xyz;
					    }
					    SV_Target0.xyz = u_xlat16_2.xyz;
					    SV_Target0.w = 1.0;
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
					varying mediump vec2 vs_TEXCOORD0;
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
					vec4 ImmCB_0_0_0[4];
					uniform 	vec4 _GaussParam0;
					uniform 	vec4 _GaussParam1;
					uniform 	vec4 _GaussParam2;
					uniform 	vec4 _GaussParam3;
					uniform 	int _SamplingLevel;
					uniform 	vec4 _MainTex_TexelSize;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec2 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					bool u_xlatb0;
					mediump vec2 u_xlat16_1;
					vec3 u_xlat2;
					mediump vec3 u_xlat16_2;
					vec3 u_xlat3;
					mediump vec3 u_xlat16_3;
					vec3 u_xlat4;
					lowp vec3 u_xlat10_4;
					ivec2 u_xlati4;
					bool u_xlatb4;
					mediump vec2 u_xlat16_5;
					vec3 u_xlat6;
					lowp vec3 u_xlat10_6;
					lowp vec3 u_xlat10_7;
					float u_xlat12;
					bool u_xlatb12;
					mediump vec2 u_xlat16_16;
					mediump vec2 u_xlat16_17;
					mediump vec2 u_xlat16_18;
					bool u_xlatb20;
					int u_xlati24;
					float u_xlat28;
					bool u_xlatb28;
					#define UNITY_DYNAMIC_INDEX_ES2 0
					
					
					
					vec4 ImmCB_0_0_0DynamicIndex(int i){
					#if UNITY_DYNAMIC_INDEX_ES2
					    return ImmCB_0_0_0[i];
					#else
					#define d_ar ImmCB_0_0_0
					    if (i <= 0) return d_ar[0]; else if (i == 1) return d_ar[1]; else if (i == 2) return d_ar[2]; else if (i == 3) return d_ar[3];
					    return d_ar[0];
					#undef d_ar
					#endif
					}
					
					void main()
					{
						ImmCB_0_0_0[0] = vec4(1.0, 0.0, 0.0, 0.0);
						ImmCB_0_0_0[1] = vec4(0.0, 1.0, 0.0, 0.0);
						ImmCB_0_0_0[2] = vec4(0.0, 0.0, 1.0, 0.0);
						ImmCB_0_0_0[3] = vec4(0.0, 0.0, 0.0, 1.0);
					    u_xlatb0 = _MainTex_TexelSize.y<0.0;
					    u_xlat16_1.x = (-vs_TEXCOORD0.y) + 1.0;
					    u_xlat16_1.y = (u_xlatb0) ? u_xlat16_1.x : vs_TEXCOORD0.y;
					    u_xlat16_1.x = vs_TEXCOORD0.x;
					    u_xlat10_0.xyz = texture2D(_MainTex, u_xlat16_1.xy).xyz;
					    u_xlat0.xyz = u_xlat10_0.xyz * _GaussParam0.xxx;
					    u_xlat16_2.x = float(0.0);
					    u_xlat16_18.x = float(0.0);
					    u_xlat16_3.xyz = u_xlat0.xyz;
					    u_xlati24 = 1;
					    for(int u_xlati_while_true_0 = 0 ; u_xlati_while_true_0 < 0x7FFF ; u_xlati_while_true_0++){
					        u_xlatb4 = u_xlati24<4;
					        u_xlatb12 = u_xlati24<_SamplingLevel;
					        u_xlatb4 = u_xlatb12 && u_xlatb4;
					        if(!u_xlatb4){break;}
					        u_xlat16_17.x = float(u_xlati24);
					        u_xlat16_2.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_1.xy + u_xlat16_2.xy;
					        u_xlat10_4.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlat28 = dot(_GaussParam0, ImmCB_0_0_0DynamicIndex(u_xlati24));
					        u_xlat4.xyz = u_xlat10_4.xyz * vec3(u_xlat28) + u_xlat16_3.xyz;
					        u_xlat16_18.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_1.xy + u_xlat16_18.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat3.xyz = u_xlat10_6.xyz * vec3(u_xlat28) + u_xlat4.xyz;
					        u_xlati24 = u_xlati24 + 1;
					        u_xlat16_3.xyz = u_xlat3.xyz;
					    }
					    u_xlat16_0.x = float(0.0);
					    u_xlat16_16.x = float(0.0);
					    u_xlat16_2.xyz = u_xlat16_3.xyz;
					    u_xlati4.x = 4;
					    for(int u_xlati_while_true_1 = 0 ; u_xlati_while_true_1 < 0x7FFF ; u_xlati_while_true_1++){
					        u_xlatb20 = u_xlati4.x<8;
					        u_xlatb28 = u_xlati4.x<_SamplingLevel;
					        u_xlatb20 = u_xlatb28 && u_xlatb20;
					        if(!u_xlatb20){break;}
					        u_xlat16_17.x = float(u_xlati4.x);
					        u_xlat16_0.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_0.xy + u_xlat16_1.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlati4.xy = u_xlati4.xx + ivec2(1, -4);
					        u_xlat12 = dot(_GaussParam1, ImmCB_0_0_0DynamicIndex(u_xlati4.y));
					        u_xlat6.xyz = u_xlat10_6.xyz * vec3(u_xlat12) + u_xlat16_2.xyz;
					        u_xlat16_16.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_16.xy + u_xlat16_1.xy;
					        u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat2.xyz = u_xlat10_7.xyz * vec3(u_xlat12) + u_xlat6.xyz;
					        u_xlat16_2.xyz = u_xlat2.xyz;
					    }
					    u_xlat16_0.x = float(0.0);
					    u_xlat16_16.x = float(0.0);
					    u_xlat16_3.xyz = u_xlat16_2.xyz;
					    u_xlati4.x = 8;
					    for(int u_xlati_while_true_2 = 0 ; u_xlati_while_true_2 < 0x7FFF ; u_xlati_while_true_2++){
					        u_xlatb20 = u_xlati4.x<12;
					        u_xlatb28 = u_xlati4.x<_SamplingLevel;
					        u_xlatb20 = u_xlatb28 && u_xlatb20;
					        if(!u_xlatb20){break;}
					        u_xlat16_17.x = float(u_xlati4.x);
					        u_xlat16_0.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_0.xy + u_xlat16_1.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlati4.xy = u_xlati4.xx + ivec2(1, -8);
					        u_xlat12 = dot(_GaussParam2, ImmCB_0_0_0DynamicIndex(u_xlati4.y));
					        u_xlat6.xyz = u_xlat10_6.xyz * vec3(u_xlat12) + u_xlat16_3.xyz;
					        u_xlat16_16.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_16.xy + u_xlat16_1.xy;
					        u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat3.xyz = u_xlat10_7.xyz * vec3(u_xlat12) + u_xlat6.xyz;
					        u_xlat16_3.xyz = u_xlat3.xyz;
					    }
					    u_xlat16_0.x = float(0.0);
					    u_xlat16_16.x = float(0.0);
					    u_xlat16_2.xyz = u_xlat16_3.xyz;
					    u_xlati4.x = 12;
					    for(int u_xlati_while_true_3 = 0 ; u_xlati_while_true_3 < 0x7FFF ; u_xlati_while_true_3++){
					        u_xlatb20 = u_xlati4.x<16;
					        u_xlatb28 = u_xlati4.x<_SamplingLevel;
					        u_xlatb20 = u_xlatb28 && u_xlatb20;
					        if(!u_xlatb20){break;}
					        u_xlat16_17.x = float(u_xlati4.x);
					        u_xlat16_0.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_0.xy + u_xlat16_1.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlati4.xy = u_xlati4.xx + ivec2(1, -12);
					        u_xlat12 = dot(_GaussParam3, ImmCB_0_0_0DynamicIndex(u_xlati4.y));
					        u_xlat6.xyz = u_xlat10_6.xyz * vec3(u_xlat12) + u_xlat16_2.xyz;
					        u_xlat16_16.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_16.xy + u_xlat16_1.xy;
					        u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat2.xyz = u_xlat10_7.xyz * vec3(u_xlat12) + u_xlat6.xyz;
					        u_xlat16_2.xyz = u_xlat2.xyz;
					    }
					    SV_Target0.xyz = u_xlat16_2.xyz;
					    SV_Target0.w = 1.0;
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
					varying mediump vec2 vs_TEXCOORD0;
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
					vec4 ImmCB_0_0_0[4];
					uniform 	vec4 _GaussParam0;
					uniform 	vec4 _GaussParam1;
					uniform 	vec4 _GaussParam2;
					uniform 	vec4 _GaussParam3;
					uniform 	int _SamplingLevel;
					uniform 	vec4 _MainTex_TexelSize;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					vec3 u_xlat0;
					mediump vec2 u_xlat16_0;
					lowp vec3 u_xlat10_0;
					bool u_xlatb0;
					mediump vec2 u_xlat16_1;
					vec3 u_xlat2;
					mediump vec3 u_xlat16_2;
					vec3 u_xlat3;
					mediump vec3 u_xlat16_3;
					vec3 u_xlat4;
					lowp vec3 u_xlat10_4;
					ivec2 u_xlati4;
					bool u_xlatb4;
					mediump vec2 u_xlat16_5;
					vec3 u_xlat6;
					lowp vec3 u_xlat10_6;
					lowp vec3 u_xlat10_7;
					float u_xlat12;
					bool u_xlatb12;
					mediump vec2 u_xlat16_16;
					mediump vec2 u_xlat16_17;
					mediump vec2 u_xlat16_18;
					bool u_xlatb20;
					int u_xlati24;
					float u_xlat28;
					bool u_xlatb28;
					#define UNITY_DYNAMIC_INDEX_ES2 0
					
					
					
					vec4 ImmCB_0_0_0DynamicIndex(int i){
					#if UNITY_DYNAMIC_INDEX_ES2
					    return ImmCB_0_0_0[i];
					#else
					#define d_ar ImmCB_0_0_0
					    if (i <= 0) return d_ar[0]; else if (i == 1) return d_ar[1]; else if (i == 2) return d_ar[2]; else if (i == 3) return d_ar[3];
					    return d_ar[0];
					#undef d_ar
					#endif
					}
					
					void main()
					{
						ImmCB_0_0_0[0] = vec4(1.0, 0.0, 0.0, 0.0);
						ImmCB_0_0_0[1] = vec4(0.0, 1.0, 0.0, 0.0);
						ImmCB_0_0_0[2] = vec4(0.0, 0.0, 1.0, 0.0);
						ImmCB_0_0_0[3] = vec4(0.0, 0.0, 0.0, 1.0);
					    u_xlatb0 = _MainTex_TexelSize.y<0.0;
					    u_xlat16_1.x = (-vs_TEXCOORD0.y) + 1.0;
					    u_xlat16_1.y = (u_xlatb0) ? u_xlat16_1.x : vs_TEXCOORD0.y;
					    u_xlat16_1.x = vs_TEXCOORD0.x;
					    u_xlat10_0.xyz = texture2D(_MainTex, u_xlat16_1.xy).xyz;
					    u_xlat0.xyz = u_xlat10_0.xyz * _GaussParam0.xxx;
					    u_xlat16_2.x = float(0.0);
					    u_xlat16_18.x = float(0.0);
					    u_xlat16_3.xyz = u_xlat0.xyz;
					    u_xlati24 = 1;
					    for(int u_xlati_while_true_0 = 0 ; u_xlati_while_true_0 < 0x7FFF ; u_xlati_while_true_0++){
					        u_xlatb4 = u_xlati24<4;
					        u_xlatb12 = u_xlati24<_SamplingLevel;
					        u_xlatb4 = u_xlatb12 && u_xlatb4;
					        if(!u_xlatb4){break;}
					        u_xlat16_17.x = float(u_xlati24);
					        u_xlat16_2.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_1.xy + u_xlat16_2.xy;
					        u_xlat10_4.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlat28 = dot(_GaussParam0, ImmCB_0_0_0DynamicIndex(u_xlati24));
					        u_xlat4.xyz = u_xlat10_4.xyz * vec3(u_xlat28) + u_xlat16_3.xyz;
					        u_xlat16_18.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_1.xy + u_xlat16_18.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat3.xyz = u_xlat10_6.xyz * vec3(u_xlat28) + u_xlat4.xyz;
					        u_xlati24 = u_xlati24 + 1;
					        u_xlat16_3.xyz = u_xlat3.xyz;
					    }
					    u_xlat16_0.x = float(0.0);
					    u_xlat16_16.x = float(0.0);
					    u_xlat16_2.xyz = u_xlat16_3.xyz;
					    u_xlati4.x = 4;
					    for(int u_xlati_while_true_1 = 0 ; u_xlati_while_true_1 < 0x7FFF ; u_xlati_while_true_1++){
					        u_xlatb20 = u_xlati4.x<8;
					        u_xlatb28 = u_xlati4.x<_SamplingLevel;
					        u_xlatb20 = u_xlatb28 && u_xlatb20;
					        if(!u_xlatb20){break;}
					        u_xlat16_17.x = float(u_xlati4.x);
					        u_xlat16_0.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_0.xy + u_xlat16_1.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlati4.xy = u_xlati4.xx + ivec2(1, -4);
					        u_xlat12 = dot(_GaussParam1, ImmCB_0_0_0DynamicIndex(u_xlati4.y));
					        u_xlat6.xyz = u_xlat10_6.xyz * vec3(u_xlat12) + u_xlat16_2.xyz;
					        u_xlat16_16.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_16.xy + u_xlat16_1.xy;
					        u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat2.xyz = u_xlat10_7.xyz * vec3(u_xlat12) + u_xlat6.xyz;
					        u_xlat16_2.xyz = u_xlat2.xyz;
					    }
					    u_xlat16_0.x = float(0.0);
					    u_xlat16_16.x = float(0.0);
					    u_xlat16_3.xyz = u_xlat16_2.xyz;
					    u_xlati4.x = 8;
					    for(int u_xlati_while_true_2 = 0 ; u_xlati_while_true_2 < 0x7FFF ; u_xlati_while_true_2++){
					        u_xlatb20 = u_xlati4.x<12;
					        u_xlatb28 = u_xlati4.x<_SamplingLevel;
					        u_xlatb20 = u_xlatb28 && u_xlatb20;
					        if(!u_xlatb20){break;}
					        u_xlat16_17.x = float(u_xlati4.x);
					        u_xlat16_0.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_0.xy + u_xlat16_1.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlati4.xy = u_xlati4.xx + ivec2(1, -8);
					        u_xlat12 = dot(_GaussParam2, ImmCB_0_0_0DynamicIndex(u_xlati4.y));
					        u_xlat6.xyz = u_xlat10_6.xyz * vec3(u_xlat12) + u_xlat16_3.xyz;
					        u_xlat16_16.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_16.xy + u_xlat16_1.xy;
					        u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat3.xyz = u_xlat10_7.xyz * vec3(u_xlat12) + u_xlat6.xyz;
					        u_xlat16_3.xyz = u_xlat3.xyz;
					    }
					    u_xlat16_0.x = float(0.0);
					    u_xlat16_16.x = float(0.0);
					    u_xlat16_2.xyz = u_xlat16_3.xyz;
					    u_xlati4.x = 12;
					    for(int u_xlati_while_true_3 = 0 ; u_xlati_while_true_3 < 0x7FFF ; u_xlati_while_true_3++){
					        u_xlatb20 = u_xlati4.x<16;
					        u_xlatb28 = u_xlati4.x<_SamplingLevel;
					        u_xlatb20 = u_xlatb28 && u_xlatb20;
					        if(!u_xlatb20){break;}
					        u_xlat16_17.x = float(u_xlati4.x);
					        u_xlat16_0.y = u_xlat16_17.x * _MainTex_TexelSize.y;
					        u_xlat16_5.xy = u_xlat16_0.xy + u_xlat16_1.xy;
					        u_xlat10_6.xyz = texture2D(_MainTex, u_xlat16_5.xy).xyz;
					        u_xlati4.xy = u_xlati4.xx + ivec2(1, -12);
					        u_xlat12 = dot(_GaussParam3, ImmCB_0_0_0DynamicIndex(u_xlati4.y));
					        u_xlat6.xyz = u_xlat10_6.xyz * vec3(u_xlat12) + u_xlat16_2.xyz;
					        u_xlat16_16.y = u_xlat16_17.x * (-_MainTex_TexelSize.y);
					        u_xlat16_17.xy = u_xlat16_16.xy + u_xlat16_1.xy;
					        u_xlat10_7.xyz = texture2D(_MainTex, u_xlat16_17.xy).xyz;
					        u_xlat2.xyz = u_xlat10_7.xyz * vec3(u_xlat12) + u_xlat6.xyz;
					        u_xlat16_2.xyz = u_xlat2.xyz;
					    }
					    SV_Target0.xyz = u_xlat16_2.xyz;
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
		}
		Pass {
			Tags { "QUEUE" = "Overlay" }
			ZWrite Off
			GpuProgramID 133441
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#ifdef VERTEX
					#version 100
					
					uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
					uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
					uniform 	vec4 _MainTex_ST;
					uniform 	mediump vec4 _UvOffset;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
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
					    vs_TEXCOORD0.x = u_xlat0.x + (-_UvOffset.x);
					    vs_TEXCOORD0.y = u_xlat0.y + _UvOffset.y;
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
					uniform 	vec4 _TexelParam;
					uniform 	vec4 _MainTex_TexelSize;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					lowp vec3 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					void main()
					{
					    u_xlat0 = _TexelParam.xxxx * vec4(-1.0, -1.0, 1.0, 1.0);
					    u_xlat1 = _MainTex_TexelSize.xyxy * u_xlat0.xyzy + vs_TEXCOORD0.xyxy;
					    u_xlat0 = _MainTex_TexelSize.xyxy * u_xlat0.xwzw + vs_TEXCOORD0.xyxy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat1.xy).xyz;
					    u_xlat10_1.xyz = texture2D(_MainTex, u_xlat1.zw).xyz;
					    u_xlat16_3.xyz = u_xlat10_1.xyz + u_xlat10_2.xyz;
					    u_xlat10_1.xyz = texture2D(_MainTex, u_xlat0.xy).xyz;
					    u_xlat10_0.xyz = texture2D(_MainTex, u_xlat0.zw).xyz;
					    u_xlat16_3.xyz = u_xlat10_1.xyz + u_xlat16_3.xyz;
					    u_xlat16_3.xyz = u_xlat10_0.xyz + u_xlat16_3.xyz;
					    SV_Target0.xyz = u_xlat16_3.xyz * vec3(0.25, 0.25, 0.25);
					    SV_Target0.w = 1.0;
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
					uniform 	mediump vec4 _UvOffset;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
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
					    vs_TEXCOORD0.x = u_xlat0.x + (-_UvOffset.x);
					    vs_TEXCOORD0.y = u_xlat0.y + _UvOffset.y;
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
					uniform 	vec4 _TexelParam;
					uniform 	vec4 _MainTex_TexelSize;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					lowp vec3 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					void main()
					{
					    u_xlat0 = _TexelParam.xxxx * vec4(-1.0, -1.0, 1.0, 1.0);
					    u_xlat1 = _MainTex_TexelSize.xyxy * u_xlat0.xyzy + vs_TEXCOORD0.xyxy;
					    u_xlat0 = _MainTex_TexelSize.xyxy * u_xlat0.xwzw + vs_TEXCOORD0.xyxy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat1.xy).xyz;
					    u_xlat10_1.xyz = texture2D(_MainTex, u_xlat1.zw).xyz;
					    u_xlat16_3.xyz = u_xlat10_1.xyz + u_xlat10_2.xyz;
					    u_xlat10_1.xyz = texture2D(_MainTex, u_xlat0.xy).xyz;
					    u_xlat10_0.xyz = texture2D(_MainTex, u_xlat0.zw).xyz;
					    u_xlat16_3.xyz = u_xlat10_1.xyz + u_xlat16_3.xyz;
					    u_xlat16_3.xyz = u_xlat10_0.xyz + u_xlat16_3.xyz;
					    SV_Target0.xyz = u_xlat16_3.xyz * vec3(0.25, 0.25, 0.25);
					    SV_Target0.w = 1.0;
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
					uniform 	mediump vec4 _UvOffset;
					attribute highp vec4 in_POSITION0;
					attribute highp vec2 in_TEXCOORD0;
					varying mediump vec2 vs_TEXCOORD0;
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
					    vs_TEXCOORD0.x = u_xlat0.x + (-_UvOffset.x);
					    vs_TEXCOORD0.y = u_xlat0.y + _UvOffset.y;
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
					uniform 	vec4 _TexelParam;
					uniform 	vec4 _MainTex_TexelSize;
					uniform lowp sampler2D _MainTex;
					varying mediump vec2 vs_TEXCOORD0;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					lowp vec3 u_xlat10_0;
					vec4 u_xlat1;
					lowp vec3 u_xlat10_1;
					lowp vec3 u_xlat10_2;
					mediump vec3 u_xlat16_3;
					void main()
					{
					    u_xlat0 = _TexelParam.xxxx * vec4(-1.0, -1.0, 1.0, 1.0);
					    u_xlat1 = _MainTex_TexelSize.xyxy * u_xlat0.xyzy + vs_TEXCOORD0.xyxy;
					    u_xlat0 = _MainTex_TexelSize.xyxy * u_xlat0.xwzw + vs_TEXCOORD0.xyxy;
					    u_xlat10_2.xyz = texture2D(_MainTex, u_xlat1.xy).xyz;
					    u_xlat10_1.xyz = texture2D(_MainTex, u_xlat1.zw).xyz;
					    u_xlat16_3.xyz = u_xlat10_1.xyz + u_xlat10_2.xyz;
					    u_xlat10_1.xyz = texture2D(_MainTex, u_xlat0.xy).xyz;
					    u_xlat10_0.xyz = texture2D(_MainTex, u_xlat0.zw).xyz;
					    u_xlat16_3.xyz = u_xlat10_1.xyz + u_xlat16_3.xyz;
					    u_xlat16_3.xyz = u_xlat10_0.xyz + u_xlat16_3.xyz;
					    SV_Target0.xyz = u_xlat16_3.xyz * vec3(0.25, 0.25, 0.25);
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
		}
	}
	Fallback "Diffuse"
}