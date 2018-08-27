using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class items : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

	public int type,id;
	public GameObject uc,pref;

	public void OnPointerEnter(PointerEventData eventData){
		uc.GetComponent<ui_control> ().mouse_on_obj = pref;
		uc.GetComponent<ui_control> ().mouse_on_type = type;
	}

	public void OnPointerExit(PointerEventData eventData){
		uc.GetComponent<ui_control> ().mouse_on_obj = null;
		uc.GetComponent<ui_control> ().mouse_on_type = 0;
	}
}
