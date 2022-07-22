Shader "CriMana/AndroidH264Rgb" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
	}

	SubShader {
		Tags {"Queue" = "Transparent"}

		Pass {
			Blend Off

			GLSLPROGRAM
#version 100

#ifdef VERTEX
precision highp float;
attribute vec4 _glesVertex;
attribute vec4 _glesMultiTexCoord0;
uniform highp mat4 glstate_matrix_mvp;
uniform highp mat4 MovieUvTransform;
uniform highp vec4 _MainTex_ST;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  highp vec4 tmpvar_1;
  tmpvar_1.zw = vec2(0.0, 1.0);
  tmpvar_1.xy = ((_glesMultiTexCoord0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
  gl_Position = (glstate_matrix_mvp * _glesVertex);
  xlv_TEXCOORD0 = (MovieUvTransform * tmpvar_1).xy;
}
#endif

#ifdef FRAGMENT
#extension GL_OES_EGL_image_external : require
precision highp float;
uniform samplerExternalOES TextureRgb;
varying mediump vec2 xlv_TEXCOORD0;
void main ()
{
  gl_FragData[0] = texture2D (TextureRgb, xlv_TEXCOORD0);
}
#endif
			ENDGLSL
		}
	}
}
