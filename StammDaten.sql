Insert Into Actors (FirstName, LastName,Age , Credits, Biography)
Values
('Wanja','Mues','49', 'The Pianist, The Bourne Supermacy and Unsere Hagenbecks','Der Beste Dude'),
('Ian','McSahne','81', 'One Piece, Pirates of the Caribbean und John Wick','Nid ganz der Beste'),
('Louis','Hofmann','26', 'Danni Lowinski, Der verlorene Vater','Der würklich grössti wos git'),
('Jeffrey','Bridges','73', 'The Big Lebowski, Tron und Tron: Legacy','The Dude'),
('Viggo','Mortensen','65', 'Herr der Ringe','The man, the Mith, the Legend');

Insert Into Directors ( FirstName, LastName, Age,  Credits, Biography)
Values
('Quentin', 'Tarantino', '60','Pulp Fiction, Kill Bill und Inglourius Basterds', 'He was Born in Knoxville'  ),
('Steven', 'Spielberg', '76','Jaws, Jurassic Park und E.T', 'He was Born in Cincinnati'  ),
('Samuel', 'Mendes', '58','1917, James Bond 007 Skyfall and Spectre', 'He was Born in Knoxville'  ),
('Peter', 'Jackson', '61','Herr Der Ringe', 'He was Born in Pukerua'),
('Wesly', 'Anderson', '54','Grand Budapest Hotel', 'He was Born in Houston'  );

Insert Into Genres( Name, Description)
Values
('Krimi', 'Polizei Serien'),
('Thriller', 'Hohe Spannung'),
('Liebesroman', 'Es küssen sich zwei'),
('Science Fiction', 'Weltall'),
('Fantasy', 'Harry you a wizard'),
('Horror', 'BUUUUUUUUUUUU');

Insert Into Films ( Name, DirectorId, ActorId, GenreId, Synopsis, Length, Rating, ReleaseYear )
Values 
('Herr der Ringe: Die Gefährten', '4','5','5','Anfang der Reise','210','10', '2001'),
('Herr der Ringe: Die zwei Türme', '4','5','5','Mitte der Reise','240','12','2002'),
('Herr der Ringe: Rückkehr des Königs', '4','5','5','Ende der Reise','270','11','2003'),
('Grand Budapest Hotel', '4','','','Grosse Pinkes Hotel','100','9','2014'),
('1917', '3','','','One Shot WW1','210','9','2001');