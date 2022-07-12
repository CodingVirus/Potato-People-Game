using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : ClickablePortal
{
    // SerializeField ����� ����Ͽ� private ������ �ν����Ϳ��� ���� �����ϰ� �����.
    // ������ ��ġ�� �����ϴ� ����
    [SerializeField] private Transform destination;

    public Transform GetDestination()
    {
        return destination;
    }
}
