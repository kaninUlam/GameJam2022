using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Text _youWin;

    // Start is called before the first frame update
    void Start()
    {
        _youWin.enabled = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            _youWin.enabled = true;
            Time.timeScale = 0;
            StartCoroutine(Restart());
        }
    }


    IEnumerator Restart()
    {
        new WaitForSeconds(2f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        yield return null;
    }

}
