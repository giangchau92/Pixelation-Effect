using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	public PixelationEffect _pixelEffect;
	public PixelationEffectMask _pixelEffectMask;
	public UnityEngine.UI.Slider _slider;

	int _index = 0;

	public void OnChangeClick() {
		_index = ++_index % 3;
		if (_index == 0) {
			_pixelEffect.enabled = false;
			_pixelEffectMask.enabled = false;
		} else if (_index == 1) {
			_pixelEffect.enabled = true;
			_pixelEffectMask.enabled = false;
		} else {
			_pixelEffect.enabled = false;
			_pixelEffectMask.enabled = true;
		}
	}

	public void OnSlideChange() {
		_pixelEffect._scale = (int)_slider.value;
		_pixelEffectMask._scale = (int)_slider.value;
	}
}
