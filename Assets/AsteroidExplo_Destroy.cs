using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplo_Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2);   
    }
}
