using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {


    
     
    void Update()
    {
        if (transform.position.y < Camera.main.transform.position.y - WorldContext.OffScreenY)
#pragma warning disable CS0618 // Type or member is obsolete
         Application.LoadLevel(Application.loadedLevel);
#pragma warning restore CS0618 // Type or member is obsolete
    }
    
}
