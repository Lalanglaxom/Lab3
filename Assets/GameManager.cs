using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject player;

    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI restartText;


    private void Start() {
        StartCoroutine(SpawnWaves());
    }

    private void Update() {
        SetText();

        if (!player.activeInHierarchy) {
            setEndText();
        }
        
        if(Input.GetKeyDown(KeyCode.S) && !player.activeInHierarchy) {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator SpawnWaves() {
        var numAsteroid = 3;

        while(true) {
            for(int i=0; i < numAsteroid; i++) {
                SpawnAsteroid();
                yield return new WaitForSeconds(2);
            }
        yield return new WaitForSeconds(4);
        }
        
        
    }

    void SpawnAsteroid() {
        Instantiate(asteroid, new Vector3(Random.Range(-4.76f, 4.76f), 0, Random.Range(10, 14)), transform.rotation); 
    }

    void SetText() {
        scoreText.SetText("Score: {0}", score);
    }

    void setEndText() {
        endText.enabled = true;
        restartText.enabled = true;
    }
}
