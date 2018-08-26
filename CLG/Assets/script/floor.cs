using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class floor : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
	
	public GameObject uc;

	public void OnPointerEnter(PointerEventData eventData){
		uc.GetComponent<ui_control> ().mouse_on_floor = this.gameObject;
		uc.GetComponent<ui_control> ().floorColor (false);
	}

	public void OnPointerExit(PointerEventData eventData){
		uc.GetComponent<ui_control> ().floorColor (true);
		uc.GetComponent<ui_control> ().mouse_on_floor = null;
	}

}
