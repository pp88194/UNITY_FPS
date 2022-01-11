Shader "Custom/CircleShader"
{
    Properties
    {
        _MainTex("", 2D) = "" {}
    }
        SubShader
    {
        Pass
        {
            ZTest Always 
            Cull Off 
            ZWrite Off
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _Intencity;

            half4 frag(v2f_img i) : SV_Target
            {
                float2 screenPos = _ScreenParams.xy * i.uv;
                float2 center = _ScreenParams.xy * 0.5;
                float distance = length(center - screenPos);
                //float fade = distance <= _Intencity ? 1 : distance / 1024;
                float fade = 1 - distance / abs(_Intencity);
                //float fade = distance;
                half4 src = tex2D(_MainTex, i.uv);
                return half4(src.rgb * fade, src.a);
            }
            ENDCG
        }
    }
}