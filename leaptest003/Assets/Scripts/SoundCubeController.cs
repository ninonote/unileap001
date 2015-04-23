using UnityEngine;
using System.Collections;

/* Todo
 * Show volume of cube by euclid distance from the center.
 * 
*/

public class SoundCubeController : MonoBehaviour {

	public static ArrayList scenes = new ArrayList {"mymain", "room2"};

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
		Debug.Log (Application.loadedLevelName);
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
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("space key was pressed");
			string currentScene = Application.loadedLevelName;
			//var word = scene.Where(currentScene => currentScene.IsKey).First();
			//int index = Array.FindIndex(scenes, w => w.IsKey == currentScene);
			//var index = Array.FindIndex(scenes, row => row.Author == currentScene);
			//var index = scenes.FindIndex(a => a.Prop == currentScene);
			var index = scenes.IndexOf(currentScene);
			index += 1;
			index %= scenes.Count;
			var nextScene = (string)scenes[index];
			Debug.Log (nextScene);
			//Debug.Log (index);
			Application.LoadLevel(nextScene);
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			returnCubes();
		}
	}

	private void OnGUI () {
		var rect = new Rect (10, 10, 100, 30);
		GUI.Label (rect, content, style);
		rect.y = 40;
		if (GUI.Button (rect, "RESET"))
		{
			Debug.Log ("Reset button pressed.");
			returnCubes();
			/*foreach(var cube in cubes) {
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
			}*/
		}
	}

	private void returnCubes () {
		Debug.Log ("Reset button pressed.");
		foreach (var cube in cubes) {
			var soundcube = cube.GetComponent<SoundCube> ();
			Debug.Log (soundcube.startPosition);
			Debug.Log (soundcube.soundcube.name);
			//soundcube.soundcube.transform.position = soundcube.startPosition;
			iTween.MoveTo (soundcube.soundcube, iTween.Hash (
				"position", soundcube.startPosition,
				"time", 0.5, 
				"oncomplete", "complete", 
				"oncompletetarget", soundcube.soundcube, 
				"easeType", "linear"
				//"space", Space.worldでグローバル座標系で移動
			));
			iTween.RotateTo (soundcube.soundcube, iTween.Hash (
				"y", 0,
				"time", 0.5
			));
		}
	}

}
