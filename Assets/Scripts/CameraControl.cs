using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Camera control
        if (Input.GetKeyDown(KeyCode.S)) { cam.transform.position += Vector3.up; }
        if (Input.GetKeyDown(KeyCode.W)) { cam.transform.position += Vector3.down; }
        if (Input.GetKeyDown(KeyCode.D)) { cam.transform.position += Vector3.left; }
        if (Input.GetKeyDown(KeyCode.A)) { cam.transform.position += Vector3.right; }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f) {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 2f;
        }
        #endregion

    }
}
