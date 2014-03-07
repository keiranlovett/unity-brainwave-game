
------------------------------------------------------------------------------------
UnityTGC Version 1.0.0
Author:Chris
Date:2013.3.22

Change Log:
1)Initialize project.

------------------------------------------------------------------------------------
Instructions

Run the Demo:
1.Drag the ThinkGear prefab from Project view to Hierarchy view
2.Drag the DisplayDataDemo prefab from Project view to Hierarchy view
3.Build project to an apk file.
4.Install apk to Android device.
5.Click "Connect1" to try to connect headset

Run your own project:
1.Drag the ThinkGear prefab from Project view to Hierarchy view	
2.At the place you want to use Attention,Meditation,EEG and so on,add following code

   void Start()
    {
		
		controller = GameObject.Find("ThinkGear").GetComponent<TGDeviceController>();
		
		controller.UpdatePoorSignal1Event += OnUpdatePoorSignal;
		controller.UpdateAttention1Event += OnUpdateAttention;
		controller.UpdateMeditation1Event += OnUpdateMeditation;
		
		controller.UpdateDelta1Event += OnUpdateDelta;
		
    }
    
3.Implement every function above
4.Call Connect() function of TGCConnectionController to connect
5.Call disconnect() function of TGCConnectionController to disconnect

Note:Before building,you must fill Bundle Identifier in Other Settings with "com.yourcompany.yourappname",
and must modify Plugins/Android/AndroidManifest.xml,like package="com.yourcompany.yourappname".

Any question/issues,contact cwang@neurosky.com