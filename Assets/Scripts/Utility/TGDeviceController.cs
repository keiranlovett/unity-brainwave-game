using UnityEngine;
using System.Collections;

public class TGDeviceController : MonoBehaviour 
{
	/*
	Basically, don't touch this because this is essential to anything and everything
	There's a lot going on here, don't mess with it
	SERIOUSLY STOP IT
	*/
	public delegate void UpdateIntValueDelegate(int value);
	public delegate void UpdateFloatValueDelegate(float value);
	public delegate void UpdateStringValueDelegate(string value);
	
	public event UpdateStringValueDelegate UpdateConnectState1Event;
		
	public event UpdateIntValueDelegate UpdatePoorSignal1Event;
	public event UpdateIntValueDelegate UpdateAttention1Event;
	public event UpdateIntValueDelegate UpdateMeditation1Event;
	public event UpdateIntValueDelegate UpdateRawdata1Event;
	public event UpdateIntValueDelegate UpdateBlink1Event;
	
	public event UpdateFloatValueDelegate UpdateDelta1Event;
	public event UpdateFloatValueDelegate UpdateTheta1Event;
	public event UpdateFloatValueDelegate UpdateLowAlpha1Event;
	public event UpdateFloatValueDelegate UpdateHighAlpha1Event;
	public event UpdateFloatValueDelegate UpdateLowBeta1Event;
	public event UpdateFloatValueDelegate UpdateHighBeta1Event;
	public event UpdateFloatValueDelegate UpdateLowGamma1Event;
	public event UpdateFloatValueDelegate UpdateHighGamma1Event;
		
	public event UpdateStringValueDelegate UpdateConnectState2Event;
	
	public event UpdateIntValueDelegate UpdatePoorSignal2Event;
	public event UpdateIntValueDelegate UpdateAttention2Event;
	public event UpdateIntValueDelegate UpdateMeditation2Event;
	public event UpdateIntValueDelegate UpdateRawdata2Event;
	public event UpdateIntValueDelegate UpdateBlink2Event;
	
	public event UpdateFloatValueDelegate UpdateDelta2Event;
	public event UpdateFloatValueDelegate UpdateTheta2Event;
	public event UpdateFloatValueDelegate UpdateLowAlpha2Event;
	public event UpdateFloatValueDelegate UpdateHighAlpha2Event;
	public event UpdateFloatValueDelegate UpdateLowBeta2Event;
	public event UpdateFloatValueDelegate UpdateHighBeta2Event;
	public event UpdateFloatValueDelegate UpdateLowGamma2Event;
	public event UpdateFloatValueDelegate UpdateHighGamma2Event;
	
	private UnityThinkGear thinkGear;					//Instantiates the reading
	private bool sendRawEnable = false;
	private bool sendEEGEnable = false;
	private bool sendESenseEnable = true;
	private bool sendBlinkEnable = true;
	
	
	void Awake()
	{
		thinkGear = UnityThinkGear.getInstance();
	}

	void Start () 
	{
		sendRawEnable = thinkGear.getSendRawdataEnable();
		sendEEGEnable = thinkGear.getSendEEGEnable();
		sendESenseEnable = thinkGear.getSendESenseEnable();
		sendBlinkEnable = thinkGear.getSendBlinkEnable();
	}
	
