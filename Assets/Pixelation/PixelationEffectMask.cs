using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class PixelationEffectMask : ImageEffectBase {
	public Material _materialMain;
	public int _scale;

	public Camera _camera;
	Camera _thisCamera;
	RenderTexture _savedRT = null;

	void Awake() {
		_thisCamera = GetComponent<Camera> ();
//		_camera.CopyFrom (_thisCamera);
	}

	void OnRenderImage(RenderTexture source, RenderTexture destination) {
		_savedRT = RenderTexture.GetTemporary (source.width, source.height, 24, RenderTextureFormat.ARGB32);
		RenderTexture.active = _savedRT;
		GL.Clear (false, true, Color.clear);
		RenderTexture.active = null;
		_camera.targetTexture = _savedRT;
		_camera.Render ();
		_camera.targetTexture = null;

		//
		RenderTexture small = RenderTexture.GetTemporary (source.width / _scale, source.height / _scale);
		Graphics.Blit (source, small);
		small.filterMode = FilterMode.Point;

		_materialMain.SetTexture("_SmallTex", small);
		_materialMain.SetTexture("_MaskTex", _savedRT);

		Graphics.Blit (source, destination, _materialMain);
		RenderTexture.ReleaseTemporary(small);
		RenderTexture.ReleaseTemporary(_savedRT);
	}
}
