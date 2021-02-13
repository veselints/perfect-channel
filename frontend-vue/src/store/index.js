import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const ROOT_URL = 'http://localhost:50454/api/task'

export const getters = {
  doneTodos: state => {
    return state.todos.filter(todo => todo.completed)
  },
  pendingTodos: state => {
    return state.todos.filter(todo => !todo.completed)
  },
  getError: state => {
    return state.error ? state.error.message : ''
  }
}

export const mutations = {
  populateTodos (state, todos) {
    state.todos = todos
  },
  remoteError (state, err) {
    state.error = err
  },
  addTodo (state, todo) {
    state.todos.push(todo)
  },
  updateTodo (state, todo) {
    const item = state.todos.find(t => t.id === todo.id)
    Object.assign(item, todo)
  }
}

export const actions = {
  readTodos (context) {
    axios.get(ROOT_URL, {
      headers: { 'Access-Control-Allow-Origin': '*' }
    })
      .then(result => context.commit('populateTodos', result.data))
      .catch((err) => context.commit('remoteError', err))
  },
  createTodo (context, description) {
    axios.post(ROOT_URL, {
      description
    }, {
      headers: { 'Access-Control-Allow-Origin': '*' }
    })
      .then(result => context.commit('addTodo', result.data))
      .catch((err) => context.commit('remoteError', err))
  },
  updateTodo (context, todo) {
    axios.put(ROOT_URL, todo, {
      headers: { 'Access-Control-Allow-Origin': '*' }
    })
      .then(result => context.commit('updateTodo', result.data))
      .catch((err) => context.commit('remoteError', err))
  }
}

export default new Vuex.Store({
  state: {
    todos: [],
    error: null
  },
  mutations,
  actions,
  getters
})
