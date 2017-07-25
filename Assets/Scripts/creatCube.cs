using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatCube : MonoBehaviour {
	public GameObject unitCube;
	public float cubeGap = 0.01f;
	public int Wall_x_Number = 5;
	public int Wall_y_Number = 4;
	public int Wall_z_Number = 3;

    public Material[] myMaterials = new Material[3];
    private Material[] mats;

    //[SerializeField]
    //private GameObject eraser;
    private GameObject cubeParent;
	private float cubeHWidth;
    private bool isFristRun;
	// Use this for initialization
	void Start () {
        isFristRun = true;
        cubeParent = GameObject.Find ("CubeGroup").gameObject;
		if (cubeParent == null) {
			print("Wall GameObject 不存在！");
		}

		cubeHWidth = unitCube.GetComponent<BoxCollider>().bounds.size.x;
		initWall ();

	}

    public void ReStart()
    {
        AppStateManager.Instance.EndGame();
        isFristRun = false;
        unitCube.SetActive(true);
        unitCube.transform.Find("Text").gameObject.SetActive(false);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("IceCube");
        foreach (GameObject cube in objs)
        {
            GameObject.Destroy(cube);
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.transform.Find("Text").gameObject.GetComponent<TextMesh>().text = "0";
        AppStateManager.Instance.totalScore = 0;
 
        initWall();
    }

    void initWall(){
		for (int z = 0; z < Wall_z_Number; z++) {
            //mats = unitCube.GetComponent<MeshRenderer>().materials;
            //mats[0] = myMaterials[z];
            
           
            for (float y = 0; y < Wall_y_Number; y++) {
				for (float x = 0; x < Wall_x_Number; x++) {
					creatCubeWall (x, y , z);
				}	
			}
		}

        if (isFristRun) {
            GameObject gb = GameObject.Find("Wall").gameObject;
            gb.transform.position = Camera.main.transform.forward * 3.1f;
            gb.transform.position += new Vector3(-0.5f, 0, 0);
        }
        else
        {
            cubeParent.transform.position += new Vector3(-0.5f, 0, 0);
        }
        
        //eraser.transform.position = Camera.main.transform.forward;
        //GameObject.Destroy(unitCube);j
        unitCube.SetActive(false);
        AppStateManager.Instance.maxCubeCount = Wall_x_Number * Wall_y_Number * Wall_z_Number;
    }

	void creatCubeWall(float xNum , float yNum , int zNum){
        GameObject newCube = Instantiate(unitCube , new Vector3((cubeHWidth + cubeGap) * xNum + unitCube.transform.position.x ,(cubeHWidth + cubeGap) * yNum + unitCube.transform.position.y, zNum * -0.30f + unitCube.transform.position.z), Quaternion.identity , cubeParent.transform);
        newCube.GetComponent<MeshRenderer>().material = myMaterials[zNum];
    }

}
