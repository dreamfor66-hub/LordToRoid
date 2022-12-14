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

        //������ = ���۵Ǵ°� = ����
        //���� = ������°� = �Ʒ���
        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;
        bottomPosY = -(yScreenHalfSize * 2);
        topPosY = yScreenHalfSize * 2 * backgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //������� transform�� y��ǥ�� 1/10��ŭ �����ִ� �ڵ带 ������ �Ǵµ� ��� �־������ �𸣰���
        // ������ ���� ���� 90�� �װǵ�...

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
