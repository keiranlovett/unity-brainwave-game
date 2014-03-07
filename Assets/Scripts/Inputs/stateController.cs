using UnityEngine;
using System.Collections;

public class stateController : MonoBehaviour {


	
	TGDeviceController controller; 						//Lets call on the ThinkGear Controller class
	
	private int poorSignal1;
	private int attention1;
	private int meditation1;
	private float delta1;

	public bool toggle;

	// Use this for initialization
	void Start () {

		controller = GameObject.Find("ThinkGear").GetComponent<TGDeviceController>();
		
		controller.UpdateAttention1Event += OnUpdateAttention;
		controller.UpdateMeditation1Event += OnUpdateMeditation;
		controller.UpdateDelta1Event += OnUpdateDelta;

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


		if (Input.GetKeyDown("space")) {
			toggle = !toggle;
		}

		//Now for some ThinkGear SPICE
		if((attention1 >= 65 && attention1 < 275) && toggle)
		{	
			nightMode();
		} else {
			if (toggle) {
				print("Toggled ON");
				nightMode();
			}
			else {
				print("Toggled OFF");
				dayMode();
			}
		}


	}

	

	
	//Them buttons
	void OnGui()
	{
		GUILayout.Label("Deviced Connected" + poorSignal1);
		GUILayout.Label("Lets keep focused" + attention1);
		GUILayout.Label("Relax grasshopper" + meditation1);
		//GUILayout.Label("Deviced Connected" + delta1);
		
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
