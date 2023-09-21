using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script triggers a UI message and/or a sound when the player enters an area.
 * This script has to be attached to an object with a collider marked as trigger (the area)
 * */

public class Interactable : MonoBehaviour
{
    
    [Tooltip("The player. It must have a collider to trigger events. If blank assumes an object named \"Player\"")]
    public GameObject player;

    [Tooltip("The canvas for the UI. If blank assumes an object named \"Canvas\"")]
    public Canvas canvas;

    [Tooltip("The textfield. If blank assumes an object named \"Message\"")]
    public Text messageField;

    [Tooltip("The message to display as text upon entering the trigger. Leave black if none.")]
    public string message = "";

    [Tooltip("Should the message disappear upon exit collider?")]
    public bool hideMessageAtExit = true;

    [Tooltip("Should the message show only once?")]
    public bool triggerOnce = false;
    private bool triggered = false;

    [Tooltip("Hide the message after x seconds. <0 means ignore duration.")]
    public float duration = -1;

    [Tooltip("The sound to play upon entering the trigger. Leave black if none.")]
    public AudioClip sound;

    [Tooltip("If no audiosource component is present, a default one will be attached.")]
    public AudioSource audioSource;

    [Tooltip("Should the message disappear when the sound stops? ie subtitle/caption")]
    public bool hideMessageAtSoundComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        if (canvas == null)
        {
            //if not initialized this scripts assumes a main canvas named "Canvas"
            canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

            if (canvas == null)
                print("Warning: I couldn't find a canvas component on an object named \"Canvas\" ");
        }
        
        if (player == null)
        {
            //if not initialized this scripts assumes a player named "Player"
            player = GameObject.Find("Player");

            if (player == null)
                print("Warning: I couldn't find a player object named \"Player\" ");
        }
        
        if(canvas != null && messageField == null)
        {
            //if not initialized this scripts assumes a player named "Player"
            messageField = canvas.transform.Find("Message").GetComponent<Text>();

            if (messageField == null)
                print("Warning: I couldn't find a message textfield named \"Message\" ");
        }

        if (messageField != null)
            messageField.text = "";

        if(sound != null)
        {
            //create default audiosource
            if(audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        //check if there is a collider
        Collider[] cols = transform.GetComponentsInChildren<Collider>();
        bool oneTrigger = false;
        
        for (int i= 0; i < cols.Length; i++)
        {
            if (cols[i].isTrigger)
                oneTrigger = true;
        }
        
        if (cols.Length == 0)
        {
            print("Warning: the object " + gameObject.name + " doesn't have any colliders attached");
        }
        else if (!oneTrigger)
        {
            print("Warning: the object " + gameObject.name + " doesn't have any colliders set on trigger attached");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && (!triggerOnce || (triggerOnce && !triggered)))
        {
            //if there is a message display
            if(message != "")
            {
                messageField.text = message;
                triggered = true;

                if(duration >0)
                {
                    Invoke("HideMessage", duration);
                }
            }

            //if there is a sound, play
            if(sound != null)
            {
                audioSource.PlayOneShot(sound);

                
                if(duration < 0 && hideMessageAtSoundComplete)
                {
                    Invoke("HideMessage", sound.length);
                }
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player && hideMessageAtExit)
        {
            HideMessage();
        }
    }


    public void HideMessage()
    {
        //don't hide other messages!
        if (messageField.text == message)
        {
            messageField.text = "";
        }
    }

}
