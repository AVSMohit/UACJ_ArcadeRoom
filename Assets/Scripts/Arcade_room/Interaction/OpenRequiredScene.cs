using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OPenRequiredScene : MonoBehaviour
{
   public void OpenScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    
}
