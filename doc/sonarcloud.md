Egyik feladatunk a SonarCloud integrálása volt. Mivel a repository-hoz nem volt admin jogunk, 
így segítséghez kellett fordulnunk. Tanár Úr hamar megadta a jogot egyikünknek, így a laboron
tanultak és SonarCloud dokumetációjának a segítségével hamar integrálni tudtuk a SonarCloud-ot
a projektünkhöz.

A SonarCloud ellenőrzési eredménye:

![image](https://user-images.githubusercontent.com/79051624/169364257-52c794e0-d7cf-4d2b-8ef1-858fb58ff031.png)

Ennél a futásnál csak simán a 'dotnet build' build command-ot adtam meg.
Később találtam egy másik build command-ot és azzal is megpróbáltam.

  -dotnet restore
  -dotnet test
  -dotnet build
  
Ugyanazt az eredmény kaptam a SonarCloud-ban. Visszaállítottam a csapat által már review-olt
build command-ra.

A hibákat javítottam.

