using UnityEngine;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour {
	public float scrollSpeed = 20;
	public float scrollArea = 50;
	public float dragSpeed = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var mPosX = Input.mousePosition.x; var mPosY = Input.mousePosition.y;
		
		// Do camera movement by mouse position 
		if (mPosX < scrollArea) {
			transform.Translate(Vector3.right *(-scrollSpeed)*Time.deltaTime);
		} 
		if (mPosX >= Screen.width-scrollArea) {
			transform.Translate(Vector3.right *scrollSpeed*Time.deltaTime);
		} 
		if (mPosY < scrollArea) {
			transform.Translate(Vector3.up *(-scrollSpeed)*Time.deltaTime);
		} 
		if (mPosY >= Screen.height-scrollArea) {
			transform.Translate(Vector3.up *scrollSpeed*Time.deltaTime);
		}
		
		// Do camera movement by keyboard 
		transform.Translate(new Vector3(Input.GetAxis("Horizontal") *scrollSpeed*Time.deltaTime, Input.GetAxis("Vertical") *scrollSpeed*Time.deltaTime, 0) );
		
		// Do camera movement by holding down option or middle mouse button and then moving mouse 
		if ( (Input.GetKey("left alt") || Input.GetKey("right alt")) || Input.GetMouseButton(2) ) { 
			transform.Translate(-new Vector3(Input.GetAxis("Mouse X")*dragSpeed, Input.GetAxis("Mouse Y")*dragSpeed, 0) ); 
		}
	}
}
