using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManage : MonoBehaviour
{
    private PlayerInputManager _playerInputManager;

    public Material p2material;
    public Color p2Color;
    public Transform p2Transform;

    private int _playerIndex = 0;

    private void Awake()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
    }
    
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        _playerIndex++;
        Debug.Log("numJug: "+_playerIndex);
        if (_playerInputManager.maxPlayerCount==_playerIndex)
        {
            Debug.Log("J2");

            //Jugador jugador = playerInput.GetComponentInChildren<Jugador>();
            Mira mira = playerInput.GetComponentInChildren<Mira>();
/*
            if (mira!=null&& jugador!=null) 
            {
                //jugador.gameObject.GetComponent<MeshRenderer>().material = p2material;
                mira.gameObject.GetComponent<SpriteRenderer>().color = p2Color;
                playerInput.gameObject.transform.position = p2Transform.position;
                Debug.Log("Todo deberia estar bien");

            }
            else
            {
                Debug.Log("Chinga tu madre");
                //Debug.Log(playerInput.GetComponentInChildren<MeshRenderer>());
                Debug.Log(mira);

            }
            */
        }
    }

    
}
