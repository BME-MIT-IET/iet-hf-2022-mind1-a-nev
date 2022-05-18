A build-ci feladat elvégzéséhez segítségett nyújtottak a dotnet környezet egyszerűen használható parancsai,
amiket a github actions workflow segítségével lehetett automatizálni minden push eseménykor.

A repoban kezdéskor már benne volt egy linux és egy windows környezethez készített build workflow,
ezt kiegészítettem egy macOS-el is. Lehetett volna egy darab build.yml fájl is ahol mátrixos formában megadva,
mind a három operációs rendszerre lehetett volna futatattni a build és test parancsokat, de végül a kiegészítés mellett döntöttem
az átírás helyett.

Szerettünk volna a benchmark részének a projekthez is ilyen automatikus futattást, de ezt el kellett vessük mert az egy külön projekt ként lett meg valósítva,
nem pedig unit tesztekként így ezeket nem tudtuk futattni github actions segítségével.
