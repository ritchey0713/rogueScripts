using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update (initialization func)

  public Rigidbody2D theRB;

  void Start() {

  }

  // Update is called once per frame
  void Update() {
    theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
  }
}

