# Movie
Set Schedule

Test Movie Project
To open project open from github then use below url to open from github
URL : https://github.com/nagib29/Movie.git

***Need Visual studio 2017 and .net core sdk 2.1 to open the project***

API URL for get request:
1.	http://localhost:50367/api/searchmovies/GetSearchResult/test/1

Here “test” is search value and 1 is userid to log request. It return movies,tvshows and person.

2.	http://localhost:50367/api/searchmovies/GetMovieById/1/1

Here url end two values “1” is movie  id and “1” is userid to log request. It returns movies with provide id.

3.	http://localhost:50367/api/searchmovies/GetTvShowById/1/1

Here url end two values “1” is tv show  id and “1” is userid to log request. It returns tv shows with provide id.

4.	http://localhost:50367/api/searchmovies/FindActorById/1/1

Here url end two values “1” is actor/person  id and “1” is userid to log request. It returns actor/person with provide id.


**** To Log each request and response I used logging.cs class and below middle ware (RequestResponseLoggingMiddleware) to save userid, request , response and requestdate. Also from here same request is made again I am returning response from save data. ****



*** I have used StartUp.cs file to add dbcontext class and interface movie and its implementation
services.AddScoped<IMovieRepository, MockMovieRepository>();

services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MovieDbConnection")));
 

*** I have used middleware to log every request
app.UseMiddleware<RequestResponseLoggingMiddleware>();

*** I also followed constructor and dependency injection and repository pattern ***
IMovieRepository.cs interface
MockMovieRepository.cs actual implementation
