using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_control : MonoBehaviour {

	// Use this for initialization
	
	public GameObject 	floor,floor_red,floor_blue,wall,crystalBlue,crystalRed,crystalBlack,
						light_B_num,light_R_num,wall_B_num,wall_R_num,mirror_B_num,mirror_R_num,
						mouse_on_obj,mouse_on_floor;
	public int holding_id,holding_type;

	public float screenX,screenY,canvasX,canvasY,ratio;


	void Start(){

		ratio = 960f / Screen.width;
	}





	public void set_panel(int H,int W,int[,] field,int initial_light,int initial_wall,int initial_mirror){
	



		light_B_num.GetComponent<Text> ().text = initial_light.ToString ();
		light_R_num.GetComponent<Text> ().text = initial_light.ToString ();
		wall_B_num.GetComponent<Text> ().text = initial_wall.ToString ();
		wall_R_num.GetComponent<Text> ().text = initial_wall.ToString ();
		mirror_B_num.GetComponent<Text> ().text = initial_mirror.ToString ();
		mirror_R_num.GetComponent<Text> ().text = initial_mirror.ToString ();


		GameObject baseObject = transform.Find ("baseObject").gameObject;
		GameObject crystals = transform.Find ("crystals").gameObject;

		float sca = 14.0f / (float)Mathf.Max (H, W);
		this.transform.localScale = new Vector3 (sca, sca, sca);
		for(int y=0;y<H;y++){
			for(int x=0;x<W;x++){
				float xc=(x-Mathf.FloorToInt(W/2.0f))*32.0f+16.0f*((W+1)%2.0f);
				float yc=-(y-Mathf.FloorToInt(H/2.0f))*32.0f-16.0f*((H+1)%2.0f);
				if(field[y,x]==0){			//FLOOR
					GameObject floorI=Instantiate(floor,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(baseObject.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI.transform.name = y.ToString ("00")+x.ToString("00")+"Floor";
					floorI.GetComponent<floor> ().uc = this.gameObject;
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
					floorI.GetComponent<floor> ().uc = this.gameObject;
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
					floorI.GetComponent<floor> ().uc = this.gameObject;
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
					floorI.GetComponent<floor> ().uc = this.gameObject;
					floorI=Instantiate(crystalBlack,Vector3.zero,Quaternion.identity);
					floorI.transform.SetParent(crystals.transform);
					floorI.transform.localPosition = new Vector3(xc,yc,0.0f);
					floorI.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
					floorI.transform.name = y.ToString ("00")+x.ToString("00")+"BlackCrystal";
				}
			}
		}
	

		StartCoroutine (pickItems (1));
	}
	

	public IEnumerator pickItems(int player){
		GameObject obj=null;
		while (true) {
			while (!Input.GetMouseButtonDown (0)) {
				yield return null;
			}
			if (mouse_on_obj != null) {
				obj = Instantiate (mouse_on_obj, Vector2.zero, Quaternion.identity);
				obj.transform.SetParent (transform.root.transform);
				obj.transform.localPosition = new Vector2 (Camera.main.ScreenToViewportPoint (Input.mousePosition).x * 960f - 480f,
					Camera.main.ScreenToViewportPoint (Input.mousePosition).y * 540f - 270f);
				obj.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.4f);
				yield return null;
				break;
			} else {
				yield return null;
			}
		}
		while (true) {
			int state = 0;
			while (true) {
				if (Input.GetMouseButtonDown (0)) {
					state = 1;
					yield return null;
					break;
				} else if (Input.GetMouseButtonDown (2)) {
					state = 2;
					yield return null;
					break;
				} else {
					state = 0;
					obj.transform.localPosition = new Vector2 (Camera.main.ScreenToViewportPoint (Input.mousePosition).x * 960f - 480f,
						Camera.main.ScreenToViewportPoint (Input.mousePosition).y * 540f - 270f);
					yield return null;
				}
			}
		}

		yield return new WaitForSeconds (2);
	}

	public void floorColor(bool clear){

		if (!clear) {
			mouse_on_floor.GetComponent<Image> ().color = new Color (0.3f, 1.0f, 0.3f);
		} else {
			mouse_on_floor.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f);
		}

	}



}
