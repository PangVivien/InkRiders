Shader "Unlit/CannyEdge"

{

    Properties

    {

        _MainTex("Texture", 2D) = "white" {}

        _Threshold("Edge Threshold", Range(0, 1)) = 0.2

    }

        SubShader

        {

            Tags { "RenderType" = "Opaque" }

            LOD 100


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

                float4 _MainTex_TexelSize; // Unity provides 1/width,1/height

                float _Threshold;


                v2f vert(appdata v)

                {

                    v2f o;

                    o.vertex = UnityObjectToClipPos(v.vertex);

                    o.uv = v.uv;

                    return o;

                }


                fixed4 frag(v2f i) : SV_Target

                {

                    // Convert to grayscale

                    fixed3 tc = tex2D(_MainTex, i.uv).rgb;

                    float gray = dot(tc, float3(0.299, 0.587, 0.114));


                    // Sobel kernel offsets

                    float2 texel = _MainTex_TexelSize.xy;


                    float gx =

                          -1.0 * tex2D(_MainTex, i.uv + texel * float2(-1,-1)).r

                        + -2.0 * tex2D(_MainTex, i.uv + texel * float2(-1, 0)).r

                        + -1.0 * tex2D(_MainTex, i.uv + texel * float2(-1, 1)).r

                        + 1.0 * tex2D(_MainTex, i.uv + texel * float2(1,-1)).r

                        + 2.0 * tex2D(_MainTex, i.uv + texel * float2(1, 0)).r

                        + 1.0 * tex2D(_MainTex, i.uv + texel * float2(1, 1)).r;


                    float gy =

                          -1.0 * tex2D(_MainTex, i.uv + texel * float2(-1,-1)).r

                        + -2.0 * tex2D(_MainTex, i.uv + texel * float2(0,-1)).r

                        + -1.0 * tex2D(_MainTex, i.uv + texel * float2(1,-1)).r

                        + 1.0 * tex2D(_MainTex, i.uv + texel * float2(-1, 1)).r

                        + 2.0 * tex2D(_MainTex, i.uv + texel * float2(0, 1)).r

                        + 1.0 * tex2D(_MainTex, i.uv + texel * float2(1, 1)).r;


                    float edgeStrength = sqrt(gx * gx + gy * gy);


                    // Threshold

                    float edge = edgeStrength > _Threshold ? 1.0 : 0.0;


                    return float4(edge.xxx, 1.0);

                }

                ENDCG

            }

        }

}

