using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    Rigidbody rocketRB;
    AudioSource rocketAudiosource;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] float rotateSpeed = 5f;
    [SerializeField] float thrustSpeed = 5f;




    // Start is called before the first frame update
    void Start()
    {
    
        rocketRB = GetComponent<Rigidbody>();
        rocketAudiosource = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();

    }
    private void Thrust(){
        if (Input.GetKey(KeyCode.Space)) {
        print ("Thrusting");
        rocketRB.AddRelativeForce (Vector3.up * thrustSpeed);

        if (!rocketAudiosource.isPlaying) {
            rocketAudiosource.PlayOneShot(mainEngine);
        }
        
        }
        else {
            rocketAudiosource.Stop();
        }
        }

        

    

    void OnCollisionEnter(Collision collision){
        switch (collision.gameObject.tag) {
        case "Friendly":
            print ("No problem");
            break;
        case "Finish":
            print ("You win!");
            break;
        default:
            break;
        }
}

    void Rotate ()
        {
        rocketRB.freezeRotation = true; //this says that we will take manual control of the rotation
        if (Input.GetKey (KeyCode.D)) {
            transform.Rotate (Vector3.forward * rotateSpeed);
        }
        else
            if (Input.GetKey (KeyCode.A)) {
            transform.Rotate (-Vector3.forward * rotateSpeed);
            }
        rocketRB.freezeRotation = false;
        }

    
    

        
    

}
