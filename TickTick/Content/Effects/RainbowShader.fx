#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;

float TimeInSeconds;

sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR
{

	float4 newColour = float4(sin((TimeInSeconds + input.TextureCoordinates.x) * 10) * 255 / 128 +
								sin((TimeInSeconds + input.TextureCoordinates.y) * 5) * 255 / 128, 

								sin((TimeInSeconds + input.TextureCoordinates.x) + 0.33333f * 10) * 255 / 128 +
								sin((TimeInSeconds + input.TextureCoordinates.y) * 10) * 255 / 128, 

								sin((TimeInSeconds + input.TextureCoordinates.x) + 0.6666667f * 10) * 255 / 128 +
								sin((TimeInSeconds + input.TextureCoordinates.y) * 20) * 255 / 128,

								input.Color.a);
								//cos((TimeInSeconds * 10) * 255 / 4 + 170));

	return tex2D(SpriteTextureSampler, input.TextureCoordinates) * newColour;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};