// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "UI/Default2"
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
		_InsideColor("Color (RGB)", Color) = (1,1,1,1)
		_StrokeColor("Stroke Color (RGB)", Color) = (0,0,0,1)
		_StrokeThickness("Stroke Thickness", Range(0,1)) = 0.05

		_Color1("Color1 (RGB)", Color) = (0,0,0,1)
		_Color2("Color2 (RGB)", Color) = (0,0,0,1)
		_Color3("Color3 (RGB)", Color) = (0,0,0,1)
		_Color4("Color4 (RGB)", Color) = (0,0,0,1)
		_Color5("Color5 (RGB)", Color) = (0,0,0,1)
		_Color6("Color6 (RGB)", Color) = (0,0,0,1)
		_Color7("Color7 (RGB)", Color) = (0,0,0,1)
		_Color8("Color7 (RGB)", Color) = (0,0,0,1)
		_Scale("Scale", Vector) = (1,1,1,1)
		_Glow("Intensity", Range(0, 3)) = 1
		_GlowIndex("Intensity2", Int) = 1
		[Toggle] _isBending("is Bending", Float) = 0
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
		float4 _InsideColor;
		float4 _StrokeColor;
		float4 _Color1;
		float4 _Color2;
		float4 _Color3;
		float4 _Color4;
		float4 _Color5;
		float4 _Color6;
		float4 _Color7;
		float4 _Color8;
		static const float2 _ColorVector[8] =
		{
			float2(cos(2 * M_PI * 0 / 8 + 3 * M_PI / 8),sin(2 * M_PI * 0 / 8 + 3 * M_PI / 8)),
			float2(cos(2 * M_PI * 1 / 8 + 3 * M_PI / 8),sin(2 * M_PI * 1 / 8 + 3 * M_PI / 8)),
			float2(cos(2 * M_PI * 2 / 8 + 3 * M_PI / 8),sin(2 * M_PI * 2 / 8 + 3 * M_PI / 8)),
			float2(cos(2 * M_PI * 3 / 8 + 3 * M_PI / 8),sin(2 * M_PI * 3 / 8 + 3 * M_PI / 8)),
			float2(cos(2 * M_PI * 4 / 8 + 3 * M_PI / 8),sin(2 * M_PI * 4 / 8 + 3 * M_PI / 8)),
			float2(cos(2 * M_PI * 5 / 8 + 3 * M_PI / 8),sin(2 * M_PI * 5 / 8 + 3 * M_PI / 8)),
			float2(cos(2 * M_PI * 6 / 8 + 3 * M_PI / 8),sin(2 * M_PI * 6 / 8 + 3 * M_PI / 8)),
			float2(cos(2 * M_PI * 7 / 8 + 3 * M_PI / 8),sin(2 * M_PI * 7 / 8 + 3 * M_PI / 8))
		};
		static const float2 _AlphaVector[7] =
		{
			float2(0,0),
			float2(0.1,0),
			float2(0.4,0.15),
			float2(0.6,0.15),
			float2(0.9,0),
			float2(0.93,0),
			float2(1,-0.15)
		};
		float _StrokeThickness;
		float _Glow;
		int _GlowIndex;
		float _None;
		bool _isBending;
		float4 _Scale;
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
		float gets(float currentValue, float radiusSquared) {
			float normalized = currentValue / radiusSquared;
			if (_AlphaVector[0].x <= normalized && normalized < _AlphaVector[1].x)
				return lerp(_AlphaVector[0].y, _AlphaVector[1].y, lerpInverse(_AlphaVector[0].x, _AlphaVector[1].x, normalized));
			else if (_AlphaVector[1].x <= normalized && normalized < _AlphaVector[2].x)
				return lerp(_AlphaVector[1].y, _AlphaVector[2].y, lerpInverse(_AlphaVector[1].x, _AlphaVector[2].x, normalized));
			else if (_AlphaVector[2].x <= normalized && normalized < _AlphaVector[3].x)
				return lerp(_AlphaVector[2].y, _AlphaVector[3].y, lerpInverse(_AlphaVector[2].x, _AlphaVector[3].x, normalized));
			else if (_AlphaVector[3].x <= normalized && normalized < _AlphaVector[4].x)
				return lerp(_AlphaVector[3].y, _AlphaVector[4].y, lerpInverse(_AlphaVector[3].x, _AlphaVector[4].x, normalized));
			else if (_AlphaVector[4].x <= normalized && normalized < _AlphaVector[5].x)
				return lerp(_AlphaVector[4].y, _AlphaVector[5].y, lerpInverse(_AlphaVector[4].x, _AlphaVector[5].x, normalized));
			else if (_AlphaVector[5].x <= normalized && normalized < _AlphaVector[6].x)
				return lerp(_AlphaVector[5].y, _AlphaVector[6].y, lerpInverse(_AlphaVector[5].x, _AlphaVector[6].x, normalized));
			else
				return _AlphaVector[6].y;
		}
		float getGlow(int index)
		{
			return (_GlowIndex == index) ? _Glow : 1;
		}
		bool isInsideSector(float2 relPoint,float2 sectorStart,float2 sectorEnd,float radiusSquared) {

			return (!areClockwise(sectorStart, relPoint) && areClockwise(sectorEnd, relPoint) && isWithinRadius(relPoint, radiusSquared));
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
					float emittSpeed = M_PI / _StrokeThickness;
					//(x - center_x)^2 + (y - center_y)^2 < radius^2
					float x = IN.texcoord.x - 0.5;
					float y = IN.texcoord.y - 0.5;

					inside = x * x + y * y;
					float _ss = _StrokeThickness / _Scale.x;
					if (inside < 0.25)
					{
						float radiusSquared = (0.5 - _ss) * (0.5 - _ss);
						if (inside < radiusSquared)
						{
							float coff = gets(inside, radiusSquared);

							if (isInsideSector(float2(x, y), _ColorVector[0], _ColorVector[1], radiusSquared))
								color.rgba = _Color1 * getGlow(0);
							else if (isInsideSector(float2(x, y), _ColorVector[1], _ColorVector[2], radiusSquared))
								color.rgba = _Color2 * getGlow(1);
							else if (isInsideSector(float2(x, y), _ColorVector[2], _ColorVector[3], radiusSquared))
								color.rgba = _Color3 * getGlow(2);
							else if (isInsideSector(float2(x, y), _ColorVector[3], _ColorVector[4], radiusSquared))
								color.rgba = _Color4 * getGlow(3);
							else if (isInsideSector(float2(x, y), _ColorVector[4], _ColorVector[5], radiusSquared))
								color.rgba = _Color5 * getGlow(4);
							else if (isInsideSector(float2(x, y), _ColorVector[5], _ColorVector[6], radiusSquared))
								color.rgba = _Color6 * getGlow(5);
							else if (isInsideSector(float2(x, y), _ColorVector[6], _ColorVector[7], radiusSquared))
								color.rgba = _Color7 * getGlow(6);
							else if (isInsideSector(float2(x, y), _ColorVector[7], _ColorVector[0], radiusSquared))
								color.rgba = _Color8 * getGlow(7);
							else
								color.rgb = _InsideColor;
							color.rgb += coff;
							//color.a = 1;
							//if (_isBending)
							//	color.a = (1 - inside / radiusSquared) * _InsideColor.a;
							//else
							//	color.a = (inside / radiusSquared) * _InsideColor.a;
						}
						else
						{
							float u = sqrt(inside);
							float v = atan2(y, x);
							float i = 0;
							float part = modf(_Scale.x, i);

							float xx = (_Scale.x*(u - (.5 - _StrokeThickness)) / (sqrt(0.25))) / (2 * _StrokeThickness) - part;
							float yy = ((emittSpeed *_Scale.x *(v + M_PI) / (2 * M_PI)));
							float2 mHexCoord = float2(xx, yy);
							half4 d = tex2D(_MainTex, mHexCoord);
							//o.Albedo = _StrokeColor;
							color.rgb = _StrokeColor.rgb*d;
							color.a = _StrokeColor.a*d.a;
						}
					}
					else
					{
						color.a = 0;
					}
					//color.Emission = o.Albedo;


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
