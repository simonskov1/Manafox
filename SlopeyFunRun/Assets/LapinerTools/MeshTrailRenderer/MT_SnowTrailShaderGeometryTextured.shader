// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/SnowTrailShaderGeometryTextured"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Offset ("Z Buffer Offset", Float) = 0.02
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue" = "Geometry-75" }
		Offset -1, -1
		ZWrite Off
		
		CGPROGRAM
		#pragma surface surf Lambert vertex:vert

		#include "UnityCG.cginc"

		sampler2D _MainTex;
		fixed4 _Color;
		
		void vert(inout appdata_full v)
		{
			float3 viewDir = WorldSpaceViewDir(v.vertex);
			float viewDirLength = length(viewDir);
			v.vertex.xyz += normalize(viewDir)*min(viewDirLength*0.75, 0.75);
		}

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color; 
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
		
		Pass
        {
			Name "ZWriter"
			Blend One One
			Offset -1, -1
			ZWrite On
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"
			
			struct v2f
			{
				float4 pos          : POSITION;
			};
			
			float _Offset;
			
			v2f vert (appdata_full v)
			{
				v2f o;
				
				o.pos = mul(unity_ObjectToWorld, v.vertex);
				
				// apply z buffer offset
				float3 zOffset = _Offset*normalize(_WorldSpaceCameraPos - o.pos.xyz);
				o.pos.xyz += zOffset;
				
				o.pos = mul(UNITY_MATRIX_VP, o.pos);
				
				return o;
			}
			
			half4 frag(v2f i) : COLOR
			{
				return half4(0, 0, 0, 0);
			}
			ENDCG
        }
	}
}
