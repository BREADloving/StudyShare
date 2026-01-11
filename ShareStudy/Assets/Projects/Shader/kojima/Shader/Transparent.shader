Shader "Custom/Transparent" {
	Properties
	{
		//色を設定するアトリビュートを作る
		_alpha("alpha", Range(0,1)) = 1.0
		_color("color", Color) = (1.0, 1.0, 1.0)
	}

	SubShader{
		Tags { "Queue" = "Transparent" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard alpha:fade 
		#pragma target 3.0

		struct Input {
			float2 uv_MainTex;
		};

		float _alpha = 1;
		fixed4 _color = 1;
		void surf(Input IN, inout SurfaceOutputStandard o) {
			o.Albedo = _color;
			o.Alpha = _alpha;
		}
		ENDCG
	}
	FallBack "Diffuse"
}