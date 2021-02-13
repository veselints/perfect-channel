<template>
  <div>
    <h3>Completed Todos:</h3>
      <todo-table :todos="completed"></todo-table>
    <h3>Pending Todos:</h3>
      <todo-table :todos="pending"></todo-table>
  </div>
</template>

<script>

import TodoTable from './TodoTable.vue'

export default {
  name: 'Main',
  components: {
    TodoTable
  },
  computed: {
    completed () {
      return this.$store.getters.doneTodos
    },
    pending () {
      return this.$store.getters.pendingTodos
    }
  },
  mounted () {
    this.$store.dispatch('readTodos')
  }
}
</script>

<style scoped>

</style>
