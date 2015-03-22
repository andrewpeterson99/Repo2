using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {
	
	public float distance;
	public float powerPush;
	Vector3 platPosition;
	public GameObject cup;
	private Vector3 cupPosition;
	public int amt;
	private bool temp = true;
	public float powerPull;
	
	// Use this for initialization
	void Start () {
		platPosition = new Vector3 (0, 30, 0);
		cupPosition = new Vector3 (0, 15, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//If left mouse button is clicked
		//create a raycast that originates from the mouse clicked position
		//Button vals = 0 left click, 1 right click, 2 for mid click
		if(Input.GetMouseButton(0)){
			//This allows us to draw the ray
			Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
			//if ray hits something, data gets stored in hitInfo variable
			RaycastHit hitInfo;  
			if(Physics.Raycast(rayOrigin, out hitInfo, distance)){
				Debug.Log("You are casting a ray.");
				Debug.DrawLine(rayOrigin.direction, hitInfo.point);
				//if hitinfo.rigidbody is equal to something other than null
				if(hitInfo.rigidbody != null){
					//then add force at impact position of ray
					hitInfo.rigidbody.AddForceAtPosition(rayOrigin.direction * powerPush, hitInfo.point);
					//This changes color
					//hitInfo.transform.GetComponent<Renderer>().material.color = Color.green;
					//Instantiate(plat, platPosition, Quaternion.identity);
					
				}
			}
		}
		if(Input.GetMouseButton(1)){
			//This allows us to draw the ray
			Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
			//if ray hits something, data gets stored in hitInfo variable
			RaycastHit hitInfo;  
			if(Physics.Raycast(rayOrigin, out hitInfo, distance)){
				Debug.Log("You are casting a ray.");
				Debug.DrawLine(rayOrigin.direction, hitInfo.point);
				//if hitinfo.rigidbody is equal to something other than null
				if(hitInfo.rigidbody != null){
					//then add force at impact position of ray
					hitInfo.rigidbody.AddForceAtPosition(rayOrigin.direction * powerPull, hitInfo.point);
					//This changes color
					//hitInfo.transform.GetComponent<Renderer>().material.color = Color.green;
					//Instantiate(plat, platPosition, Quaternion.identity);
					
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(Application.loadedLevelName);
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			amt += 1;
			Instantiate(cup, cupPosition, Quaternion.identity);
		}
		if (amt >= 15) {
			GameObject.Destroy(cup);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
			Application.Quit ();
		} else {
			Cursor.lockState = CursorLockMode.Locked;
		}
		
		
	}
}
