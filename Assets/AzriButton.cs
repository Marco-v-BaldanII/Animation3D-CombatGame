using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AzriButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayAsAzri()
    {
        SceneManager.LoadScene("AzriScene");
    }
}
