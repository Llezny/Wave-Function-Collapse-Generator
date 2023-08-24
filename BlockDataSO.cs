﻿using UnityEngine;

namespace WaveFunctionCollapseGenerator {
    [CreateAssetMenu( fileName = "WaveFunctionCollapse Model", menuName = "ScriptableObjects/WFC/WFC Block" )]
    public class BlockDataSO : ScriptableObject {
        [ field: SerializeField ] public BlockData BlockData { get; private set; }
    }
}