	void Update () 
	{
		if(!sendRawEnable && (UpdateRawdata1Event != null || UpdateRawdata2Event != null)){
			sendRawEnable = true;
			thinkGear.setSendRawdataEnable(true);
		}
		if(sendRawEnable && UpdateRawdata1Event == null && UpdateRawdata2Event == null){
			sendRawEnable = false;
			thinkGear.setSendRawdataEnable(false);
		}
		
		if(!sendEEGEnable && 
		   (UpdateDelta1Event != null || UpdateDelta2Event != null ||
		   UpdateTheta1Event != null || UpdateTheta2Event != null ||
		   UpdateLowAlpha1Event != null || UpdateLowAlpha2Event != null ||
		   UpdateLowBeta1Event != null || UpdateLowBeta2Event != null ||
		   UpdateLowGamma1Event != null || UpdateLowGamma2Event != null ||
		   UpdateHighAlpha1Event != null || UpdateHighAlpha2Event != null ||
		   UpdateHighBeta1Event != null || UpdateHighBeta2Event != null ||
		   UpdateHighGamma1Event != null || UpdateHighGamma2Event != null))
		{
			sendEEGEnable = true;
			thinkGear.setSendEEGEnable(true);
		}
		
		if(sendEEGEnable && 
		   UpdateDelta1Event == null && UpdateDelta2Event == null &&
		   UpdateTheta1Event == null && UpdateTheta2Event == null &&
		   UpdateLowAlpha1Event == null && UpdateLowAlpha2Event == null &&
		   UpdateLowBeta1Event == null && UpdateLowBeta2Event == null &&
		   UpdateLowGamma1Event == null && UpdateLowGamma2Event == null &&
		   UpdateHighAlpha1Event == null && UpdateHighAlpha2Event == null &&
		   UpdateHighBeta1Event == null && UpdateHighBeta2Event == null &&
		   UpdateHighGamma1Event == null && UpdateHighGamma2Event == null)
		{
			sendEEGEnable = false;
			thinkGear.setSendEEGEnable(false);
		}
		
		if(!sendESenseEnable &&
		   (UpdateAttention1Event != null || UpdateAttention2Event != null ||
		    UpdateMeditation1Event != null || UpdateMeditation2Event != null))
		{
			sendESenseEnable = true;
			thinkGear.setSendESenseEnable(true);
		}
		
		if(sendESenseEnable &&
		   UpdateAttention1Event == null && UpdateAttention2Event == null &&
		    UpdateMeditation1Event == null && UpdateMeditation2Event == null)
		{
			sendESenseEnable = false;
			thinkGear.setSendESenseEnable(false);
		}
		
		if(!sendBlinkEnable && 
		   (UpdateBlink1Event != null || UpdateBlink2Event != null))
		{
			sendBlinkEnable = true;
			thinkGear.setSendBlinkEnable(true);
		}
		
		if(sendBlinkEnable && 
		   UpdateBlink1Event == null && UpdateBlink2Event == null)
		{
			sendBlinkEnable = false;
			thinkGear.setSendBlinkEnable(false);
		}
	}
	
	void OnApplicationQuit()
	{
		//Disconnect1();
		//Disconnect2();
	}
	
	/*
	   receive "idle" : BT is null or connect status has not been updated
	   receive "connecting": Android device is connecting mindwave headset.
	   receive "connected" : Android device can read data from mindwave headset.
	   receive "not found" : paired mindwave headset is off or not in searchable area.
	   receive "not paired": there are not mindwave headset paired with Android device.
	   receive "disconnected":mindwave headset is off or out of searchable area of Android device.
	   receive "low battery" :mindwave headset's battery dose not have power.
	   receive "bluetooth error" : Android device is not support BT.
    */
	void receiveConnectState1(string value)
	{
		if(UpdateConnectState1Event != null)
		{
			UpdateConnectState1Event(value);
		}
	}
	void receivePoorSignal1(string value)
	{
		if(UpdatePoorSignal1Event != null)
		{
			UpdatePoorSignal1Event(int.Parse(value));
		}
	}
	void receiveRaw1(string value)
	{
		if(UpdateRawdata1Event != null)
		{
			UpdateRawdata1Event(int.Parse(value));
		}
	}
	void receiveAttention1(string value)
	{
		if(UpdateAttention1Event != null)
		{
			UpdateAttention1Event(int.Parse(value));
		}
	}
	void receiveMeditation1(string value)
	{
		if(UpdateMeditation1Event != null)
		{
			UpdateMeditation1Event(int.Parse(value));
		}
	}
	void receiveBlink1(string value){
		if(UpdateBlink1Event != null){
			UpdateBlink1Event(int.Parse(value));
		}
	}
	
