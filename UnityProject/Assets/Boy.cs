using UnityEngine;

public class Boy : MonoBehaviour
{
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    [Header("跳躍高度"), Range(100, 1500)]
    public int jump = 100;
    bool floor = false;   //判斷是否在地板
    public Rigidbody Rb;         //剛體
    public AudioSource As;    //音效
    public Animator at; //動畫

    private void Update()
    {
        Move();
        Rb = GetComponent<Rigidbody>();
        As = GetComponent<AudioSource>();
	
    }

    private void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    public void Jump()
    {
	if(floor == true)
	{
	Rb.AddForce(new Vector3(0, jump, 0));
	at.SetBool("跳躍開關", true);
	As.Play();
	floor = false;
	}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "地板")
        {
	    at.SetBool("跳躍開關", false);
            floor = true; //判斷是否在地板
        }
    }
}
