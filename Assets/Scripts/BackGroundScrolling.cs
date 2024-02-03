using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    /// <summary>
    /// 백그라운드 스크롤링을 위한 변수들
    /// </summary>
    public float scrollingSpeed;        // 스크롤링 속도
    public Transform[] backgrounds;     // 배경

    private float leftPosX = 0f;        // 배경의 끝 x좌표
    private float rightPosX = 0f;       // 배경의 시작 x좌표
    private float xScreenHalfSize;      // 게임 화면의 x좌표 절반
    private float yScreenHalfSize;      // 게임 화면의 y좌표 절반

    
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Scrolling();
    }

    /// <summary>
    /// 백그라운드 스크롤링에 사용되는 화면 좌표들의 값 초기화
    /// </summary>
    private void Init()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;
    }

    /// <summary>
    /// 배경들의 좌표를 scrollingSpeed만큼 계속 이동시킨다.
    /// 이동 중 배경의 x좌표가 leftPosX보다 작아졌다면
    /// 배경의 x좌표에 rightPosX만큼을 이동시켜주어
    /// 다시 화면의 시작쪽에 위치하게 해준다.
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
