# Wave function Collapse Generator for Unity


## Installation

Clone this repo under your projects `Assets` directory.

## Getting started
1.   Create ScriptableObject by clicking `Create/ScriptableObjects/WFC/BlockData`. Then define the blocks from which maps will be built. Each block has 4 sockets so that the algorithm knows which blocks can connect to each other. You can define your own sockets in `SocketType.cs`.

![Block](https://github.com/Llezny/Wave-Function-Collapse-Generator/assets/28007720/bfde9724-e964-49a8-b388-dfee14ebb3fa)
2. Create ScriptableObject by clicking `Create/ScriptableObjects/WFC/MapConfiguration`.  Drag blocks of your choice to the configuration.
   
![MapConfiguration](https://github.com/Llezny/Wave-Function-Collapse-Generator/assets/28007720/08c2d475-25ca-4fd3-810b-ff11d9f5cdda)


3. Create a new `WFCGenerator` and use `Generate()` method to generate map. `WFCGenerator` constructor takes two parameters.  The first is a previously created configuration, you can add it in the inspector or load from resources. The second is the size of the map.
```
    public class MapGenerator : Monobehaviour {
        void Start() {
            var config = Resources.Load<MapConfigurationSO>("SciptableObjects/MapConfiguration");
            var mapSize = 32;
            var generator = new WFCGenerator( config , ChunkSize );
            var map = generator.Generate( );
        }
    }
```


4. Use generated data to Instantiate blocks
   
![ExampleMap](https://github.com/Llezny/Wave-Function-Collapse-Generator/assets/28007720/8e433e8e-fcde-4c37-87e9-b2b88137ef62)

## Rotations

In block settings you can set rotations. This will generate additional blocks with selected rotations. Be careful, each rotation increases the number of blocks of a given type, which may cause them to appear more often on the map.

![Rotations](https://github.com/Llezny/Wave-Function-Collapse-Generator/assets/28007720/65d1e2d1-770e-4353-90aa-6a98b6a0941f)


## TODO
* Example scene
* ~~Block rotating~~
* Backtracking
* Special rules
* Higher test coverage
