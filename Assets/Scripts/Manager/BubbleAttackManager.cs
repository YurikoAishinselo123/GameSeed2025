using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public class BubbleAttackManager : MonoBehaviour
{
    [SerializeField] GameObject CapturePlayer;
    GameObject Player;
    PlayerController playerController;
    Collider2D PlayerCollider;
    bool isCapture = false;
    ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = Player.GetComponent<Collider2D>();
        ps.trigger.SetCollider(0, PlayerCollider);
        playerController = Player.GetComponent<PlayerController>();
    }
    private void OnParticleTrigger()
    {
        if (isCapture == true)
            return;
        StartCoroutine(SetCapturePlayer());
    }

    IEnumerator SetCapturePlayer()
    {
        if(isCapture == false)
        {
            isCapture = true;
            GameObject CapturePlayerObj = Instantiate(CapturePlayer, Player.transform.position, Quaternion.identity);
            CapturePlayerObj.transform.SetParent(Player.transform);
            playerController.canMove = true;
            Debug.Log("test");
            yield return new WaitForSeconds(2f);
            if(playerController != null)
            {
                playerController.canMove = false;
            }
            Destroy(CapturePlayerObj);
            playerController.anim.SetBool("Exploded", true);
            yield return new WaitForSeconds(.8f);
            playerController.anim.SetBool("Exploded", false);
        }
    }
    //void setFreesPlayer()
    //{
    //    Destroy(CapturePlayerObj);
    //    playerController.enabled = true;
    //}
}
