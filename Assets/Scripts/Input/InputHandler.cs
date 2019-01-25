using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Client {
    public class InputHandler : MonoBehaviour {

        [Inject] private ClientNetworkManager networkManager;

        private InputData oldInput;

        public void Update() {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            var input = new InputData(horizontal > 0, horizontal < 0, vertical > 0, vertical < 0);
            if(oldInput.Down != input.Down ||
               oldInput.Up != input.Up ||
               oldInput.Left != input.Left ||
               oldInput.Right != input.Right) {
                networkManager.SendInput(input);
                oldInput = input;
            }
        }
    }
}
