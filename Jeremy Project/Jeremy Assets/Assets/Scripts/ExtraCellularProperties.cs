using System.Collections;
using UnityEngine;

public class ExtraCellularProperties : MonoBehaviour
{


    #region Public Fields + Properties + Events + Delegates + Enums

	public bool allowMovement = true;
    public bool isActive = true;

	public void changeState(bool message)
	{
		this.isActive = message;
		this.allowMovement = message;
		if (this.isActive == false) {
			this.GetComponent<ReceptorPathfinding> ().enabled = false;
		} else
			this.GetComponent<ReceptorPathfinding> ().enabled = true;
	}

    #endregion Public Fields + Properties + Events + Delegates + Enums

    #region Private Methods




    private void FixedUpdate()
    {
    }

    #endregion Private Methods
}