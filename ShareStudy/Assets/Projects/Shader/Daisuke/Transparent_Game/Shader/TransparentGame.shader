Shader "Custom/TransparentGame"{
        Properties{
        _BaseColor("Base Color", Color) = (0,0,0,1)
        _alpha("alpha", Range(0, 1)) = 1.0
    }
    SubShader{
        Tags { "Queue" = "Transparent" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard alpha:fade
        #pragma target 3.0

        struct Input{
            float2 uv_MainTex;
        };

        fixed4 _BaseColor;
        fixed _alpha;

        void surf (Input IN, inout SurfaceOutputStandard o){
            o.Albedo = _BaseColor;
            o.Alpha = _alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
