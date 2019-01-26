using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

namespace Client {
    public class InputHandler : ITickable {

        [Inject] private ClientNetworkManager networkManager;

        private InputData oldInput;

        public long index = 0;

        public InputData[] inputList = new InputData[1024];

        public void Tick() {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            var input = new InputData(horizontal > 0, horizontal < 0, vertical > 0, vertical < 0, index);
            if(oldInput.Down != input.Down ||
               oldInput.Up != input.Up ||
               oldInput.Left != input.Left ||
               oldInput.Right != input.Right) {
                oldInput = input;
            }
            networkManager.SendInput(input);
            long bufferSlot = index % 1024;
            inputList[bufferSlot] = input;
            index++;
        }
    }
}
