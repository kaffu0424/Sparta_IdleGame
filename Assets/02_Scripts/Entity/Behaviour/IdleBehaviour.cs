using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : MonoBehaviour, IIdleBehaviour
{
    public void InitIdle(BaseEntity owner)
    {
        throw new System.NotImplementedException();
    }

    public void OnIdle()
    {
        Debug.Log("IdleBehaviour 1");
    }
}
