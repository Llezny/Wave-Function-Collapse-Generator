using NUnit.Framework;
using WaveFunctionCollapseGenerator;

namespace WaveFunctionCollapseGeneratorTests {
    public class CellTests {

        /* V LastIndex Tests V */
        [ Test ]
        public void GetNeighbourIndexes_LastIndex_West( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 15, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.West ] == 14 );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_LastIndex_East( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 15, 4 );
            Assert.IsFalse(neighbourIndexes.ContainsKey( Direction.East ) );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_LastIndex_South( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 15, 4 );
            Assert.IsFalse(neighbourIndexes.ContainsKey( Direction.South ) );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_LastIndex_North( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 15, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.North ] == 11 );
        }
        /* ^ LastIndex Tests ^ */
        
        /* V FirstIndex Tests V */
        [ Test ]
        public void GetNeighbourIndexes_FirstIndex_West( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 0, 4 );
            Assert.IsFalse(neighbourIndexes.ContainsKey( Direction.West ) );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_FirstIndex_East( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 0, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.East ] == 1 );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_FirstIndex_South( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 0, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.South ] == 4 );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_FirstIndex_North( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 0, 4 );
            Assert.IsFalse(neighbourIndexes.ContainsKey( Direction.North ) );
        }
        /* ^ FirstIndex Tests ^ */
        
        /* V Mid Tests V */
        [ Test ]
        public void GetNeighbourIndexes_Mid_West( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 10, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.West ] == 9 );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_Mid_East( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 10, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.East ] == 11 );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_Mid_South( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 10, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.South ] == 14 );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_Mid_North( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 10, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.North ] == 6 );
        }
        /* ^ Mid Tests ^ */
        
        /* V Border Tests V */
        [ Test ]
        public void GetNeighbourIndexes_AtBorder_West( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 7, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.West ] == 6 );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_AtBorder_East( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 7, 4 );
            Assert.IsFalse(neighbourIndexes.ContainsKey( Direction.East ) );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_AtBorder_South( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 7, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.South ] == 11 );
        }
        
        [ Test ]
        public void GetNeighbourIndexes_AtBorder_North( ) {
            var neighbourIndexes = Cell.GetNeighbourIndexes( 7, 4 );
            Assert.IsTrue(neighbourIndexes[ Direction.North ] == 3 );
        }
        /* ^ Border Tests ^ */
    }
}