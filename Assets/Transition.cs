using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    IEnumerator CallTransition(int t)
    {
        yield return new WaitForSeconds(t);
        GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>().SetBool("end", true);
        yield return new WaitForSeconds(0.3f);
    }

    public IEnumerator RestartScene(int t)
    {
        yield return CallTransition(t);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartScene()
    {
        StartCoroutine(RestartScene(0));
    }

    public IEnumerator QuitGame(int t)
    {
        yield return CallTransition(t);
        Application.Quit();
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGame(0));
    }
}
