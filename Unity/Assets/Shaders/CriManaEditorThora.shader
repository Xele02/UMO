Shader "CriMana/EditorTheora" {
	Properties {
		_MainTex  ("Texture", 2D)   = "white" {}
		_MovieTexture_ST ("MovieUvTransform", Vector) = (1, 1, 0, 0)
		[HideInInspector] _SrcBlendMode ("SrcBlendMode", Float) = 0
		[HideInInspector] _DstBlendMode ("DstBlendMode", Float) = 0
		[HideInInspector] _CullMode ("CullMode", Float) = 2
		[HideInInspector] _ZWriteMode ("ZWriteMode", Float) = 1
	}
	SubShader {
		Tags {"Queue" = "Transparent"}
		Pass {
			Blend [_SrcBlendMode] [_DstBlendMode]
			ZWrite [_ZWriteMode]
			Cull [_CullMode]

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#if defined(SHADER_API_PSP2) || defined(SHADER_API_PS3)
			// seems that ARB_precision_hint_fastest is not supported on these platforms.
			#else
			#pragma fragmentoption ARB_precision_hint_fastest
			#endif

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4x4  MovieUvTransform;

			struct appdata {
				float4 vertex   : POSITION;
				half2  texcoord : TEXCOORD0;
			};

			struct v2f {
				float4   pos : SV_POSITION;
				half2     uv : TEXCOORD0;
			};


			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv  = mul(MovieUvTransform, float4(TRANSFORM_TEX(v.texcoord, _MainTex), 0.0, 1.0));
				//o.uv.y = 1 - o.uv.y;
				return o;
			}

			fixed4 frag(v2f i) : COLOR
			{
				fixed4 color;
				color.rgb = tex2D(_MainTex, i.uv).rgb;
				color.a   = 1.0;
				return color;
			}
			ENDCG

		}
	}
}