using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    /// <summary>
    /// ��׶��� ��ũ�Ѹ��� ���� ������
    /// </summary>
    public float scrollingSpeed;        // ��ũ�Ѹ� �ӵ�
    public Transform[] backgrounds;     // ���

    private float leftPosX = 0f;        // ����� �� x��ǥ
    private float rightPosX = 0f;       // ����� ���� x��ǥ
    private float xScreenHalfSize;      // ���� ȭ���� x��ǥ ����
    private float yScreenHalfSize;      // ���� ȭ���� y��ǥ ����

    
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Scrolling();
    }

    /// <summary>
    /// ��׶��� ��ũ�Ѹ��� ���Ǵ� ȭ�� ��ǥ���� �� �ʱ�ȭ
    /// </summary>
    private void Init()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;
    }

    /// <summary>
    /// ������ ��ǥ�� scrollingSpeed��ŭ ��� �̵���Ų��.
    /// �̵� �� ����� x��ǥ�� leftPosX���� �۾����ٸ�
    /// ����� x��ǥ�� rightPosX��ŭ�� �̵������־�
    /// �ٽ� ȭ���� �����ʿ� ��ġ�ϰ� ���ش�.
    /// </summary>
    private void Scrolling()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-scrollingSpeed, 0, 0) * Time.deltaTime;

            if (backgrounds[i].position.x < leftPosX)
            {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x + rightPosX, nextPos.y, nextPos.z);
                backgrounds[i].position = nextPos;
            }
        }
    }
}
