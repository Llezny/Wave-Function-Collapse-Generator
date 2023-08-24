# Wave function Collapse Generator for Unity


## Installation

Clone this repo under your projets `Assets` directory.

## Getting started
1.   Create ScriptableObject by clicking `Create/ScriptableObjects/WFC/BlockData`. Then define the blocks from which maps will be built. Each block has 4 sockets so that the algorithm knows which blocks can connect to each other. In You can define your own sockets in `SocketType.cs`.

![BlockData](https://lh3.googleusercontent.com/pw/AIL4fc_IoQalTXqFPw_S3AhtXbcEP3QmLPkIhWfR152gG7HKNK-oEkI0pg77ETcrn7l5dc5Ev92gpaAQP8c_7708XnigO3FMvvPYO8RrGLZwac_FhjU6btcppsd4Yiw9lKO6N31bsOEhNtAxuFfqTZrDX4-tiFXMDP47SMPL2-RlS7-macHFjZvJQwJ2NA-Tk1iPaIFZ6NQyM9YxZNuK_8wuFa3l9rL3LU5IFvZgioFj_7tFrwIHy2YBtk8rJzQkBjKvjLtJvVZ-x3pYgL5akGkcFz1p2qX0T9hFWnA8Ip72NJZhehV7K7K5nAHXqY7KyrMMKL7rTcMcKeZeU6ecSgrY1_J8rOwAWC-76s3eRm_h47WATLGRAVJkG36pkaQyrmbhMY9oYYlJ_YsC5SzypzaE1JLP6SeyTShLoXoHA8enabyaDdjlj-llNVyxe24oQj7cZuYdanauO8tgHw9xpVmOVCu_T8PNpYNjQEEJYDGjMju6oaf5u-QAhOOstd4bI_39vkbvMJSixYEhbgOp7t6rK-3iQaYBtR-F2C-vOlUEYs9I4T6fgZbCdRqTJwKQpuqSV2QlKUAs-bzoeB4m3aKBFtUjatIH-hG3I4DLn-F5PU2b5T8jL2T2sLQojY01iuGCnztkzj5xpjLo5oSPQAg8p8a5yCIZKY0nImuXy5k1HjMd2TTwGNAoHbLu4O2LJWkblm_OmeZ_vNpUgm2QPaHLcnbvZSiDpXNB7YbsLtaf7x3YdkoU8Pxu5xT4P_mGVIkFKE8WkF6Xytg_p2GPaNAJCGs01CpzNgJbS42joGg39Bfn7d7CPAmMFkcBZmT1j-UwxUCQBGfdUkduyBHivcDLq-gDFeyH-QtOxdSFWhj1HHDKgXCIVh3dEm4oBjybbiu11C1EXIDrWgspjZGXTT27bk_pMJSXraOqBkr6aQmEpcKK8MWW0M-3Ly2tL7T9Sgsjg7dJ4xM5ugkdztNsCNCzLvXgoZ_ZWtGQLZgYs9hGk2bpuRwxfBlluvhfAJQt9XwUvVE=w653-h447-s-no?authuser=0)


2. Create ScriptableObject by clicking `Create/ScriptableObjects/WFC/MapConfiguration`.   Drag blocks of your choice to the configuration.
   
![MapConfiguration](https://lh3.googleusercontent.com/pw/AIL4fc-eB-tpSRTyvNiCise_Mbm84XU1NIhPOPDEPv_c766hMG17FORa7Tm5bsGtbXvinjIt7UUYjHoJRQBHnikjhEfhGAulabdMLjIt5EzhMJo8i3DnCK1tXha6duxDbDpxCsVXqu4DIQFUHhr6xLC_PRrU=w663-h208-s-no)


3. Create new `WFCGenerator` and use `Generate()` method to generate map. `WFCGenerator` constructor takes two parameters.  The first is a previously created configuration, you can add it in the inspector or load from resources. The second is the size of the map.
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
   
![ExampleMap](https://lh3.googleusercontent.com/pw/AIL4fc9TepdAdPulJLpVXo7oBiM80RoyEE5gSZjYNCj45dQEiKCTyOlZUC2vjSE4eewECWbxVQyAR6c7SmiqkEL_8WovvajgyfZaTNEDRb7XHG4ZCjKEPFVl2UEmzO5KxA990_yGmbxxw5drSNcRgyBeocPiCEwdt6HRdwJaKWfxaQz06xGaQZIpQ2pEqqTsqhkuxGtbONhXmuRoo59kgbwsAM0K6o1i2uhg4ya6elseIqNoW-akqc9ANmpW7ZfE_VVgCuMmjcxjSU0Lsh8oKo2GzzV5axILD43L3AyIUF9kxBQ6AdQeGTE9up79UKx_wZhxZMS_QOeX07EooDXWHHJ_HQ4nzM8aJlPxrDCEa97sQcp99AL9dJQOGRBaLO4R1nxuEp-jz2cjzkrSP77JThZpQaLOd9oLw6g5WIfB32YCIvNvngcMEaxbgUV3HWi_zRRCHccyYhYa7lIYeVp_iuHeL-v3tCN7vrfYjuPCLcOZ8miP79aU6iYPYQUnjslmO8_DNGY4S3ccX3yYL3imN3xnUwjv15HV7YXcu-T5PzQOSweGQSM9thAdPSWBzUoculFojn0C7xVrk5k07xUJ2AvMYoMGRqX_gil3qVTQBPFFVLitMQzI89MjF_mOI3fvrsVIaXgHAerf2ExrnmM39Q5Kiit4Pz3xdxrfWL1FqejACh54zwQowxbkUCa05cO-hIsXADkkDz_RZHdgNediGH1hkKcZbWDpQ0SgazYiO9wrX3oHBnzs0xgVBxHugr-0S4sPqHWkUKMfEMN4lGY4RHZmblqt1Q23ALv9KAjXrRgaH3gwnFMlE9ACo9REB1ihhn_KX05xRjDR4xHssC8sy2lOKJC7z-q4uuZciOggH0TDGm-6lGx1ZGLsVfRpK96LMMaQVmY62oy0jE7LXuzOiPjdQvIkEwj3fJJjHUTMZwy7TUEOLyL7D3ZL353GMuSe93IJ1gACHht6Q9R3HpNaSWj4nBcU1BULyKwoLh1cI3J1UlWATnrpkpt_a80mGiFYICwDd2s=w1720-h932-s-no?authuser=0)


## TODO
* Example scene
* Block rotating
* Backtracking
* Special rules
* Higher test coverage
