using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovementPlayer : MonoBehaviour
{
    public float speed = 5f;
    Animator anim;

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if(hor>0 && ver == 0)
        {
            anim.SetBool("isRunningRight", true);
            anim.SetBool("isRunningLeft", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isRunningBack", false);
            speed = 5f;
        } else if(hor < 0 && ver == 0)
        {
            anim.SetBool("isRunningRight", false);
            anim.SetBool("isRunningLeft", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isRunningBack", false);
            speed = 5f;
        } else if(ver>0 && hor == 0)
        {
            anim.SetBool("isRunningRight", false);
            anim.SetBool("isRunningLeft", false);
            anim.SetBool("isRunning", true);
            anim.SetBool("isRunningBack", false);
            speed = 5f;
        } else if(ver<0 && hor == 0)
        {
            anim.SetBool("isRunningRight", false);
            anim.SetBool("isRunningLeft", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isRunningBack", true);
            speed = 5f;
        }
        else
        {
            anim.SetBool("isRunningRight", false);
            anim.SetBool("isRunningLeft", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isRunningBack", false);

            speed = 0;
        }

        if (HealthManager.health <= 0)
        {
            anim.SetBool("isRunningRight", false);
            anim.SetBool("isRunningLeft", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isRunningBack", false);
            anim.SetBool("IsDead", true);
            //Destroy(gameObject,3);
            StartCoroutine(WaitForSceneLoad());
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;


        }



        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Time.deltaTime * speed;
        transform.Translate(playerMovement, Space.Self);
       // anim.SetBool("isRunning", true);
    }
}
