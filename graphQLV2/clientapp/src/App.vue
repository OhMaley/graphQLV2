<template>
    <div id="app">
        <h1>Your best movies</h1>
        <MovieTable/>
    </div>
</template>

<script>
import MovieTable from './components/MovieTable.vue'

export default {
  name: 'app',
  components: {
    MovieTable
  }
}
</script>

<style>
    #app {
      font-family: 'Avenir', Helvetica, Arial, sans-serif;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
      text-align: center;
      color: #2c3e50;
      margin-top: 60px;
    }
</style>
