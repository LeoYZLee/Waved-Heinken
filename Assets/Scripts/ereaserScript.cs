using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ereaserScript : MonoBehaviour {
	public float moveSpeed = 0.2f;
    public GameObject scoreText;
    public GameObject totalTimesText;
    public Transform pointPos;
    private IFormatProvider format;

    // Use this for initialization
    //void Start () {

    //}

    // Update is called once per frame
    void Update () {
        /*
		if (Input.GetKey (KeyCode.I)) {
			transform.Translate (Vector3.up * moveSpeed * Time.deltaTime);

		} else if (Input.GetKey (KeyCode.M)) {
			transform.Translate (Vector3.down * moveSpeed * Time.deltaTime);

		} else if (Input.GetKey (KeyCode.J)) {
			transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		
		} else if(Input.GetKey (KeyCode.K)) {
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
		} else if(Input.GetKey (KeyCode.F)) {
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		} else if(Input.GetKey (KeyCode.B)) {
			transform.Translate (Vector3.back * moveSpeed * Time.deltaTime);
		}
        */
        transform.position = pointPos.position;
 	}

    private void FixedUpdate()
    {
        scoreText.GetComponent<TextMesh>().text =  AppStateManager.Instance.totalScore.ToString();
        totalTimesText.GetComponent<TextMesh>().text = "Total Times:" + AppStateManager.Instance.totalTime.ToString().Substring(3,8);

    }

}
