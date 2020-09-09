<template>
    <div>
        <div id="moviesDiv">
            <h2>Movies</h2>
            <table id="movieTable">
                <tr>
                    <th v-for="header in moviesHeaders" v-bind:key="header">{{header}}</th>
                </tr>
                <tbody v-if="movies.length">
                    <tr v-for="movie in movies" v-bind:key="movie.id" v-on:click="movieSelected(movie.id)">
                        <td v-for="(item, key, index) in movie" v-bind:key="index">{{item}}</td>
                    </tr>
                </tbody>
                <tbody v-else>
                    <tr id="databaseEmptyRow">
                        <td colspan="4">The database in empty. Add a new movie using the input below.</td>
                    </tr>
                </tbody>
                <tbody>
                    <tr id="addMovieRow">
                        <td>
                            <button v-on:click="addMovie">Add</button>
                        </td>
                        <td>
                            <input v-model="inputNewMovieTitle">
                        </td>
                        <td>
                            <input v-model="inputNewMovieYear">
                        </td>
                        <td>
                            <input v-model="inputNewMovieDirector">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div id="actorsDiv">
            <h2 v-if="isMovieSelected">Actors playing in {{selectedMovie.title}}</h2>
            <h2 v-else>Select a movie to show his casting</h2>
            <table id="actorTable">
                <tr>
                    <th v-for="header in actorsHeaders" v-bind:key="header">{{header}}</th>
                </tr>
                <tbody v-if="actors.length">
                    <tr v-for="actor in actors" v-bind:key="actor.id">
                        <td v-for="(item, key, index) in actor" v-bind:key="index">{{item}}</td>
                    </tr>
                </tbody>
                <tbody v-else>
                    <tr>
                        <td colspan="3">The casting for this movie is empty. Add a new actor using the input below.</td>
                    </tr>
                </tbody>
                <tr v-if="isMovieSelected" id="addActorRow">
                    <td>
                        <button v-on:click="addActorToMovie">Add</button>
                    </td>
                    <td>
                        <input v-model="inputNewActorName">
                    </td>
                    <td>
                        <input v-model="inputNewActorCharacter">
                    </td>
                </tr>
            </table>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                moviesHeaders: [
                    "Id",
                    "Movie",
                    "Release year",
                    "Director"],
                movies: [],
                actorsHeaders: [
                    "Id",
                    "Name",
                    "Character"],
                actors: [],
                isMovieSelected: false,
                selectedMovie: null,
                inputNewMovieTitle: "",
                inputNewMovieYear: "",
                inputNewMovieDirector: "",
                inputNewActorName: "",
                inputNewActorCharacter: ""
            }
        },
        created() {
            var url = 'http://localhost:5000/graphql';
            var getMoviesQuery = "{ movies { id, title, year, director } }";

            this.fetchData(url, getMoviesQuery)
                .then(response => response.json())
                .then(data => this.movies = data.data.movies);
        },
        methods: {
            fetchData: function (url, query) {
                return fetch(url, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Accept': 'application/json',
                    },
                    body: JSON.stringify({
                        query: query
                    })
                })
            },
            movieSelected: function (movieId) {
                this.isMovieSelected = true;
                this.selectedMovie = this.movies.find(movie => {
                    return movie.id === movieId;
                })
                var url = 'http://localhost:5000/graphql';
                var getMoviesQuery = "{ movie(id: " + this.selectedMovie.id + ") { actors { id, name, character } } }";
                this.fetchData(url, getMoviesQuery)
                    .then(response => response.json())
                    .then(data => this.actors = data.data.movie.actors);
            },
            addMovie: function () {
                if (this.inputNewMovieTitle) {
                    var url = 'http://localhost:5000/graphql';
                    var addUserMovieQuery = "mutation addUserMovie{ addMovie(title: \"" + this.inputNewMovieTitle + "\", year: \"" + this.inputNewMovieYear + "\", director: \"" + this.inputNewMovieDirector + "\") { id, title, year, director } }";

                    this.fetchData(url, addUserMovieQuery)
                        .then(response => response.json())
                        .then(data => this.movies.push(data.data.addMovie));
                    this.inputNewMovieTitle = "";
                    this.inputNewMovieYear = "";
                    this.inputNewMovieDirector = "";
                }
            },
            addActorToMovie: function () {
                if (this.inputNewActorName) {
                    var url = 'http://localhost:5000/graphql';
                    var addActorToMovieQuery = "mutation addUserActorToMovie{ addActorToMovie(id: \"" + this.selectedMovie.id + "\", name: \"" + this.inputNewActorName + "\", character: \"" + this.inputNewActorCharacter + "\") { id, name, character } }";

                    this.fetchData(url, addActorToMovieQuery)
                        .then(response => response.json())
                        .then(data => this.actors.push(data.data.addActorToMovie));
                    this.inputNewActorName = "";
                    this.inputNewActorCharacter = "";
                }
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    div {
        display: flex;
        flex-direction: row;
    }

    #actorsDiv, #moviesDiv {
        height: 100%;
        width: 50%;
        display: flex;
        flex-direction: column;
    }

    table {
        flex-grow: 1;
        margin-left: auto;
        margin-right: auto;
        text-align: center;
        font-family: Helvetica Neue, Arial, sans-serif;
        font-size: 14px;
        color: #444;
        border: 2px solid #42b983;
        border-radius: 3px;
        background-color: #fff;
    }

    th {
        background-color: #42b983;
        color: rgba(255, 255, 255, 0.66);
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
    }

    td {
        background-color: #f9f9f9;
    }

    #movieTable td {
        cursor: pointer;
    }

    #addMovieRow td, #databaseEmptyRow td{
        cursor: default;
    }

    th, td {
        min-width: 120px;
        padding: 10px 20px;
    }

    button {
        border-radius: 5px;
        border: 2px solid #42b983;
        cursor: pointer;
    }
</style>
