using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookTriggerhouse : MonoBehaviour {

    bool sitTriggered, standTriggered;
    public Animator houseDown;
    public float waitBeforeHouseUp = 30.0f;
    
    void Awake(){
        sitTriggered = false;
        standTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touched" + other.name);
       

        if (other.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
           // houseDown.Play("housesit");
            if (!sitTriggered && !standTriggered){
                sitTriggered = true;
                houseDown.SetTrigger("sit");
                Debug.Log("house went down");
            }
            StopCoroutine("raiseHouse");
            StartCoroutine("raiseHouse");

        }
            
        
    }

    IEnumerator raiseHouse(){
        yield return new WaitForSeconds(waitBeforeHouseUp + 3.0f);
        houseDown.SetTrigger("stand");
        Debug.Log("house went up");
        standTriggered = true;
        sitTriggered = false;
        yield return new WaitForSeconds(2.0f);
        standTriggered = false;
        yield return null;
    }
}
