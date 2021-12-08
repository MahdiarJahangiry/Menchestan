// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "UI/JapanFlag"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)

		_StencilComp("Stencil Comparison", Float) = 8
		_Stencil("Stencil ID", Float) = 0
		_StencilOp("Stencil Operation", Float) = 0
		_StencilWriteMask("Stencil Write Mask", Float) = 255
		_StencilReadMask("Stencil Read Mask", Float) = 255

		_ColorMask("Color Mask", Float) = 15

		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip("Use Alpha Clip", Float) = 0


		_Color1("Color1 (RGB)", Color) = (0,0,0,1)
		_Color2("Color2 (RGB)", Color) = (0,0,0,1)
		_NumArc("Number of Arc", Int) = 4
		_Offset("Offset", Range(0, 3.14)) = 0
	}

		SubShader
		{
			Tags
			{
				"Queue" = "Transparent"
				"IgnoreProjector" = "True"
				"RenderType" = "Transparent"
				"PreviewType" = "Plane"
				"CanUseSpriteAtlas" = "True"
			}

			Stencil
			{
				Ref[_Stencil]
				Comp[_StencilComp]
				Pass[_StencilOp]
				ReadMask[_StencilReadMask]
				WriteMask[_StencilWriteMask]
			}

			Cull Off
			Lighting Off
			ZWrite Off
			ZTest[unity_GUIZTestMode]
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask[_ColorMask]

			Pass
			{
				Name "Default"
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 2.0

				#include "UnityCG.cginc"
				#include "UnityUI.cginc"

				#pragma multi_compile __ UNITY_UI_CLIP_RECT
				#pragma multi_compile __ UNITY_UI_ALPHACLIP

				struct appdata_t
				{
					float4 vertex   : POSITION;
					float4 color    : COLOR;
					float2 texcoord : TEXCOORD0;
					UNITY_VERTEX_INPUT_INSTANCE_ID
				};

				struct v2f
				{
					float4 vertex   : SV_POSITION;
					fixed4 color : COLOR;
					float2 texcoord  : TEXCOORD0;
					float4 worldPosition : TEXCOORD1;
					UNITY_VERTEX_OUTPUT_STEREO
				};

				sampler2D _MainTex;
				fixed4 _Color;
				fixed4 _TextureSampleAdd;
				float4 _ClipRect;
				float4 _MainTex_ST;
				#define M_PI 3.1415926535897932384626433832795
		float4 _Color1;
		float4 _Color2;
		int  _NumArc;
		float _Offset;
		static const float _th = 2 * M_PI / _NumArc;

		struct Input {
		float2 uv_MainTex;
		};
		bool areClockwise(float2 v1, float2 v2) {
			return -v1.x*v2.y + v1.y*v2.x > 0;
		}
		bool isWithinRadius(float2 v, float radiusSquared) {
			return v.x*v.x + v.y*v.y <= radiusSquared;
		}
		float lerpInverse(float a, float b, float l) {
			if (b == a)
				return 0;
			return (l - a) / (b - a);
		}
		bool isInsideSector(float2 relPoint,float2 sectorStart,float2 sectorEnd,float radiusSquared) {

			return (!areClockwise(sectorStart, relPoint) && areClockwise(sectorEnd, relPoint) && isWithinRadius(relPoint, radiusSquared));
		}
		int GetColorIndex(float2 xy)
		{
			for (int i = 0; i < _NumArc; i++)
			{
				float2 a = float2(cos(2 * M_PI * i / _NumArc + _Offset), sin(2 * M_PI * i / _NumArc + _Offset));
				int nextIndex = fmod(i + 1, _NumArc);
				float2 b = float2(cos(2 * M_PI * nextIndex / _NumArc + _Offset), sin(2 * M_PI * nextIndex / _NumArc + _Offset));
				if (isInsideSector(xy, a, b,0.5))
					return fmod(nextIndex, 2);
			}
			return 0;
		}
				v2f vert(appdata_t v)
				{
					v2f OUT;
					UNITY_SETUP_INSTANCE_ID(v);
					UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
					OUT.worldPosition = v.vertex;
					OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

					OUT.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);

					OUT.color = v.color * _Color;
					return OUT;
				}

				fixed4 frag(v2f IN) : SV_Target
				{
					half4 color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color;

					float inside = 0;
					//(x - center_x)^2 + (y - center_y)^2 < radius^2
					float x = IN.texcoord.x - 0.5;
					float y = IN.texcoord.y - 0.5;
					int index = GetColorIndex(float2(x, y));
					if (index == 1)
						color.rgba = _Color1;
					else
						color.rgba = _Color2;
					color.rgb = color.rgb + lerp(1,-3,pow(length(float2(x,y)),2))*_Color;
					#ifdef UNITY_UI_CLIP_RECT
					color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
					#endif

					#ifdef UNITY_UI_ALPHACLIP
					clip(color.a - 0.001);
					#endif

					return color;
				}
			ENDCG
			}
		}
}
