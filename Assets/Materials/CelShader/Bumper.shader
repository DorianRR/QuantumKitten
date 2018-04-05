Shader "CelShader: Specular, Emissive, Transparency, Cutout" 
{
   Properties 
   {
        _MainTex ("Main Texture", 2D) = " " {}
        _BaseColor ("Base Color Addition", Color) = (1,1,1,1)
        //_NormalMap ("Normal Map", 2D) = "bump" {}
        _NotLitColor ("Shadow Color Addition", Color) = (0.0,0.0,0,1)
        _ShadowCoverage ("Shadow Coverage", Range(-1.1,1)) = 0.1
        _SpecularHighlightColor ("Specular Highlight Color", Color) = (1,1,1,1)
        _SpecularCoverageArea ("Specular Area Coverage", Range(0.0,1)) = 1 
        _BlackLineBorderThickness ("Black Border Line Thickness", Range(0,1)) = 0.1
        _EmitMap ("Emission Map", 2D) = "black" {}
        _EmitStrength ("Emission Strength", Range( 0.0, 10.0 )) = 0
        _TransparencyMap ("Transparency Map", 2D) = "white" {}
        _Transparency("Transparency", Range(0.0, 1.0)) = 0.25
        _CutoutMap("Cutout Map", 2D) = "black" {}
        _CutoutThresh("Cutout Threshold", Range(0.0,0.8)) = 0.0


    }
   
    SubShader 
    {
        

        Pass 
        {
			Tags{ "LightMode"="ForwardBase" "Que"="Transparent" "RenderType"="Transparent"  }


			Zwrite Off
			Blend SrcAlpha OneMinusSrcAlpha 
			Cull back

            CGPROGRAM
        
            #pragma vertex vert
            #pragma fragment frag

            uniform float4 _BaseColor;
            uniform float4 _NotLitColor;
            uniform float _ShadowCoverage;
            uniform float4 _SpecularHighlightColor;
            uniform float _SpecularCoverageArea;
            uniform float _BlackLineBorderThickness;
            uniform sampler2D _EmitMap;
            uniform float4 _EmitMap_ST;
            uniform float _EmitStrength;
            uniform sampler2D _TransparencyMap;
            float _Transparency;
            float _CutoutThresh;
            uniform sampler2D _CutoutMap;
            //uniform sampler2D _NormalMap;
            //uniform float4 _NormalMap_ST;

            uniform float4 _LightColor0;
            uniform sampler2D _MainTex;
            uniform float4 _MainTex_ST;  

        
            struct vertexInput 
            {
            
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
                
            };
        
            struct vertexOutput 
            {
            
                float4 pos : SV_POSITION;
                float3 Normal : TEXCOORD1;
                float4 lightDir : TEXCOORD2;
                float3 viewDir : TEXCOORD3;
                float2 uv : TEXCOORD0;

            };
    
            vertexOutput vert(vertexInput i)
            {
                vertexOutput o;
            
                o.Normal = normalize ( mul ( float4( i.normal, 0.0 ), unity_WorldToObject).xyz);
            
                float4 posWorld = mul(unity_ObjectToWorld, i.vertex);
            
                o.viewDir = normalize( _WorldSpaceCameraPos.xyz - posWorld.xyz );
            
                float3 fragToLight = ( _WorldSpaceCameraPos.xyz - posWorld.xyz);
                o.lightDir = float4
                (
                    normalize( lerp(_WorldSpaceLightPos0.xyz , fragToLight, _WorldSpaceLightPos0.w) ),
                    lerp(1.0 , 1.0/length(fragToLight), _WorldSpaceLightPos0.w)

                );
            
                o.pos = UnityObjectToClipPos( i.vertex );  
            
                o.uv =i.texcoord;	

                return o;
            
            }
        
            float4 frag(vertexOutput i) : COLOR
            {

                float nDotL = saturate(dot(i.Normal, i.lightDir.xyz));
                    
                float shadowCutoff = saturate( ( max(_ShadowCoverage, nDotL) - _ShadowCoverage ) *1000 );
                    
                float specCoverage = saturate( max(_SpecularCoverageArea, dot(reflect(-i.lightDir.xyz, i.Normal), i.viewDir))-_SpecularCoverageArea ) * 1000;
                    
                float blackLine = saturate( (dot(i.Normal, i.viewDir ) - _BlackLineBorderThickness) * 1000 );

                float4 textureEmissive = tex2D( _EmitMap, i.uv.xy * _EmitMap_ST.xy + _EmitMap_ST.zw );

                float4 textureCutout = tex2D( _CutoutMap, i.uv.xy);

                float4 textureTransparency = tex2D( _TransparencyMap, i.uv.xy);

                float3 ambientLight = (1-shadowCutoff) * _NotLitColor.xyz; 
                float3 diffuseReflection = (1-specCoverage) * _BaseColor.xyz * shadowCutoff;
                float3 specularReflection = _SpecularHighlightColor.xyz * specCoverage;
                
                float3 combinedLight = (ambientLight + diffuseReflection) * blackLine + specularReflection + (textureEmissive.xyz * _EmitStrength);

                fixed4 combinedTexture = float4(combinedLight, 1.0) * tex2D(_MainTex, i.uv); 

                combinedTexture.a = (textureTransparency + _Transparency);

                clip(textureCutout.r - _CutoutThresh);

                return combinedTexture;
            
            }
            ENDCG
        }
 
    }
    Fallback "Diffuse"
}