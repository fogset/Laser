using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour {
    public float speed = 15.0f;
	
	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
