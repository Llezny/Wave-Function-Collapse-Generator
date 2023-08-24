using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using UnityEngine;

namespace WaveFunctionCollapseGenerator {
    public class WFCGenerator {
        private readonly int gridEdgeSize;
        private readonly int gridSize;

        private int cellsToCollapse;
        private Cell[] grid;

        private readonly List<BlockData> availableBlockOnThisMap;

        public WFCGenerator( List<BlockData> availableBlocksOnThisMap, int gridEdgeSize ) {
            this.gridEdgeSize = gridEdgeSize;
            this.gridSize = gridEdgeSize * gridEdgeSize;
            this.grid = new Cell[ gridSize ];
            this.availableBlockOnThisMap = availableBlocksOnThisMap;
            Prewarm( );
        }

        public Cell[] Generate( ) {
            cellsToCollapse = gridSize;
            while ( cellsToCollapse >= 0 ) {
                var index = FindLowestEntropyIndex( );
                Collapse( ref grid[ index ] );
                AdjustNeighbours( index );
            }
            return grid;
        }
        
        public static List<Socket> GetMatchingSockets( List<Socket> adjacentToCollapsedBlockSocket, List<Socket> adjacentToNeighbourSocket ) {
            List<Socket> matchingSockets = new( );
            foreach ( var socket in adjacentToCollapsedBlockSocket ) {
                if ( adjacentToNeighbourSocket.Contains( socket ) ) {
                    matchingSockets.Add( socket );
                }
            }
            return matchingSockets;
        }

        public bool TryGetNeighbourCell( int currentCellIndex, Vector2Int neighbourDirection, out Cell neighbourCell ) {
            if ( grid[ currentCellIndex ].TryGetNeighbourIndex( neighbourDirection, out var neighbourIndex ) ) {
                neighbourCell = grid[ neighbourIndex ];
                return true;
            }
            neighbourCell = new Cell(  );
            return false;
        }

        private void Prewarm( ) {
            for ( int i = 0; i < gridEdgeSize; i++ ) {
                for ( int j = 0; j < gridEdgeSize; j++ ) {
                    var index = i * gridEdgeSize + j;
                    grid[ index ].AvailableBlocks = new WeightedList<BlockData>(availableBlockOnThisMap);
                    grid[ index ].CacheNeighbourIndexes( index, gridEdgeSize );
                }
            }
        }

        private int FindLowestEntropyIndex() {
            var indexes = new int[gridSize].GetRandomIndexesArray( );
            var cellWithLowestEntropy = int.MaxValue;
            var index = 0;

            for ( int i = 0; i < gridSize; i++ ) {
                var randomIndex = indexes[ i ];
                var cell = grid[ randomIndex ];
                if ( cell.IsCollapsed || cell.AvailableBlocks.Count > cellWithLowestEntropy ) {
                    continue;
                }
                index = randomIndex;
                cellWithLowestEntropy = cell.AvailableBlocks.Count;
            }
            return index;
        }

        private void Collapse( ref Cell cell ) {
            var randomizedBlock = cell.AvailableBlocks.Next( );
            cell.AvailableBlocks.RemoveAll( block => block != randomizedBlock );
            cell.IsCollapsed = true;
            cellsToCollapse--;
        }

        private void AdjustNeighbours( int collapsedBlockIndex ) {
            if ( grid[ collapsedBlockIndex ].AvailableBlocks.IsNullOrEmpty( ) ) {
                return;
            }
            var collapsedBlock = grid[ collapsedBlockIndex ].AvailableBlocks[ 0 ];
            UpdateNeighbourWeights( collapsedBlockIndex, collapsedBlock, Direction.North );
            UpdateNeighbourWeights( collapsedBlockIndex, collapsedBlock, Direction.South );
            UpdateNeighbourWeights( collapsedBlockIndex, collapsedBlock, Direction.East );
            UpdateNeighbourWeights( collapsedBlockIndex, collapsedBlock, Direction.West );
        }

        private void UpdateNeighbourWeights( int collapsedCellIndex, BlockData collapsedBlock, Vector2Int neighbourDirection ) {
            if ( !TryGetNeighbourCell( collapsedCellIndex, neighbourDirection, out var neighbourCell ) || neighbourCell.IsCollapsed ) {
                return;
            }
            
            var adjacentToNeighbourSocket = collapsedBlock.GetSocketByDirection( neighbourDirection );
            
            for ( int i = neighbourCell.AvailableBlocks.Count - 1; i >= 0; i-- ) {
                var availableNeighbourBlock = neighbourCell.AvailableBlocks[ i ];
                var adjacentToCollapsedBlockSocket = availableNeighbourBlock.GetSocketByDirection( -neighbourDirection ) ;

                var matchingSockets = GetMatchingSockets( adjacentToCollapsedBlockSocket, adjacentToNeighbourSocket );
                if ( matchingSockets.IsNullOrEmpty( ) ) {
                    neighbourCell.AvailableBlocks.RemoveAt( i );
                    return;
                }
                foreach ( var socket in matchingSockets ) {
                    neighbourCell.AvailableBlocks.AddWeightToItem( collapsedBlock, socket.Weight  );
                }
            }
        }
    }
}