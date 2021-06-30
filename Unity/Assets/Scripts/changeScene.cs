using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeScene : MonoBehaviour
{
	public void gotoScene(string sceneName)
	
	{
		
	SceneManager.LoadScene (sceneName);
	
	}
}
