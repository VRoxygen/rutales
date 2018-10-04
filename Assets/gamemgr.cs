using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemgr : MonoBehaviour {

    public breadcollider breadcollider;

    public Animator youngBY;

    public AudioSource youngBYgreeting;
    public AudioSource tasklistChime;

    public GameObject taskList;
    public GameObject breadBad;
    //public GameObject timer;

    public enum State { greeting, bread, catfeeding, dragonfight, babayagafight };
    public State currentState;



    void Start()
    {
        currentState = State.greeting;
        youngBYGreet();
        StartCoroutine(PerformPlayerMotion());
    }



   /* private void OnTriggerEnter(Collider other)
    {
        Debug.Log("bread touched " + other.name);

        if (other.name == "Sphere")
        {
         //   currentState = State.bread;
            Debug.Log("bread is eaten");
        }

    } */

    void youngBYGreet()
    {
        youngBY.enabled = true;
    }


    IEnumerator PerformPlayerMotion()
    {
        yield return new WaitForSeconds(5);
        youngBY.Play("Talking");
        youngBYgreeting.Play();

        yield return new WaitForSeconds(21);
        Debug.Log("10seconds has passed");
        taskList.SetActive(true);
        tasklistChime.Play();
      //  timer.SetActive(true);
       // bread.SetActive(true);
        // yield return StartCoroutine();

    }

    /*  void Start()
      {
          StartCoroutine(Example());
      }
      [VRTK][AUTOGEN][BodyColliderContainer]

      IEnumerator Example()
      {
          print(Time.time);
          yield return new WaitForSeconds(5);
          print(Time.time);
      }
      */
}
