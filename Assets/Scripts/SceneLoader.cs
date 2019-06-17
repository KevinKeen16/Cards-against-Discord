using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour

{
    public GameObject Loader = null;
    public GameObject Timer = null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    float timeLeft = 5.0f;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        //if (timeLeft < 0)
        if (AvatarImage.Loaded == true)
        {
            Debug.Log("Timer ran out");
            Loader.active = false;
            Destroy(this);
        }
    }


}
