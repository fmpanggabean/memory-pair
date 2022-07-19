using UnityEngine;

namespace MemoryPair {
    public class BaseUI : MonoBehaviour {

        public void Hide() {
            gameObject.SetActive(false);
        }
        public void Show() {
            gameObject.SetActive(true);
        }
    } 
}
