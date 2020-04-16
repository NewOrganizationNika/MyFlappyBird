#pragma warning disable CS0649
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    private void Start()
    {
        float gm;

        gm = obj.GetComponentsInChildren<Bird>().Length;
        Debug.Log(gm);
    }
}