Shader "Hidden/GradientShader"
{
    Properties
    {
        _Color1("Top Color", Color) = (1,1,1,1)
        _Color2("Bottom Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float4 _Color1;
            float4 _Color2;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 color : COLOR;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color = lerp(_Color2, _Color1, v.uv.y);
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) : COLOR
            {
                float4 c = i.color;
                c.a = 1;
                return c;
            }
            ENDCG
        }
    }
}