using UnityEngine;
using System.Collections;

public class TileActor : MonoBehaviour {

	private TextMesh txtMsh;

	// Use this for initialization
	void Awake () {
		Component[] textMeshes;
		textMeshes = GetComponentsInChildren<TextMesh> (true);
		if (textMeshes.Length > 0) {
			txtMsh = textMeshes [0] as TextMesh;
			txtMsh.text = "?";
		}
	}

	public void SetValue(int value) {
		if (txtMsh != null) {
			txtMsh.text = value.ToString();
		}
	}
	
}
