using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WaveFunctionCollapseGenerator;

namespace WaveFunctionCollapseGeneratorTests {
    public class RotationTests {
        
        [ Test ]
        public void RotateBlock90DegreesInPlace( ) {
            var grassSocket = new Socket( ) { SocketType = SocketType.Grass };
            var sandSocket = new Socket( ) { SocketType = SocketType.Sand };
            var treeSocket = new Socket( ) { SocketType = SocketType.Tree };
            var stoneSocket = new Socket( ) { SocketType = SocketType.Stone };

            var socketsTop = new List<Socket> { grassSocket, sandSocket };
            var socketsBottom = new List<Socket>{ sandSocket, stoneSocket };
            var socketsRight = new List<Socket> { treeSocket };
            var socketsLeft = new List<Socket> { stoneSocket, treeSocket };

            var block = new BlockData( socketsTop, socketsBottom, socketsLeft, socketsRight );
            block.Rotate90Degrees(  );
            
            Assert.IsTrue( socketsTop.SequenceEqual( block.SocketsRight ) );
            Assert.IsTrue( socketsBottom.SequenceEqual( block.SocketsLeft ) );
            Assert.IsTrue( socketsRight.SequenceEqual( block.SocketsBottom ) );
            Assert.IsTrue( socketsLeft.SequenceEqual( block.SocketsTop ) );
        }
    }
}