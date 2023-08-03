using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Test2
{
    public GameObject myObj;
    public int test2;
    public float test3;
}

public enum MyTest
{
    A,
    B,
    C,
}
public class EditorTest : MonoBehaviour
{
    public int intTest = 0;
    public List<GameObject> list;

    [HideInInspector][SerializeField] MyTest _enumTest;
    [HideInInspector][SerializeField] MyTest _enumTest2;
    [HideInInspector][SerializeField] Test2 _test4;

}
