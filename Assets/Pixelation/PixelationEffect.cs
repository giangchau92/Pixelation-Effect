using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class PixelationEffect : ImageEffectBase {
	public int _scale;

	void OnRenderImage(RenderTexture source, RenderTexture destination) {
		RenderTexture small = RenderTexture.GetTemporary (source.width / _scale, source.height / _scale);
		Graphics.Blit (source, small);
		small.filterMode = FilterMode.Point;
		Graphics.Blit (small, destination);
		RenderTexture.ReleaseTemporary (small);
	}
}
