using UnityEngine;
using System.Collections;

public class DisplayData : MonoBehaviour
{
	public Texture2D[] signalIcons;
	
	private float indexSignalIcons = 1;
	private bool enableAnimation = false;
	private float animationInterval = 0.06f;
	
    TGDeviceController controller;

    private int poorSignal1;
    private int attention1;
    private int meditation1;
	
	private float delta;

    void Start()
    {
		
		controller = GameObject.Find("ThinkGear").GetComponent<TGDeviceController>();
		
		controller.UpdatePoorSignal1Event += OnUpdatePoorSignal;
		controller.UpdateAttention1Event += OnUpdateAttention;
		controller.UpdateMeditation1Event += OnUpdateMeditation;
		
		controller.UpdateDelta1Event += OnUpdateDelta;
		
    }
	
	void OnUpdatePoorSignal(int value){
		poorSignal1 = value;
		if(value < 25){
      		indexSignalIcons = 0;
			enableAnimation = false;
		}else if(value >= 25 && value < 175 && !enableAnimation){
			indexSignalIcons = 2;
      		enableAnimation = true;
		}else if(value >= 175){
      		indexSignalIcons = 1;
			enableAnimation = false;
		}
	}
	void OnUpdateAttention(int value){
		attention1 = value;
	}
	void OnUpdateMeditation(int value){
		meditation1 = value;
	}
	void OnUpdateDelta(float value){
		delta = value;
	}
	
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
	
	/**
	 *when Fixed Timestep == 0.02 
	 **/
	void FixedUpdate(){
		if(enableAnimation){
			if(indexSignalIcons >= 4.8){
				indexSignalIcons = 2;
			}
			indexSignalIcons += animationInterval;
		}
		
	}


    void OnGUI()
    {
		GUILayout.BeginHorizontal();
		GUILayout.Label("NOCTURNAL DEMO");
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		
		GUILayout.Space(15);
        if (GUILayout.Button("Connect1"))
        {
            controller.ConnectNoRaw1();
        }
		GUILayout.Space(15);
        if (GUILayout.Button("DisConnect1"))
        {
            controller.Disconnect1();
			indexSignalIcons = 1;
        }
		if (GUILayout.Button("Menu"))
		{
			Application.LoadLevel("menu");
		}
		
		GUILayout.Space(Screen.width-350);
		GUILayout.Label(signalIcons[(int)indexSignalIcons]);
		
		GUILayout.EndHorizontal();

		GUILayout.Space(40);
        GUILayout.Label("PoorSignal1:" + poorSignal1);
        GUILayout.Label("Attention1:" + attention1);
        GUILayout.Label("Meditation1:" + meditation1);
		GUILayout.Label("Delta:" + delta);
		

    }
}
