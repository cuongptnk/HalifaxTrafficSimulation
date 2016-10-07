using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private bool PopUp = false;
	public string Info = "The incoming direction to road ";
	//public TheLink[] inputLinkToIntersection = { new TheLink(), new TheLink(), new TheLink()};


	public string nameLink1 = null, nameLink2 = null, nameLink3 = null;
	public OffMeshLink startLink1 = null;
	public OffMeshLink startLink2 = null;
	public OffMeshLink startLink3 = null;

	public GameObject inputToRoad1 = null, inputToRoad2 = null, inputToRoad3 = null;

	private bool isBlock1 = false;
	private bool isBlock2 = false;
	private bool isBlock3 = false;

	private bool updateOldColor = false;
	public Color oldRoadColor;

	// Use this for initialization
	void Start () {
		oldRoadColor = inputToRoad2.GetComponent<Renderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (!startLink1.activated) {
			inputToRoad1.GetComponent<Renderer> ().material.color = Color.gray;	
		} else {
			inputToRoad1.GetComponent<Renderer> ().material.color = oldRoadColor;
		}

		if (!startLink2.activated) {
			inputToRoad2.GetComponent<Renderer> ().material.color = Color.gray;	
		} else {
			inputToRoad2.GetComponent<Renderer> ().material.color = oldRoadColor;
		}

		if (startLink3 != null) {
			if (!startLink3.activated) {
				inputToRoad3.GetComponent<Renderer> ().material.color = Color.gray;	
			} else {
				inputToRoad3.GetComponent<Renderer> ().material.color = oldRoadColor;
			}
		}
	
	}



	void OnMouseDown()
	{
		PopUp = true;
	}

	void DrawInfo()
	{
		int start = 60;
		int width = 600;
		int height = 100;
		Rect rect = new Rect (20,start, width, height);
		Rect close = new Rect (width,start,20,20);
		Rect label1 = new Rect (20,start+height,width,height);
		Rect link1 = new Rect (20,start+height*2,width,height);
		Rect label2 = new Rect (20,start+height*3,width,height);
		Rect link2 = new Rect (20,start+height*4,width,height);
		Rect label3 = new Rect (20,start+height*5,width,height);
		Rect link3 = new Rect (20,start+height*6,width,height);
		GUIStyle myStyle = new GUIStyle (GUI.skin.button);
		myStyle.fontSize = 40;

		if (PopUp)
		{
			if (!updateOldColor) {
				
				updateOldColor = true;
			}
			GUI.Box(rect, Info,myStyle);
			GUI.Box(label1, nameLink1,myStyle);


			//if (!isBlock1) {
			//	if (GUI.Button (link1, "Block",myStyle)) {
			//		inputToRoad1.GetComponent<Renderer> ().material.color = Color.gray;
			//		startLink1.activated = false;
			//		isBlock1 = true;
			//	}
			//} else {
			//	if (GUI.Button (link1, "Unblock",myStyle)) {
			//		inputToRoad1.GetComponent<Renderer> ().material.color = oldRoadColor;
			//		startLink1.activated = true;
			//		isBlock1 = false;
			//	}
			//}

			if (startLink1.activated) {
				if (GUI.Button (link1, "Block", myStyle)) {
					inputToRoad1.GetComponent<Renderer> ().material.color = Color.gray;
					startLink1.activated = false;
				}
			} else {
				if (GUI.Button (link1, "Unblock",myStyle)) {
					inputToRoad1.GetComponent<Renderer> ().material.color = oldRoadColor;
					startLink1.activated = true;
				}

			}

			GUI.Box(label2, nameLink2,myStyle);

			if (startLink2.activated) {
				if (GUI.Button (link2, "Block", myStyle)) {
					inputToRoad2.GetComponent<Renderer> ().material.color = Color.gray;
					startLink2.activated = false;
				}
			} else {
				if (GUI.Button (link2, "Unblock",myStyle)) {
					inputToRoad2.GetComponent<Renderer> ().material.color = oldRoadColor;
					startLink2.activated = true;
				}

			}



			//some intersection does not have the 3rd link
			if (startLink3 != null && nameLink3 != null && inputToRoad3 != null) {
				GUI.Box(label3, nameLink3,myStyle);
				if (startLink3.activated) {
					if (GUI.Button (link3, "Block", myStyle)) {
						inputToRoad3.GetComponent<Renderer> ().material.color = Color.gray;
						startLink3.activated = false;
					}
				} else {
					if (GUI.Button (link3, "Unblock",myStyle)) {
						inputToRoad3.GetComponent<Renderer> ().material.color = oldRoadColor;
						startLink3.activated = true;
					}

				}

			}




			if (GUI.Button(close,"X"))
			{
				PopUp = false;
			}
		}
	}

	void OnGUI()
	{
		DrawInfo();
	}
}
