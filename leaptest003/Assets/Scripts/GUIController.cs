using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	[SerializeField]
	public GUIContent content;

	private GUIStyle style;



	// Use this for initialization
	private void Start () {
		Debug.Log ("Launching GUI!");
		style = new GUIStyle();
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.black;
	}
	
	// Update is called once per frame
	private void OnGUI () {
		var rect = new Rect (10, 10, 400, 30);
		GUI.Label (rect, content, style);
		rect.y = 40;
		if (GUI.Button (rect, "RESET"))
		{
			content.text = "yo";
		}
	}
}
