using UnityEngine;

public class ReceptorPathfinding : MonoBehaviour
{
    #region Public Fields + Properties + Events + Delegates + Enums

    public Transform SightEnd;
    public Transform sightStart;
	public bool displayPath = true;
    public bool spotted = false;
	public int speed = 100;

    #endregion Public Fields + Properties + Events + Delegates + Enums

	#region Private Members
	private GameObject [] myFoundObjs;
	private GameObject myTarget;
	#endregion Private Member



    #region Private Methods

    private void Raycasting()
    {
		//while (true) {
		int x = 0;
		myFoundObjs = GameObject.FindGameObjectsWithTag("ExternalReceptor");
		while (x < myFoundObjs.Length && myFoundObjs[x].GetComponent<ExtraCellularProperties>().isActive == false) {
			x++;
		}
			//foreach (GameObject myFoundObjs in GameObject.FindGameObjectsWithTag("ExternalReceptor")) {
		if (myFoundObjs[x].GetComponent<ExtraCellularProperties> ().isActive == true) {
			//Debug.Log("We found a receptor!");
			sightStart = myFoundObjs[x].transform;
			transform.position += transform.up * Time.deltaTime * speed;
			if(displayPath == true){
				Debug.DrawLine (sightStart.position, SightEnd.position, Color.green);
			}
			spotted = Physics2D.Linecast (sightStart.position, SightEnd.position);
			
			Quaternion rotation = Quaternion.LookRotation (SightEnd.position - sightStart.position, sightStart.TransformDirection (Vector3.up));
			transform.rotation = new Quaternion (0, 0, rotation.z, rotation.w);
		}
			
		
    }

    // Use this for initialization 
    void Start()
    {

    }

    // Update is called once per frame 
    private void Update()
    {
		Raycasting();
	}

#endregion Private Methods
}