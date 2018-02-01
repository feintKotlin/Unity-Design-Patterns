using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Feint.Command
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private KeyCode _upKey;
        [SerializeField] private KeyCode _downKey;
        [SerializeField] private KeyCode _leftKey;
        [SerializeField] private KeyCode _rightKey;

        private GameObject _gameManager;

        // Use this for initialization
        void Start()
        {
            _gameManager = GameObject.Find("GameManager");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(_upKey))
            {
                _gameManager.SendMessage("Move",CubeMsg.Msg(
                    transform,MoveDir.Up));
              
            }

            if (Input.GetKeyDown(_downKey))
            {
                _gameManager.SendMessage("Move",CubeMsg.Msg(
                    transform,MoveDir.Down));
 
            }

            if (Input.GetKeyDown(_leftKey))
            {
                _gameManager.SendMessage("Move",CubeMsg.Msg(
                    transform,MoveDir.Left));

            }

            if (Input.GetKeyDown(_rightKey))
            {
                _gameManager.SendMessage("Move",CubeMsg.Msg(
                    transform,MoveDir.Right));

            }
        }
    }
}