using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour {

	string currentLevel_rough;
	int currentLevel;

	// Use this for initialization
	void Start () {
		//Figure out the current scenes name, then we'll strip the crap and get the level number.
		currentLevel_rough = Application.loadedLevelName;
		currentLevel_rough = Regex.Replace(currentLevel_rough, "[^0-9]", "");
		currentLevel = int.Parse(currentLevel_rough);
		UnityEngine.Debug.Log(currentLevel);
		//nextLevel = currentLevel++;


	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("CoinTrigger").GetComponent<Collectable>().levelComplete) { //will check if true
			Application.LoadLevel("level_" + (currentLevel + 1));
		}
	}
}
