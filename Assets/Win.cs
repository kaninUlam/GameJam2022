using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Text _youWin;
    public Timer _timer;

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
            _timer.EndTimer();
            _youWin.enabled = true;
            
            StartCoroutine(Restart());
        }
    }


    IEnumerator Restart()
    {
        yield return  new WaitForSeconds(2f);
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        
    }

}
