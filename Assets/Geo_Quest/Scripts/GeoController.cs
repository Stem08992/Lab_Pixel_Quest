
using UnityEngine.SceneManagement;
using UnityEngine;

public class GenController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer rbSpriteRender;

    public Color color1;
    public Color color2;
    public Color color3;

    public float speed = 5f;
    public string nextLevel = "Geo_Quest_Scene_2";
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //hitColider = GetComponent<Collider>();
        rbSpriteRender = rb.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);

                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
        }
    }

    private void colorChanger()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rbSpriteRender.color = color1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rbSpriteRender.color = color2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            rbSpriteRender.color = color3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        //Debug.Log(xInput);
        colorChanger();

    }
}
