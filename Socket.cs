using System;
using UnityEngine;

namespace WaveFunctionCollapseGenerator {
    
    [ Serializable ]
    public class Socket : IEquatable<Socket>{
        public BlockType blockType;

        [ Range( 1, 100 ) ]
        public int Weight;

        public bool Equals( Socket other ) {
            return this.blockType == other?.blockType;
        }
    }
}