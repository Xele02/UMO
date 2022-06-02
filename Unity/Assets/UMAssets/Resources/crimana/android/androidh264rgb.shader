Shader "CriMana/AndroidH264Rgb" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		[HideInInspector] _MovieTexture_ST ("MovieTexture_ST", Vector) = (1,1,0,0)
		[HideInInspector] _AlphaTexture_ST ("AlphaTexture_ST", Vector) = (1,1,0,0)
		[HideInInspector] _TextureRGB ("TextureRGB", 2D) = "white" {}
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
			GpuProgramID 54917
			Program "vp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 33
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 33
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 36
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 36
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 36
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 37
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 36
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 36
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
			}
			Program "fp" {
				SubProgram "gles hw_tier00 " {
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 33
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 33
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 36
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 34
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 36
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 36
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 35
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier00 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF3 1
					#define UNITY_NO_FULL_STANDARD_SHADER 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER1 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 37
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier01 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER2 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 36
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
				SubProgram "gles hw_tier02 " {
					Keywords { "CRI_ALPHA_MOVIE" "CRI_APPLY_TARGET_ALPHA" "CRI_LINEAR_COLORSPACE" }
					"!!GLES
					#version 100
					#extension GL_OES_EGL_image_external : enable
					#extension GL_OES_EGL_image_external_essl3 : enable
					#define UNITY_NO_DXT5nm 1
					#define UNITY_NO_RGBM 1
					#define UNITY_ENABLE_REFLECTION_BUFFERS 1
					#define UNITY_FRAMEBUFFER_FETCH_AVAILABLE 1
					#define UNITY_NO_CUBEMAP_ARRAY 1
					#define UNITY_NO_SCREENSPACE_SHADOWS 1
					#define UNITY_PBS_USE_BRDF2 1
					#define SHADER_API_MOBILE 1
					#define UNITY_HARDWARE_TIER3 1
					#define UNITY_COLORSPACE_GAMMA 1
					#define UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS 1
					#define UNITY_LIGHTMAP_DLDR_ENCODING 1
					#define CRI_ALPHA_MOVIE 1
					#define CRI_APPLY_TARGET_ALPHA 1
					#define CRI_LINEAR_COLORSPACE 1
					#ifndef SHADER_TARGET
					    #define SHADER_TARGET 25
					#endif
					#ifndef SHADER_REQUIRE_DERIVATIVES
					    #define SHADER_REQUIRE_DERIVATIVES 1
					#endif
					#ifndef SHADER_TARGET_AVAILABLE
					    #define SHADER_TARGET_AVAILABLE 25
					#endif
					#ifndef SHADER_AVAILABLE_DERIVATIVES
					    #define SHADER_AVAILABLE_DERIVATIVES 1
					#endif
					#ifndef SHADER_AVAILABLE_FRAGCOORD
					    #define SHADER_AVAILABLE_FRAGCOORD 1
					#endif
					#ifndef SHADER_API_GLES
					    #define SHADER_API_GLES 1
					#endif
					#line 1
					#ifndef GLSL_SUPPORT_INCLUDED
					#define GLSL_SUPPORT_INCLUDED
					
					// Automatically included in raw GLSL (GLSLPROGRAM) shader snippets, to map from some of the legacy OpenGL
					// variable names to uniform names used by Unity.
					
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					    precision highp float;
					#else
					    precision mediump float;
					#endif
					
					uniform mat4 unity_ObjectToWorld;
					uniform mat4 unity_WorldToObject;
					uniform mat4 unity_MatrixVP;
					uniform mat4 unity_MatrixV;
					uniform mat4 unity_MatrixInvV;
					uniform mat4 glstate_matrix_projection;
					
					#define gl_ModelViewProjectionMatrix        (unity_MatrixVP * unity_ObjectToWorld)
					#define gl_ModelViewMatrix                  (unity_MatrixV * unity_ObjectToWorld)
					#define gl_ModelViewMatrixTranspose         (transpose(unity_MatrixV * unity_ObjectToWorld))
					#define gl_ModelViewMatrixInverseTranspose  (transpose(unity_WorldToObject * unity_MatrixInvV))
					#define gl_NormalMatrix                     (transpose(mat3(unity_WorldToObject * unity_MatrixInvV)))
					#define gl_ProjectionMatrix                 glstate_matrix_projection
					
					#if __VERSION__ < 120
					#ifndef UNITY_GLSL_STRIP_TRANSPOSE
					mat3 transpose(mat3 mtx)
					{
					    vec3 c0 = mtx[0];
					    vec3 c1 = mtx[1];
					    vec3 c2 = mtx[2];
					
					    return mat3(
					        vec3(c0.x, c1.x, c2.x),
					        vec3(c0.y, c1.y, c2.y),
					        vec3(c0.z, c1.z, c2.z)
					    );
					}
					mat4 transpose(mat4 mtx)
					{
					    vec4 c0 = mtx[0];
					    vec4 c1 = mtx[1];
					    vec4 c2 = mtx[2];
					    vec4 c3 = mtx[3];
					
					    return mat4(
					        vec4(c0.x, c1.x, c2.x, c3.x),
					        vec4(c0.y, c1.y, c2.y, c3.y),
					        vec4(c0.z, c1.z, c2.z, c3.z),
					        vec4(c0.w, c1.w, c2.w, c3.w)
					    );
					}
					#endif
					#endif // __VERSION__ < 120
					
					#endif // GLSL_SUPPORT_INCLUDED
					
					#line 36
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					
					#line 29
					#ifdef DUMMY_PREPROCESSOR_TO_WORK_AROUND_HLSL_COMPILER_LINE_HANDLING
					#endif
					/* UNITY: Original start of shader */
								//version 100 // this will be converted to 300 es when using OpenGLES3
								// #pragma multi_compile _ CRI_ALPHA_MOVIE
								// #pragma multi_compile _ CRI_APPLY_TARGET_ALPHA
								// #pragma multi_compile _ CRI_LINEAR_COLORSPACE
														
					
					#ifdef VERTEX
					
					   attribute vec4 _glesVertex;
					   attribute vec4 _glesMultiTexCoord0;
					   #ifdef CRI_APPLY_TARGET_ALPHA
					   attribute vec4 _glesColor;
					   varying lowp float alpha;
					   #endif
					   uniform highp vec4 _MainTex_ST;
					   uniform highp vec4 _MovieTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD0;
					   #ifdef CRI_ALPHA_MOVIE
					   uniform highp vec4 _AlphaTexture_ST;
					   varying mediump vec2 xlv_TEXCOORD1;
					   #endif
					   void main ()
					   {
					    highp vec4 tmpvar;
					    tmpvar.w = 1.0;
					    tmpvar.xyz = _glesVertex.xyz;
					    gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar)); // UnityObjectToClipPos(*)
					    xlv_TEXCOORD0 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _MovieTexture_ST.xy) + _MovieTexture_ST.zw;
					   #ifdef  CRI_ALPHA_MOVIE
					    xlv_TEXCOORD1 = (((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw) * _AlphaTexture_ST.xy) + _AlphaTexture_ST.zw;
					   #endif
					   #ifdef CRI_APPLY_TARGET_ALPHA
					    alpha = _glesColor.w;
					   #endif
					   }
					   
					#endif
					#ifdef FRAGMENT
					#ifdef GL_FRAGMENT_PRECISION_HIGH
					precision highp float;
					#else
					precision mediump float;
					#endif
					precision highp int;
					
								
								
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
								uniform samplerExternalOES _TextureRGB;
								#else
								uniform sampler2D _TextureRGB;
								#endif
								varying mediump vec2 xlv_TEXCOORD0;
								uniform lowp float _Transparency;
								#ifdef 	CRI_ALPHA_MOVIE
								uniform sampler2D _TextureA;
								varying mediump vec2 xlv_TEXCOORD1;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
								varying lowp float alpha;
								#endif
								void main ()
								{
								#if (defined(SHADER_API_GLES3) && defined(GL_OES_EGL_image_external_essl3)) || defined(GL_OES_EGL_image_external) && !defined(SHADER_API_GLCORE)
									gl_FragData[0] = texture2D(_TextureRGB, xlv_TEXCOORD0);
								#else
									gl_FragData[0].x = gl_FragData[0].y = gl_FragData[0].z = 0.0f;
								#endif
								#ifdef CRI_LINEAR_COLORSPACE
									gl_FragData[0].x = pow(max(gl_FragData[0].x, 0), 2.2);
									gl_FragData[0].y = pow(max(gl_FragData[0].y, 0), 2.2);
									gl_FragData[0].z = pow(max(gl_FragData[0].z, 0), 2.2);
								#endif
								#ifdef 	CRI_ALPHA_MOVIE
									gl_FragData[0].w = texture2D(_TextureA, xlv_TEXCOORD1).x;
								#endif
								#ifdef CRI_APPLY_TARGET_ALPHA
									gl_FragData[0].w *= alpha;
								#endif
									gl_FragData[0].w *= 1.0 - _Transparency;
								}
								
					#endif"
				}
			}
		}
	}
}