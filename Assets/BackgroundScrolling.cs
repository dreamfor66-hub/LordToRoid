using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float speed;
    public Transform[] backgrounds;
    public Camera cam;

    float leftPosX = 0f;
    float rightPosX = 0f;
    float topPosY = 0f;
    float bottomPosY = 0f;
    float xScreenHalfSize;
    float yScreenHalfSize;
    // Start is called before the first frame update
    void Awake()
    {
        yScreenHalfSize = cam.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * cam.aspect;

        //오른쪽 = 시작되는곳 = 위쪽
        //왼쪽 = 사라지는곳 = 아래쪽
        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;
        bottomPosY = -(yScreenHalfSize * 2);
        topPosY = yScreenHalfSize * 2 * backgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //대상자의 transform의 y좌표를 1/10만큼 곱해주는 코드를 넣으면 되는데 어디에 넣어야할지 모르겠음
        // 깡으로 넣은 숫자 90이 그건데...

        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(0, 0, -speed) * Time.deltaTime;

            if (backgrounds[i].position.z < bottomPosY * 90)
            {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x, nextPos.y, nextPos.z + topPosY* 90);
                backgrounds[i].position = nextPos;
            }
        }
    }
}
