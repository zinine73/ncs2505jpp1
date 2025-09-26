using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 offset = new Vector3(0, 6, -13);

    void LateUpdate() // 카메라 이동은 LateUpdate에서 하자
    {
        transform.position = player.transform.position
            + offset;
    }
}
