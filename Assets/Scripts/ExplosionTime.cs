using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTime : MonoBehaviour
{
    public void ExplosionEnd(){
        Destroy(gameObject);
    }
}
