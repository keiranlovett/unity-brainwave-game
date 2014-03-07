/*! 
 * \file
 * \author Stig Olavsen <stig.olavsen@randomrnd.com>
 * \author http://www.RandomRnD.com
 * \date © 2011-August-05
 * \brief The shader definition for the HealthBar/HealthBar Opaque shader
 * \details An opaque shader with two texture inputs and a ratio control
 * that lets you set the display ratio of the two textures
 */

Shader "HealthBar/HealthBar Opaque" {
	Properties {
		_MainColor ("Base Color", Color) = (1,1,1,1)
		_BackgroundColor ("Background Color", Color) = (0,0,0,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_BackgroundTex ("Base (RGB)", 2D) = "white" {}
		_Health ("Health", Range(0.0, 1.0)) = 1.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _BackgroundTex;
		fixed4 _MainColor;
		fixed4 _BackgroundColor;
		float _Health;

		struct Input 
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			half4 c;
			if (IN.uv_MainTex.x < _Health)
			{
				c = tex2D (_MainTex, IN.uv_MainTex) * _MainColor;
			}
			else
			{
				c = tex2D (_BackgroundTex, IN.uv_MainTex) * _BackgroundColor;
			}
			o.Albedo = c.rgb;
		}
		
		ENDCG
	} 
	FallBack "Diffuse"
}
