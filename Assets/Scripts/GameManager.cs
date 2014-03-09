using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour {

	string currentLevel_rough;
	int currentLevel;


	//State assets
	public Material skyboxDay;
	public Material skyboxNight;
	public GameObject lightDay;
	public GameObject lightNight;

	TGDeviceController controller; 	//Lets call on the ThinkGear Controller class
	
	private int poorSignal1;
	public int attention1;
	private int meditation1;
	private float delta1;
	
	public bool toggle;
	public float rangeCur;
	public float rangeMin = 65; //65
	public float rangeMax = 275; //275
	public float rangeAvg;

	public focusType type;

	public enum focusType {
		ATTENTION,
		MEDITATION,
		DELTA
	}

	// Use this for initialization
	void Start () {

		controller = GameObject.Find("ThinkGear").GetComponent<TGDeviceController>();
		
		controller.UpdateAttention1Event += OnUpdateAttention;
		controller.UpdateMeditation1Event += OnUpdateMeditation;
		controller.UpdateDelta1Event += OnUpdateDelta;

		//Figure out the current scenes name, then we'll strip the crap and get the level number.
		currentLevel_rough = Application.loadedLevelName;
		currentLevel_rough = Regex.Replace(currentLevel_rough, "[^0-9]", "");
		currentLevel = int.Parse(currentLevel_rough);
		UnityEngine.Debug.Log(currentLevel);

	}
	
	// Update is called once per frame
	void Update () {

		//SWAP LEVEL
		if (GameObject.Find("CoinTrigger").GetComponent<Collectable>().levelComplete) { //will check if true
			Application.LoadLevel("level_" + (currentLevel + 1));
		}

		//Set the current range to the desired focus attribute.
		switch (type) {
			case focusType.ATTENTION:
				rangeCur = attention1;
				break;
			case focusType.MEDITATION:
				rangeCur = meditation1;
				break;
			case focusType.DELTA:
				rangeCur = delta1;
				break;
		}

		//Set the focus range the user needs to achieve, used for focus bar.
		rangeAvg = (rangeMin + rangeMax)/2;
		
		// Clamp ratio between 0.0 and 1.0
		//if (rangeCur < 0.0f) rangeCur = 0.0f;
		//if (rangeCur > (rangeMax+100)) rangeCur = (rangeMax+100);


		//Focus Bar
		GameObject.Find("Bar").renderer.material.SetFloat("_Current", (rangeCur/(rangeMax+100)));
		GameObject.Find("Plane").transform.localPosition = new Vector3(0, (rangeAvg/500), 0);

		//STATEs
		if((rangeCur >= rangeMin && rangeCur < rangeMax)) {	
			nightMode();
		} else {
			if (toggle) {
				nightMode();
			}
			else {
				dayMode();
			}
		}

		//DEBUG
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			toggle = !toggle;
		}

	}

	void OnUpdateAttention(int a1) {
		attention1 = a1;
	}
	void OnUpdateMeditation(int m1) {
		meditation1 = m1;
	}
	void OnUpdateDelta(float d1) {
		delta1 = d1;
	}

	void dayMode() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag( "Day" );
		foreach( GameObject go in objects ) {
			if(go.renderer)
				go.renderer.enabled = true;
			if(go.collider)
				go.collider.enabled=true;
		}
		GameObject[] objects2 = GameObject.FindGameObjectsWithTag( "Night" );
		foreach( GameObject go in objects2 ) {
			if(go.renderer)
				go.renderer.enabled = false;
			if(go.collider)
				go.collider.enabled=false;
		}

		RenderSettings.skybox = skyboxDay;
		lightDay.light.enabled = true;
		lightNight.light.enabled = false;

	}
	
	void nightMode() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag( "Day" );
		foreach( GameObject go in objects ){
			if(go.renderer)
				go.renderer.enabled = false;
			if(go.collider)
				go.collider.enabled=false;
		}
		GameObject[] objects2 = GameObject.FindGameObjectsWithTag( "Night" );
		foreach( GameObject go in objects2 ) {
			if(go.renderer)
				go.renderer.enabled = true;
			if(go.collider)
				go.collider.enabled=true;
		}
		
		RenderSettings.skybox = skyboxNight;
		lightDay.light.enabled = false;
		lightNight.light.enabled = true;
	}

}
