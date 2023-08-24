using UnityEngine;

namespace WaveFunctionCollapseGenerator {
    public struct Direction {
        public static readonly Vector2Int North = new (0, 1);
        public static readonly Vector2Int South = new (0, -1);
        public static readonly Vector2Int West = new (-1, 0);
        public static readonly Vector2Int East = new (1, 0);
    }
}