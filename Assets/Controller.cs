using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject cube0, cube1;
    public GameObject sphereRoot;
    private float speed = 2;
    private float dis;
    private bool isMoved=true;
    private bool lastSphere = false;
    private void Start()
    {
        sphereRoot.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { cube0.transform.Translate(speed*Time.deltaTime,0,0); isMoved = true; }
        if (Input.GetKey(KeyCode.S)) { cube0.transform.Translate(speed * -Time.deltaTime,0,0); isMoved = true; }
        if (Input.GetKey(KeyCode.A)) { cube0.transform.Translate(0,0, speed * Time.deltaTime); isMoved = true; }
        if (Input.GetKey(KeyCode.D)) { cube0.transform.Translate(0,0, speed * -Time.deltaTime); isMoved = true; }

        if (Input.GetKey(KeyCode.UpArrow)) { cube1.transform.Translate(speed * Time.deltaTime,0,0); isMoved = true; }
        if (Input.GetKey(KeyCode.DownArrow)) { cube1.transform.Translate(speed * -Time.deltaTime,0,0); isMoved = true; }
        if (Input.GetKey(KeyCode.LeftArrow)) { cube1.transform.Translate(0,0, speed * Time.deltaTime); isMoved = true; }
        if (Input.GetKey(KeyCode.RightArrow)) { cube1.transform.Translate(0,0, speed * -Time.deltaTime); isMoved = true; }

        if (isMoved)
        {
            isMoved = false;
            cube0.transform.GetChild(0).transform.LookAt(cube1.transform);
            cube1.transform.GetChild(0).transform.LookAt(cube0.transform);
            dis = Vector2.Distance(new Vector2(cube0.transform.position.x, cube0.transform.position.z), new Vector2(cube1.transform.position.x, cube1.transform.position.z));
            if (lastSphere != dis < 2) { lastSphere = dis < 2; sphereRoot.SetActive(lastSphere); }
            if (dis < 1) { Application.LoadLevel(1); }
        }
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width - 200, Screen.height - 20, 200, 20), dis.ToString());
    }
}
