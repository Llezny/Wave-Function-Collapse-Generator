using System.Collections.Generic;
using UnityEngine;

namespace WaveFunctionCollapseGenerator {
    public struct Cell {

        public Dictionary<Vector2Int, int> NeighbourIndexes { get; private set; }
        public bool IsCollapsed;
        public WeightedList<BlockData> AvailableBlocks;

        public bool TryGetNeighbourIndex( Vector2Int neighbourDirection, out int neighbourIndex ) {
            return NeighbourIndexes.TryGetValue( neighbourDirection, out neighbourIndex );
        }

        public void CacheNeighbourIndexes( int index, int gridEdgeSize ) {
            this.NeighbourIndexes = GetNeighbourIndexes( index, gridEdgeSize );
        }

        public static Dictionary<Vector2Int, int> GetNeighbourIndexes( int index, int gridEdgeSize ) {
            var gridSize = gridEdgeSize * gridEdgeSize;
            var neighbours = new Dictionary<Vector2Int, int>( );
            if ( index - gridEdgeSize >= 0 ) {
                neighbours.Add( Direction.North, index - gridEdgeSize );
            }

            if ( index + gridEdgeSize < gridSize ) {
                neighbours.Add( Direction.South, index + gridEdgeSize );
            }
            
            var leftBlockIndex = index - 1;
            if ( leftBlockIndex > 0 && leftBlockIndex % gridEdgeSize < gridEdgeSize - 1 ) {
                neighbours.Add( Direction.West, leftBlockIndex );
            }
            
            var rightBlockIndex = index + 1;
            if ( rightBlockIndex < gridSize && rightBlockIndex % gridEdgeSize > 0 ) {
                neighbours.Add( Direction.East, rightBlockIndex );
            }

            return neighbours;
        }
    }
}