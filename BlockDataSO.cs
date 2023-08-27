using UnityEngine;

namespace WaveFunctionCollapseGenerator {
    [CreateAssetMenu( fileName = "WaveFunctionCollapse Model", menuName = "ScriptableObjects/WFC/BlockData" )]
    public class BlockDataSO : ScriptableObject {
        [ field: SerializeField ] public RotationAmount BlockRotations { get; private set; }
        [ field: SerializeField ] public BlockData BlockData { get; private set; }
    }
}