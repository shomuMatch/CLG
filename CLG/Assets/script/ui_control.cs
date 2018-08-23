using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ui_control : MonoBehaviour {

	// Use this for initialization
	
	public GameObject floor,floor_red,floor_blue,wall,crystalBlue,crystalRed,crystalBlack;

	
	void Start(){
		Debug.Log("START");
		set_panel(3,3,new int[,] {{1,2,1},{3,1,0},{1,0,4}});
		Debug.Log("END");
	}
	
	public void set_panel(int H,int W,int[,] field){
	
		GameObject baseObject = transform.Find ("baseObject").gameObject;
		GameObject crystals = transform.Find ("crystals").gameObject;

		float sca = 14.0f / (float)Mathf.Max (H, W);
		this.transform.localScale = new Vector3 (sca, sca, sca);
		for(int y=0;y<H;y++){
			for(int x=0;x<W;x++){
				float xc=(x-Mathf.FloorToInt(W/2.0f))*32.0f+16.0f*((W+1)%2.0f);
				float yc=-(y-Mathf.FloorToInt(H/2.0f))*32.0f+16.0f*((H+1)%2.0f);
				if(field[y,x]==0){			//FLOOR
					GameObject floorI=Instantiate(floor,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI.transform.name = y.ToString ("00")+x.ToString("00")+"Floor";
				}else if(field[y,x]==1){	//WALL
					GameObject floorI=Instantiate(wall,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI.transform.name = y.ToString ("00")+x.ToString("00")+"Wall";
				}else if(field[y,x]==2){	//BLUE CRYSTAL
					GameObject floorI=Instantiate(floor,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI.transform.name = y.ToString ("00")+x.ToString("00")+"Floor";
					floorI=Instantiate(crystalBlue,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(crystals.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI.transform.name = y.ToString ("00")+x.ToString("00")+"BlueCrystal";
				}else if(field[y,x]==3){	//RED CRYSTAL
					GameObject floorI=Instantiate(floor,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI.transform.name = y.ToString ("00")+x.ToString("00")+"Floor";
					floorI=Instantiate(crystalRed,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(crystals.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI.transform.name = y.ToString ("00")+x.ToString("00")+"RedCrystal";
				}else if(field[y,x]==4){	//BLACK CRYSTAL
					GameObject floorI=Instantiate(floor,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI.transform.name = y.ToString ("00")+x.ToString("00")+"Floor";
					floorI=Instantiate(crystalBlack,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(crystals.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI.transform.name = y.ToString ("00")+x.ToString("00")+"BlackCrystal";
				}
			}
		}
	
	}
	
	
}
