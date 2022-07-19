using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryPair {
    [CreateAssetMenu(fileName = "Data Container", menuName = "Scriptable Object/Data Container")]
    public class DataContainer : ScriptableObject {
        public int playerCount;
    } 
}
