Shader "Custom/Pixelation" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _MaskTex ("Mask (RGB)", 2D) = "white" {}
    }
    SubShader {
        Pass {

            CGPROGRAM

            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            uniform sampler2D _MainTex;
            uniform sampler2D _SmallTex;
            uniform sampler2D _MaskTex;

            fixed4 frag (v2f_img i) : COLOR
            {
            	#if UNITY_UV_STARTS_AT_TOP
            	half2 offset = half2(i.uv.x, 1 - i.uv.y);
            	#else
            	half2 offset = i.uv;
            	#endif

                fixed4 mask = tex2D(_MaskTex, offset);
                if (mask.a != 0) {
                	fixed4 small = tex2D(_SmallTex, offset);
                	return small;
                } else {
                	fixed4 main = tex2D(_MainTex, i.uv); // source
					return main;
				}
            }


            ENDCG
        }
    }
}
