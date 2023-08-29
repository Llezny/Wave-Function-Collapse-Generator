# Wave function Collapse Generator for Unity


## Installation

Clone this repo under your projets `Assets` directory.

## Getting started
1.   Create ScriptableObject by clicking `Create/ScriptableObjects/WFC/BlockData`. Then define the blocks from which maps will be built. Each block has 4 sockets so that the algorithm knows which blocks can connect to each other. In You can define your own sockets in `SocketType.cs`.

![Block](https://lh3.googleusercontent.com/pw/AIL4fc8v8LboRfEKLssyQ5RCGeGzri4KkQt-iXHLtbJy31V5CN76Y2ocvMoQFyEtD8bTyi_KkWpmblosC0wKg3nXISs5d9-sE-s8jPD8zWqKKgRoWepFvbcqVoIUW3ZBC5DnjmFj4KC5QA6HbeO5DfCD5EdTCJbg0kirvKMdDpAvzXocU1_1sBkvXPRiW86--PDREDjEFTv_5PDIFXNnHOqd6jqDdU0_4uGN-HKXcJglrH7FHlL5ylLJB4eqPDIPMuCcz1Z1zXIFIbRFEfofp6MhCfM8kWxK8aPojcWlLzlpCk_sUuBjbrV1mtS-eAZTnlRYkKPy1WbPUykcV1qr722gkYnyT-mVZljPm-yEHjhT8U2dx2pIvDzxNUy3q_5GWPR1X7V30h7LtBMTQde_qxO-5NTFnUpQPRGvzsx3ZJKCxbRcpc06lqVjm56Yra2UBu_I7STcLZo2gydthHJATAvHKLuSOJRoCWFK4d7ltpTCMQmhvFOJrkYdt8Fp1PslEqky6cCGnlwKh3Eb-0PDeyr7a8M6xxa0L8DwAVwX37tIb7XRLWMus901E6QvrwwND6EKWEsFCTmvw0stC6u77g3C4k62MtNiqjU0OcXUOV37muWuAlk3ksgJBJVq9Gh81zPY5S6-NoRFej6GKCx-VDfGtlf4u4Sllr-LSOI0UQzGxhU1ZtAqUwPVee_3xxooAgLY-8OKB585YoXmiVQdsFL0nLhluZvwhLOrzBHUgIiqkH8GckOZV7tO6I0jxqDQnmGIF9OrnWvjjk-7mxjkeWqmu0DCOB3Udyoe2Z9A_BmUCo-ABuA0CRS5rpTe-u4EpXvFHKQiAyQqtAnx2vMguin_4fqzhpGsu-UjLzj5zMd7l1BUGd5kVUF76CM4RFQlwtIHgxb7BpOm5dozjYy7gceWyJQhxks-4zJgHeY_zVtiXuxkR8ZhJ05GocQvl2ygjk9ElbQxrtzrtvgdRE0EMdIXXUKGz093laHOJNGtPO5zV_S7A8TqRP5WHI6dtxYUP162DyQ=w649-h375-s-no?authuser=0)
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
   
![ExampleMap](https://lh3.googleusercontent.com/pw/AIL4fc93pi-A442E-MYGkl-_oi0Yb7KBTQixntGqy7BttEV8SRqIPBa_8VxaqaKaCd3sa5_cKLXg6hJoN-MBi9bKwvRITXcw2pymXloyHpR27q5y2IdoJIS3QsrEZUelZfDcdIwGg6mj3-UPCu01QSeQKWeNdHlWgkK2WEER_490US9xYBp72msgD6XV335j98LTN7UFpRNFzmXVdorzOrfRK6-KeTzCZ1Gb_Z6FvpURqt2vn7XHdx67U9-2mhucvBbfMkfdV1KX7b9AQwn9ImtJsLc7GzlLX_Z49QeirBpf2fdtT_B96y9rOjWYd30D_kcdlZrlc7hxqyHFQSndi4tDWhoWxOaNHEcPxqzDp2NL1gNkyN1yToJfLgZyi_lBbzpPrff9uMD6H37dxlpDliNrJvdDqRkUILtGWblyjHOuqFNHh_ghPbx4b47re3vdX01OofwGNUAGtfg55svBIoVQeDpozG4JaBr5k8gdAncZw31zS1iMk2I366mpUIZBWh8BTr95dpLbae-9E0kcA0-K3_l8PO4Eh-JzXmHTqUI5sog_L4uxuoBMbfJTQuFrarPhjJqNuHyLYOWwT8JoF7NcgTonLa8MOOJfrWm7kKas1wdG47HR6pe2eNpdeBDqrpJFzDDvkm19lGJu4rd2dzHc9o-DYM879uwO3gLSrCc_flDpL_1BETD19bVg8v7DKPGldWgDYEGsT19y8z65vXN7pYw4pqgjW1Esy9pfeWv9XmoBrLZHLXLSDnklWPVw653nTZeJxmHkZ6g5iamow9X3X2yNAmI3Akr05A7zXfTtD9ysUjT2-qog4nWudQNAB5cpB5rvsCjIn8OGkE-QPMryDcGGSDtLfpjh_6q-VVNuvbeTZBWVpL6eoD3fnmmkG4OBfAyQXYtMjFO2A-ix-bRSQEzpD3aKFXu9g3EzwoBgO7XHRHnnk4uoC66_b5MIXKrAeFx9K-ZoKnQsIBNaA3dV7Hi0JPdLMYlnrKsxyPKWhl1eW_X6MF4380nWLKbiGBhtwcc=w1597-h865-s-no?authuser=0)

## Rotations

In block settings you can set rotations. This will generate additional blocks with selected rotations. Be careful, each rotation increases the number of blocks of a given type, which may cause them to appear more often on the map.

![Rotations](https://lh3.googleusercontent.com/pw/AIL4fc9HEpxT9Tgg4v_PM5YK7fgupj8b9o0zZI-oYUpP2jjjMDtjS95_hCVinvQvkBUToGW3lCBszdX8zmkXh6Gcm-7gWe-TnPqpldpsWlT6Tn7RSJ9JZyPE4Q2tLXfZsHkNRwFL2MB9v-97cwDcURp1evR69MLfH-VYu0K5RytHa5tZ4kHZqlPSZNmpda5HpBFrQ3DjM_IsoPxMVsUfnEu_sYt7oK93bxITLBjzDUSh8hV8h8fv49dJPYq8ajcxA0FtzYnrqVrDcgyzvT0Z7_1HPOpB9Q9p70tKUvEK-uNYkOhS2u-znqsRuv2IlSlCiEAH22kCQ-V8aWJR9YbbXmcrV2gc7PuBQZckV-NzQlc1vhjqwtkE971G2YxdofNg3ay_sdddBw4-6muSXjfNqBkm0qs05BRs6NgVreBnwqv9AAdtHYA6KJcM6ylTVv5m1oEgytMYUNqh88vkbHOYzNnApRLFS8ZrHeNLI7dC8MLLESJPzKUn_3VnZa1PpIviEM5lfVVKO1_3Qep0mQH95czQm0u9rqjaTEkLYJ72QxP08agZm59cek4O_wyvbD2cgY9sB5qQkwIp-bINo4f7B-kw-5LlvckDCqwsW6liu2WvsKvK54LLhLJgE3FfLPK6NxJEx1TV67EVbeD87SGR6zQx4PXg46yOZ9riG1WSKrE3UeYlacJC2NnRc5-4mp8ZrD4DuxwwTVirbWTXER4Mj3dvWTthkz-qW2TTCRhrt6QBnWbbv1OWIKTov0ctYqNZk9c004lZnztR0xsftfv-b9LQb_WyyDc3VrXWgmnNOYqDjff09ojNj1wU54bYtqn-ddO6EVkQ8_MQl126MXgZLbf24CcDcB3Dmyna9pPyrSM8TthoZsl4NCQGha4uU7VypEzP6gGnbbaQ10MXGD7t-eXInrFGxDHKYLL6RpgxbooKFzu1vB6E8r_nrE6zeJf8_pdDD331rqNlC29dS-aJnbfJ130yTdRGpQXKUqQpHttgO7z9BlUPtSx07h80WTYhlqkLdWQ=w646-h252-s-no?authuser=0)


## TODO
* Example scene
* ~~Block rotating~~
* Backtracking
* Special rules
* Higher test coverage
