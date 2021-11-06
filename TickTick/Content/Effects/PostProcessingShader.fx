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
	float4 origTex = tex2D(SpriteTextureSampler, input.TextureCoordinates + 
									float2(0, sin(TimeInSeconds) + sin((input.TextureCoordinates.x + (TimeInSeconds)) * 3) ) / 4);
											//(input.TextureCoordinates.x * TimeInSeconds % (sin(TimeInSeconds / 10) * 200)) / 2));

	float4 origColor = float4(	input.Color.r * sin(TimeInSeconds + input.TextureCoordinates.y * 2 + 
																	cos(input.TextureCoordinates.x * sin(40* TimeInSeconds) + TimeInSeconds)),
								input.Color.g * sin(TimeInSeconds + input.TextureCoordinates.y * 4 + 
																	cos(input.TextureCoordinates.x * cos(31 * TimeInSeconds) + TimeInSeconds)),
								input.Color.b * sin(TimeInSeconds + input.TextureCoordinates.y * 7 + 
																	cos(input.TextureCoordinates.x * sin(17 * TimeInSeconds) + TimeInSeconds)),
								input.Color.a);

	return origTex * origColor;
}


technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};