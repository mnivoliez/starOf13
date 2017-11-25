using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour {
    [SerializeField]
    private int houseSceneIndex;
	// Use this for initialization
	void Start () {
		
	}
	

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<Animator>().SetBool("isChanging", true);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(houseSceneIndex);
    }
}
