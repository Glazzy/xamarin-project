# Mobiludvikling Afleveringsprojekt

Projektet er udarbejdet af Lasse P. og Kevin. Det er en app der kan vise information om film og opkobler til [The Movie Database API](https://developers.themoviedb.org/3/). Man kan bl.a. få vist en oversigt over populære film, en side over film man har gjort til favoritter, og få foreslået nye film baseret på forskellige kriterier.

Projektet er delvist opbygget efter MVVM (Model View ViewModel) mønsteret med databinding mellem ContentPages/Views og ViewModels.

## Oversigt over ContentPages

### Main/MainMaster

En MasterDetailPage med MainMaster som master page og MainPage som detail page. MainMaster har navigation til andre sider, samt en søgefunktion. Main/MainMaster er lavet af Lasse

### MainPage

Dette er applikationens forside, der viser en liste over film der er populære i øjeblikket. MainPage er lavet af Kevin.

### FavoritesPage

Denne sider viser en liste over film der er blevet markeret som favoritter. FavoritesPage er lavet af Lasse.

### MoviePage

Denne side viser information om en enkelt film, og der navigeres til denne hver gang der trykkes på en film andre steder i applikationen. MoviePage er lavet af Lasse.

### RandomMoviePage

RandomMoviePage er lavet af Kevin.

### SearchPage

En liste med søgeresultater fra søgefunktion i MainMaster. SearchPage er lavet af Lasse.
