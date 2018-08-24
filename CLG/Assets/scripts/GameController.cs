using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public ui_control uc;
	// Use this for initialization
	void Start () {
		uc=GameObject.Find("mainField").GetComponent<ui_control>();	//mainFieldのui_controlを読み込む
		int H=UnityEngine.Random.Range(10,15);	//フィールドの縦を決める[10,15]
		int W=UnityEngine.Random.Range(10,15);	//フィールドの横を決める[10,15]
		Debug.Log("(H,W)=("+H+","+W+")");	//デバッグログ
		int[,] field=new int[H,W];	//盤面を宣言
		uc.set_panel(H,W,field,0,0,0);	//set_panelを呼び出して盤面を初期化
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
