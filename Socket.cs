using System;
using UnityEngine;

namespace WaveFunctionCollapseGenerator {
    
    [ Serializable ]
    public class Socket : IEquatable<Socket>{
        public SocketType SocketType;

        [ Range( 0, 10 ) ]
        public int Weight;

        public bool Equals( Socket other ) {
            return this.SocketType == other?.SocketType;
        }
    }
}