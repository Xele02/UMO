Shader "MCRS/Valkyrie_High" {
	Properties {
		_VAL_col ("VAL_col", 2D) = "white" {}
		_Frenel_slider ("Frenel_slider", Range(-0.5, 1)) = 0
		_Cube_map ("Cube_map", Cube) = "_Skybox" {}
		_VAL_mask ("VAL_mask", 2D) = "white" {}
		_Brightnessmulti ("Brightness(multi)", Range(0, 2)) = 1
		_Saturationpower ("Saturation (power)", Range(0, 2)) = 1
		_IBL_color ("IBL_color", Vector) = (0.5,0.5,0.5,1)
		_speed ("speed", Float) = 10
		_DamageColor ("DamageColor", Vector) = (0,0,0,1)
		_MuzzleColor ("MuzzleColor", Vector) = (0.5019608,0.5019608,0.5019608,1)
	}
	SubShader {
		Tags { "RenderType" = "Opaque" }
		Pass {
			Name "FORWARD"
			Tags { "LIGHTMODE" = "FORWARDBASE" "RenderType" = "Opaque" "SHADOWSUPPORT" = "true" }
			GpuProgramID 60644
			Program "vp" {
				SubProgram "gles hw_tier00 " {
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTPROBE_SH" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTPROBE_SH" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTPROBE_SH" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" "VERTEXLIGHT_ON" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "DIRECTIONAL" "VERTEXLIGHT_ON" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "VERTEXLIGHT_ON" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" "VERTEXLIGHT_ON" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" "VERTEXLIGHT_ON" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "LIGHTPROBE_SH" "VERTEXLIGHT_ON" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "VERTEXLIGHT_ON" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "VERTEXLIGHT_ON" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "VERTEXLIGHT_ON" }
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier00 " {
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
				SubProgram "gles hw_tier01 " {
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
					    SV_Target0.w = 1.0;
					    return;
					}
					
					#endif"
				}
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
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
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
					uniform 	vec4 _VAL_col_ST;
					uniform 	float _Frenel_slider;
					uniform 	vec4 _VAL_mask_ST;
					uniform 	float _Saturationpower;
					uniform 	float _Brightnessmulti;
					uniform 	vec4 _IBL_color;
					uniform 	float _speed;
					uniform 	vec4 _DamageColor;
					uniform 	vec4 _MuzzleColor;
					uniform lowp sampler2D _VAL_col;
					uniform lowp samplerCube _Cube_map;
					uniform lowp sampler2D _VAL_mask;
					varying highp vec2 vs_TEXCOORD0;
					varying highp vec4 vs_TEXCOORD1;
					varying highp vec3 vs_TEXCOORD2;
					#define SV_Target0 gl_FragData[0]
					vec4 u_xlat0;
					vec3 u_xlat1;
					mediump vec3 u_xlat16_1;
					lowp vec3 u_xlat10_1;
					vec3 u_xlat2;
					vec3 u_xlat3;
					vec3 u_xlat4;
					vec3 u_xlat5;
					float u_xlat14;
					void main()
					{
					    u_xlat0.x = _Time.w + _TimeEditor.w;
					    u_xlat0.x = u_xlat0.x * _speed;
					    u_xlat0.x = u_xlat0.x * 0.0174532942;
					    u_xlat1.x = cos(u_xlat0.x);
					    u_xlat0.x = sin(u_xlat0.x);
					    u_xlat2.x = (-u_xlat0.x);
					    u_xlat4.xyz = (-vs_TEXCOORD1.xyz) + _WorldSpaceCameraPos.xyz;
					    u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat4.xyz = u_xlat4.xyz * u_xlat5.xxx;
					    u_xlat5.x = dot(vs_TEXCOORD2.xyz, vs_TEXCOORD2.xyz);
					    u_xlat5.x = inversesqrt(u_xlat5.x);
					    u_xlat5.xyz = u_xlat5.xxx * vs_TEXCOORD2.xyz;
					    u_xlat14 = dot((-u_xlat4.xyz), u_xlat5.xyz);
					    u_xlat14 = u_xlat14 + u_xlat14;
					    u_xlat3.xyz = u_xlat5.xyz * (-vec3(u_xlat14)) + (-u_xlat4.xyz);
					    u_xlat4.x = dot(u_xlat5.xyz, u_xlat4.xyz);
					    u_xlat4.y = dot(vec3(0.5, -0.300000012, 1.0), u_xlat5.xyz);
					    u_xlat4.xy = max(u_xlat4.xy, vec2(0.0, 0.0));
					    u_xlat4.x = (-u_xlat4.x) + 1.0;
					    u_xlat4.x = log2(u_xlat4.x);
					    u_xlat4.x = u_xlat4.x * _Frenel_slider;
					    u_xlat4.x = exp2(u_xlat4.x);
					    u_xlat2.y = u_xlat1.x;
					    u_xlat2.z = u_xlat0.x;
					    u_xlat1.z = dot(u_xlat2.zy, u_xlat3.xz);
					    u_xlat1.x = dot(u_xlat2.yx, u_xlat3.xz);
					    u_xlat1.y = u_xlat3.y;
					    u_xlat10_1.xyz = textureCube(_Cube_map, u_xlat1.xyz).xyz;
					    u_xlat1.xyz = u_xlat10_1.xyz * _IBL_color.xyz;
					    u_xlat0.xyw = min(u_xlat4.xxx, u_xlat1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_mask_ST.xy + _VAL_mask_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_mask, u_xlat1.xy).xyz;
					    u_xlat0.xyw = min(u_xlat0.xyw, u_xlat10_1.xyz);
					    u_xlat1.xy = vs_TEXCOORD0.xy * _VAL_col_ST.xy + _VAL_col_ST.zw;
					    u_xlat10_1.xyz = texture2D(_VAL_col, u_xlat1.xy).xyz;
					    u_xlat16_1.xyz = u_xlat10_1.xyz * u_xlat10_1.xyz;
					    u_xlat16_1.xyz = log2(u_xlat16_1.xyz);
					    u_xlat1.xyz = u_xlat16_1.xyz * vec3(_Saturationpower);
					    u_xlat1.xyz = exp2(u_xlat1.xyz);
					    u_xlat0.xyw = u_xlat1.xyz * vec3(vec3(_Brightnessmulti, _Brightnessmulti, _Brightnessmulti)) + u_xlat0.xyw;
					    u_xlat0.xyw = _DamageColor.xyz * _DamageColor.www + u_xlat0.xyw;
					    u_xlat1.xyz = _MuzzleColor.www * _MuzzleColor.xyz;
					    SV_Target0.xyz = u_xlat1.xyz * u_xlat4.yyy + u_xlat0.xyw;
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
		}
	}
	Fallback "Diffuse"
	CustomEditor "ShaderForgeMaterialInspector"
}