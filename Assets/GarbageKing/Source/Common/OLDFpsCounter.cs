using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDFpsCounter : MonoBehaviour
{
	private float _deltaTime = 0.0f;

	private void Update()
	{
		_deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
	}

	private void OnGUI()
	{
		var width = Screen.width;
		var height = Screen.height;

		var style = new GUIStyle();

		var rect = new Rect(0, 0, width, height * 2 / 100);

		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = height * 2 / 100;
		style.normal.textColor = Color.black;

		int fps =(int)(1 / _deltaTime);
		var text = string.Format($"DEVICE OPTIMIZATION TEST-------> {fps} FPS");

		GUI.Label(rect, text, style);
	}
}
