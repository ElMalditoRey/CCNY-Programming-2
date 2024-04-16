using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshControl : MonoBehaviour
{

    [Header("basic vars")]
    public Renderer myRender;
    public Mesh myMesh;
    public Material myMat;
    public Color baseCol = Color.white;
    public Color hitCol = Color.red;
    public Texture baseMap;
    Rigidbody myRB;

    [Header("squash vars")]
    public float speed = .1f;
    public Vector2 zClamp = new Vector2(.8f, 3f);

    [Header("SFX")]
    public TrailRenderer myTrail;
    public float gate = 2f;
    public ParticleSystem mySparks;
    public float sparkGate = 3f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        myMat = myRender.material;
        myMesh = GetComponent<MeshFilter>().mesh;
        myMat.color = baseCol;
        myMat.mainTexture = baseMap;
        myRB = GetComponent<Rigidbody>();
        mySparks.Pause();
        
    }

    // Update is called once per frame
    void Update()
    {
        speedSquash();

        //simple trail enable at higher speed
        if (myRB.velocity.magnitude > gate)
        {
            myTrail.enabled = true;
        }
        else 
        {
            myTrail.Clear();
            myTrail.enabled = false; 
        }

        if(myRB.velocity.magnitude > sparkGate)
        {
            mySparks.Play(true);
        }
        else { mySparks.Play(); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            StartCoroutine(takeHit(.7f));
        }
    }

    public void speedSquash()
    {
        if(myRB != null)
        {
            //finding the current actual speed of the RB, modifying by our desired speed of squash
            float currentSpeed = myRB.velocity.magnitude * speed;
            //clamping to a reasonable range
            float newZ = Mathf.Clamp(currentSpeed, zClamp.x, zClamp.y);

            //set the Z value to a new target if it is within our clamped range
            if(transform.localScale.z >= zClamp.x && transform.localScale.z <= zClamp.y)
            {
                transform.localScale = new Vector3(1, 1, newZ);
            }
        }
    }

    IEnumerator takeHit(float time)
    {
        //code that executes when we first call the co-routine goes here
        myMat.color = hitCol;
        yield return new WaitForSeconds(time);
        //code that executes when the time is up goes here
        myMat.color = baseCol;
    }


}
