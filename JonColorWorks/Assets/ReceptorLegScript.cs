using UnityEngine;
using System.Collections;

public class ReceptorLegScript : MonoBehaviour {



	private IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "ATP")
		{
			ReceptorLegProperties objProps = (ReceptorLegProperties)this.GetComponent("ReceptorLegProperties");
			objProps.isActive = false;
			other.GetComponent<ATPproperties>().changeState(false);
			other.GetComponent<ATPproperties>().dropOff();
			yield return new WaitForSeconds(3);
			Transform tail = other.transform.FindChild ("Tail");
			tail.transform.SetParent (transform);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
