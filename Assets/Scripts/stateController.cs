using UnityEngine;
using System.Collections;

public class stateController : MonoBehaviour {

	public Texture2D[] signalIcons;
	
	private float indexSignalIcons = 1;					//These three variables are for setting the animation for signalIcons
	private bool enableAnimation = false;				//This is actually very useful for letting the player know that the device is connected
	private float animationInterval = 0.0f;
	
	TGDeviceController controller; 						//Lets call on the ThinkGear Controller class
	
	private int poorSignal1;
	private int attention1;
	private int meditation1;
	private float delta1;

	public bool state;

	// Use this for initialization
	void Start () {
		state = false;

		controller = GameObject.Find("ThinkGear").GetComponent<TGDeviceController>();
		
		controller.UpdatePoorSignal1Event += OnUpdatePoorSignal;
		controller.UpdateAttention1Event += OnUpdateAttention;
		controller.UpdateMeditation1Event += OnUpdateMeditation;
		controller.UpdateDelta1Event += OnUpdateDelta;

	}

	void OnUpdatePoorSignal(int pSig1)					//Might actually want to instantiate a new name for value.
	{
		poorSignal1 = pSig1;
		
		if(pSig1 < 25)
		{
			indexSignalIcons = 0;
			enableAnimation = false;
		}
		else if(pSig1 >= 25 && pSig1 < 275 && !enableAnimation)
		{
			indexSignalIcons = 2;
			enableAnimation = true;
		}
		else if(pSig1 >= 175)
		{
			indexSignalIcons = 1;
			enableAnimation = false;
		}
	}
	void OnUpdateAttention(int a1)
	{
		attention1 = a1;
	}
	void OnUpdateMeditation(int m1)
	{
		meditation1 = m1;
	}
	void OnUpdateDelta(float d1)
	{
		delta1 = d1;
	}

	// Update is called once per frame
	void Update () {

		//If Night MODE
		if(state == true) {
			dayMode();
		} else {
			nightMode();
		}

		//Now for some ThinkGear jumping
		if(attention1 >= 65 && attention1 < 275)
		{	
			dayMode();
		} else {
			nightMode();
		}

		//If Night MODE
		if(state == true) {
			dayMode();
		} else {
			nightMode();
		}

	}

	
	void FixedUpdate()
	{
		if (enableAnimation)
		{
			if (indexSignalIcons >= 4.8)
			{
				indexSignalIcons = 2;
			}
			indexSignalIcons += animationInterval;
		}
	}
	
	//Them buttons
	void OnGui()
	{
		GUILayout.Label("Deviced Connected" + poorSignal1);
		GUILayout.Label("Lets keep focused" + attention1);
		GUILayout.Label("Relax grasshopper" + meditation1);
		GUILayout.Label("Deviced Connected" + delta1);
		
	}


	void dayMode() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag( "Day" );
		foreach( GameObject go in objects )
		{
			go.renderer.enabled = true;
			go.collider.enabled=true;
		}
		GameObject[] objects2 = GameObject.FindGameObjectsWithTag( "Night" );
		foreach( GameObject go in objects2 )
		{
			go.renderer.enabled = false;
			go.collider.enabled=false;
		}
	}

	void nightMode() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag( "Day" );
		foreach( GameObject go in objects )
		{
			go.renderer.enabled = false;
			go.collider.enabled=false;
		}
		GameObject[] objects2 = GameObject.FindGameObjectsWithTag( "Night" );
		foreach( GameObject go in objects2 )
		{
			go.renderer.enabled = true;
			go.collider.enabled=true;
		}
	}

}
