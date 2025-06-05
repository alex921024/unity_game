using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndButtonClicked()
    {
        //ИѕТрЈь SampleScene        
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
