using UnityEngine;
using System.Collections;

public class PlatformRemover : MonoBehaviour {
    private Camera gameCamera;

	// Use this for initialization
	void Start () {
        gameCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < gameCamera.transform.position.x-30 )
            Destroy(gameObject);
	}
}
