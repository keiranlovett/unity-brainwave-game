using UnityEngine;
using System.Collections;

public class DisplayData : MonoBehaviour
{
	public Texture2D[] signalIcons;
	
	private float indexSignalIcons = 1;			//Displays the disconnected icon
	private bool enableAnimation = false;		//I have no idea what this does, to be honest
	private float animationInterval = 0.06f;	//How long it takes to cycle between different Elements
	
    TGDeviceController controller;				//Calling on the TGDeviceController and naming it controller. (kind of a silly name)

    private int poorSignal1;					//Variable for raw data
    private int attention1;						//Variable for keeping focus, this is key for jumping mechanism
    private int meditation1;					//Variable for keeping relaxed, this is key for bird activation mechanism
	private float delta;						//Variable for other thaaangs


    void Start()
    {
		
		//controller.ConnectNoRaw1();

		controller = GameObject.Find("ThinkGear").GetComponent<TGDeviceController>();
		
		controller.UpdatePoorSignal1Event += OnUpdatePoorSignal;
		controller.UpdateAttention1Event += OnUpdateAttention;
		controller.UpdateMeditation1Event += OnUpdateMeditation;
		
		controller.UpdateDelta1Event += OnUpdateDelta;
		
    }
	
	void OnUpdatePoorSignal(int value)
	{
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
	void OnUpdateAttention(int value)
	{
		attention1 = value;
	}
	void OnUpdateMeditation(int value)
	{
		meditation1 = value;
	}
	void OnUpdateDelta(float value)
	{
		delta = value;
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	
	/**
	 *when Fixed Timestep == 0.02 
	 **/
	void FixedUpdate()
	{
		if(enableAnimation)
		{
			if(indexSignalIcons >= 4.8)
			{
				indexSignalIcons = 2;
			}
			indexSignalIcons += animationInterval;
		}
		
	}

	//Formats GUI stuff easily
	public GUIStyle GUIStyleButton;

	//any kind of texture to use in OnGUI()
	public Texture2D intTexture;

	//Them buttons
    void OnGUI()
    {

        GUILayout.Label("Deviced Connected: " + poorSignal1);
        GUILayout.Label("Lets keep focused: " + attention1);
        GUILayout.Label("Relax grasshopper: " + meditation1);
		GUILayout.Label("Bye Bye Head face: " + delta);

		GUILayout.BeginHorizontal();				//This is the beginning of something beautiful 

		GUILayout.Space(Screen.width-250);
       	if (GUILayout.Button("Connect1", GUILayout.Width(120), GUILayout.Height(120)))
        {
            controller.ConnectNoRaw1();				
        }

		GUILayout.Space(5);
        if (GUILayout.Button("DisConnect1", GUILayout.Width(120), GUILayout.Height(120)))
        {
            controller.Disconnect1();
			indexSignalIcons = 1;
        }
				
		GUILayout.EndHorizontal();					//This is the end of something
				

		
    }
}