	void receiveDelta1(string value)
	{
		if(UpdateDelta1Event != null)
		{
			UpdateDelta1Event(float.Parse(value));
		}
	}
	void receiveTheta1(string value){
		if(UpdateTheta1Event != null){
			UpdateTheta1Event(float.Parse(value));
		}
	}
	void receiveLowGamma1(string value)
	{
		if(UpdateLowGamma1Event != null)
		{
			UpdateLowGamma1Event(float.Parse(value));
		}
	}
	void receiveLowBeta1(string value){
		if(UpdateLowBeta1Event != null){
			UpdateLowBeta1Event(float.Parse(value));
		}
	}
	void receiveLowAlpha1(string value)
	{
		if(UpdateLowAlpha1Event != null)
		{
			UpdateLowAlpha1Event(float.Parse(value));
		}
	}
	void receiveHighGamma1(string value)
	{
		if(UpdateHighGamma1Event != null)
		{
			UpdateHighGamma1Event(float.Parse(value));
		}
	}
	void receiveHighBeta1(string value)
	{
		if(UpdateHighBeta1Event != null)
		{
			UpdateHighBeta1Event(float.Parse(value));
		}
	}
	void receiveHighAlpha1(string value)
	{
		if(UpdateHighAlpha1Event != null)
		{
			UpdateHighAlpha1Event(float.Parse(value));
		}
	}
	
	/*
	   receive "idle" : BT is null or connect status has not been updated
	   receive "connecting": Android device is connecting mindwave headset.
	   receive "connected" : Android device can read data from mindwave headset.
	   receive "not found" : paired mindwave headset is off or not in searchable area.
	   receive "not paired": there are not mindwave headset paired with Android device.
	   receive "disconnected":mindwave headset is off or out of searchable area of Android device.
	   receive "low battery" :mindwave headset's battery dose not have power.
	   receive "bluetooth error" : Android device is not support BT.
    */
	void receiveConnectState2(string value)
	{
		if(UpdateConnectState2Event != null)
		{
			UpdateConnectState2Event(value);
		}
	}
	void receivePoorSignal2(string value)
	{
		if(UpdatePoorSignal2Event != null)
		{
			UpdatePoorSignal2Event(int.Parse(value));
		}
	}
	void receiveRaw2(string value)
	{
		if(UpdateRawdata2Event != null)
		{
			UpdateRawdata2Event(int.Parse(value));
		}
	}
	void receiveAttention2(string value)
	{
		if(UpdateAttention2Event != null)
		{
			UpdateAttention2Event(int.Parse(value));
		}
	}
	void receiveMeditation2(string value)
	{
		if(UpdateMeditation2Event != null)
		{
			UpdateMeditation2Event(int.Parse(value));
		}
	}
	void receiveBlink2(string value)
	{
		if(UpdateBlink2Event != null)
		{
			UpdateBlink2Event(int.Parse(value));
		}
	}
	void receiveDelta2(string value)
	{
		if(UpdateDelta2Event != null)
		{
			UpdateDelta2Event(float.Parse(value));
		}
	}
	void receiveTheta2(string value)
	{
		if(UpdateTheta2Event != null)
		{
			UpdateTheta2Event(float.Parse(value));
		}
	}
	void receiveLowGamma2(string value)
	{
		if(UpdateLowGamma2Event != null)
		{
			UpdateLowGamma2Event(float.Parse(value));
		}
	}
	void receiveLowBeta2(string value)
	{
		if(UpdateLowBeta2Event != null)
		{
			UpdateLowBeta2Event(float.Parse(value));
		}
	}
	void receiveLowAlpha2(string value)
	{
		if(UpdateLowAlpha2Event != null)
		{
			UpdateLowAlpha2Event(float.Parse(value));
		}
	}
	void receiveHighGamma2(string value)
	{
		if(UpdateHighGamma2Event != null)
		{
			UpdateHighGamma2Event(float.Parse(value));
		}
	}
	void receiveHighBeta2(string value)
	{
		if(UpdateHighBeta2Event != null)
		{
			UpdateHighBeta2Event(float.Parse(value));
		}
	}
	void receiveHighAlpha2(string value)
	{
		if(UpdateHighAlpha2Event != null)
		{
			UpdateHighAlpha2Event(float.Parse(value));
		}
	}
	
		
	public void ConnectNoRaw1()
	{
		thinkGear.connectNoRaw1();
	}
	public void ConnectNoRaw2()
	{
		thinkGear.connectNoRaw2();
	}
	public void ConnectWithRaw1()
	{
		thinkGear.connectWithRaw1();
	}
	public void ConnectWithRaw2()
	{
		thinkGear.connectWithRaw2();
	}
	
	public void Disconnect1()
	{
		thinkGear.disconnect1();
	}
	public void Disconnect2()
	{
		thinkGear.disconnect2();
	}
	
}
