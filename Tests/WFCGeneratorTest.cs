using System.Collections.Generic;
using NUnit.Framework;
using WaveFunctionCollapseGenerator;

namespace WaveFunctionCollapseGeneratorTests {
    public class WFCGeneratorTest {

        [ Test ]
        public void GetMatchingSocketsTest_Without_Weights( ) {
            var collapsedBlockSocket = new List<Socket> {
                new (){ SocketType = SocketType.Earth },
                new (){ SocketType = SocketType.Grass },
                new (){ SocketType = SocketType.Tree },
            };
            
            var neighbourBlockSocket = new List<Socket> {
                new (){ SocketType = SocketType.Earth },
                new (){ SocketType = SocketType.Grass },
                new (){ SocketType = SocketType.Sand },
            };

            var result = WFCGenerator.GetMatchingSockets( neighbourBlockSocket, collapsedBlockSocket );
            Assert.IsTrue( result.Contains(new (){ SocketType = SocketType.Earth } ));
            Assert.IsTrue( result.Contains(new (){ SocketType = SocketType.Grass } ));
            Assert.IsFalse( result.Contains(new (){ SocketType = SocketType.Tree } ));
            Assert.IsFalse( result.Contains(new (){ SocketType = SocketType.Sand } ));

        }
        
        [ Test ]
        public void GetMatchingSocketsTest_With_Weights( ) {
            var collapsedBlockSocket = new List<Socket> {
                new (){ SocketType = SocketType.Earth, Weight = 5 },
                new (){ SocketType = SocketType.Grass, Weight = 8 },
                new (){ SocketType = SocketType.Tree, Weight = 1 },
            };
            
            var neighbourBlockSocket = new List<Socket> {
                new (){ SocketType = SocketType.Earth, Weight = 2 },
                new (){ SocketType = SocketType.Grass, Weight = 3 },
                new (){ SocketType = SocketType.Sand, Weight = 4 },
            };

            var result = WFCGenerator.GetMatchingSockets( neighbourBlockSocket, collapsedBlockSocket );
            Assert.IsTrue( result.Contains(new (){ SocketType = SocketType.Earth, Weight = 8 } ));
            Assert.IsTrue( result.Contains(new (){ SocketType = SocketType.Grass, Weight = 7 } ));
            Assert.IsFalse( result.Contains(new (){ SocketType = SocketType.Tree, Weight = 6 } ));
            Assert.IsFalse( result.Contains(new (){ SocketType = SocketType.Sand, Weight = 0 } ));

        }
    }
}
