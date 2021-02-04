using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update (initialization func)

  public Rigidbody2D theRB;

  public float moveSpeed;

  public Animator myAnim;

  public static PlayerController instance;

  void Start() {
    if(instance == null){
      // this refers to an instance of the controller script if it has been assigned, the script ran already and we need to remove dupes
      instance = this;
    } else {
      Destroy(gameObject);
    }
    // gameObject refers to what script is attached to i.e. the player sprite here
    DontDestroyOnLoad(gameObject);
  }

  // Update is called once per frame
  void Update() {
    theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

    myAnim.SetFloat("moveX", theRB.velocity.x);
    myAnim.SetFloat("moveY", theRB.velocity.y);

    if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) {
      myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
      myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
    }
  }
}

