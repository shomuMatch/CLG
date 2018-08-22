using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class initialize : MonoBehaviour {

	// Use this for initialization
	
	public GameObject floor,floor_red,floor_blue,wall,crystalBlue,crystalRed,crystalBlack;

	
	void Start(){
		Debug.Log("START");
		set_panel(3,3,new int[,] {{1,2,1},{3,1,0},{1,0,4}});
		Debug.Log("END");
	}
	
	public void set_panel(int H,int W,int[,] field){
	
		GameObject baseObject=transform.GetChild(0).gameObject;
		
		for(int y=0;y<H;y++){
			for(int x=0;x<W;x++){
				Debug.Log(Mathf.FloorToInt(W/2.0f));
				float xc=(x-Mathf.FloorToInt(W/2.0f))*32.0f+16.0f*((W+1)%2.0f);
				float yc=-(y-Mathf.FloorToInt(H/2.0f))*32.0f+16.0f*((H+1)%2.0f);
				if(field[y,x]==0){
					GameObject floorI=Instantiate(floor,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					Debug.Log("floor");
				}else if(field[y,x]==1){
					GameObject floorI=Instantiate(wall,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					Debug.Log("Wall");
				}else if(field[y,x]==2){
					GameObject floorI=Instantiate(floor,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI=Instantiate(crystalBlue,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					Debug.Log("Blue");
				}else if(field[y,x]==3){
					GameObject floorI=Instantiate(floor,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI=Instantiate(crystalRed,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					Debug.Log("Red");
				}else if(field[y,x]==4){
					GameObject floorI=Instantiate(floor,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI=Instantiate(crystalBlack,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					Debug.Log("Black");
				}
			}
		}
	
	}
	
	
}
