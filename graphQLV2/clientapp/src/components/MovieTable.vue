<template>
    <div>
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
                <tr>
                    <td colspan="4">The database in empty. Add a new item using the input above.</td>
                </tr>
            </tbody>
        </table>
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
                    <td colspan="3">Select a movie to show his casting</td>
                </tr>
            </tbody>
        </table>
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
                actors: []
            }
        },
        created() {
            var url = 'http://localhost:5000/graphql';
            var getMoviesQuery = "{ movies { id, title, year, director} }";

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
                console.log("clicked on " + movieId);
                var url = 'http://localhost:5000/graphql';
                var getMoviesQuery = "{ movie(id: " + movieId + ") { actors { id, name, character } } }";
                console.log(getMoviesQuery);
                this.fetchData(url, getMoviesQuery)
                    .then(response => response.json())
                    .then(data => this.actors = data.data.movie.actors);
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
        cursor: pointer;
    }

    th, td {
        min-width: 120px;
        padding: 10px 20px;
    }
</style>
