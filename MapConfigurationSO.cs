using System.Collections.Generic;
using UnityEngine;

namespace WaveFunctionCollapseGenerator {

    [CreateAssetMenu( fileName = "New configuration", menuName = "ScriptableObjects/WFC/MapConfiguration" )]
    public class MapConfigurationSO : ScriptableObject {
        public List<BlockDataSO> AvailableBlocksOnMap;
    }
}