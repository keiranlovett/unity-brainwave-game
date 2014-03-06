using UnityEngine;
using System.Collections;

public class floatingObject : MonoBehaviour {

	public float frequencyMin = 0.1f;
	
	public float frequencyMax = -0.3f;
	
	public float magnitude = 0.0002f;
	
	private float randomInterval;
	
	
	
	void  Start (){
		
		randomInterval = Random.Range(frequencyMin, frequencyMax);
		
	}
	
	
	
	void  Update (){
		
		this.transform.position += new Vector3(0, randomInterval, 0);

	}

}