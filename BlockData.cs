using System;
using System.Collections.Generic;
using UnityEngine;

namespace WaveFunctionCollapseGenerator {
    
    [ Serializable ]
    public class BlockData {
        [ field: SerializeField ] public GameObject Block { get; private set; }

        [ field: SerializeField ] public List<Socket> SocketsTop { get; private set; }
        [ field: SerializeField ] public List<Socket> SocketsBottom { get; private set; }
        [ field: SerializeField ] public List<Socket> SocketsLeft { get; private set; }
        [ field: SerializeField ] public List<Socket> SocketsRight { get; private set; }
        
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