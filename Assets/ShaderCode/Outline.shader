Shader "Custom/TextureOutline"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _OutlineColor("Outline Color", Color) = (0,0,0,1)
        _OutlineThickness("Outline Thickness", Range(0.001, 0.05)) = 0.01
    }
        SubShader
        {
            Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            Lighting Off
            ZWrite Off

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_TexelSize; // x = 1/width, y = 1/height
                float4 _OutlineColor;
                float _OutlineThickness;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float2 uv = i.uv;
                    fixed4 mainCol = tex2D(_MainTex, uv);

                    // If alpha already exists, we check surrounding pixels for outline
                    float alpha = mainCol.a;
                    if (alpha < 0.1)
                    {
                        // sample around for outline
                        float2 offset = _OutlineThickness * _MainTex_TexelSize.xy;
                        float outline = 0.0;

                        outline += tex2D(_MainTex, uv + float2(offset.x, 0)).a;
                        outline += tex2D(_MainTex, uv + float2(-offset.x, 0)).a;
                        outline += tex2D(_MainTex, uv + float2(0, offset.y)).a;
                        outline += tex2D(_MainTex, uv + float2(0,-offset.y)).a;

                        if (outline > 0.0)
                            return _OutlineColor;
                    }

                    return mainCol;
                }
                ENDCG
            }
        }
}
