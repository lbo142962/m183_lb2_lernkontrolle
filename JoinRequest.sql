Select f.* 
From Films F
Join ActorFilm On ActorFilm.FilmID = F.ID
Join Actors On Actors.ID = ActorFilm.ActorID
where Actors.LastName Like 'M%'
