using System.Linq.Expressions;
using Filmsammlung.Data;
using Filmsammlung.Model;
using Filmsammlung.Model.DTO;
using Filmsammlung.Services;
using Filmsammlung.Services.Services;
using Moq;


namespace FilmSammlung.Tests
{
    [TestClass]
    public class FilmCollectionTest
    {
        [TestMethod]
        public void GetFilmbyActorTest()
        {
            Expression<Func<Actor, bool>> predicate = x => string.Concat(x.FirstName.ToLower(), "", x.LastName.ToLower()).Contains("Silas");
            string[] includes = { "ActorsFilms", "ActorsFilms.Film" };

            var genericrepositoryStub = new Moq.Mock<IGenericRepository>();

            List<Actor> actorList = new List<Actor>();

            actorList.Add(new Actor()
            {
                ID = 1,
                FirstName = "Silas",
                LastName = "Grossmann",
                ActorsFilms = new List<ActorFilm>()
                {
                    new ActorFilm()
                    {
                        ActorID = 1,
                        Film = new Film()
                        {
                            Name = "Herr der Ringe"
                        }
                       
                    },
                    new ActorFilm()
                    {
                        ActorID = 1,
                        Film = new Film()
                        {
                            Name = "Herr der Ringe 2"
                        }

                    }
                }
            }); ; ;

            genericrepositoryStub
                .Setup(x => x.GetByPredicate(It.IsAny<Expression<Func<Actor, bool>>>(), includes))
                .ReturnsAsync(actorList);

            var filmservices = new FilmService(genericrepositoryStub.Object);
            IEnumerable<FilmDto> result = filmservices.GetFilmByActorName("Hallo");
            Assert.IsTrue(result.Any(x => x.Name == "Herr der Ringe") && result.Any(x => x.Name == "Herr der Ringe 2"));
           
        }
        [TestMethod]
        public void GetFilmByLengthTest()
        {
            var genericrepositoryStub = new Moq.Mock<IGenericRepository>();

            List<Film> FilmList = new List<Film>();

            FilmList.AddRange(new List<Film>()
            {
            new Film
            {
                ID = 1,
                Name = "Herr der Ringe",
                Length = 210
            },
            new Film()
            {
                ID = 2,
                Name = "Der BigLebowski",
                Length = 180
            },
            new Film
            {
                ID = 3,
                Name = "Herr der Kuerze",
                Length = 0
            },
            new Film()
            {
                ID = 4,
                Name = "Der Dude",
                Length = 5000
            },
            new Film
            {
                ID = 5,
                Name = "Herr der laenge",
                Length = 500000
            },
            new Film()
            {
                ID = 6,
                Name = "THIS IS SPARTA",
                Length = 190
            }
            });

            genericrepositoryStub
                .Setup(x => x.GetAll<Film>())
                .Returns(FilmList);

            var filmservices = new FilmService(genericrepositoryStub.Object);
            IEnumerable<FilmDto> result = filmservices.GetFilmsByLenght(200,220);
            Assert.IsTrue(result.Any(x => x.Name == "Herr der Ringe"));
        }
    }
}
