using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    float moveSpd;

    Transform tr;

    Vector3 initMousePos;
    

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initMousePos = Input.mousePosition;
            initMousePos.y = 10;
            initMousePos = cam.ScreenToWorldPoint(initMousePos);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 movedPoint = Input.mousePosition;
            movedPoint.y = 10;
            movedPoint = cam.ScreenToWorldPoint(movedPoint);

            Vector3 diffPos = movedPoint - initMousePos;
            diffPos.y = 0;

            initMousePos = Input.mousePosition;
            initMousePos.y = 10;
            initMousePos = cam.ScreenToWorldPoint(initMousePos);

            tr.transform.position = new Vector3(Mathf.Clamp(tr.transform.position.x + diffPos.x, -3.5f, 3.5f), tr.transform.position.y, Mathf.Clamp(tr.transform.position.z + diffPos.z, -4.5f, 4.5f));
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

        }
    }
}
