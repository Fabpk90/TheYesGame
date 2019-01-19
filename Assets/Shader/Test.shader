﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/TestingTheTest" 
{
    Properties {
		_Tint ("Tint", Color) = (1, 1, 1, 1)
		_MainTex ("Texture", 2D) = "white" {}
	}

	SubShader 
    {
		Pass 
        {
           CGPROGRAM

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

            #include "UnityCG.cginc"

            float4 _Tint;
			float4 _MainTex_ST;
			sampler2D _MainTex;

            struct Interpolators {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			struct VertexData {
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
			};

            Interpolators MyVertexProgram (VertexData data) {
				Interpolators i;
				i.uv = TRANSFORM_TEX(data.uv, _MainTex);
				i.position = UnityObjectToClipPos(data.position);
				return i;
			}

			float4 MyFragmentProgram (Interpolators i) : SV_TARGET {
				return tex2D(_MainTex, i.uv) * _Tint;
			}

			ENDCG
		}
	}
}