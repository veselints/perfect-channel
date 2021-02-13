<template>
  <div>
    <h3>Completed Todos:</h3>
    <todo-table :todos="completed"></todo-table>
    <h3>Pending Todos:</h3>
    <todo-table :todos="pending"></todo-table>
    <h3>Create Todo:</h3>
    <label>Description:<input type="text" v-model="descr"><input type="button" value="Add" @click="onClick"></label>
    <h3>Status:</h3>
    <span :text="error"></span>
  </div>
</template>

<script>

import TodoTable from './TodoTable.vue'

export default {
  name: 'Main',
  components: {
    TodoTable
  },
  data () {
    return {
      descr: ''
    }
  },
  computed: {
    completed () {
      return this.$store.getters.doneTodos
    },
    pending () {
      return this.$store.getters.pendingTodos
    },
    error () {
      return this.$store.getters.getError
    }
  },
  mounted () {
    this.$store.dispatch('readTodos')
  },
  methods: {
    onClick () {
      if (this.descr) {
        this.$store.dispatch('createTodo', this.descr)
      }
    }
  }
}
</script>

<style scoped>

</style>
