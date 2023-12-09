using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace WaveFunctionCollapseGenerator {
    public class WFCGenerator {
        private readonly int gridEdgeSize;
        private readonly int gridSize;

        private int cellsToCollapse;
        private Cell[] grid;

        private readonly MapConfigurationSO config;
        private readonly List<BlockData> availableBlockOnThisMap;

        public WFCGenerator( MapConfigurationSO config, int gridEdgeSize ) {
            this.gridEdgeSize = gridEdgeSize;
            this.gridSize = gridEdgeSize * gridEdgeSize;
            this.availableBlockOnThisMap = new( );
            this.config = config;
            CacheAvailableBlocks( );
        }

        public Cell[] Generate( ) {
            Init( );
            while ( cellsToCollapse >= 0 ) {
                var index = FindLowestEntropyIndex( );
                Collapse( ref grid[ index ] );
                AdjustNeighbours( index );
            }
            return grid;
        }

        public bool TryGetNeighbourCell( int currentCellIndex, Vector2Int neighbourDirection, out Cell neighbourCell ) {
            if ( grid[ currentCellIndex ].TryGetNeighbourIndex( neighbourDirection, out var neighbourIndex ) ) {
                neighbourCell = grid[ neighbourIndex ];
                return true;
            }
            neighbourCell = new Cell(  );
            return false;
        }

        private void Init( ) {
            this.grid = new Cell[ gridSize ];
            cellsToCollapse = gridSize;
            CacheCellsData( );
        }
        
        private void CacheCellsData( ) {
            for ( int i = 0; i < gridEdgeSize; i++ ) {
                for ( int j = 0; j < gridEdgeSize; j++ ) {
                    var index = i * gridEdgeSize + j;
                    grid[ index ].AvailableBlocks = new WeightedList<BlockData>(availableBlockOnThisMap);
                    grid[ index ].CacheNeighbourIndexes( index, gridEdgeSize );
                }
            }
        }

        private void CacheAvailableBlocks( ) {
            foreach ( var availableBlockSO in config.AvailableBlocksOnMap ) {
                availableBlockOnThisMap.Add( availableBlockSO.BlockData  );
                GenerateRotatedBlocks( availableBlockSO );
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
            UpdateNeighbours( collapsedBlockIndex, collapsedBlock, Direction.North );
            UpdateNeighbours( collapsedBlockIndex, collapsedBlock, Direction.South );
            UpdateNeighbours( collapsedBlockIndex, collapsedBlock, Direction.East );
            UpdateNeighbours( collapsedBlockIndex, collapsedBlock, Direction.West );
        }

        private void GenerateRotatedBlocks( BlockDataSO block ) {
            int max = ( int )RotationAmount.Right270Degrees;
            for ( int i = 1; i <= max; i*=2 ) {
                if ( block.BlockRotations.HasFlag( ( RotationAmount )i ) ) {
                    var newBlock = new BlockData( block.BlockData );
                    RotateBlock( newBlock , i );
                    availableBlockOnThisMap.Add( newBlock );
                }
            }
        }
        
        public static BlockData RotateBlock( BlockData blockToRotate, int rotationFactor ) {
            for ( int i = 0; i < rotationFactor; i++ ) {
                blockToRotate.Rotate90Degrees(  );
            }
            return blockToRotate;
        }

        private void UpdateNeighbours( int collapsedCellIndex, BlockData collapsedBlock, Vector2Int neighbourDirection ) {
            if ( !TryGetNeighbourCell( collapsedCellIndex, neighbourDirection, out var neighbourCell ) || neighbourCell.IsCollapsed ) {
                return;
            }
            
            var adjacentToNeighbourSocket = collapsedBlock.GetSocketByDirection( neighbourDirection );
            
            for ( int i = neighbourCell.AvailableBlocks.Count - 1; i >= 0; i-- ) {
                var availableNeighbourBlock = neighbourCell.AvailableBlocks[ i ];
                var compatibleSocket = adjacentToNeighbourSocket.Find( socket => socket.blockType == availableNeighbourBlock.BlockType );
                
                if ( compatibleSocket == null ) {
                    neighbourCell.AvailableBlocks.RemoveAt( i );
                    continue;
                }
               
                neighbourCell.AvailableBlocks.AddWeightToItem( availableNeighbourBlock, compatibleSocket.Weight  );
            }

            if ( Debug.isDebugBuild && neighbourCell.AvailableBlocks.Count == 0 ) {
                Debug.LogWarning( $"No available blocks for #{ collapsedCellIndex } cell, with neighbour: {collapsedBlock.BlockType}" );
            }
        }
    }
}