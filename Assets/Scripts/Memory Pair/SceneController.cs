using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MemoryPair
{
    public class SceneController : MonoBehaviour
    {
        
        public void PlayGame() {
            SceneManager.LoadScene(1);
        }
        public void MainMenu() {
            SceneManager.LoadScene(0);
        }
    }
}
