using UnityEngine;
using System.Collections;
using System;

public class UnityThinkGear
{
    /*
    Following are connection status that declared in UnityThinkGear2User.Jar
    when you getConnectStatex(),the return value will be one of following string
     *
	public static final String STATE_IDLE = "idle";
	public static final String STATE_CONNECTING = "connecting";
	public static final String STATE_CONNECTED = "connected";
	public static final String STATE_NOT_FOUND = "not found";
	public static final String STATE_NOT_PAIRED = "not paired";
	public static final String STATE_DISCONNECTED = "disconnected";
	public static final String LOW_BATTERY = "low battery";
	public static final String BLUETOOTH_ERROR = "bluetooth error";

	public String connectState1 = STATE_IDLE;
	public String connectState2 = STATE_IDLE;
	*/
    private AndroidJavaClass jc;
    private AndroidJavaObject jo;
	
	private static UnityThinkGear thinkGear = null;

	
	private UnityThinkGear()
	{
		jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
	}
	
	/**
	 * Singleton
	 **/
	public static UnityThinkGear getInstance()
	{
		if(thinkGear == null)
		{
			thinkGear = new UnityThinkGear();
		}
		return thinkGear;
	}

	/**
	 * when your app use raw data,set this for true
	 * otherwise,set to false.
	 * default is false.
	 **/
    public void setSendRawdataEnable(bool value)
    {
        jo.Set<bool>("sendRawEnable", value);
    }
	/**
	 * when your app use Alpha,Beta,Gamma,Theta,Delta,set this for true
	 * otherwise,set to false.
	 * default is false.
	 **/
	public void setSendEEGEnable(bool value = true)
    {
        jo.Set<bool>("sendEEGEnable", value);
    }
	/**
	 * when your app use Attention,Meditation,set this for true
	 * otherwise,set to false.
	 * default is true.
	 **/
	public void setSendESenseEnable(bool value)
    {
        jo.Set<bool>("sendESenseEnable", value);
    }
	/**
	 * when your app use Blink,set this for true
	 * otherwise,set to false.
	 * default is true.
	 **/
	public void setSendBlinkEnable(bool value)
    {
        jo.Set<bool>("sendBlinkEnable", value);
    }
	
	public bool getSendRawdataEnable(){
		return jo.Get<bool>("sendRawEnable");
	}
	public bool getSendEEGEnable(){
		return jo.Get<bool>("sendEEGEnable");
	}
	public bool getSendESenseEnable(){
		return jo.Get<bool>("sendESenseEnable");
	}
	public bool getSendBlinkEnable(){
		return jo.Get<bool>("sendBlinkEnable");
	}
	
	/**
	 * Try to connect Mindwave headset,if successfuly connect,raw data will send.
	 * Before connecting,recommend call getPairedDeviceNum() to check if how many headset paired.
	 * Reference:connectNoRaw1()
	 **/ 
    public void connectWithRaw1()
    {
		jo.Set<bool>("sendRawEnable", true);
        jo.Call("connectWithRaw1");
    }
	/**
	 * Try to connect Mindwave headset,if successfuly connect,raw data will not send.
	 * Before connecting,recommend call getPairedDeviceNum() to check if how many headset paired.
	 * Reference:connectWithRaw1()
	 **/
    public void connectNoRaw1()
    {
		jo.Set<bool>("sendRawEnable", false);
        jo.Call("connectNoRaw1");
    }
	/**
	 * Try to connect second Mindwave headset,if successfuly connect,raw data will send.
	 * Before connecting,recommend call getPairedDeviceNum() to check if how many headset paired.
	 * Reference:connectNoRaw2()
	 **/
	public void connectWithRaw2()
    {
		jo.Set<bool>("sendRawEnable", true);
        jo.Call("connectWithRaw2");
    }
	/**
	 * Try to connect second Mindwave headset,if successfuly connect,raw data will not send.
	 * Before connecting,recommend call getPairedDeviceNum() to check if how many headset paired.
	 * Reference:connectWithRaw2()
	 **/
	public void connectNoRaw2()
    {
		jo.Set<bool>("sendRawEnable", false);
        jo.Call("connectNoRaw2");
    }
	
	/**
	 * disconnect connected headset
	 **/ 
    public void disconnect1()
    {
        jo.Call("disconnect1");
    }
	/**
	 * disconnect second connected headset
	 **/
	public void disconnect2()
    {
        jo.Call("disconnect2");
    }
	/**
	 * check the Android device's BlueTooth status
	  *return -1:BT is null
	   return 10:BT is off status
	   return 11:BT is turning on
	   return 12:BT is on
	   return 13:BT is turning off
	 **/ 
    public int getBTState()
    {/*
      * -1:BT is null,remind user open BT function of Android device;
      * 10:STATE_OFF;
      * 11:STATE_TURNING_ON;
      * 12:STATE_ON;
      * 13:STATE_TURNING_OFF;*/

        return jo.Call<int>("checkBTState");
    }
	/**
	 *Check how many device was paired with Android device.
	 return -1:BT is null,remind user open BT function of Android device *
	 **/ 
    public int getPairedDeviceNum()
    {
        /*
         * -1:BT is null;
         * ;*/
        return jo.Call<int>("getPairedDeviceNum");
    }



	/**
	 * Check the status of first connected headset
	 * 
	 * return "idle" : BT is null or connect status has not been updated
	   return "connecting": Android device is connecting mindwave headset.
	   return "connected" : Android device can read data from mindwave headset.
	   return "not found" : paired mindwave headset is off or not in searchable area.
	   return "not paired": there are not mindwave headset paired with Android device.
	   return "disconnected":mindwave headset is off or out of searchable area of Android device.
	   return "low battery" :mindwave headset's battery dose not have power.
	   return "bluetooth error" : Android device is not support BT.
	 **/ 
    public string getConnectState1()
    {
        if (jo == null)
        {
            return "idle";
        }
        else
        {
            return jo.Get<string>("connectState1");
        }
    }
	/**
	 * Check the status of second connected headset
	 *  
	 * return "idle" : BT is null or connect status has not been updated
	   return "connecting": Android device is connecting mindwave headset.
	   return "connected" : Android device can read data from mindwave headset.
	   return "not found" : paired mindwave headset is off or not in searchable area.
	   return "not paired": there are not mindwave headset paired with Android device.
	   return "disconnected":mindwave headset is off or out of searchable area of Android device.
	   return "low battery" :mindwave headset's battery dose not have power.
	   return "bluetooth error" : Android device is not support BT.
	 **/
    public string getConnectState2()
    {
        if (jo == null)
        {
            return "idle";
        }
        else
        {
            return jo.Get<string>("connectState2");
        }
    }

}
