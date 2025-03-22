using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3);
        GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>().SetBool("end", true);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
