using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeScript : MonoBehaviour {
	public GameObject textObj;
	//private Animation ani;

	void Start(){
		textObj.SetActive (false);
		//ani = transform.GetComponent<Animator>().gameObject;
	}

    void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
              if (AppStateManager.Instance.touchCubeCount == 0)
            {
                AppStateManager.Instance.StartGame();
            }
            transform.GetComponent<BoxCollider>().enabled = false;
            AppStateManager.Instance.touchCubeCount = AppStateManager.Instance.touchCubeCount + 1;
            textObj.SetActive (true);
            AppStateManager.Instance.totalScore = AppStateManager.Instance.touchCubeCount * 10;
            //print("score ="+ AppStateManager.Instance.totalScore);
			//ani.Play ("CubeAnimation");
			Destroy(gameObject,0.5f);
		}
	}
}
