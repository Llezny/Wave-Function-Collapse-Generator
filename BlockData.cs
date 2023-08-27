using System;
using System.Collections.Generic;
using UnityEngine;

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit {}
}

namespace WaveFunctionCollapseGenerator {
    
    [ Serializable ]
    public class BlockData {
        [ field: SerializeField ] public GameObject Block { get; private set; }

        [ field: SerializeField ] public List<Socket> SocketsTop { get; private set; }
        [ field: SerializeField ] public List<Socket> SocketsBottom { get; private set; }
        [ field: SerializeField ] public List<Socket> SocketsLeft { get; private set; }
        [ field: SerializeField ] public List<Socket> SocketsRight { get; private set; }
        
        public BlockData( ) { }

        public BlockData( BlockData previousBlock ) {
            Block = previousBlock.Block;
            SocketsTop = new( previousBlock.SocketsTop );
            SocketsBottom = new( previousBlock.SocketsBottom );
            SocketsLeft = new( previousBlock.SocketsLeft );
            SocketsRight = new( previousBlock.SocketsRight );
        }

        public BlockData( List<Socket> socketsTop, List<Socket> socketsBottom, 
                          List<Socket> socketsLeft, List<Socket> socketsRight, GameObject block = null ) {
            Block = block;
            SocketsTop = new( socketsTop );
            SocketsBottom = new( socketsBottom );
            SocketsLeft = new( socketsLeft );
            SocketsRight = new( socketsRight );
        }
        
        public void Rotate90Degrees() {
            var socketsTop = SocketsTop;
            
            SocketsTop = SocketsLeft;
            SocketsLeft = SocketsBottom;
            SocketsBottom = SocketsRight;
            SocketsRight = socketsTop;
        }
        
        public List<Socket> GetSocketByDirection( Vector2Int edge ) {
            if ( edge == Direction.North ) {
                return SocketsTop;
            }
            if ( edge == Direction.South ) {
                return SocketsBottom;
            }
            if ( edge == Direction.West ) {
                return SocketsLeft;
            }
            if ( edge == Direction.East ) {
                return SocketsRight;
            }
            throw new ArgumentOutOfRangeException( nameof(edge), $"This edge does not exist {edge}" );
        }
    }
}