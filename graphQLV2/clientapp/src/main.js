import Vue from 'vue'
import App from './App.vue'

Vue.config.productionTip = false

new Vue({
    render: h => h(App)
}).$mount('#app')

/*
console.log('Add Pierre');
var addPierreStr = "mutation add { addAuthor(name: \"Pierre\") { id, name } }";

fetch('http://localhost:5000/graphql', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
    },
    body: JSON.stringify({
        query: addPierreStr
    })
})
    .then(response => response.json())
    .then(data => console.log('add Pierre, response:', JSON.stringify(data.data, null, 2)));


console.log('Add Paul');
var addPaulStr = "mutation add { addAuthor(name: \"Paul\") { id, name } }";

fetch('http://localhost:5000/graphql', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
    },
    body: JSON.stringify({
        query: addPaulStr
    })
})
    .then(response => response.json())
    .then(data => console.log('add Paul, response:', JSON.stringify(data.data, null, 2)));


console.log('get Authors');
var getAuthorsStr = "{ authors { id, name } }";

fetch('http://localhost:5000/graphql', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
    },
    body: JSON.stringify({
        query: getAuthorsStr
    })
})
    .then(response => response.json())
    .then(data => console.log('get authors, response:', JSON.stringify(data.data, null, 2)));
*/