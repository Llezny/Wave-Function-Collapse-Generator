using System;

namespace WaveFunctionCollapseGenerator {
    public static class ExtensionMethods {
        public static int[] GetRandomIndexesArray( this int[] arr ) {
            var rng = new Random( );
            var size = arr.Length;
            for ( int i = 0; i < size; i++ ) {
                arr[ i ] = i;
            }
            rng.Shuffle( arr );
            return arr;
        }
        
        public static T[] Shuffle<T> (this Random rng, T[] array) {
            int n = array.Length;
            while (n > 1) {
                int k = rng.Next(n--);
                ( array[n], array[k] ) = ( array[k], array[n] );
            }
            return array;
        }
    }
}