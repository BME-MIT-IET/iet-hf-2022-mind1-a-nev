Egyik feladatunk a SonarCloud integrálása volt. Mivel a repository-hoz nem volt admin jogunk, 
így segítséghez kellett fordulnunk. Tanár Úr hamar megadta a jogot egyikünknek, így a laboron
tanultak és SonarCloud dokumetációjának a segítségével hamar integrálni tudtuk a SonarCloud-ot
a projektünkhöz.

A SonarCloud ellenőrzési eredménye:

![image](https://user-images.githubusercontent.com/79051624/168875854-c4cc8985-9cfb-4963-bd5c-745d373f82f5.png)

Ennél a futásnál csak simán a 'dotnet build' build command-ot adtam meg.
Később találtam egy másik build command-ot és azzal is megpróbáltam.

  -dotnet restore
  -dotnet test
  -dotnet build
  
Ugyanazt az eredmény kaptam a SonarCloud-ban. Visszaállítottam a csapat által már review-olt
build command-ra.

Manuális kódvizsgálatot végeztem a projekt Model részére. Vizsgálataim során nem találtam semmi
kiróvó hibát, bug-ot vagy code smell-t, így elfogadtam a SonarCloud által szolgáltatott eredményt

