Shader "CurrentBar/CurrentBar Opaque" {
	Properties {
		_MainColor ("Base Color", Color) = (1,1,1,1)
		_BackgroundColor ("Background Color", Color) = (0,0,0,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MeterTex ("Base (RGB)", 2D) = "white" {}
		_Current ("Current", Range(0.0, 1.0)) = 1.0
		_Average ("Average", Range(0.0, 1.0)) = 1.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _MeterTex;
		fixed4 _MainColor;
		fixed4 _BackgroundColor;
		float _Current;

		struct Input 
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			half4 c;
			if (IN.uv_MainTex.x < _Current)
			{
				c = tex2D (_MainTex, IN.uv_MainTex) * _MainColor;
			}
			else
			{
				c = tex2D (_MeterTex, IN.uv_MainTex) * _BackgroundColor;
			}
			o.Albedo = c.rgb;
		}
		
		ENDCG
	} 
	FallBack "Diffuse"
}
