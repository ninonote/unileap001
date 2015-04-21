using UnityEngine;
using System.Collections;

/* Todo
 * Show volume of cube by euclid distance from the center.
 * 
*/

public class SoundCubeController : MonoBehaviour {

	//protected ArrayList startPositions;
	public GameObject[] cubes;
	//protected ArrayList soundcubes;

	[SerializeField]
	public GUIContent content;

	private GUIStyle style;

	void Awake() {
		var tag = "SoundCube";
		cubes = GameObject.FindGameObjectsWithTag (tag);
	}

	// Use this for initialization
	void Start () {
		//startPositions = new ArrayList ();
		//soundcubes = new ArrayList ();
		//foreach (var cube in cubes)
		//{
		//	Debug.Log (cube.name);
			//cube.AddComponent(SoundCube);
			//soundcubes.Add (cube.GetComponent<SoundCube>());
			//var soundcube = cube.GetComponent<SoundCube>();
			//Debug.Log (soundcube.startPosition);
			//Debug.Log (cube.transform.position);
			//startPositions.Add (cube.transform.position);
		///}

		Debug.Log ("Launching GUI!");
		style = new GUIStyle();
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnGUI () {
		var rect = new Rect (10, 10, 100, 30);
		GUI.Label (rect, content, style);
		rect.y = 40;
		if (GUI.Button (rect, "RESET"))
		{
			Debug.Log ("Reset button pressed.");
			foreach(var cube in cubes) {
				var soundcube = cube.GetComponent<SoundCube>();
				Debug.Log (soundcube.startPosition);
				Debug.Log (soundcube.soundcube.name);
				//soundcube.soundcube.transform.position = soundcube.startPosition;
				iTween.MoveTo(soundcube.soundcube, iTween.Hash(
					"position", soundcube.startPosition,
					"time", 0.5, 
					"oncomplete", "complete", 
					"oncompletetarget", soundcube.soundcube, 
					"easeType", "linear"
					//"space", Space.worldでグローバル座標系で移動
				));
				iTween.RotateTo(soundcube.soundcube, iTween.Hash(
					"y", 0,
					"time", 0.5
				));
			}
		}
	}

}
