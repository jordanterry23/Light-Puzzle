using UnityEngine;

public class GameLight : MonoBehaviour
{
    public bool on = false;

    public Color onColor = Color.green;
    public Color offColor = Color.red;
    
    private SpriteRenderer sr;

    public AudioSource source;
    public Sprite onSprite;
    public Sprite offSprite;
    public AudioClip onSound;
    public AudioClip offSound;


    private void Start()
    {

        sr = gameObject.GetComponent<SpriteRenderer>();
        source = gameObject.GetComponent<AudioSource>();
        source.clip = onSound;

        SetColor();
    }

    private void Update()
    {
        SetColor();
    }

    private void SetColor()
    {
        if (!on)
        {
            sr.color = offColor;
            sr.sprite = offSprite;
        }
        else
        {
            sr.color = onColor;
            sr.sprite = onSprite;
        }
    }

    private void OnMouseDown()
    {
        SendMessageUpwards("Switch", this);
    }

    public void PlaySound()
    {
        if(on)
        {
            source.clip = onSound;
        }
        else
        {
            source.clip = offSound;
        }
        source.Play();
    }

}
