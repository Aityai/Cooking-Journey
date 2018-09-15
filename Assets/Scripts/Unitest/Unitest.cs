using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Contact.Messages;

public class Unitest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.MessageWait(MessagePost.error, (parm, sender) => Unit());
        this.MessagePost(MessagePost.error);
		
	}

    void Unit()
    {
        Debug.Log("that so OK");
    }
	

}
